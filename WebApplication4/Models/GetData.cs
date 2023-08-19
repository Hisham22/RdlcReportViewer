using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;
using WebApiCoreWithEF.Context;

namespace WebApplication4.Models
{
    public class GetData
    {
        public readonly CompanyContext _db;
        public GetData(CompanyContext db)
        {
            _db = db;
        }
        public DataTable Data()
        {

            // Query the database using LINQ

            

            var employeesQuery = from employee in _db.Employees
                                 select new
                                 {
                                     employee.EmployeeId,
                                     employee.EmployeeName,
                                     employee.DateOfBirth,
                                     employee.Gender,
                                     employee.CurrentAddress,
                                     employee.PermanentAddress,
                                     employee.City,
                                     employee.Nationality,
                                     employee.PINCode
                                 };

            // Convert the query result to a DataTable
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("EmployeeId", typeof(int));
            dataTable.Columns.Add("EmployeeName", typeof(string));
            dataTable.Columns.Add("DateOfBirth", typeof(string));
            dataTable.Columns.Add("Gender", typeof(string));
            dataTable.Columns.Add("CurrentAddress", typeof(string));
            dataTable.Columns.Add("PermanentAddress", typeof(string));
            dataTable.Columns.Add("City", typeof(string));
            dataTable.Columns.Add("Nationality", typeof(string));
            dataTable.Columns.Add("PINCode", typeof(string));

            foreach (var employee in employeesQuery)
            {
                dataTable.Rows.Add(
                    employee.EmployeeId,
                    employee.EmployeeName,
                    employee.DateOfBirth,
                    employee.Gender,
                    employee.CurrentAddress,
                    employee.PermanentAddress,
                    employee.City,
                    employee.Nationality,
                    employee.PINCode
                );
            }
            return dataTable;
        }
    }
}
