using Domain.Entities;
using Repository;

namespace Services
{
    public class BattleService : IBattleService
    {
        private IRepository<Hamster, int> hamsterRepository;

        private IRepository<Battle, int> battleRepository;

        public BattleService(IRepository<Hamster, int> hamsterRepository, IRepository<Battle, int> battleRepository)
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
