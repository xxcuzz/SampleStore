using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleStore.Infrastructure.Persistence.Dapper.DatabaseInitWork;

namespace SampleStore.API.Controllers;

[Route("[controller]")]
[AllowAnonymous]
public class DatabaseController : ApiController
{
    private readonly DatabaseOperations _dbOperations;

    public DatabaseController(DatabaseOperations dbOperations)
    {
        _dbOperations = dbOperations;
    }

    [HttpPost("[action]")]
    public IActionResult Clear()
    {
        _dbOperations.ClearDatabase();
        return Ok();
    }

    [HttpPost("[action]")]
    public IActionResult Seed()
    {
        _dbOperations.SeedDatabase();
        return Ok();
    }
}
