namespace PersonWEBAPI.Application.DTOs.Person;

public class PersonCreateDTO : PersonBaseDTO
{
    public string Login { get; set; }
    public string Password { get; set; }
}
