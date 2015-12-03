// Tianli Zhan
// December 2, 2015
// My model that contains my share of the subprograms for this program
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimSpace_JAT
{
    class TianliModel
    {
        /// <summary>
        /// Links to the other programmers' methods
        /// </summary>
        PlanetModelWrapper _wrapper;

        /// <summary>
        /// Links to the variable all programmers share
        /// </summary>
        SharedVariables _variables;

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
            //boolean variables to store if such a facility is found within the range
            bool hasEmergencyServices = false, hasSchool = false, hasMedical = false, hasGovernment = false, hasPowerPlant = false;
            //stores the current row and column being checked
            int curRow, curCol;
            //stores all the possible combinations of row and col for a range around a location
            List<Tuple<int, int>> combinations = new List<Tuple<int, int>>();
            //fill in the list of combinations
            for (int i = 1; i <= ResidentialFacility.RANGE_LIMIT; i++)
            {
                //fill in the combinations list with grid blocks straight away from the location
                combinations.Add(Tuple.Create(0,i));
                combinations.Add(Tuple.Create(0,-1*i));
                combinations.Add(Tuple.Create(i,0));
                combinations.Add(Tuple.Create(-1*i,0));
                //fill in the combination list with rest of the gridblock locations within the range limit
                for(int j = 1; j <= ResidentialFacility.RANGE_LIMIT - i; j++)
                {
                    combinations.Add(Tuple.Create(i,j));
                    combinations.Add(Tuple.Create(i,-1*j));
                    combinations.Add(Tuple.Create(-1*i,j));
                    combinations.Add(Tuple.Create(-1*i,-1*j));
                }
            }
            //loop through the possible combinations
            for (int i = 0; i < combinations.Count; i++)
            {
                //assign current row and col variables with the possible combinations
                curRow = row + combinations[i].Item1;
                curCol = col + combinations[i].Item2;
                //check if the to-be-checked-location is out of bound, then check if it's an EssentialServiceFacility
                if (curRow >= 0 && curRow < _wrapper.NumRows && curCol >= 0 && curCol < _wrapper.NumCols && _variables.Facilities[curRow, curCol] is EssentialServicesFacility)
                {
                    //check what kind of facility it is, and flag the corresponding "has" variables with true
                    if (_variables.Facilities[curRow, curCol] is EmergencyServices)
                        hasEmergencyServices = true;
                    else if (_variables.Facilities[curRow, curCol] is School)
                        hasSchool = true;
                    else if (_variables.Facilities[curRow, curCol] is MedicalFacility)
                        hasMedical = true;
                    else if (_variables.Facilities[curRow, curCol] is GovernmentFacility)
                        hasGovernment = true;
                    else
                        hasPowerPlant = true;
                }
            }
            //if all the facilities are found within range, the residential facility can be built here
            if (hasEmergencyServices && hasSchool && hasMedical && hasGovernment && hasPowerPlant)
                return true;
            //otherwise it cannot
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
            for (int i = 0; i < _wrapper.NumRows; i++)
            {
                for (int j = 0; j < _wrapper.NumCols; j++)
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
            for (int i = 0; i < _wrapper.NumRows; i++)
            {
                for (int j = 0; j < _wrapper.NumCols; j++)
                {
                    //add all the power
                    netPower += _variables.Facilities[i, j].Power;
                }
            }
            //return the net power
            return netPower;
        }

        public void UpdateTime()
        {
            _variables.Money = CalculateMoney();
        }
    }
}
