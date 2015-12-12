namespace SimSpace_JAT
{
    partial class LevelSelectorForm
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.pnlSizeSelect = new System.Windows.Forms.Panel();
            this.btnStartLarge = new System.Windows.Forms.Button();
            this.btnStartMedium = new System.Windows.Forms.Button();
            this.btnStartSmall = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.pnlSizeSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(136, 116);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 47);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start New Game";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(136, 186);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 27);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load Game";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // pnlSizeSelect
            // 
            this.pnlSizeSelect.Controls.Add(this.btnBack);
            this.pnlSizeSelect.Controls.Add(this.btnStartLarge);
            this.pnlSizeSelect.Controls.Add(this.btnStartMedium);
            this.pnlSizeSelect.Controls.Add(this.btnStartSmall);
            this.pnlSizeSelect.Location = new System.Drawing.Point(120, 107);
            this.pnlSizeSelect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlSizeSelect.Name = "pnlSizeSelect";
            this.pnlSizeSelect.Size = new System.Drawing.Size(131, 158);
            this.pnlSizeSelect.TabIndex = 2;
            this.pnlSizeSelect.Visible = false;
            // 
            // btnStartLarge
            // 
            this.btnStartLarge.Location = new System.Drawing.Point(0, 71);
            this.btnStartLarge.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStartLarge.Name = "btnStartLarge";
            this.btnStartLarge.Size = new System.Drawing.Size(127, 28);
            this.btnStartLarge.TabIndex = 2;
            this.btnStartLarge.Text = "Large 30x30";
            this.btnStartLarge.UseVisualStyleBackColor = true;
            this.btnStartLarge.Click += new System.EventHandler(this.btnStartLarge_Click);
            // 
            // btnStartMedium
            // 
            this.btnStartMedium.Location = new System.Drawing.Point(0, 36);
            this.btnStartMedium.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStartMedium.Name = "btnStartMedium";
            this.btnStartMedium.Size = new System.Drawing.Size(127, 28);
            this.btnStartMedium.TabIndex = 1;
            this.btnStartMedium.Text = "Medium 25x25";
            this.btnStartMedium.UseVisualStyleBackColor = true;
            this.btnStartMedium.Click += new System.EventHandler(this.btnStartMedium_Click);
            // 
            // btnStartSmall
            // 
            this.btnStartSmall.Location = new System.Drawing.Point(0, 0);
            this.btnStartSmall.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStartSmall.Name = "btnStartSmall";
            this.btnStartSmall.Size = new System.Drawing.Size(127, 28);
            this.btnStartSmall.TabIndex = 0;
            this.btnStartSmall.Text = "Small 20x20";
            this.btnStartSmall.UseVisualStyleBackColor = true;
            this.btnStartSmall.Click += new System.EventHandler(this.btnStartSmall_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(26, 132);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 26);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // LevelSelectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 321);
            this.Controls.Add(this.pnlSizeSelect);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnStart);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "LevelSelectorForm";
            this.Text = "Sim Space";
            this.pnlSizeSelect.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Panel pnlSizeSelect;
        private System.Windows.Forms.Button btnStartLarge;
        private System.Windows.Forms.Button btnStartMedium;
        private System.Windows.Forms.Button btnStartSmall;
        private System.Windows.Forms.Button btnBack;
    }
}

