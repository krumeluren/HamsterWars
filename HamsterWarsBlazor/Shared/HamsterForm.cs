using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamsterWarsBlazor.Shared
{
    public class HamsterForm
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string? FavFood { get; set; }
        public string? Loves { get; set; }
        public string? Img_Src { get; set; }



    }
}
