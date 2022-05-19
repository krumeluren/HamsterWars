using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using HamsterWarsBlazor.Shared;


namespace HamsterWarsBlazor.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
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

        [HttpGet("random")]
        public IEnumerable<Hamster> GetRandom()
        {
            var hamsters = _hamsterService.GetRandomHamsters();
            return hamsters.ToArray();
        }

        [HttpPost]
        public async Task<IActionResult> Add(HamsterForm hamsterForm)
        {
            var hamster = new Hamster
            {
                Name = hamsterForm.Name,
                Age = hamsterForm.Age,
                FavFood = hamsterForm.FavFood,
                Loves = hamsterForm.Loves,
                Img_Src = hamsterForm.Img_Src
            };
            
            _hamsterService.CreateHamster(hamster);
            return Ok();
        }

        [HttpPost("battleresult")]
        public async Task<IActionResult> BattleResult(List<Hamster> hamsters)
        {
            var winner = _hamsterService.GetHamsterById(hamsters[0].Id);
            var loser = _hamsterService.GetHamsterById(hamsters[1].Id);
            
            _hamsterService.BattleResult(winner, loser);
            return Ok();
            
        }

    }
}
