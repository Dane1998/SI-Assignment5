using Customer.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Customer.Repo
{
    public class UserRepo : IUserRepo
    {
        private readonly CustomerDataContext _db;

        public UserRepo(CustomerDataContext db)
        {
            _db = db;
        }

        public async Task<User> GetRoleById(int userId)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.RoleId == userId);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.EmailAddress == email);
        }

        public async Task<User> GetUserById(int userId)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.UserId == userId);
        }
    }
}
