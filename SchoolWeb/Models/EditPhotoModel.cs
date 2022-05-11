using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolWeb.Models
{
    public class EditPhotoModel
    {
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
        [ValidateNever]
        public IFormFile ImageFile { get; set; }

        public static EditPhotoModel FromPhotoModel(PhotoModel model)
        {
            EditPhotoModel editModel = new EditPhotoModel();
            editModel.Id = model.Id;
            editModel.Title = model.Title;
            editModel.Description = model.Description;
            editModel.ImageName = model.ImageName;
            return editModel;
        }
    }
}
