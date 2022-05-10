using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolWeb.Models
{
    public class PhotoModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите название для фото")]
        [DisplayName("Название:")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Добавьте описание для фото")]
        [DisplayName("Описание:")]
        public string Description { get; set; }
        [ValidateNever]
        public string ImageName { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Добавьте фото")]
        public IFormFile ImageFile { get; set; }

        public override string ToString() => $"/gallery/{ImageName}";
    }
}
