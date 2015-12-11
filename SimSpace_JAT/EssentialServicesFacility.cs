// Written by: Jack Wen | Team Members: Andrew, Tianli
// Date: December 11, 2015
// Abstract IndustrialFacility class that contains all the values shared in all of the child classes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimSpace_JAT
{
    abstract class IndustrialFacility : Facility
    {
        // Creates a public constant integer that saves the Range Limit as 6
        public const int RANGE_LIMIT = 6;
    }
}
