namespace SimSpace_JAT
{
    partial class PlanetTianliForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnSave = new System.Windows.Forms.Button();
            this.tmrTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlScoreBoard = new System.Windows.Forms.Panel();
            this.lblCurrentDate = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblPopulation = new System.Windows.Forms.Label();
            this.lblPollution = new System.Windows.Forms.Label();
            this.lblPower = new System.Windows.Forms.Label();
            this.lblMoney = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.pnlFacilityStats = new System.Windows.Forms.Panel();
            this.lblSelectedFacilityName = new System.Windows.Forms.Label();
            this.lblSelectedFacilityMaintCost = new System.Windows.Forms.Label();
            this.lblSelectedFacilityPowerUsage = new System.Windows.Forms.Label();
            this.lblSelectedFacilityRevenue = new System.Windows.Forms.Label();
            this.lblSelectedFacilityPollution = new System.Windows.Forms.Label();
            this.lblSelectedFacilityPopulation = new System.Windows.Forms.Label();
            this.lblSelectedFacilityLocation = new System.Windows.Forms.Label();
            this.pnlScoreBoard.SuspendLayout();
            this.pnlFacilityStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(41, 270);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(175, 50);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "SAVE GAME";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.MouseEnter += new System.EventHandler(this.btnSave_MouseEnter);
            this.btnSave.MouseLeave += new System.EventHandler(this.btnSave_MouseLeave);
            // 
            // tmrTimer
            // 
            this.tmrTimer.Interval = 10000;
            this.tmrTimer.Tick += new System.EventHandler(this.tmrTimer_Tick);
            // 
            // pnlScoreBoard
            // 
            this.pnlScoreBoard.BackColor = System.Drawing.Color.Black;
            this.pnlScoreBoard.Controls.Add(this.lblCurrentDate);
            this.pnlScoreBoard.Controls.Add(this.lblTime);
            this.pnlScoreBoard.Controls.Add(this.lblPopulation);
            this.pnlScoreBoard.Controls.Add(this.lblPollution);
            this.pnlScoreBoard.Controls.Add(this.lblPower);
            this.pnlScoreBoard.Controls.Add(this.lblMoney);
            this.pnlScoreBoard.Controls.Add(this.lblScore);
            this.pnlScoreBoard.Location = new System.Drawing.Point(41, 41);
            this.pnlScoreBoard.Name = "pnlScoreBoard";
            this.pnlScoreBoard.Size = new System.Drawing.Size(302, 223);
            this.pnlScoreBoard.TabIndex = 1;
            this.pnlScoreBoard.Visible = false;
            // 
            // lblCurrentDate
            // 
            this.lblCurrentDate.AutoSize = true;
            this.lblCurrentDate.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentDate.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentDate.ForeColor = System.Drawing.Color.Gold;
            this.lblCurrentDate.Location = new System.Drawing.Point(16, 193);
            this.lblCurrentDate.Name = "lblCurrentDate";
            this.lblCurrentDate.Size = new System.Drawing.Size(82, 16);
            this.lblCurrentDate.TabIndex = 6;
            this.lblCurrentDate.Text = "Current Date: ";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.Gold;
            this.lblTime.Location = new System.Drawing.Point(16, 169);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(87, 16);
            this.lblTime.TabIndex = 5;
            this.lblTime.Text = "Months Passed: ";
            // 
            // lblPopulation
            // 
            this.lblPopulation.AutoSize = true;
            this.lblPopulation.BackColor = System.Drawing.Color.Transparent;
            this.lblPopulation.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPopulation.ForeColor = System.Drawing.Color.Lime;
            this.lblPopulation.Location = new System.Drawing.Point(25, 138);
            this.lblPopulation.Name = "lblPopulation";
            this.lblPopulation.Size = new System.Drawing.Size(59, 16);
            this.lblPopulation.TabIndex = 4;
            this.lblPopulation.Text = "Population";
            // 
            // lblPollution
            // 
            this.lblPollution.AutoSize = true;
            this.lblPollution.BackColor = System.Drawing.Color.Transparent;
            this.lblPollution.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPollution.ForeColor = System.Drawing.Color.Lime;
            this.lblPollution.Location = new System.Drawing.Point(25, 111);
            this.lblPollution.Name = "lblPollution";
            this.lblPollution.Size = new System.Drawing.Size(49, 16);
            this.lblPollution.TabIndex = 3;
            this.lblPollution.Text = "Pollution";
            // 
            // lblPower
            // 
            this.lblPower.AutoSize = true;
            this.lblPower.BackColor = System.Drawing.Color.Transparent;
            this.lblPower.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPower.ForeColor = System.Drawing.Color.Lime;
            this.lblPower.Location = new System.Drawing.Point(25, 83);
            this.lblPower.Name = "lblPower";
            this.lblPower.Size = new System.Drawing.Size(38, 16);
            this.lblPower.TabIndex = 2;
            this.lblPower.Text = "Power";
            // 
            // lblMoney
            // 
            this.lblMoney.AutoSize = true;
            this.lblMoney.BackColor = System.Drawing.Color.Transparent;
            this.lblMoney.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoney.ForeColor = System.Drawing.Color.Lime;
            this.lblMoney.Location = new System.Drawing.Point(25, 57);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(40, 16);
            this.lblMoney.TabIndex = 1;
            this.lblMoney.Text = "Money";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.Color.Transparent;
            this.lblScore.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.Color.Lime;
            this.lblScore.Location = new System.Drawing.Point(13, 15);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(86, 35);
            this.lblScore.TabIndex = 0;
            this.lblScore.Text = "Score";
            // 
            // pnlFacilityStats
            // 
            this.pnlFacilityStats.Controls.Add(this.lblSelectedFacilityLocation);
            this.pnlFacilityStats.Controls.Add(this.lblSelectedFacilityPopulation);
            this.pnlFacilityStats.Controls.Add(this.lblSelectedFacilityPollution);
            this.pnlFacilityStats.Controls.Add(this.lblSelectedFacilityRevenue);
            this.pnlFacilityStats.Controls.Add(this.lblSelectedFacilityPowerUsage);
            this.pnlFacilityStats.Controls.Add(this.lblSelectedFacilityMaintCost);
            this.pnlFacilityStats.Controls.Add(this.lblSelectedFacilityName);
            this.pnlFacilityStats.Location = new System.Drawing.Point(41, 327);
            this.pnlFacilityStats.Name = "pnlFacilityStats";
            this.pnlFacilityStats.Size = new System.Drawing.Size(302, 217);
            this.pnlFacilityStats.TabIndex = 2;
            // 
            // lblSelectedFacilityName
            // 
            this.lblSelectedFacilityName.AutoSize = true;
            this.lblSelectedFacilityName.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectedFacilityName.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedFacilityName.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblSelectedFacilityName.Location = new System.Drawing.Point(14, 19);
            this.lblSelectedFacilityName.Name = "lblSelectedFacilityName";
            this.lblSelectedFacilityName.Size = new System.Drawing.Size(137, 27);
            this.lblSelectedFacilityName.TabIndex = 7;
            this.lblSelectedFacilityName.Text = "FacilityName";
            // 
            // lblSelectedFacilityMaintCost
            // 
            this.lblSelectedFacilityMaintCost.AutoSize = true;
            this.lblSelectedFacilityMaintCost.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectedFacilityMaintCost.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedFacilityMaintCost.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblSelectedFacilityMaintCost.Location = new System.Drawing.Point(25, 55);
            this.lblSelectedFacilityMaintCost.Name = "lblSelectedFacilityMaintCost";
            this.lblSelectedFacilityMaintCost.Size = new System.Drawing.Size(105, 16);
            this.lblSelectedFacilityMaintCost.TabIndex = 8;
            this.lblSelectedFacilityMaintCost.Text = "Maintenance Cost: ";
            // 
            // lblSelectedFacilityPowerUsage
            // 
            this.lblSelectedFacilityPowerUsage.AutoSize = true;
            this.lblSelectedFacilityPowerUsage.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectedFacilityPowerUsage.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedFacilityPowerUsage.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblSelectedFacilityPowerUsage.Location = new System.Drawing.Point(25, 80);
            this.lblSelectedFacilityPowerUsage.Name = "lblSelectedFacilityPowerUsage";
            this.lblSelectedFacilityPowerUsage.Size = new System.Drawing.Size(78, 16);
            this.lblSelectedFacilityPowerUsage.TabIndex = 9;
            this.lblSelectedFacilityPowerUsage.Text = "Power Usage: ";
            // 
            // lblSelectedFacilityRevenue
            // 
            this.lblSelectedFacilityRevenue.AutoSize = true;
            this.lblSelectedFacilityRevenue.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectedFacilityRevenue.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedFacilityRevenue.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblSelectedFacilityRevenue.Location = new System.Drawing.Point(25, 106);
            this.lblSelectedFacilityRevenue.Name = "lblSelectedFacilityRevenue";
            this.lblSelectedFacilityRevenue.Size = new System.Drawing.Size(57, 16);
            this.lblSelectedFacilityRevenue.TabIndex = 10;
            this.lblSelectedFacilityRevenue.Text = "Revenue: ";
            // 
            // lblSelectedFacilityPollution
            // 
            this.lblSelectedFacilityPollution.AutoSize = true;
            this.lblSelectedFacilityPollution.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectedFacilityPollution.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedFacilityPollution.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblSelectedFacilityPollution.Location = new System.Drawing.Point(25, 132);
            this.lblSelectedFacilityPollution.Name = "lblSelectedFacilityPollution";
            this.lblSelectedFacilityPollution.Size = new System.Drawing.Size(56, 16);
            this.lblSelectedFacilityPollution.TabIndex = 11;
            this.lblSelectedFacilityPollution.Text = "Pollution: ";
            // 
            // lblSelectedFacilityPopulation
            // 
            this.lblSelectedFacilityPopulation.AutoSize = true;
            this.lblSelectedFacilityPopulation.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectedFacilityPopulation.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedFacilityPopulation.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblSelectedFacilityPopulation.Location = new System.Drawing.Point(25, 158);
            this.lblSelectedFacilityPopulation.Name = "lblSelectedFacilityPopulation";
            this.lblSelectedFacilityPopulation.Size = new System.Drawing.Size(66, 16);
            this.lblSelectedFacilityPopulation.TabIndex = 12;
            this.lblSelectedFacilityPopulation.Text = "Population: ";
            // 
            // lblSelectedFacilityLocation
            // 
            this.lblSelectedFacilityLocation.AutoSize = true;
            this.lblSelectedFacilityLocation.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectedFacilityLocation.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedFacilityLocation.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblSelectedFacilityLocation.Location = new System.Drawing.Point(25, 184);
            this.lblSelectedFacilityLocation.Name = "lblSelectedFacilityLocation";
            this.lblSelectedFacilityLocation.Size = new System.Drawing.Size(71, 16);
            this.lblSelectedFacilityLocation.TabIndex = 13;
            this.lblSelectedFacilityLocation.Text = "Location: (,)";
            // 
            // PlanetTianliForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::SimSpace_JAT.Properties.Resources.Deep_Space_Wallpaper;
            this.ClientSize = new System.Drawing.Size(484, 571);
            this.Controls.Add(this.pnlFacilityStats);
            this.Controls.Add(this.pnlScoreBoard);
            this.Controls.Add(this.btnSave);
            this.DoubleBuffered = true;
            this.Name = "PlanetTianliForm";
            this.Text = "SimSpace_JAT Large (30 x 30)";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlanetTianliForm_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PlanetTianliForm_MouseUp);
            this.pnlScoreBoard.ResumeLayout(false);
            this.pnlScoreBoard.PerformLayout();
            this.pnlFacilityStats.ResumeLayout(false);
            this.pnlFacilityStats.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Timer tmrTimer;
        private System.Windows.Forms.Panel pnlScoreBoard;
        private System.Windows.Forms.Label lblPopulation;
        private System.Windows.Forms.Label lblPollution;
        private System.Windows.Forms.Label lblPower;
        private System.Windows.Forms.Label lblMoney;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblCurrentDate;
        private System.Windows.Forms.Panel pnlFacilityStats;
        private System.Windows.Forms.Label lblSelectedFacilityLocation;
        private System.Windows.Forms.Label lblSelectedFacilityPopulation;
        private System.Windows.Forms.Label lblSelectedFacilityPollution;
        private System.Windows.Forms.Label lblSelectedFacilityRevenue;
        private System.Windows.Forms.Label lblSelectedFacilityPowerUsage;
        private System.Windows.Forms.Label lblSelectedFacilityMaintCost;
        private System.Windows.Forms.Label lblSelectedFacilityName;

    }
}