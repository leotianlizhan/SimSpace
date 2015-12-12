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
            this.lblPopulation = new System.Windows.Forms.Label();
            this.lblPollution = new System.Windows.Forms.Label();
            this.lblPower = new System.Windows.Forms.Label();
            this.lblMoney = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.pnlScoreBoard.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(55, 295);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 28);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save Game";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tmrTimer
            // 
            this.tmrTimer.Interval = 10000;
            this.tmrTimer.Tick += new System.EventHandler(this.tmrTimer_Tick);
            // 
            // pnlScoreBoard
            // 
            this.pnlScoreBoard.BackColor = System.Drawing.Color.Black;
            this.pnlScoreBoard.Controls.Add(this.lblPopulation);
            this.pnlScoreBoard.Controls.Add(this.lblPollution);
            this.pnlScoreBoard.Controls.Add(this.lblPower);
            this.pnlScoreBoard.Controls.Add(this.lblMoney);
            this.pnlScoreBoard.Controls.Add(this.lblScore);
            this.pnlScoreBoard.Location = new System.Drawing.Point(55, 50);
            this.pnlScoreBoard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlScoreBoard.Name = "pnlScoreBoard";
            this.pnlScoreBoard.Size = new System.Drawing.Size(403, 222);
            this.pnlScoreBoard.TabIndex = 1;
            this.pnlScoreBoard.Visible = false;
            // 
            // lblPopulation
            // 
            this.lblPopulation.AutoSize = true;
            this.lblPopulation.ForeColor = System.Drawing.Color.Lime;
            this.lblPopulation.Location = new System.Drawing.Point(33, 170);
            this.lblPopulation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPopulation.Name = "lblPopulation";
            this.lblPopulation.Size = new System.Drawing.Size(75, 17);
            this.lblPopulation.TabIndex = 4;
            this.lblPopulation.Text = "Population";
            // 
            // lblPollution
            // 
            this.lblPollution.AutoSize = true;
            this.lblPollution.ForeColor = System.Drawing.Color.Lime;
            this.lblPollution.Location = new System.Drawing.Point(33, 137);
            this.lblPollution.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPollution.Name = "lblPollution";
            this.lblPollution.Size = new System.Drawing.Size(62, 17);
            this.lblPollution.TabIndex = 3;
            this.lblPollution.Text = "Pollution";
            // 
            // lblPower
            // 
            this.lblPower.AutoSize = true;
            this.lblPower.ForeColor = System.Drawing.Color.Lime;
            this.lblPower.Location = new System.Drawing.Point(33, 102);
            this.lblPower.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPower.Name = "lblPower";
            this.lblPower.Size = new System.Drawing.Size(47, 17);
            this.lblPower.TabIndex = 2;
            this.lblPower.Text = "Power";
            // 
            // lblMoney
            // 
            this.lblMoney.AutoSize = true;
            this.lblMoney.ForeColor = System.Drawing.Color.Lime;
            this.lblMoney.Location = new System.Drawing.Point(33, 70);
            this.lblMoney.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(50, 17);
            this.lblMoney.TabIndex = 1;
            this.lblMoney.Text = "Money";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.Color.Lime;
            this.lblScore.Location = new System.Drawing.Point(17, 18);
            this.lblScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(111, 39);
            this.lblScore.TabIndex = 0;
            this.lblScore.Text = "Score";
            // 
            // PlanetTianliForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 375);
            this.Controls.Add(this.pnlScoreBoard);
            this.Controls.Add(this.btnSave);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PlanetTianliForm";
            this.Text = "Sim Space 30 x 30";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlanetTianliForm_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PlanetTianliForm_MouseUp);
            this.pnlScoreBoard.ResumeLayout(false);
            this.pnlScoreBoard.PerformLayout();
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

    }
}