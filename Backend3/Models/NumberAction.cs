using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend3.Models
{
    public enum NumberAction
    {
        Submit,
        Finish
    }
    public class NumberResultViewModel
    {
      public string First { get; set; }
    }
    public class NumberBul
    {
        public int Bul { get; set; }
    }

}
