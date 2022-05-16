using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository<T, IKey> where T : BaseEntity<IKey>
    {
        IEnumerable<T> GetAll();
        T GetById(IKey id);
        
    }
}
