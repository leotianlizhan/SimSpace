// Written by Jack Wen | Team members: Andrew, Tianli [Yes, I stole this formatting]
// ICS4U Assignment 2 (SimSpace)
// This is the PlanetModelWrapper class where the variables across the program are recreated and returned
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimSpace_JAT
{
    class PlanetModelWrapper
    {
        // individual team members' models
        private AndrewModel _andrewModel;
        private TianliModel _tianliModel;
        private JackModel _jackModel;

        // Shared variables between each team members' models
        private SharedVariables _variables;

        /// <summary>
        /// Creates a planet's rows and columns with the given number(s)
        /// </summary>
        /// <param name="numRows">the amount of rows of the planet</param>
        /// <param name="numCols">the amount of columns of the planet</param>
        public PlanetModelWrapper(int numRows, int numCols)
        {
            _variables = new SharedVariables();
            _variables.Facilities = new Facility[numRows, numCols];

            for (int i = 0; i < numRows; i++)
                for (int j = 0; j < numCols; j++)
                    _variables.Facilities[i, j] = new Dirt();

            _andrewModel = new AndrewModel(this, _variables); 
            _tianliModel = new TianliModel(this, _variables);
            _jackModel = new JackModel(this, _variables);
        }

        // Creates the public boolean and returns BuildEmergencyServices from JackModel 
        public bool BuildEmergencyServices(int row, int col)
        {
            return _jackModel.BuildEmergencyServices(row, col);
        }

        // Creates the public boolean and returns BuildSchool from JackModel 
        public bool BuildSchool(int row, int col)
        {
            return _jackModel.BuildSchool(row, col);
        }

        // Creates the public boolean and returns BuildMedicalFacility from JackModel 
        public bool BuildMedicalFacility(int row, int col)
        {
            return _jackModel.BuildMedicalFacility(row, col);
        }

        // Creates the public boolean and returns BuildGovernmentFacility from JackModel 
        public bool BuildGovernmentFacility(int row, int col)
        {
            return _jackModel.BuildGovernmentFacility(row, col);
        }

        // Creates the public boolean and returns BuildPowerPlant from JackModel 
        public bool BuildPowerPlant(int row, int col)
        {
            return _jackModel.BuildPowerPlant(row, col);
        }

        // Creates the public boolean and returns BuildFactory from JackModel 
        public bool BuildFactory(int row, int col)
        {
            return _jackModel.BuildFactory(row, col);
        }

        // Creates the public boolean and returns BuildEnvironmentalFacility from JackModel 
        public bool BuildEnvironmentalFacility(int row, int col)
        {
            return _jackModel.BuildEnvironmentalFacility(row, col);
        }

        // Creates the public boolean and returns BuildLuxuryHome from TianliModel 
        public bool BuildLuxuryHome(int row, int col)
        {
            return _tianliModel.BuildLuxuryHome(row, col);
        }

        // Creates the public boolean and returns BuildComfortableHome from TianliModel 
        public bool BuildComfortableHome(int row, int col)
        {
            return _tianliModel.BuildComfortableHome(row, col);
        }

        // Creates the public boolean and returns BuildAffordableHome from TianliModel  
        public bool BuildAffordableHome(int row, int col)
        {
            return _tianliModel.BuildAffordableHome(row, col);
        }

        // Creates the public boolean and returns BuildStore from AndrewModel 
        public bool BuildStore(int row, int col)
        {
            return _andrewModel.BuildStore(row, col);
        }

        // Creates the public boolean and returns BuildRestaurant from AndrewModel 
        public bool BuildRestaurant(int row, int col)
        {
            return _andrewModel.BuildRestaurant(row, col);
        }

        // Creates the public boolean and returns BuildOffice from AndrewModel 
        public bool BuildOffice(int row, int col)
        {
            return _andrewModel.BuildOffice(row, col);
        }

        // Creates the public boolean and returns CanBuildHighlightedGrid from TianliModel
        public bool[,] CanBuildHighlightedGrid(int selectedFacility)
        {
            return _tianliModel.CanBuildHighlightedGrid(selectedFacility);
        }

        // Creates the public boolean and returns CanBuildResidential from AndrewModel
        public bool CanBuildResidential(int row, int col)
        {
            return _tianliModel.CanBuildResidential(row, col);
        }

        // Creates the public boolean and returns CanBuildIndustrial from TianliModel
        public bool CanBuildIndustrial(int row, int col)
        {
            return _tianliModel.CanBuildIndustrial(row, col);
        }

        // Creates the public boolean and returns CanBuildCommercial from AndrewModel
        public bool CanBuildCommercial(int row, int col)
        {
            return _andrewModel.CanBuildCommercial(row, col);
        }

        // Creates the public boolean and returns AttemptAsteroidStrike from AndrewModel
        public bool AttemptAsteroidStrike()
        {
            return _andrewModel.AttemptAsteroidStrike();
        }

        // Creates the public integer and returns CalculateHappyPopulation from AndrewModel
        public int CalculateHappyPopulation()
        {
            return _andrewModel.CalculateHappyPopulation();
        }

        // Creates the public integer and returns CalculatePopulation from AndrewModel
        public int CalculatePopulation()
        {
            return _andrewModel.CalculatePopulation();
        }

        // Creates the public integer and returns CalculatePollution from JackModel
        public int CalculatePollution()
        {
            return _jackModel.CalculatePollution();
        }

        // Creates the public integer and returns CalculateScore from JackModel
        public int CalculateScore()
        {
            return _jackModel.CalculateScore();
        }

        // Creates the public long and returns CalculateMoney from TianliModel
        public long CalculateMoney()
        {
            return _tianliModel.CalculateMoney();
        }

        // Creates the public integer and returns CalculatePower from TianliModel
        public int CalculatePower()
        {
            return _tianliModel.CalculatePower();
        }

        // Creates the public constructor and returns UpdateTime from TianliModel
        public void UpdateTime()
        {
            _tianliModel.UpdateTime();
        }

        /// <summary>
        /// Saves the game
        /// </summary>
        /// <returns>True if successful</returns>
        public bool Save()
        {
            return _tianliModel.Save();
        }

        /// <summary>
        /// Loads the selected game
        /// </summary>
        /// <param name="filePath">Path to the saved game file</param>
        /// <returns>True if successful</returns>
        public bool Load(string filePath)
        {
            return _andrewModel.Load(filePath);
        }

        /// <summary>
        /// Saves the score in the file provided
        /// </summary>
        /// <param name="filePath">File path</param>
        public void SaveScore(string filePath)
        {
            _jackModel.SaveScore(filePath);
        }

        /// <summary>
        /// Loads the score from the file provided
        /// </summary>
        /// <param name="filePath">File path</param>
        public void LoadScore(string filePath)
        {
            _jackModel.LoadScore(filePath);
        }

        /// <summary>
        /// Gets or sets the facilities array
        /// </summary>
        public Facility[,] Facilities
        {
            get
            {
                return _variables.Facilities;
            }
            private set
            {
                _variables.Facilities = value;
            }
        }

        /// <summary>
        /// Gets or sets the amount of money the player has
        /// </summary>
        public long Money
        {
            get
            {
                return _variables.Money;
            }
            private set
            {
                _variables.Money = value;
            }
        }

        /// <summary>
        /// Gets or sets the score for the player
        /// </summary>
        public int Score
        {
            get
            {
                return _variables.Score;
            }
            private set
            {
                _variables.Score = value;
            }
        }
    }
}