using Customer.Data;

namespace Customer.Repo
{
    public interface ICustomerRepo
    {
        public Task<Customers> GetCustomerById(int id);
        public Task<Customers> GetCustomerByEmail(string email);
    }
}