using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Repository.Models;

public partial class RestaurantContext : DbContext
{
    public RestaurantContext()
    {
    }

    public RestaurantContext(DbContextOptions<RestaurantContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BillRecord> Bills { get; set; }

    public virtual DbSet<BookingRecord> Bookings { get; set; }

    public virtual DbSet<CustomerRecord> Customers { get; set; }

    public virtual DbSet<MenuRecord> Menus { get; set; }

    public virtual DbSet<MenuBillRecord> MenuBills { get; set; }

    public virtual DbSet<OwnerRecord> Owners { get; set; }

    public virtual DbSet<RestaurantRecord> Restaurants { get; set; }

    public virtual DbSet<SaleDetailRecord> SaleDetails { get; set; }

    public virtual DbSet<TableRecord> Tables { get; set; }

    public virtual DbSet<UserRecord> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=TECH-LP-2151\\SQLEXPRESS;initial catalog=Restaurant;integrated security=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BillRecord>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__BILL__F1E4607BF67A5F2B");

            entity.ToTable("BILL");

            entity.Property(e => e.OrderId).HasColumnName("Order_Id");
            entity.Property(e => e.CustomerFname)
                .HasMaxLength(20)
                .HasColumnName("Customer_Fname");
            entity.Property(e => e.CustomerId).HasColumnName("Customer_id");
            entity.Property(e => e.CustomerLname)
                .HasMaxLength(20)
                .HasColumnName("Customer_Lname");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Total_Amount");
        });

        modelBuilder.Entity<BookingRecord>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__BOOKING__35ABFDC0F1C563F7");

            entity.ToTable("BOOKING");

            entity.Property(e => e.BookingId).HasColumnName("Booking_Id");
            entity.Property(e => e.CustId).HasColumnName("Cust_Id");
            entity.Property(e => e.Date).HasMaxLength(30);
            entity.Property(e => e.TableNum)
                .HasMaxLength(9)
                .HasColumnName("Table_Num");
            entity.Property(e => e.Time).HasMaxLength(30);

            entity.HasOne(d => d.Cust).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.CustId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BOOKING__Cust_Id__6754599E");

            entity.HasOne(d => d.TableNumNavigation).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.TableNum)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BOOKING__Table_N__68487DD7");
        });

        modelBuilder.Entity<CustomerRecord>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__CUSTOMER__8CB28699CAB4FDAF");

            entity.ToTable("CUSTOMER");

            entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");
            entity.Property(e => e.Contact).HasMaxLength(20);
            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .HasColumnName("Email_Id");
            entity.Property(e => e.Fname).HasMaxLength(15);
            entity.Property(e => e.Lname).HasMaxLength(15);
        });

        modelBuilder.Entity<MenuRecord>(entity =>
        {
            entity.HasKey(e => new { e.MenuId, e.Name }).HasName("PK__MENU__0ED07B77FACFA893");

            entity.ToTable("MENU");

            entity.Property(e => e.MenuId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Menu_Id");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Category).HasMaxLength(30);
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.ImageLink).HasMaxLength(4000);
            entity.Property(e => e.Price)
             .HasColumnType("decimal(18, 2)")
                .HasColumnName("Price");
            entity.Property(e => e.Type).HasMaxLength(20);
        });

        modelBuilder.Entity<MenuBillRecord>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MENU_BILL");

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.OrderId).HasColumnName("Order_Id");
            entity.Property(e => e.Price)
            .HasColumnType("decimal(18, 2)")
                .HasColumnName("Price");
            entity.Property(e => e.Quantity).HasMaxLength(20);

            entity.HasOne(d => d.Order).WithMany()
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MENU_BILL__Order__5DCAEF64");
        });

        modelBuilder.Entity<OwnerRecord>(entity =>
        {
            entity.HasKey(e => new { e.Fname, e.Lname, e.Contact }).HasName("PK__OWNER__7DFF7166554A5407");

            entity.ToTable("OWNER");

            entity.Property(e => e.Fname).HasMaxLength(15);
            entity.Property(e => e.Lname).HasMaxLength(15);
            entity.Property(e => e.Contact).HasMaxLength(100);
            entity.Property(e => e.RestName)
                .HasMaxLength(100)
                .HasColumnName("Rest_Name");

            entity.HasOne(d => d.RestNameNavigation).WithMany(p => p.Owners)
                .HasForeignKey(d => d.RestName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OWNER__Rest_Name__2F10007B");
        });

        modelBuilder.Entity<RestaurantRecord>(entity =>
        {
            entity.HasKey(e => e.Name).HasName("PK__RESTAURA__737584F7EC1D3E4D");

            entity.ToTable("RESTAURANT");

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Contact).HasMaxLength(100);
            entity.Property(e => e.Details).HasMaxLength(500);
            entity.Property(e => e.Location).HasMaxLength(100);
            entity.Property(e => e.OpeningClosingTime)
                .HasMaxLength(100)
                .HasColumnName("Opening_Closing_Time");
        });

        modelBuilder.Entity<SaleDetailRecord>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SALE_DETAIL");

            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Rname).HasMaxLength(30);
        });

        modelBuilder.Entity<TableRecord>(entity =>
        {
            entity.HasKey(e => e.TableNumber).HasName("PK__TABLES__FB5DA37D6011FF8F");

            entity.ToTable("TABLES");

            entity.Property(e => e.TableNumber)
                .HasMaxLength(9)
                .HasColumnName("Table_Number");
            entity.Property(e => e.Details).HasMaxLength(200);
        });

        modelBuilder.Entity<UserRecord>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__USER__206D9170C4780071");

            entity.ToTable("USER");

            entity.Property(e => e.UserId).HasColumnName("User_Id");
            entity.Property(e => e.Fname).HasMaxLength(50);
            entity.Property(e => e.Lname).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(30);
            entity.Property(e => e.Role).HasMaxLength(30);

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
