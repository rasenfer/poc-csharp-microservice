namespace poc_csharp_microservice.Model;
using Swashbuckle.AspNetCore.Annotations;

[SwaggerSchema(Description = "echo entity")]
public class Echo
{
    [SwaggerSchema(Description = "echo id")]
    public int Id { get; set; }

    [SwaggerSchema(Description = "echo name")]
    public string? Name { get; set; }

    [SwaggerSchema(Description = "echo description")]
    public string? Description { get; set; }

    [SwaggerSchema(Description = "echo created time")]
    public DateTime Created { get; set; }
}
