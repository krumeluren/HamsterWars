using Domain.Entities;

namespace Services;
public interface IHamsterService
{
    IEnumerable<Hamster> GetAll();
    /// <summary>
    /// Gets a single hamster by id from the dbcontext 
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The found hamster</returns>
    Hamster? GetHamsterById(int id);       
    /// <summary>
    /// 
    /// </summary>
    /// <param name="hamster"></param>
    void CreateHamster(Hamster hamster);
    /// <summary>
    /// Selects 2 random hamsters. If less than 2 hamsters found none are selected.
    /// </summary>
    /// <returns>2 hamsters or empty</returns>
    IEnumerable<Hamster> GetRandomHamsters();
    /// <summary>
    /// Increment Games, Wins and Losses and creates a new Battle entity with the winner and loser.
    /// </summary>
    /// <param name="winner">The winner</param>
    /// <param name="loser">The loser</param>
    void BattleResult(Hamster winner, Hamster loser);
    /// <summary>
    /// Delete the hamster
    /// </summary>
    void DeleteHamster(Hamster hamster);
}
