// Written by: Jack Wen | Team Members: Andrew, Tianli
// Date: December 11, 2015
// This is the MedicalFacility class that creates a factory with the given values
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimSpace_JAT
{
    class MedicalFacility : EssentialServicesFacility
    {
        /// <summary>
        /// Cost of a Medical Facility
        /// </summary>
        public const int COST = 1000000000;
        
        /// <summary>
        /// Creates a Medical Facility with the assigned attributes
        /// </summary>
        public MedicalFacility()
            : base()
        {
            Maintenance = 15000000;
            Power = -20;
        }
    }
}
