using Confluent.Kafka;
using Shared.Shared;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Review.Services
{
    public class ConsumerService
    {
        public class ApacheKafkaConsumerService : IHostedService
        {
            private readonly string topic = "create_review";
            private readonly string groupId = "review_group";
            private readonly string bootstrapServers = "localhost:9092";

            private readonly IServiceProvider _serviceProvider;


            public ApacheKafkaConsumerService(IServiceProvider serviceProvider)
            {
                _serviceProvider = serviceProvider;

            }

            public Task StartAsync(CancellationToken cancellationToken)
            {
                var config = new ConsumerConfig
                {
                    GroupId = groupId,
                    BootstrapServers = bootstrapServers,
                    AutoOffsetReset = AutoOffsetReset.Earliest
                };

                try
                {
                    using (var consumerBuilder = new ConsumerBuilder
                    <Ignore, string>(config).Build())
                    {
                        consumerBuilder.Subscribe(topic);
                        var cancelToken = new CancellationTokenSource();

                        using var scope = _serviceProvider.CreateScope();
                        var service = scope.ServiceProvider.GetRequiredService<IReviewService>();

                        try
                        {
                            while (true)
                            {
                                var consumer = consumerBuilder.Consume
                                   (cancelToken.Token);
                                var test = consumer.Message.Value;


                                var obj = System.Text.Json.JsonSerializer.Deserialize<ReviewDTO>(test);
                                Debug.WriteLine(obj.ReviewText);

                                using (SqlConnection conn = new SqlConnection())
                                {
                                    conn.ConnectionString = "Server=127.0.0.1,5433;Database=Reviewdb;User Id=postgres;Password=postgres;TrustServerCertificate=True";

                                    conn.Open();

                                    SqlCommand sqlCommand = new SqlCommand($"INSERT INTO Reviews (UserId, RestaurantId, DeliveryId, Message, ReviewDate, Rating) VALUES (@0, @1, @2, @3)", conn);
                                    sqlCommand.Parameters.Add(new SqlParameter("0", obj.CustomerId));
                                    sqlCommand.Parameters.Add(new SqlParameter("1", obj.ReviewText));
                                    sqlCommand.Parameters.Add(new SqlParameter("2", DateTime.UtcNow));
                                    sqlCommand.Parameters.Add(new SqlParameter("3", obj.Rating));

                                    sqlCommand.ExecuteNonQuery();
                                }
                            }
                        }
                        catch (OperationCanceledException)
                        {
                            consumerBuilder.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }

                return Task.CompletedTask;
            }
            public Task StopAsync(CancellationToken cancellationToken)
            {
                return Task.CompletedTask;
            }
        }
    }
}
