using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM_Net104_ShoppingCard.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public int Rate { get; set; }
        public string? Comment { get; set; }

        //set InvoiceItem

        public int? InvoiceItemId { get; set; } // Đặt kiểu dữ liệu là Guid? để có thể chấp nhận giá trị null
        [ForeignKey("InvoiceItemId")]
        public virtual InvoiceItem InvoiceItem { get; set; }
    }
}
