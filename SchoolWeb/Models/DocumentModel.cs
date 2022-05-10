using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolWeb.Models
{
    public class DocumentModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите название для документа")]
        [DisplayName("Название:")]
        public string Title { get; set; }
        [ValidateNever]
        public string DocumentName { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Добавьте документ")]
        public IFormFile DocumentFile { get; set; }
    }
}
