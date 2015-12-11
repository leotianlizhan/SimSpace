// Written by: Jack Wen | Team Members: Andrew, Tianli
// Date: December 11, 2015
// This is the EmergencyServices class that creates a factory with the given values
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimSpace_JAT
{
    class EmergencyServices : EssentialServicesFacility
    {
        /// <summary>
        /// Cost of Emergency Service Facilities
        /// </summary>
        public const int COST = 100000000;
        
        /// <summary>
        /// Creates an EmergencyServices facility with the given values
        /// </summary>
        public EmergencyServices()
            : base()
        {
            Maintenance = 50000;
            Power = -5;
        }
    }
}
