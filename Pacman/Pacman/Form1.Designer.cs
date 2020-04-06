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
            this.playTimerR = new System.Windows.Forms.Timer(this.components);
            this.playTimerL = new System.Windows.Forms.Timer(this.components);
            this.playTimerU = new System.Windows.Forms.Timer(this.components);
            this.playTimerD = new System.Windows.Forms.Timer(this.components);
            this.findPlayerEngineTimer = new System.Windows.Forms.Timer(this.components);
            this.collectingPoints = new System.Windows.Forms.Timer(this.components);
            this.lbScore = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.ghostTimer1 = new System.Windows.Forms.Timer(this.components);
            this.ghostTimer2 = new System.Windows.Forms.Timer(this.components);
            this.ghostTimer3 = new System.Windows.Forms.Timer(this.components);
            this.ghostTimer4 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Transparent;
            this.player.Image = global::Pacman.Properties.Resources.PlayerL;
            this.player.Location = new System.Drawing.Point(225, 375);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(22, 22);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.player.TabIndex = 0;
            this.player.TabStop = false;
            // 
            // playTimerR
            // 
            this.playTimerR.Interval = 1;
            this.playTimerR.Tick += new System.EventHandler(this.playTmerR_Tick);
            // 
            // playTimerL
            // 
            this.playTimerL.Interval = 1;
            this.playTimerL.Tick += new System.EventHandler(this.playTimerL_Tick);
            // 
            // playTimerU
            // 
            this.playTimerU.Interval = 1;
            this.playTimerU.Tick += new System.EventHandler(this.playTimerU_Tick);
            // 
            // playTimerD
            // 
            this.playTimerD.Interval = 1;
            this.playTimerD.Tick += new System.EventHandler(this.playTimerD_Tick);
            // 
            // findPlayerEngineTimer
            // 
            this.findPlayerEngineTimer.Enabled = true;
            this.findPlayerEngineTimer.Interval = 1;
            this.findPlayerEngineTimer.Tick += new System.EventHandler(this.gameEngineTimer_Tick);
            // 
            // collectingPoints
            // 
            this.collectingPoints.Enabled = true;
            this.collectingPoints.Interval = 150;
            this.collectingPoints.Tick += new System.EventHandler(this.timer1_Tick);
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
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Pacman.Properties.Resources.G3D;
            this.pictureBox1.Location = new System.Drawing.Point(240, 233);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(18, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Pacman.Properties.Resources.G1D;
            this.pictureBox2.Location = new System.Drawing.Point(264, 233);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(18, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Pacman.Properties.Resources.G2D;
            this.pictureBox3.Location = new System.Drawing.Point(192, 233);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(18, 20);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Pacman.Properties.Resources.G4D;
            this.pictureBox4.Location = new System.Drawing.Point(216, 233);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(18, 20);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 5;
            this.pictureBox4.TabStop = false;
            // 
            // ghostTimer1
            // 
            this.ghostTimer1.Tick += new System.EventHandler(this.ghostTimer1_Tick);
            // 
            // ghostTimer2
            // 
            this.ghostTimer2.Tick += new System.EventHandler(this.ghostTimer2_Tick);
            // 
            // ghostTimer3
            // 
            this.ghostTimer3.Tick += new System.EventHandler(this.ghostTimer3_Tick);
            // 
            // ghostTimer4
            // 
            this.ghostTimer4.Tick += new System.EventHandler(this.ghostTimer4_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::Pacman.Properties.Resources.Maze;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(470, 514);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbScore);
            this.Controls.Add(this.player);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Pacman";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Timer playTimerR;
        private System.Windows.Forms.Timer playTimerL;
        private System.Windows.Forms.Timer playTimerU;
        private System.Windows.Forms.Timer playTimerD;
        private System.Windows.Forms.Timer findPlayerEngineTimer;
        private System.Windows.Forms.Timer collectingPoints;
        private System.Windows.Forms.Label lbScore;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Timer ghostTimer1;
        private System.Windows.Forms.Timer ghostTimer2;
        private System.Windows.Forms.Timer ghostTimer3;
        private System.Windows.Forms.Timer ghostTimer4;
    }
}

