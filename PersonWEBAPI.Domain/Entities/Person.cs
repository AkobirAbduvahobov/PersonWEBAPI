using PersonWEBAPI.Domain.States;

namespace PersonWEBAPI.Domain.Entities;

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public Gender UserGender { get; set; }

}
