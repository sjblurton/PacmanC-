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
            this.pbGhostRed = new System.Windows.Forms.PictureBox();
            this.redTimer = new System.Windows.Forms.Timer(this.components);
            this.redMovmentTimer = new System.Windows.Forms.Timer(this.components);
            this.pbGhostPink = new System.Windows.Forms.PictureBox();
            this.pinkTimer = new System.Windows.Forms.Timer(this.components);
            this.pinkMovmentTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGhostRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGhostPink)).BeginInit();
            this.SuspendLayout();
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Transparent;
            this.player.Image = ((System.Drawing.Image)(resources.GetObject("player.Image")));
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
            // redTimer
            // 
            this.redTimer.Enabled = true;
            this.redTimer.Interval = 25;
            this.redTimer.Tick += new System.EventHandler(this.redTimer_Tick);
            // 
            // redMovmentTimer
            // 
            this.redMovmentTimer.Enabled = true;
            this.redMovmentTimer.Interval = 25;
            this.redMovmentTimer.Tick += new System.EventHandler(this.redMovmenTimer_Tick);
            // 
            // pbGhostPink
            // 
            this.pbGhostPink.Image = global::Pacman.Properties.Resources.GPD;
            this.pbGhostPink.Location = new System.Drawing.Point(215, 230);
            this.pbGhostPink.Name = "pbGhostPink";
            this.pbGhostPink.Size = new System.Drawing.Size(18, 20);
            this.pbGhostPink.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbGhostPink.TabIndex = 3;
            this.pbGhostPink.TabStop = false;
            // 
            // pinkTimer
            // 
            this.pinkTimer.Enabled = true;
            this.pinkTimer.Interval = 25;
            this.pinkTimer.Tick += new System.EventHandler(this.pinkTimer_Tick);
            // 
            // pinkMovmentTimer
            // 
            this.pinkMovmentTimer.Enabled = true;
            this.pinkMovmentTimer.Interval = 25;
            this.pinkMovmentTimer.Tick += new System.EventHandler(this.pinkMovmentTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(470, 514);
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
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGhostRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGhostPink)).EndInit();
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
        private System.Windows.Forms.PictureBox pbGhostRed;
        private System.Windows.Forms.Timer redTimer;
        private System.Windows.Forms.Timer redMovmentTimer;
        private System.Windows.Forms.PictureBox pbGhostPink;
        private System.Windows.Forms.Timer pinkTimer;
        private System.Windows.Forms.Timer pinkMovmentTimer;
    }
}

