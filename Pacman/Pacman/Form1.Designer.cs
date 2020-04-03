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
            this.gameEngineTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // player
            // 
            this.player.Image = global::Pacman.Properties.Resources.PlayerL;
            this.player.Location = new System.Drawing.Point(420, 470);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(22, 22);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.player.TabIndex = 0;
            this.player.TabStop = false;
            // 
            // playTimerR
            // 
            this.playTimerR.Interval = 50;
            this.playTimerR.Tick += new System.EventHandler(this.playTmerR_Tick);
            // 
            // playTimerL
            // 
            this.playTimerL.Interval = 50;
            this.playTimerL.Tick += new System.EventHandler(this.playTimerL_Tick);
            // 
            // playTimerU
            // 
            this.playTimerU.Interval = 50;
            this.playTimerU.Tick += new System.EventHandler(this.playTimerU_Tick);
            // 
            // playTimerD
            // 
            this.playTimerD.Interval = 50;
            this.playTimerD.Tick += new System.EventHandler(this.playTimerD_Tick);
            // 
            // gameEngineTimer
            // 
            this.gameEngineTimer.Enabled = true;
            this.gameEngineTimer.Interval = 50;
            this.gameEngineTimer.Tick += new System.EventHandler(this.gameEngineTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::Pacman.Properties.Resources.Maze;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(470, 514);
            this.Controls.Add(this.player);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "Pacman";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Timer playTimerR;
        private System.Windows.Forms.Timer playTimerL;
        private System.Windows.Forms.Timer playTimerU;
        private System.Windows.Forms.Timer playTimerD;
        private System.Windows.Forms.Timer gameEngineTimer;
    }
}

