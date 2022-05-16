using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Repository<T, TKey> : IRepository<T, IKey> where T : BaseEntity<IKey>
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> entities;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            entities = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
        
        public T GetById(IKey id)
        {
            return entities.FirstOrDefault(e => e.Id == id);
        }

    }
}
