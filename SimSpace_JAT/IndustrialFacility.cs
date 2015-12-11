// Written by: Jack Wen | Team Members: Andrew, Tianli
// Date: December 11, 2015
// Abstract EssentialServicesFacility class that contains all the values shared in all of the child classes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimSpace_JAT
{
    abstract class EssentialServicesFacility : Facility
    {
        /// <summary>
        /// Sets the default revenue and pollution for the child classes
        /// </summary>
        public EssentialServicesFacility()
        {
            Revenue = 0;
            Pollution = 0;
        }
    }
}
