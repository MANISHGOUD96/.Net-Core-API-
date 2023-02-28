using Microsoft.EntityFrameworkCore;
using Mk_Core_Web_API.DB_Connection;

namespace Mk_Core_Web_API.DB_Connection
{
   
        public class Table : DbContext
        {
            public Table(DbContextOptions<Table> options) : base(options)
            {

            }
            public DbSet<Employee> Employees { get; set; }
           public DbSet<Login> Logins { get; set; }
        }
    
}
