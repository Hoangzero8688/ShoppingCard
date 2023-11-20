using System.ComponentModel.DataAnnotations;

namespace ASM_Net104_ShoppingCard.Models
{
    public class ImgUrl
    {

        [Key]
        public int Id{ get; set; }

        public string Url1 { get; set; }
        public string Url2 { get; set; }
        public string Url3 { get; set; }
        public string Url4 { get; set; }

        public ICollection<ProductVariant> productVariants { get; set; }
    }
}
