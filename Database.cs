using SQLite;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp
{
    // Seperate non-page-specific database functions are here
    class Database
    {
        // Async connection created.
        SQLiteAsyncConnection _database;

        string dbPath;

        public Database()
        {
            // Database pathing.
            dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Employees.db");
            
            // Database Async initializations and connection setup
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Employee>().Wait();

            // Delete and drop table/objects. Should only be used to clear database if absolutely needed.
            //_database.DeleteAllAsync<Person>().Wait();
            //_database.DropTableAsync<Person>().Wait();
        }

        //Database CRUD Operations
        //
        // Insert new Employee record. NOTE: Needs expection handling for Primary Key duplicates.
        public async Task AddEmployeeAsync(Employee record)
        {
            await _database.InsertAsync(record);
        }

        // Retrieve Employee records. Should be used with <ListView>.
        public Task<List<Employee>> RetrieveEmployees()
        {
            return _database.Table<Employee>().ToListAsync();
        }

        // Update a Employee record.
        public async Task UpdateEmployeeAsync(Employee record)
        {
            await _database.UpdateAsync(record);
        }

        // Delete a Employee record, requires a Primary Key to be set to properly complete.
        public async Task DeleteEmployeeAsync(Employee record)
        {
            await _database.DeleteAsync(record);
        }

    }
}

// Class to represent a single record from the Staff Member database.
// Used for CRUD operation data.
[Table("Employee")]
public class Employee
{
    [PrimaryKey]
    [Column("Id")]
    public string Id { get; set; }
    [Column("Name")]
    public string Name { get; set; }
    [Column("PhoneNo")]
    public string PhoneNo { get; set; }
    [Column("Department")]
    public string Department { get; set; }
    [Column("Street")]
    public string Street { get; set; }
    [Column("City")]
    public string City { get; set; }
    [Column("State")]
    public string State { get; set; }
    [Column("Zip")]
    public string Zip { get; set; }
    [Column("Country")]
    public string Country { get; set; }
}