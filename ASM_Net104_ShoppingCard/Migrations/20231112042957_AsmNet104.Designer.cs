﻿// <auto-generated />
using System;
using ASM_Net104_ShoppingCard.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ASM_Net104_ShoppingCard.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20231112042957_AsmNet104")]
    partial class AsmNet104
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ASM_Net104_ShoppingCard.Models.Brand", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("brands");
                });

            modelBuilder.Entity("ASM_Net104_ShoppingCard.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("cards");
                });

            modelBuilder.Entity("ASM_Net104_ShoppingCard.Models.CardItem", b =>
                {
                    b.Property<int>("ProductVariantId")
                        .HasColumnType("int");

                    b.Property<int>("CardId")
                        .HasColumnType("int");

                    b.Property<string>("AddedAt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ProductVariantId", "CardId");

                    b.HasIndex("CardId");

                    b.ToTable("cardItems");
                });

            modelBuilder.Entity("ASM_Net104_ShoppingCard.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdBrand")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdBrand");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("ASM_Net104_ShoppingCard.Models.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ColorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("colors");
                });

            modelBuilder.Entity("ASM_Net104_ShoppingCard.Models.ImgUrl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Url1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("imgUrls");
                });

            modelBuilder.Entity("ASM_Net104_ShoppingCard.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BoughtAt")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<float>("TotalPrice")
                        .HasColumnType("real");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("invoices");
                });

            modelBuilder.Entity("ASM_Net104_ShoppingCard.Models.InvoiceItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("ProductVariantId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("ReviewId")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("ProductVariantId");

                    b.HasIndex("ReviewId");

                    b.ToTable("invoiceItems");
                });

            modelBuilder.Entity("ASM_Net104_ShoppingCard.Models.Origin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("OriginName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("origins");
                });

            modelBuilder.Entity("ASM_Net104_ShoppingCard.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaSp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Material")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<DateTime>("ProductionYear")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<float?>("Weight")
                        .HasColumnType("real");

                    b.Property<int>("categoryid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("categoryid");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ASM_Net104_ShoppingCard.Models.ProductVariant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<int>("ImgUrlId")
                        .HasColumnType("int");

                    b.Property<int>("OriginId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("SizeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.HasIndex("ImgUrlId");

                    b.HasIndex("OriginId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SizeId");

                    b.ToTable("productVariants");
                });

            modelBuilder.Entity("ASM_Net104_ShoppingCard.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InvoiceItemId")
                        .HasColumnType("int");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceItemId");

                    b.ToTable("reviews");
                });

            modelBuilder.Entity("ASM_Net104_ShoppingCard.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("ASM_Net104_ShoppingCard.Models.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MaxHeight")
                        .HasColumnType("int");

                    b.Property<int>("MinHeight")
                        .HasColumnType("int");

                    b.Property<string>("SizeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("sizes");
                });

            modelBuilder.Entity("ASM_Net104_ShoppingCard.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Yob")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("ASM_Net104_ShoppingCard.Models.Card", b =>
                {
                    b.HasOne("ASM_Net104_ShoppingCard.Models.User", "User")
                        .WithOne("Card")
                        .HasForeignKey("ASM_Net104_ShoppingCard.Models.Card", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ASM_Net104_ShoppingCard.Models.CardItem", b =>
                {
                    b.HasOne("ASM_Net104_ShoppingCard.Models.Card", "card")
                        .WithMany("cardItems")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASM_Net104_ShoppingCard.Models.ProductVariant", "productVariant")
                        .WithMany("cardItems")
                        .HasForeignKey("ProductVariantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("card");

                    b.Navigation("productVariant");
                });

            modelBuilder.Entity("ASM_Net104_ShoppingCard.Models.Category", b =>
                {
                    b.HasOne("ASM_Net104_ShoppingCard.Models.Brand", "Brand")
                        .WithMany("categories")
                        .HasForeignKey("IdBrand")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("ASM_Net104_ShoppingCard.Models.Invoice", b =>
                {
                    b.HasOne("ASM_Net104_ShoppingCard.Models.User", "User")
                        .WithMany("Invoices")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ASM_Net104_ShoppingCard.Models.InvoiceItem", b =>
                {
                    b.HasOne("ASM_Net104_ShoppingCard.Models.Invoice", "Invoice")
                        .WithMany("InvoiceItems")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASM_Net104_ShoppingCard.Models.ProductVariant", "ProductVariant")
                        .WithMany("invoiceItems")
                        .HasForeignKey("ProductVariantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASM_Net104_ShoppingCard.Models.Review", "Review")
                        .WithMany()
                        .HasForeignKey("ReviewId");

                    b.Navigation("Invoice");

                    b.Navigation("ProductVariant");

                    b.Navigation("Review");
                });

            modelBuilder.Entity("ASM_Net104_ShoppingCard.Models.Product", b =>
                {
                    b.HasOne("ASM_Net104_ShoppingCard.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("categoryid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ASM_Net104_ShoppingCard.Models.ProductVariant", b =>
                {
                    b.HasOne("ASM_Net104_ShoppingCard.Models.Color", "color")
                        .WithMany("productVariants")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASM_Net104_ShoppingCard.Models.ImgUrl", "ImgUrl")
                        .WithMany("productVariants")
                        .HasForeignKey("ImgUrlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASM_Net104_ShoppingCard.Models.Origin", "Origin")
                        .WithMany("productVariants")
                        .HasForeignKey("OriginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASM_Net104_ShoppingCard.Models.Product", "Product")
                        .WithMany("productVariants")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASM_Net104_ShoppingCard.Models.Size", "Size")
                        .WithMany("productVariants")
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ImgUrl");

                    b.Navigation("Origin");

                    b.Navigation("Product");

                    b.Navigation("Size");

                    b.Navigation("color");
                });

            modelBuilder.Entity("ASM_Net104_ShoppingCard.Models.Review", b =>
                {
                    b.HasOne("ASM_Net104_ShoppingCard.Models.InvoiceItem", "InvoiceItem")
                        .WithMany()
                        .HasForeignKey("InvoiceItemId");

                    b.Navigation("InvoiceItem");
                });

            modelBuilder.Entity("ASM_Net104_ShoppingCard.Models.User", b =>
                {
                    b.HasOne("ASM_Net104_ShoppingCard.Models.Role", "Role")
                        .WithMany("users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ASM_Net104_ShoppingCard.Models.Brand", b =>
                {
                    b.Navigation("categories");
                });

            modelBuilder.Entity("ASM_Net104_ShoppingCard.Models.Card", b =>
                {
                    b.Navigation("cardItems");
                });

            modelBuilder.Entity("ASM_Net104_ShoppingCard.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ASM_Net104_ShoppingCard.Models.Color", b =>
                {
                    b.Navigation("productVariants");
                });

            modelBuilder.Entity("ASM_Net104_ShoppingCard.Models.ImgUrl", b =>
                {
                    b.Navigation("productVariants");
                });

            modelBuilder.Entity("ASM_Net104_ShoppingCard.Models.Invoice", b =>
                {
                    b.Navigation("InvoiceItems");
                });

            modelBuilder.Entity("ASM_Net104_ShoppingCard.Models.Origin", b =>
                {
                    b.Navigation("productVariants");
                });

            modelBuilder.Entity("ASM_Net104_ShoppingCard.Models.Product", b =>
                {
                    b.Navigation("productVariants");
                });

            modelBuilder.Entity("ASM_Net104_ShoppingCard.Models.ProductVariant", b =>
                {
                    b.Navigation("cardItems");

                    b.Navigation("invoiceItems");
                });

            modelBuilder.Entity("ASM_Net104_ShoppingCard.Models.Role", b =>
                {
                    b.Navigation("users");
                });

            modelBuilder.Entity("ASM_Net104_ShoppingCard.Models.Size", b =>
                {
                    b.Navigation("productVariants");
                });

            modelBuilder.Entity("ASM_Net104_ShoppingCard.Models.User", b =>
                {
                    b.Navigation("Card")
                        .IsRequired();

                    b.Navigation("Invoices");
                });
#pragma warning restore 612, 618
        }
    }
}
