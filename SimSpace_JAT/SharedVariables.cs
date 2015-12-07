// Written by Andrew Pang | Team members: Tianli, Jack
// Date: Sunday, December 6, 2015
// ICS4U Assignment 2 (SimSpace)
// This is the shared variables class, where variables that are universal between classes are set/declared
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimSpace_JAT
{
    class SharedVariables
    {
        // The row dimension value of the 2D array
        public const int ROW = 0;
        // The column dimension value of the 2D array
        public const int COL = 1;
        // The base starting amount of money the player starts out with
        public const long START_MONEY = 5000000000;
        // The size of each grid cell in pixels (each grid cell is a square; thus the size represents the length and width)
        public const int CELL_SIZE = 35;
        // The size of each toolbar cell in pixels (each toolbar cell is a square; thus the size represents the length and width)
        public const int TOOLBAR_SIZE = 50;
        // The length of each month, in seconds
        public const int MONTH = 10;

        // Construct a new random generator object
        private static Random _numberGenerator = new Random();

        // Create a number generator object
        public static Random NumberGenerator
        {
            get
            {
                return _numberGenerator;
            }
        }

        
        // ||***STRUCTURE ID VALUES***||
        // The structure ID of Dirt (unused land)
        public const int DIRT = -1;
        // The structure ID of Emergency Services
        public const int EMERGENCY_SERVICES = 0;
        // The structure ID of a School
        public const int SCHOOL = 1;
        // The structure ID of a Medical facility
        public const int MEDICAL = 2;
        // The structure ID of a Government building
        public const int GOVERNMENT = 3;
        // The structure ID of a Power Plant
        public const int POWER_PLANT = 4;
        // The structure ID of a Luxury home
        public const int LUXURY_HOME = 5;
        // The structure ID of a Comfortable home
        public const int COMFORTABLE_HOME = 6;
        // The structure ID of an Affordable home
        public const int AFFORDABLE_HOME = 7;
        // The structure ID of a Factory
        public const int FACTORY = 8;
        // The structure ID of an Environmental facility
        public const int ENVIRONMENTAL_FACILITY = 9;
        // The structure ID of a Store
        public const int STORE = 10;
        // The structure ID of a Restaurant
        public const int RESTAURANT = 11;
        // The structure ID of an Office
        public const int OFFICE = 12;
        // ||*************************||

        // Create a private long variable to store the money
        private static long _money;
        // Create a private integer variable to store the score
        private static int _score;

        // The private 2D array of facilities
        private Facility[,] _facilities;
        
        /// <summary>
        /// The public 2D array of facilities that the player builds
        /// </summary>
        public Facility[,] Facilities
        {
            get
            {
                return _facilities;
            }
            set
            {
                _facilities = value;
            }
        }


        /// <summary>
        /// The amount of money the player has.
        /// </summary>
        public long Money
        {
            get
            {
                return _money;
            }
            set
            {
                _money = value;
            }
        }

        /// <summary>
        /// The number of rows in the map.
        /// </summary>
        public int NumRows
        {
            get
            {
                return Facilities.GetLength(ROW);
            }
        }

        /// <summary>
        /// The number of columns in the map.
        /// </summary>
        public int NumCols
        {
            get
            {
                return Facilities.GetLength(COL);
            }
        }

        /// <summary>
        /// The score the player has accumulated. This value can be negative.
        /// </summary>
        public int Score
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
            }
        }
    }
}
