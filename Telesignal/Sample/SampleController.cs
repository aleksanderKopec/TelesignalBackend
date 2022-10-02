using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Telesignal.Sample.Interfaces;

namespace Telesignal.Sample;

[ApiController]
[Route("sample")]
public class SampleController : ControllerBase, ISampleController
{
    private ISampleService _sampleService;

    public SampleController(ISampleService sampleService) {
        _sampleService = sampleService;
    }

    [HttpGet("/")]
    [Authorize]
    public string Hello() {
        return "Hello world";
    }
}
