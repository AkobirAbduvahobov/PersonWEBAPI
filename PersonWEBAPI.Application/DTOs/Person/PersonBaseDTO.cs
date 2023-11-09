using PersonWEBAPI.Domain.States;

namespace PersonWEBAPI.Application.DTOs.Person;

public class PersonBaseDTO
{ 
    public string Name { get; set; }
    public int Age { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public Gender UserGender { get; set; }
}
