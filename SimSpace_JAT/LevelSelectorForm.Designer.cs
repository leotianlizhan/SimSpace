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
            this.btnBack = new System.Windows.Forms.Button();
            this.btnStartLarge = new System.Windows.Forms.Button();
            this.btnStartMedium = new System.Windows.Forms.Button();
            this.btnStartSmall = new System.Windows.Forms.Button();
            this.pnlLevelSelector = new System.Windows.Forms.Panel();
            this.btnCredits = new System.Windows.Forms.Button();
            this.picLogoText = new System.Windows.Forms.PictureBox();
            this.pnlSizeSelect.SuspendLayout();
            this.pnlLevelSelector.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoText)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.SystemColors.Control;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(3, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(175, 50);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "NEW GAME";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            this.btnStart.MouseEnter += new System.EventHandler(this.btnStart_MouseEnter);
            this.btnStart.MouseLeave += new System.EventHandler(this.btnStart_MouseLeave);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.SystemColors.Control;
            this.btnLoad.FlatAppearance.BorderSize = 0;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Location = new System.Drawing.Point(3, 58);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(175, 50);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "LOAD GAME";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            this.btnLoad.MouseEnter += new System.EventHandler(this.btnLoad_MouseEnter);
            this.btnLoad.MouseLeave += new System.EventHandler(this.btnLoad_MouseLeave);
            // 
            // pnlSizeSelect
            // 
            this.pnlSizeSelect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlSizeSelect.Controls.Add(this.btnBack);
            this.pnlSizeSelect.Controls.Add(this.btnStartLarge);
            this.pnlSizeSelect.Controls.Add(this.btnStartMedium);
            this.pnlSizeSelect.Controls.Add(this.btnStartSmall);
            this.pnlSizeSelect.Location = new System.Drawing.Point(90, 240);
            this.pnlSizeSelect.Name = "pnlSizeSelect";
            this.pnlSizeSelect.Size = new System.Drawing.Size(180, 240);
            this.pnlSizeSelect.TabIndex = 2;
            this.pnlSizeSelect.Visible = false;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.Control;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(3, 188);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(175, 50);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "PREVIOUS MENU";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnStartLarge
            // 
            this.btnStartLarge.BackColor = System.Drawing.SystemColors.Control;
            this.btnStartLarge.FlatAppearance.BorderSize = 0;
            this.btnStartLarge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartLarge.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartLarge.ForeColor = System.Drawing.Color.White;
            this.btnStartLarge.Location = new System.Drawing.Point(3, 115);
            this.btnStartLarge.Name = "btnStartLarge";
            this.btnStartLarge.Size = new System.Drawing.Size(175, 50);
            this.btnStartLarge.TabIndex = 2;
            this.btnStartLarge.Text = "LARGE (30x30)";
            this.btnStartLarge.UseVisualStyleBackColor = false;
            this.btnStartLarge.Click += new System.EventHandler(this.btnStartLarge_Click);
            // 
            // btnStartMedium
            // 
            this.btnStartMedium.BackColor = System.Drawing.SystemColors.Control;
            this.btnStartMedium.FlatAppearance.BorderSize = 0;
            this.btnStartMedium.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartMedium.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartMedium.ForeColor = System.Drawing.Color.White;
            this.btnStartMedium.Location = new System.Drawing.Point(3, 59);
            this.btnStartMedium.Name = "btnStartMedium";
            this.btnStartMedium.Size = new System.Drawing.Size(175, 50);
            this.btnStartMedium.TabIndex = 1;
            this.btnStartMedium.Text = "MEDIUM (25x25)";
            this.btnStartMedium.UseVisualStyleBackColor = false;
            this.btnStartMedium.Click += new System.EventHandler(this.btnStartMedium_Click);
            this.btnStartMedium.MouseEnter += new System.EventHandler(this.btnStartMedium_MouseEnter);
            this.btnStartMedium.MouseLeave += new System.EventHandler(this.btnStartMedium_MouseLeave);
            // 
            // btnStartSmall
            // 
            this.btnStartSmall.BackColor = System.Drawing.SystemColors.Control;
            this.btnStartSmall.FlatAppearance.BorderSize = 0;
            this.btnStartSmall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartSmall.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartSmall.ForeColor = System.Drawing.Color.White;
            this.btnStartSmall.Location = new System.Drawing.Point(3, 3);
            this.btnStartSmall.Name = "btnStartSmall";
            this.btnStartSmall.Size = new System.Drawing.Size(175, 50);
            this.btnStartSmall.TabIndex = 0;
            this.btnStartSmall.Text = "SMALL (20x20)";
            this.btnStartSmall.UseVisualStyleBackColor = false;
            this.btnStartSmall.Click += new System.EventHandler(this.btnStartSmall_Click);
            this.btnStartSmall.MouseEnter += new System.EventHandler(this.btnStartSmall_MouseEnter);
            this.btnStartSmall.MouseLeave += new System.EventHandler(this.btnStartSmall_MouseLeave);
            // 
            // pnlLevelSelector
            // 
            this.pnlLevelSelector.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlLevelSelector.Controls.Add(this.btnCredits);
            this.pnlLevelSelector.Controls.Add(this.btnStart);
            this.pnlLevelSelector.Controls.Add(this.btnLoad);
            this.pnlLevelSelector.Location = new System.Drawing.Point(90, 240);
            this.pnlLevelSelector.Name = "pnlLevelSelector";
            this.pnlLevelSelector.Size = new System.Drawing.Size(180, 240);
            this.pnlLevelSelector.TabIndex = 3;
            // 
            // btnCredits
            // 
            this.btnCredits.BackColor = System.Drawing.SystemColors.Control;
            this.btnCredits.FlatAppearance.BorderSize = 0;
            this.btnCredits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCredits.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCredits.ForeColor = System.Drawing.Color.White;
            this.btnCredits.Location = new System.Drawing.Point(3, 187);
            this.btnCredits.Name = "btnCredits";
            this.btnCredits.Size = new System.Drawing.Size(175, 50);
            this.btnCredits.TabIndex = 2;
            this.btnCredits.Text = "CREDITS";
            this.btnCredits.UseVisualStyleBackColor = false;
            this.btnCredits.MouseEnter += new System.EventHandler(this.btnCredits_MouseEnter);
            this.btnCredits.MouseLeave += new System.EventHandler(this.btnCredits_MouseLeave);
            // 
            // picLogoText
            // 
            this.picLogoText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picLogoText.BackColor = System.Drawing.Color.Transparent;
            this.picLogoText.Image = global::SimSpace_JAT.Properties.Resources.simspacejat_logoplusbluetext;
            this.picLogoText.Location = new System.Drawing.Point(37, 34);
            this.picLogoText.Name = "picLogoText";
            this.picLogoText.Size = new System.Drawing.Size(280, 200);
            this.picLogoText.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogoText.TabIndex = 4;
            this.picLogoText.TabStop = false;
            // 
            // LevelSelectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(344, 501);
            this.Controls.Add(this.pnlSizeSelect);
            this.Controls.Add(this.picLogoText);
            this.Controls.Add(this.pnlLevelSelector);
            this.Name = "LevelSelectorForm";
            this.Text = "Sim Space";
            this.pnlSizeSelect.ResumeLayout(false);
            this.pnlLevelSelector.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogoText)).EndInit();
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
        private System.Windows.Forms.Panel pnlLevelSelector;
        private System.Windows.Forms.Button btnCredits;
        private System.Windows.Forms.PictureBox picLogoText;
    }
}

