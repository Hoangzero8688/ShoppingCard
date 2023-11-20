using ASM_Net104_ShoppingCard.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASM_Net104_ShoppingCard.Configuration
{
    public class BrandConfig : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            // Đặt tên bảng
            builder.ToTable("Brand");

            // Set khóa chính
            builder.HasKey(p => p.id);

            // Set thuộc tính
            builder.Property(p => p.name).IsRequired().HasMaxLength(255);
            // Thêm các cấu hình khác nếu cần

            // Các cấu hình mối quan hệ nếu có
            // Ví dụ: builder.HasMany(b => b.Categories).WithOne(c => c.Brand).HasForeignKey(c => c.IdBrand);
        }
    }
}
