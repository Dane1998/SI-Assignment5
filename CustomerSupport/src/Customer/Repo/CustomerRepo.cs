using Customer.Data;
using Microsoft.EntityFrameworkCore;

namespace Customer.Repo
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly CustomerDataContext _db;

        public CustomerRepo(CustomerDataContext db)
        {
            _db = db;
        }

        public async Task<Customers> GetCustomerByEmail(string email)
        {
            return await _db.Customer.FirstOrDefaultAsync(x => x.EmailAddress == email);
        }

        public async Task<Customers> GetCustomerById(int customerId)
        {
            return await _db.Customer.FirstOrDefaultAsync(x => x.Id == customerId);
        }
    }
}
