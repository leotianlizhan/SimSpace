// Written by Andrew Pang || Group members: Tianli Zhan, Jack Wen 
// ICS4U December 2, 2015
// This is the parent class for the commercial facilities, which inherits from the main facility class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimSpace_JAT
{
    abstract class CommercialFacility : Facility
    {
        // The maximum distance it can be built from a residental facility
        public const int RANGE_LIMIT = 6;

        
    }
}
