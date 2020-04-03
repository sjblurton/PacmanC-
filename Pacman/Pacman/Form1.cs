using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    public partial class Form1 : Form
    {

        #region Veribles

        int[] waypointsX = new int[10] { 20, 50, 100, 150, 195, 245, 290, 340, 390, 420 };

        int[] waypointsmainX = new int[100]   { 20,500,100,500,195,245,500,340,500,420,
                                            20,500,100,500,195,245,500,340,500,420,
                                            20,500,100,150,195,245,290,340,500,420,
                                            500,500,500,150,195,245,290,500,500,500,
                                            500,500,100,150,500,500,290,340,500,500,
                                            500,500,500,150,500,500,290,500,500,500,
                                            20,500,100,150,195,245,290,340,500,420,
                                            20,50,100,150,195,245,290,340,390,420,
                                            20,50,100,150,195,245,290,340,390,420,
                                            20,500,500,500,195,245,500,500,500,420 };

        int[] waypointsY = new int[] { 20, 85, 130, 180, 230, 280, 325, 375, 420, 470 };
        int PlayerSpeed = 5;

        #endregion

        #region on start up

        public Form1()
        {
            InitializeComponent();
            Settings.playerDirection = Directions.Left;
        }

        #endregion

        #region main game engine

        private void gameEngineTimer_Tick(object sender, EventArgs e)
        {
            //checking if player is inbetween waypoints
            //TODO: finish all left to rights, and ups to downs. also the cross over
            if ((player.Top == waypointsY[9]) && (player.Left > waypointsX[0] && player.Left < waypointsX[4])
                || (player.Left > waypointsX[4] && player.Left < waypointsX[5])
                || (player.Left > waypointsX[5] && player.Left < waypointsX[9]))
                MovePlayerLR();
            else
                PlayerWhichWaypoint();
        }

        #endregion

        #region player movment timers

        private void playTmerR_Tick(object sender, EventArgs e)
        {
            if (Settings.playerDirection == Directions.Right)
                player.Left += PlayerSpeed;
            else playTimerR.Stop();
        }

        private void playTimerL_Tick(object sender, EventArgs e)
        {
            if (Settings.playerDirection == Directions.Left)
                player.Left -= PlayerSpeed;
                player.Image = Properties.Resources.PlayerL;
            else playTimerL.Stop();
        }

        private void playTimerU_Tick(object sender, EventArgs e)
        {
            if (Settings.playerDirection == Directions.Up)
                player.Top -= PlayerSpeed;
            else playTimerU.Stop();
        }

        private void playTimerD_Tick(object sender, EventArgs e)
        {
            if (Settings.playerDirection == Directions.Down)
                player.Top += PlayerSpeed;
            else playTimerD.Stop();
        }

        #endregion

        #region key inputs

        private void keyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) { Settings.playerDirection = Directions.Up; player.Image = Properties.Resources.PlayerU; }
            if (e.KeyCode == Keys.Down) { Settings.playerDirection = Directions.Down; player.Image = Properties.Resources.PlayerD;}
            if (e.KeyCode == Keys.Left) { Settings.playerDirection = Directions.Left; player.Image = Properties.Resources.PlayerL; }
            if (e.KeyCode == Keys.Right) { Settings.playerDirection = Directions.Right; player.Image = Properties.Resources.PlayerR; }
        }

        private void keyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) { Settings.playerDirection = Directions.Up; }
            if (e.KeyCode == Keys.Down) { Settings.playerDirection = Directions.Down; }
            if (e.KeyCode == Keys.Left) { Settings.playerDirection = Directions.Left; }
            if (e.KeyCode == Keys.Right) { Settings.playerDirection = Directions.Right; }
        }

        #endregion

        #region checking which waypoint the player is at

        public void PlayerWhichWaypoint()
        {
            //checking the which waypoint
            //RD
            if ((player.Top == waypointsY[0] && player.Left == waypointsX[0])
                || (player.Top == waypointsY[0] && player.Left == waypointsX[5])
                || (player.Top == waypointsY[3] && player.Left == waypointsX[3])
                || (player.Top == waypointsY[2] && player.Left == waypointsX[5])
                || (player.Top == waypointsY[6] && player.Left == waypointsX[0])
                || (player.Top == waypointsY[6] && player.Left == waypointsX[5])
                || (player.Top == waypointsY[7] && player.Left == waypointsX[8])
                || (player.Top == waypointsY[8] && player.Left == waypointsX[0])
                || (player.Top == waypointsY[8] && player.Left == waypointsX[5]))
            {
                stopMovingPlayer();
                MovePlayerRD();
            }
            //LD
       else if ((player.Top == waypointsY[0] && player.Left == waypointsX[4])
                || (player.Top == waypointsY[0] && player.Left == waypointsX[9])
                || (player.Top == waypointsY[2] && player.Left == waypointsX[3])
                || (player.Top == waypointsY[2] && player.Left == waypointsX[4])
                || (player.Top == waypointsY[3] && player.Left == waypointsX[5])
                || (player.Top == waypointsY[3] && player.Left == waypointsX[6])
                || (player.Top == waypointsY[6] && player.Left == waypointsX[4])
                || (player.Top == waypointsY[6] && player.Left == waypointsX[9])
                || (player.Top == waypointsY[7] && player.Left == waypointsX[1])
                || (player.Top == waypointsY[8] && player.Left == waypointsX[4]))
            {
                stopMovingPlayer();
                MovePlayerLD();
            }
            //LU
       else if ((player.Top == waypointsY[2] && player.Left == waypointsX[6])
                || (player.Top == waypointsY[2] && player.Left == waypointsX[9])
                || (player.Top == waypointsY[7] && player.Left == waypointsX[9])
                || (player.Top == waypointsY[8] && player.Left == waypointsX[2])
                || (player.Top == waypointsY[8] && player.Left == waypointsX[6])
                || (player.Top == waypointsY[8] && player.Left == waypointsX[9])
                || (player.Top == waypointsY[9] && player.Left == waypointsX[9]))
            {
                stopMovingPlayer();
                MovePlayerLU();
            }
            //RU
       else if ((player.Top == waypointsY[1] && player.Left == waypointsX[9])
                || (player.Top == waypointsY[2] && player.Left == waypointsX[2])
                || (player.Top == waypointsY[7] && player.Left == waypointsX[0])
                || (player.Top == waypointsY[8] && player.Left == waypointsX[3])
                || (player.Top == waypointsY[8] && player.Left == waypointsX[7])
                || (player.Top == waypointsY[9] && player.Left == waypointsX[0]))
            {
                stopMovingPlayer();
                MovePlayerRU();
            }
            //LRD
       else if ((player.Top == waypointsY[0] && player.Left == waypointsX[2])
                || (player.Top == waypointsY[0] && player.Left == waypointsX[7])
                || (player.Top == waypointsY[7] && player.Left == waypointsX[6]))
            {
                stopMovingPlayer();
                MovePlayerLRD();
            }
            //RUD
       else if ((player.Top == waypointsY[1] && player.Left == waypointsX[0])
                || (player.Top == waypointsY[2] && player.Left == waypointsX[7])
                || (player.Top == waypointsY[4] && player.Left == waypointsX[6])
                || (player.Top == waypointsY[4] && player.Left == waypointsX[7])
                || (player.Top == waypointsY[5] && player.Left == waypointsX[3])
                || (player.Top == waypointsY[7] && player.Left == waypointsX[2])
                || (player.Top == waypointsY[7] && player.Left == waypointsX[3]))
            {
                stopMovingPlayer();
                MovePlayerRUD();
            }
            //LRU
       else if( (player.Top == waypointsY[1] && player.Left == waypointsX[4])
                || (player.Top == waypointsY[1] && player.Left == waypointsX[5])
                || (player.Top == waypointsY[3] && player.Left == waypointsX[4])
                || (player.Top == waypointsY[6] && player.Left == waypointsX[3])
                || (player.Top == waypointsY[6] && player.Left == waypointsX[6])
                || (player.Top == waypointsY[7] && player.Left == waypointsX[4])
                || (player.Top == waypointsY[7] && player.Left == waypointsX[5])
                || (player.Top == waypointsY[8] && player.Left == waypointsX[1])
                || (player.Top == waypointsY[8] && player.Left == waypointsX[8])
                || (player.Top == waypointsY[9] && player.Left == waypointsX[4])
                || (player.Top == waypointsY[9] && player.Left == waypointsX[5]))
            {
                stopMovingPlayer();
                MovePlayerLRU();
            }
            //LUD
       else if ((player.Top == waypointsY[2] && player.Left == waypointsX[0])
                || (player.Top == waypointsY[4] && player.Left == waypointsX[2])
                || (player.Top == waypointsY[4] && player.Left == waypointsX[3])
                || (player.Top == waypointsY[5] && player.Left == waypointsX[6])
                || (player.Top == waypointsY[7] && player.Left == waypointsX[7]))
            {
                stopMovingPlayer();
                MovePlayerLUD();
            }
            //LRUD
       else if ((player.Top == waypointsY[1] && player.Left == waypointsX[2])
                || (player.Top == waypointsY[1] && player.Left == waypointsX[7])
                || (player.Top == waypointsY[6] && player.Left == waypointsX[2])
                || (player.Top == waypointsY[6] && player.Left == waypointsX[7]))
            {
                stopMovingPlayer();
                MovePlayerLRUD();
            }
         
        }

        #endregion

        #region Moving player methods

        private void stopMovingPlayer()
        {
            playTimerR.Stop();
            playTimerD.Stop();
            playTimerU.Stop();
            playTimerL.Stop();
            Settings.playerDirection = Directions.Stop;
        }
        public void MovePlayerLRUD()
        {
            playTimerL.Start();
            playTimerR.Start();
            playTimerU.Start();
            playTimerD.Start();
        }
        public void MovePlayerLRU()
        {
            playTimerL.Start();
            playTimerR.Start();
            playTimerU.Start();
        }
        public void MovePlayerLRD()
        {
            playTimerL.Start();
            playTimerR.Start();
            playTimerD.Start();
        }
        public void MovePlayerLUD()
        {
            playTimerL.Start();
            playTimerU.Start();
            playTimerD.Start();
        }
        public void MovePlayerRUD()
        {
            playTimerR.Start();
            playTimerU.Start();
            playTimerD.Start();
        }
        public void MovePlayerLD()
        {
            playTimerL.Start();
            playTimerD.Start();
        }
        public void MovePlayerLU()
        {
            playTimerL.Start();
            playTimerU.Start();
        }
        public void MovePlayerRU()
        {
            playTimerR.Start();
            playTimerU.Start();
        }
        public void MovePlayerRD()
        {
            playTimerR.Start();
            playTimerD.Start();
        }
        public void MovePlayerLR()
        {
            playTimerL.Start();
            playTimerR.Start();
        }
        public void MovePlayerUD()
        {
            playTimerU.Start();
            playTimerD.Start();
        }

        #endregion
    }
}

    
