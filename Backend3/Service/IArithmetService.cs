using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend3.Service
{
    public interface IArithmetService
    {
        int sum(int a, int b);
        int del(int a, int b);
        int minus(int a, int b);
        int plus(int a, int b);
    }
}
