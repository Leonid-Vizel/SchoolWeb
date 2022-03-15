using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.Models
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Название МО должно быть обязательно указано")]
        [DisplayName("Наименование МО:")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Количество учителей в МО должно быть обязательно указано")]
        [DisplayName("Учителей в МО:")]
        public int Total { get; set; }
        [Required(ErrorMessage = "Укажите значение поля")]
        [DisplayName("Среди них имеют высшее образование:")]
        public int HasHighEdu { get; set; }
        [Required(ErrorMessage = "Укажите значение поля")]
        [DisplayName("Среди них имеют высшую квал. категорию:")]
        public int HasHighQuality { get; set; }
        [Required(ErrorMessage = "Укажите значение поля")]
        [DisplayName("Среди них имеют I квал. категорию:")]
        public int HasFirstQuality { get; set; }
    }
}
