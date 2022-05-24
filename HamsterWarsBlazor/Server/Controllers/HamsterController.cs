using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using HamsterWarsBlazor.Shared;
using Services.Interface;

namespace HamsterWarsBlazor.Server.Controllers;
[ApiController]
[Route("api/[controller]")]
public class HamsterController : ControllerBase
{
    private readonly ILogger<HamsterController> _logger;
    private readonly IHamsterService _hamsterService;
    private readonly IFileUpload _fileUpload;

    public HamsterController(ILogger<HamsterController> logger, IHamsterService hamsterService, IFileUpload fileUpload)
    {
        _logger = logger;
        _hamsterService = hamsterService;
        _fileUpload = fileUpload;
    }

    [HttpGet]
    public IEnumerable<Hamster> Get()
    {
        return _hamsterService.GetAll().ToArray();
    }

    [HttpGet("random")]
    public IEnumerable<Hamster> GetRandom()
    {  
        return _hamsterService.GetRandomHamsters().ToArray();
    }

    [HttpPost]
    public Task<IActionResult> Add(HamsterForm hamsterForm)
    {
        //randomize name for image
        hamsterForm.ImgName =  Guid.NewGuid().ToString() + hamsterForm.ImgName;
        
        var hamster = new Hamster
        {
            Name = hamsterForm.Name,
            Age = hamsterForm.Age,
            FavFood = hamsterForm.FavFood,
            Loves = hamsterForm.Loves,
            ImgName = hamsterForm.ImgName
        };

        Byte[] bytes = Convert.FromBase64String(hamsterForm.ImgData);

        _fileUpload.Upload(bytes, hamsterForm.ImgName);

        if (ModelState.IsValid)
        {
            _hamsterService.CreateHamster(hamster);
            return Task.FromResult<IActionResult>(Ok());
        }  
        return Task.FromResult<IActionResult>(BadRequest());
    }

    [HttpPost("battleresult")]
    public Task<IActionResult> BattleResult(List<Hamster> hamsters)
    {
        var winner = _hamsterService.GetHamsterById(hamsters[0].Id);
        var loser = _hamsterService.GetHamsterById(hamsters[1].Id);

        if (winner != null && loser != null)
        {
            _hamsterService.BattleResult(winner, loser);
        }
        else
        {
            return Task.FromResult<IActionResult>(BadRequest());
        }
        return Task.FromResult<IActionResult>(Ok());
    }

    [HttpPost("delete")]
    public Task<IActionResult> Delete(Hamster hamster)
    {
        var hamsterToDelete = _hamsterService.GetHamsterById(hamster.Id);
        if (hamsterToDelete != null)
        {
            _hamsterService.DeleteHamster(hamsterToDelete);
        }
        else
        {
            return Task.FromResult<IActionResult>(BadRequest());
        }
        return Task.FromResult<IActionResult>(Ok());
    }

}
