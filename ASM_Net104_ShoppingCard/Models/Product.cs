using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM_Net104_ShoppingCard.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        //public Guid 
        public string Name { get; set; }

        public string? MaSp{ get; set; }
        [MinLength(0)]
        public DateTime ProductionYear { get; set; }
        public float Price { get; set; }

        public string? Material { get; set; }
        [MinLength(0)]
        public float? Weight { get; set; }
        [MinLength(0)]
        public int Quantity { get; set; }

        public string? Description { get; set; }
        public int Status  { get; set; }

        public int categoryid { get; set; }
        [ForeignKey("categoryid")]
        public virtual Category Category { get; set; }

        public ICollection<ProductVariant> productVariants { get; set; }



    }
}
