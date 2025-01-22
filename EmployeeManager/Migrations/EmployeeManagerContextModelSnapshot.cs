﻿// <auto-generated />
using System;
using EmployeeManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeManager.Migrations
{
    [DbContext(typeof(EmployeeManagerContext))]
    partial class EmployeeManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("EmployeeManager.Models.CurrentDeptEmp", b =>
                {
                    b.Property<string>("DeptNo")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("char(4)")
                        .HasColumnName("dept_no")
                        .IsFixedLength();

                    b.Property<int>("EmpNo")
                        .HasColumnType("int")
                        .HasColumnName("emp_no");

                    b.Property<DateOnly?>("FromDate")
                        .HasColumnType("date")
                        .HasColumnName("from_date");

                    b.Property<DateOnly?>("ToDate")
                        .HasColumnType("date")
                        .HasColumnName("to_date");

                    b.ToView("current_dept_emp");
                });

            modelBuilder.Entity("EmployeeManager.Models.Department", b =>
                {
                    b.Property<string>("DeptNo")
                        .HasMaxLength(4)
                        .HasColumnType("char(4)")
                        .HasColumnName("dept_no")
                        .IsFixedLength();

                    b.Property<string>("DeptName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("dept_name");

                    b.HasKey("DeptNo")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "DeptName" }, "dept_name")
                        .IsUnique();

                    b.ToTable("departments");
                });

            modelBuilder.Entity("EmployeeManager.Models.DeptEmp", b =>
                {
                    b.Property<int>("EmpNo")
                        .HasColumnType("int")
                        .HasColumnName("emp_no");

                    b.Property<string>("DeptNo")
                        .HasMaxLength(4)
                        .HasColumnType("char(4)")
                        .HasColumnName("dept_no")
                        .IsFixedLength();

                    b.Property<DateOnly>("FromDate")
                        .HasColumnType("date")
                        .HasColumnName("from_date");

                    b.Property<DateOnly>("ToDate")
                        .HasColumnType("date")
                        .HasColumnName("to_date");

                    b.HasKey("EmpNo", "DeptNo")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                    b.HasIndex(new[] { "DeptNo" }, "dept_no");

                    b.ToTable("dept_emp");
                });

            modelBuilder.Entity("EmployeeManager.Models.DeptEmpLatestDate", b =>
                {
                    b.Property<int>("EmpNo")
                        .HasColumnType("int")
                        .HasColumnName("emp_no");

                    b.Property<DateOnly?>("FromDate")
                        .HasColumnType("date")
                        .HasColumnName("from_date");

                    b.Property<DateOnly?>("ToDate")
                        .HasColumnType("date")
                        .HasColumnName("to_date");

                    b.ToView("dept_emp_latest_date");
                });

            modelBuilder.Entity("EmployeeManager.Models.DeptManager", b =>
                {
                    b.Property<int>("EmpNo")
                        .HasColumnType("int")
                        .HasColumnName("emp_no");

                    b.Property<string>("DeptNo")
                        .HasMaxLength(4)
                        .HasColumnType("char(4)")
                        .HasColumnName("dept_no")
                        .IsFixedLength();

                    b.Property<DateOnly>("FromDate")
                        .HasColumnType("date")
                        .HasColumnName("from_date");

                    b.Property<DateOnly>("ToDate")
                        .HasColumnType("date")
                        .HasColumnName("to_date");

                    b.HasKey("EmpNo", "DeptNo")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                    b.HasIndex(new[] { "DeptNo" }, "dept_no")
                        .HasDatabaseName("dept_no1");

                    b.ToTable("dept_manager");
                });

            modelBuilder.Entity("EmployeeManager.Models.Employee", b =>
                {
                    b.Property<int>("EmpNo")
                        .HasColumnType("int")
                        .HasColumnName("emp_no");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date")
                        .HasColumnName("birth_date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)")
                        .HasColumnName("first_name");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("enum('M','F')")
                        .HasColumnName("gender");

                    b.Property<DateOnly>("HireDate")
                        .HasColumnType("date")
                        .HasColumnName("hire_date");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)")
                        .HasColumnName("last_name");

                    b.HasKey("EmpNo")
                        .HasName("PRIMARY");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("EmployeeManager.Models.Salary", b =>
                {
                    b.Property<int>("EmpNo")
                        .HasColumnType("int")
                        .HasColumnName("emp_no");

                    b.Property<DateOnly>("FromDate")
                        .HasColumnType("date")
                        .HasColumnName("from_date");

                    b.Property<int>("Salary1")
                        .HasColumnType("int")
                        .HasColumnName("salary");

                    b.Property<DateOnly>("ToDate")
                        .HasColumnType("date")
                        .HasColumnName("to_date");

                    b.HasKey("EmpNo", "FromDate")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                    b.ToTable("salaries");
                });

            modelBuilder.Entity("EmployeeManager.Models.Title", b =>
                {
                    b.Property<int>("EmpNo")
                        .HasColumnType("int")
                        .HasColumnName("emp_no");

                    b.Property<string>("Title1")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("title");

                    b.Property<DateOnly>("FromDate")
                        .HasColumnType("date")
                        .HasColumnName("from_date");

                    b.Property<DateOnly?>("ToDate")
                        .HasColumnType("date")
                        .HasColumnName("to_date");

                    b.HasKey("EmpNo", "Title1", "FromDate")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                    b.ToTable("titles");
                });

            modelBuilder.Entity("EmployeeManager.Models.DeptEmp", b =>
                {
                    b.HasOne("EmployeeManager.Models.Department", "DeptNoNavigation")
                        .WithMany("DeptEmps")
                        .HasForeignKey("DeptNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("dept_emp_ibfk_2");

                    b.HasOne("EmployeeManager.Models.Employee", "EmpNoNavigation")
                        .WithMany("DeptEmps")
                        .HasForeignKey("EmpNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("dept_emp_ibfk_1");

                    b.Navigation("DeptNoNavigation");

                    b.Navigation("EmpNoNavigation");
                });

            modelBuilder.Entity("EmployeeManager.Models.DeptManager", b =>
                {
                    b.HasOne("EmployeeManager.Models.Department", "DeptNoNavigation")
                        .WithMany("DeptManagers")
                        .HasForeignKey("DeptNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("dept_manager_ibfk_2");

                    b.HasOne("EmployeeManager.Models.Employee", "EmpNoNavigation")
                        .WithMany("DeptManagers")
                        .HasForeignKey("EmpNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("dept_manager_ibfk_1");

                    b.Navigation("DeptNoNavigation");

                    b.Navigation("EmpNoNavigation");
                });

            modelBuilder.Entity("EmployeeManager.Models.Salary", b =>
                {
                    b.HasOne("EmployeeManager.Models.Employee", "EmpNoNavigation")
                        .WithMany("Salaries")
                        .HasForeignKey("EmpNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("salaries_ibfk_1");

                    b.Navigation("EmpNoNavigation");
                });

            modelBuilder.Entity("EmployeeManager.Models.Title", b =>
                {
                    b.HasOne("EmployeeManager.Models.Employee", "EmpNoNavigation")
                        .WithMany("Titles")
                        .HasForeignKey("EmpNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("titles_ibfk_1");

                    b.Navigation("EmpNoNavigation");
                });

            modelBuilder.Entity("EmployeeManager.Models.Department", b =>
                {
                    b.Navigation("DeptEmps");

                    b.Navigation("DeptManagers");
                });

            modelBuilder.Entity("EmployeeManager.Models.Employee", b =>
                {
                    b.Navigation("DeptEmps");

                    b.Navigation("DeptManagers");

                    b.Navigation("Salaries");

                    b.Navigation("Titles");
                });
#pragma warning restore 612, 618
        }
    }
}
