using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM_Net104_ShoppingCard.Models
{
    public class ProductVariant
    {
        [Key]
        public int Id { get; set; }

        public string name { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public int ImgUrlId { get; set; }
        [ForeignKey("ImgUrlId")]
        public virtual ImgUrl ImgUrl { get; set; }
        public int SizeId { get; set; }
        [ForeignKey("SizeId")]
        public virtual Size Size  { get; set; }
        public int ColorId { get; set; }
        [ForeignKey("ColorId")]
        public virtual Color color { get; set; }
        public int OriginId { get; set; }
        [ForeignKey("OriginId")]

        public virtual Origin Origin { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Invalid Quantity")]
        public int Quantity { get; set; }

        public ICollection<CardItem> cardItems { get; set; }
        public ICollection<InvoiceItem> invoiceItems { get; set; }
    }
}
