using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SchoolWeb.Attributes;

namespace SchoolWeb.Models
{
    public class EgeResult
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Год")]
        [Required]
        public int Year { get; set; }
        [Result("Русский язык")]
        [Required]
        public float Russian { get; set; }
        [Result("Математика (Базовая)")]
        [Required]
        public float MathBase { get; set; }
        [Result("Математика (Профильная)")]
        [Required]
        public float MathProfi { get; set; }      
        [Result("История")]
        [Required]
        public float History { get; set; }       
        [Result("Обществознание")]
        [Required]
        public float SocialStudies { get; set; }        
        [Result("Физика")]
        [Required]
        public float Physics { get; set; }       
        [Result("Химия")]
        [Required]
        public float Chemistry { get; set; }        
        [Result("География")]
        [Required]
        public float Geography { get; set; }        
        [Result("Биология")]
        [Required]
        public float Biology { get; set; }        
        [Result("Информатика")]
        [Required]
        public float Informatics { get; set; }        
        [Result("Английский язык")]
        [Required]
        public float English { get; set; }       
        [Result("Литература")]
        [Required]
        public float Literature { get; set; }
    }
}
