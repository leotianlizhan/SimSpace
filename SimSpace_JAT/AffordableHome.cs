//Tianli Zhan
//December 2, 2015
//This is the AffordableHome class, for creating an affordable home with the right amount of values
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimSpace_JAT
{
    class AffordableHome : ResidentialFacility
    {
        /// <summary>
        /// cost to build the affordable home
        /// </summary>
        public const int COST = 50000000;
        /// <summary>
        /// Creates an AffordableHome facility with certain population
        /// <param name="population">Population for the facility to start with</param>
        /// </summary>
        public AffordableHome(int population)
            : base(population)
        {
            Maintenance = 800000;
            Revenue = 10000;
            Power = 25;
            Pollution = 1000;
            _happyPopulationFactor = 10;
            _maxPopulation = 25000;
        }

        /// <summary>
        /// Builds the affordable home initially
        /// </summary>
        public AffordableHome()
            : this(0)
        {
        }
    }
}
