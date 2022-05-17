﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Hamster : BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string? FavFood { get; set; }
        public string? Loves { get; set; }
        public string? Img_Src { get; set; }
        public int? Wins { get; set; }
        public int? Losses { get; set; }
        public int? Games { get; set; }

        [InverseProperty("WinnerHamster")]
        public ICollection<Battle>? BattlesWon { get; set; }

        [InverseProperty("LoserHamster")]
        public ICollection<Battle>? BattlesLost { get; set; }
    }
}
