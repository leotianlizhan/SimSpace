// Written by: Jack Wen | Team Members: Andrew, Tianli
// Date: December 11, 2015
// This is the Powerplant class that creates a factory with the given values
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimSpace_JAT
{
    class Powerplant : EssentialServicesFacility
    {
        /// <summary>
        /// Cost of a Powerplant
        /// </summary>
        public const int COST = 500000000;
        
        /// <summary>
        /// Creates a Powerplant with the given values
        /// </summary>
        public Powerplant()
            : base()
        {
            Maintenance = 2000000;
            Power = 100;
        }
    }
}
