using System.ComponentModel.DataAnnotations;

namespace Customer.Data
{ 
    public class Role
    {
        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public ICollection<User> UserRoles { get; set; }
    }
}
