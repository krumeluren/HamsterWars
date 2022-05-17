using Domain.Entities;

namespace Services
{
    public interface IHamsterService
    {
        IEnumerable<Hamster> GetAll();
        Hamster GetHamsterById(int id);
        void CreateHamster(Hamster hamster);

        /// <summary>
        /// Selects 2 random hamsters. If less than 2 hamsters found none are selected.
        /// </summary>
        /// <returns>2 hamsters or empty</returns>
        IEnumerable<Hamster> GetRandomHamsters();
    }
}
