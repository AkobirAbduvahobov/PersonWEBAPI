using Microsoft.EntityFrameworkCore;
using PersonWEBAPI.Domain.Entities;

namespace PersonWEBAPI.Application.Abstraction;

public interface IDataDbContext
{
    public DbSet<Person> Persons { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

}
