using Microsoft.EntityFrameworkCore;
using RunningShoes.Models;

namespace RunningShoes.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Shoe> Shoes { get; set; }

       

            
        
    }
}
