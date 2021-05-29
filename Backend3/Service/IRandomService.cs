using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend3.Service
{
    public interface IRandomService
    {
        int Rand(int min, int max);
    }
}
