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
        private PlanetModelWrapper _planet;
        private const int GRID_SIZE = 30;
        private const int TOOLBAR_SIZE = 13;
        private Size _cellSize = new Size(30, 30);
        private struct Cell
        {
            private Image _image;
            private Rectangle _rect;
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
        //array to store the graphical information needed for graphical processing for a Toolbar, including image and coordinates
        private Cell[] _toolbar = new Cell[TOOLBAR_SIZE];
        //array to store the graphical information needed for graphical processing for a grid, including image and coordinates
        private Cell[,] _grid = new Cell[GRID_SIZE, GRID_SIZE];

        public PlanetTianliForm()
        {
            InitializeComponent();
            _planet = new PlanetModelWrapper();
            CreateNewGrid(GRID_SIZE, GRID_SIZE);
            CreateToolbar();
        }

        /// <summary>
        /// Creates the grid cells
        /// </summary>
        /// <param name="rows">Number of rows for the grid</param>
        /// <param name="cols">Number of columns for the grid</param>
        private void CreateNewGrid(int rows, int cols)
        {
            //Loop through all the rows
            for (int i = 0; i < rows; i++)
            {
                //loop through all the columns
                for (int j = 0; j < cols; j++)
                {
                    //create each grid cell
                    _grid[i,j].Rect = new Rectangle(_cellSize.Width+_cellSize.Width*j+20, _cellSize.Height*i, _cellSize.Width,_cellSize.Height)
                }
            }
        }

        /// <summary>
        /// Initializes the toolbar with rectangle locations and images
        /// </summary>
        private void CreateToolbar()
        {
            //Loop through the toolbar cells
            for (int i = 0; i < TOOLBAR_SIZE; i++)
            {
                //create the rectangles
                _toolbar[i].Rect = new Rectangle(new Point(0, _cellSize.Height * i), _cellSize);
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

        //override OnPaint, called everytime the form refreshes
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            DrawGrid(e);

            DrawToolbar(e);
        }
        //Draws the grid
        private void DrawGrid(PaintEventArgs e)
        {
            // Only draw grid if it exists, prevents crashing
            if (_grid != null)
            {
                // Loop through each row in the grid
                for (int i = 0; i < _grid.GetLength(SharedVariables.ROW); i++)
                {
                    // Loop through each column in the row
                    for (int j = 0; j < _grid.GetLength(SharedVariables.COL); j++)
                    {
                        e.Graphics.DrawRectangle(Pens.Black, _grid[i, j].Rect);
                        //Check if there is no image (no facility built yet) to prevent crashing
                        if (_grid[i, j].Image != null)
                        {
                            e.Graphics.DrawImage(_grid[i, j].Image, _grid[i, j].Rect);
                        }
                    }
                }
            }
        }
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
                        //Draws the cell
                        e.Graphics.DrawRectangle(Pens.Black, _toolbar[i].Rect);
                        //Draws the image
                        e.Graphics.DrawImage(_toolbar[i].Image, _toolbar[i].Rect);
                    }
                }
            }
        }
    }
}
