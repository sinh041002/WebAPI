using System.ComponentModel.DataAnnotations;

namespace WebAPI.Model
{
    public class LoaiModel
    { 

          [Required]
          [MaxLength(255)]
          public string TenLoai { get; set; }
    }
}
