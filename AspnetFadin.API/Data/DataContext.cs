
using Microsoft.EntityFrameworkCore;
using AspnetFadin.API.Models;

namespace AspnetFadin.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
           
        }
        public DbSet<Value> Values {get;set;}         
    }
}