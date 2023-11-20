using System.ComponentModel.DataAnnotations;

namespace ASM_Net104_ShoppingCard.Models
{
    public class Size
    {
        [Key]
        public int Id { get; set; }

        public string SizeName { get; set; }
        public int MinHeight { get; set; }
        public int MaxHeight { get; set; }
        public float Weight { get; set; }

        public ICollection<ProductVariant> productVariants { get; set; }
    }
}
