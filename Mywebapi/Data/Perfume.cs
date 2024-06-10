using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mywebapi.Data
{
    [Table("SANPHAM")]
    public class Perfume
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(100)]
        public string Tittle { get; set; }
        public string Description { get; set; }
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        [Range(0, 100)]
        public int Quality { get; set; }

    }
}
