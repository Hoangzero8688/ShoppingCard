using System.ComponentModel.DataAnnotations;

namespace ASM_Net104_ShoppingCard.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> users { get; set; }
    }
}
