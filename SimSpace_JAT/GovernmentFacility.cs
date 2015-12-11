// Written by: Jack Wen | Team Members: Andrew, Tianli
// Date: December 11, 2015
// This is the GovernmentFacility class that creates a factory with the given values
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimSpace_JAT
{
    class GovernmentFacility : EssentialServicesFacility
    {
        /// <summary>
        /// Cost of a Government Facility
        /// </summary>
        public const int COST = 10000000;

        /// <summary>
        /// Creates a Government Facility with the assigned values
        /// </summary>
        public GovernmentFacility()
            : base()
        {
            Maintenance = 1000000;
            Power = -10; 
        }
    }
}
