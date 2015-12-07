//Tianli Zhan, Andrew Pang, Jack Wen
//December 6, 2015
//Main form when you open the program, allows you to create new game or load saved game
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SimSpace_JAT
{
    public partial class LevelSelectorForm : Form
    {
        public LevelSelectorForm()
        {
            InitializeComponent();
        }

        //show the 
        private void btnStart_Click(object sender, EventArgs e)
        {
            pnlSizeSelect.Visible = true;
        }

        //starts the game with small grid
        private void btnStartSmall_Click(object sender, EventArgs e)
        {
            //PlanetJackForm gameForm = new PlanetJackForm();
            //gameForm.Show();
            pnlSizeSelect.Visible = false;
        }

        //starts the game with medium grid
        private void btnStartMedium_Click(object sender, EventArgs e)
        {
            //PlanetAndrewForm gameForm = new PlanetAndrewForm();
            //gameForm.Show();
            pnlSizeSelect.Visible = false;
        }

        //starts the game with large grid
        private void btnStartLarge_Click(object sender, EventArgs e)
        {
            PlanetTianliForm gameForm = new PlanetTianliForm();
            gameForm.Show();
            pnlSizeSelect.Visible = false;
        }

        //pop up a file browser to select saved game
        private void btnLoad_Click(object sender, EventArgs e)
        {
            //creates a file browser dialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //set the initial directory to where the .exe file is
            openFileDialog.InitialDirectory = Application.StartupPath;

            //set the file filter by default to .txt files, with the option to see all files
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;

            //show the dialog and store the result
            DialogResult dialogResult = openFileDialog.ShowDialog();

            //if the result was the user selected something by clicking OK
            if (dialogResult == DialogResult.OK)
            {
                //read from the file
                using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                {
                    //look for size
                    while (sr.Peek() != -1)
                        if (sr.ReadLine() == "[SIZE]")
                        {
                            //parse the size to int
                            int size;
                            if (int.TryParse(sr.ReadLine(), out size))
                            {
                                //create a game form accordingly
                                if (size == PlanetTianliForm.GRID_SIZE)
                                {
                                    PlanetTianliForm form = new PlanetTianliForm(openFileDialog.FileName);
                                    form.Show();
                                    return;
                                }
                                //else if (size == PlanetAndrewForm.GRID_SIZE)
                                //{
                                //    PlanetTianliForm form = new PlanetAndrewForm(openFileDialog.FileName);
                                //    form.Show();
                                //    return;
                                //}
                                //else if (size == PlanetJackForm.GRID_SIZE)
                                //{
                                //    PlanetJackForm form = new PlanetJackForm(openFileDialog.FileName);
                                //    form.Show();
                                //    return;
                                //}
                                else
                                {
                                    MessageBox.Show("INVALID GRID SIZE!!");
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("INCORRECT SIZE FORMAT!!");
                                return;
                            }
                        }
                    MessageBox.Show("NO SIZE FOUND!!");
                }
            }
        }
    }
}
