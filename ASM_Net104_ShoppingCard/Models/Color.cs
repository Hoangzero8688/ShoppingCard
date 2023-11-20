using System.ComponentModel.DataAnnotations;

namespace ASM_Net104_ShoppingCard.Models
{
    public class Color
    {
        [Key]
        public int Id { get; set; }

        public string ColorName { get; set; }

        public ICollection<ProductVariant> productVariants { get; set; }
    }
}
