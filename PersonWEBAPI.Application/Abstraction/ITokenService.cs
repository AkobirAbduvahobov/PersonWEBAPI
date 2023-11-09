using PersonWEBAPI.Domain.Entities;

namespace PersonWEBAPI.Application.Abstraction;

public interface ITokenService<in T> where T : class
{
    public string GetToken(T entity);
}
