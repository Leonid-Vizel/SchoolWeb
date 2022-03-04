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
        [DisplayName("Русский язык")]
        public float Russian { get; set; }
        [DisplayName("Математика")]
        public float Math { get; set; }
        [DisplayName("Обществознание")]
        public float SocialStudies { get; set; }
        [DisplayName("Английский язык")]
        public float English { get; set; }
        [DisplayName("Информатика")]
        public float Informatics { get; set; }
        [DisplayName("История")]
        public float History { get; set; }
        [DisplayName("Биология")]
        public float Biology { get; set; }
        [DisplayName("Химия")]
        public float Chemistry { get; set; }
        [DisplayName("География")]
        public float Geography { get; set; }
        [DisplayName("Физика")]
        public float Physics { get; set; }
    }
}
