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

        int[] waypointsX = new int[10] { 23, 52, 102, 152, 200, 248, 294, 342, 392, 422 };
        /*
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
*/
        int[] waypointsY = new int[] { 20, 85, 133, 180, 230, 280, 325, 375, 420, 470 };
        int PlayerSpeed = 1;
        int score = 0;

        #endregion

        #region on start up

        public Form1()
        {
            InitializeComponent();
            Settings.playerDirection = Directions.Stop;
            placeCoin();
        }

        #endregion

        #region Finding player game engine

        private void gameEngineTimer_Tick(object sender, EventArgs e)
        {

            #region Left to right movment on the board for the player on the Y axses

            //checking if player is inbetween waypoints
            //all left to rights TODO THE CROSS OVER!!!
            //Row Y 9 left to right
            if ((player.Top == waypointsY[9])
                && ((player.Left > waypointsX[0] && player.Left < waypointsX[4])
                || (player.Left > waypointsX[4] && player.Left < waypointsX[5])
                || (player.Left > waypointsX[5] && player.Left < waypointsX[9])))
                MovePlayerLR();
            //Row Y 8 left to right
            else if ((player.Top == waypointsY[8])
                && ((player.Left > waypointsX[0] && player.Left < waypointsX[1])
                || (player.Left > waypointsX[1] && player.Left < waypointsX[2])
                || (player.Left > waypointsX[3] && player.Left < waypointsX[4])
                || (player.Left > waypointsX[5] && player.Left < waypointsX[6])
                || (player.Left > waypointsX[7] && player.Left < waypointsX[8])
                || (player.Left > waypointsX[8] && player.Left < waypointsX[9])))
                MovePlayerLR();
            //Row Y 7 left to right
            else if ((player.Top == waypointsY[7])
                && ((player.Left > waypointsX[0] && player.Left < waypointsX[1])
                || (player.Left > waypointsX[2] && player.Left < waypointsX[3])
                || (player.Left > waypointsX[3] && player.Left < waypointsX[4])
                || (player.Left > waypointsX[4] && player.Left < waypointsX[5])
                || (player.Left > waypointsX[5] && player.Left < waypointsX[6])
                || (player.Left > waypointsX[6] && player.Left < waypointsX[7])
                || (player.Left > waypointsX[8] && player.Left < waypointsX[9])))
                MovePlayerLR();
            //Row Y 6 left to right
            else if ((player.Top == waypointsY[6])
                && ((player.Left > waypointsX[0] && player.Left < waypointsX[2])
                || (player.Left > waypointsX[2] && player.Left < waypointsX[3])
                || (player.Left > waypointsX[3] && player.Left < waypointsX[4])
                || (player.Left > waypointsX[5] && player.Left < waypointsX[6])
                || (player.Left > waypointsX[6] && player.Left < waypointsX[7])
                || (player.Left > waypointsX[7] && player.Left < waypointsX[9])))
                MovePlayerLR();
            //Row Y 5 left to right
            else if ((player.Top == waypointsY[5])
                && ((player.Left > waypointsX[3] && player.Left < waypointsX[6])))
                MovePlayerLR();
            //Row Y 4 left to right
            else if ((player.Top == waypointsY[4])
                && ((player.Left > waypointsX[2] && player.Left < waypointsX[3])
                || (player.Left > -20 && player.Left < waypointsX[2]) //the cross over
                || (player.Left > waypointsX[6] && player.Left < waypointsX[7])
                || (player.Left > waypointsX[7] && player.Left < 470))) //the cross over
                MovePlayerLR();
            //Row Y 3 left to right
            else if ((player.Top == waypointsY[3])
                && ((player.Left > waypointsX[3] && player.Left < waypointsX[4])
                || (player.Left > waypointsX[4] && player.Left < waypointsX[5])
                || (player.Left > waypointsX[5] && player.Left < waypointsX[6])))
                MovePlayerLR();
            //Row Y 2 left to right
            else if ((player.Top == waypointsY[2])
                && ((player.Left > waypointsX[0] && player.Left < waypointsX[2])
                || (player.Left > waypointsX[3] && player.Left < waypointsX[4])
                || (player.Left > waypointsX[5] && player.Left < waypointsX[6])
                || (player.Left > waypointsX[7] && player.Left < waypointsX[9])))
                MovePlayerLR();
            //Row Y  1 left to right
            else if ((player.Top == waypointsY[1])
                && ((player.Left > waypointsX[0] && player.Left < waypointsX[2])
                || (player.Left > waypointsX[2] && player.Left < waypointsX[3])
                || (player.Left > waypointsX[3] && player.Left < waypointsX[4])
                || (player.Left > waypointsX[4] && player.Left < waypointsX[5])
                || (player.Left > waypointsX[5] && player.Left < waypointsX[6])
                || (player.Left > waypointsX[6] && player.Left < waypointsX[7])
                || (player.Left > waypointsX[7] && player.Left < waypointsX[9])))
                MovePlayerLR();
            //Row Y  0 left to right
            else if ((player.Top == waypointsY[0])
                && ((player.Left > waypointsX[0] && player.Left < waypointsX[2])
                || (player.Left > waypointsX[2] && player.Left < waypointsX[4])
                || (player.Left > waypointsX[4] && player.Left < waypointsX[5])
                || (player.Left > waypointsX[5] && player.Left < waypointsX[7])
                || (player.Left > waypointsX[7] && player.Left < waypointsX[9])))
                MovePlayerLR();
            // The Cross over left to right
            else if (((player.Top == waypointsY[4]) && (player.Left == -20)) && (Settings.playerDirection == Directions.Left))
            {
                player.Left = 470;
            }
            // The Cross over left to right
            else if (((player.Top == waypointsY[4]) && (player.Left == 470)) && (Settings.playerDirection == Directions.Right))
            {
                player.Left = -20;

            }




            #endregion

            #region Up and down movment on the board for the player on the X axses

            //all the ups to downs on X axses
            //Up and down X axses column 0 & 9
            else if (((player.Left == waypointsX[0]) || (player.Left == waypointsX[9]))
                && ((player.Top > waypointsY[0] && player.Top < waypointsY[1])
                || (player.Top > waypointsY[1] && player.Top < waypointsY[2])
                || (player.Top > waypointsY[6] && player.Top < waypointsY[7])
                || (player.Top > waypointsY[8] && player.Top < waypointsY[9])))
                MovePlayerUD();
            //Up and down X axses column 1 & 8
            else if (((player.Left == waypointsX[1]) || (player.Left == waypointsX[8]))
                && ((player.Top > waypointsY[7] && player.Top < waypointsY[8])))
                MovePlayerUD();
            //Up and down X axses column 2 & 7
            else if (((player.Left == waypointsX[2]) || (player.Left == waypointsX[7]))
                && ((player.Top > waypointsY[0] && player.Top < waypointsY[1])
                || (player.Top > waypointsY[1] && player.Top < waypointsY[2])
                || (player.Top > waypointsY[2] && player.Top < waypointsY[4])
                || (player.Top > waypointsY[4] && player.Top < waypointsY[6])
                || (player.Top > waypointsY[6] && player.Top < waypointsY[7])
                || (player.Top > waypointsY[7] && player.Top < waypointsY[8])))
                MovePlayerUD();
            //Up and down X axses column 3 & 6
            else if (((player.Left == waypointsX[3]) || (player.Left == waypointsX[6]))
                && ((player.Top > waypointsY[3] && player.Top < waypointsY[4])
                || (player.Top > waypointsY[4] && player.Top < waypointsY[5])
                || (player.Top > waypointsY[5] && player.Top < waypointsY[6])
                || (player.Top > waypointsY[7] && player.Top < waypointsY[8])))
                MovePlayerUD();
            //Up and down X axses column 4 & 5
            else if (((player.Left == waypointsX[4]) || (player.Left == waypointsX[5]))
                && ((player.Top > waypointsY[0] && player.Top < waypointsY[1])
                || (player.Top > waypointsY[2] && player.Top < waypointsY[3])
                || (player.Top > waypointsY[6] && player.Top < waypointsY[7])
                || (player.Top > waypointsY[8] && player.Top < waypointsY[9])))
                MovePlayerUD();
            else
                PlayerWhichWaypoint();

            #endregion


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
            if (e.KeyCode == Keys.Up)
            {
                Settings.playerDirection = Directions.Up;
            }
            if (e.KeyCode == Keys.Down)
            {
                Settings.playerDirection = Directions.Down;
            }
            if (e.KeyCode == Keys.Left)
            {
                Settings.playerDirection = Directions.Left;
            }
            if (e.KeyCode == Keys.Right)
            {
                Settings.playerDirection = Directions.Right;
            }
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
                     || (player.Top == waypointsY[2] && player.Left == waypointsX[4])
                     || (player.Top == waypointsY[3] && player.Left == waypointsX[6])
                     || (player.Top == waypointsY[6] && player.Left == waypointsX[4])
                     || (player.Top == waypointsY[6] && player.Left == waypointsX[9])
                     || (player.Top == waypointsY[7] && player.Left == waypointsX[1])
                     || (player.Top == waypointsY[8] && player.Left == waypointsX[9])
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
                     || (player.Top == waypointsY[9] && player.Left == waypointsX[9]))
            {
                stopMovingPlayer();
                MovePlayerLU();
            }
            //RU
            else if ((player.Top == waypointsY[2] && player.Left == waypointsX[0])
                     || (player.Top == waypointsY[2] && player.Left == waypointsX[3])
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
                     || (player.Top == waypointsY[1] && player.Left == waypointsX[3])
                     || (player.Top == waypointsY[1] && player.Left == waypointsX[6])
                     || (player.Top == waypointsY[7] && player.Left == waypointsX[6])
                     || (player.Top == waypointsY[7] && player.Left == waypointsX[3]))
            {
                stopMovingPlayer();
                MovePlayerLRD();
            }
            //RUD
            else if ((player.Top == waypointsY[1] && player.Left == waypointsX[0])
                     || (player.Top == waypointsY[2] && player.Left == waypointsX[7])
                     || (player.Top == waypointsY[4] && player.Left == waypointsX[6])
                     || (player.Top == waypointsY[5] && player.Left == waypointsX[3])
                     || (player.Top == waypointsY[7] && player.Left == waypointsX[2]))
            {
                stopMovingPlayer();
                MovePlayerRUD();
            }
            //LRU
            else if ((player.Top == waypointsY[1] && player.Left == waypointsX[4])
                     || (player.Top == waypointsY[1] && player.Left == waypointsX[5])
                     || (player.Top == waypointsY[3] && player.Left == waypointsX[4])
                     || (player.Top == waypointsY[3] && player.Left == waypointsX[5])
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
            else if ((player.Top == waypointsY[1] && player.Left == waypointsX[9])
                     || (player.Top == waypointsY[2] && player.Left == waypointsX[2])
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
                     || (player.Top == waypointsY[4] && player.Left == waypointsX[2])
                     || (player.Top == waypointsY[4] && player.Left == waypointsX[7])
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #region place the coins

        public void placeCoin()
        {
            int spacing = 15;
            int[] Y = new int[] { 30, 95, 140, 190, 240, 290, 335, 385, 430, 480 };


            int AStart = 50, AStop = 110, BStart = 130, BStop = 210,
                CStart = 170, CStop = 215, DStart = 130, DStop = 345,
                EStart= 270, EStop= 310, FStart = 270, FStop = 360,
                GStart = 370, GStop = 430;

            Circles bigOne1 = new Circles();
            bigOne1.coinLeft =31;
            bigOne1.coinTop = Y[7]-10;
            bigOne1.mkBig(this);
            Circles bigOne2 = new Circles();
            bigOne2.coinLeft = 31;
            bigOne2.coinTop = 55;
            bigOne2.mkBig(this);
            Circles bigOne3 = new Circles();
            bigOne3.coinLeft = 426;
            bigOne3.coinTop = Y[7] -10;
            bigOne3.mkBig(this);
            Circles bigOne4 = new Circles();
            bigOne4.coinLeft = 426;
            bigOne4.coinTop = 55;
            bigOne4.mkBig(this);


            //row 0
            for (int i = AStart; i < AStop; i+=spacing)
            {
                    Circles coin = new Circles();
                    coin.coinLeft = i ;
                    coin.coinTop = Y[0];
                    coin.mkCoin(this);
            }
            
            for (int i = BStart; i < BStop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = i;
                coin.coinTop = Y[0];
                coin.mkCoin(this);
            }
            for (int i = FStart; i < FStop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = i;
                coin.coinTop = Y[0];
                coin.mkCoin(this);
            }
            for (int i = GStart; i < GStop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = i;
                coin.coinTop = Y[0];
                coin.mkCoin(this);
            }
            //row 1
            for (int i = AStart; i < AStop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = i;
                coin.coinTop = Y[1];
                coin.mkCoin(this);
            }

            for (int i = DStart; i < DStop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = i;
                coin.coinTop = Y[1];
                coin.mkCoin(this);
            }
            for (int i = GStart; i < GStop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = i;
                coin.coinTop = Y[1];
                coin.mkCoin(this);
            }
            //row 2
            for (int i = AStart; i < AStop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = i;
                coin.coinTop = Y[2];
                coin.mkCoin(this);
            }

            for (int i = GStart; i < GStop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = i;
                coin.coinTop = Y[2];
                coin.mkCoin(this);
            }

            for (int i = CStart; i < CStop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = i;
                coin.coinTop = Y[2];
                coin.mkCoin(this);
            }

            for (int i = EStart; i < EStop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = i;
                coin.coinTop = Y[2];
                coin.mkCoin(this);
            }
            //row 6
            for (int i = AStart; i < AStop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = i;
                coin.coinTop = Y[6];
                coin.mkCoin(this);
            }
            for (int i = BStart; i < BStop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = i;
                coin.coinTop = Y[6];
                coin.mkCoin(this);
            }
            for (int i = FStart; i < FStop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = i;
                coin.coinTop = Y[6];
                coin.mkCoin(this);
            }
            for (int i = GStart; i < GStop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = i;
                coin.coinTop = Y[6];
                coin.mkCoin(this);
            }
            //row 7
            for (int i = DStart; i < DStop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = i;
                coin.coinTop = Y[7];
                coin.mkCoin(this);
            }
            //row 8
            for (int i = AStart; i < AStop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = i;
                coin.coinTop = Y[8];
                coin.mkCoin(this);
            }
            for (int i = CStart; i < CStop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = i;
                coin.coinTop = Y[8];
                coin.mkCoin(this);
            }
            for (int i = EStart; i < EStop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = i;
                coin.coinTop = Y[8];
                coin.mkCoin(this);
            }
            for (int i = GStart; i < GStop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = i;
                coin.coinTop = Y[8];
                coin.mkCoin(this);
            }
            //row 9
            for (int i = AStart; i < CStop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = i;
                coin.coinTop = Y[9];
                coin.mkCoin(this);
            }
            for (int i = EStart; i < GStop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = i;
                coin.coinTop = Y[9];
                coin.mkCoin(this);
            }
            //columns
            int Y1Start=430, Y1Stop=480, Y2Start = 335, Y2Stop =385,
                Y3Start = 380,Y3Stop= 420, Y4Start= 400,Y4Stop=430,
                Y5Start= 30,Y5Stop = 430, Y6Start= 30,Y6Stop = 140,
                Y7Start=110,Y7Stop=140, Y8Start = 30, Y8Stop = 85;
            int[] X = new int[] { 35, 60, 113, 160, 211, 255, 305, 355, 400, 430 };

            //column 0
            for (int i = Y1Start; i < Y1Stop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = X[0];
                coin.coinTop = i;
                coin.mkCoin(this);
            }
            for (int i = Y2Start; i < Y2Stop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = X[0];
                coin.coinTop = i;
                coin.mkCoin(this);
            }
            for (int i = Y6Start; i < Y6Stop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = X[0];
                coin.coinTop = i;
                coin.mkCoin(this);
            }
            //column 1
            for (int i = Y3Start; i < Y3Stop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = X[1];
                coin.coinTop = i;
                coin.mkCoin(this);
            }
            //column 2
            for (int i = Y5Start; i < Y5Stop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = X[2];
                coin.coinTop = i;
                coin.mkCoin(this);
            }
            //column 3
            for (int i = Y4Start; i < Y4Stop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = X[3];
                coin.coinTop = i;
                coin.mkCoin(this);
            }
            for (int i = Y7Start; i < Y7Stop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = X[3];
                coin.coinTop = i;
                coin.mkCoin(this);
            }
            //column 4
            for (int i = Y1Start; i < Y1Stop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = X[4];
                coin.coinTop = i;
                coin.mkCoin(this);
            }
            for (int i = Y2Start; i < Y2Stop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = X[4];
                coin.coinTop = i;
                coin.mkCoin(this);
            }

            for (int i = Y8Start; i < Y8Stop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = X[4];
                coin.coinTop = i;
                coin.mkCoin(this);
            }
            //column 5
            for (int i = Y1Start; i < Y1Stop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = X[5];
                coin.coinTop = i;
                coin.mkCoin(this);
            }
            for (int i = Y2Start; i < Y2Stop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = X[5];
                coin.coinTop = i;
                coin.mkCoin(this);
            }

            for (int i = Y8Start; i < Y8Stop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = X[5];
                coin.coinTop = i;
                coin.mkCoin(this);
            }
            //column 6
            for (int i = Y4Start; i < Y4Stop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = X[6];
                coin.coinTop = i;
                coin.mkCoin(this);
            }
            for (int i = Y7Start; i < Y7Stop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = X[6];
                coin.coinTop = i;
                coin.mkCoin(this);
            }
            //column 7
            for (int i = Y5Start; i < Y5Stop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = X[7];
                coin.coinTop = i;
                coin.mkCoin(this);
            }
            //column 8
            for (int i = Y3Start; i < Y3Stop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = X[8];
                coin.coinTop = i;
                coin.mkCoin(this);
            }
            //column 9
            for (int i = Y1Start; i < Y1Stop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = X[9];
                coin.coinTop = i;
                coin.mkCoin(this);
            }
            for (int i = Y2Start; i < Y2Stop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = X[9];
                coin.coinTop = i;
                coin.mkCoin(this);
            }
            for (int i = Y6Start; i < Y6Stop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = X[9];
                coin.coinTop = i;
                coin.mkCoin(this);
            }

        }

        #endregion

        #region player colecting points

        int coinCount = 0;
        bool youWin = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!youWin)
            {

                if ((player.Image != Properties.Resources.PlayerR) && Settings.playerDirection == Directions.Right)
                    player.Image = Properties.Resources.PlayerR;
                else if ((player.Image != Properties.Resources.PlayerL) && Settings.playerDirection == Directions.Left)
                    player.Image = Properties.Resources.PlayerL;
                else if ((player.Image != Properties.Resources.PlayerU) && Settings.playerDirection == Directions.Up)
                    player.Image = Properties.Resources.PlayerU;
                else if ((player.Image != Properties.Resources.PlayerD) && Settings.playerDirection == Directions.Down)
                    player.Image = Properties.Resources.PlayerD;


                lbScore.Text = "Score:\n" + score;

                //inside the second loop adding j verible to controls
                foreach (Control j in this.Controls)
                {//to identify coins to collect
                    if ((j is PictureBox && j.Tag == "coin"))
                    {
                        if (player.Bounds.IntersectsWith(j.Bounds))
                        {
                            coinCount++;
                            score += 10;
                            this.Controls.Remove(j);
                            j.Dispose();
                            if (coinCount == 254)
                                youWin = true;
                        }
                    }
                }

            }
            if (youWin)
            {
                YouWin();
            }

        }

        private void YouWin()
        {

        }

        #endregion

        #region ghoast timers

        private void ghostTimer1_Tick(object sender, EventArgs e)
        {

        }

        private void ghostTimer2_Tick(object sender, EventArgs e)
        {

        }

        private void ghostTimer3_Tick(object sender, EventArgs e)
        {

        }

        private void ghostTimer4_Tick(object sender, EventArgs e)
        {

        }

        #endregion
    }
}

    
