using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
namespace WebApplication.Models
{
    public partial class SUBDContext : DbContext
    {
        public SUBDContext()
        {
        }

        public SUBDContext(DbContextOptions<SUBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Budgets> Budgets { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Finproducts> Finproducts { get; set; }
        public virtual DbSet<Ingredients> Ingredients { get; set; }
        public virtual DbSet<Months> Months { get; set; }
        public virtual DbSet<P> P { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }
        public virtual DbSet<Production> Production { get; set; }
        public virtual DbSet<PurchaseOfrawmaterials> PurchaseOfrawmaterials { get; set; }
        public virtual DbSet<Rawmaterials> Rawmaterials { get; set; }
        public virtual DbSet<S> S { get; set; }
        public virtual DbSet<Salary> Salary { get; set; }
        public virtual DbSet<Saleofproducts> Saleofproducts { get; set; }
        public virtual DbSet<Units> Units { get; set; }
        public virtual DbSet<ViewEmployees> ViewEmployees { get; set; }
        public virtual DbSet<Years> Years { get; set; }
        public virtual DbSet<Ч> Ч { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
             #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-28KMSTV\\SQLEXPRESS;Initial Catalog=WEB_SUBD;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Budgets>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Budgetamount).HasColumnType("money");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Fullname).HasMaxLength(50);

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.Property(e => e.Telephone).HasMaxLength(50);

                entity.HasOne(d => d.PositionNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Position)
                    .HasConstraintName("FK_Employees_Positions");
            });

            modelBuilder.Entity<Finproducts>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Sum).HasColumnType("money");

                entity.HasOne(d => d.UnitNavigation)
                    .WithMany(p => p.Finproducts)
                    .HasForeignKey(d => d.Unit)
                    .HasConstraintName("FK_Finproducts_Units");
            });

            modelBuilder.Entity<Ingredients>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.Product)
                    .HasConstraintName("FK_Ingredients_Finproducts");

                entity.HasOne(d => d.RawMaterialsNavigation)
                    .WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.RawMaterials)
                    .HasConstraintName("FK_Ingredients_Rawmaterials");
            });

            modelBuilder.Entity<Months>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MonthName).HasMaxLength(50);
            });

            modelBuilder.Entity<P>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("P");

                entity.Property(e => e.CountPr).HasColumnName("CountPR");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Positions>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Position).HasMaxLength(50);
            });

            modelBuilder.Entity<Production>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("smalldatetime");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.Production)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("FK_Production_Employees");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.Production)
                    .HasForeignKey(d => d.Product)
                    .HasConstraintName("FK_Production_Finproducts");
            });

            modelBuilder.Entity<PurchaseOfrawmaterials>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("smalldatetime");

                entity.Property(e => e.Sum).HasColumnType("money");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.PurchaseOfrawmaterials)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("FK_PurchaseOfrawmaterials_Employees");

                entity.HasOne(d => d.RawMaterialsNavigation)
                    .WithMany(p => p.PurchaseOfrawmaterials)
                    .HasForeignKey(d => d.RawMaterials)
                    .HasConstraintName("FK_PurchaseOfrawmaterials_Rawmaterials");
            });

            modelBuilder.Entity<Rawmaterials>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Sum).HasColumnType("money");

                entity.HasOne(d => d.UnitNavigation)
                    .WithMany(p => p.Rawmaterials)
                    .HasForeignKey(d => d.Unit)
                    .HasConstraintName("FK_Rawmaterials_Units");
            });

            modelBuilder.Entity<S>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("S");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.HasIndex(e => new { e.Year, e.Month, e.Employee })
                    .HasName("NonClusteredIndex-20220407-134015")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CountParticipation).HasComputedColumnSql("(([ParticipationPurchase]+[ParticipationSale])+[ParticipationProduction])");

                entity.Property(e => e.Issued).HasDefaultValueSql("((0))");

                entity.Property(e => e.SalaryEmployee).HasColumnType("money");

                entity.Property(e => e.TotalAmount).HasComputedColumnSql("([SalaryEmployee]+[Bonus])");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.SalaryNavigation)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("FK_Salary_Employees");

                entity.HasOne(d => d.MonthNavigation)
                    .WithMany(p => p.Salary)
                    .HasForeignKey(d => d.Month)
                    .HasConstraintName("FK_Salary_Months");

                entity.HasOne(d => d.YearNavigation)
                      .WithMany(p => p.Salary)
                      .HasForeignKey(d => d.Year)
                      .HasConstraintName("FK_Salary_Years");
            });

            modelBuilder.Entity<Saleofproducts>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("smalldatetime");

                entity.Property(e => e.Sum).HasColumnType("money");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.Saleofproducts)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("FK_Saleofproducts_Employees");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.Saleofproducts)
                    .HasForeignKey(d => d.Product)
                    .HasConstraintName("FK_Saleofproducts_Finproducts");
            });

            modelBuilder.Entity<Units>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<ViewEmployees>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Employees");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Fullname).HasMaxLength(50);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Position).HasMaxLength(50);

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.Property(e => e.Telephone).HasMaxLength(50);
            });

            modelBuilder.Entity<Years>(entity =>
            {
                entity.HasKey(e => e.YearName);

                entity.Property(e => e.YearName).ValueGeneratedNever();
            });

            modelBuilder.Entity<Ч>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Ч");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
