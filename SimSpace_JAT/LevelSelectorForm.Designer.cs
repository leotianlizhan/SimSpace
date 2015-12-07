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
            this.btnStartSmall = new System.Windows.Forms.Button();
            this.btnStartMedium = new System.Windows.Forms.Button();
            this.btnStartLarge = new System.Windows.Forms.Button();
            this.pnlSizeSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(102, 94);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 38);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start New Game";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(102, 151);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 22);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load Game";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // pnlSizeSelect
            // 
            this.pnlSizeSelect.Controls.Add(this.btnStartLarge);
            this.pnlSizeSelect.Controls.Add(this.btnStartMedium);
            this.pnlSizeSelect.Controls.Add(this.btnStartSmall);
            this.pnlSizeSelect.Location = new System.Drawing.Point(90, 87);
            this.pnlSizeSelect.Name = "pnlSizeSelect";
            this.pnlSizeSelect.Size = new System.Drawing.Size(98, 86);
            this.pnlSizeSelect.TabIndex = 2;
            this.pnlSizeSelect.Visible = false;
            // 
            // btnStartSmall
            // 
            this.btnStartSmall.Location = new System.Drawing.Point(0, 0);
            this.btnStartSmall.Name = "btnStartSmall";
            this.btnStartSmall.Size = new System.Drawing.Size(95, 23);
            this.btnStartSmall.TabIndex = 0;
            this.btnStartSmall.Text = "Small 20x20";
            this.btnStartSmall.UseVisualStyleBackColor = true;
            this.btnStartSmall.Click += new System.EventHandler(this.btnStartSmall_Click);
            // 
            // btnStartMedium
            // 
            this.btnStartMedium.Location = new System.Drawing.Point(0, 29);
            this.btnStartMedium.Name = "btnStartMedium";
            this.btnStartMedium.Size = new System.Drawing.Size(95, 23);
            this.btnStartMedium.TabIndex = 1;
            this.btnStartMedium.Text = "Medium 25x25";
            this.btnStartMedium.UseVisualStyleBackColor = true;
            this.btnStartMedium.Click += new System.EventHandler(this.btnStartMedium_Click);
            // 
            // btnStartLarge
            // 
            this.btnStartLarge.Location = new System.Drawing.Point(0, 58);
            this.btnStartLarge.Name = "btnStartLarge";
            this.btnStartLarge.Size = new System.Drawing.Size(95, 23);
            this.btnStartLarge.TabIndex = 2;
            this.btnStartLarge.Text = "Large 30x30";
            this.btnStartLarge.UseVisualStyleBackColor = true;
            this.btnStartLarge.Click += new System.EventHandler(this.btnStartLarge_Click);
            // 
            // LevelSelectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.pnlSizeSelect);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnStart);
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
    }
}

