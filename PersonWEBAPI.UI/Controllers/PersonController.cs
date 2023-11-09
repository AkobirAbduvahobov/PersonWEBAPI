using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PersonWEBAPI.Application.Abstraction;
using PersonWEBAPI.Application.DTOs.Person;
using PersonWEBAPI.Application.Models;
using PersonWEBAPI.Application.Repositories;
using PersonWEBAPI.Domain.Entities;

namespace PersonWEBAPI.UI.Controllers;
[Route("api/[Controller]/[action]")]

public class PersonController : Controller
{
    private readonly IPersonRepository _repository;
    private readonly IMapper _mapper;
    private readonly IValidator<Person> _validator;
    private readonly ITokenService<Person> _tokenService;

    public PersonController(IPersonRepository repository, IMapper mapper, IValidator<Person> validator, ITokenService<Person> tokenService)
    {
        _repository = repository;
        _mapper = mapper;
        _validator = validator;
        _tokenService = tokenService;
    }



    [HttpPost]
    public async Task<IActionResult> Create( [FromBody] PersonCreateDTO personCreateDTO)
    {
        var personEntity = _mapper.Map<Person>(personCreateDTO);
        var validationRes = await _validator.ValidateAsync(personEntity);
        if (!validationRes.IsValid)
            return BadRequest(validationRes);
        var returnedPersonEntity = await _repository.CreateAsync(personEntity);
        var personGet = _mapper.Map<PersonGetDTO>(returnedPersonEntity);
        return Ok(personGet);
    }

    [HttpGet]
    public async Task<IActionResult> Login( PersonCredentials personCredentials)
    {
        var res = (await _repository.GetAllAsync()).ToList();

        var personEnt = res.FirstOrDefault(p => p.Login == personCredentials.Login && p.Password == personCredentials.Password);

        if (personEnt != null)
            return Ok(_tokenService.GetToken(personEnt));

        return NotFound("Not found");
    }


    [HttpDelete]
    public async Task<IActionResult> Delete( int id)
    {
        var res = await _repository.DeleteAsync(id);
        if (res == false) return NotFound(res);
        return Ok(res);
    }

    [HttpGet]
    public async Task<IActionResult> GetById(int id)
    {
        var personEntity = await _repository.GetByIdAsync(id);
        if(personEntity == null) return NotFound("Not found");
        var personGet = _mapper.Map<PersonGetDTO>(personEntity);
        return Ok(personGet);
    }

    [HttpPost]
    public async Task<IActionResult> Update(Person person)
    {
        var res = await _repository.UpdateAsync(person);

        if (res == false) return BadRequest(res);
        return Ok(res);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<Person> people = await _repository.GetAllAsync();
        List<PersonGetDTO> personsGetDTO = new List<PersonGetDTO>();
        PersonGetDTO personGet;
        foreach (Person person in people)
        {
            personGet = _mapper.Map<PersonGetDTO>(person);
            personsGetDTO.Add(personGet);
        }
        return Ok(personsGetDTO);
    }
}
