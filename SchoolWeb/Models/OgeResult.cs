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
        public int Year { get; set; }
        [Result("Русский язык")]
        public float Russian { get; set; }
        [Result("Математика")]
        public float Math { get; set; }
        [Result("Обществознание")]
        public float SocialStudies { get; set; }
        [Result("Английский язык")]
        public float English { get; set; }
        [Result("Информатика")]
        public float Informatics { get; set; }
        [Result("История")]
        public float History { get; set; }
        [Result("Биология")]
        public float Biology { get; set; }
        [Result("Химия")]
        public float Chemistry { get; set; }
        [Result("География")]
        public float Geography { get; set; }
        [Result("Физика")]
        public float Physics { get; set; }
    }
}
