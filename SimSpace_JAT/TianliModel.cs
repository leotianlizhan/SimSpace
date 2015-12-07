// Tianli Zhan
// December 2, 2015
// My model that contains my share of the subprograms for this program
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimSpace_JAT
{
    class TianliModel
    {
        /// <summary>
        /// Links to the other programmers' methods
        /// </summary>
        private PlanetModelWrapper _wrapper;

        /// <summary>
        /// Links to the variable all programmers share
        /// </summary>
        private SharedVariables _variables;

        /// <summary>
        /// Creates an object with Tianli's subprograms of the simspace program
        /// </summary>
        /// <param name="wrapper">Model wrapper that has the rest of the team's subprograms</param>
        /// <param name="variables">SharedVariables object that has all the required variables shared between all 3 of us</param>
        public TianliModel(PlanetModelWrapper wrapper, SharedVariables variables)
        {
            _wrapper = wrapper;
            _variables = variables;
        }

        /// <summary>
        /// Checks if a residential facility can be built in a location
        /// </summary>
        /// <param name="row">Row of the location to be built</param>
        /// <param name="col">Column of the location to be built</param>
        /// <returns>A boolean to indicate if it can be built there</returns>
        public bool CanBuildResidential(int row, int col)
        {
            //check if the location to be built is not dirt, because if it's not, you can't build it there
            if(!(_variables.Facilities[row, col] is Dirt))
                return false;
            //boolean variables to store if such a facility is found within the range, ALTERNATIVELY I CAN USE A MASK
            bool hasEmergencyServices = false, hasSchool = false, hasMedical = false, hasGovernment = false, hasPowerPlant = false;
            //loop through the facilities array
            for (int i = 0; i < _variables.NumRows; i++)
            {
                for (int j = 0; j < _variables.NumCols; j++)
                {
                    //check if current location is within range
                    if ((i-row)*(i-row) + (j-col)*(j-col) <= ResidentialFacility.RANGE_LIMIT*ResidentialFacility.RANGE_LIMIT)
                    {
                        //check what kind of facility it is, and flag the corresponding "has" variables with true
                        if (_variables.Facilities[i, j] is EmergencyServices)
                            hasEmergencyServices = true;
                        else if (_variables.Facilities[i, j] is School)
                            hasSchool = true;
                        else if (_variables.Facilities[i, j] is MedicalFacility)
                            hasMedical = true;
                        else if (_variables.Facilities[i, j] is GovernmentFacility)
                            hasGovernment = true;
                        else if (_variables.Facilities[i, j] is Powerplant)
                            hasPowerPlant = true;
                    }
                }
            }
            //if all the facilities are found within range, the residential facility can be built here
            if (hasEmergencyServices && hasSchool && hasMedical && hasGovernment && hasPowerPlant)
                return true;
            //otherwise it cannot
            return false;
        }

        /// <summary>
        /// Check if an Industrial facility can be built at specified location
        /// </summary>
        /// <param name="row">Row to build the industrial facility</param>
        /// <param name="col">Column to build the industrial facility</param>
        /// <returns></returns>
        public bool CanBuildIndustrial(int row, int col)
        {
            for (int i = 0; i < _variables.NumRows; i++)
                for (int j = 0; j < _variables.NumCols; j++)
                    if ((i - row) * (i - row) + (j - col) * (j - col) <= ResidentialFacility.RANGE_LIMIT * ResidentialFacility.RANGE_LIMIT)
                        if (_variables.Facilities[i, j] is Powerplant)
                            return true;
            return false;
        }

        public bool[,] CanBuildHighlightedGrid(int selectedFacility)
        {
            bool[,] highlightedGrid = new bool[_variables.NumRows, _variables.NumCols];
            for(int i=0; i<_variables.NumRows; i++)
                for(int j=0; j<_variables.NumCols; j++)
                    if (_variables.Facilities[i, j] is Dirt)
                    {
                        if (selectedFacility == SharedVariables.LUXURY_HOME || selectedFacility == SharedVariables.COMFORTABLE_HOME ||
                            selectedFacility == SharedVariables.AFFORDABLE_HOME)
                            highlightedGrid[i, j] = _wrapper.CanBuildResidential(i, j);
                        else if (selectedFacility == SharedVariables.FACTORY || selectedFacility == SharedVariables.ENVIRONMENTAL_FACILITY)
                            highlightedGrid[i, j] = _wrapper.CanBuildIndustrial(i, j);
                        else if (selectedFacility == SharedVariables.STORE || selectedFacility == SharedVariables.RESTAURANT ||
                            selectedFacility == SharedVariables.OFFICE)
                            highlightedGrid[i, j] = _wrapper.CanBuildCommercial(i, j);
                        else
                            highlightedGrid[i, j] = true;
                    }
            return highlightedGrid;
        }

        //build a luxury home facility at specified location
        public bool BuildLuxuryHome(int row, int col)
        {
            return BuildFacility(row, col, BUILD_LUXURY);
        }
        //build a comfortable home facility at specified location
        public bool BuildComfortableHome(int row, int col)
        {
            return BuildFacility(row, col, BUILD_COMFORTABLE);
        }
        //build a affordable home facility at specified location
        public bool BuildAffordableHome(int row, int col)
        {
            return BuildFacility(row, col, BUILD_AFFORDABLE);
        }
        private const string BUILD_LUXURY = "Luxury";
        private const string BUILD_COMFORTABLE = "Comfortable";
        private const string BUILD_AFFORDABLE = "Affordable";
        //Build the facility, based on what it is
        private bool BuildFacility(int row, int col, string type)
        {
            //check the id of the facility so it can check the cost accordingly
            if (type == BUILD_LUXURY)
            {
                //check if money is enough
                if (_variables.Money >= LuxuryHome.COST)
                {
                    //update the money by minus the cost from it
                    _variables.Money -= LuxuryHome.COST;
                    //build the new luxury home facility at target location
                    _variables.Facilities[row, col] = new LuxuryHome();

                    //successfully built a facility
                    return true;
                }
            }
            else if (type == BUILD_COMFORTABLE)
            {
                if (_variables.Money >= ComfortableHome.COST)
                {
                    _variables.Money -= ComfortableHome.COST;
                    _variables.Facilities[row, col] = new ComfortableHome();

                    return true;
                }
            }
            else if (type == BUILD_AFFORDABLE)
            {
                if (_variables.Money >= AffordableHome.COST)
                {
                    _variables.Money -= AffordableHome.COST;
                    _variables.Facilities[row, col] = new AffordableHome();

                    return true;
                }
            }
            //didn't have enough money or invalid land type
            return false;
        }

        /// <summary>
        /// Calculate the amount of money, for updating the player's money at the end of each month
        /// </summary>
        /// <returns>Money for the planet at the end of each month</returns>
        public long CalculateMoney()
        {
            //stores the net for this month, either positive or negative
            int netRevenue = 0, netMaintenance = 0;
            //loop through the facilities array
            for (int i = 0; i < _variables.NumRows; i++)
            {
                for (int j = 0; j < _variables.NumCols; j++)
                {
                    //count all the maintenance cost
                    netMaintenance += _variables.Facilities[i, j].Maintenance;
                    //count all the revenue income
                    netRevenue += _variables.Facilities[i, j].Revenue;
                }
            }
            //if power is out, player doesn't get revenue
            if (CalculatePower() < 0)
                return _variables.Money - netMaintenance;
            //otherwise, they do
            return _variables.Money + netRevenue - netMaintenance;
        }

        /// <summary>
        /// Calculate the net power consumption of the planet
        /// </summary>
        /// <returns>Net power consumption of the planet</returns>
        public int CalculatePower()
        {
            //stores the net power consumption
            int netPower = 0;
            //loop through the facilities array
            for (int i = 0; i < _variables.NumRows; i++)
            {
                for (int j = 0; j < _variables.NumCols; j++)
                {
                    //add all the power
                    netPower += _variables.Facilities[i, j].Power;
                }
            }
            //return the net power
            return netPower;
        }

        /// <summary>
        /// Update the population for all residential facilities, should be called at the end of the month
        /// </summary>
        private void UpdateAllPopulation()
        {
            for(int i=0; i<_variables.NumRows; i++)
                for(int j=0; j<_variables.NumCols; j++)
                    if(_variables.Facilities[i, j] is ResidentialFacility)
                        ((ResidentialFacility)_variables.Facilities[i, j]).UpdatePopulation();
        }
        /// <summary>
        /// Called end of each month to update the data
        /// </summary>
        public void UpdateTime()
        {
            //update the money
            _variables.Money = CalculateMoney();
            //update the population
            UpdateAllPopulation();
        }

        /// <summary>
        /// Saves the game
        /// </summary>
        public bool Save()
        {
            //Prevent file access errors, in case someone is currently editing the file
            try
            {
                //use current time as filename
                string filePath = DateTime.Now.ToString("yyyy-MM-dd") + "_" + DateTime.Now.ToString("hh.mm.ss") + ".txt";
                //use the streamwriter to output info to file
                using (StreamWriter sr = new StreamWriter(filePath))
                {
                    //save the size of the map
                    sr.WriteLine("[SIZE]");
                    sr.WriteLine(_variables.NumRows);
                    //save the score
                    _wrapper.SaveScore(filePath);
                    //save the money
                    sr.WriteLine("[MONEY]");
                    sr.WriteLine(_variables.Money);
                    //save each facility's relevant information
                    sr.WriteLine("[LOCATIONS]");
                    //loop through the facilities array
                    for (int i = 0; i < _variables.NumRows; i++)
                        for (int j = 0; j < _variables.NumCols; j++)
                        {
                            //save the facility type
                            if (_variables.Facilities[i, j] is EmergencyServices)
                                sr.Write(SharedVariables.EMERGENCY_SERVICES);
                            else if (_variables.Facilities[i, j] is School)
                                sr.Write(SharedVariables.SCHOOL);
                            else if (_variables.Facilities[i, j] is MedicalFacility)
                                sr.Write(SharedVariables.MEDICAL);
                            else if (_variables.Facilities[i, j] is GovernmentFacility)
                                sr.Write(SharedVariables.GOVERNMENT);
                            else if (_variables.Facilities[i, j] is Powerplant)
                                sr.Write(SharedVariables.POWER_PLANT);
                            else if (_variables.Facilities[i, j] is LuxuryHome)
                                sr.Write(SharedVariables.LUXURY_HOME);
                            else if (_variables.Facilities[i, j] is ComfortableHome)
                                sr.Write(SharedVariables.COMFORTABLE_HOME);
                            else if (_variables.Facilities[i, j] is AffordableHome)
                                sr.Write(SharedVariables.AFFORDABLE_HOME);
                            else if (_variables.Facilities[i, j] is Factory)
                                sr.Write(SharedVariables.FACTORY);
                            else if (_variables.Facilities[i, j] is EnvironmentalFacility)
                                sr.Write(SharedVariables.ENVIRONMENTAL_FACILITY);
                            else if (_variables.Facilities[i, j] is Store)
                                sr.Write(SharedVariables.STORE);
                            else if (_variables.Facilities[i, j] is Restaurant)
                                sr.Write(SharedVariables.RESTAURANT);
                            else if (_variables.Facilities[i, j] is Office)
                                sr.Write(SharedVariables.OFFICE);
                            sr.Write(":");
                            //save the facility location
                            sr.Write(i + ":" + j);
                            //save the population if it's a residential facility
                            if (_variables.Facilities[i, j] is ResidentialFacility)
                            {
                                sr.Write(":" + ((ResidentialFacility)(_variables.Facilities[i, j])).Population);
                            }
                            //otherwise save population as 0
                            else
                                sr.Write(":0");
                            //make a new line
                            sr.WriteLine();
                        }
                    //end of the file
                    sr.WriteLine("[END]");
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
