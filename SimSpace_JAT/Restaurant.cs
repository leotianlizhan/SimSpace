// Written by Andrew Pang | Group members: Jack, Tianli
// Wednesday, December 2, 2015
// This class sets the statistics of the Restaurant facility.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimSpace_JAT
{
    class Restaurant : CommercialFacility
    {
        // Create a constant integer variable to store the initial build cost of the restaurant
        public const int COST = 250000;

        /// <summary>
        /// The constructor for the Restaurant facility.
        /// </summary>
        public Restaurant()
        {
            // Set the monthly maintenance cost of the Restaurant
            Maintenance = 5000;
            // Set the monthly revenue of the Restaurant
            Revenue = 10000;
            // Set the monthly power generation of the Restaurant
            Power = -5;
            // Set the monthly pollution output of the Restaurant
            Pollution = 300;
        }
    }
}
