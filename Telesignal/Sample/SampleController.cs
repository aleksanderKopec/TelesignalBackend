using Microsoft.AspNetCore.Mvc;
using Telesignal.Sample.Interfaces;

namespace Telesignal.Sample;

[ApiController]
[Route("sample")]
public class SampleController : ControllerBase
{
    private ISampleService _sampleService;

    public SampleController(ISampleService sampleService) {
        _sampleService = sampleService;
    }

    [HttpGet("/")]
    public string Hello() {
        return "Hello world";
    }
}
