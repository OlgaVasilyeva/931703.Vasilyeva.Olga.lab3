﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend3.Service
{
    public class RandomService : IRandomService
    {
        private Random rand = new Random();
        public int Rand(int min, int max)
        {
            return rand.Next(min, max);
        }
    }
}
