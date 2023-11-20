using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASM_Net104_ShoppingCard.Models
{
    public class InvoiceItem
    {
        [Key]
        public int Id { get; set; }

        [MinLength(0)]
        public int Quantity { get; set; }

        [MinLength(0)]
        public float Price { get; set; }

        public int status { get; set; }

        //set Product
        public int ProductVariantId { get; set; }
        [ForeignKey("ProductVariantId")]
        public virtual ProductVariant ProductVariant { get; set; }

        //set Invoice
        public int InvoiceId { get; set; }
        [ForeignKey("InvoiceId")]
        public virtual Invoice Invoice { get; set; }

        //set Review 

        public int? ReviewId { get; set; }
        [ForeignKey("ReviewId")]
        public virtual Review Review { get; set; }

    }
}
