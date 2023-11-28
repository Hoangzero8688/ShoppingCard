using System.ComponentModel.DataAnnotations;

namespace ASM_Net104_ShoppingCard.Models
{
    public class CardItem
    {
        [Key]
        public int ProductVariantId { get; set; }
        public int CardId { get; set; }
        [MinLength(0)]
        public int Quantity { get; set; }
        public string? AddedAt { get; set; }
        public ProductVariant productVariant { get; set; }
        public Card card { get; set; }



    }
}
