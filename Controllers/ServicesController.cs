using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tp.Integrador.Softtek.Entities;

namespace Tp.Integrador.Softtek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(Service services)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Service updatedService)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
