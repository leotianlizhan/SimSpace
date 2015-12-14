//Tianli Zhan
//December 12, 2015
//Form for a 30x30 grid game
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimSpace_JAT
{
    public partial class PlanetTianliForm : Form
    {
        /// <summary>
        /// Link to wrapper with all the needed subprograms
        /// </summary>
        private PlanetModelWrapper _planet;
        /// <summary>
        /// size of the grid
        /// </summary>
        public const int GRID_SIZE = 30;
        /// <summary>
        /// size of each cell for grid
        /// </summary>
        private Size _gridCellSize;
        /// <summary>
        /// size of each cell for toolbar
        /// </summary>
        private Size _toolbarCellSize;
        /// <summary>
        /// Stores the needed graphical information for each cell, including image and the rectangle
        /// </summary>
        private struct Cell
        {
            //stores the image of the cell
            private Image _image;
            //stores the rectangle for the cell for later calculations
            private Rectangle _rect;
            // Create the image property
            public Image Image
            {
                get
                {
                    return _image;
                }
                set
                {
                    _image = value;
                }
            }
            public Rectangle Rect
            {
                get
                {
                    return _rect;
                }
                set
                {
                    _rect = value;
                }
            }
        }
        //array to store each cell for grid
        private Cell[,] _grid = new Cell[GRID_SIZE, GRID_SIZE];
        //stores the fake game time, not entirely accurate, it won't be consistent when one loads a game. This is just an extra feature
        //we didn't want to spend a lot of time on saving DateTime
        private DateTime _gameTime;

        /********** TOOLBAR DATA *************/
        /// <summary>
        /// size of the toolbar
        /// </summary>
        private const int TOOLBAR_SIZE = 13;
        //array to store each cell for toolbar
        private Cell[] _toolbar = new Cell[TOOLBAR_SIZE];
        //index of the selected toolbar item
        private int _selectedToolbarItem = NOTHING;
        //selected toolbar item should be this if nothing is selected
        private const int NOTHING = -1;
        //grid to highlight
        private bool[,] _highlightedGrid = null;
        /********** TOOLBAR DATA *************/

        /********** FACILITY STAT PANEL DATA *************/
        //stores the location of the last clicked facility, so the stats display can properly update
        private Point _lastClickedFacility = _noFacilityClicked;
        //stores the value that represent when no facility is clicked to view stats
        private static Point _noFacilityClicked = new Point(-1, -1);
        /********** FACILITY STAT PANEL DATA *************/

        // Create an long variable to store the player's money for the current month (by Andrew)
        long currentMoney = 0;

        /// <summary>
        /// Constructs the 30x30 form
        /// </summary>
        public PlanetTianliForm()
        {
            InitializeComponent();
            //create a new planet
            _planet = new PlanetModelWrapper(GRID_SIZE, GRID_SIZE);
            //set the cell sizes based on screen size
            _toolbarCellSize = new Size(Screen.FromControl(this).Bounds.Height*9 / (10*13), Screen.FromControl(this).Bounds.Height*9 / (10*13));
            _gridCellSize = new Size(Screen.FromControl(this).Bounds.Height*9 / (10*GRID_SIZE), Screen.FromControl(this).Bounds.Height*9 / (10*GRID_SIZE));
            //create the grid (WITHOUT LOADED DATA)
            CreateGrid(GRID_SIZE, GRID_SIZE);
            //create the toolbar
            CreateToolbar();
            //initializes the side options
            InitSideOptions();
            //start the timer
            tmrTimer.Start();
            //set the fake game time to now
            _gameTime = DateTime.Now;
            //update the scoreboard
            UpdateScoreBoard();
        }

        /// <summary>
        /// Constructs the 30x30 form with a loaded game
        /// </summary>
        /// <param name="filePath">Path of the saved game file</param>
        public PlanetTianliForm(string filePath)
            : this()
        {
            //load all the data
            _planet.Load(filePath);
            //create the grid with the data after loaded
            CreateGrid(GRID_SIZE, GRID_SIZE);
            //update scoreboard data
            UpdateScoreBoard();
        }

        // Tianli did Scoreboard, Andrew did FacilityStats
        /// <summary>
        /// Initializes the side options, including scoreboard and save button
        /// </summary>
        private void InitSideOptions()
        {
            int xLocation = _toolbarCellSize.Width + _gridCellSize.Width * GRID_SIZE + _toolbarCellSize.Width * 3 * 2 / 5;
            //change the side options' locations
            pnlScoreBoard.Location = new Point(xLocation, 5);
            btnSave.Location = new Point(xLocation + pnlScoreBoard.Width/2-btnSave.Width/2, pnlScoreBoard.Location.Y + pnlScoreBoard.Size.Height + _toolbarCellSize.Width * 2 / 5);
            //make them visible
            pnlScoreBoard.Visible = true;
            btnSave.Visible = true;
            //change the scoreboard's color
            pnlScoreBoard.BackColor = Color.FromArgb(160, Color.SkyBlue);
            //change the save button's color
            btnSave.BackColor = Color.FromArgb(160, Color.SkyBlue);
            // Align the location of the facility stats panel to its proper position below the save button
            pnlFacilityStats.Location = new Point(xLocation, btnSave.Location.Y + btnSave.Size.Height + _toolbarCellSize.Width * 2 / 5);
            //change the facilitystats's color
            pnlFacilityStats.BackColor = Color.FromArgb(160, Color.SkyBlue);
        }

        //Tianli
        /// <summary>
        /// Creates the grid
        /// </summary>
        /// <param name="rows">Number of rows for the grid</param>
        /// <param name="cols">Number of columns for the grid</param>
        private void CreateGrid(int rows, int cols)
        {
            //Loop through all the rows
            for (int i = 0; i < rows; i++)
            {
                //loop through all the columns
                for (int j = 0; j < cols; j++)
                {
                    //create each grid cell
                    _grid[i, j].Rect = new Rectangle(_toolbarCellSize.Width + _gridCellSize.Width * j + _toolbarCellSize.Width*2*2/5, _gridCellSize.Height * i, _gridCellSize.Width, _gridCellSize.Height);
                    //set each grid image accordingly, leave dirt to null
                    if (_planet.Facilities[i, j] is EmergencyServices)
                        _grid[i, j].Image = Properties.Resources.Emergency_Services;
                    else if (_planet.Facilities[i, j] is School)
                        _grid[i, j].Image = Properties.Resources.School;
                    else if (_planet.Facilities[i, j] is MedicalFacility)
                        _grid[i, j].Image = Properties.Resources.Medical;
                    else if (_planet.Facilities[i, j] is GovernmentFacility)
                        _grid[i, j].Image = Properties.Resources.Government;
                    else if (_planet.Facilities[i, j] is Powerplant)
                        _grid[i, j].Image = Properties.Resources.Power_Plant;
                    else if (_planet.Facilities[i, j] is LuxuryHome)
                        _grid[i, j].Image = Properties.Resources.Luxury_Home;
                    else if (_planet.Facilities[i, j] is ComfortableHome)
                        _grid[i, j].Image = Properties.Resources.Comfortable_Home;
                    else if (_planet.Facilities[i, j] is AffordableHome)
                        _grid[i, j].Image = Properties.Resources.Affordable_Home;
                    else if (_planet.Facilities[i, j] is Factory)
                        _grid[i, j].Image = Properties.Resources.Factory;
                    else if (_planet.Facilities[i, j] is EnvironmentalFacility)
                        _grid[i, j].Image = Properties.Resources.Environmental_Facility;
                    else if (_planet.Facilities[i, j] is Store)
                        _grid[i, j].Image = Properties.Resources.Store;
                    else if (_planet.Facilities[i, j] is Restaurant)
                        _grid[i, j].Image = Properties.Resources.Restaurant;
                    else if (_planet.Facilities[i, j] is Office)
                        _grid[i, j].Image = Properties.Resources.Office;
                }
            }
            Refresh();
        }

        //Tianli
        /// <summary>
        /// Initializes the toolbar with rectangle locations and images
        /// </summary>
        private void CreateToolbar()
        {
            //Loop through the toolbar cells
            for (int i = 0; i < TOOLBAR_SIZE; i++)
            {
                //create the rectangles
                _toolbar[i].Rect = new Rectangle(new Point(_toolbarCellSize.Width*2/5, _toolbarCellSize.Height * i), _toolbarCellSize);
            }
            //assign the images
            _toolbar[SharedVariables.EMERGENCY_SERVICES].Image = Properties.Resources.Emergency_Services;
            _toolbar[SharedVariables.SCHOOL].Image = Properties.Resources.School;
            _toolbar[SharedVariables.MEDICAL].Image = Properties.Resources.Medical;
            _toolbar[SharedVariables.GOVERNMENT].Image = Properties.Resources.Government;
            _toolbar[SharedVariables.POWER_PLANT].Image = Properties.Resources.Power_Plant;
            _toolbar[SharedVariables.LUXURY_HOME].Image = Properties.Resources.Luxury_Home;
            _toolbar[SharedVariables.COMFORTABLE_HOME].Image = Properties.Resources.Comfortable_Home;
            _toolbar[SharedVariables.AFFORDABLE_HOME].Image = Properties.Resources.Affordable_Home;
            _toolbar[SharedVariables.FACTORY].Image = Properties.Resources.Factory;
            _toolbar[SharedVariables.ENVIRONMENTAL_FACILITY].Image = Properties.Resources.Environmental_Facility;
            _toolbar[SharedVariables.STORE].Image = Properties.Resources.Store;
            _toolbar[SharedVariables.RESTAURANT].Image = Properties.Resources.Restaurant;
            _toolbar[SharedVariables.OFFICE].Image = Properties.Resources.Office;
        }

        //Tianli
        //override OnPaint, called everytime the form refreshes
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            DrawGrid(e);

            DrawToolbar(e);
        }

        //Tianli
        //Draws the grid
        private void DrawGrid(PaintEventArgs e)
        {
            // Only draw grid if it exists, prevents crashing
            if (_grid != null)
            {
                // Loop through each row in the grid
                for (int i = 0; i < _grid.GetLength(SharedVariables.ROW); i++)
                {
                    // Loop through each column in the grid
                    for (int j = 0; j < _grid.GetLength(SharedVariables.COL); j++)
                    {
                        //check if the grid needs to be highlighted
                        if (_highlightedGrid != null)
                        {
                            //if this cell is true, highlight it with translucent green
                            if (_highlightedGrid[i, j])
                                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.Lime)), _grid[i, j].Rect);
                            //otherwise highlight it with translucent red
                            else
                                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.IndianRed)), _grid[i, j].Rect);
                        }
                        //do not highlight it otherwise, and clear all colors
                        else
                            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(80, Color.SkyBlue)), _grid[i, j].Rect);
                        //Check if there is no image (means it's Dirt) to prevent crashing
                        if (_grid[i, j].Image != null)
                        {
                            e.Graphics.DrawImage(_grid[i, j].Image, _grid[i, j].Rect);
                        }
                        //draw the cell borders at last
                        e.Graphics.DrawRectangle(Pens.SteelBlue, _grid[i, j].Rect);
                    }
                }
            }
        }

        //Tianli
        //Draws the toolbar
        private void DrawToolbar(PaintEventArgs e)
        {
            //check if toolbar has not been created, prevents crashing
            if (_toolbar != null)
            {
                //loop through every toolbar cell
                for (int i = 0; i < TOOLBAR_SIZE; i++)
                {
                    //check if the cell has not been created, prevents crashing
                    if (_toolbar[i].Rect != null && _toolbar[i].Image != null)
                    {
                        //Draws the image
                        e.Graphics.DrawImage(_toolbar[i].Image, _toolbar[i].Rect);
                        //Draws the cell
                        e.Graphics.DrawRectangle(Pens.DeepSkyBlue, _toolbar[i].Rect);
                    }
                }
            }
        }

        //Tianli
        private void PlanetTianliForm_MouseDown(object sender, MouseEventArgs e)
        {
            //loop through the toolbar
            for (int i = 0; i < TOOLBAR_SIZE; i++)
                if (_toolbar[i].Rect.Contains(e.Location))
                {
                    //if the rectangle contains the mousedown location, that item is selected
                    _selectedToolbarItem = i;
                    //prepare a highlighted grid boolean array for DrawGrid
                    _highlightedGrid = _planet.CanBuildHighlightedGrid(_selectedToolbarItem);
                    //change the cursor based on the selected toolbar item
                    if (i == SharedVariables.EMERGENCY_SERVICES)
                        this.Cursor = new Cursor(Properties.Resources.Emergency_Cursor.Handle);
                    else if (i == SharedVariables.SCHOOL)
                        this.Cursor = new Cursor(Properties.Resources.School_Cursor.Handle);
                    else if (i == SharedVariables.MEDICAL)
                        this.Cursor = new Cursor(Properties.Resources.Medical_Cursor.Handle);
                    else if (i == SharedVariables.GOVERNMENT)
                        this.Cursor = new Cursor(Properties.Resources.Government_Cursor.Handle);
                    else if (i == SharedVariables.POWER_PLANT)
                        this.Cursor = new Cursor(Properties.Resources.Powerplant_Cursor.Handle);
                    else if (i == SharedVariables.LUXURY_HOME)
                        this.Cursor = new Cursor(Properties.Resources.Luxury_Home_Cursor.Handle);
                    else if (i == SharedVariables.COMFORTABLE_HOME)
                        this.Cursor = new Cursor(Properties.Resources.Comfortable_Home_Cursor.Handle);
                    else if (i == SharedVariables.AFFORDABLE_HOME)
                        this.Cursor = new Cursor(Properties.Resources.Affordable_Home_Cursor.Handle);
                    else if (i == SharedVariables.FACTORY)
                        this.Cursor = new Cursor(Properties.Resources.Factory_Cursor.Handle);
                    else if (i == SharedVariables.ENVIRONMENTAL_FACILITY)
                        this.Cursor = new Cursor(Properties.Resources.Environmental_Cursor.Handle);
                    else if (i == SharedVariables.STORE)
                        this.Cursor = new Cursor(Properties.Resources.Store_Cursor.Handle);
                    else if (i == SharedVariables.RESTAURANT)
                        this.Cursor = new Cursor(Properties.Resources.Restaurant_Cursor.Handle);
                    else
                        this.Cursor = new Cursor(Properties.Resources.Office_Cursor.Handle);
                    //refresh because grid will be highlighted after you choose a toolbar item
                    Refresh();
                }
        }

        //Tianli
        private void PlanetTianliForm_MouseUp(object sender, MouseEventArgs e)
        {
            //if something is selected
            if (_selectedToolbarItem != NOTHING)
            {
                //loop throught the grid to find one which one the user released the mouse on
                for(int i = 0; i < GRID_SIZE; i++)
                    for(int j = 0; j < GRID_SIZE; j++)
                        if (_grid[i, j].Rect.Contains(e.Location) && _highlightedGrid[i, j])
                        {
                            //stores the result from building, if it's unsuccessful or not
                            bool successful = false;
                            //find out which one the user wants to build and build it accordingly
                            if (_selectedToolbarItem == SharedVariables.EMERGENCY_SERVICES)
                                successful = _planet.BuildEmergencyServices(i, j);
                            else if (_selectedToolbarItem == SharedVariables.SCHOOL)
                                successful = _planet.BuildSchool(i, j);
                            else if (_selectedToolbarItem == SharedVariables.MEDICAL)
                                successful = _planet.BuildMedicalFacility(i, j);
                            else if (_selectedToolbarItem == SharedVariables.GOVERNMENT)
                                successful = _planet.BuildGovernmentFacility(i, j);
                            else if (_selectedToolbarItem == SharedVariables.POWER_PLANT)
                                successful = _planet.BuildPowerPlant(i, j);
                            else if (_selectedToolbarItem == SharedVariables.LUXURY_HOME)
                                successful = _planet.BuildLuxuryHome(i, j);
                            else if (_selectedToolbarItem == SharedVariables.COMFORTABLE_HOME)
                                successful = _planet.BuildComfortableHome(i, j);
                            else if (_selectedToolbarItem == SharedVariables.AFFORDABLE_HOME)
                                successful = _planet.BuildAffordableHome(i, j);
                            else if (_selectedToolbarItem == SharedVariables.FACTORY)
                                successful = _planet.BuildFactory(i, j);
                            else if (_selectedToolbarItem == SharedVariables.ENVIRONMENTAL_FACILITY)
                                successful = _planet.BuildEnvironmentalFacility(i, j);
                            else if (_selectedToolbarItem == SharedVariables.STORE)
                                successful = _planet.BuildStore(i, j);
                            else if (_selectedToolbarItem == SharedVariables.RESTAURANT)
                                successful = _planet.BuildRestaurant(i, j);
                            else
                                successful = _planet.BuildOffice(i, j);
                            if (successful)
                            {
                                //set the grid image to the one you built
                                _grid[i, j].Image = _toolbar[_selectedToolbarItem].Image;
                                UpdateScoreBoard();
                            }
                        }
                //reset the mouse cursor to normal
                this.Cursor = Cursors.Default;
                //set the selected toolbar and highlight grid to nothing
                _selectedToolbarItem = NOTHING;
                _highlightedGrid = null;
                //update what the user sees
                Refresh();
            }
        }

        //Tianli
        private void btnSave_Click(object sender, EventArgs e)
        {
            //if saved successfully
            if (_planet.Save())
                MessageBox.Show("Saved Successfully", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else // if file could not be saved properly
                MessageBox.Show("ERROR. Maybe you have the file open, close them all if you can", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Tianli, Andrew
        private void tmrTimer_Tick(object sender, EventArgs e)
        {
            //update the data every month
            _planet.UpdateTime();
            //increase the fake-game time and display it (Andrew wants it)
            _gameTime = _gameTime.AddMonths(1);
            //update the score board
            UpdateScoreBoard();
            //update the facility stats panel
            if (_lastClickedFacility != _noFacilityClicked)
                UpdateFacilityStatsDisplay(_lastClickedFacility.X, _lastClickedFacility.Y);
            // Attempt asteroid strike on the planet
            if (_planet.AttemptAsteroidStrike())
            {
                //stops the timer
                tmrTimer.Enabled = false;
                //inform the user that the game has ended
                MessageBox.Show("Asteroid Struck...gg");
                //move the scoreboard to the center
                pnlScoreBoard.Location = new Point(Screen.FromControl(this).Bounds.Width / 2 - pnlScoreBoard.Width / 2, Screen.FromControl(this).Bounds.Height / 2 - pnlScoreBoard.Height / 2);
                //make button invisible
                btnSave.Visible = false;
                //nullify the grid and toolbar so nothing gets drawn
                _grid = null;
                _toolbar = null;
                //refresh the entire form
                Refresh();
            }
        }

        //Tianli
        /// <summary>
        /// Updates the scoreboard data on the side
        /// </summary>
        private void UpdateScoreBoard()
        {
            //display all the information in labels with proper formatting
            lblMoney.Text = String.Format("Money: {0:C} ({1:C})", _planet.Money, _planet.Money - currentMoney);
            lblPopulation.Text = String.Format("Population: {0:n0}", _planet.CalculatePopulation());
            lblPollution.Text = String.Format("Pollution: {0:n0}", _planet.CalculatePollution());
            //check if power is negative, change the color so the user will be more informed about their decision
            if (_planet.CalculatePower() < 0)
                lblPower.ForeColor = Color.Red;
            else
                lblPower.ForeColor = Color.Lime;
            lblPower.Text = String.Format("Power: {0:n0}", _planet.CalculatePower());
            lblScore.Text = String.Format("Score: {0:n0}", _planet.Score);
            lblTime.Text = String.Format("Months Passed: {0:n0}", _planet.TimeElapsed);
            lblCurrentDate.Text = "Current Date: " + _gameTime.ToString("MMMM yyyy");
            // Store the player's current balance in a variable (by Andrew)
            currentMoney = _planet.Money;
        }

        //beautify the button, change text color
        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            btnSave.ForeColor = Color.Black;
        }
        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            btnSave.ForeColor = Color.White;
        }

        //Made by Andrew and Tianli in Skype call. P.S. Idk what the heck Andrew made but it looks like a Christmas tree
        private void UpdateFacilityStatsDisplay(int i, int j)
        {
            // Find out what the facility that was clicked was 
            if (_planet.Facilities[i, j] is EmergencyServices) // if facility was emergency services
            {
                // Display the name of the facility in the side bar
                lblSelectedFacilityName.Text = "Emergency Services";
                // Display the monthly maintenance cost of the facility in the side bar
                lblSelectedFacilityMaintCost.Text = "Maintenance Cost: $" + _planet.Facilities[i, j].Maintenance.ToString();
                // Display the monthly power usage of the facility in the side bar
                lblSelectedFacilityPowerGeneration.Text = "Power Generation: " + _planet.Facilities[i, j].Power.ToString();
                // Display the monthly revenue of the facility in the side bar
                lblSelectedFacilityRevenue.Text = "Revenue: $" + _planet.Facilities[i, j].Revenue.ToString();
                // Display the pollution output of the facility in the side bar
                lblSelectedFacilityPollution.Text = "Pollution: " + _planet.Facilities[i, j].Pollution.ToString();
                // Display the population of the facility in the side bar
                lblSelectedFacilityPopulation.Text = "Population: 0";
                // Display the location of the facility in the side bar
                lblSelectedFacilityLocation.Text = "Location: (" + i.ToString() + ", " + j.ToString() + ")";
                // Show the facility stats side panel
                pnlFacilityStats.Visible = true;
            }
            else if (_planet.Facilities[i, j] is School)
            {
                // Display the name of the facility in the side bar
                lblSelectedFacilityName.Text = "School";
                // Display the monthly maintenance cost of the facility in the side bar
                lblSelectedFacilityMaintCost.Text = "Maintenance Cost: " + _planet.Facilities[i, j].Maintenance.ToString();
                // Display the monthly power usage of the facility in the side bar
                lblSelectedFacilityPowerGeneration.Text = "Power Generation: " + _planet.Facilities[i, j].Power.ToString();
                // Display the monthly revenue of the facility in the side bar
                lblSelectedFacilityRevenue.Text = "Revenue: $" + _planet.Facilities[i, j].Revenue.ToString();
                // Display the pollution output of the facility in the side bar
                lblSelectedFacilityPollution.Text = "Pollution: " + _planet.Facilities[i, j].Pollution.ToString();
                // Display the population of the facility in the side bar
                lblSelectedFacilityPopulation.Text = "Population: 0";
                // Display the location of the facility in the side bar
                lblSelectedFacilityLocation.Text = "Location: (" + i.ToString() + ", " + j.ToString() + ")";
                // Show the facility stats side panel
                pnlFacilityStats.Visible = true;
            }
            else if (_planet.Facilities[i, j] is MedicalFacility)
            {
                // Display the name of the facility in the side bar
                lblSelectedFacilityName.Text = "Medical Facility";
                // Display the monthly maintenance cost of the facility in the side bar
                lblSelectedFacilityMaintCost.Text = "Maintenance Cost: " + _planet.Facilities[i, j].Maintenance.ToString();
                // Display the monthly power usage of the facility in the side bar
                lblSelectedFacilityPowerGeneration.Text = "Power Generation: " + _planet.Facilities[i, j].Power.ToString();
                // Display the monthly revenue of the facility in the side bar
                lblSelectedFacilityRevenue.Text = "Revenue: $" + _planet.Facilities[i, j].Revenue.ToString();
                // Display the pollution output of the facility in the side bar
                lblSelectedFacilityPollution.Text = "Pollution: " + _planet.Facilities[i, j].Pollution.ToString();
                // Display the population of the facility in the side bar
                lblSelectedFacilityPopulation.Text = "Population: 0";
                // Display the location of the facility in the side bar
                lblSelectedFacilityLocation.Text = "Location: (" + i.ToString() + ", " + j.ToString() + ")";
                // Show the facility stats side panel
                pnlFacilityStats.Visible = true;
            }
            else if (_planet.Facilities[i, j] is GovernmentFacility)
            {
                // Display the name of the facility in the side bar
                lblSelectedFacilityName.Text = "Government Facility";
                // Display the monthly maintenance cost of the facility in the side bar
                lblSelectedFacilityMaintCost.Text = "Maintenance Cost: " + _planet.Facilities[i, j].Maintenance.ToString();
                // Display the monthly power usage of the facility in the side bar
                lblSelectedFacilityPowerGeneration.Text = "Power Generation: " + _planet.Facilities[i, j].Power.ToString();
                // Display the monthly revenue of the facility in the side bar
                lblSelectedFacilityRevenue.Text = "Revenue: $" + _planet.Facilities[i, j].Revenue.ToString();
                // Display the pollution output of the facility in the side bar
                lblSelectedFacilityPollution.Text = "Pollution: " + _planet.Facilities[i, j].Pollution.ToString();
                // Display the population of the facility in the side bar
                lblSelectedFacilityPopulation.Text = "Population: 0";
                // Display the location of the facility in the side bar
                lblSelectedFacilityLocation.Text = "Location: (" + i.ToString() + ", " + j.ToString() + ")";
                // Show the facility stats side panel
                pnlFacilityStats.Visible = true;
            }
            else if (_planet.Facilities[i, j] is Powerplant)
            {
                // Display the name of the facility in the side bar
                lblSelectedFacilityName.Text = "Power Plant";
                // Display the monthly maintenance cost of the facility in the side bar
                lblSelectedFacilityMaintCost.Text = "Maintenance Cost: " + _planet.Facilities[i, j].Maintenance.ToString();
                // Display the monthly power usage of the facility in the side bar
                lblSelectedFacilityPowerGeneration.Text = "Power Generation: " + _planet.Facilities[i, j].Power.ToString();
                // Display the monthly revenue of the facility in the side bar
                lblSelectedFacilityRevenue.Text = "Revenue: $" + _planet.Facilities[i, j].Revenue.ToString();
                // Display the pollution output of the facility in the side bar
                lblSelectedFacilityPollution.Text = "Pollution: " + _planet.Facilities[i, j].Pollution.ToString();
                // Display the population of the facility in the side bar
                lblSelectedFacilityPopulation.Text = "Population: 0";
                // Display the location of the facility in the side bar
                lblSelectedFacilityLocation.Text = "Location: (" + i.ToString() + ", " + j.ToString() + ")";
                // Show the facility stats side panel
                pnlFacilityStats.Visible = true;
            }
            else if (_planet.Facilities[i, j] is LuxuryHome)
            {
                // Display the name of the facility in the side bar
                lblSelectedFacilityName.Text = "Luxury Home";
                // Display the monthly maintenance cost of the facility in the side bar
                lblSelectedFacilityMaintCost.Text = "Maintenance Cost: " + _planet.Facilities[i, j].Maintenance.ToString();
                // Display the monthly power usage of the facility in the side bar
                lblSelectedFacilityPowerGeneration.Text = "Power Generation: " + _planet.Facilities[i, j].Power.ToString();
                // Display the monthly revenue of the facility in the side bar
                lblSelectedFacilityRevenue.Text = "Revenue: $" + _planet.Facilities[i, j].Revenue.ToString();
                // Display the pollution output of the facility in the side bar
                lblSelectedFacilityPollution.Text = "Pollution: " + _planet.Facilities[i, j].Pollution.ToString();
                // Display the population of the facility in the side bar
                lblSelectedFacilityPopulation.Text = "Population: " + ((ResidentialFacility)_planet.Facilities[i, j]).Population;
                // Display the location of the facility in the side bar
                lblSelectedFacilityLocation.Text = "Location: (" + i.ToString() + ", " + j.ToString() + ")";
                // Show the facility stats side panel
                pnlFacilityStats.Visible = true;
            }
            else if (_planet.Facilities[i, j] is ComfortableHome)
            {
                // Display the name of the facility in the side bar
                lblSelectedFacilityName.Text = "Comfortable Home";
                // Display the monthly maintenance cost of the facility in the side bar
                lblSelectedFacilityMaintCost.Text = "Maintenance Cost: " + _planet.Facilities[i, j].Maintenance.ToString();
                // Display the monthly power usage of the facility in the side bar
                lblSelectedFacilityPowerGeneration.Text = "Power Generation: " + _planet.Facilities[i, j].Power.ToString();
                // Display the monthly revenue of the facility in the side bar
                lblSelectedFacilityRevenue.Text = "Revenue: $" + _planet.Facilities[i, j].Revenue.ToString();
                // Display the pollution output of the facility in the side bar
                lblSelectedFacilityPollution.Text = "Pollution: " + _planet.Facilities[i, j].Pollution.ToString();
                // Display the population of the facility in the side bar
                lblSelectedFacilityPopulation.Text = "Population: " + ((ResidentialFacility)_planet.Facilities[i, j]).Population;
                // Display the location of the facility in the side bar
                lblSelectedFacilityLocation.Text = "Location: (" + i.ToString() + ", " + j.ToString() + ")";
                // Show the facility stats side panel
                pnlFacilityStats.Visible = true;
            }
            else if (_planet.Facilities[i, j] is AffordableHome)
            {
                // Display the name of the facility in the side bar
                lblSelectedFacilityName.Text = "Affordable Home";
                // Display the monthly maintenance cost of the facility in the side bar
                lblSelectedFacilityMaintCost.Text = "Maintenance Cost: " + _planet.Facilities[i, j].Maintenance.ToString();
                // Display the monthly power usage of the facility in the side bar
                lblSelectedFacilityPowerGeneration.Text = "Power Generation: " + _planet.Facilities[i, j].Power.ToString();
                // Display the monthly revenue of the facility in the side bar
                lblSelectedFacilityRevenue.Text = "Revenue: $" + _planet.Facilities[i, j].Revenue.ToString();
                // Display the pollution output of the facility in the side bar
                lblSelectedFacilityPollution.Text = "Pollution: " + _planet.Facilities[i, j].Pollution.ToString();
                // Display the population of the facility in the side bar
                lblSelectedFacilityPopulation.Text = "Population: " + ((ResidentialFacility)_planet.Facilities[i, j]).Population;
                // Display the location of the facility in the side bar
                lblSelectedFacilityLocation.Text = "Location: (" + i.ToString() + ", " + j.ToString() + ")";
                // Show the facility stats side panel
                pnlFacilityStats.Visible = true;
            }
            else if (_planet.Facilities[i, j] is Factory)
            {
                // Display the name of the facility in the side bar
                lblSelectedFacilityName.Text = "Factory";
                // Display the monthly maintenance cost of the facility in the side bar
                lblSelectedFacilityMaintCost.Text = "Maintenance Cost: " + _planet.Facilities[i, j].Maintenance.ToString();
                // Display the monthly power usage of the facility in the side bar
                lblSelectedFacilityPowerGeneration.Text = "Power Generation: " + _planet.Facilities[i, j].Power.ToString();
                // Display the monthly revenue of the facility in the side bar
                lblSelectedFacilityRevenue.Text = "Revenue: $" + _planet.Facilities[i, j].Revenue.ToString();
                // Display the pollution output of the facility in the side bar
                lblSelectedFacilityPollution.Text = "Pollution: " + _planet.Facilities[i, j].Pollution.ToString();
                // Display the population of the facility in the side bar
                lblSelectedFacilityPopulation.Text = "Population: 0";
                // Display the location of the facility in the side bar
                lblSelectedFacilityLocation.Text = "Location: (" + i.ToString() + ", " + j.ToString() + ")";
                // Show the facility stats side panel
                pnlFacilityStats.Visible = true;
            }
            else if (_planet.Facilities[i, j] is EnvironmentalFacility)
            {
                // Display the name of the facility in the side bar
                lblSelectedFacilityName.Text = "Environmental Facility";
                // Display the monthly maintenance cost of the facility in the side bar
                lblSelectedFacilityMaintCost.Text = "Maintenance Cost: " + _planet.Facilities[i, j].Maintenance.ToString();
                // Display the monthly power usage of the facility in the side bar
                lblSelectedFacilityPowerGeneration.Text = "Power Generation: " + _planet.Facilities[i, j].Power.ToString();
                // Display the monthly revenue of the facility in the side bar
                lblSelectedFacilityRevenue.Text = "Revenue: $" + _planet.Facilities[i, j].Revenue.ToString();
                // Display the pollution output of the facility in the side bar
                lblSelectedFacilityPollution.Text = "Pollution: " + _planet.Facilities[i, j].Pollution.ToString();
                // Display the population of the facility in the side bar
                lblSelectedFacilityPopulation.Text = "Population: 0";
                // Display the location of the facility in the side bar
                lblSelectedFacilityLocation.Text = "Location: (" + i.ToString() + ", " + j.ToString() + ")";
                // Show the facility stats side panel
                pnlFacilityStats.Visible = true;
            }
            else if (_planet.Facilities[i, j] is Store)
            {
                // Display the name of the facility in the side bar
                lblSelectedFacilityName.Text = "Store";
                // Display the monthly maintenance cost of the facility in the side bar
                lblSelectedFacilityMaintCost.Text = "Maintenance Cost: " + _planet.Facilities[i, j].Maintenance.ToString();
                // Display the monthly power usage of the facility in the side bar
                lblSelectedFacilityPowerGeneration.Text = "Power Generation: " + _planet.Facilities[i, j].Power.ToString();
                // Display the monthly revenue of the facility in the side bar
                lblSelectedFacilityRevenue.Text = "Revenue: $" + _planet.Facilities[i, j].Revenue.ToString();
                // Display the pollution output of the facility in the side bar
                lblSelectedFacilityPollution.Text = "Pollution: " + _planet.Facilities[i, j].Pollution.ToString();
                // Display the population of the facility in the side bar
                lblSelectedFacilityPopulation.Text = "Population: 0";
                // Display the location of the facility in the side bar
                lblSelectedFacilityLocation.Text = "Location: (" + i.ToString() + ", " + j.ToString() + ")";
                // Show the facility stats side panel
                pnlFacilityStats.Visible = true;
            }
            else if (_planet.Facilities[i, j] is Restaurant)
            {
                // Display the name of the facility in the side bar
                lblSelectedFacilityName.Text = "Restaurant";
                // Display the monthly maintenance cost of the facility in the side bar
                lblSelectedFacilityMaintCost.Text = "Maintenance Cost: " + _planet.Facilities[i, j].Maintenance.ToString();
                // Display the monthly power usage of the facility in the side bar
                lblSelectedFacilityPowerGeneration.Text = "Power Generation: " + _planet.Facilities[i, j].Power.ToString();
                // Display the monthly revenue of the facility in the side bar
                lblSelectedFacilityRevenue.Text = "Revenue: $" + _planet.Facilities[i, j].Revenue.ToString();
                // Display the pollution output of the facility in the side bar
                lblSelectedFacilityPollution.Text = "Pollution: " + _planet.Facilities[i, j].Pollution.ToString();
                // Display the location of the facility in the side bar
                lblSelectedFacilityLocation.Text = "Location: (" + i.ToString() + ", " + j.ToString() + ")";
                // Show the facility stats side panel
                pnlFacilityStats.Visible = true;
            }
            else if (_planet.Facilities[i, j] is Office)
            {
                // Display the name of the facility in the side bar
                lblSelectedFacilityName.Text = "Office";
                // Display the monthly maintenance cost of the facility in the side bar
                lblSelectedFacilityMaintCost.Text = "Maintenance Cost: " + _planet.Facilities[i, j].Maintenance.ToString();
                // Display the monthly power usage of the facility in the side bar
                lblSelectedFacilityPowerGeneration.Text = "Power Generation: " + _planet.Facilities[i, j].Power.ToString();
                // Display the monthly revenue of the facility in the side bar
                lblSelectedFacilityRevenue.Text = "Revenue: $" + _planet.Facilities[i, j].Revenue.ToString();
                // Display the pollution output of the facility in the side bar
                lblSelectedFacilityPollution.Text = "Pollution: " + _planet.Facilities[i, j].Pollution.ToString();
                // Display the population of the facility in the side bar
                lblSelectedFacilityPopulation.Text = "Population: 0";
                // Display the location of the facility in the side bar
                lblSelectedFacilityLocation.Text = "Location: (" + i.ToString() + ", " + j.ToString() + ")";
                // Show the facility stats side panel
                pnlFacilityStats.Visible = true;
            }
            else // if the facility type is not recognized or is dirt
            {
                // Hide the facility stats side panel
                pnlFacilityStats.Visible = false;
                _lastClickedFacility = _noFacilityClicked;
                return;
            }
            _lastClickedFacility.X = i;
            _lastClickedFacility.Y = j;
        }

        // Section done by Andrew
        private void PlanetTianliForm_MouseClick(object sender, MouseEventArgs e)
        {
            // Check if nothing is selected
            if (_selectedToolbarItem == NOTHING)
            {
                // Loop throught the grid to find one which one the user clicked on
                for (int i = 0; i < GRID_SIZE; i++)
                {
                    for (int j = 0; j < GRID_SIZE; j++)
                    {
                        if (_grid[i, j].Rect.Contains(e.Location))
                        {
                            UpdateFacilityStatsDisplay(i, j);
                        }
                    }
                }
            }
        }
    }
}
