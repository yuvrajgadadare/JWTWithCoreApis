using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JWTWithCoreApis.Models;

public partial class CoreapidbContext : DbContext
{
    public CoreapidbContext()
    {
    }

    public CoreapidbContext(DbContextOptions<CoreapidbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<TblCustomer> TblCustomers { get; set; }

    public virtual DbSet<TblInvoiceDetail> TblInvoiceDetails { get; set; }

    public virtual DbSet<TblInvoicePayment> TblInvoicePayments { get; set; }

    public virtual DbSet<TblInvoiceProduct> TblInvoiceProducts { get; set; }

    public virtual DbSet<TblProduct> TblProducts { get; set; }

    public virtual DbSet<Tblemployee> Tblemployees { get; set; }

    public virtual DbSet<TblstudentDetail> TblstudentDetails { get; set; }

    public virtual DbSet<Tbluser> Tblusers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=115.124.106.98;Database=coreapidb;User Id=coreapiuser;Password=P0wersh#t#2026;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("apiuser");

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__products__47027DF521A3E01B");

            entity.ToTable("products", "dbo");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Gst).HasColumnName("gst");
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("product_name");
            entity.Property(e => e.Rate).HasColumnName("rate");
            entity.Property(e => e.StockQuantity).HasColumnName("stock_quantity");
        });

        modelBuilder.Entity<TblCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__tblCusto__A4AE64D82C6760C1");

            entity.ToTable("tblCustomers", "dbo");

            entity.HasIndex(e => e.MobileNumber, "UQ__tblCusto__250375B1B4E27C0B").IsUnique();

            entity.HasIndex(e => e.MobileNumber, "UQ__tblCusto__250375B1D11C89D5").IsUnique();

            entity.HasIndex(e => e.EmailAddress, "UQ__tblCusto__49A147403662EB00").IsUnique();

            entity.HasIndex(e => e.EmailAddress, "UQ__tblCusto__49A147409F4685E8").IsUnique();

            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblInvoiceDetail>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("PK__tblInvoi__D796AAB521E7BE2A");

            entity.ToTable("tblInvoiceDetails", "dbo");

            entity.HasOne(d => d.Customer).WithMany(p => p.TblInvoiceDetails)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("fkcid");
        });

        modelBuilder.Entity<TblInvoicePayment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__tblInvoi__9B556A3810C69400");

            entity.ToTable("tblInvoicePayments", "dbo");

            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.PaymentMode)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Invoice).WithMany(p => p.TblInvoicePayments)
                .HasForeignKey(d => d.InvoiceId)
                .HasConstraintName("fkincid");
        });

        modelBuilder.Entity<TblInvoiceProduct>(entity =>
        {
            entity.HasKey(e => e.InvoiceProductId).HasName("PK__tblInvoi__D032D0C95C5D3F80");

            entity.ToTable("tblInvoiceProducts", "dbo");

            entity.HasOne(d => d.Invoice).WithMany(p => p.TblInvoiceProducts)
                .HasForeignKey(d => d.InvoiceId)
                .HasConstraintName("fkinvoiceid");

            entity.HasOne(d => d.Product).WithMany(p => p.TblInvoiceProducts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("fkproductid");
        });

        modelBuilder.Entity<TblProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__tblProdu__B40CC6CD9AE61534");

            entity.ToTable("tblProducts", "dbo");

            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tblemployee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__tblemplo__C52E0BA83EF6F507");

            entity.ToTable("tblemployees", "dbo");

            entity.HasIndex(e => e.EmployeeCode, "UQ__tblemplo__B0AA7345CDC14887").IsUnique();

            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.Designation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("designation");
            entity.Property(e => e.EmployeeCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("employee_code");
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("employee_name");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        modelBuilder.Entity<TblstudentDetail>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__tblstude__2A33069A6E0ABE11");

            entity.ToTable("tblstudent_details", "dbo");

            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email_address");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("mobile_number");
            entity.Property(e => e.StudentName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("student_name");
        });

        modelBuilder.Entity<Tbluser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__tblusers__1788CC4C53F2595C");

            entity.ToTable("tblusers", "dbo");

            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ProfilePhoto)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
