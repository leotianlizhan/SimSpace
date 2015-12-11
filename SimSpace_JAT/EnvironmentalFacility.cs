// Written by: Jack Wen | Team Members: Andrew, Tianli
// Date: December 11, 2015
// This is the EnvironmentalFacility class that creates a factory with the given values
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimSpace_JAT
{
    class EnvironmentalFacility : IndustrialFacility
    {
        /// <summary>
        /// Cost of an Environmental Facility
        /// </summary>
        public const int COST = 200000000;
        
        /// <summary>
        /// Creates an EnvironmentalFacility with the assigned attributes
        /// </summary>
        public EnvironmentalFacility()
        {
            Maintenance = 3000000;
            Revenue = 0;
            Pollution = -20000;
            Power = -75;
        }
    }
}
