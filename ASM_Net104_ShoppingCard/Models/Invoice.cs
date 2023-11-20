using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM_Net104_ShoppingCard.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        public int BoughtAt { get; set; }

        [MinLength(0)]
        public float TotalPrice { get; set;}


        public DateTime DateCreate { get; set; }

        public int status { get; set; }

        //set Uset
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        //set invoice Item
        public ICollection<InvoiceItem> InvoiceItems { get; set;}



    }
}
