using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Battle : BaseEntity<int>
    {
        public DateTime Started { get; set; }
        public DateTime Ended { get; set; }

        public virtual ICollection<Hamster>? Hamsters { get; set; }
    }
}
