using Microsoft.AspNetCore.Mvc;
using Telesignal.Common.Database.EntityFramework.Model;
using Telesignal.Sample.Interfaces;

namespace Telesignal.Sample;

[ApiController]
[Route("/sample")]
public class SampleController : ControllerBase, ISampleController
{
    readonly private ISampleService _sampleService;

    public SampleController(ISampleService sampleService) {
        _sampleService = sampleService;
    }

    [HttpGet("/")]
    public string Hello() {
        return "Hello world";
    }

    [HttpGet("/user/{id}")]
    public async Task<User> GetUser(string id) {
        return await _sampleService.GetUser(id);
    }
}
