using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTableAgregateFunctions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTable EmployeesDataTable = new DataTable();

            // Add table columns
            EmployeesDataTable.Columns.Add("ID", typeof(int));
            EmployeesDataTable.Columns.Add("Name", typeof(string));
            EmployeesDataTable.Columns.Add("Country", typeof(string));
            EmployeesDataTable.Columns.Add("Salary", typeof(double));
            EmployeesDataTable.Columns.Add("DateOfBirth", typeof(DateTime));


            // Add Rows
            EmployeesDataTable.Rows.Add(1, "Ragheb", "EGP", 10000.543, new DateTime(2008, 1, 1));
            EmployeesDataTable.Rows.Add(2, "kem", "JOD", 30000.23, new DateTime(1978, 7, 22));
            EmployeesDataTable.Rows.Add(3, "Ali", "KSA", 2332.322, DateTime.Now);
            EmployeesDataTable.Rows.Add(4, "Mikel", "USA", 3232.53, DateTime.Now);
            EmployeesDataTable.Rows.Add(5, "Jane", "GRM", 5432.42, DateTime.Now);


            // Agregate functions
            int count = EmployeesDataTable.Rows.Count;
            double sum = Convert.ToDouble(EmployeesDataTable.Compute("SUM(Salary)", string.Empty));
            double avg = Convert.ToDouble(EmployeesDataTable.Compute("AVG(Salary)", string.Empty));
            double min = Convert.ToDouble(EmployeesDataTable.Compute("MIN(Salary)", string.Empty));
            double max = Convert.ToDouble(EmployeesDataTable.Compute("MAX(Salary)", string.Empty));

            Console.WriteLine($"Count = {count}");
            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine($"Avg = {avg}");
            Console.WriteLine($"Min = {min}");
            Console.WriteLine($"Max = {max}");
        }
    }
}
