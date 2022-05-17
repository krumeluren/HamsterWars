using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Battle : BaseEntity
    {
        public DateTime TimeOfPost { get; set; }
        public int WinnerHamsterId { get; set; }

        [ForeignKey("WinnerHamsterId")]
        public virtual Hamster WinnerHamster { get; set; }
        public int LoserHamsterId { get; set; }
        
        [ForeignKey("LoserHamsterId")]
        public virtual Hamster LoserHamster { get; set; }
        
    }
}
