using System.ComponentModel.DataAnnotations.Schema;

namespace HomeRentManagement.Data
{
    public class Role
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortForm { get; set; }
        public int StatusId { get; set; } = 1;

        [ForeignKey("StatusId")]
        public virtual Status? statuss { get; set; }



    }
}
