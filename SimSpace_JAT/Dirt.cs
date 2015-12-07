//Tianli Zhan
//December 2, 2015
//This is the Dirt class, meaning there are no facilities built yet
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimSpace_JAT
{
    class Dirt : Facility
    {
        /// <summary>
        /// Creates a dirt, aka no facilities
        /// </summary>
        public Dirt()
        {
            Maintenance = 0;
            Revenue = 0;
            Power = 0;
            Pollution = 0;
        }
    }
}
