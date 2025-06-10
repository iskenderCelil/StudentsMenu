using Microsoft.EntityFrameworkCore;

namespace ConsoleDb2;

public class AppDbContext : DbContext // veri tabanında todo tiğinde bir yer ayırtma
{
    public DbSet<Todo> Todos { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {   
        
        options.UseSqlServer("Server=localhost;Database=ConsoleAppDb;User Id=sa;Password=******+; TrustServerCertificate=True");
    }
}
public class Todo
{
    public int Id { get; set; }
    public string? Task { get; set; }
    public bool IsComplete { get; set; } 
    public DateTime CompleteTime { get; set; } = DateTime.Now;
}