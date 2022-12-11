using API_Portfolio.Workers;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Portfolio.Controllers
{
    [Route("api/algorithms")]
    [EnableCors(PolicyName = "corsapp")]
    [ApiController]
    public class AlgorithmsController : Controller
    {
        protected readonly IHttpContextAccessor _contextAccessor;
        protected readonly IAlgorithms _algorithms;

        public AlgorithmsController(IAlgorithms algorithms)
        {
            _algorithms = algorithms;
        }

        [HttpPost("getmagicsquare")]
        public IActionResult GetMagicSquare([FromForm] int size)
        {
            var magicSquare = _algorithms.GetMagicSquare(size);

            return Ok(magicSquare);
        }

        [HttpGet("getmagicsquaremock")]
        public IActionResult GetMagicSquareMock()
        {
            var magicSquare = _algorithms.GetMagicSquareMock();

            return Ok(magicSquare);
        }

    }
}
