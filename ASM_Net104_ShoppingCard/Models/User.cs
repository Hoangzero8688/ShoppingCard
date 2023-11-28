using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM_Net104_ShoppingCard.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }
        [Display(Name = "PassWord")]
        [Required(ErrorMessage = "PassWord Required")]
        [StringLength(25, MinimumLength = 8, ErrorMessage = "Min Lenght is 8 Max Lenght 50")]
        public string PassWord { get; set; }
        public string FullName { get; set; }
        [Phone]
        [StringLength(10, ErrorMessage = "Input 10 character!")]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Erro format Email!")]
        public string Email { get; set; }
        public string? Address { get; set; }
        public DateTime? Yob { get; set; }

        // Navigation property để truy cập giỏ hàng từ User
        public Card? Card { get; set; }

        //set Role

        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        // set invoices
        
        public ICollection<Invoice> Invoices { get; set; }

    }
}
