using Microsoft.EntityFrameworkCore;
using EmployeeManager.Models;
// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo

namespace EmployeeManager.Data
{
    public class EmployeeManagerContext : DbContext
    {

        public EmployeeManagerContext(DbContextOptions<EmployeeManagerContext> options)
            : base(options)
        {
        }

        public DbSet<CurrentDeptEmp> CurrentDeptEmps { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<Job> DeptEmps { get; set; } = null!;
        public DbSet<DeptEmpLatestDate> DeptEmpLatestDates { get; set; } = null!;
        public DbSet<DeptManager> DeptManagers { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Salary> Salaries { get; set; } = null!;
        public DbSet<Title> Titles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<CurrentDeptEmp>(entity =>
            {
                entity.ToView("current_dept_emp");

                entity.Property(e => e.DeptNo).IsFixedLength();
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptNo)
                    .HasName("PRIMARY");

                entity.Property(e => e.DeptNo).IsFixedLength();
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasKey(e => new { e.EmpNo, e.DeptNo })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.Property(e => e.DeptNo).IsFixedLength();

                entity.HasOne(d => d.DeptNoNavigation)
                    .WithMany(p => p.DeptEmps)
                    .HasForeignKey(d => d.DeptNo)
                    .HasConstraintName("dept_emp_ibfk_2");

                entity.HasOne(d => d.EmpNoNavigation)
                    .WithMany(p => p.DeptEmps)
                    .HasForeignKey(d => d.EmpNo)
                    .HasConstraintName("dept_emp_ibfk_1");
            });

            modelBuilder.Entity<DeptEmpLatestDate>(entity =>
            {
                entity.ToView("dept_emp_latest_date");
            });

            modelBuilder.Entity<DeptManager>(entity =>
            {
                entity.HasKey(e => new { e.EmpNo, e.DeptNo })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.Property(e => e.DeptNo).IsFixedLength();

                entity.HasOne(d => d.DeptNoNavigation)
                    .WithMany(p => p.DeptManagers)
                    .HasForeignKey(d => d.DeptNo)
                    .HasConstraintName("dept_manager_ibfk_2");

                entity.HasOne(d => d.EmpNoNavigation)
                    .WithMany(p => p.DeptManagers)
                    .HasForeignKey(d => d.EmpNo)
                    .HasConstraintName("dept_manager_ibfk_1");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpNo)
                    .HasName("PRIMARY");

                entity.Property(e => e.EmpNo).ValueGeneratedNever();
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.HasKey(e => new { e.EmpNo, e.FromDate })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.HasOne(d => d.EmpNoNavigation)
                    .WithMany(p => p.Salaries)
                    .HasForeignKey(d => d.EmpNo)
                    .HasConstraintName("salaries_ibfk_1");
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.HasKey(e => new { e.EmpNo, e.Title1, e.FromDate })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.HasOne(d => d.EmpNoNavigation)
                    .WithMany(p => p.Titles)
                    .HasForeignKey(d => d.EmpNo)
                    .HasConstraintName("titles_ibfk_1");
            });
        }
    }
}
