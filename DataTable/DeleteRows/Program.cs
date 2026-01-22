using System;
using System.Data;

class Program
{
    static void Main()
    {
        DataTable dtEmployees = new DataTable("Employees");

        dtEmployees.Columns.Add("ID", typeof(int));
        dtEmployees.Columns.Add("Name", typeof(string));
        dtEmployees.Columns.Add("Country", typeof(string));
        dtEmployees.Columns.Add("Salary", typeof(double));
        dtEmployees.Columns.Add("DateOfBirth", typeof(DateTime));

        dtEmployees.Rows.Add(1, "Mohamed", "Egypt", 10000, new DateTime(2008, 1, 1));
        dtEmployees.Rows.Add(2, "Ibrahem", "Jordan", 50030, new DateTime(2006, 4, 21));
        dtEmployees.Rows.Add(3, "Mostafa", "Kuwait", 43232, new DateTime(2010, 3, 23));
        dtEmployees.Rows.Add(4, "Ali", "Saudi Arabia", 25000, new DateTime(2012, 5, 12));
        dtEmployees.Rows.Add(5, "Sara", "UAE", 32000, new DateTime(2009, 7, 18));
        dtEmployees.Rows.Add(6, "Laila", "Qatar", 28000, new DateTime(2011, 9, 30));

        Console.WriteLine("Employees Table before deleting:\n");
        foreach (DataRow row in dtEmployees.Rows)
        {
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}",
                row["ID"],
                row["Name"],
                row["Country"],
                row["Salary"],
                ((DateTime)row["DateOfBirth"]).ToString("dd/MM/yyyy")); // print date only
        }

        // Delete where id = 4
        DataRow[] markForDelete = dtEmployees.Select("ID = 4");
        foreach (var row in markForDelete)
        {
            row.Delete();
        }

        // Accept changes to remove deleted rows permanently
        dtEmployees.AcceptChanges();

        Console.WriteLine("Employees Table after deleting:\n");
        foreach (DataRow row in dtEmployees.Rows) // print from main table after deleting
        {
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}",
                row["ID"],
                row["Name"],
                row["Country"],
                row["Salary"],
                ((DateTime)row["DateOfBirth"]).ToString("dd/MM/yyyy")); // print date only
        }
    }
}
