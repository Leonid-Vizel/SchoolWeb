using SchoolWeb.Attributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.Models
{
    public class OgeResult
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Год")]
        [Required]
        public int Year { get; set; }
        [Result("Русский язык")]
        [Required]
        public float Russian { get; set; }
        [Result("Математика")]
        [Required]
        public float Math { get; set; }
        [Result("Обществознание")]
        [Required]
        public float SocialStudies { get; set; }
        [Result("Английский язык")]
        [Required]
        public float English { get; set; }
        [Result("Информатика")]
        [Required]
        public float Informatics { get; set; }
        [Result("История")]
        [Required]
        public float History { get; set; }
        [Result("Биология")]
        [Required]
        public float Biology { get; set; }
        [Result("Химия")]
        [Required]
        public float Chemistry { get; set; }
        [Result("География")]
        [Required]
        public float Geography { get; set; }
        [Result("Физика")]
        [Required]
        public float Physics { get; set; }
    }
}
