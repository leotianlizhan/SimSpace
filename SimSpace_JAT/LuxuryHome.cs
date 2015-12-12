//Tianli Zhan
//December 2, 2015
//This is the LuxuryHome class, for creating a LuxuryHome with the right amount of values
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimSpace_JAT
{
    class LuxuryHome : ResidentialFacility
    {
        /// <summary>
        /// Cost for luxury home
        /// </summary>
        public const int COST = 1000000000;
        /// <summary>
        /// Creates a ComfortableHome facility with certain population
        /// </summary>
        public LuxuryHome(int population)
            : base(population)
        {
            Maintenance = 1000000;
            Revenue = 1500000;
            Power = -100;
            Pollution = 5000;
            _happyPopulationFactor = 2;
            _maxPopulation = 10000;
        }
        /// <summary>
        /// Creates a comfortable home facility initially, with no population
        /// </summary>
        public LuxuryHome() : this(0) { }
    }
}
