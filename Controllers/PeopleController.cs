using CustomerApi.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PeopleController : ControllerBase
{
    private IValidator<Person> _validator;
    private readonly List<Person> _people = new List<Person>();

    public PeopleController(IValidator<Person> validator)
    {
        // Inject our validator and also a DB context for storing our person object.
        _validator = validator;
    }


    [HttpPost]
    public async Task<IActionResult> Create(Person person)
    {
        var validationResult = await _validator.ValidateAsync(person);
        var x = "a, b, c, d,";

        var n = x.TrimEnd(',');

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        _people.Add(person);

        return Ok(person);
    }
}