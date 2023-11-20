using ASM_Net104_ShoppingCard.Configuration;
using ASM_Net104_ShoppingCard.Models;
using Microsoft.EntityFrameworkCore;

namespace ASM_Net104_ShoppingCard.Context
{
    public class MyDbContext:DbContext 
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options):base(options)
        {
            
        }

      public  DbSet<Brand> brands {  get; set; }
        public DbSet<Category> categories {  get; set; }
        public DbSet<Product> Products {  get; set; }
        public DbSet<ProductVariant> productVariants {  get; set; }
        public DbSet<ImgUrl> imgUrls {  get; set; }
        public DbSet<Size> sizes {  get; set; }
        public DbSet<Color> colors {  get; set; }
        public DbSet<Origin> origins {  get; set; }
        public DbSet<Card> cards {  get; set; }
        public DbSet<CardItem> cardItems {  get; set; }
        public DbSet<User> users {  get; set; }
        public DbSet<Role> roles {  get; set; }
        public DbSet<Invoice> invoices {  get; set; }
        public DbSet<InvoiceItem> invoiceItems {  get; set; }
        public DbSet<Review> reviews {  get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Định nghĩa lớp CardItem có 2 khoá chính
            modelBuilder.Entity<CardItem>().HasKey(am => new
            {
                am.ProductVariantId,
                am.CardId
            });
            // Định nghĩa mqh nhiều lớp

            modelBuilder.Entity<CardItem>().HasOne(m=> m.productVariant).WithMany(am => am.cardItems).HasForeignKey(am => am.ProductVariantId);
            modelBuilder.Entity<CardItem>().HasOne(n=> n.card).WithMany(am => am.cardItems).HasForeignKey(am => am.CardId);

            // Mối quan hệ 1-1 giữa User và Card
            modelBuilder.Entity<User>()
                .HasOne(u => u.Card)
                .WithOne(c => c.User)
                .HasForeignKey<Card>(c => c.UserId);

            // Configuration class brandconfig
            //modelBuilder.ApplyConfiguration(new BrandConfig());

        }
    }
}
