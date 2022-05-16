using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.Models
{
    public class EditPhotoModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите название для фото")]
        [DisplayName("Название:")]
        [MinLength(1, ErrorMessage = "Слишком короткое название")]
        [MaxLength(80, ErrorMessage = "Слишком длинное название")]
        public string Title { get; set; }
        [DisplayName("Описание (Необязательно):")]
        [ValidateNever]
        public string? Description { get; set; }
        [ValidateNever]
        public IFormFile? ImageFile { get; set; }

        public static EditPhotoModel FromPhotoModel(PhotoModel model)
        {
            return new EditPhotoModel()
            {
                Title = model.Title,
                Description = model.Description,
                ImageFile = model.ImageFile
            };
        }
    }
}
