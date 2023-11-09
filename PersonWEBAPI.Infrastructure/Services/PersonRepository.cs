using PersonWEBAPI.Application.Abstraction;
using PersonWEBAPI.Application.Repositories;
using PersonWEBAPI.Domain.Entities;

namespace PersonWEBAPI.Infrastructure.Services;

public class PersonRepository : IPersonRepository
{
    private readonly IDataDbContext _context;
    public PersonRepository(IDataDbContext context)
    {
        _context = context;
    }

    public async Task<Person> CreateAsync(Person entity)
    {
        await _context.Persons.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var personEntity = await _context.Persons.FindAsync(id);
        if (personEntity == null) return false; 
        _context.Persons.Remove(personEntity);
        int affectedRpws = await _context.SaveChangesAsync();
        return affectedRpws > 0;
    }

    public async Task<IEnumerable<Person>> GetAllAsync()
    {
        return _context.Persons;
    }

    public async Task<Person> GetByIdAsync(int id)
    {
        var personEntity = await _context.Persons.FindAsync(id);

        return personEntity;
    }

    public async Task<bool> UpdateAsync(Person person)
    {
        var personEntity = await _context.Persons.FindAsync(person.Id);
        if (personEntity == null) return false;

        personEntity.Name = person.Name;
        personEntity.Age = person.Age;
        personEntity.PhoneNumber = person.PhoneNumber;
        personEntity.BirthDate = person.BirthDate;
        personEntity.Login = person.Login;
        personEntity.Email = person.Email;
        personEntity.Password = person.Password;

        return true;
        
    }
}
