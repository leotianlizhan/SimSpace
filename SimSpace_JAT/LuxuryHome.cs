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
        /// Creates a ComfortableHome facility
        /// </summary>
        public LuxuryHome()
        {
            Cost = 1000000000;
            Maintenance = 1000000;
            Revenue = 1500000;
            Power = 100;
            Pollution = 5000;
            _happyPopulationFactor = 2;
            _maxPopulation = 10000;
        }
    }
}
