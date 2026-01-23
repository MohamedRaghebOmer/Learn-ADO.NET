using System;
using System.Data;

internal class Program
{
    static void Main(string[] args)
    {
        DataTable Employees = new DataTable();

        Employees.Columns.Add("Id", typeof(int));
        Employees.Columns.Add("Name", typeof(string));
        Employees.Columns.Add("Country", typeof(string));
        Employees.Columns.Add("Salary", typeof(decimal));
        Employees.Columns.Add("HireDate", typeof(DateTime));

        Employees.Rows.Add(1, "Mohamed", "Egypt", 10000m, new DateTime(2008, 1, 1));
        Employees.Rows.Add(2, "Ibrahem", "Jordan", 50030m, new DateTime(2006, 4, 21));
        Employees.Rows.Add(3, "Ziad", "Kuwait", 43232m, new DateTime(2009, 7, 15));
        Employees.Rows.Add(4, "Ahmed", "Egypt", 25000m, new DateTime(2010, 3, 10));
        Employees.Rows.Add(5, "Basem", "Egypt", 28000m, new DateTime(2011, 6, 5));

        DataTable Departments = new DataTable();

        Departments.Columns.Add("DepartmentId", typeof(int));
        Departments.Columns.Add("DepartmentName", typeof(string));
        Departments.Columns.Add("Location", typeof(string));

        Departments.Rows.Add(1, "Human Resources", "Cairo");
        Departments.Rows.Add(2, "IT", "Alexandria");
        Departments.Rows.Add(3, "Finance", "Giza");
        Departments.Rows.Add(4, "Marketing", "Cairo");


        DataSet dataSet = new DataSet();

        dataSet.Tables.Add(Employees);
        dataSet.Tables.Add(Departments);

        Console.WriteLine("Printing Employees table data from data set:\n");
        foreach(DataRow row in dataSet.Tables[0].Rows)
        {
            Console.WriteLine(
                   $"Id: {row["Id"]}, " +
                   $"Name: {row["Name"]}, " +
                   $"Country: {row["Country"]}, " +
                   $"Salary: {row["Salary"]}, " +
                   $"HireDate: {((DateTime)row["HireDate"]).ToShortDateString()}"
               );
        }

        Console.WriteLine("\nPrinting Department table data from data set:\n");
        foreach (DataRow row in dataSet.Tables[1].Rows)
        {
            Console.WriteLine(
               $"DepartmentId: {row["DepartmentId"]}, " +
               $"DepartmentName: {row["DepartmentName"]}, " +
               $"Location: {row["Location"]}"
   );
        }

    }
}

