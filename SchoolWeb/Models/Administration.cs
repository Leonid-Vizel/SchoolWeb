using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.Models
{
    public class Administration
    {
        [Key]
        public int Id { get; set; }
        public string Position { get; set; }
        public string Name { get; set; }
        public string Education { get; set; }
        public string Category { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
