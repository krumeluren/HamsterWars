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
        private IRepository<Hamster, int> hamsterRepository;
        
        private IRepository<Battle, int> battleRepository;

        public HamsterService(IRepository<Hamster, int> hamsterRepository, IRepository<Battle, int> battleRepository)
        {
            this.hamsterRepository = hamsterRepository;
            this.battleRepository = battleRepository;
        }

        public IEnumerable<Hamster> GetAll()
        {
            return hamsterRepository.GetAll();
        }
        
        public Hamster GetHamsterById(int Id)
        {
            return hamsterRepository.GetById(Id);
        }
    }
}
