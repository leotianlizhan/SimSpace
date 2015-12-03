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
        /// Creates a ComfortableHome facility
        /// </summary>
        public ComfortableHome()
        {
            Cost = 500000000;
            Maintenance = 1000000;
            Revenue = 100000;
            Power = 50;
            Pollution = 2000;
            _happyPopulationFactor = 4;
            _maxPopulation = 15000;
        }
    }
}
