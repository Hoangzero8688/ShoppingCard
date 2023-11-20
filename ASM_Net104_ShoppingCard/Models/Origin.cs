using System.ComponentModel.DataAnnotations;

namespace ASM_Net104_ShoppingCard.Models
{
    public class Origin
    {
        [Key]
        public int Id { get; set; }

        public string OriginName { get; set; }

        public ICollection<ProductVariant> productVariants { get; set; }
    }
}
