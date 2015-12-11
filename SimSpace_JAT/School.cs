// Written by: Jack Wen | Team Members: Andrew, Tianli
// Date: December 11, 2015
// This is the School class that creates a factory with the given values
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimSpace_JAT
{
    class School : EssentialServicesFacility
    {
        /// <summary>
        /// Cost of Schools
        /// </summary>
        public const int COST = 500000000;

        /// <summary>
        /// Creates a school with the assigned values
        /// </summary>
        public School()
            : base()
        {
            Maintenance = 5000000;
            Power = -15;
        }
    }
}
