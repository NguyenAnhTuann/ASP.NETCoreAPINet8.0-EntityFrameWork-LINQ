using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webAPI.Data
{
    [Table("NuocHoa")]
    public class NuocHoa
    {
        [Key]
        public int MaNH { get; set; }

        [Required]
        [MaxLength(100)]
        public string TenNH { get; set; }
        [Range(0, double.MaxValue)]
        public int Dongia { get; set; }
        public int? MaLoai { get; set; }
        [ForeignKey("MaLoai")]
        public Loai loai { get; set; }

    }
}
