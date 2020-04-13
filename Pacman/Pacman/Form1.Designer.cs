namespace Pacman
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.player = new System.Windows.Forms.PictureBox();
            this.findPlayerEngineTimer = new System.Windows.Forms.Timer(this.components);
            this.lbScore = new System.Windows.Forms.Label();
            this.pbGhostRed = new System.Windows.Forms.PictureBox();
            this.ghostTimer = new System.Windows.Forms.Timer(this.components);
            this.pbGhostPink = new System.Windows.Forms.PictureBox();
            this.pbGhostBlue = new System.Windows.Forms.PictureBox();
            this.pbGhostOrange = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGhostRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGhostPink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGhostBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGhostOrange)).BeginInit();
            this.SuspendLayout();
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Transparent;
            this.player.Image = ((System.Drawing.Image)(resources.GetObject("player.Image")));
            this.player.Location = new System.Drawing.Point(226, 376);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(22, 22);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.player.TabIndex = 0;
            this.player.TabStop = false;
            // 
            // findPlayerEngineTimer
            // 
            this.findPlayerEngineTimer.Enabled = true;
            this.findPlayerEngineTimer.Interval = 75;
            this.findPlayerEngineTimer.Tick += new System.EventHandler(this.gameEngineTimer_Tick);
            // 
            // lbScore
            // 
            this.lbScore.AutoSize = true;
            this.lbScore.BackColor = System.Drawing.Color.Transparent;
            this.lbScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbScore.ForeColor = System.Drawing.Color.White;
            this.lbScore.Location = new System.Drawing.Point(13, 171);
            this.lbScore.Name = "lbScore";
            this.lbScore.Size = new System.Drawing.Size(55, 20);
            this.lbScore.TabIndex = 1;
            this.lbScore.Text = "Score:";
            // 
            // pbGhostRed
            // 
            this.pbGhostRed.Image = global::Pacman.Properties.Resources.GRD;
            this.pbGhostRed.Location = new System.Drawing.Point(240, 230);
            this.pbGhostRed.Name = "pbGhostRed";
            this.pbGhostRed.Size = new System.Drawing.Size(18, 20);
            this.pbGhostRed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbGhostRed.TabIndex = 2;
            this.pbGhostRed.TabStop = false;
            // 
            // ghostTimer
            // 
            this.ghostTimer.Enabled = true;
            this.ghostTimer.Interval = 75;
            this.ghostTimer.Tick += new System.EventHandler(this.ghostTimer_Tick);
            // 
            // pbGhostPink
            // 
            this.pbGhostPink.Image = global::Pacman.Properties.Resources.GPD;
            this.pbGhostPink.Location = new System.Drawing.Point(214, 230);
            this.pbGhostPink.Name = "pbGhostPink";
            this.pbGhostPink.Size = new System.Drawing.Size(18, 20);
            this.pbGhostPink.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbGhostPink.TabIndex = 3;
            this.pbGhostPink.TabStop = false;
            // 
            // pbGhostBlue
            // 
            this.pbGhostBlue.Image = global::Pacman.Properties.Resources.GBD;
            this.pbGhostBlue.Location = new System.Drawing.Point(264, 230);
            this.pbGhostBlue.Name = "pbGhostBlue";
            this.pbGhostBlue.Size = new System.Drawing.Size(18, 20);
            this.pbGhostBlue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbGhostBlue.TabIndex = 4;
            this.pbGhostBlue.TabStop = false;
            // 
            // pbGhostOrange
            // 
            this.pbGhostOrange.Image = global::Pacman.Properties.Resources.GOD;
            this.pbGhostOrange.Location = new System.Drawing.Point(190, 230);
            this.pbGhostOrange.Name = "pbGhostOrange";
            this.pbGhostOrange.Size = new System.Drawing.Size(18, 20);
            this.pbGhostOrange.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbGhostOrange.TabIndex = 5;
            this.pbGhostOrange.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(470, 514);
            this.Controls.Add(this.pbGhostOrange);
            this.Controls.Add(this.pbGhostBlue);
            this.Controls.Add(this.pbGhostPink);
            this.Controls.Add(this.pbGhostRed);
            this.Controls.Add(this.lbScore);
            this.Controls.Add(this.player);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Pacman";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyIsDown);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGhostRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGhostPink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGhostBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGhostOrange)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Timer findPlayerEngineTimer;
        private System.Windows.Forms.Label lbScore;
        private System.Windows.Forms.PictureBox pbGhostRed;
        private System.Windows.Forms.Timer ghostTimer;
        private System.Windows.Forms.PictureBox pbGhostPink;
        private System.Windows.Forms.PictureBox pbGhostBlue;
        private System.Windows.Forms.PictureBox pbGhostOrange;
    }
}

