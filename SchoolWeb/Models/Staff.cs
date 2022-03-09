using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.Models
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }
        public string Category { get; set; }
        public int Total { get; set; }
        public int HasHighEdu { get; set; }
        public int HasHighQuality { get; set; }
        public int HasFirstQuality { get; set; }
    }
}
