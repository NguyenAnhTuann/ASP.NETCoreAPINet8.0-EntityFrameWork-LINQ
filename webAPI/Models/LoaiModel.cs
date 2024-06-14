using System.ComponentModel.DataAnnotations;

namespace webAPI.Models
{
    public class LoaiModel
    {
        [Required]
        [MaxLength(50)]
        public string TenLoai { get; set; }
    }
}
