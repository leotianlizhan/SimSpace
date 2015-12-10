// Written by Andrew Pang | Group members: Tianli, Jack
// Date: Sunday, December 6, 2015
// ICS4U Assignment 2 (SimSpace)
// This is the class where Andrew's subprograms are created, which are called by the model wrapper after the form(s) call the model wrapper
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace SimSpace_JAT
{
    class AndrewModel
    {
        // Create a new shared variables object
        SharedVariables _variables;
        // Create a new planet wrapper object
        PlanetModelWrapper _planetWrapper;

        // Create the string variable to store the file path for the log file
        // The name of the file is composed of the date followed by the local time at which the program was started
        // For example, the file could be named: 2015-12-03_09.49.28.log
        private string _filepath = DateTime.Now.ToString("yyyy-MM-dd") + "_" + DateTime.Now.ToString("hh.mm.ss") + ".log";

        // Create a boolean variable to store the state of the debug logger
        private bool _hasLoggingStarted = false;

        // Set private constant strings to the various types of debug messages for use as prefixes in the logger
        private const string _PREFIX_INFO = "INFO";
        private const string _PREFIX_WARNING = "WARNING";
        private const string _PREFIX_ERROR = "ERROR";

        // Create a regex pattern to use to check for the saved game's map size section
        private const string _patMapSize = @"^\[SIZE\]$\n^([0-9]*)$";
        // Create a regex pattern to use to check for the saved game's score
        private const string _patScore = @"^\[SCORE\]$\n^([0-9]*)$";
        // Create a regex pattern to use to check for the saved game's money
        private const string _patMoney = @"^\[MONEY\]$\n^([0-9]*)$";
        // Create a regex pattern to use to check for the saved game's facilities
        private const string _patFacilities = @"";

        // Create the constructor for AndrewModel
        public AndrewModel(PlanetModelWrapper planetWrapper, SharedVariables variables)
        {
            // Link the shared variables and planet wrapper to this class
            _variables = variables;
            _planetWrapper = planetWrapper;
        }

        // Create a private string to store the type of debug log message that was logged
        private string _debugType;

        /// <summary>
        /// Check if a commercial facility can be built at the row and column passed in.
        /// </summary>
        /// <returns>Returns true if it can be built, and false if it can't be built.</returns>
        public bool CanBuildCommercial(int row, int col)
        {            
            // Loop through the rows in the two dimensional array
            for (int i = 0; i < _variables.NumRows; i++)
            {
                // Loop through the columns in the two dimensional array
                for (int j = 0; j < _variables.NumCols; j++)
                {
                    // Create an integer variable to store the range limit of a commercial facility, in regards to where it can be built relative to a necessary facility
                    int rangeLimit = ResidentialFacility.RANGE_LIMIT;
                    // Create an integer variable to store the square of the hypotenuse
                    int hypotenuseSquared = (i-row)*(i-col) + (j-row)*(j-col);
                    // Create an integer variable tp store the square of the range limit
                    int rangeLimitSquared = rangeLimit * rangeLimit;
                    // Check to see if the square of the hypotenuse is equal to the square of the range limit, since apparently programming languages don't like comparing decimal values
                    if (hypotenuseSquared <= rangeLimitSquared)
                    {
                        if(_variables.Facilities[i, j] is ResidentialFacility)
                        // Return true to confirm that the location can have a commercial facility, thereby exiting the function
                            return true;
                    }                    
                }
            }

            return false;            
        }

        /// <summary>
        /// Attempt to build a store at the row and column specified.
        /// </summary>
        /// <param name="row">The row of the construction site.</param>
        /// <param name="col">The column of the construction site.</param>
        /// <returns>Returns true if it was successfully built, and false if it could not (if there is already a facility there).</returns>
        public bool BuildStore(int row, int col)
        {
            // Check if the construction site (row and col) that is passed in is dirt, even though another team member's subprogram that calls this already does it (yay, redundancy)
            if (_variables.Facilities[row, col] is Dirt)
            {
                // Set facility type to store
                _variables.Facilities[row, col] = new Store();
                // Exit the function because the store was built successfully
                return true;
            }
            else // if the facility type at the row and column given is not dirt
            {
                // Report to log that a store was somehow attempted to be built on another facility (i.e. not dirt), but was prevented from doing so
                Logger("Prevented something trying to build a store on top of a " + _variables.Facilities[row, col].ToString() + "- cell should be empty (Dirt).", 1);
                // Exit the function because the store could not be built
                return false;
            }
        }

        /// <summary>
        /// Attempt to build a restaurant at the row and column specified.
        /// </summary>
        /// <param name="row">The row of the construction site.</param>
        /// <param name="col">The column of the construction site.</param>
        /// <returns>Returns true if it was successfully built, and false if it could not (if there is already a facility there).</returns>
        public bool BuildRestaurant(int row, int col)
        {
            // Check if the construction site (row and col) that is passed in is dirt, even though another team member's subprogram that calls this already does it (yay, redundancy)
            if (_variables.Facilities[row, col] is Dirt)
            {
                // Set facility type to restaurant
                _variables.Facilities[row, col] = new Restaurant();
                // Exit the function because the restaurant was built successfully
                return true;
            }
            else // if the facility type at the row and column given is not dirt
            {
                // Report to log that a restaurant was somehow attempted to be built on another facility (i.e. not dirt), but was prevented from doing so
                Logger("Prevented something trying to build a restaurant on top of a " + _variables.Facilities[row, col].ToString() + "- cell should be empty (Dirt).", 1);
                // Exit the function because the restaurant could not be built
                return false;
            }            
        }

        /// <summary>
        /// Attempt to build an office at the row and column specified.
        /// </summary>
        /// <param name="row">The row of the construction site.</param>
        /// <param name="col">The column of the construction site.</param>
        /// <returns></returns>
        public bool BuildOffice(int row, int col)
        {
            // Check if the construction site (row and col) that is passed in is dirt, even though another team member's subprogram that calls this already does it (yay, redundancy)
            if (_variables.Facilities[row, col] is Dirt)
            {
                // Set facility type to office
                _variables.Facilities[row, col] = new Office();
                // Exit the function because the office was built successfully
                return true;
            }
            else // if the facility type at the row and column given is not dirt
            {
                // Report to log that an office was somehow attempted to be built on another facility (i.e. not dirt), but was prevented from doing so
                Logger("Prevented something trying to build an office on top of a " + _variables.Facilities[row, col].ToString() + "- cell should be empty (Dirt).", 1);
                // Exit the function because the office could not be built
                return false;
            } 
        }

        /// <summary>
        /// Calculates the total happy population of all the residential facilities on the map.
        /// </summary>
        /// <returns>Returns the total happy population.</returns>
        public int CalculateHappyPopulation()
        {
            // Create a local integer variable to store the populcation as it is added on to for each iteration of the for loop
            int totalHappyPopulation = 0;
            // Loop through the two dimensional array containing the facilities, starting with the rows
            for (int i = 0; i < _variables.NumRows; i++)
            {
                // Loop through the columns
                for (int j = 0; j < _variables.NumCols; j++)
                {
                    // Check if the facility at i, j is a residential facility
                    if (_variables.Facilities[i, j] is ResidentialFacility)
                    {
                        // Add the amount of happy people in the residential home to the total amount of happy people 
                        totalHappyPopulation += ((ResidentialFacility)_variables.Facilities[i, j]).GetHappyPopulation();
                    }                    
                }
            }
            // Report to log the total population that was calculated
            Logger("A total happy population of all the existing populations in facilities was calculated to be " + totalHappyPopulation.ToString() + " people.", 0);
            // Return the total happy population
            return totalHappyPopulation;
        }

        /// <summary>
        /// Calculates the population of all the residential facilities on the map.
        /// </summary>
        /// <returns>Returns the total population.</returns>
        public int CalculatePopulation()
        {
            // Create a local integer variable to store the population as it is added on to for each iteration of the for loop
            int population = 0;
            // Loop through the two dimensional array containing the facilities, starting with the rows
            for (int i = 0; i < _variables.NumRows; i++)
            {
                // Loop through the columns
                for (int j = 0; j < _variables.NumCols; j++)
                {
                    // Check if the facility at i, j is a residential facility type
                    if (_variables.Facilities[i, j] is ResidentialFacility)
                    {
                        // Add the population of the current facility being checked to the local variable, to be returned upon completion
                        population += ((ResidentialFacility)_variables.Facilities[i, j]).Population;
                    }
                }
            }
            // Report to log the total population that was calculated
            Logger("A total population of all the existing populations in facilities was calculated to be " + population.ToString() + " people.", 0);
            // Return the population of all of the facilities
            return population;
        }

        /// <summary>
        /// Attempts an asteroid strike.
        /// </summary>
        /// <returns>If the asteroid is determined to strike, then return true- otherwise false.</returns>
        public bool AttemptAsteroidStrike()
        {
            // Generate a random number between 0 and 10000, constituting a 0.01% chance, and store it
            int impactChance = SharedVariables.NumberGenerator.Next(0, 10000);
            // Check if the impact chance value that was generated equals 0 (a number that equates to 0.01%)
            if (impactChance == 0)
            {
                // Log debug information: value of the number generated and that the impact happened
                Logger("Asteroid impact occurred- procedure generated a value of " + impactChance.ToString() + " (value should be 0)", 0);
                // Return true to indicate that the asteroid should hit.
                return true;
            }
            else // if the number generated was not 0
            {
                // Log debug information: value of the number generated and that the impact did not happen
                Logger("Asteroid impact did not occur- procedure generated a value of " + impactChance.ToString() + " (value should not be 0)", 0);
                // then the asteroid does not impact the planet
                return false;
            }
        }

        /// <summary>
        /// Log debug information passed in to a line in the latest log file, with proper prefixing.
        /// </summary>
        /// <param name="line">The line to write to log file.</param>
        /// <param name="type">The type of debug message: 0 = INFO, 1 = WARNING, 2 = ERROR</param>
        public void Logger(string line, int type)
        {
            // Check if the type of debug message parameter is 0
            if (type == 0)
            {
                // Set the debug type to the INFO tag
                _debugType = _PREFIX_INFO;
            }
            else if (type == 1) // Check if the type of debug message parameter is 1
            {
                // Set the debug type to the WARNING tag
                _debugType = _PREFIX_WARNING;
            }
            else if (type == 2) // Check if the type of debug message parameter is 2
            {
                // Set the debug type to the ERROR tag
                _debugType = _PREFIX_ERROR;
            }
            else // If the type parameter passed in does not match any existing IDs
            {
                // Set the debug type to UNRECOGNIZED
                _debugType = "UNRECOGNIZED DEBUG LEVEL/TYPE";
            }

            // Create a new streamwriter object to write the log to
            using (StreamWriter sw = new StreamWriter(_filepath, true))
            {
                // Check if logging has been started before
                if (_hasLoggingStarted == true)
                {
                    // Write the log message to the log file with the proper time formatting
                    sw.WriteLine("[" + DateTime.Now.ToString("hh:mm:ss") + "] " + line);
                }
                else // if logging has not started before now
                {
                    //// Start off the log file with the log file header and disclaimer
                    //sw.WriteLine("|" + DateTime.Now.ToString("hh:mm:ss") + "| [INFO] Logging initialized!");
                    //sw.WriteLine("|" + DateTime.Now.ToString("hh:mm:ss") + "| [INFO] Current date: " + DateTime.Now.ToString("yyyy-MM-dd"));
                    //sw.WriteLine("|" + DateTime.Now.ToString("hh:mm:ss") + "| [INFO] This is the log file for Andrew, Tianli, and Jack's Assignment 2 for ICS4U 2015 Semester 1.");
                    //sw.WriteLine("|" + DateTime.Now.ToString("hh:mm:ss") + "| [INFO] Since nobody except for Andrew sees the importance logging debug information is, Andrew will likely be the only person to ever need to open one of these.");
                    //sw.WriteLine("|" + DateTime.Now.ToString("hh:mm:ss") + "| [INFO] Blame everyone else if something breaks and you can't find it in these log files :D");

                    // Write the log message to the log file with the proper time formatting
                    sw.WriteLine("|{0}| [{1}] {2}" + line, DateTime.Now.ToString("hh:mm:ss"), _debugType, line);
                }
            }
        }

        /// <summary>
        /// Load a saved copy of the game from a local save file.
        /// </summary>
        /// <param name="filePath">The path to the game save file.</param>
        /// <returns>If the game save was entirely loaded, then return true- otherwise false.</returns>
        public bool Load(string filePath)
        {
            try
            {
                // Create a string variable to store the current line being checked
                string line;
                // Create an integer variable to store the map size as an integer
                int mapSize;
                // Create an integer variable to store the score as an integer
                int score;
                // Create a long variable to store the money 
                long money;
                Regex re = new Regex(@"^(\d+):(\d+):(\d+):(\d+)$");
                // Create a new int array to store the facility ID and its metadata for one line
                int[] facilityValues = new int[4];

                // Check if the file exists at the specified location, as passed in via the parameter
                if (File.Exists(filePath))
                {
                    // read file
                    // Log debug information: file was found at path specified.
                    Logger("Found game save file at file path: " + filePath + ".", 0);
                    // Create a new streamreader object to read the game save file at the specified file path
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        // Get and store the line
                        line = sr.ReadLine();
                        // Check if the line matches the section header for the map size
                        if (line == "[SIZE]")
                        {
                            // Get and store the next line
                            line = sr.ReadLine();
                            // Use regex to check if the line below the SIZE header contains a digit repeated greater than zero times, from start to end
                            if (Regex.IsMatch(line, @"^(\d+)$"))
                            {
                                // Convert the current input line to an integer
                                int.TryParse(line, out mapSize);

                                // TODO: DO SOMETHING WITH THE RETRIEVED MAP SIZE
                                // Not done anymore, Tianli will handle it directly

                                // Report to the log file that the map size was successfully retrieved from the game save file
                                Logger("A map size of " + mapSize.ToString() + " was found in the game save file located at: " + filePath + ", but was not used (something else is handling it).", 0);
                            }
                            else // if the line below the SIZE header was not an integer
                            {
                                // Report to log file that the file did not store an integer value to denote map size
                                Logger("Game save file at: " + filePath + " did not store an integer value for the map size.", 2);
                                // Exit the procedure
                                return false;
                            }
                        }
                        else // if the section header for size was not found
                        {
                            // Report to debug file that the file did not start with the section header for map size
                            Logger("Game save file at: " + filePath + " did not start with the section header for map size.", 2);
                            // Exit the function
                            return false;
                        }

                        // Get and store the next line
                        line = sr.ReadLine();
                        // Check if the line matches the section header for the score
                        if (line == "[SCORE]")
                        {
                            // Get and store the next line
                            line = sr.ReadLine();
                            // Use regex to check if the line below the SCORE header contains a digit repeated greater than zero times, from start to end
                            if (Regex.IsMatch(line, @"^(\-?\d+)$"))
                            {
                                // Convert the current input line to an integer
                                int.TryParse(line, out score);

                                // Assign the value of the score from the saved game file to the ingame score counting variable
                                _variables.Score = score;

                                // Report to the log file that the score was successfully retrieved from the game save file
                                Logger("A saved game score of " + score.ToString() + " points was found in the game save file located at: " + filePath + ".", 0);
                            }
                            else // if the line below the SCORE header was not an integer
                            {
                                // Report to log file that the file did not store an integer value to denote score
                                Logger("Game save file at: " + filePath + " did not store an integer value for the score.", 2);
                                // Exit the procedure
                                return false;
                            }
                        }
                        else // if the section header for score was not found
                        {
                            // Report to debug file that the file did not start with the section header for score
                            Logger("Game save file at: " + filePath + " did not start with the section header for map score where expected.", 2);
                            // Exit the function
                            return false;
                        }

                        // Get and store the next line
                        line = sr.ReadLine();
                        // Check if the line matches the section header for the money
                        if (line == "[MONEY]")
                        {
                            // Get and store the next line
                            line = sr.ReadLine();
                            // Use regex to check if the line below the MONEY header contains a digit repeated greater than zero times, from start to end
                            if (Regex.IsMatch(line, @"^(\d+)$"))
                            {
                                // Convert the current input line to long
                                long.TryParse(line, out money);

                                // Assign the value of the money from the saved game file to the current balance
                                _variables.Money = money;

                                // Report to the log file that the balance was successfully retrieved from the game save file
                                Logger("A saved game balance of " + money.ToString() + " dollars was found in the game save file located at: " + filePath + ".", 0);
                            }
                            else // if the line below the MONEY header was not a number
                            {
                                // Report to log file that the file did not store an integer value to denote balance
                                Logger("Game save file at: " + filePath + " did not store an integer value for the money (balance).", 2);
                                // Exit the procedure
                                return false;
                            }
                        }
                        else // if the section header for money was not found
                        {
                            // Report to debug file that the file did not start with the section header for money
                            Logger("Game save file at: " + filePath + " did not start with the section header for money (balance) where expected.", 2);
                            // Exit the function
                            return false;
                        }

                        // Get and store the next line
                        line = sr.ReadLine();
                        // Check if the line matches the section header for facility locations
                        if (line == "[LOCATIONS]")
                        {
                            // Get and store the next line
                            line = sr.ReadLine();
                            // Loop if the cursor is not at the end of the file
                            while (line != "[END]")
                            {
                                // Use regex to check if the line below the LOCATIONS header contains only a set of 4 numbers, separated by 4 colons
                                if (Regex.IsMatch(line, @"^(\-?\d+)\:(\d+)\:(\d+)\:(\d+)$"))
                                {
                                    // Match the text from the input line to the regex pattern the regex object was instantiated with
                                    Match m = re.Match(line);
                                    // Loop through the 4 possible inputs that were separated by colons
                                    for (int j = 1; j <= 4; j++)
                                    {
                                        // Store the match found after each iteration
                                        Group g = m.Groups[j];
                                        // Convert the matching group to an element in the facility values array
                                        int.TryParse(g.ToString(), out facilityValues[j - 1]);
                                    }

                                    if (facilityValues[0] == -1) // check if the facility ID matches the ID for unused land (dirt)
                                    {
                                        // Set facility type to dirt
                                        _variables.Facilities[facilityValues[1], facilityValues[2]] = new Dirt();
                                        Logger("Saved facility ID value of " + facilityValues[0] + " at (" + facilityValues[1] + ", " + facilityValues[2] + ")", 0);
                                    }
                                    else if (facilityValues[0] == 0) // check if the facility ID matches the ID for emergency services
                                    {
                                        // Set facility type to emergency services
                                        _variables.Facilities[facilityValues[1], facilityValues[2]] = new EmergencyServices();
                                        Logger("Saved facility ID value of " + facilityValues[0] + " at (" + facilityValues[1] + ", " + facilityValues[2] + ")", 0);
                                    }
                                    else if (facilityValues[0] == 1) // check if the facility ID matches the ID for schools
                                    {
                                        // Set facility type to school
                                        _variables.Facilities[facilityValues[1], facilityValues[2]] = new School();
                                        Logger("Saved facility ID value of " + facilityValues[0] + " at (" + facilityValues[1] + ", " + facilityValues[2] + ")", 0);
                                    }
                                    else if (facilityValues[0] == 2) // check if the facility ID matches the ID for medical facilities
                                    {
                                        // Set facility type to medical
                                        _variables.Facilities[facilityValues[1], facilityValues[2]] = new MedicalFacility();
                                        Logger("Saved facility ID value of " + facilityValues[0] + " at (" + facilityValues[1] + ", " + facilityValues[2] + ")", 0);
                                    }
                                    else if (facilityValues[0] == 3) // check if the facility ID matches the ID for governments
                                    {
                                        // Set facility type to government
                                        _variables.Facilities[facilityValues[1], facilityValues[2]] = new GovernmentFacility();
                                        Logger("Saved facility ID value of " + facilityValues[0] + " at (" + facilityValues[1] + ", " + facilityValues[2] + ")", 0);
                                    }
                                    else if (facilityValues[0] == 4) // check if the facility ID matches the ID for power plants
                                    {
                                        // Set facility type to power plant
                                        _variables.Facilities[facilityValues[1], facilityValues[2]] = new Powerplant();
                                        Logger("Saved facility ID value of " + facilityValues[0] + " at (" + facilityValues[1] + ", " + facilityValues[2] + ")", 0);
                                    }
                                    else if (facilityValues[0] == 5) // check if the facility ID matches the ID for luxury homes
                                    {
                                        // Check if the population from the file is positive
                                        if (facilityValues[3] >= 0)
                                        {
                                            // Set facility type to luxury home and set the population to the input value from the file
                                            _variables.Facilities[facilityValues[1], facilityValues[2]] = new LuxuryHome(facilityValues[3]);
                                            // Report to log that the facility was loaded
                                            Logger("Facility with the ID of " + facilityValues[0].ToString() + ", grid and column value of (" + facilityValues[1].ToString() + "," + facilityValues[2].ToString() +
                                                ") and population of " + facilityValues[3].ToString() + " was successfully loaded from the file found at: " + filePath + ".", 0);
                                        }
                                        else // if the facility had a negative value for population
                                        {
                                            // Report to log that the population was negative
                                            Logger("Facility with the ID of " + facilityValues[0].ToString() + ", grid and column value of (" + facilityValues[1].ToString() + "," + facilityValues[2].ToString() +
                                                ") and population of " + facilityValues[3].ToString() + " could not be loaded from the file found at: " + filePath + " because population was negative (expected positive or 0).", 2);
                                            // Exit the function
                                            return false;
                                        }
                                    }
                                    else if (facilityValues[0] == 6) // check if the facility ID matches the ID for comfortable homes
                                    {
                                        // Check if the population from the file is positive
                                        if (facilityValues[3] >= 0)
                                        {
                                            // Set facility type to comfortable home and set the population to the input value from the file
                                            _variables.Facilities[facilityValues[1], facilityValues[2]] = new ComfortableHome(facilityValues[3]);
                                            // Report to log that the facility was loaded
                                            Logger("Facility with the ID of " + facilityValues[0].ToString() + ", grid and column value of (" + facilityValues[1].ToString() + "," + facilityValues[2].ToString() +
                                                ") and population of " + facilityValues[3].ToString() + " was successfully loaded from the file found at: " + filePath + ".", 0);
                                        }
                                        else // if the facility had a negative value for population
                                        {
                                            // Report to log that the population was negative
                                            Logger("Facility with the ID of " + facilityValues[0].ToString() + ", grid and column value of (" + facilityValues[1].ToString() + "," + facilityValues[2].ToString() +
                                                ") and population of " + facilityValues[3].ToString() + " could not be loaded from the file found at: " + filePath + " because population was negative (expected positive or 0).", 2);
                                            // Exit the function
                                            return false;
                                        }
                                    }
                                    else if (facilityValues[0] == 7) // check if the facility ID matches the ID for affordable homes
                                    {// Check if the population from the file is positive
                                        if (facilityValues[3] >= 0)
                                        {
                                            // Set facility type to affordable home and set the population to the input value from the file
                                            _variables.Facilities[facilityValues[1], facilityValues[2]] = new AffordableHome(facilityValues[3]);
                                            // Report to log that the facility was loaded
                                            Logger("Facility with the ID of " + facilityValues[0].ToString() + ", grid and column value of (" + facilityValues[1].ToString() + "," + facilityValues[2].ToString() +
                                                ") and population of " + facilityValues[3].ToString() + " was successfully loaded from the file found at: " + filePath + ".", 0);
                                        }
                                        else // if the facility had a negative value for population
                                        {
                                            // Report to log that the population was negative
                                            Logger("Facility with the ID of " + facilityValues[0].ToString() + ", grid and column value of (" + facilityValues[1].ToString() + "," + facilityValues[2].ToString() +
                                                ") and population of " + facilityValues[3].ToString() + " could not be loaded from the file found at: " + filePath + " because population was negative (expected positive or 0).", 2);
                                            // Exit the function
                                            return false;
                                        }
                                    }
                                    else if (facilityValues[0] == 8) // check if the facility ID matches the ID for factories
                                    {
                                        // Set facility type to factory
                                        _variables.Facilities[facilityValues[1], facilityValues[2]] = new Factory();
                                        Logger("Saved facility ID value of " + facilityValues[0] + " at (" + facilityValues[1] + ", " + facilityValues[2] + ")", 0);
                                    }
                                    else if (facilityValues[0] == 9) // check if the facility ID matches the ID for environmental facilities
                                    {
                                        // Set facility type to environmental facility
                                        _variables.Facilities[facilityValues[1], facilityValues[2]] = new EnvironmentalFacility();
                                        Logger("Saved facility ID value of " + facilityValues[0] + " at (" + facilityValues[1] + ", " + facilityValues[2] + ")", 0);
                                    }
                                    else if (facilityValues[0] == 10) // check if the facility ID matches the ID for stores
                                    {
                                        // Set facility type to store
                                        _variables.Facilities[facilityValues[1], facilityValues[2]] = new Store();
                                        Logger("Saved facility ID value of " + facilityValues[0] + " at (" + facilityValues[1] + ", " + facilityValues[2] + ")", 0);
                                    }
                                    else if (facilityValues[0] == 11) // check if the facility ID matches the ID for restaurants
                                    {
                                        // Set facility type to restaurant
                                        _variables.Facilities[facilityValues[1], facilityValues[2]] = new Restaurant();
                                        Logger("Saved facility ID value of " + facilityValues[0] + " at (" + facilityValues[1] + ", " + facilityValues[2] + ")", 0);
                                    }
                                    else if (facilityValues[0] == 12) // check if the facility ID matches the ID for offices
                                    {
                                        // Set facility type to office
                                        _variables.Facilities[facilityValues[1], facilityValues[2]] = new Office();
                                        Logger("Saved facility ID value of " + facilityValues[0] + " at (" + facilityValues[1] + ", " + facilityValues[2] + ")", 0);
                                    }
                                    else // If the facility ID did not match with one on record
                                    {
                                        // Report to log that the facility ID is invalid
                                        Logger("Found a facility ID value of " + facilityValues[0].ToString() + ", expected a value from -1 to 12 (line in question: " + line + ").", 2);
                                        // Exit the function
                                        return false;
                                    }
                                }
                                else // if the file format is not correct
                                {
                                    // Report to log that the file contained a line that does not match the standards for saving a facility
                                    Logger("Game save file at: " + filePath + " contained a facility information line with invalid format (" + line + ").", 2);
                                    // Exit the function
                                    return false;
                                }
                                line = sr.ReadLine();
                            }
                        }
                        else // if the section header for facility locations was not found
                        {
                            // Report to debug file that the file did not start with the section header for facility locations
                            Logger("Game save file at: " + filePath + " did not start with the section header for the locations (of facilities).", 2);
                            // Exit the function
                            return false;
                        }
                    }
                }
                else // if the file does not exist at the path specified
                {
                    // Log debug information: file was not found at path specified.
                    Logger("Game save file could not be found at file path: " + filePath + ". Make sure the name of the file is correct, and the saves directory has not been moved.", 2);
                    // Exit the function
                    return false;
                }

                // If the code path the code decided to take was free of all the hurdles and did not end up somewhere where it ended up returning false
                return true; // because this is the finish line- only took 320 lines
            }
            catch (Exception e)
            {
                // Just in case there is an unhandled exception
                Logger(e.ToString(), 2);
                // Exit the function because a fatal error occurred
                return false;
            }
        }
    }
}
