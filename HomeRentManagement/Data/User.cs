using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeRentManagement.Data
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        [StringLength(11, ErrorMessage = "Phone number cannot be longer than 11 characters")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        public int RoleID { get; set; } = 2;

        [ForeignKey("RoleID")]
        public virtual Role Role { get; set; } // Change to Role, not ICollection<Role>
        public int StatusId { get; set; } = 1;
        [ForeignKey("StatusId")]
        public virtual Status? Status { get; set; }
        public virtual ICollection<House> Houses { get; set; }

    }

}
