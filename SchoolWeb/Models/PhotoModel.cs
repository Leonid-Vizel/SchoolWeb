using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.Models
{
    public class PhotoModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public byte[] Data { get; set; }

        public override string ToString() => Data != null ? $"data:image/jpg;base64,{Convert.ToBase64String(Data)}" : string.Empty;
    }
}
