using System.ComponentModel.DataAnnotations.Schema;

namespace Customer.Data
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }  
        public DateTime CreatedDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public virtual string NormalizedEmail { get; private set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public virtual string NormalizedUserName { get; private set; }

    }
}
