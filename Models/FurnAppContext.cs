using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FurnApp_API.Models
{
    public partial class FurnAppContext : DbContext
    {
        public FurnAppContext()
        {
        }

        public FurnAppContext(DbContextOptions<FurnAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductColor> ProductColors { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-RUVM77E; Database=FurnApp; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.AddressId).HasColumnName("Address_Id");

                entity.Property(e => e.BuildingNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Building_Number");

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.District)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.HomeNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Home_Number");

                entity.Property(e => e.Neighborhood)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Postal_Code");

                entity.Property(e => e.Street)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.CartId).HasColumnName("Cart_Id");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.UsersId).HasColumnName("Users_Id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Cart__Product_Id__5629CD9C");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.UsersId)
                    .HasConstraintName("FK__Cart__Users_Id__5535A963");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Category_Name");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.Property(e => e.ColorId).HasColumnName("Color_Id");

                entity.Property(e => e.ColorName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Color_Name");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("Order_Id");

                entity.Property(e => e.AddressId).HasColumnName("Address_Id");

                entity.Property(e => e.CargoNo).HasColumnName("Cargo_No");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Order_Date");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.UsersId).HasColumnName("Users_Id");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK__Orders__Address___6477ECF3");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Orders__Product___6383C8BA");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UsersId)
                    .HasConstraintName("FK__Orders__Users_Id__628FA481");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.PaymentId).HasColumnName("Payment_Id");

                entity.Property(e => e.CardCvv).HasColumnName("Card_Cvv");

                entity.Property(e => e.CardMonth).HasColumnName("Card_Month");

                entity.Property(e => e.CardName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Card_Name");

                entity.Property(e => e.CardYear).HasColumnName("Card_Year");

                entity.Property(e => e.CargoCompany)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Cargo_Company");

                entity.Property(e => e.CargoPrice)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Cargo_Price");

                entity.Property(e => e.CreditCardNo).HasColumnName("CreditCard_No");

                entity.Property(e => e.UsersId).HasColumnName("Users_Id");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.UsersId)
                    .HasConstraintName("FK__Payment__Users_I__4E88ABD4");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.ProductDescription)
                    .IsUnicode(false)
                    .HasColumnName("Product_Description");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Product_Name");

                entity.Property(e => e.ProductPicture).HasColumnName("Product_Picture");

                entity.Property(e => e.ProductPrice)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Product_Price");

                entity.Property(e => e.ProductStock).HasColumnName("Product_Stock");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Products__Catego__44FF419A");
            });

            modelBuilder.Entity<ProductColor>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.ColorId })
                    .HasName("PK__Product___CFA10A6F1A6BE1A4");

                entity.ToTable("Product_Colors");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.ColorId).HasColumnName("Color_Id");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.ProductColors)
                    .HasForeignKey(d => d.ColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product_C__Color__5FB337D6");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductColors)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product_C__Produ__5EBF139D");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UsersId)
                    .HasName("PK__Users__EB68292DE57BE168");

                entity.Property(e => e.UsersId).HasColumnName("Users_Id");

                entity.Property(e => e.UsersAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Users_Address");

                entity.Property(e => e.UsersAuthorization).HasColumnName("Users_Authorization");

                entity.Property(e => e.UsersMail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Users_Mail");

                entity.Property(e => e.UsersPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Users_Password");

                entity.Property(e => e.UsersTelNo).HasColumnName("Users_TelNo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
