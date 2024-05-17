using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public int RoleID { get; set; } = 3;

        [ForeignKey("RoleID")]
        public virtual Role Role { get; set; } // Change to Role, not ICollection<Role>
        public int StatusId { get; set; } = 1;
        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }
        public virtual ICollection<House> Houses { get; set; }
    }

}
