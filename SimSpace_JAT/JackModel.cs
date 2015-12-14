// Written by: Jack Wen | Team Members: Andrew, Tianli
// Date: December 11, 2015
// This is the class where Jack's subprograms are created, which are called by the model wrapper after the form(s) call the model wrapper
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Windows.Forms;

namespace SimSpace_JAT
{
    class JackModel
    {
        // Link to the other programmer's methods 
        PlanetModelWrapper _wrapper;

        // Links to the variables all programmer's share within sharedvariables
        SharedVariables _variables;

        // Parameters are required to link
        public JackModel(PlanetModelWrapper wrapper, SharedVariables variables)
        {
            _wrapper = wrapper;
            _variables = variables;
        }

        // Constant strings used in order to build the "essential services" lands
        private const string BUILD_EMERGENCYSERVICES = "Emergency Services";
        private const string BUILD_SCHOOL = "School";
        private const string BUILD_MEDICALFACILITY = "Medical Facility";
        private const string BUILD_GOVERNMENTFACILITY = "Government Facility";
        private const string BUILD_POWERPLANT = "Powerplant";

        // Constant strings used in order to build the "industrial facility" lands
        private const string BUILD_FACTORY = "Factory";
        private const string BUILD_ENVIRONMENTALFACILITY = "Environmental Facility";

        // Sets highscore as an int variable 
        int highestScore;
        int preHighscore;

        // A boolean used to build the Emergency Services using the rows and columns of the grid
        public bool BuildEmergencyServices(int row, int col)
        {
            return BuildFacility(row, col, BUILD_EMERGENCYSERVICES);
        }

        // A boolean used to build the School using the rows and columns of the grid
        public bool BuildSchool(int row, int col)
        {
            return BuildFacility(row, col, BUILD_SCHOOL);
        }

        // A boolean used to build the Medical Facility (Hospital) using the rows and columns of the grid
        public bool BuildMedicalFacility(int row, int col)
        {
            return BuildFacility(row, col, BUILD_MEDICALFACILITY);
        }

        // A boolean used to build the Government Facility using the rows and columns of the grid
        public bool BuildGovernmentFacility(int row, int col)
        {
            return BuildFacility(row, col, BUILD_GOVERNMENTFACILITY);
        }

        // A boolean used to build the Powerplant using the rows and columns of the grid
        public bool BuildPowerPlant(int row, int col)
        {
            return BuildFacility(row, col, BUILD_POWERPLANT);
        }

        // A boolean used to build the Factory using the rows and columns of the grid
        public bool BuildFactory(int row, int col)
        {
            return BuildFacility(row, col, BUILD_FACTORY);
        }

        // A boolean used to build the Environmental Facility using the rows and columns of the grid
        public bool BuildEnvironmentalFacility(int row, int col)
        {
            return BuildFacility(row, col, BUILD_ENVIRONMENTALFACILITY);
        }

        /// <summary>
        /// Checks what the building the user wishes to create is,
        /// checks the cost and depending on whether or not the user has the required amount of money,
        /// build the facility or do not do anything
        /// </summary>
        /// <param name="row">The row of the grid</param>
        /// <param name="col">The column of the grid</param>
        /// <param name="type">The specific building the user wishes to build</param>
        /// <returns>Returns what action was used (building built or not)</returns>
        private bool BuildFacility(int row, int col, string type)
        {
            // Checks if the type of the building is a Emergency Services Facility
            if (type == BUILD_EMERGENCYSERVICES)
            {
                // Checks if the user's money is greater than the cost of Emergency Services
                if (_variables.Money >= EmergencyServices.COST)
                {
                    // Subtract the amount of money the user has with the cost of the Emergency Services
                    _variables.Money -= EmergencyServices.COST;

                    // Build Emergency Services at the desired grid space
                    _variables.Facilities[row, col] = new EmergencyServices();

                    // Exits the function because it was built
                    return true;
                }
            }

                // Checks if the type of the building is a School
            else if (type == BUILD_SCHOOL)
            {
                // Checks if the user's money is greater than the cost of a School
                if (_variables.Money >= School.COST)
                {
                    // Find the difference between the user's current amount of money and the cost of the school
                    _variables.Money -= School.COST;

                    // Build a school at the desired grid space
                    _variables.Facilities[row, col] = new School();

                    // Exits the function because it was built
                    return true;
                }
            }

            // Checks if the type of the building is a Medical Facility
            else if (type == BUILD_MEDICALFACILITY)
            {
                // Checks if the user's money is greater than the cost of a Medical Facility
                if (_variables.Money >= MedicalFacility.COST)
                {
                    // Find the difference between the user's current amount of money and the cost of the Medical Facility
                    _variables.Money -= MedicalFacility.COST;

                    // Build a Medical Facility at the desired grid space
                    _variables.Facilities[row, col] = new MedicalFacility();

                    // Exits the function because it was built 
                    return true;
                }
            }

            // Checks if the type of the building is a Government Facility
            else if (type == BUILD_GOVERNMENTFACILITY)
            {
                // Checks if the user's money is greater than the cost of a Government Facility
                if (_variables.Money >= GovernmentFacility.COST)
                {
                    // Find the difference between the user's current amount of money and the cost of the Government Facility
                    _variables.Money -= GovernmentFacility.COST;

                    // Build a Government Facility at the desired grid space
                    _variables.Facilities[row, col] = new GovernmentFacility();

                    // Exits the function because it was built 
                    return true;
                }
            }
            // Checks if the type of the building is a Powerplant
            else if (type == BUILD_POWERPLANT)
            {
                // Checks if the user's money is greater than the cost of a Powerplant
                if (_variables.Money >= Powerplant.COST)
                {
                    // Find the difference between the user's current amount of money and the cost of the Powerplant
                    _variables.Money -= Powerplant.COST;

                    // Build a Powerplant at the desired grid space
                    _variables.Facilities[row, col] = new Powerplant();

                    // Exits the function because it was built
                    return true;
                }
            }
            // Checks if the type of the building is a Factory
            else if (type == BUILD_FACTORY)
            {
                // Checks if the user's money is greater than the cost of a Factory
                if (_variables.Money >= Factory.COST)
                {
                    // Find the difference between the user's current amount of money and the cost of the Factory
                    _variables.Money -= Factory.COST;

                    // Build a Factory at the desired grid space
                    _variables.Facilities[row, col] = new Factory();

                    // Exits the function because it was built
                    return true;
                }
            }
            // Checks if the type of the building is an Environmental Facility
            else if (type == BUILD_ENVIRONMENTALFACILITY)
            {
                // Checks if the user's money is greater than the cost of an Environmental Facility
                if (_variables.Money >= EnvironmentalFacility.COST)
                {
                    // Find the difference between the user's current amount of money and the cost of the Environmental Facility
                    _variables.Money -= EnvironmentalFacility.COST;

                    // Build an Environmental Facility at the desired grid space
                    _variables.Facilities[row, col] = new EnvironmentalFacility();

                    // Exits the function because it was built
                    return true;
                }
            }
            // Exits the function because nothing could be built
            return false;
        }

        // Calculates the total pollution of the planet
        public int CalculatePollution()
        {
            // Sets totalPollution as a uint variable
            int totalPollution = 0;

            // Loop through the rows of the grid
            for (int i = 0; i < _variables.NumRows; i++)
            {
                // Loop through the columns of the grid
                for (int j = 0; j < _variables.NumCols; j++)
                {
                    // Add up the total pollution from all the facilties on the planet and add it all up
                    totalPollution += _variables.Facilities[i, j].Pollution;
                }
            }
            // If totalPollution is less than 0
            if (totalPollution > 0)
                // Return the totalPollution as 0
                return 0;
            // Returns the totalPollution when the loop is finished
            return totalPollution;
        }

        // Calculates the total Score of the planet
        public int CalculateScore()
        {
            // Sets contentedPopulation as an integer and finds it by subtracting the happypopulation from the population of the planet
            int contentedPopulation = _wrapper.CalculatePopulation() - _wrapper.CalculateHappyPopulation();

            // Returns the Score by using the given formula of multiplying the happy population by 3, adding it onto contentedpopulation and then subtracting pollution from it 
            return 3 * _wrapper.CalculateHappyPopulation() + contentedPopulation - _wrapper.CalculatePollution();
        }

        // A method used to save the highscore
        public void SaveHighScore()
        {
            // Checks if the file exists
            if (File.Exists("Highscore.txt"))
            {
                // Read the file using Streamreader
                using (StreamReader sr = new StreamReader("Highscore.txt"))
                {
                    // Reads the file and saves it as the highestscore variable
                    int.TryParse(sr.ReadLine(), out highestScore);
                    // Checks if the current score is greater than the highest score
                    if (_variables.Score > highestScore)
                    {
                        // Creates a file named Highscore.txt if the file is not found
                        using (StreamWriter sw = new StreamWriter("Highscore.txt"))
                        {
                            // Writes down the highscore of the player
                            sw.WriteLine(_variables.Score);
                        }
                    }
                }
            }
            else
            {
                // Creates a file named Highscore.txt if the file is not found
                using (StreamWriter sw = new StreamWriter("Highscore.txt"))
                {
                    // Writes down the highscore of the player
                    sw.WriteLine(_variables.Score);
                }
            }
        }

        // A method used to load the highscore
        public void LoadHighScore()
        {
            // Handles any errors that may occur
            try
            {
                // Checks if the file "Highscore" exists or not
                if (File.Exists("Highscore.txt") == true)
                {
                    // If the file exists, read the file using StreamReader
                    using (StreamReader file = new StreamReader("Highscore.txt"))
                    {
                        // Set the text within the file as the Highscore variable
                        preHighscore = int.Parse(file.ReadToEnd());

                        // Checks if current score is greater than previous highscore
                        if (_variables.Score > preHighscore)
                        {
                            // Sets highest score variable as current score variable if it is greater
                            highestScore = _variables.Score;
                        }
                        // If current score is less than previous highscore
                        else
                        {
                            // Set the highestscore as the previous highscore
                            highestScore = preHighscore;
                        }

                    }
                }
                // If the file does not, display a messagebox
                else
                {
                    // Have a messagebox that displays "File could not be found" appear
                    MessageBox.Show("File could not be found.");
                }
            }
            // Ends try with catch
            catch
            {

            }
        }
    }
}

