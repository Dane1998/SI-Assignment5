using Confluent.Kafka;
using System.Diagnostics;
using System.Net;

namespace Customer.Services
{
    public interface IKafkaProducerService
    {
        public Task<bool> SendReviewRequest(string topic, string message);
    }

    public class KafkaProducerService : IKafkaProducerService
    {
        private readonly string server = "localhost:9092";

        public async Task<bool> SendReviewRequest(string topic, string jsonObject)
        {
            ProducerConfig config = new ProducerConfig
            {
                BootstrapServers = server,
                ClientId = Dns.GetHostName()
            };

            try
            {
                using (var producer = new ProducerBuilder<Null, string>(config).Build())
                {
                    var result = await producer.ProduceAsync(topic, new Message<Null, string>
                    {
                        Value = jsonObject
                    });

                    Debug.WriteLine(result);

                    return await Task.FromResult(true);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return await Task.FromResult(false);
        }
    }
}
