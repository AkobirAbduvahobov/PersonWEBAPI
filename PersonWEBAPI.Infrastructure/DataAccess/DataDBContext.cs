using Microsoft.EntityFrameworkCore;
using PersonWEBAPI.Application.Abstraction;
using PersonWEBAPI.Domain.Entities;

namespace PersonWEBAPI.Infrastructure.DataAccess;

public class DataDBContext : DbContext, IDataDbContext
{

    public DataDBContext(DbContextOptions<DataDBContext> options)
        : base(options)
    {

    }

    public DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors();
    }
}
