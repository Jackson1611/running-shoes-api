using Microsoft.EntityFrameworkCore;
using RunningShoes.Models; 

public class RunningShoesDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public RunningShoesDbContext(DbContextOptions<RunningShoesDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public DbSet<Shoe> Shoes { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
    }
}
