using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repository.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> entities;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            entities = _context.Set<T>();
        }

        public void Remove(T entity)
        {
            entities.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T GetById(int id)
        {
            return entities.FirstOrDefault(e => e.Id == id);
        }

        public void Insert(T entity)
        {
            entities.Add(entity);
            _context.SaveChanges();
        }

        public T GetRandom()
        {
            return entities.OrderBy(e => Guid.NewGuid()).FirstOrDefault();
        }

        public IEnumerable<T> GetRandom(int count)
        {
            var allEntities =  entities.AsEnumerable();

            if (count <= 0)
            {
                return new List<T>();
            }

            else if (count > entities.Count())
            {
                return allEntities;
            }

            return entities.OrderBy(e => Guid.NewGuid()).Take(count);
        }
        
        
    }
}
