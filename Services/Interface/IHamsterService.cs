using Domain.Entities;

namespace Services
{
    public interface IHamsterService
    {
        IEnumerable<Hamster> GetAll();
        Hamster GetHamsterById(int id);
    }
}
