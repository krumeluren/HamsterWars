using Domain.Entities;
using Repository;

namespace Services;
public class HamsterService : IHamsterService
{
    private IRepository<Hamster> hamsterRepository;
    private IRepository<Battle> battleRepository;

    public HamsterService(IRepository<Hamster> hamsterRepository,IRepository<Battle> battleRepository)
    {
        this.hamsterRepository = hamsterRepository;
        this.battleRepository = battleRepository;
    }
    public void BattleResult(Hamster winner, Hamster loser)
    {
        winner.Wins++;
        loser.Losses++;
        winner.Games++;
        loser.Games++;

        battleRepository.Insert(new Battle()
        {
            WinnerHamster = winner,
            LoserHamster = loser,
        });
        battleRepository.SaveChanges();
    }
    public void CreateHamster(Hamster hamster)
    {
        hamster.Games = 0;
        hamster.Wins = 0;
        hamster.Losses = 0;
        hamsterRepository.Insert(hamster);
        hamsterRepository.SaveChanges();
    }
    public void DeleteHamster(Hamster hamster)
    {
        // Get all battles where this hamster is involved
        var battles = battleRepository.GetAll().Where(x => x.WinnerHamster == hamster || x.LoserHamster == hamster);

        foreach (var battle in battles)
        {
            if (battle.WinnerHamster == hamster)
            {
                battle.WinnerHamsterId = null;
            }
            else
            {
                battle.LoserHamsterId = null;
            }
        }
        hamsterRepository.Remove(hamster);
        hamsterRepository.SaveChanges();
    }
    public IEnumerable<Hamster> GetAll()
    {
        return hamsterRepository.GetAll();
    }
    public Hamster? GetHamsterById(int Id)
    {
        return hamsterRepository.GetById(Id);
    }
    public IEnumerable<Hamster> GetRandomHamsters()
    {      
        var hamsters = hamsterRepository.GetRandom(2);

        if (hamsters == null || hamsters.Count() != 2)
        {
            return new List<Hamster>();
        }
        return hamsters;
    }
}
