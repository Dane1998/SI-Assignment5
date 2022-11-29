using System.ComponentModel.DataAnnotations;

namespace Customer.Data
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(128)]
        public string UserName { get; set; }

        [Required]
        [StringLength(128, MinimumLength = 128)]
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }  
        public DateTime CreatedDate { get; set; }
        public Role Role { get; set; }
        public int RoleId { get; set; }

    }
}
