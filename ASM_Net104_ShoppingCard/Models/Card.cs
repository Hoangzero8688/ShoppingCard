using System.ComponentModel.DataAnnotations;

namespace ASM_Net104_ShoppingCard.Models
{
    public class Card
    {
        [Key]
        public int Id { get; set; }

        [MinLength(0)]
        public int Quantity { get; set; }

        // Khóa ngoại trỏ đến User
        public int UserId { get; set; }
        // Navigation property để EF có thể tạo mối quan hệ
        public User User { get; set; }

        public ICollection<CardItem> cardItems { get; set;}

       

    }
}
