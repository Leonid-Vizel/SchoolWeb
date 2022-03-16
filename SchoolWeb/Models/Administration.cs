using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.Models
{
    public class Administration
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Занимаемая должность должна быть обязательно указана")]
        [DisplayName("Занимаемая должность:")]
        public string Position { get; set; }
        [Required(ErrorMessage = "ФИО сотрудника должно быть обязательно указано")]
        [DisplayName("ФИО:")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Образование сотрудника должно быть обязательно указано")]
        [DisplayName("Образование:")]
        public string Education { get; set; }
        [Required(ErrorMessage = "Квалификационная категория сотрудника должна быть обязательно указана")]
        [DisplayName("Квалификационная категория:")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Номер телефона сотрудника должен быть обязательно указан")]
        [DisplayName("Номер телефона:")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Электронная почта сотрудника должна быть обязательно указана")]
        [DisplayName("Электронная почта:")]
        [DataType(DataType.EmailAddress,ErrorMessage = "Значение не является валидным адресом электронной почты")]
        public string Email { get; set; }
    }
}
