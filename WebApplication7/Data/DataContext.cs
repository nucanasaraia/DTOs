using Microsoft.EntityFrameworkCore;
using WebApplication7.Models;

namespace WebApplication7.Data;

public class DataContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=select;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }
}
