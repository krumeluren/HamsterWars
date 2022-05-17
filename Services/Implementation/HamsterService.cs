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

        public void CreateHamster(Hamster hamster)
        {
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
