// Written by: Jack Wen | Team Members: Andrew, Tianli
// Date: December 11, 2015
// This is the Factory class that creates a factory with the given values
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimSpace_JAT
{
    class Factory : IndustrialFacility
    {
        /// <summary>
        /// Cost of Factory
        /// </summary>
        public const int COST = 50000000;

        /// <summary>
        /// Creates a factory with the given attributes
        /// </summary>
        public Factory()
        {
            Maintenance = 500000;
            Revenue = 5000000;
            Pollution = 20000;
            Power = -50;
        }
    }
}
