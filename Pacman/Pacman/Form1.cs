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

        int[] waypointsX = new int[10] { 24, 52, 104, 152, 200, 248, 294, 342, 392, 422 };
        int[] waypointsY = new int[] { 20, 86, 134, 180, 230, 280, 326, 376, 420, 470 };
        int PlayerSpeed = 2;
        int score = 0;

        #endregion

        #region on start up

        public Form1()
        {
            InitializeComponent();
            placeCoin();
            keyLeft = true;
        }

        #endregion

        #region Player Game Engine Timer

        private void gameEngineTimer_Tick(object sender, EventArgs e)
        {
            CollectingPoints();

            if (Settings.playerDirection == Directions.Left || Settings.playerDirection == Directions.Right)
            {
                playerRightLeftMovment();
            }
            else if (Settings.playerDirection == Directions.Up || Settings.playerDirection == Directions.Down)
            {
                PlayerUpDownMovment();
            }


        }

        #endregion

        #region key inputs
        bool keyUp = false, keyDown = false, keyLeft = false, keyRight = false, UpDown = false, RightLeft = false;

        private void keyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                UpDown = true;
                keyUp = true;
                keyDown = false;
                keyRight = false;
                keyLeft = false;
                if (keyUp)
                    player.Image = Properties.Resources.PlayerU;
            }
            if (e.KeyCode == Keys.Down)
            {
                UpDown = false;
                keyUp = false;
                keyDown = true;
                keyRight = false;
                keyLeft = false;
                if (keyDown)
                    player.Image = Properties.Resources.PlayerD;

            }
            if (e.KeyCode == Keys.Left)
            {
                RightLeft = false;
                keyUp = false;
                keyDown = false;
                keyRight = false;
                keyLeft = true;
                if (keyLeft)
                    player.Image = Properties.Resources.PlayerL;
            }
            if (e.KeyCode == Keys.Right)
            {
                RightLeft = true;
                keyUp = false;
                keyDown = false;
                keyRight = true;
                keyLeft = false;

            }

        }


        private void PlayerMovmentLeft()
        {
            Settings.playerDirection = Directions.Left;
            player.Left -= PlayerSpeed;
        }
        private void PlayerMovmentRight()
        {
            Settings.playerDirection = Directions.Right;
            player.Left += PlayerSpeed;
        }
        private void PlayerMovmentUp()
        {
            Settings.playerDirection = Directions.Up;
            player.Top -= PlayerSpeed;
        }
        private void PlayerMovmentDown()
        {
            Settings.playerDirection = Directions.Down;
            player.Top += PlayerSpeed;

        }
        private void PlayerMovmentStop()
        {
            Settings.playerDirection = Directions.Stop;
            player.Left += 0;
            player.Top += 0;


        }
        #endregion

        #region player moving inbetween the waypoints left-right, up-down

        private void PlayerUpDownMovment()
        {
            //all the ups to downs on X axses
            //Up and down X axses column 0 & 9
            if (((player.Left == waypointsX[0]) || (player.Left == waypointsX[9]))
                && ((player.Top > waypointsY[0] && player.Top < waypointsY[1])
                || (player.Top > waypointsY[1] && player.Top < waypointsY[2])
                || (player.Top > waypointsY[6] && player.Top < waypointsY[7])
                || (player.Top > waypointsY[8] && player.Top < waypointsY[9])))
            {
                MovePlayerUD();
            }
            //Up and down X axses column 1 & 8
            else if (((player.Left == waypointsX[1]) || (player.Left == waypointsX[8]))
                && ((player.Top > waypointsY[7] && player.Top < waypointsY[8])))
            {
                MovePlayerUD();
            }
            //Up and down X axses column 2 & 7
            else if (((player.Left == waypointsX[2]) || (player.Left == waypointsX[7]))
                && ((player.Top > waypointsY[0] && player.Top < waypointsY[1])
                || (player.Top > waypointsY[1] && player.Top < waypointsY[2])
                || (player.Top > waypointsY[2] && player.Top < waypointsY[4])
                || (player.Top > waypointsY[4] && player.Top < waypointsY[6])
                || (player.Top > waypointsY[6] && player.Top < waypointsY[7])
                || (player.Top > waypointsY[7] && player.Top < waypointsY[8])))
            {
                MovePlayerUD();
            }
            //Up and down X axses column 3 & 6
            else if (((player.Left == waypointsX[3]) || (player.Left == waypointsX[6]))
                && ((player.Top > waypointsY[1] && player.Top < waypointsX[3])
                || (player.Top > waypointsY[1] && player.Top < waypointsY[6])
                ||(player.Top > waypointsY[3] && player.Top < waypointsY[4])
                || (player.Top > waypointsY[4] && player.Top < waypointsY[5])
                || (player.Top > waypointsY[5] && player.Top < waypointsY[6])
                || (player.Top > waypointsY[7] && player.Top < waypointsY[8])))
            {
                MovePlayerUD();
            }
            //Up and down X axses column 4 & 5
            else if (((player.Left == waypointsX[4]) || (player.Left == waypointsX[5]))
                && ((player.Top > waypointsY[0] && player.Top < waypointsY[1])
                || (player.Top > waypointsY[2] && player.Top < waypointsY[3])
                || (player.Top > waypointsY[6] && player.Top < waypointsY[7])
                || (player.Top > waypointsY[8] && player.Top < waypointsY[9])))
            {
                MovePlayerUD();
            }
            else PlayerWhichWaypoint();

        }

        private void playerRightLeftMovment()
        {
            //checking if player is inbetween waypoints
            //Row Y 9 left to right
            if ((player.Top == waypointsY[9])
                && ((player.Left > waypointsX[0] && player.Left < waypointsX[4])
                || (player.Left > waypointsX[4] && player.Left < waypointsX[5])
                || (player.Left > waypointsX[5] && player.Left < waypointsX[9])))
            {
                MovePlayerLR();

            }
            //Row Y 8 left to right
            else if ((player.Top == waypointsY[8])
                && ((player.Left > waypointsX[0] && player.Left < waypointsX[1])
                || (player.Left > waypointsX[1] && player.Left < waypointsX[2])
                || (player.Left > waypointsX[3] && player.Left < waypointsX[4])
                || (player.Left > waypointsX[5] && player.Left < waypointsX[6])
                || (player.Left > waypointsX[7] && player.Left < waypointsX[8])
                || (player.Left > waypointsX[8] && player.Left < waypointsX[9])))
            {
                MovePlayerLR();

            }
            //Row Y 7 left to right
            else if ((player.Top == waypointsY[7])
                && ((player.Left > waypointsX[0] && player.Left < waypointsX[1])
                || (player.Left > waypointsX[2] && player.Left < waypointsX[3])
                || (player.Left > waypointsX[3] && player.Left < waypointsX[4])
                || (player.Left > waypointsX[4] && player.Left < waypointsX[5])
                || (player.Left > waypointsX[5] && player.Left < waypointsX[6])
                || (player.Left > waypointsX[6] && player.Left < waypointsX[7])
                || (player.Left > waypointsX[8] && player.Left < waypointsX[9])))
            {
                MovePlayerLR();

            }
            //Row Y 6 left to right
            else if ((player.Top == waypointsY[6])
                && ((player.Left > waypointsX[0] && player.Left < waypointsX[2])
                || (player.Left > waypointsX[2] && player.Left < waypointsX[3])
                || (player.Left > waypointsX[3] && player.Left < waypointsX[4])
                || (player.Left > waypointsX[5] && player.Left < waypointsX[6])
                || (player.Left > waypointsX[6] && player.Left < waypointsX[7])
                || (player.Left > waypointsX[7] && player.Left < waypointsX[9])))
            {
                MovePlayerLR();

            }
            //Row Y 5 left to right
            else if ((player.Top == waypointsY[5])
                && ((player.Left > waypointsX[3] && player.Left < waypointsX[6])))
            {
                MovePlayerLR();

            }
            //Row Y 4 left to right
            else if ((player.Top == waypointsY[4])
                && ((player.Left > waypointsX[2] && player.Left < waypointsX[3])
                || (player.Left > -20 && player.Left < waypointsX[2]) //the cross over
                || (player.Left > waypointsX[6] && player.Left < waypointsX[7])
                || (player.Left > waypointsX[7] && player.Left < 470))) //the cross over
            {
                MovePlayerLR();

            }
            //Row Y 3 left to right
            else if ((player.Top == waypointsY[3])
                && ((player.Left > waypointsX[3] && player.Left < waypointsX[4])
                || (player.Left > waypointsX[4] && player.Left < waypointsX[5])
                || (player.Left > waypointsX[5] && player.Left < waypointsX[6])))
            {
                MovePlayerLR();

            }
            //Row Y 2 left to right
            else if ((player.Top == waypointsY[2])
                && ((player.Left > waypointsX[0] && player.Left < waypointsX[2])
                || (player.Left > waypointsX[3] && player.Left < waypointsX[4])
                || (player.Left > waypointsX[5] && player.Left < waypointsX[6])
                || (player.Left > waypointsX[7] && player.Left < waypointsX[9])))
            {
                MovePlayerLR();

            }
            //Row Y  1 left to right
            else if ((player.Top == waypointsY[1])
                && ((player.Left > waypointsX[0] && player.Left < waypointsX[2])
                || (player.Left > waypointsX[2] && player.Left < waypointsX[3])
                || (player.Left > waypointsX[3] && player.Left < waypointsX[4])
                || (player.Left > waypointsX[4] && player.Left < waypointsX[5])
                || (player.Left > waypointsX[5] && player.Left < waypointsX[6])
                || (player.Left > waypointsX[6] && player.Left < waypointsX[7])
                || (player.Left > waypointsX[7] && player.Left < waypointsX[9])))
            {
                MovePlayerLR();
            }

            //Row Y  0 left to right
            else if ((player.Top == waypointsY[0])
                && ((player.Left > waypointsX[0] && player.Left < waypointsX[2])
                || (player.Left > waypointsX[2] && player.Left < waypointsX[4])
                || (player.Left > waypointsX[4] && player.Left < waypointsX[5])
                || (player.Left > waypointsX[5] && player.Left < waypointsX[7])
                || (player.Left > waypointsX[7] && player.Left < waypointsX[9])))
            {
                MovePlayerLR();
            }

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
            else PlayerWhichWaypoint();

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
                MovePlayerLRD();
            }
            //RUD
            else if ((player.Top == waypointsY[1] && player.Left == waypointsX[0])
                     || (player.Top == waypointsY[2] && player.Left == waypointsX[7])
                     || (player.Top == waypointsY[4] && player.Left == waypointsX[6])
                     || (player.Top == waypointsY[5] && player.Left == waypointsX[3])
                     || (player.Top == waypointsY[7] && player.Left == waypointsX[2]))
            {
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
                MovePlayerLRU();
            }
            //LUD
            else if ((player.Top == waypointsY[1] && player.Left == waypointsX[9])
                     || (player.Top == waypointsY[2] && player.Left == waypointsX[2])
                     || (player.Top == waypointsY[4] && player.Left == waypointsX[3])
                     || (player.Top == waypointsY[5] && player.Left == waypointsX[6])
                     || (player.Top == waypointsY[7] && player.Left == waypointsX[7]))
            {
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
                MovePlayerLRUD();
            }

        }

        #endregion

        #region Moving player methods at waypoints, and inbetween

        public void MovePlayerLRUD()
        {
            PlayerMovmentStop();

            if (keyLeft)
            {
                PlayerMovmentLeft();
                player.Image = Properties.Resources.PlayerL;
            }

            else if (keyRight)
            {
                PlayerMovmentRight();
                player.Image = Properties.Resources.PlayerR;
            }

            else if (keyUp)
            {
                PlayerMovmentUp();
                player.Image = Properties.Resources.PlayerU;
            }

            else if (keyDown)
            {
                PlayerMovmentDown();
                player.Image = Properties.Resources.PlayerD;
            }
            else
                PlayerMovmentStop();
        }
        public void MovePlayerLRU()
        {
            PlayerMovmentStop();

            if (keyLeft)
            {
                PlayerMovmentLeft();
                player.Image = Properties.Resources.PlayerL;
            }
            else if (keyRight)
            {
                PlayerMovmentRight();
                player.Image = Properties.Resources.PlayerR;
            }
            else if (keyUp)
            {
                PlayerMovmentUp();
                player.Image = Properties.Resources.PlayerU;
            }
            else
                PlayerMovmentStop();
       }
        public void MovePlayerLRD()
        {
            PlayerMovmentStop();

            if (keyLeft)
            {
                PlayerMovmentLeft();
                player.Image = Properties.Resources.PlayerL;
            }
            else if (keyRight)
            {
                PlayerMovmentRight();
                player.Image = Properties.Resources.PlayerR;
            }
            else if (keyDown)
            {
                PlayerMovmentDown();
                player.Image = Properties.Resources.PlayerD;
            }
            else
                PlayerMovmentStop();
        }
        public void MovePlayerLUD()
        {
            PlayerMovmentStop();

            if (keyLeft)
            {
                PlayerMovmentLeft();
                player.Image = Properties.Resources.PlayerL;
            }
            else if (keyUp)
            {
                PlayerMovmentUp();
                player.Image = Properties.Resources.PlayerU;
            }
            else if (keyDown)
            {
                PlayerMovmentDown();
                player.Image = Properties.Resources.PlayerD;
            }
            else
                PlayerMovmentStop();
        }
        public void MovePlayerRUD()
        {
            PlayerMovmentStop();

            if (keyRight)
            {
                PlayerMovmentRight();
                player.Image = Properties.Resources.PlayerR;
            }
            else if (keyUp)
            {
                PlayerMovmentUp();
                player.Image = Properties.Resources.PlayerU;
            }
            else if (keyDown)
            {
                PlayerMovmentDown();
                player.Image = Properties.Resources.PlayerD;
            }
            else
                PlayerMovmentStop();
        }
        public void MovePlayerLD()
        {
            PlayerMovmentStop();

            if (keyLeft)
            {
                PlayerMovmentLeft();
                player.Image = Properties.Resources.PlayerL;
            }
            else if (keyDown)
            {
                PlayerMovmentDown();
                player.Image = Properties.Resources.PlayerD;
            }
            else
                PlayerMovmentStop();

        }
        public void MovePlayerLU()
        {
            PlayerMovmentStop();

            if (keyLeft)
            {
                PlayerMovmentLeft();
                player.Image = Properties.Resources.PlayerL;
            }
            else if (keyUp)
            {
                PlayerMovmentUp();
                player.Image = Properties.Resources.PlayerU;
            }
            else
                PlayerMovmentStop();
        }
        public void MovePlayerRU()
        {
            PlayerMovmentStop();

            if (keyRight)
            {
                PlayerMovmentRight();
                player.Image = Properties.Resources.PlayerR;
            }
            else if (keyUp)
            {
                PlayerMovmentUp();
                player.Image = Properties.Resources.PlayerU;
            }
            else
                PlayerMovmentStop();
        }
        public void MovePlayerRD()
        {
            PlayerMovmentStop();
            if (keyRight)
            {
                PlayerMovmentRight();
                player.Image = Properties.Resources.PlayerR;
            }
            else if (keyDown)
            {
                PlayerMovmentDown();
                player.Image = Properties.Resources.PlayerD;
            }
            else
                PlayerMovmentStop();
        }

        //To move inbetween the way points and to change direction quickly

        public void MovePlayerLR()
        {
            if (RightLeft)
            {
                PlayerMovmentRight();
                if (player.Image == Properties.Resources.PlayerL)
                {
                    player.Image = Properties.Resources.PlayerR;
                }
            }
            else if (!RightLeft)
            {
                PlayerMovmentLeft();
                if (player.Image == Properties.Resources.PlayerR)
                {
                    player.Image = Properties.Resources.PlayerL;
                }
            }
        }
        public void MovePlayerUD()
        {
            if (UpDown)
            {
                PlayerMovmentUp();
                if (player.Image == Properties.Resources.PlayerD)
                {
                    player.Image = Properties.Resources.PlayerU;
                }
            }
            else if (!UpDown)
            {
                PlayerMovmentDown();
                if (player.Image == Properties.Resources.PlayerU)
                {
                    player.Image = Properties.Resources.PlayerD;
                }
            }

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

        private void CollectingPoints()
        {
            if (!youWin)
            {
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
            throw new NotImplementedException();
        }



        #endregion

        #region Ghost Timers
        bool chase = false;
        bool scatter = false;
        bool frightened = false;
        bool dead = false;
        bool redInHouse = true;
        bool pinkInHouse = true;
        bool blueInHouse = true;
        bool orangeInHouse = true;
        int ghostSpeed = 2;


        private void ghostTimer_Tick(object sender, EventArgs e)
        {

            RedMovmentMethod();

            PinkMovmentMethod();

            BlueMovmentMethod();

            OrangeMovmentMethod();

            if (redInHouse || pinkInHouse || blueInHouse || orangeInHouse)
            {
                GhostsInHouse();
            }
            if (!redInHouse && scatter)
            {
                    GhostAtWaypointTrue("redGhost");
                    ghostScatter("redScatter");
            }
            if (!pinkInHouse && scatter)
            {
                    GhostAtWaypointTrue("pinkGhost");
                    ghostScatter("pinkScatter");
            }
            if (!blueInHouse && scatter)
            {
                    GhostAtWaypointTrue("blueGhost");
                    ghostScatter("blueScatter");
            }
            if (!orangeInHouse && scatter)
            {
                    GhostAtWaypointTrue("orangeGhost");
                    ghostScatter("orangeScatter");
            }


        }


        #endregion

        #region Ghost Movment Methods
        private void OrangeMovmentMethod()
        {
            if (Settings.GhostOrangeDirection == Directions.Up)
            {
                pbGhostOrange.Image = Properties.Resources.GOU;
                pbGhostOrange.Top -= ghostSpeed;
            }
            else if (Settings.GhostOrangeDirection == Directions.Down)
            {
                pbGhostOrange.Image = Properties.Resources.GOD;
                pbGhostOrange.Top += ghostSpeed;
            }
            else if (Settings.GhostOrangeDirection == Directions.Left)
            {
                pbGhostOrange.Image = Properties.Resources.GOL;
                pbGhostOrange.Left -= ghostSpeed;
            }
            else if (Settings.GhostOrangeDirection == Directions.Right)
            {
                pbGhostOrange.Image = Properties.Resources.GOR;
                pbGhostOrange.Left += ghostSpeed;
            }
            else if (Settings.GhostOrangeDirection == Directions.Stop)
            {
                pbGhostOrange.Image = Properties.Resources.GOD;
                pbGhostOrange.Left += 0;
                pbGhostOrange.Top += 0;

            }
        }

        private void BlueMovmentMethod()
        {
            if (Settings.GhostBlueDirection == Directions.Up)
            {
                pbGhostBlue.Image = Properties.Resources.GBU;
                pbGhostBlue.Top -= ghostSpeed;
            }
            else if (Settings.GhostBlueDirection == Directions.Down)
            {
                pbGhostBlue.Image = Properties.Resources.GBD;
                pbGhostBlue.Top += ghostSpeed;
            }
            else if (Settings.GhostBlueDirection == Directions.Left)
            {
                pbGhostBlue.Image = Properties.Resources.GBL;
                pbGhostBlue.Left -= ghostSpeed;
            }
            else if (Settings.GhostBlueDirection == Directions.Right)
            {
                pbGhostBlue.Image = Properties.Resources.GBR;
                pbGhostBlue.Left += ghostSpeed;
            }
            else if (Settings.GhostBlueDirection == Directions.Stop)
            {
                pbGhostBlue.Image = Properties.Resources.GBD;
                pbGhostBlue.Left += 0;
                pbGhostBlue.Top += 0;

            }
        }

        private void PinkMovmentMethod()
        {
            if (Settings.GhostPinkDirection == Directions.Up)
            {
                pbGhostPink.Image = Properties.Resources.GPU;
                pbGhostPink.Top -= ghostSpeed;
            }
            else if (Settings.GhostPinkDirection == Directions.Down)
            {
                pbGhostPink.Image = Properties.Resources.GPD;
                pbGhostPink.Top += ghostSpeed;
            }
            else if (Settings.GhostPinkDirection == Directions.Left)
            {
                pbGhostPink.Image = Properties.Resources.GPL;
                pbGhostPink.Left -= ghostSpeed;
            }
            else if (Settings.GhostPinkDirection == Directions.Right)
            {
                pbGhostPink.Image = Properties.Resources.GPR;
                pbGhostPink.Left += ghostSpeed;
            }
            else if (Settings.GhostPinkDirection == Directions.Stop)
            {
                pbGhostPink.Image = Properties.Resources.GPD;
                pbGhostPink.Left += 0;
                pbGhostPink.Top += 0;

            }
        }

        private void RedMovmentMethod()
        {
            if (Settings.GhostRedDirection == Directions.Up)
            {
                pbGhostRed.Image = Properties.Resources.GRU;
                pbGhostRed.Top -= ghostSpeed;
            }
            else if (Settings.GhostRedDirection == Directions.Down)
            {
                pbGhostRed.Image = Properties.Resources.GRD;
                pbGhostRed.Top += ghostSpeed;
            }
            else if (Settings.GhostRedDirection == Directions.Left)
            {
                pbGhostRed.Image = Properties.Resources.GRL;
                pbGhostRed.Left -= ghostSpeed;
            }
            else if (Settings.GhostRedDirection == Directions.Right)
            {
                pbGhostRed.Image = Properties.Resources.GRR;
                pbGhostRed.Left += ghostSpeed;
            }
            else if (Settings.GhostRedDirection == Directions.Stop)
            {
                pbGhostRed.Image = Properties.Resources.GRD;
                pbGhostRed.Left += 0;
                pbGhostRed.Top += 0;
            }
        }
        #endregion

        #region GhostAtWaypointTrue

        //Red ghost is at a checkpoint true or false
        bool redMoveRD = false, redMoveLD = false, redMoveLU = false, redMoveRU = false,
            redMoveLRD = false, redMoveRUD = false, redMoveLRU = false, redMoveLUD = false, redMoveLRUD = false;

        bool pinkMoveRD = false, pinkMoveLD = false, pinkMoveLU = false, pinkMoveRU = false,
            pinkMoveLRD = false, pinkMoveRUD = false, pinkMoveLRU = false, pinkMoveLUD = false, pinkMoveLRUD = false;

        bool blueMoveRD = false, blueMoveLD = false, blueMoveLU = false, blueMoveRU = false,
            blueMoveLRD = false, blueMoveRUD = false, blueMoveLRU = false, blueMoveLUD = false, blueMoveLRUD = false;

        bool orangeMoveRD = false, orangeMoveLD = false, orangeMoveLU = false, orangeMoveRU = false,
            orangeMoveLRD = false, orangeMoveRUD = false, orangeMoveLRU = false, orangeMoveLUD = false, orangeMoveLRUD = false;


        private void GhostAtWaypointTrue(string ghost)
        {
            switch (ghost)
            {
                case "redGhost":
                    //checking the which waypoint
                    //RD
                    if ((pbGhostRed.Top == waypointsY[0] && pbGhostRed.Left == waypointsX[0])
                            || (pbGhostRed.Top == waypointsY[0] && pbGhostRed.Left == waypointsX[5])
                            || (pbGhostRed.Top == waypointsY[3] && pbGhostRed.Left == waypointsX[3])
                            || (pbGhostRed.Top == waypointsY[2] && pbGhostRed.Left == waypointsX[5])
                            || (pbGhostRed.Top == waypointsY[6] && pbGhostRed.Left == waypointsX[0])
                            || (pbGhostRed.Top == waypointsY[6] && pbGhostRed.Left == waypointsX[5])
                            || (pbGhostRed.Top == waypointsY[7] && pbGhostRed.Left == waypointsX[8])
                            || (pbGhostRed.Top == waypointsY[8] && pbGhostRed.Left == waypointsX[0])
                            || (pbGhostRed.Top == waypointsY[8] && pbGhostRed.Left == waypointsX[5]))
                    {
                        redMoveRD = true;
                        redMoveLD = false; redMoveLU = false; redMoveRU = false; redMoveLRD = false;
                        redMoveRUD = false; redMoveLRU = false; redMoveLUD = false; redMoveLRUD = false;
                    }
                    //LD
                    else if ((pbGhostRed.Top == waypointsY[0] && pbGhostRed.Left == waypointsX[4])
                                  || (pbGhostRed.Top == waypointsY[0] && pbGhostRed.Left == waypointsX[9])
                                  || (pbGhostRed.Top == waypointsY[2] && pbGhostRed.Left == waypointsX[4])
                                  || (pbGhostRed.Top == waypointsY[3] && pbGhostRed.Left == waypointsX[6])
                                  || (pbGhostRed.Top == waypointsY[6] && pbGhostRed.Left == waypointsX[4])
                                  || (pbGhostRed.Top == waypointsY[6] && pbGhostRed.Left == waypointsX[9])
                                  || (pbGhostRed.Top == waypointsY[7] && pbGhostRed.Left == waypointsX[1])
                                  || (pbGhostRed.Top == waypointsY[8] && pbGhostRed.Left == waypointsX[9])
                                  || (pbGhostRed.Top == waypointsY[8] && pbGhostRed.Left == waypointsX[4]))
                    {
                        redMoveLD = true;
                        redMoveRD = false; redMoveLU = false; redMoveRU = false; redMoveLRD = false;
                        redMoveRUD = false; redMoveLRU = false; redMoveLUD = false; redMoveLRUD = false;

                    }
                    //LU
                    else if ((pbGhostRed.Top == waypointsY[2] && pbGhostRed.Left == waypointsX[6])
                                  || (pbGhostRed.Top == waypointsY[2] && pbGhostRed.Left == waypointsX[9])
                                  || (pbGhostRed.Top == waypointsY[7] && pbGhostRed.Left == waypointsX[9])
                                  || (pbGhostRed.Top == waypointsY[8] && pbGhostRed.Left == waypointsX[2])
                                  || (pbGhostRed.Top == waypointsY[8] && pbGhostRed.Left == waypointsX[6])
                                  || (pbGhostRed.Top == waypointsY[9] && pbGhostRed.Left == waypointsX[9]))
                    {
                        redMoveLU = true;
                        redMoveRD = false; redMoveLD = false; redMoveRU = false; redMoveLRD = false;
                        redMoveRUD = false; redMoveLRU = false; redMoveLUD = false; redMoveLRUD = false;

                    }
                    //RU
                    else if ((pbGhostRed.Top == waypointsY[2] && pbGhostRed.Left == waypointsX[0])
                                  || (pbGhostRed.Top == waypointsY[2] && pbGhostRed.Left == waypointsX[3])
                                  || (pbGhostRed.Top == waypointsY[7] && pbGhostRed.Left == waypointsX[0])
                                  || (pbGhostRed.Top == waypointsY[8] && pbGhostRed.Left == waypointsX[3])
                                  || (pbGhostRed.Top == waypointsY[8] && pbGhostRed.Left == waypointsX[7])
                                  || (pbGhostRed.Top == waypointsY[9] && pbGhostRed.Left == waypointsX[0]))
                    {
                        redMoveRU = true;
                        redMoveRD = false; redMoveLD = false; redMoveLU = false; redMoveLRD = false;
                        redMoveRUD = false; redMoveLRU = false; redMoveLUD = false; redMoveLRUD = false;

                    }
                    //LRD
                    else if ((pbGhostRed.Top == waypointsY[0] && pbGhostRed.Left == waypointsX[2])
                                  || (pbGhostRed.Top == waypointsY[0] && pbGhostRed.Left == waypointsX[7])
                                  || (pbGhostRed.Top == waypointsY[1] && pbGhostRed.Left == waypointsX[3])
                                  || (pbGhostRed.Top == waypointsY[1] && pbGhostRed.Left == waypointsX[6])
                                  || (pbGhostRed.Top == waypointsY[7] && pbGhostRed.Left == waypointsX[6])
                                  || (pbGhostRed.Top == waypointsY[7] && pbGhostRed.Left == waypointsX[3]))
                    {
                        redMoveLRD = true;
                        redMoveRD = false; redMoveLD = false; redMoveLU = false; redMoveRU = false; 
                        redMoveRUD = false; redMoveLRU = false; redMoveLUD = false; redMoveLRUD = false;

                    }
                    //RUD
                    else if ((pbGhostRed.Top == waypointsY[1] && pbGhostRed.Left == waypointsX[0])
                                  || (pbGhostRed.Top == waypointsY[2] && pbGhostRed.Left == waypointsX[7])
                                  || (pbGhostRed.Top == waypointsY[4] && pbGhostRed.Left == waypointsX[6])
                                  || (pbGhostRed.Top == waypointsY[5] && pbGhostRed.Left == waypointsX[3])
                                  || (pbGhostRed.Top == waypointsY[7] && pbGhostRed.Left == waypointsX[2]))
                    {
                        redMoveRUD = true;
                        redMoveRD = false; redMoveLD = false; redMoveLU = false; redMoveRU = false; redMoveLRD = false;
                         redMoveLRU = false; redMoveLUD = false; redMoveLRUD = false;

                    }
                    //LRU
                    else if ((pbGhostRed.Top == waypointsY[1] && pbGhostRed.Left == waypointsX[4])
                                  || (pbGhostRed.Top == waypointsY[1] && pbGhostRed.Left == waypointsX[5])
                                  || (pbGhostRed.Top == waypointsY[3] && pbGhostRed.Left == waypointsX[4])
                                  || (pbGhostRed.Top == waypointsY[6] && pbGhostRed.Left == waypointsX[3])
                                  || (pbGhostRed.Top == waypointsY[6] && pbGhostRed.Left == waypointsX[6])
                                  || (pbGhostRed.Top == waypointsY[7] && pbGhostRed.Left == waypointsX[4])
                                  || (pbGhostRed.Top == waypointsY[7] && pbGhostRed.Left == waypointsX[5])
                                  || (pbGhostRed.Top == waypointsY[8] && pbGhostRed.Left == waypointsX[1])
                                  || (pbGhostRed.Top == waypointsY[8] && pbGhostRed.Left == waypointsX[8])
                                  || (pbGhostRed.Top == waypointsY[9] && pbGhostRed.Left == waypointsX[4])
                                  || (pbGhostRed.Top == waypointsY[9] && pbGhostRed.Left == waypointsX[5]))
                    {
                        redMoveLRU = true;
                        redMoveRD = false; redMoveLD = false; redMoveLU = false; redMoveRU = false; redMoveLRD = false;
                        redMoveRUD = false; redMoveLUD = false; redMoveLRUD = false;

                    }
                    //LUD
                    else if ((pbGhostRed.Top == waypointsY[1] && pbGhostRed.Left == waypointsX[9])
                                  || (pbGhostRed.Top == waypointsY[2] && pbGhostRed.Left == waypointsX[2])
                                  || (pbGhostRed.Top == waypointsY[4] && pbGhostRed.Left == waypointsX[3])
                                  || (pbGhostRed.Top == waypointsY[5] && pbGhostRed.Left == waypointsX[6])
                                  || (pbGhostRed.Top == waypointsY[7] && pbGhostRed.Left == waypointsX[7]))
                    {
                        redMoveLUD = true;
                        redMoveRD = false; redMoveLD = false; redMoveLU = false; redMoveRU = false; redMoveLRD = false;
                        redMoveRUD = false; redMoveLRU = false; redMoveLRUD = false;


                    }
                    //LRUD
                    else if ((pbGhostRed.Top == waypointsY[1] && pbGhostRed.Left == waypointsX[2])
                                  || (pbGhostRed.Top == waypointsY[1] && pbGhostRed.Left == waypointsX[7])
                                  || (pbGhostRed.Top == waypointsY[4] && pbGhostRed.Left == waypointsX[2])
                                  || (pbGhostRed.Top == waypointsY[4] && pbGhostRed.Left == waypointsX[7])
                                  || (pbGhostRed.Top == waypointsY[6] && pbGhostRed.Left == waypointsX[2])
                                  || (pbGhostRed.Top == waypointsY[6] && pbGhostRed.Left == waypointsX[7]))
                    {
                        redMoveLRUD = true;
                        redMoveRD = false; redMoveLD = false; redMoveLU = false; redMoveRU = false; redMoveLRD = false;
                        redMoveRUD = false; redMoveLRU = false; redMoveLUD = false;

                    }
                    break;


                case "pinkGhost":
                    //checking the which waypoint
                    //RD
                    if ((pbGhostPink.Top == waypointsY[0] && pbGhostPink.Left == waypointsX[0])
                            || (pbGhostPink.Top == waypointsY[0] && pbGhostPink.Left == waypointsX[5])
                            || (pbGhostPink.Top == waypointsY[3] && pbGhostPink.Left == waypointsX[3])
                            || (pbGhostPink.Top == waypointsY[2] && pbGhostPink.Left == waypointsX[5])
                            || (pbGhostPink.Top == waypointsY[6] && pbGhostPink.Left == waypointsX[0])
                            || (pbGhostPink.Top == waypointsY[6] && pbGhostPink.Left == waypointsX[5])
                            || (pbGhostPink.Top == waypointsY[7] && pbGhostPink.Left == waypointsX[8])
                            || (pbGhostPink.Top == waypointsY[8] && pbGhostPink.Left == waypointsX[0])
                            || (pbGhostPink.Top == waypointsY[8] && pbGhostPink.Left == waypointsX[5]))
                    {
                        pinkMoveRD = true; pinkMoveLD = false; pinkMoveLU = false; pinkMoveRU = false;
                        pinkMoveLRD = false; pinkMoveRUD = false; pinkMoveLRU = false; pinkMoveLUD = false; pinkMoveLRUD = false;
                    }
                    //LD
                    else if ((pbGhostPink.Top == waypointsY[0] && pbGhostPink.Left == waypointsX[4])
                                  || (pbGhostPink.Top == waypointsY[0] && pbGhostPink.Left == waypointsX[9])
                                  || (pbGhostPink.Top == waypointsY[2] && pbGhostPink.Left == waypointsX[4])
                                  || (pbGhostPink.Top == waypointsY[3] && pbGhostPink.Left == waypointsX[6])
                                  || (pbGhostPink.Top == waypointsY[6] && pbGhostPink.Left == waypointsX[4])
                                  || (pbGhostPink.Top == waypointsY[6] && pbGhostPink.Left == waypointsX[9])
                                  || (pbGhostPink.Top == waypointsY[7] && pbGhostPink.Left == waypointsX[1])
                                  || (pbGhostPink.Top == waypointsY[8] && pbGhostPink.Left == waypointsX[9])
                                  || (pbGhostPink.Top == waypointsY[8] && pbGhostPink.Left == waypointsX[4]))
                    {
                        pinkMoveRD = false; pinkMoveLD = true; pinkMoveLU = false; pinkMoveRU = false;
                        pinkMoveLRD = false; pinkMoveRUD = false; pinkMoveLRU = false; pinkMoveLUD = false; pinkMoveLRUD = false;
                    }
                    //LU
                    else if ((pbGhostPink.Top == waypointsY[2] && pbGhostPink.Left == waypointsX[6])
                                  || (pbGhostPink.Top == waypointsY[2] && pbGhostPink.Left == waypointsX[9])
                                  || (pbGhostPink.Top == waypointsY[7] && pbGhostPink.Left == waypointsX[9])
                                  || (pbGhostPink.Top == waypointsY[8] && pbGhostPink.Left == waypointsX[2])
                                  || (pbGhostPink.Top == waypointsY[8] && pbGhostPink.Left == waypointsX[6])
                                  || (pbGhostPink.Top == waypointsY[9] && pbGhostPink.Left == waypointsX[9]))
                    {
                        pinkMoveRD = false; pinkMoveLD = false; pinkMoveLU = true; pinkMoveRU = false;
                        pinkMoveLRD = false; pinkMoveRUD = false; pinkMoveLRU = false; pinkMoveLUD = false; pinkMoveLRUD = false;
                    }
                    //RU
                    else if ((pbGhostPink.Top == waypointsY[2] && pbGhostPink.Left == waypointsX[0])
                                  || (pbGhostPink.Top == waypointsY[2] && pbGhostPink.Left == waypointsX[3])
                                  || (pbGhostPink.Top == waypointsY[7] && pbGhostPink.Left == waypointsX[0])
                                  || (pbGhostPink.Top == waypointsY[8] && pbGhostPink.Left == waypointsX[3])
                                  || (pbGhostPink.Top == waypointsY[8] && pbGhostPink.Left == waypointsX[7])
                                  || (pbGhostPink.Top == waypointsY[9] && pbGhostPink.Left == waypointsX[0]))
                    {
                        pinkMoveRD = false; pinkMoveLD = false; pinkMoveLU = false; pinkMoveRU = true;
                        pinkMoveLRD = false; pinkMoveRUD = false; pinkMoveLRU = false; pinkMoveLUD = false; pinkMoveLRUD = false;
                    }
                    //LRD
                    else if ((pbGhostPink.Top == waypointsY[0] && pbGhostPink.Left == waypointsX[2])
                                  || (pbGhostPink.Top == waypointsY[0] && pbGhostPink.Left == waypointsX[7])
                                  || (pbGhostPink.Top == waypointsY[1] && pbGhostPink.Left == waypointsX[3])
                                  || (pbGhostPink.Top == waypointsY[1] && pbGhostPink.Left == waypointsX[6])
                                  || (pbGhostPink.Top == waypointsY[7] && pbGhostPink.Left == waypointsX[6])
                                  || (pbGhostPink.Top == waypointsY[7] && pbGhostPink.Left == waypointsX[3]))
                    {
                        pinkMoveRD = false; pinkMoveLD = false; pinkMoveLU = false; pinkMoveRU = false;
                        pinkMoveLRD = true; pinkMoveRUD = false; pinkMoveLRU = false; pinkMoveLUD = false; pinkMoveLRUD = false;
                    }
                    //RUD
                    else if ((pbGhostPink.Top == waypointsY[1] && pbGhostPink.Left == waypointsX[0])
                                  || (pbGhostPink.Top == waypointsY[2] && pbGhostPink.Left == waypointsX[7])
                                  || (pbGhostPink.Top == waypointsY[4] && pbGhostPink.Left == waypointsX[6])
                                  || (pbGhostPink.Top == waypointsY[5] && pbGhostPink.Left == waypointsX[3])
                                  || (pbGhostPink.Top == waypointsY[7] && pbGhostPink.Left == waypointsX[2]))
                    {
                        pinkMoveRD = false; pinkMoveLD = false; pinkMoveLU = false; pinkMoveRU = false;
                        pinkMoveLRD = false; pinkMoveRUD = true; pinkMoveLRU = false; pinkMoveLUD = false; pinkMoveLRUD = false;
                    }
                    //LRU
                    else if ((pbGhostPink.Top == waypointsY[1] && pbGhostPink.Left == waypointsX[4])
                                  || (pbGhostPink.Top == waypointsY[1] && pbGhostPink.Left == waypointsX[5])
                                  || (pbGhostPink.Top == waypointsY[3] && pbGhostPink.Left == waypointsX[4])
                                  || (pbGhostPink.Top == waypointsY[3] && pbGhostPink.Left == waypointsX[5])
                                  || (pbGhostPink.Top == waypointsY[6] && pbGhostPink.Left == waypointsX[3])
                                  || (pbGhostPink.Top == waypointsY[6] && pbGhostPink.Left == waypointsX[6])
                                  || (pbGhostPink.Top == waypointsY[7] && pbGhostPink.Left == waypointsX[4])
                                  || (pbGhostPink.Top == waypointsY[7] && pbGhostPink.Left == waypointsX[5])
                                  || (pbGhostPink.Top == waypointsY[8] && pbGhostPink.Left == waypointsX[1])
                                  || (pbGhostPink.Top == waypointsY[8] && pbGhostPink.Left == waypointsX[8])
                                  || (pbGhostPink.Top == waypointsY[9] && pbGhostPink.Left == waypointsX[4])
                                  || (pbGhostPink.Top == waypointsY[9] && pbGhostPink.Left == waypointsX[5]))
                    {
                        pinkMoveRD = false; pinkMoveLD = false; pinkMoveLU = false; pinkMoveRU = false;
                        pinkMoveLRD = false; pinkMoveRUD = false; pinkMoveLRU = true; pinkMoveLUD = false; pinkMoveLRUD = false;
                    }
                    //LUD
                    else if ((pbGhostPink.Top == waypointsY[1] && pbGhostPink.Left == waypointsX[9])
                                  || (pbGhostPink.Top == waypointsY[2] && pbGhostPink.Left == waypointsX[2])
                                  || (pbGhostPink.Top == waypointsY[4] && pbGhostPink.Left == waypointsX[3])
                                  || (pbGhostPink.Top == waypointsY[5] && pbGhostPink.Left == waypointsX[6])
                                  || (pbGhostPink.Top == waypointsY[7] && pbGhostPink.Left == waypointsX[7]))
                    {
                        pinkMoveRD = false; pinkMoveLD = false; pinkMoveLU = false; pinkMoveRU = false;
                        pinkMoveLRD = false; pinkMoveRUD = false; pinkMoveLRU = false; pinkMoveLUD = true; pinkMoveLRUD = false;
                    }
                    //LRUD
                    else if ((pbGhostPink.Top == waypointsY[1] && pbGhostPink.Left == waypointsX[2])
                                  || (pbGhostPink.Top == waypointsY[1] && pbGhostPink.Left == waypointsX[7])
                                  || (pbGhostPink.Top == waypointsY[4] && pbGhostPink.Left == waypointsX[2])
                                  || (pbGhostPink.Top == waypointsY[4] && pbGhostPink.Left == waypointsX[7])
                                  || (pbGhostPink.Top == waypointsY[6] && pbGhostPink.Left == waypointsX[2])
                                  || (pbGhostPink.Top == waypointsY[6] && pbGhostPink.Left == waypointsX[7]))
                    {
                        pinkMoveRD = false; pinkMoveLD = false; pinkMoveLU = false; pinkMoveRU = false;
                        pinkMoveLRD = false; pinkMoveRUD = false; pinkMoveLRU = false; pinkMoveLUD = false; pinkMoveLRUD = true;
                    }
                    break;

                case "orangeGhost":
                    //checking the which waypoint
                    //RD
                    if ((pbGhostOrange.Top == waypointsY[0] && pbGhostOrange.Left == waypointsX[0])
                       || (pbGhostOrange.Top == waypointsY[0] && pbGhostOrange.Left == waypointsX[5])
                       || (pbGhostOrange.Top == waypointsY[3] && pbGhostOrange.Left == waypointsX[3])
                       || (pbGhostOrange.Top == waypointsY[2] && pbGhostOrange.Left == waypointsX[5])
                       || (pbGhostOrange.Top == waypointsY[6] && pbGhostOrange.Left == waypointsX[0])
                       || (pbGhostOrange.Top == waypointsY[6] && pbGhostOrange.Left == waypointsX[5])
                       || (pbGhostOrange.Top == waypointsY[7] && pbGhostOrange.Left == waypointsX[8])
                       || (pbGhostOrange.Top == waypointsY[8] && pbGhostOrange.Left == waypointsX[0])
                       || (pbGhostOrange.Top == waypointsY[8] && pbGhostOrange.Left == waypointsX[5]))
                    {
                        orangeMoveRD = true; orangeMoveLD = false; orangeMoveLU = false; orangeMoveRU = false;
                        orangeMoveLRD = false; orangeMoveRUD = false; orangeMoveLRU = false; orangeMoveLUD = false; orangeMoveLRUD = false;
                    }
                    //LD
                    else if ((pbGhostOrange.Top == waypointsY[0] && pbGhostOrange.Left == waypointsX[4])
                            || (pbGhostOrange.Top == waypointsY[0] && pbGhostOrange.Left == waypointsX[9])
                            || (pbGhostOrange.Top == waypointsY[2] && pbGhostOrange.Left == waypointsX[4])
                            || (pbGhostOrange.Top == waypointsY[3] && pbGhostOrange.Left == waypointsX[6])
                            || (pbGhostOrange.Top == waypointsY[6] && pbGhostOrange.Left == waypointsX[4])
                            || (pbGhostOrange.Top == waypointsY[6] && pbGhostOrange.Left == waypointsX[9])
                            || (pbGhostOrange.Top == waypointsY[7] && pbGhostOrange.Left == waypointsX[1])
                            || (pbGhostOrange.Top == waypointsY[8] && pbGhostOrange.Left == waypointsX[9])
                            || (pbGhostOrange.Top == waypointsY[8] && pbGhostOrange.Left == waypointsX[4]))
                    {
                        orangeMoveRD = false; orangeMoveLD = true; orangeMoveLU = false; orangeMoveRU = false;
                        orangeMoveLRD = false; orangeMoveRUD = false; orangeMoveLRU = false; orangeMoveLUD = false; orangeMoveLRUD = false;
                    }
                    //LU
                    else if ((pbGhostOrange.Top == waypointsY[2] && pbGhostOrange.Left == waypointsX[6])
                            || (pbGhostOrange.Top == waypointsY[2] && pbGhostOrange.Left == waypointsX[9])
                            || (pbGhostOrange.Top == waypointsY[7] && pbGhostOrange.Left == waypointsX[9])
                            || (pbGhostOrange.Top == waypointsY[8] && pbGhostOrange.Left == waypointsX[2])
                            || (pbGhostOrange.Top == waypointsY[8] && pbGhostOrange.Left == waypointsX[6])
                            || (pbGhostOrange.Top == waypointsY[9] && pbGhostOrange.Left == waypointsX[9]))
                    {
                        orangeMoveRD = false; orangeMoveLD = false; orangeMoveLU = true; orangeMoveRU = false;
                        orangeMoveLRD = false; orangeMoveRUD = false; orangeMoveLRU = false; orangeMoveLUD = false; orangeMoveLRUD = false;
                    }
                    //RU
                    else if ((pbGhostOrange.Top == waypointsY[2] && pbGhostOrange.Left == waypointsX[0])
                            || (pbGhostOrange.Top == waypointsY[2] && pbGhostOrange.Left == waypointsX[3])
                            || (pbGhostOrange.Top == waypointsY[7] && pbGhostOrange.Left == waypointsX[0])
                            || (pbGhostOrange.Top == waypointsY[8] && pbGhostOrange.Left == waypointsX[3])
                            || (pbGhostOrange.Top == waypointsY[8] && pbGhostOrange.Left == waypointsX[7])
                            || (pbGhostOrange.Top == waypointsY[9] && pbGhostOrange.Left == waypointsX[0]))
                    {
                        orangeMoveRD = false; orangeMoveLD = false; orangeMoveLU = false; orangeMoveRU = true;
                        orangeMoveLRD = false; orangeMoveRUD = false; orangeMoveLRU = false; orangeMoveLUD = false; orangeMoveLRUD = false;
                    }
                    //LRD
                    else if ((pbGhostOrange.Top == waypointsY[0] && pbGhostOrange.Left == waypointsX[2])
                            || (pbGhostOrange.Top == waypointsY[0] && pbGhostOrange.Left == waypointsX[7])
                            || (pbGhostOrange.Top == waypointsY[1] && pbGhostOrange.Left == waypointsX[3])
                            || (pbGhostOrange.Top == waypointsY[1] && pbGhostOrange.Left == waypointsX[6])
                            || (pbGhostOrange.Top == waypointsY[7] && pbGhostOrange.Left == waypointsX[6])
                            || (pbGhostOrange.Top == waypointsY[7] && pbGhostOrange.Left == waypointsX[3]))
                    {
                        orangeMoveRD = false; orangeMoveLD = false; orangeMoveLU = false; orangeMoveRU = false;
                        orangeMoveLRD = true; orangeMoveRUD = false; orangeMoveLRU = false; orangeMoveLUD = false; orangeMoveLRUD = false;
                    }
                    //RUD
                    else if ((pbGhostOrange.Top == waypointsY[1] && pbGhostOrange.Left == waypointsX[0])
                            || (pbGhostOrange.Top == waypointsY[2] && pbGhostOrange.Left == waypointsX[7])
                            || (pbGhostOrange.Top == waypointsY[4] && pbGhostOrange.Left == waypointsX[6])
                            || (pbGhostOrange.Top == waypointsY[5] && pbGhostOrange.Left == waypointsX[3])
                            || (pbGhostOrange.Top == waypointsY[7] && pbGhostOrange.Left == waypointsX[2]))
                    {
                        orangeMoveRD = false; orangeMoveLD = false; orangeMoveLU = false; orangeMoveRU = false;
                        orangeMoveLRD = false; orangeMoveRUD = true; orangeMoveLRU = false; orangeMoveLUD = false; orangeMoveLRUD = false;
                    }
                    //LRU
                    else if ((pbGhostOrange.Top == waypointsY[1] && pbGhostOrange.Left == waypointsX[4])
                            || (pbGhostOrange.Top == waypointsY[1] && pbGhostOrange.Left == waypointsX[5])
                            || (pbGhostOrange.Top == waypointsY[3] && pbGhostOrange.Left == waypointsX[5])
                            || (pbGhostOrange.Top == waypointsY[6] && pbGhostOrange.Left == waypointsX[3])
                            || (pbGhostOrange.Top == waypointsY[6] && pbGhostOrange.Left == waypointsX[6])
                            || (pbGhostOrange.Top == waypointsY[7] && pbGhostOrange.Left == waypointsX[4])
                            || (pbGhostOrange.Top == waypointsY[7] && pbGhostOrange.Left == waypointsX[5])
                            || (pbGhostOrange.Top == waypointsY[8] && pbGhostOrange.Left == waypointsX[1])
                            || (pbGhostOrange.Top == waypointsY[8] && pbGhostOrange.Left == waypointsX[8])
                            || (pbGhostOrange.Top == waypointsY[9] && pbGhostOrange.Left == waypointsX[4])
                            || (pbGhostOrange.Top == waypointsY[9] && pbGhostOrange.Left == waypointsX[5]))
                    {
                        orangeMoveRD = false; orangeMoveLD = false; orangeMoveLU = false; orangeMoveRU = false;
                        orangeMoveLRD = false; orangeMoveRUD = false; orangeMoveLRU = true; orangeMoveLUD = false; orangeMoveLRUD = false;
                    }
                    //LUD
                    else if ((pbGhostOrange.Top == waypointsY[1] && pbGhostOrange.Left == waypointsX[9])
                            || (pbGhostOrange.Top == waypointsY[2] && pbGhostOrange.Left == waypointsX[2])
                            || (pbGhostOrange.Top == waypointsY[4] && pbGhostOrange.Left == waypointsX[3])
                            || (pbGhostOrange.Top == waypointsY[5] && pbGhostOrange.Left == waypointsX[6])
                            || (pbGhostOrange.Top == waypointsY[7] && pbGhostOrange.Left == waypointsX[7]))
                    {
                        orangeMoveRD = false; orangeMoveLD = false; orangeMoveLU = false; orangeMoveRU = false;
                        orangeMoveLRD = false; orangeMoveRUD = false; orangeMoveLRU = false; orangeMoveLUD = true; orangeMoveLRUD = false;
                    }
                    //LRUD
                    else if ((pbGhostOrange.Top == waypointsY[1] && pbGhostOrange.Left == waypointsX[2])
                            || (pbGhostOrange.Top == waypointsY[1] && pbGhostOrange.Left == waypointsX[7])
                            || (pbGhostOrange.Top == waypointsY[4] && pbGhostOrange.Left == waypointsX[2])
                            || (pbGhostOrange.Top == waypointsY[4] && pbGhostOrange.Left == waypointsX[7])
                            || (pbGhostOrange.Top == waypointsY[6] && pbGhostOrange.Left == waypointsX[2])
                            || (pbGhostOrange.Top == waypointsY[6] && pbGhostOrange.Left == waypointsX[7]))
                    {
                        orangeMoveRD = false; orangeMoveLD = false; orangeMoveLU = false; orangeMoveRU = false;
                        orangeMoveLRD = false; orangeMoveRUD = false; orangeMoveLRU = false; orangeMoveLUD = false; orangeMoveLRUD = true;
                    }
                    break;



                case "blueGhost":
                    //checking the which waypoint
                    //RD
                    if ((pbGhostBlue.Top == waypointsY[0] && pbGhostBlue.Left == waypointsX[0])
                       || (pbGhostBlue.Top == waypointsY[0] && pbGhostBlue.Left == waypointsX[5])
                       || (pbGhostBlue.Top == waypointsY[3] && pbGhostBlue.Left == waypointsX[3])
                       || (pbGhostBlue.Top == waypointsY[2] && pbGhostBlue.Left == waypointsX[5])
                       || (pbGhostBlue.Top == waypointsY[6] && pbGhostBlue.Left == waypointsX[0])
                       || (pbGhostBlue.Top == waypointsY[6] && pbGhostBlue.Left == waypointsX[5])
                       || (pbGhostBlue.Top == waypointsY[7] && pbGhostBlue.Left == waypointsX[8])
                       || (pbGhostBlue.Top == waypointsY[8] && pbGhostBlue.Left == waypointsX[0])
                       || (pbGhostBlue.Top == waypointsY[8] && pbGhostBlue.Left == waypointsX[5]))
                    {
                        blueMoveRD = true; blueMoveLD = false; blueMoveLU = false; blueMoveRU = false;
                        blueMoveLRD = false; blueMoveRUD = false; blueMoveLRU = false; blueMoveLUD = false; blueMoveLRUD = false;
                    }
                    //LD
                    else if ((pbGhostBlue.Top == waypointsY[0] && pbGhostBlue.Left == waypointsX[4])
                            || (pbGhostBlue.Top == waypointsY[0] && pbGhostBlue.Left == waypointsX[9])
                            || (pbGhostBlue.Top == waypointsY[2] && pbGhostBlue.Left == waypointsX[4])
                            || (pbGhostBlue.Top == waypointsY[3] && pbGhostBlue.Left == waypointsX[6])
                            || (pbGhostBlue.Top == waypointsY[6] && pbGhostBlue.Left == waypointsX[4])
                            || (pbGhostBlue.Top == waypointsY[6] && pbGhostBlue.Left == waypointsX[9])
                            || (pbGhostBlue.Top == waypointsY[7] && pbGhostBlue.Left == waypointsX[1])
                            || (pbGhostBlue.Top == waypointsY[8] && pbGhostBlue.Left == waypointsX[9])
                            || (pbGhostBlue.Top == waypointsY[8] && pbGhostBlue.Left == waypointsX[4]))
                    {
                        blueMoveRD = false; blueMoveLD = true; blueMoveLU = false; blueMoveRU = false;
                        blueMoveLRD = false; blueMoveRUD = false; blueMoveLRU = false; blueMoveLUD = false; blueMoveLRUD = false;
                    }
                    //LU
                    else if ((pbGhostBlue.Top == waypointsY[2] && pbGhostBlue.Left == waypointsX[6])
                            || (pbGhostBlue.Top == waypointsY[2] && pbGhostBlue.Left == waypointsX[9])
                            || (pbGhostBlue.Top == waypointsY[7] && pbGhostBlue.Left == waypointsX[9])
                            || (pbGhostBlue.Top == waypointsY[8] && pbGhostBlue.Left == waypointsX[2])
                            || (pbGhostBlue.Top == waypointsY[8] && pbGhostBlue.Left == waypointsX[6])
                            || (pbGhostBlue.Top == waypointsY[9] && pbGhostBlue.Left == waypointsX[9]))
                    {
                        blueMoveRD = false; blueMoveLD = false; blueMoveLU = true; blueMoveRU = false;
                        blueMoveLRD = false; blueMoveRUD = false; blueMoveLRU = false; blueMoveLUD = false; blueMoveLRUD = false;
                    }
                    //RU
                    else if ((pbGhostBlue.Top == waypointsY[2] && pbGhostBlue.Left == waypointsX[0])
                            || (pbGhostBlue.Top == waypointsY[2] && pbGhostBlue.Left == waypointsX[3])
                            || (pbGhostBlue.Top == waypointsY[7] && pbGhostBlue.Left == waypointsX[0])
                            || (pbGhostBlue.Top == waypointsY[8] && pbGhostBlue.Left == waypointsX[3])
                            || (pbGhostBlue.Top == waypointsY[8] && pbGhostBlue.Left == waypointsX[7])
                            || (pbGhostBlue.Top == waypointsY[9] && pbGhostBlue.Left == waypointsX[0]))
                    {
                        blueMoveRD = false; blueMoveLD = false; blueMoveLU = false; blueMoveRU = true;
                        blueMoveLRD = false; blueMoveRUD = false; blueMoveLRU = false; blueMoveLUD = false; blueMoveLRUD = false;
                    }
                    //LRD
                    else if ((pbGhostBlue.Top == waypointsY[0] && pbGhostBlue.Left == waypointsX[2])
                            || (pbGhostBlue.Top == waypointsY[0] && pbGhostBlue.Left == waypointsX[7])
                            || (pbGhostBlue.Top == waypointsY[1] && pbGhostBlue.Left == waypointsX[3])
                            || (pbGhostBlue.Top == waypointsY[1] && pbGhostBlue.Left == waypointsX[6])
                            || (pbGhostBlue.Top == waypointsY[7] && pbGhostBlue.Left == waypointsX[6])
                            || (pbGhostBlue.Top == waypointsY[7] && pbGhostBlue.Left == waypointsX[3]))
                    {
                        blueMoveRD = false; blueMoveLD = false; blueMoveLU = false; blueMoveRU = false;
                        blueMoveLRD = true; blueMoveRUD = false; blueMoveLRU = false; blueMoveLUD = false; blueMoveLRUD = false;
                    }
                    //RUD
                    else if ((pbGhostBlue.Top == waypointsY[1] && pbGhostBlue.Left == waypointsX[0])
                            || (pbGhostBlue.Top == waypointsY[2] && pbGhostBlue.Left == waypointsX[7])
                            || (pbGhostBlue.Top == waypointsY[4] && pbGhostBlue.Left == waypointsX[6])
                            || (pbGhostBlue.Top == waypointsY[5] && pbGhostBlue.Left == waypointsX[3])
                            || (pbGhostBlue.Top == waypointsY[7] && pbGhostBlue.Left == waypointsX[2]))
                    {
                        blueMoveRD = false; blueMoveLD = false; blueMoveLU = false; blueMoveRU = false;
                        blueMoveLRD = false; blueMoveRUD = true; blueMoveLRU = false; blueMoveLUD = false; blueMoveLRUD = false;
                    }
                    //LRU
                    else if ((pbGhostBlue.Top == waypointsY[1] && pbGhostBlue.Left == waypointsX[4])
                            || (pbGhostBlue.Top == waypointsY[1] && pbGhostBlue.Left == waypointsX[5])
                            || (pbGhostBlue.Top == waypointsY[3] && pbGhostBlue.Left == waypointsX[4])
                            || (pbGhostBlue.Top == waypointsY[6] && pbGhostBlue.Left == waypointsX[3])
                            || (pbGhostBlue.Top == waypointsY[6] && pbGhostBlue.Left == waypointsX[6])
                            || (pbGhostBlue.Top == waypointsY[7] && pbGhostBlue.Left == waypointsX[4])
                            || (pbGhostBlue.Top == waypointsY[7] && pbGhostBlue.Left == waypointsX[5])
                            || (pbGhostBlue.Top == waypointsY[8] && pbGhostBlue.Left == waypointsX[1])
                            || (pbGhostBlue.Top == waypointsY[8] && pbGhostBlue.Left == waypointsX[8])
                            || (pbGhostBlue.Top == waypointsY[9] && pbGhostBlue.Left == waypointsX[4])
                            || (pbGhostBlue.Top == waypointsY[9] && pbGhostBlue.Left == waypointsX[5]))
                    {
                        blueMoveRD = false; blueMoveLD = false; blueMoveLU = false; blueMoveRU = false;
                        blueMoveLRD = false; blueMoveRUD = false; blueMoveLRU = true; blueMoveLUD = false; blueMoveLRUD = false;
                    }
                    //LUD
                    else if ((pbGhostBlue.Top == waypointsY[1] && pbGhostBlue.Left == waypointsX[9])
                            || (pbGhostBlue.Top == waypointsY[2] && pbGhostBlue.Left == waypointsX[2])
                            || (pbGhostBlue.Top == waypointsY[4] && pbGhostBlue.Left == waypointsX[3])
                            || (pbGhostBlue.Top == waypointsY[5] && pbGhostBlue.Left == waypointsX[6])
                            || (pbGhostBlue.Top == waypointsY[7] && pbGhostBlue.Left == waypointsX[7]))
                    {
                        blueMoveRD = false; blueMoveLD = false; blueMoveLU = false; blueMoveRU = false;
                        blueMoveLRD = false; blueMoveRUD = false; blueMoveLRU = false; blueMoveLUD = true; blueMoveLRUD = false;
                    }
                    //LRUD
                    else if ((pbGhostBlue.Top == waypointsY[1] && pbGhostBlue.Left == waypointsX[2])
                            || (pbGhostBlue.Top == waypointsY[1] && pbGhostBlue.Left == waypointsX[7])
                            || (pbGhostBlue.Top == waypointsY[4] && pbGhostBlue.Left == waypointsX[2])
                            || (pbGhostBlue.Top == waypointsY[4] && pbGhostBlue.Left == waypointsX[7])
                            || (pbGhostBlue.Top == waypointsY[6] && pbGhostBlue.Left == waypointsX[2])
                            || (pbGhostBlue.Top == waypointsY[6] && pbGhostBlue.Left == waypointsX[7]))
                    {
                        blueMoveRD = false; blueMoveLD = false; blueMoveLU = false; blueMoveRU = false;
                        blueMoveLRD = false; blueMoveRUD = false; blueMoveLRU = false; blueMoveLUD = false; blueMoveLRUD = true;
                    }
                    break;
                    
            }


        }


        #endregion


        #region Ghost Scatter

        private void ghostScatter(string ghost)
        {
            switch (ghost)
            {
                case "redScatter":
                    //checking the which waypoint
                    //RD
                    if (redMoveRD)
                    {
                        ghostMoveRD("ghostRed");
                    }
                    //LD
                    else if (redMoveLD)
                    {
                        ghostMoveLD("ghostRed");
                    }
                    //LU
                    else if (redMoveLU)
                    {
                        ghostMoveLU("ghostRed");
                    }
                    //RU
                    else if (redMoveRU)
                    {
                        ghostMoveRU("ghostRedScatter");
                    }
                    //LRD
                    else if (redMoveLRD)
                    {
                        ghostMoveLRD("ghostRedScatter");
                    }
                    //RUD
                    else if (redMoveRUD)
                    {
                        ghostMoveRUD("ghostRedScatter");
                    }
                    //LRU
                    else if (redMoveLRU)
                    {
                        ghostMoveLRU("ghostRedScatter");
                    }
                    //LUD
                    else if (redMoveLUD)
                    {
                        ghostMoveLUD("ghostRedScatter");
                    }
                    //LRUD
                    else if (redMoveLRUD)
                    {
                        ghostMoveLRUD("ghostRedScatter");
                    }
                    break;


                case "pinkScatter":
                    //checking the which waypoint
                    //RD
                    if (pinkMoveRD)
                    {
                        ghostMoveRD("ghostPink");
                    }
                    //LD
                    else if (pinkMoveLD)
                    {
                        ghostMoveLD("ghostPink");
                    }
                    //LU
                    else if (pinkMoveLU)
                    {
                        ghostMoveLU("ghostPink");
                    }
                    //RU
                    else if (pinkMoveRU)
                    {
                        ghostMoveRU("ghostPink");
                    }
                    //LRD
                    else if (pinkMoveLRD)
                    {
                        ghostMoveLRD("pinkScatter");
                    }
                    //RUD
                    else if (pinkMoveRUD)
                    {
                        ghostMoveRUD("pinkScatter");
                    }
                    //LRU
                    else if (pinkMoveLRU)
                    {
                        ghostMoveLRU("pinkScatter");
                    }
                    //LUD
                    else if (pinkMoveLUD)
                    {
                        ghostMoveLUD("pinkScatter");
                    }
                    //LRUD
                    else if (pinkMoveLRUD)
                    {
                        ghostMoveLRUD("pinkScatter");
                    }
                    break;

                case "orangeScatter":
                    //checking the which waypoint
                    //RD
                    if (orangeMoveRD)
                    {
                        ghostMoveRD("ghostOrange");
                    }
                    //LD
                    else if (orangeMoveLD)
                    {
                        ghostMoveLD("ghostOrange");
                    }
                    //LU
                    else if (orangeMoveLU)
                    {
                        ghostMoveLU("ghostOrange");
                    }
                    //RU
                    else if (orangeMoveRU)
                    {
                        ghostMoveRU("ghostOrange");
                    }
                    //LRD
                    else if (orangeMoveLRD)
                    {
                        ghostMoveLRD("orangeScatter");
                    }
                    //RUD
                    else if (orangeMoveRUD)
                    {
                        ghostMoveRUD("orangeScatter");
                    }
                    //LRU
                    else if (orangeMoveLRU)
                    {
                        ghostMoveLRU("orangeScatter");
                    }
                    //LUD
                    else if (orangeMoveLUD)
                    {
                        ghostMoveLUD("orangeScatter");
                    }
                    //LRUD
                    else if (orangeMoveLRUD)
                    {
                        ghostMoveLRUD("orangeScatter");
                    }
                    break;



                case "blueScatter":
                    //checking the which waypoint
                    //RD
                    if (blueMoveRD)
                    {
                        ghostMoveRD("ghostBlue");
                    }
                    //LD
                    else if (blueMoveLD)
                    {
                        ghostMoveLD("ghostBlue");
                    }
                    //LU
                    else if (blueMoveLU)
                    {
                        ghostMoveLU("ghostBlue");
                    }
                    //RU
                    else if (blueMoveRU)
                    {
                        ghostMoveRU("ghostBlue");
                    }
                    //LRD
                    else if (blueMoveLRD)
                    {
                        ghostMoveLRD("blueScatter");
                    }
                    //RUD
                    else if (blueMoveRUD)
                    {
                        ghostMoveRUD("blueScatter");
                    }
                    //LRU
                    else if (blueMoveLRU)
                    {
                        ghostMoveLRU("blueScatter");
                    }
                    //LUD
                    else if (blueMoveLUD)
                    {
                        ghostMoveLUD("blueScatter");
                    }
                    //LRUD
                    else if (blueMoveLRUD)
                    {
                        ghostMoveLRUD("blueScatter");
                    }
                    break;

            }


        }


        #endregion


        #region Ghost Chase Waypoints

        private void ghostCaseWhichWaypoint(string ghost)
        {
            switch (ghost)
            {
                case "redChase":
                    //checking the which waypoint
                    //RD
                    if ((pbGhostRed.Top == waypointsY[0] && pbGhostRed.Left == waypointsX[0])
                            || (pbGhostRed.Top == waypointsY[0] && pbGhostRed.Left == waypointsX[5])
                            || (pbGhostRed.Top == waypointsY[3] && pbGhostRed.Left == waypointsX[3])
                            || (pbGhostRed.Top == waypointsY[2] && pbGhostRed.Left == waypointsX[5])
                            || (pbGhostRed.Top == waypointsY[6] && pbGhostRed.Left == waypointsX[0])
                            || (pbGhostRed.Top == waypointsY[6] && pbGhostRed.Left == waypointsX[5])
                            || (pbGhostRed.Top == waypointsY[7] && pbGhostRed.Left == waypointsX[8])
                            || (pbGhostRed.Top == waypointsY[8] && pbGhostRed.Left == waypointsX[0])
                            || (pbGhostRed.Top == waypointsY[8] && pbGhostRed.Left == waypointsX[5]))
                    {
                        ghostMoveRD("ghostRed");
                    }
                    //LD
                    else if ((pbGhostRed.Top == waypointsY[0] && pbGhostRed.Left == waypointsX[4])
                                  || (pbGhostRed.Top == waypointsY[0] && pbGhostRed.Left == waypointsX[9])
                                  || (pbGhostRed.Top == waypointsY[2] && pbGhostRed.Left == waypointsX[4])
                                  || (pbGhostRed.Top == waypointsY[3] && pbGhostRed.Left == waypointsX[6])
                                  || (pbGhostRed.Top == waypointsY[6] && pbGhostRed.Left == waypointsX[4])
                                  || (pbGhostRed.Top == waypointsY[6] && pbGhostRed.Left == waypointsX[9])
                                  || (pbGhostRed.Top == waypointsY[7] && pbGhostRed.Left == waypointsX[1])
                                  || (pbGhostRed.Top == waypointsY[8] && pbGhostRed.Left == waypointsX[9])
                                  || (pbGhostRed.Top == waypointsY[8] && pbGhostRed.Left == waypointsX[4]))
                    {
                        ghostMoveLD("ghostRed");
                    }
                    //LU
                    else if ((pbGhostRed.Top == waypointsY[2] && pbGhostRed.Left == waypointsX[6])
                                  || (pbGhostRed.Top == waypointsY[2] && pbGhostRed.Left == waypointsX[9])
                                  || (pbGhostRed.Top == waypointsY[7] && pbGhostRed.Left == waypointsX[9])
                                  || (pbGhostRed.Top == waypointsY[8] && pbGhostRed.Left == waypointsX[2])
                                  || (pbGhostRed.Top == waypointsY[8] && pbGhostRed.Left == waypointsX[6])
                                  || (pbGhostRed.Top == waypointsY[9] && pbGhostRed.Left == waypointsX[9]))
                    {
                        ghostMoveLU("ghostRed");
                    }
                    //RU
                    else if ((pbGhostRed.Top == waypointsY[2] && pbGhostRed.Left == waypointsX[0])
                                  || (pbGhostRed.Top == waypointsY[2] && pbGhostRed.Left == waypointsX[3])
                                  || (pbGhostRed.Top == waypointsY[7] && pbGhostRed.Left == waypointsX[0])
                                  || (pbGhostRed.Top == waypointsY[8] && pbGhostRed.Left == waypointsX[3])
                                  || (pbGhostRed.Top == waypointsY[8] && pbGhostRed.Left == waypointsX[7])
                                  || (pbGhostRed.Top == waypointsY[9] && pbGhostRed.Left == waypointsX[0]))
                    {
                        ghostMoveRU("ghostRedChase");
                    }
                    //LRD
                    else if ((pbGhostRed.Top == waypointsY[0] && pbGhostRed.Left == waypointsX[2])
                                  || (pbGhostRed.Top == waypointsY[0] && pbGhostRed.Left == waypointsX[7])
                                  || (pbGhostRed.Top == waypointsY[1] && pbGhostRed.Left == waypointsX[3])
                                  || (pbGhostRed.Top == waypointsY[1] && pbGhostRed.Left == waypointsX[6])
                                  || (pbGhostRed.Top == waypointsY[7] && pbGhostRed.Left == waypointsX[6])
                                  || (pbGhostRed.Top == waypointsY[7] && pbGhostRed.Left == waypointsX[3]))
                    {
                        ghostMoveLRD("ghostRedChase");
                    }
                    //RUD
                    else if ((pbGhostRed.Top == waypointsY[1] && pbGhostRed.Left == waypointsX[0])
                                  || (pbGhostRed.Top == waypointsY[2] && pbGhostRed.Left == waypointsX[7])
                                  || (pbGhostRed.Top == waypointsY[4] && pbGhostRed.Left == waypointsX[6])
                                  || (pbGhostRed.Top == waypointsY[5] && pbGhostRed.Left == waypointsX[3])
                                  || (pbGhostRed.Top == waypointsY[7] && pbGhostRed.Left == waypointsX[2]))
                    {
                        ghostMoveRUD("ghostRedChase");
                    }
                    //LRU
                    else if ((pbGhostRed.Top == waypointsY[1] && pbGhostRed.Left == waypointsX[4])
                                  || (pbGhostRed.Top == waypointsY[1] && pbGhostRed.Left == waypointsX[5])
                                  || (pbGhostRed.Top == waypointsY[3] && pbGhostRed.Left == waypointsX[4])
                                  || (pbGhostRed.Top == waypointsY[3] && pbGhostRed.Left == waypointsX[5])
                                  || (pbGhostRed.Top == waypointsY[6] && pbGhostRed.Left == waypointsX[3])
                                  || (pbGhostRed.Top == waypointsY[6] && pbGhostRed.Left == waypointsX[6])
                                  || (pbGhostRed.Top == waypointsY[7] && pbGhostRed.Left == waypointsX[4])
                                  || (pbGhostRed.Top == waypointsY[7] && pbGhostRed.Left == waypointsX[5])
                                  || (pbGhostRed.Top == waypointsY[8] && pbGhostRed.Left == waypointsX[1])
                                  || (pbGhostRed.Top == waypointsY[8] && pbGhostRed.Left == waypointsX[8])
                                  || (pbGhostRed.Top == waypointsY[9] && pbGhostRed.Left == waypointsX[4])
                                  || (pbGhostRed.Top == waypointsY[9] && pbGhostRed.Left == waypointsX[5]))
                    {
                        ghostMoveLRU("ghostRedChase");
                    }
                    //LUD
                    else if ((pbGhostRed.Top == waypointsY[1] && pbGhostRed.Left == waypointsX[9])
                                  || (pbGhostRed.Top == waypointsY[2] && pbGhostRed.Left == waypointsX[2])
                                  || (pbGhostRed.Top == waypointsY[4] && pbGhostRed.Left == waypointsX[3])
                                  || (pbGhostRed.Top == waypointsY[5] && pbGhostRed.Left == waypointsX[6])
                                  || (pbGhostRed.Top == waypointsY[7] && pbGhostRed.Left == waypointsX[7]))
                    {
                        ghostMoveLUD("ghostRedChase");
                    }
                    //LRUD
                    else if ((pbGhostRed.Top == waypointsY[1] && pbGhostRed.Left == waypointsX[2])
                                  || (pbGhostRed.Top == waypointsY[1] && pbGhostRed.Left == waypointsX[7])
                                  || (pbGhostRed.Top == waypointsY[4] && pbGhostRed.Left == waypointsX[2])
                                  || (pbGhostRed.Top == waypointsY[4] && pbGhostRed.Left == waypointsX[7])
                                  || (pbGhostRed.Top == waypointsY[6] && pbGhostRed.Left == waypointsX[2])
                                  || (pbGhostRed.Top == waypointsY[6] && pbGhostRed.Left == waypointsX[7]))
                    {
                        ghostMoveLRUD("ghostRedChase");
                    }
                    break;

                    /*
                case "pinkScatter":
                    //checking the which waypoint
                    //RD
                    if ((pbGhostPink.Top == waypointsY[0] && pbGhostPink.Left == waypointsX[0])
                            || (pbGhostPink.Top == waypointsY[0] && pbGhostPink.Left == waypointsX[5])
                            || (pbGhostPink.Top == waypointsY[3] && pbGhostPink.Left == waypointsX[3])
                            || (pbGhostPink.Top == waypointsY[2] && pbGhostPink.Left == waypointsX[5])
                            || (pbGhostPink.Top == waypointsY[6] && pbGhostPink.Left == waypointsX[0])
                            || (pbGhostPink.Top == waypointsY[6] && pbGhostPink.Left == waypointsX[5])
                            || (pbGhostPink.Top == waypointsY[7] && pbGhostPink.Left == waypointsX[8])
                            || (pbGhostPink.Top == waypointsY[8] && pbGhostPink.Left == waypointsX[0])
                            || (pbGhostPink.Top == waypointsY[8] && pbGhostPink.Left == waypointsX[5]))
                    {
                        ghostMoveRD("ghostPink");
                    }
                    //LD
                    else if ((pbGhostPink.Top == waypointsY[0] && pbGhostPink.Left == waypointsX[4])
                                  || (pbGhostPink.Top == waypointsY[0] && pbGhostPink.Left == waypointsX[9])
                                  || (pbGhostPink.Top == waypointsY[2] && pbGhostPink.Left == waypointsX[4])
                                  || (pbGhostPink.Top == waypointsY[3] && pbGhostPink.Left == waypointsX[6])
                                  || (pbGhostPink.Top == waypointsY[6] && pbGhostPink.Left == waypointsX[4])
                                  || (pbGhostPink.Top == waypointsY[6] && pbGhostPink.Left == waypointsX[9])
                                  || (pbGhostPink.Top == waypointsY[7] && pbGhostPink.Left == waypointsX[1])
                                  || (pbGhostPink.Top == waypointsY[8] && pbGhostPink.Left == waypointsX[9])
                                  || (pbGhostPink.Top == waypointsY[8] && pbGhostPink.Left == waypointsX[4]))
                    {
                        ghostMoveLD("ghostPink");
                    }
                    //LU
                    else if ((pbGhostPink.Top == waypointsY[2] && pbGhostPink.Left == waypointsX[6])
                                  || (pbGhostPink.Top == waypointsY[2] && pbGhostPink.Left == waypointsX[9])
                                  || (pbGhostPink.Top == waypointsY[7] && pbGhostPink.Left == waypointsX[9])
                                  || (pbGhostPink.Top == waypointsY[8] && pbGhostPink.Left == waypointsX[2])
                                  || (pbGhostPink.Top == waypointsY[8] && pbGhostPink.Left == waypointsX[6])
                                  || (pbGhostPink.Top == waypointsY[9] && pbGhostPink.Left == waypointsX[9]))
                    {
                        ghostMoveLU("ghostPink");
                    }
                    //RU
                    else if ((pbGhostPink.Top == waypointsY[2] && pbGhostPink.Left == waypointsX[0])
                                  || (pbGhostPink.Top == waypointsY[2] && pbGhostPink.Left == waypointsX[3])
                                  || (pbGhostPink.Top == waypointsY[7] && pbGhostPink.Left == waypointsX[0])
                                  || (pbGhostPink.Top == waypointsY[8] && pbGhostPink.Left == waypointsX[3])
                                  || (pbGhostPink.Top == waypointsY[8] && pbGhostPink.Left == waypointsX[7])
                                  || (pbGhostPink.Top == waypointsY[9] && pbGhostPink.Left == waypointsX[0]))
                    {
                        ghostMoveRU("ghostPink");
                    }
                    //LRD
                    else if ((pbGhostPink.Top == waypointsY[0] && pbGhostPink.Left == waypointsX[2])
                                  || (pbGhostPink.Top == waypointsY[0] && pbGhostPink.Left == waypointsX[7])
                                  || (pbGhostPink.Top == waypointsY[1] && pbGhostPink.Left == waypointsX[3])
                                  || (pbGhostPink.Top == waypointsY[1] && pbGhostPink.Left == waypointsX[6])
                                  || (pbGhostPink.Top == waypointsY[7] && pbGhostPink.Left == waypointsX[6])
                                  || (pbGhostPink.Top == waypointsY[7] && pbGhostPink.Left == waypointsX[3]))
                    {
                        ghostMoveLRD("pinkScatter");
                    }
                    //RUD
                    else if ((pbGhostPink.Top == waypointsY[1] && pbGhostPink.Left == waypointsX[0])
                                  || (pbGhostPink.Top == waypointsY[2] && pbGhostPink.Left == waypointsX[7])
                                  || (pbGhostPink.Top == waypointsY[4] && pbGhostPink.Left == waypointsX[6])
                                  || (pbGhostPink.Top == waypointsY[5] && pbGhostPink.Left == waypointsX[3])
                                  || (pbGhostPink.Top == waypointsY[7] && pbGhostPink.Left == waypointsX[2]))
                    {
                        ghostMoveRUD("pinkScatter");
                    }
                    //LRU
                    else if ((pbGhostPink.Top == waypointsY[1] && pbGhostPink.Left == waypointsX[4])
                                  || (pbGhostPink.Top == waypointsY[1] && pbGhostPink.Left == waypointsX[5])
                                  || (pbGhostPink.Top == waypointsY[3] && pbGhostPink.Left == waypointsX[4])
                                  || (pbGhostPink.Top == waypointsY[3] && pbGhostPink.Left == waypointsX[5])
                                  || (pbGhostPink.Top == waypointsY[6] && pbGhostPink.Left == waypointsX[3])
                                  || (pbGhostPink.Top == waypointsY[6] && pbGhostPink.Left == waypointsX[6])
                                  || (pbGhostPink.Top == waypointsY[7] && pbGhostPink.Left == waypointsX[4])
                                  || (pbGhostPink.Top == waypointsY[7] && pbGhostPink.Left == waypointsX[5])
                                  || (pbGhostPink.Top == waypointsY[8] && pbGhostPink.Left == waypointsX[1])
                                  || (pbGhostPink.Top == waypointsY[8] && pbGhostPink.Left == waypointsX[8])
                                  || (pbGhostPink.Top == waypointsY[9] && pbGhostPink.Left == waypointsX[4])
                                  || (pbGhostPink.Top == waypointsY[9] && pbGhostPink.Left == waypointsX[5]))
                    {
                        ghostMoveLRU("pinkScatter");
                    }
                    //LUD
                    else if ((pbGhostPink.Top == waypointsY[1] && pbGhostPink.Left == waypointsX[9])
                                  || (pbGhostPink.Top == waypointsY[2] && pbGhostPink.Left == waypointsX[2])
                                  || (pbGhostPink.Top == waypointsY[4] && pbGhostPink.Left == waypointsX[3])
                                  || (pbGhostPink.Top == waypointsY[5] && pbGhostPink.Left == waypointsX[6])
                                  || (pbGhostPink.Top == waypointsY[7] && pbGhostPink.Left == waypointsX[7]))
                    {
                        ghostMoveLUD("pinkScatter");
                    }
                    //LRUD
                    else if ((pbGhostPink.Top == waypointsY[1] && pbGhostPink.Left == waypointsX[2])
                                  || (pbGhostPink.Top == waypointsY[1] && pbGhostPink.Left == waypointsX[7])
                                  || (pbGhostPink.Top == waypointsY[4] && pbGhostPink.Left == waypointsX[2])
                                  || (pbGhostPink.Top == waypointsY[4] && pbGhostPink.Left == waypointsX[7])
                                  || (pbGhostPink.Top == waypointsY[6] && pbGhostPink.Left == waypointsX[2])
                                  || (pbGhostPink.Top == waypointsY[6] && pbGhostPink.Left == waypointsX[7]))
                    {
                        ghostMoveLRUD("pinkScatter");
                    }
                    break;

                case "orangeScatter":
                    //checking the which waypoint
                    //RD
                    if ((pbGhostOrange.Top == waypointsY[0] && pbGhostOrange.Left == waypointsX[0])
                       || (pbGhostOrange.Top == waypointsY[0] && pbGhostOrange.Left == waypointsX[5])
                       || (pbGhostOrange.Top == waypointsY[3] && pbGhostOrange.Left == waypointsX[3])
                       || (pbGhostOrange.Top == waypointsY[2] && pbGhostOrange.Left == waypointsX[5])
                       || (pbGhostOrange.Top == waypointsY[6] && pbGhostOrange.Left == waypointsX[0])
                       || (pbGhostOrange.Top == waypointsY[6] && pbGhostOrange.Left == waypointsX[5])
                       || (pbGhostOrange.Top == waypointsY[7] && pbGhostOrange.Left == waypointsX[8])
                       || (pbGhostOrange.Top == waypointsY[8] && pbGhostOrange.Left == waypointsX[0])
                       || (pbGhostOrange.Top == waypointsY[8] && pbGhostOrange.Left == waypointsX[5]))
                    {
                        ghostMoveRD("ghostOrange");
                    }
                    //LD
                    else if ((pbGhostOrange.Top == waypointsY[0] && pbGhostOrange.Left == waypointsX[4])
                            || (pbGhostOrange.Top == waypointsY[0] && pbGhostOrange.Left == waypointsX[9])
                            || (pbGhostOrange.Top == waypointsY[2] && pbGhostOrange.Left == waypointsX[4])
                            || (pbGhostOrange.Top == waypointsY[3] && pbGhostOrange.Left == waypointsX[6])
                            || (pbGhostOrange.Top == waypointsY[6] && pbGhostOrange.Left == waypointsX[4])
                            || (pbGhostOrange.Top == waypointsY[6] && pbGhostOrange.Left == waypointsX[9])
                            || (pbGhostOrange.Top == waypointsY[7] && pbGhostOrange.Left == waypointsX[1])
                            || (pbGhostOrange.Top == waypointsY[8] && pbGhostOrange.Left == waypointsX[9])
                            || (pbGhostOrange.Top == waypointsY[8] && pbGhostOrange.Left == waypointsX[4]))
                    {
                        ghostMoveLD("ghostOrange");
                    }
                    //LU
                    else if ((pbGhostOrange.Top == waypointsY[2] && pbGhostOrange.Left == waypointsX[6])
                            || (pbGhostOrange.Top == waypointsY[2] && pbGhostOrange.Left == waypointsX[9])
                            || (pbGhostOrange.Top == waypointsY[7] && pbGhostOrange.Left == waypointsX[9])
                            || (pbGhostOrange.Top == waypointsY[8] && pbGhostOrange.Left == waypointsX[2])
                            || (pbGhostOrange.Top == waypointsY[8] && pbGhostOrange.Left == waypointsX[6])
                            || (pbGhostOrange.Top == waypointsY[9] && pbGhostOrange.Left == waypointsX[9]))
                    {
                        ghostMoveLU("ghostOrange");
                    }
                    //RU
                    else if ((pbGhostOrange.Top == waypointsY[2] && pbGhostOrange.Left == waypointsX[0])
                            || (pbGhostOrange.Top == waypointsY[2] && pbGhostOrange.Left == waypointsX[3])
                            || (pbGhostOrange.Top == waypointsY[7] && pbGhostOrange.Left == waypointsX[0])
                            || (pbGhostOrange.Top == waypointsY[8] && pbGhostOrange.Left == waypointsX[3])
                            || (pbGhostOrange.Top == waypointsY[8] && pbGhostOrange.Left == waypointsX[7])
                            || (pbGhostOrange.Top == waypointsY[9] && pbGhostOrange.Left == waypointsX[0]))
                    {
                        ghostMoveRU("ghostOrange");
                    }
                    //LRD
                    else if ((pbGhostOrange.Top == waypointsY[0] && pbGhostOrange.Left == waypointsX[2])
                            || (pbGhostOrange.Top == waypointsY[0] && pbGhostOrange.Left == waypointsX[7])
                            || (pbGhostOrange.Top == waypointsY[1] && pbGhostOrange.Left == waypointsX[3])
                            || (pbGhostOrange.Top == waypointsY[1] && pbGhostOrange.Left == waypointsX[6])
                            || (pbGhostOrange.Top == waypointsY[7] && pbGhostOrange.Left == waypointsX[6])
                            || (pbGhostOrange.Top == waypointsY[7] && pbGhostOrange.Left == waypointsX[3]))
                    {
                        ghostMoveLRD("orangeScatter");
                    }
                    //RUD
                    else if ((pbGhostOrange.Top == waypointsY[1] && pbGhostOrange.Left == waypointsX[0])
                            || (pbGhostOrange.Top == waypointsY[2] && pbGhostOrange.Left == waypointsX[7])
                            || (pbGhostOrange.Top == waypointsY[4] && pbGhostOrange.Left == waypointsX[6])
                            || (pbGhostOrange.Top == waypointsY[5] && pbGhostOrange.Left == waypointsX[3])
                            || (pbGhostOrange.Top == waypointsY[7] && pbGhostOrange.Left == waypointsX[2]))
                    {
                        ghostMoveRUD("orangeScatter");
                    }
                    //LRU
                    else if ((pbGhostOrange.Top == waypointsY[1] && pbGhostOrange.Left == waypointsX[4])
                            || (pbGhostOrange.Top == waypointsY[1] && pbGhostOrange.Left == waypointsX[5])
                            || (pbGhostOrange.Top == waypointsY[3] && pbGhostOrange.Left == waypointsX[5])
                            || (pbGhostOrange.Top == waypointsY[6] && pbGhostOrange.Left == waypointsX[3])
                            || (pbGhostOrange.Top == waypointsY[6] && pbGhostOrange.Left == waypointsX[6])
                            || (pbGhostOrange.Top == waypointsY[7] && pbGhostOrange.Left == waypointsX[4])
                            || (pbGhostOrange.Top == waypointsY[7] && pbGhostOrange.Left == waypointsX[5])
                            || (pbGhostOrange.Top == waypointsY[8] && pbGhostOrange.Left == waypointsX[1])
                            || (pbGhostOrange.Top == waypointsY[8] && pbGhostOrange.Left == waypointsX[8])
                            || (pbGhostOrange.Top == waypointsY[9] && pbGhostOrange.Left == waypointsX[4])
                            || (pbGhostOrange.Top == waypointsY[9] && pbGhostOrange.Left == waypointsX[5]))
                    {
                        ghostMoveLRU("orangeScatter");
                    }
                    //LUD
                    else if ((pbGhostOrange.Top == waypointsY[1] && pbGhostOrange.Left == waypointsX[9])
                            || (pbGhostOrange.Top == waypointsY[2] && pbGhostOrange.Left == waypointsX[2])
                            || (pbGhostOrange.Top == waypointsY[4] && pbGhostOrange.Left == waypointsX[3])
                            || (pbGhostOrange.Top == waypointsY[5] && pbGhostOrange.Left == waypointsX[6])
                            || (pbGhostOrange.Top == waypointsY[7] && pbGhostOrange.Left == waypointsX[7]))
                    {
                        ghostMoveLUD("orangeScatter");
                    }
                    //LRUD
                    else if ((pbGhostOrange.Top == waypointsY[1] && pbGhostOrange.Left == waypointsX[2])
                            || (pbGhostOrange.Top == waypointsY[1] && pbGhostOrange.Left == waypointsX[7])
                            || (pbGhostOrange.Top == waypointsY[4] && pbGhostOrange.Left == waypointsX[2])
                            || (pbGhostOrange.Top == waypointsY[4] && pbGhostOrange.Left == waypointsX[7])
                            || (pbGhostOrange.Top == waypointsY[6] && pbGhostOrange.Left == waypointsX[2])
                            || (pbGhostOrange.Top == waypointsY[6] && pbGhostOrange.Left == waypointsX[7]))
                    {
                        ghostMoveLRUD("orangeScatter");
                    }
                    break;



                case "blueScatter":
                    //checking the which waypoint
                    //RD
                    if ((pbGhostBlue.Top == waypointsY[0] && pbGhostBlue.Left == waypointsX[0])
                       || (pbGhostBlue.Top == waypointsY[0] && pbGhostBlue.Left == waypointsX[5])
                       || (pbGhostBlue.Top == waypointsY[3] && pbGhostBlue.Left == waypointsX[3])
                       || (pbGhostBlue.Top == waypointsY[2] && pbGhostBlue.Left == waypointsX[5])
                       || (pbGhostBlue.Top == waypointsY[6] && pbGhostBlue.Left == waypointsX[0])
                       || (pbGhostBlue.Top == waypointsY[6] && pbGhostBlue.Left == waypointsX[5])
                       || (pbGhostBlue.Top == waypointsY[7] && pbGhostBlue.Left == waypointsX[8])
                       || (pbGhostBlue.Top == waypointsY[8] && pbGhostBlue.Left == waypointsX[0])
                       || (pbGhostBlue.Top == waypointsY[8] && pbGhostBlue.Left == waypointsX[5]))
                    {
                        ghostMoveRD("ghostBlue");
                    }
                    //LD
                    else if ((pbGhostBlue.Top == waypointsY[0] && pbGhostBlue.Left == waypointsX[4])
                            || (pbGhostBlue.Top == waypointsY[0] && pbGhostBlue.Left == waypointsX[9])
                            || (pbGhostBlue.Top == waypointsY[2] && pbGhostBlue.Left == waypointsX[4])
                            || (pbGhostBlue.Top == waypointsY[3] && pbGhostBlue.Left == waypointsX[6])
                            || (pbGhostBlue.Top == waypointsY[6] && pbGhostBlue.Left == waypointsX[4])
                            || (pbGhostBlue.Top == waypointsY[6] && pbGhostBlue.Left == waypointsX[9])
                            || (pbGhostBlue.Top == waypointsY[7] && pbGhostBlue.Left == waypointsX[1])
                            || (pbGhostBlue.Top == waypointsY[8] && pbGhostBlue.Left == waypointsX[9])
                            || (pbGhostBlue.Top == waypointsY[8] && pbGhostBlue.Left == waypointsX[4]))
                    {
                        ghostMoveLD("ghostBlue");
                    }
                    //LU
                    else if ((pbGhostBlue.Top == waypointsY[2] && pbGhostBlue.Left == waypointsX[6])
                            || (pbGhostBlue.Top == waypointsY[2] && pbGhostBlue.Left == waypointsX[9])
                            || (pbGhostBlue.Top == waypointsY[7] && pbGhostBlue.Left == waypointsX[9])
                            || (pbGhostBlue.Top == waypointsY[8] && pbGhostBlue.Left == waypointsX[2])
                            || (pbGhostBlue.Top == waypointsY[8] && pbGhostBlue.Left == waypointsX[6])
                            || (pbGhostBlue.Top == waypointsY[9] && pbGhostBlue.Left == waypointsX[9]))
                    {
                        ghostMoveLU("ghostBlue");
                    }
                    //RU
                    else if ((pbGhostBlue.Top == waypointsY[2] && pbGhostBlue.Left == waypointsX[0])
                            || (pbGhostBlue.Top == waypointsY[2] && pbGhostBlue.Left == waypointsX[3])
                            || (pbGhostBlue.Top == waypointsY[7] && pbGhostBlue.Left == waypointsX[0])
                            || (pbGhostBlue.Top == waypointsY[8] && pbGhostBlue.Left == waypointsX[3])
                            || (pbGhostBlue.Top == waypointsY[8] && pbGhostBlue.Left == waypointsX[7])
                            || (pbGhostBlue.Top == waypointsY[9] && pbGhostBlue.Left == waypointsX[0]))
                    {
                        ghostMoveRU("ghostBlue");
                    }
                    //LRD
                    else if ((pbGhostBlue.Top == waypointsY[0] && pbGhostBlue.Left == waypointsX[2])
                            || (pbGhostBlue.Top == waypointsY[0] && pbGhostBlue.Left == waypointsX[7])
                            || (pbGhostBlue.Top == waypointsY[1] && pbGhostBlue.Left == waypointsX[3])
                            || (pbGhostBlue.Top == waypointsY[1] && pbGhostBlue.Left == waypointsX[6])
                            || (pbGhostBlue.Top == waypointsY[7] && pbGhostBlue.Left == waypointsX[6])
                            || (pbGhostBlue.Top == waypointsY[7] && pbGhostBlue.Left == waypointsX[3]))
                    {
                        ghostMoveLRD("blueScatter");
                    }
                    //RUD
                    else if ((pbGhostBlue.Top == waypointsY[1] && pbGhostBlue.Left == waypointsX[0])
                            || (pbGhostBlue.Top == waypointsY[2] && pbGhostBlue.Left == waypointsX[7])
                            || (pbGhostBlue.Top == waypointsY[4] && pbGhostBlue.Left == waypointsX[6])
                            || (pbGhostBlue.Top == waypointsY[5] && pbGhostBlue.Left == waypointsX[3])
                            || (pbGhostBlue.Top == waypointsY[7] && pbGhostBlue.Left == waypointsX[2]))
                    {
                        ghostMoveRUD("blueScatter");
                    }
                    //LRU
                    else if ((pbGhostBlue.Top == waypointsY[1] && pbGhostBlue.Left == waypointsX[4])
                            || (pbGhostBlue.Top == waypointsY[1] && pbGhostBlue.Left == waypointsX[5])
                            || (pbGhostBlue.Top == waypointsY[3] && pbGhostBlue.Left == waypointsX[4])
                            || (pbGhostBlue.Top == waypointsY[6] && pbGhostBlue.Left == waypointsX[3])
                            || (pbGhostBlue.Top == waypointsY[6] && pbGhostBlue.Left == waypointsX[6])
                            || (pbGhostBlue.Top == waypointsY[7] && pbGhostBlue.Left == waypointsX[4])
                            || (pbGhostBlue.Top == waypointsY[7] && pbGhostBlue.Left == waypointsX[5])
                            || (pbGhostBlue.Top == waypointsY[8] && pbGhostBlue.Left == waypointsX[1])
                            || (pbGhostBlue.Top == waypointsY[8] && pbGhostBlue.Left == waypointsX[8])
                            || (pbGhostBlue.Top == waypointsY[9] && pbGhostBlue.Left == waypointsX[4])
                            || (pbGhostBlue.Top == waypointsY[9] && pbGhostBlue.Left == waypointsX[5]))
                    {
                        ghostMoveLRU("blueScatter");
                    }
                    //LUD
                    else if ((pbGhostBlue.Top == waypointsY[1] && pbGhostBlue.Left == waypointsX[9])
                            || (pbGhostBlue.Top == waypointsY[2] && pbGhostBlue.Left == waypointsX[2])
                            || (pbGhostBlue.Top == waypointsY[4] && pbGhostBlue.Left == waypointsX[3])
                            || (pbGhostBlue.Top == waypointsY[5] && pbGhostBlue.Left == waypointsX[6])
                            || (pbGhostBlue.Top == waypointsY[7] && pbGhostBlue.Left == waypointsX[7]))
                    {
                        ghostMoveLUD("blueScatter");
                    }
                    //LRUD
                    else if ((pbGhostBlue.Top == waypointsY[1] && pbGhostBlue.Left == waypointsX[2])
                            || (pbGhostBlue.Top == waypointsY[1] && pbGhostBlue.Left == waypointsX[7])
                            || (pbGhostBlue.Top == waypointsY[4] && pbGhostBlue.Left == waypointsX[2])
                            || (pbGhostBlue.Top == waypointsY[4] && pbGhostBlue.Left == waypointsX[7])
                            || (pbGhostBlue.Top == waypointsY[6] && pbGhostBlue.Left == waypointsX[2])
                            || (pbGhostBlue.Top == waypointsY[6] && pbGhostBlue.Left == waypointsX[7]))
                    {
                        ghostMoveLRUD("blueScatter");
                    }
                    break;
                    */

            }


        }


        #endregion

        #region Ghost Frightened

        bool ghostFrightend = false;

        

        #endregion

        #region Ghost Dead

        bool ghostDead = false;



        #endregion

        #region Ghost In house Method

        private void GhostsInHouse()
        {
            int leftExit = 220;
            int rightExit = 236;
            int inHouseStartY = 230;
            if (redInHouse)
            {
                Settings.GhostPinkDirection = Directions.Stop;
                Settings.GhostBlueDirection = Directions.Stop;
                Settings.GhostOrangeDirection = Directions.Stop;

                if (pbGhostRed.Left > rightExit && pbGhostRed.Top == inHouseStartY)
                {
                    Settings.GhostRedDirection = Directions.Left;
                }
                else if (pbGhostRed.Left == rightExit && pbGhostRed.Top > waypointsY[3])
                {
                    Settings.GhostRedDirection = Directions.Up;
                }
                else if (pbGhostRed.Left == rightExit && pbGhostRed.Top == waypointsY[3])
                {
                    Settings.GhostRedDirection = Directions.Right;
                    scatter = true;
                    redInHouse = false;
                }

            }
            else if (!redInHouse)
            {
                if (pinkInHouse)
                {
                    if (pbGhostPink.Left < leftExit && pbGhostPink.Top == inHouseStartY)
                    {
                        Settings.GhostPinkDirection = Directions.Right;
                    }
                    else if (pbGhostPink.Left == leftExit && pbGhostPink.Top > waypointsY[3])
                    {
                        Settings.GhostPinkDirection = Directions.Up;
                    }
                    else if (pbGhostPink.Left == leftExit && pbGhostPink.Top == waypointsY[3])
                    {
                        Settings.GhostPinkDirection = Directions.Left;
                        scatter = true;
                        pinkInHouse = false;
                    }
                }
                else if (!pinkInHouse)
                {
                    if (blueInHouse)
                    {
                        if (pbGhostBlue.Left > rightExit && pbGhostBlue.Top == inHouseStartY)
                        {
                            Settings.GhostBlueDirection = Directions.Left;
                        }
                        else if (pbGhostBlue.Left == rightExit && pbGhostBlue.Top > waypointsY[3])
                        {
                            Settings.GhostBlueDirection = Directions.Up;
                        }
                        else if (pbGhostBlue.Left == rightExit && pbGhostBlue.Top == waypointsY[3])
                        {
                            Settings.GhostBlueDirection = Directions.Right;
                            scatter = true;
                            blueInHouse = false;
                        }
                    }
                    else if (!blueInHouse)
                    {
                        if (orangeInHouse)
                        {
                            if (pbGhostOrange.Left < leftExit && pbGhostOrange.Top == inHouseStartY)
                            {
                                Settings.GhostOrangeDirection = Directions.Right;
                            }
                            else if (pbGhostOrange.Left == leftExit && pbGhostOrange.Top > waypointsY[3])
                            {
                                Settings.GhostOrangeDirection = Directions.Up;
                            }
                            else if (pbGhostOrange.Left == leftExit && pbGhostOrange.Top == waypointsY[3])
                            {
                                Settings.GhostOrangeDirection = Directions.Left;
                                scatter = true;
                                orangeInHouse = false;
                            }
                        }

                    }
                }
            }
        }
        #endregion

        #region Ghost Methods Left, Right, Up, or Down

        #region constant Move methods

        public void ghostMoveRD(string ghost)
        {
            switch (ghost)
            {
                case "ghostRed":
                    if (Settings.GhostRedDirection == Directions.Up)
                        Settings.GhostRedDirection = Directions.Right;
                    if (Settings.GhostRedDirection == Directions.Left)
                        Settings.GhostRedDirection = Directions.Down;
                    redMoveRD = false;
                    break;
                case "ghostPink":
                    if (Settings.GhostPinkDirection == Directions.Up)
                        Settings.GhostPinkDirection = Directions.Right;
                    if (Settings.GhostPinkDirection == Directions.Left)
                        Settings.GhostPinkDirection = Directions.Down;
                    pinkMoveRD = false;
                    break;
                case "ghostOrange":
                    if (Settings.GhostOrangeDirection == Directions.Up)
                        Settings.GhostOrangeDirection = Directions.Right;
                    if (Settings.GhostOrangeDirection == Directions.Left)
                        Settings.GhostOrangeDirection = Directions.Down;
                    orangeMoveRD = false;
                    break;
                case "ghostBlue":
                    if (Settings.GhostBlueDirection == Directions.Up)
                        Settings.GhostBlueDirection = Directions.Right;
                    if (Settings.GhostBlueDirection == Directions.Left)
                        Settings.GhostBlueDirection = Directions.Down;
                    blueMoveRD = false;
                    break;
            }

        }
        public void ghostMoveRU(string ghost)
        {
            switch (ghost)
            {
                case "ghostRed":
                    if (Settings.GhostRedDirection == Directions.Down)
                        Settings.GhostRedDirection = Directions.Right;
                    if (Settings.GhostRedDirection == Directions.Left)
                        Settings.GhostRedDirection = Directions.Up;
                    redMoveRU = false;
                    break;
                case "ghostPink":
                    if (Settings.GhostPinkDirection == Directions.Down)
                        Settings.GhostPinkDirection = Directions.Right;
                    if (Settings.GhostPinkDirection == Directions.Left)
                        Settings.GhostPinkDirection = Directions.Up;
                    pinkMoveRU = false;
                    break;
                case "ghostOrange":
                    if (Settings.GhostOrangeDirection == Directions.Down)
                        Settings.GhostOrangeDirection = Directions.Right;
                    if (Settings.GhostOrangeDirection == Directions.Left)
                        Settings.GhostOrangeDirection = Directions.Up;
                    orangeMoveRU = false;
                    break;
                case "ghostBlue":
                    if (Settings.GhostBlueDirection == Directions.Down)
                        Settings.GhostBlueDirection = Directions.Right;
                    if (Settings.GhostBlueDirection == Directions.Left)
                        Settings.GhostBlueDirection = Directions.Up;
                    blueMoveRU = false;
                    break;
            }

        }
        public void ghostMoveLD(string ghost)
        {
            switch (ghost)
            {
                case "ghostRed":
                    if (Settings.GhostRedDirection == Directions.Up)
                        Settings.GhostRedDirection = Directions.Left;
                    if (Settings.GhostRedDirection == Directions.Right)
                        Settings.GhostRedDirection = Directions.Down;
                    redMoveLD = false;
                    break;
                case "ghostPink":
                    if (Settings.GhostPinkDirection == Directions.Up)
                        Settings.GhostPinkDirection = Directions.Left;
                    if (Settings.GhostPinkDirection == Directions.Right)
                        Settings.GhostPinkDirection = Directions.Down;
                    pinkMoveLD = false;
                    break;
                case "ghostOrange":
                    if (Settings.GhostOrangeDirection == Directions.Up)
                        Settings.GhostOrangeDirection = Directions.Left;
                    if (Settings.GhostOrangeDirection == Directions.Right)
                        Settings.GhostOrangeDirection = Directions.Down;
                    orangeMoveLD = false;
                    break;
                case "ghostBlue":
                    if (Settings.GhostBlueDirection == Directions.Up)
                        Settings.GhostBlueDirection = Directions.Left;
                    if (Settings.GhostBlueDirection == Directions.Right)
                        Settings.GhostBlueDirection = Directions.Down;
                    blueMoveLD = false;
                    break;
            }

        }
        public void ghostMoveLU(string ghost)
        {
            switch (ghost)
            {
                case "ghostRed":
                    if (Settings.GhostRedDirection == Directions.Down)
                        Settings.GhostRedDirection = Directions.Left;
                    if (Settings.GhostRedDirection == Directions.Right)
                        Settings.GhostRedDirection = Directions.Up;
                    redMoveLU = false;
                    break;
                case "ghostPink":
                    if (Settings.GhostPinkDirection == Directions.Down)
                        Settings.GhostPinkDirection = Directions.Left;
                    if (Settings.GhostPinkDirection == Directions.Right)
                        Settings.GhostPinkDirection = Directions.Up;
                    pinkMoveLU = false;
                    break;
                case "ghostOrange":
                    if (Settings.GhostOrangeDirection == Directions.Down)
                        Settings.GhostOrangeDirection = Directions.Left;
                    if (Settings.GhostOrangeDirection == Directions.Right)
                        Settings.GhostOrangeDirection = Directions.Up;
                    orangeMoveLU = false;
                    break;
                case "ghostBlue":
                    if (Settings.GhostBlueDirection == Directions.Down)
                        Settings.GhostBlueDirection = Directions.Left;
                    if (Settings.GhostBlueDirection == Directions.Right)
                        Settings.GhostBlueDirection = Directions.Up;
                    blueMoveLU = false;
                    break;
            }

        }


        #endregion

        int[] ghostRedScatterXY = new int[] { 450, 0 };
        int[] ghostPinkScatterXY = new int[] { 0, 0 };
        int[] ghostBlueScatterXY = new int[] { 450, 490 };
        int[] ghostOrangeScatterXY = new int[] { 0, 490 };



        public void ghostMoveLRU(string ghost)
        {

            switch (ghost)
            {
                case "ghostRedScatter":
                    if (((ghostRedScatterXY[1] + pbGhostRed.Top) > (ghostRedScatterXY[0] - pbGhostRed.Left)))
                    {
                        if (Settings.GhostRedDirection != Directions.Down)
                        {
                            Settings.GhostRedDirection = Directions.Up;
                        }
                        else
                        {
                            Settings.GhostRedDirection = Directions.Right;
                        }
                    }
                    if (((ghostRedScatterXY[1] + pbGhostRed.Top) < (ghostRedScatterXY[0] - pbGhostRed.Left)))
                    {
                        if (Settings.GhostRedDirection != Directions.Left)
                        {
                            Settings.GhostRedDirection = Directions.Right;
                        }
                        else
                        {
                            Settings.GhostRedDirection = Directions.Up;
                        }
                    }
                    redMoveLRU = false;

                    break;
                case "pinkScatter":
                    if (pbGhostPink.Top > pbGhostPink.Left)
                    {
                        if (Settings.GhostPinkDirection != Directions.Down)
                        {
                            Settings.GhostPinkDirection = Directions.Up;
                        }
                        else
                        {
                            Settings.GhostPinkDirection = Directions.Left;
                        }
                    }
                    if (pbGhostPink.Top < pbGhostPink.Left)
                    {
                        if (Settings.GhostPinkDirection != Directions.Right)
                        {
                            Settings.GhostPinkDirection = Directions.Left;
                        }
                        else
                        {
                            Settings.GhostPinkDirection = Directions.Up;
                        }
                    }
                    pinkMoveLRU = false;


                    break;
                case "orangeScatter":
                    if (((ghostOrangeScatterXY[1] - pbGhostOrange.Top) > (pbGhostOrange.Left)))
                    {
                        if (Settings.GhostOrangeDirection != Directions.Right)
                        {
                            Settings.GhostOrangeDirection = Directions.Left;
                        }
                        else
                        {
                            Settings.GhostOrangeDirection = Directions.Up;
                        }
                    }
                    if (((ghostOrangeScatterXY[1] - pbGhostOrange.Top) < (pbGhostOrange.Left)))
                    {
                        if (Settings.GhostOrangeDirection != Directions.Right)
                        {
                            Settings.GhostOrangeDirection = Directions.Left;
                        }
                        else
                        {
                            Settings.GhostOrangeDirection = Directions.Up;
                        }
                    }
                    orangeMoveLRU = false;

                    break;
                case "blueScatter":
                    if (((ghostBlueScatterXY[1] - pbGhostBlue.Top) > (ghostBlueScatterXY[0] - pbGhostBlue.Left)))
                    {
                        if (Settings.GhostBlueDirection != Directions.Left)
                        {
                            Settings.GhostBlueDirection = Directions.Right;
                        }
                        else
                        {
                            Settings.GhostBlueDirection = Directions.Up;
                        }
                    }
                    if (((ghostBlueScatterXY[1] - pbGhostBlue.Top) < (ghostBlueScatterXY[0] - pbGhostBlue.Left)))
                    {
                        if (Settings.GhostBlueDirection != Directions.Left)
                        {
                            Settings.GhostBlueDirection = Directions.Right;
                        }
                        else
                        {
                            Settings.GhostBlueDirection = Directions.Up;
                        }
                    }
                    blueMoveLRU = false;


                    break;
            }

        }

        public void ghostMoveLRD(string ghost)
        {
            switch (ghost)
            {
                case "ghostRedScatter":
                        if (Settings.GhostRedDirection != Directions.Left)
                        {
                            Settings.GhostRedDirection = Directions.Right;
                        }
                        else
                        {
                            Settings.GhostRedDirection = Directions.Down;
                        }
                    redMoveLRD = false;

                    break;

                case "pinkScatter":
                    if (Settings.GhostPinkDirection != Directions.Right)
                    {
                        Settings.GhostPinkDirection = Directions.Left;
                    }
                    else
                    {
                        Settings.GhostPinkDirection = Directions.Down;
                    }
                    pinkMoveLRD = false;

                    break;

                case "orangeScatter":
                    if (Settings.GhostOrangeDirection != Directions.Right)
                    {
                        Settings.GhostOrangeDirection = Directions.Left;
                    }
                    else
                    {
                        Settings.GhostOrangeDirection = Directions.Down;
                    }
                    orangeMoveLRD = false;

                    break;

                case "blueScatter":
                    if (Settings.GhostBlueDirection != Directions.Left)
                    {
                        Settings.GhostBlueDirection = Directions.Right;
                    }
                    else
                    {
                        Settings.GhostBlueDirection = Directions.Down;
                    }
                    blueMoveLRD = false; 

                    break;
            }

        }
        public void ghostMoveRUD(string ghost)
        {
            switch (ghost)
            {
                case "ghostRedScatter":
                    if (((ghostRedScatterXY[1] + pbGhostRed.Top) > (ghostRedScatterXY[0] - pbGhostRed.Left)))
                    {
                        if (Settings.GhostRedDirection != Directions.Down)
                        {
                            Settings.GhostRedDirection = Directions.Up;
                        }
                        else
                        {
                            Settings.GhostRedDirection = Directions.Right;
                        }
                    }
                    if (((ghostRedScatterXY[1] + pbGhostRed.Top) < (ghostRedScatterXY[0] - pbGhostRed.Left)))
                    {
                        if (Settings.GhostRedDirection != Directions.Left)
                        {
                            Settings.GhostRedDirection = Directions.Right;
                        }
                        else
                        {
                            Settings.GhostRedDirection = Directions.Up;
                        }
                    }
                    redMoveRUD = false;


                    break;
                case "pinkScatter":
                    if (pbGhostPink.Top > pbGhostPink.Left)
                    {
                        if (Settings.GhostPinkDirection != Directions.Down)
                        {
                            Settings.GhostPinkDirection = Directions.Up;
                        }
                        else
                        {
                            Settings.GhostPinkDirection = Directions.Right;
                        }
                    }
                    if (pbGhostPink.Top < pbGhostPink.Left)
                    {
                        if (Settings.GhostPinkDirection != Directions.Right)
                        {
                            Settings.GhostPinkDirection = Directions.Left;
                        }
                        else
                        {
                            Settings.GhostPinkDirection = Directions.Up;
                        }
                    }
                    pinkMoveRUD = false;

                    break;

                case "orangeScatter":
                    if (((ghostOrangeScatterXY[1] - pbGhostOrange.Top) > (pbGhostOrange.Left)))
                    {
                        if (Settings.GhostOrangeDirection != Directions.Up)
                        {
                            Settings.GhostOrangeDirection = Directions.Down;
                        }
                        else
                        {
                            Settings.GhostOrangeDirection = Directions.Right;
                        }
                    }
                    if (((ghostOrangeScatterXY[1] - pbGhostOrange.Top) < (pbGhostOrange.Left)))
                    {
                        if (Settings.GhostOrangeDirection != Directions.Right)
                        {
                            Settings.GhostOrangeDirection = Directions.Left;
                        }
                        else
                        {
                            Settings.GhostOrangeDirection = Directions.Up;
                        }
                    }
                    orangeMoveRUD = false;

                    break;
                case "blueScatter":
                    if (((ghostBlueScatterXY[1] + pbGhostBlue.Top) > (ghostBlueScatterXY[0] - pbGhostBlue.Left)))
                    {
                        if (Settings.GhostBlueDirection != Directions.Up)
                        {
                            Settings.GhostBlueDirection = Directions.Down;
                        }
                        else
                        {
                            Settings.GhostBlueDirection = Directions.Right;
                        }
                    }
                    if (((ghostBlueScatterXY[1] - pbGhostBlue.Top) < (ghostBlueScatterXY[0] - pbGhostBlue.Left)))
                    {
                        if (Settings.GhostBlueDirection != Directions.Left)
                        {
                            Settings.GhostBlueDirection = Directions.Right;
                        }
                        else
                        {
                            Settings.GhostBlueDirection = Directions.Up;
                        }
                    }
                    blueMoveRUD = false;

                    break;
            }

        }
        public void ghostMoveLUD(string ghost)
        {
            switch (ghost)
            {
                case "ghostRedScatter":
                    if (((ghostRedScatterXY[1] + pbGhostRed.Top) > (ghostRedScatterXY[0] - pbGhostRed.Left)))
                    {
                        if (Settings.GhostRedDirection != Directions.Down)
                        {
                            Settings.GhostRedDirection = Directions.Up;
                        }
                        else
                        {
                            Settings.GhostRedDirection = Directions.Left;
                        }
                    }
                    if (((ghostRedScatterXY[1] + pbGhostRed.Top) < (ghostRedScatterXY[0] - pbGhostRed.Left)))
                    {
                        if (Settings.GhostRedDirection != Directions.Down)
                        {
                            Settings.GhostRedDirection = Directions.Up;
                        }
                        else
                        {
                            Settings.GhostRedDirection = Directions.Left;
                        }
                    }
                    redMoveLUD = false;


                    break;
                case "pinkScatter":
                    if (pbGhostPink.Top > pbGhostPink.Left)
                    {
                        if (Settings.GhostPinkDirection != Directions.Down)
                        {
                            Settings.GhostPinkDirection = Directions.Up;
                        }
                        else
                        {
                            Settings.GhostPinkDirection = Directions.Left;
                        }
                    }
                    if (pbGhostPink.Top < pbGhostPink.Left)
                    {
                        if (Settings.GhostPinkDirection != Directions.Right)
                        {
                            Settings.GhostPinkDirection = Directions.Left;
                        }
                        else
                        {
                            Settings.GhostPinkDirection = Directions.Up;
                        }
                    }
                    pinkMoveLUD = false;

                    break;
                case "orangeScatter":
                    if (((ghostOrangeScatterXY[1] - pbGhostOrange.Top) > (pbGhostOrange.Left)))
                    {
                        if (Settings.GhostOrangeDirection != Directions.Up)
                        {
                            Settings.GhostOrangeDirection = Directions.Down;
                        }
                        else
                        {
                            Settings.GhostOrangeDirection = Directions.Left;
                        }
                    }
                    if (((ghostOrangeScatterXY[1] - pbGhostOrange.Top) < (pbGhostOrange.Left)))
                    {
                        if (Settings.GhostOrangeDirection != Directions.Right)
                        {
                            Settings.GhostOrangeDirection = Directions.Left;
                        }
                        else
                        {
                            Settings.GhostOrangeDirection = Directions.Up;
                        }
                    }
                    orangeMoveLUD = false;
                    break;
                case "blueScatter":
                    if (((ghostBlueScatterXY[1] - pbGhostBlue.Top) > (ghostBlueScatterXY[0] - pbGhostBlue.Left)))
                    {
                        if (Settings.GhostBlueDirection != Directions.Up)
                        {
                            Settings.GhostBlueDirection = Directions.Down;
                        }
                        else
                        {
                            Settings.GhostBlueDirection = Directions.Left;
                        }
                    }
                    if (((ghostBlueScatterXY[1] + pbGhostBlue.Top) < (ghostBlueScatterXY[0] - pbGhostBlue.Left)))
                    {
                        if (Settings.GhostBlueDirection != Directions.Down)
                        {
                            Settings.GhostBlueDirection = Directions.Up;
                        }
                        else
                        {
                            Settings.GhostBlueDirection = Directions.Left;
                        }
                    }
                    blueMoveLUD = false;
                    break;
            }

        }
        public void ghostMoveLRUD(string ghost)
        {
            switch (ghost)
            {
                case "ghostRedScatter":
                    if (((ghostRedScatterXY[1] + pbGhostRed.Top) > (ghostRedScatterXY[0] - pbGhostRed.Left)))
                    {
                        if (Settings.GhostRedDirection != Directions.Down)
                        {
                            Settings.GhostRedDirection = Directions.Up;
                        }
                        else
                        {
                            Settings.GhostRedDirection = Directions.Right;
                        }
                    }
                    if (((ghostRedScatterXY[1] + pbGhostRed.Top) < (ghostRedScatterXY[0] - pbGhostRed.Left)))
                    {
                        if (Settings.GhostRedDirection != Directions.Left)
                        {
                            Settings.GhostRedDirection = Directions.Right;
                        }
                        else
                        {
                            Settings.GhostRedDirection = Directions.Up;
                        }
                    }
                    redMoveLRUD = false;

                    break;
                case "pinkScatter":
                    if (pbGhostPink.Top > pbGhostPink.Left)
                    {
                        if (Settings.GhostPinkDirection != Directions.Down)
                        {
                            Settings.GhostPinkDirection = Directions.Up;
                        }
                        else
                        {
                            Settings.GhostPinkDirection = Directions.Left;
                        }
                    }
                    if (pbGhostPink.Top < pbGhostPink.Left)
                    {
                        if (Settings.GhostPinkDirection != Directions.Right)
                        {
                            Settings.GhostPinkDirection = Directions.Left;
                        }
                        else
                        {
                            Settings.GhostPinkDirection = Directions.Up;
                        }
                    }
                    pinkMoveLRUD = false;


                    break;
                case "orangeScatter":
                    if (((ghostOrangeScatterXY[1] - pbGhostOrange.Top) > (pbGhostOrange.Left)))
                    {
                        if (Settings.GhostOrangeDirection != Directions.Up)
                        {
                            Settings.GhostOrangeDirection = Directions.Down;
                        }
                        else
                        {
                            Settings.GhostOrangeDirection = Directions.Right;
                        }
                    }
                    if (((ghostOrangeScatterXY[1] - pbGhostOrange.Top) < (pbGhostOrange.Left)))
                    {
                        if (Settings.GhostOrangeDirection != Directions.Right)
                        {
                            Settings.GhostOrangeDirection = Directions.Left;
                        }
                        else
                        {
                            Settings.GhostOrangeDirection = Directions.Down;
                        }
                    }
                    orangeMoveLRUD = false;


                    break;
                case "blueScatter":
                    if (((ghostBlueScatterXY[1] - pbGhostBlue.Top) > (ghostBlueScatterXY[0] - pbGhostBlue.Left)))
                    {
                        if (Settings.GhostBlueDirection != Directions.Up)
                        {
                            Settings.GhostBlueDirection = Directions.Down;
                        }
                        else
                        {
                            Settings.GhostBlueDirection = Directions.Right;
                        }
                    }
                    if (((ghostBlueScatterXY[1] + pbGhostBlue.Top) < (ghostBlueScatterXY[0] - pbGhostBlue.Left)))
                    {
                        if (Settings.GhostBlueDirection != Directions.Left)
                        {
                            Settings.GhostBlueDirection = Directions.Right;
                        }
                        else
                        {
                            Settings.GhostBlueDirection = Directions.Down;
                        }
                    }
                    blueMoveLRUD = false;

                    break;
            }

        }


        #endregion


    }
}

    
