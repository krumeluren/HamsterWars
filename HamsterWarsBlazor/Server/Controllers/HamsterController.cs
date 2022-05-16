using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using HamsterWarsBlazor.Shared;


namespace HamsterWarsBlazor.Server.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class HamsterController : ControllerBase
    {

        private readonly ILogger<HamsterController> _logger;
        private readonly IHamsterService _hamsterService;

        public HamsterController(ILogger<HamsterController> logger, IHamsterService hamsterService)
        {
            _hamsterService = hamsterService;
            _logger = logger;            
        }

        [HttpGet]
        public IEnumerable<Hamster> Get()
        {
            
            var hamsters = _hamsterService.GetAll();


            return hamsters.ToArray();
        }
    }
}
