//Tianli Zhan
//December 2, 2015
//This is the ComfortableHome class, for creating a comfortable home with the right amount of values
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimSpace_JAT
{
    class ComfortableHome : ResidentialFacility
    {
        /// <summary>
        /// cost to build the comfortable home
        /// </summary>
        public const int COST = 500000000;
        /// <summary>
        /// Creates a ComfortableHome facility with certain population
        /// </summary>
        public ComfortableHome(int population)
            : base(population)
        {
            Maintenance = 1000000;
            Revenue = 100000;
            Power = -50;
            Pollution = 2000;
            _happyPopulationFactor = 4;
            _maxPopulation = 15000;
        }
        /// <summary>
        /// Creates a comfortable home facility initially, with no population
        /// </summary>
        public ComfortableHome() : this(0) { }
    }
}
