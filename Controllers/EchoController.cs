using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

using poc_csharp_microservice.Model;

namespace poc_csharp_microservice.Controllers;

[ApiController]
[Route("echo")]
public class EchoController : ControllerBase
{

    private readonly ILogger<EchoController> _logger;

    public EchoController(ILogger<EchoController> logger)
    {
        _logger = logger;
    }

    [SwaggerOperation(Summary = "Returns list of echoes.")]
    [HttpGet]
    public IEnumerable<Echo> Get()
    {
        return Enumerable.Range(1, 100).Select(index => Build(index))
        .ToArray();
    }

    [SwaggerOperation(Summary = "Create an echo.")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public Echo Post([FromBody] Echo echo)
    {
        _logger.LogInformation("Post -> {} ", echo);
        HttpContext.Response.StatusCode = StatusCodes.Status201Created;
        return echo;
    }

    [SwaggerOperation(Summary = "Returns specific echo by id.")]
    [HttpGet("{id}")]
    public Echo Get(int id)
    {
        _logger.LogInformation("Get -> {} ", id);
        return Build(id);
    }

    [SwaggerOperation(Summary = "Update specific echo by id.")]
    [HttpPut("{id}")]
    public Echo Put(int id, [FromBody] Echo echo)
    {
        _logger.LogInformation("Put -> {} ", echo);
        return echo;
    }

    [SwaggerOperation(Summary = "Modify specific echo by id.")]
    [HttpPatch("{id}")]
    public Echo Patch(int id, [FromBody] Echo echo)
    {
        _logger.LogInformation("Patch -> {} ", echo);
        return echo;
    }

    [SwaggerOperation(Summary = "Delete specific echo by id.")]
    [HttpDelete("{id}")]
    public Echo Delete(int id)
    {
        _logger.LogInformation("Delete -> {} ", id);
        return Build(id);
    }

    private Echo Build(int id) {
        return new Echo
        {
            Id = id,
            Name = "name " + id,
            Description = "description " + id,
            Created = DateTime.Now.AddDays(id)
        };
    }
}
