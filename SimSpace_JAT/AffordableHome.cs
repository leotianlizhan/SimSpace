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
        /// Creates an AffordableHome facility
        /// </summary>
        public AffordableHome()
        {
            Cost = 50000000;
            Maintenance = 800000;
            Revenue = 10000;
            Power = 25;
            Pollution = 1000;
            _happyPopulationFactor = 10;
            _maxPopulation = 25000;
        }
    }
}
