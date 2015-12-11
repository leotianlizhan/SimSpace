// Written by: Jack Wen | Team Members: Andrew, Tianli 
// Date: December 11, 2015
// Abstract IndustrialFacility that contains variables that are shared by all child classes, such as EnvironmentalFacility
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimSpace_JAT
{
    abstract class IndustrialFacility : Facility
    {
        public const int RANGE_LIMIT = 6;
    }
}