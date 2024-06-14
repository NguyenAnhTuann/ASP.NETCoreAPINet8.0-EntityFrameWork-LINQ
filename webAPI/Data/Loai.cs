using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webAPI.Data
{
    [Table("Loai")]

    public class Loai
    {
        [Key]
        public int MaLoai { get; set; }
        [Required]
        [MaxLength(50)]
        public string TenLoai { get; set; }

        public virtual ICollection<NuocHoa> NuocHoas { get; set; }

    }
}
