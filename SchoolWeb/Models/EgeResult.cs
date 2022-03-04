using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.Models
{
    public class EgeResult
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Год")]
        public int Year { get; set; }
        [DisplayName("Русский язык")]
        public float Russian { get; set; }
        [DisplayName("Математика (Базовая)")]
        public float MathBase { get; set; }
        [DisplayName("Математика (Профильная)")]
        public float MathProfi { get; set; }
        [DisplayName("История")]
        public float History { get; set; }
        [DisplayName("Обществознание")]
        public float SocialStudies { get; set; }
        [DisplayName("Физика")]
        public float Physics { get; set; }
        [DisplayName("Химия")]
        public float Chemistry { get; set; }
        [DisplayName("География")]
        public float Geography { get; set; }
        [DisplayName("Биология")]
        public float Biology { get; set; }
        [DisplayName("Информатика")]
        public float Informatics { get; set; }
        [DisplayName("Английский язык")]
        public float English { get; set; }
        [DisplayName("Литература")]
        public float Literature { get; set; }
    }
}
