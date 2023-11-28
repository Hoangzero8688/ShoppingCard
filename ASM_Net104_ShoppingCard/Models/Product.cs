using NuGet.Protocol.Plugins;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM_Net104_ShoppingCard.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string? MaSp { get; set; }

        
        public DateTime ProductionYear { get; set; }

        public float Price { get; set; }

        public string? Material { get; set; }

        public string? Image { get; set; }
       // [Range(0, int.MaxValue, ErrorMessage = "Invalid Quantity")]

        public string? Description { get; set; }

        public bool Status { get; set; }

        public int categoryid { get; set; }

        [ForeignKey("categoryid")]
        public virtual Category Category { get; set; }

        public ICollection<ProductVariant> ProductVariants { get; set; }
    }
}
