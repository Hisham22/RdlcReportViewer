namespace WebApiCoreWithEF.Context
{
    using Microsoft.EntityFrameworkCore;
    using WebApiCoreWithEF.Models;

    public class CompanyContext
        : DbContext
    {
        public CompanyContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<Employee>()
                .HasData(
                    new Employee
                    {
                        EmployeeId=1,
                        EmployeeName = "Employee001",
                        Gender = "Male",
                        DateOfBirth = "01-01-1990",
                        Nationality = "Indian",
                        City = "Bangalore",
                        CurrentAddress = "Current Address",
                        PermanentAddress = "Permanent Address",
                        PINCode = "560078"
                    },
                    new Employee
                    {
                        EmployeeId = 2,
                        EmployeeName = "Employee002",
                        Gender = "Female",
                        DateOfBirth = "01-01-1994",
                        Nationality = "Indian",
                        City = "Bangalore",
                        CurrentAddress = "Current Address",
                        PermanentAddress = "Permanent Address",
                        PINCode = "560078"
                    }
                    ,
                    new Employee
                    {
                        EmployeeId = 3,
                        EmployeeName = "Employee003",
                        Gender = "Female",
                        DateOfBirth = "01-01-1995",
                        Nationality = "Indian",
                        City = "Bangalore",
                        CurrentAddress = "Current Address",
                        PermanentAddress = "Permanent Address",
                        PINCode = "560078"
                    }
                );
        }

        public DbSet<Employee> Employees { get; set; }
    }
}