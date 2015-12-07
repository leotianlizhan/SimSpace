// Written by Andrew Pang | Group members: Jack, Tianli
// Wednesday, December 2, 2015
// This class sets the statistics of the Store facility.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimSpace_JAT
{
    class Store : CommercialFacility
    {
        // Create a constant integer variable to store the cost of the store facility
        public const int COST = 2000000;

        /// <summary>
        /// The constructor for the Store facility.
        /// </summary>
        public Store()
        {
            // Set the monthly maintenance cost of the Store
            Maintenance = 50000;
            // Set the monthly revenue of the Store
            Revenue = 200000;
            // Set the monthly power generation of the Store
            Power = -5;
            // Set the monthly pollution output of the Store
            Pollution = 500;
        }
    }
}
