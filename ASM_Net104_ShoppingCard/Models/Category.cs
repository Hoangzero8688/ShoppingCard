using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM_Net104_ShoppingCard.Models
{
    public class Category
    {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        [DisplayName("Name Category")]

        public ICollection<Product> Products { get; set; }
        public int IdBrand { get; set; }
        [ForeignKey("IdBrand")]
        public virtual Brand Brand { get; set; }

        //public ICollection<Brand> Brands { get; set; }

    }
}
