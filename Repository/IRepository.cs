using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository;
public interface IRepository<T> where T : BaseEntity
{
    /// <returns>All entities in the dbset</returns>
    IEnumerable<T> GetAll();
    /// <param name="id">The primary key</param>
    /// <returns>A single entity by the primary key</returns>
    T? GetById(int id);        
    /// <summary>
    /// Remove entity from database
    /// </summary>
    /// <param name="entity">The entity to be removed</param>
    void Remove(T entity);
    /// <summary>
    /// Add entity to database
    /// </summary>
    void Insert(T entity);        
    /// <returns>A random entity of the type from the dbcontext</returns>
    T? GetRandom();
    /// <summary>Selects random entities. Selects all entities if count is greater than the count of entities in the dbcontext.</summary>
    /// <param name="count">The amount of random entities to return</param>
    /// <returns>A set of random entities of the type from dbset. Or an empty list if count is 0 or less.</returns>
    IEnumerable<T> GetRandom(int count);
    /// <summary>
    /// Saves all changes made in this context to the database.
    /// </summary>
    void SaveChanges();
}
