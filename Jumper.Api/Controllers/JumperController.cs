using System;
using System.Collections.Generic;
using System.Linq;
using Jumper.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Jumper.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JumperController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<JumperController> _logger;

        public JumperController(ILogger<JumperController> logger, Calculator jumpCalculator)
        {
            _logger = logger;
            JumpCalculator = jumpCalculator;
        }

        public Calculator JumpCalculator { get; }

        [HttpGet]
        public string Get()
        {
            return "Call POST, pass arrays of arrays for batch processing. Example: [[1,2,3,4],[1,0,0]]";
        }

        [HttpPost]
        public IEnumerable<List<int>> Post(List<List<int>> input)
        {
            var result = input.OrderedParallel(o => JumpCalculator.GetShortestPath(o));
            return result;
        }
    }
}
