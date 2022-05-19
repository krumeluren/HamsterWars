using Domain.Entities;


namespace Services
{
    public interface IBattleService
    {
        IEnumerable<Battle> GetAll();
        Battle GetBattleById(int id);
    }
}
