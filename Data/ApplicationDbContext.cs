using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;


namespace Leave_System.Data
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
   
            modelBuilder.Entity<VacationType>().HasData(new VacationType() { Id = 1, Name="Casual", Balance=7 });
            modelBuilder.Entity<VacationType>().HasData(new VacationType() { Id = 2, Name = "Schedule", Balance = 14 });
            modelBuilder.Entity<Gender>().HasData(new Gender() { Id = 2, Name = "F" });
            modelBuilder.Entity<Gender>().HasData(new Gender() { Id = 1, Name = "M" });
            modelBuilder.Entity<Gender>().HasData(new Gender() { Id = 3, Name = "other" });
            modelBuilder.Entity<Employee>().HasData(new Employee() { Id = 2, fullname = "Hassan Khalil Mohamed", GenderId = 1, Email = "hassankhalil@gmail.com", Birthdate = DateTime.Parse("1998-02-04") });
            modelBuilder.Entity<Employee>().HasData(new Employee (){ Id=1, fullname="Amr Sherief Abdelhakim",GenderId=1, Email="amrsaadeldin97@gmail.com", Birthdate=DateTime.Parse("1997-02-04")});
            modelBuilder.Entity<Employee>().HasData(new Employee() { Id = 3, fullname = "Nadia Mohamed Hassan", GenderId = 2, Email = "nadiamohamed97@gmail.com", Birthdate = DateTime.Parse("1956-05-06") });
            modelBuilder.Entity<VacationRequest>().HasData(new VacationRequest() { Id = 1, EmployeeId = 1, StartDate = DateTime.Parse("2020-11-17"), EndDate = DateTime.Parse("2020-11-24"), VacationTypeId = 1, Status = true, DateRequested = DateTime.Parse("2020-11-15"), Cancelled = false });
            modelBuilder.Entity<VacationRequest>().HasData(new VacationRequest() { Id = 2, EmployeeId = 2, StartDate = DateTime.Parse("2020-11-17"), EndDate = DateTime.Parse("2020-12-15"), VacationTypeId = 2, Status = true, DateRequested = DateTime.Parse("2020-11-15"), Cancelled = false });

        }

        public DbSet<Employee> Employees { set; get; }
        public DbSet<VacationType> VacationTypes { set; get; }
        public DbSet<VacationRequest> VacationRequests { set; get; }
        public DbSet<VacationAllocation> VacationAllocations { set; get; }
        public DbSet<Gender> Genders { set; get; }

       
    }
}
