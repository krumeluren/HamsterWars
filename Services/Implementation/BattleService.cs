using Domain.Entities;
using Repository;

namespace Services
{
    public class BattleService : IBattleService
    {
        private IRepository<Hamster> hamsterRepository;
        
        private IRepository<Battle> battleRepository;

        public BattleService(IRepository<Hamster> hamsterRepository, IRepository<Battle> battleRepository)
        {
            this.hamsterRepository = hamsterRepository;
            this.battleRepository = battleRepository;
        }

        public IEnumerable<Battle> GetAll()
        {
            return battleRepository.GetAll();
        }

        public Battle GetBattleById(int id)
        {
            return battleRepository.GetById(id);
        }
    }
}
