// Written by Andrew Pang | Group members: Jack, Tianli
// Wednesday, December 2, 2015
// This class sets the statistics of the Office facility.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimSpace_JAT
{
    class Office : CommercialFacility
    {
        // Create a constant integer variable to store the initial build cost of an office facility
        public const int COST = 3000000;

        /// <summary>
        /// The constructor for the Office facility.
        /// </summary>
        public Office()
        {
            // Set the monthly maintenance cost of the Office
            Maintenance = 10000;
            // Set the monthly revenue of the Office
            Revenue = 20000;
            // Set the monthly power generation of the Office
            Power = -15;
            // Set the monthly pollution output of the Office
            Pollution = 800;
        }
    }
}
