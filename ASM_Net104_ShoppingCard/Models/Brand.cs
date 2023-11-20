using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASM_Net104_ShoppingCard.Models
{
    public class Brand
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }
        //[DisplayName("Name Brand")]

        public ICollection<Category> categories { get; set; }

    }
}
