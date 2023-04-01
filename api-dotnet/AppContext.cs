using Microsoft.EntityFrameworkCore;

public class AppContext : DbContext
{
    private readonly IConfiguration _configuration;
    public AppContext(IConfiguration configuration)
    {
        _configuration = configuration;
        this.Database.EnsureCreated();
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Lead> Leads { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
    }
}