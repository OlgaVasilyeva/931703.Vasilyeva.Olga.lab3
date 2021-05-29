using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend3.Models
{
    public class NumberVievModel
    {
        public Int32 NumberCount { get; set; }

        public Int32 NumberCountRight { get; set; }

        public List<NumberBul> Prov { get; set; } = new List<NumberBul>();

        public List<NumberResultViewModel> Actions { get; set; } = new List<NumberResultViewModel>();
               
    }
}
