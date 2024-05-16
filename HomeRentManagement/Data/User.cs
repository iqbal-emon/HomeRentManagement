using System.ComponentModel.DataAnnotations;

namespace HomeRentManagement.Data
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }

        public virtual ICollection<House> Houses { get; set; }
    }

}
