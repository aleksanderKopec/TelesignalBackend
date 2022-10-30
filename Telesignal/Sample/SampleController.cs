using Microsoft.AspNetCore.Authorization;
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
    
    [Authorize]
    [HttpGet("auth")]
    public string HelloAuth() {
        return "Hello world";
    }
    
    [HttpGet("")]
    public string HelloNoAuth() {
        return "Hello world";
    }

}
