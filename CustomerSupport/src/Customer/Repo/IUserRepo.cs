using Customer.Data;

namespace Customer.Repo
{
    public interface IUserRepo
    {
        public Task<User> GetUserById(int userId);
        public Task<User> GetUserByEmail(string email);
    }
}
