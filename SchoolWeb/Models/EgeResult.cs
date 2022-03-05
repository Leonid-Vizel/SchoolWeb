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
        public int Year { get; set; }
        [Result("Русский язык")]
        public float Russian { get; set; }
        [Result("Математика (Базовая)")]
        public float MathBase { get; set; }
        [Result("Математика (Профильная)")]
        public float MathProfi { get; set; }      
        [Result("История")]
        public float History { get; set; }       
        [Result("Обществознание")]
        public float SocialStudies { get; set; }        
        [Result("Физика")]
        public float Physics { get; set; }       
        [Result("Химия")]
        public float Chemistry { get; set; }        
        [Result("География")]
        public float Geography { get; set; }        
        [Result("Биология")]
        public float Biology { get; set; }        
        [Result("Информатика")]
        public float Informatics { get; set; }        
        [Result("Английский язык")]
        public float English { get; set; }       
        [Result("Литература")]
        public float Literature { get; set; }
    }
}
