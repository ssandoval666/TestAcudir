using AcudirTes2.Models;
using AcudirTes2.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcudirTes2.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PeopleController : ControllerBase    
    {
        
        private readonly ILogger<PeopleController> _logger;
        private IPeopleService _PeopleService;

        public PeopleController(ILogger<PeopleController> logger, IPeopleService oPeopleService)
        {
            _PeopleService = oPeopleService;
            _logger = logger;
        }

        
        [HttpGet]
        [Authorize]
        public IEnumerable<People> Get()
        {
            return _PeopleService.GetAll();
        }

        
        [HttpGet("{id}")]
        [Authorize]
        public People Get(int id)
        {
            return _PeopleService.GetById(id);
        }

        
        [HttpGet("Shuffle")]
        [Authorize]
        public People Shuffle()
        {             

            return _PeopleService.GetAll().OrderBy(x => Guid.NewGuid()).FirstOrDefault();
        }


        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(int id)
        {

            _PeopleService.Delete(id);
        }

        [HttpPost("Delete")]
        [Authorize]
        public void Borrar(int id)
        {

            _PeopleService.Delete(id);
        }

    }
}
