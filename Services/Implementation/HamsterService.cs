using Domain.Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class HamsterService : IHamsterService
    {
        private IRepository<Hamster> hamsterRepository;
        
        private IRepository<Battle> battleRepository;

        public HamsterService(IRepository<Hamster> hamsterRepository, IRepository<Battle> battleRepository)
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

            battleRepository.Insert(new Battle {
                TimeOfPost = DateTime.Now,
                WinnerHamster = winner,
                LoserHamster = loser 
            });
        }

        public void CreateHamster(Hamster hamster)
        {
            hamster.Games = 0;
            hamster.Wins = 0;
            hamster.Losses = 0;
            
            hamsterRepository.Insert(hamster);
        }

        public IEnumerable<Hamster> GetAll()
        {
            return hamsterRepository.GetAll();
        }
        
        public Hamster GetHamsterById(int Id)
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
}
