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
        [DisplayName("Русский язык")]
        [Result("Русский язык")]
        [Required]
        public float Russian { get; set; }
        [DisplayName("Математика")]
        [Result("Математика")]
        [Required]
        public float Math { get; set; }
        [DisplayName("Обществознание")]
        [Result("Обществознание")]
        [Required]
        public float SocialStudies { get; set; }
        [DisplayName("Английский язык")]
        [Result("Английский язык")]
        [Required]
        public float English { get; set; }
        [DisplayName("Информатика")]
        [Result("Информатика")]
        [Required]
        public float Informatics { get; set; }
        [DisplayName("История")]
        [Result("История")]
        [Required]
        public float History { get; set; }
        [DisplayName("Биология")]
        [Result("Биология")]
        [Required]
        public float Biology { get; set; }
        [DisplayName("Химия")]
        [Result("Химия")]
        [Required]
        public float Chemistry { get; set; }
        [DisplayName("География")]
        [Result("География")]
        [Required]
        public float Geography { get; set; }
        [DisplayName("Физика")]
        [Result("Физика")]
        [Required]
        public float Physics { get; set; }
    }
}
