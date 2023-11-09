using AutoMapper;
using PersonWEBAPI.Application.DTOs.Person;
using PersonWEBAPI.Domain.Entities;

namespace PersonWEBAPI.Application.Mappings;

public class MapProfiles : Profile
{
    public MapProfiles()
    {
        Person();
    }

    private void Person()
    {
        CreateMap<PersonCreateDTO, Person>();
        CreateMap<Person, PersonGetDTO>();
        CreateMap<PersonUpdateDTO, Person>();
    }
}
