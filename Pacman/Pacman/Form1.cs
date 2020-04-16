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

        int[] waypointsX = new int[10] { 24, 52, 104, 152, 200, 248, 296, 344, 392, 424 };
        int[] waypointsY = new int[] { 20, 88, 136, 180, 232, 280, 328, 376, 420, 472 };
        int PlayerSpeed = 4;
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
            PlayerWhichWaypoint();

            if (Settings.playerDirection == Directions.Left || Settings.playerDirection == Directions.Right)
            {
                PlayerRightLeftMovment();
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
            }
            if (e.KeyCode == Keys.Down)
            {
                UpDown = false;
                keyUp = false;
                keyDown = true;
                keyRight = false;
                keyLeft = false;

            }
            if (e.KeyCode == Keys.Left)
            {
                RightLeft = false;
                keyUp = false;
                keyDown = false;
                keyRight = false;
                keyLeft = true;
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
                || (player.Top > waypointsY[3] && player.Top < waypointsY[4])
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

        private void PlayerRightLeftMovment()
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
                || (player.Left > waypointsX[7] && player.Left < 472))) //the cross over
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
            else if (((player.Top == waypointsY[4]) && (player.Left == -20)))
            {
                player.Left = 468;
            }
            // The Cross over left to right
            else if (((player.Top == waypointsY[4]) && (player.Left == 472)))
            {
                player.Left = -16;

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
                EStart = 270, EStop = 310, FStart = 270, FStop = 360,
                GStart = 370, GStop = 430;

            Circles bigOne1 = new Circles();
            bigOne1.coinLeft = 31;
            bigOne1.coinTop = Y[7] - 10;
            bigOne1.mkBig(this);
            Circles bigOne2 = new Circles();
            bigOne2.coinLeft = 31;
            bigOne2.coinTop = 55;
            bigOne2.mkBig(this);
            Circles bigOne3 = new Circles();
            bigOne3.coinLeft = 426;
            bigOne3.coinTop = Y[7] - 10;
            bigOne3.mkBig(this);
            Circles bigOne4 = new Circles();
            bigOne4.coinLeft = 426;
            bigOne4.coinTop = 55;
            bigOne4.mkBig(this);


            //row 0
            for (int i = AStart; i < AStop; i += spacing)
            {
                Circles coin = new Circles();
                coin.coinLeft = i;
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
            int Y1Start = 430, Y1Stop = 480, Y2Start = 335, Y2Stop = 385,
                Y3Start = 380, Y3Stop = 420, Y4Start = 400, Y4Stop = 430,
                Y5Start = 30, Y5Stop = 430, Y6Start = 30, Y6Stop = 140,
                Y7Start = 110, Y7Stop = 140, Y8Start = 30, Y8Stop = 85;
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
                            if (coinCount == 252)
                                youWin = true;
                        }
                    }
                }
                foreach (Control j in this.Controls)
                {//to identify coins to collect
                    if ((j is PictureBox && j.Tag == "big"))
                    {
                        if (player.Bounds.IntersectsWith(j.Bounds))
                        {

                            this.Controls.Remove(j);
                            j.Dispose();
                            BigDot();
                        }
                    }
                }


            }
            if (youWin)
            {
                YouWin();
            }
        }

        private void BigDot()
        {
            redScatter = false; pinkScatter = false; orangeScatter = false; blueScatter = false;
            redFrightend = true; pinkFrightend = true; orangeFrightend = true; blueFrightend = true;
            frightenedTimer.Start();
            ghostTimer.Interval = 300;
            pbGhostRed.Image = Properties.Resources.crazy;
            pbGhostPink.Image = Properties.Resources.crazy;
            pbGhostOrange.Image = Properties.Resources.crazy;
            pbGhostBlue.Image = Properties.Resources.crazy;
            pbGhostRed.Tag = "frightend";
            pbGhostPink.Tag = "frightend";
            pbGhostOrange.Tag = "frightend";
            pbGhostBlue.Tag = "frightend";
            RedGhost360();
            PinkGhost360();
            OrangeGhost360();
            BlueGhost360();

        }

        private void YouWin()
        {
            throw new NotImplementedException();
        }



        #endregion

        #region Ghost Timers

        bool chase = false;
        bool redScatter = false, pinkScatter = false, orangeScatter = false, blueScatter = false;
        bool redInHouse = true, pinkInHouse = true, blueInHouse = true, orangeInHouse = true;
        bool redFrightend = false, pinkFrightend = false, orangeFrightend = false, blueFrightend = false;
        bool redDead = false, pinkDead = false, orangeDead = false, blueDead = false;

        int ghostSpeed = 2;
        int fearSpeed = 2;


        private void ghostTimer_Tick(object sender, EventArgs e)
        {
            if (redInHouse)
            {
                RedMovmentMethod();
                GhostsInHouse();
            }
            if (pinkInHouse)
            {
                PinkMovmentMethod();
                GhostsInHouse();
            }
            if (orangeInHouse)
            {
                OrangeMovmentMethod();
                GhostsInHouse();
            }
            if (blueInHouse)
            {
                BlueMovmentMethod();
                GhostsInHouse();
            }


            if (redScatter && !redFrightend)
            {
                RedMovmentMethod();
                GhostAtWaypointTrue("ghostRed");
                ghostScatter("ghostRed");
            }
            if (pinkScatter&& !pinkFrightend)
            {
                PinkMovmentMethod();
                GhostAtWaypointTrue("ghostPink");
                ghostScatter("ghostPink");
            }
            if (orangeScatter && !orangeFrightend)
            {
                OrangeMovmentMethod();
                GhostAtWaypointTrue("ghostOrange");
                ghostScatter("ghostOrange");
            }
            if (blueScatter && !blueFrightend)
            {
                BlueMovmentMethod();
                GhostAtWaypointTrue("ghostBlue");
                ghostScatter("ghostBlue");
            }


            if (redFrightend && !redInHouse)
            {
                RedMovmentFear();
                GhostAtWaypointTrue("ghostRed");
                GhostFrightendMovement("ghostRed");
            }
            if (pinkFrightend && !pinkInHouse)
            {
                PinkMovmentFear();
                GhostAtWaypointTrue("ghostPink");
                GhostFrightendMovement("ghostPink");
            }
            if (orangeFrightend && !orangeInHouse)
            {
                OrangeMovmentFear();
                GhostAtWaypointTrue("ghostOrange");
                GhostFrightendMovement("ghostOrange");
            }
            if (blueFrightend && !blueInHouse)
            {
                BlueMovmentFear();
                GhostAtWaypointTrue("ghostBlue");
                GhostFrightendMovement("ghostBlue");
            }



        }


        private void frightenedTimer_Tick(object sender, EventArgs e)
        {
            frightenedTimer.Stop();


            if (redFrightend)
                pbGhostRed.Image = Properties.Resources.Gtemp;
            if (pinkFrightend)
                pbGhostPink.Image = Properties.Resources.Gtemp;
            if (orangeFrightend)
                pbGhostOrange.Image = Properties.Resources.Gtemp;
            if (blueFrightend)
                pbGhostBlue.Image = Properties.Resources.Gtemp;


            warningTimer.Start();
        }

        private void warningTimer_Tick(object sender, EventArgs e)
        {
            warningTimer.Stop();
            pbGhostRed.Tag = "ghost";
            pbGhostPink.Tag = "ghost";
            pbGhostOrange.Tag = "ghost";
            pbGhostBlue.Tag = "ghost";
            redFrightend = false; pinkFrightend = false; orangeFrightend = false; blueFrightend = false;
            redScatter = true; pinkScatter = true; orangeScatter = true; blueScatter = true;
            ghostTimer.Interval = 150;


        }


        #endregion

        #region 360 methods

        private void RedGhost360()
        {
            redMoveRD = false; redMoveLD = false; redMoveLU = false; redMoveRU = false;
            redMoveLRD = false; redMoveRUD = false; redMoveLRU = false; redMoveLUD = false; redMoveLRUD = false;

            if (Settings.GhostRedDirection == Directions.Down)
                Settings.GhostRedDirection = Directions.Up;
            else if (Settings.GhostRedDirection == Directions.Up)
                Settings.GhostRedDirection = Directions.Down;
            else if (Settings.GhostRedDirection == Directions.Left)
                Settings.GhostRedDirection = Directions.Right;
            else if (Settings.GhostRedDirection == Directions.Right)
                Settings.GhostRedDirection = Directions.Left;
            GhostAtWaypointTrue("ghostRed");

        }
        private void PinkGhost360()
        {
            pinkMoveRD = false; pinkMoveLD = false; pinkMoveLU = false; pinkMoveRU = false;
            pinkMoveLRD = false; pinkMoveRUD = false; pinkMoveLRU = false; pinkMoveLUD = false; pinkMoveLRUD = false;
            if (Settings.GhostPinkDirection == Directions.Down)
                Settings.GhostPinkDirection = Directions.Up;
            else if (Settings.GhostPinkDirection == Directions.Up)
                Settings.GhostPinkDirection = Directions.Down;
            else if (Settings.GhostPinkDirection == Directions.Left)
                Settings.GhostPinkDirection = Directions.Right;
            else if (Settings.GhostPinkDirection == Directions.Right)
                Settings.GhostPinkDirection = Directions.Left;
            GhostAtWaypointTrue("ghostPink");

        }
        private void OrangeGhost360()
        {
            orangeMoveRD = false; orangeMoveLD = false; orangeMoveLU = false; orangeMoveRU = false;
            orangeMoveLRD = false; orangeMoveRUD = false; orangeMoveLRU = false; orangeMoveLUD = false; orangeMoveLRUD = false;
            if (Settings.GhostOrangeDirection == Directions.Down)
                Settings.GhostOrangeDirection = Directions.Up;
            else if (Settings.GhostOrangeDirection == Directions.Up)
                Settings.GhostOrangeDirection = Directions.Down;
            else if (Settings.GhostOrangeDirection == Directions.Left)
                Settings.GhostOrangeDirection = Directions.Right;
            else if (Settings.GhostOrangeDirection == Directions.Right)
                Settings.GhostOrangeDirection = Directions.Left;
            GhostAtWaypointTrue("ghostOrange");

        }
        private void BlueGhost360()
        {
            blueMoveRD = false; blueMoveLD = false; blueMoveLU = false; blueMoveRU = false;
            blueMoveLRD = false; blueMoveRUD = false; blueMoveLRU = false; blueMoveLUD = false; blueMoveLRUD = false;
            if (Settings.GhostBlueDirection == Directions.Down)
                Settings.GhostBlueDirection = Directions.Up;
            else if (Settings.GhostBlueDirection == Directions.Up)
                Settings.GhostBlueDirection = Directions.Down;
            else if (Settings.GhostBlueDirection == Directions.Left)
                Settings.GhostBlueDirection = Directions.Right;
            else if (Settings.GhostBlueDirection == Directions.Right)
                Settings.GhostBlueDirection = Directions.Left;
            GhostAtWaypointTrue("ghostBlue");
        }

        #endregion

        #region Ghost Movment Methods
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

        private void RedMovmentFear()
        {
            if (Settings.GhostRedDirection == Directions.Up)
            {
                pbGhostRed.Top -= fearSpeed;
            }
            else if (Settings.GhostRedDirection == Directions.Down)
            {
                pbGhostRed.Top += fearSpeed;
            }
            else if (Settings.GhostRedDirection == Directions.Left)
            {
                pbGhostRed.Left -= fearSpeed;
            }
            else if (Settings.GhostRedDirection == Directions.Right)
            {
                pbGhostRed.Left += fearSpeed;
            }
            else if (Settings.GhostRedDirection == Directions.Stop)
            {
                pbGhostRed.Left += 0;
                pbGhostRed.Top += 0;
            }
        }

        private void PinkMovmentFear()
        {
            if (Settings.GhostPinkDirection == Directions.Up)
            {
                pbGhostPink.Top -= fearSpeed;
            }
            else if (Settings.GhostPinkDirection == Directions.Down)
            {
                pbGhostPink.Top += fearSpeed;
            }
            else if (Settings.GhostPinkDirection == Directions.Left)
            {
                pbGhostPink.Left -= fearSpeed;
            }
            else if (Settings.GhostPinkDirection == Directions.Right)
            {
                pbGhostPink.Left += fearSpeed;
            }
            else if (Settings.GhostPinkDirection == Directions.Stop)
            {
                pbGhostPink.Left += 0;
                pbGhostPink.Top += 0;

            }
        }


        private void OrangeMovmentFear()
        {
            if (Settings.GhostOrangeDirection == Directions.Up)
            {
                pbGhostOrange.Top -= fearSpeed;
            }
            else if (Settings.GhostOrangeDirection == Directions.Down)
            {
                pbGhostOrange.Top += fearSpeed;
            }
            else if (Settings.GhostOrangeDirection == Directions.Left)
            {
                pbGhostOrange.Left -= fearSpeed;
            }
            else if (Settings.GhostOrangeDirection == Directions.Right)
            {
                pbGhostOrange.Left += fearSpeed;
            }
            else if (Settings.GhostOrangeDirection == Directions.Stop)
            {
                pbGhostOrange.Left += 0;
                pbGhostOrange.Top += 0;

            }
        }

        private void BlueMovmentFear()
        {
            if (Settings.GhostBlueDirection == Directions.Up)
            {
                pbGhostBlue.Top -= fearSpeed;
            }
            else if (Settings.GhostBlueDirection == Directions.Down)
            {
                pbGhostBlue.Top += fearSpeed;
            }
            else if (Settings.GhostBlueDirection == Directions.Left)
            {
                pbGhostBlue.Left -= fearSpeed;
            }
            else if (Settings.GhostBlueDirection == Directions.Right)
            {
                pbGhostBlue.Left += fearSpeed;
            }
            else if (Settings.GhostBlueDirection == Directions.Stop)
            {
                pbGhostBlue.Left += 0;
                pbGhostBlue.Top += 0;

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
                case "ghostRed":
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
                                  || (pbGhostRed.Top == waypointsY[6] && pbGhostRed.Left == waypointsX[3])
                                  || (pbGhostRed.Top == waypointsY[6] && pbGhostRed.Left == waypointsX[6])
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
                    else if (((pbGhostRed.Top == waypointsY[4]) && (pbGhostRed.Left == -20)))
                    {
                        pbGhostRed.Left = 470;
                        Settings.GhostRedDirection = Directions.Left;
                    }
                    // The Cross over left to right
                    else if (((pbGhostRed.Top == waypointsY[4]) && (pbGhostRed.Left == 472)))
                    {
                        pbGhostRed.Left = -18;
                        Settings.GhostRedDirection = Directions.Right;

                    }

                    break;


                case "ghostPink":
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
                    else if (((pbGhostPink.Top == waypointsY[4]) && (pbGhostPink.Left == -20)))
                    {
                        pbGhostPink.Left = 470;
                        Settings.GhostPinkDirection = Directions.Left;

                    }
                    // The Cross over left to right
                    else if (((pbGhostPink.Top == waypointsY[4]) && (pbGhostPink.Left == 472)))
                    {
                        pbGhostPink.Left = -18;
                        Settings.GhostPinkDirection = Directions.Right;

                    }

                    break;

                case "ghostOrange":
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
                    else if (((pbGhostOrange.Top == waypointsY[4]) && (pbGhostOrange.Left == -20)))
                    {
                        pbGhostOrange.Left = 470;
                        Settings.GhostOrangeDirection = Directions.Left;

                    }
                    // The Cross over left to right
                    else if (((pbGhostOrange.Top == waypointsY[4]) && (pbGhostOrange.Left == 472)))
                    {
                        pbGhostOrange.Left = -18;
                        Settings.GhostOrangeDirection = Directions.Right;

                    }

                    break;



                case "ghostBlue":
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
                    else if (((pbGhostBlue.Top == waypointsY[4]) && (pbGhostBlue.Left == -20)))
                    {
                        pbGhostBlue.Left = 470;
                        Settings.GhostBlueDirection = Directions.Left;

                    }
                    // The Cross over left to right
                    else if (((pbGhostBlue.Top == waypointsY[4]) && (pbGhostBlue.Left == 472)))
                    {
                        pbGhostBlue.Left = -18;
                        Settings.GhostBlueDirection = Directions.Right;

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
                case "ghostRed":
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
                        ghostMoveRU("ghostRed");
                    }
                    //LRD
                    else if (redMoveLRD)
                    {
                        GhostScatterLRD("ghostRed");
                    }
                    //RUD
                    else if (redMoveRUD)
                    {
                        GhostScatterRUD("ghostRed");
                    }
                    //LRU
                    else if (redMoveLRU)
                    {
                        GhostScatterLRU("ghostRed");
                    }
                    //LUD
                    else if (redMoveLUD)
                    {
                        GhostScatterLUD("ghostRed");
                    }
                    //LRUD
                    else if (redMoveLRUD)
                    {
                        GhostScatterLRUD("ghostRed");
                    }
                    break;


                case "ghostPink":
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
                        GhostScatterLRD("ghostPink");
                    }
                    //RUD
                    else if (pinkMoveRUD)
                    {
                        GhostScatterRUD("ghostPink");
                    }
                    //LRU
                    else if (pinkMoveLRU)
                    {
                        GhostScatterLRU("ghostPink");
                    }
                    //LUD
                    else if (pinkMoveLUD)
                    {
                        GhostScatterLUD("ghostPink");
                    }
                    //LRUD
                    else if (pinkMoveLRUD)
                    {
                        GhostScatterLRUD("ghostPink");
                    }
                    break;

                case "ghostOrange":
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
                        GhostScatterLRD("ghostOrange");
                    }
                    //RUD
                    else if (orangeMoveRUD)
                    {
                        GhostScatterRUD("ghostOrange");
                    }
                    //LRU
                    else if (orangeMoveLRU)
                    {
                        GhostScatterLRU("ghostOrange");
                    }
                    //LUD
                    else if (orangeMoveLUD)
                    {
                        GhostScatterLUD("ghostOrange");
                    }
                    //LRUD
                    else if (orangeMoveLRUD)
                    {
                        GhostScatterLRUD("ghostOrange");
                    }
                    break;



                case "ghostBlue":
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
                        GhostScatterLRD("ghostBlue");
                    }
                    //RUD
                    else if (blueMoveRUD)
                    {
                        GhostScatterRUD("ghostBlue");
                    }
                    //LRU
                    else if (blueMoveLRU)
                    {
                        GhostScatterLRU("ghostBlue");
                    }
                    //LUD
                    else if (blueMoveLUD)
                    {
                        GhostScatterLUD("ghostBlue");
                    }
                    //LRUD
                    else if (blueMoveLRUD)
                    {
                        GhostScatterLRUD("ghostBlue");
                    }
                    break;

            }


        }


        #endregion

        #region Frightend Ghosts movment

        private void GhostFrightendMovement(string ghost)
        {
            switch (ghost)
            {
                case "ghostRed":
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
                        ghostMoveRU("ghostRed");
                    }
                    //LRD
                    else if (redMoveLRD)
                    {
                        GhostFearMoveLRD("ghostRed");
                    }
                    //RUD
                    else if (redMoveRUD)
                    {
                        GhostFearMoveRUD("ghostRed");
                    }
                    //LRU
                    else if (redMoveLRU)
                    {
                        GhostFearMoveLRU("ghostRed");
                    }
                    //LUD
                    else if (redMoveLUD)
                    {
                        GhostFearMoveLUD("ghostRed");
                    }
                    //LRUD
                    else if (redMoveLRUD)
                    {
                        GhostFearMoveLRUD("ghostRed");
                    }
                    break;


                case "ghostPink":
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
                        GhostFearMoveLRD("ghostPink");
                    }
                    //RUD
                    else if (pinkMoveRUD)
                    {
                        GhostFearMoveRUD("ghostPink");
                    }
                    //LRU
                    else if (pinkMoveLRU)
                    {
                        GhostFearMoveLRU("ghostPink");
                    }
                    //LUD
                    else if (pinkMoveLUD)
                    {
                        GhostFearMoveLUD("ghostPink");
                    }
                    //LRUD
                    else if (pinkMoveLRUD)
                    {
                        GhostFearMoveLRUD("ghostPink");
                    }
                    break;

                case "ghostOrange":
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
                        GhostFearMoveLRD("ghostOrange");
                    }
                    //RUD
                    else if (orangeMoveRUD)
                    {
                        GhostFearMoveRUD("ghostOrange");
                    }
                    //LRU
                    else if (orangeMoveLRU)
                    {
                        GhostFearMoveLRU("ghostOrange");
                    }
                    //LUD
                    else if (orangeMoveLUD)
                    {
                        GhostFearMoveLUD("ghostOrange");
                    }
                    //LRUD
                    else if (orangeMoveLRUD)
                    {
                        GhostFearMoveLRUD("ghostOrange");
                    }
                    break;



                case "ghostBlue":
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
                        GhostFearMoveLRD("ghostBlue");
                    }
                    //RUD
                    else if (blueMoveRUD)
                    {
                        GhostFearMoveRUD("ghostBlue");
                    }
                    //LRU
                    else if (blueMoveLRU)
                    {
                        GhostFearMoveLRU("ghostBlue");
                    }
                    //LUD
                    else if (blueMoveLUD)
                    {
                        GhostFearMoveLUD("ghostBlue");
                    }
                    //LRUD
                    else if (blueMoveLRUD)
                    {
                        GhostFearMoveLRUD("ghostBlue");
                    }
                    break;

            }

        }

        #endregion

        #region Ghost Chase Waypoints

        private void ghostCaseWhichWaypoint(string ghost)
        {




        }


        #endregion

        #region Ghost Dead

        bool ghostDead = false;



        #endregion

        #region Ghost In house Method

        private void GhostsInHouse()
        {
            int leftExit = 220;
            int rightExit = 236;
            int inHouseStartY = 228;
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
                    redScatter = true;
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
                        pinkScatter = true;
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
                            blueScatter = true;
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
                                orangeScatter = true;
                                orangeInHouse = false;
                            }
                        }

                    }
                }
            }
        }
        #endregion

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

        #region ghost scatter AI


        public void GhostScatterLRU(string ghost)
        {

            switch (ghost)
            {

                case "ghostRed":
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
                case "ghostPink":
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
                case "ghostOrange":
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
                case "ghostBlue":
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

        public void GhostScatterLRD(string ghost)
        {

            switch (ghost)
            {

                case "ghostRed":
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

                case "ghostPink":
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

                case "ghostOrange":
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

                case "ghostBlue":
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
        public void GhostScatterRUD(string ghost)
        {

            switch (ghost)
            {

                case "ghostRed":
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
                case "ghostPink":
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

                case "ghostOrange":
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
                case "ghostBlue":
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
        public void GhostScatterLUD(string ghost)
        {

            switch (ghost)
            {

                case "ghostRed":
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
                case "ghostPink":
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
                case "ghostOrange":
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
                case "ghostBlue":
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
        public void GhostScatterLRUD(string ghost)
        {

            switch (ghost)
            {

                case "ghostRed":
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
                case "ghostPink":
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
                case "ghostOrange":
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
                case "ghostBlue":
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

        #region ghost fear AI
        Random rnd = new Random();

        public void GhostFearMoveLRU(string ghost)
        {
            int i = rnd.Next(1, 4);

            switch (ghost)
            {
                case "ghostRed":

                    switch (i)
                    {
                        case 1:
                            if (Settings.GhostRedDirection != Directions.Right)
                            {
                                Settings.GhostRedDirection = Directions.Left;
                            }
                            else
                            {
                                GhostFearMoveLRU("ghostRed");
                            }
                            break;

                        case 2:
                            if (Settings.GhostRedDirection != Directions.Left)
                            {
                                Settings.GhostRedDirection = Directions.Right;
                            }
                            else
                            {
                                GhostFearMoveLRU("ghostRed");
                            }
                            break;
                        case 3:
                            if (Settings.GhostRedDirection != Directions.Down)
                            {
                                Settings.GhostRedDirection = Directions.Up;
                            }
                            else
                            {
                                GhostFearMoveLRU("ghostRed");
                            }
                            break;
                    }
                    redMoveLRU = false;
                    break;

                case "ghostPink":
                    switch (i)
                    {
                        case 1:
                            if (Settings.GhostPinkDirection != Directions.Right)
                            {
                                Settings.GhostPinkDirection = Directions.Left;
                            }
                            else
                            {
                                GhostFearMoveLRU("ghostPink");
                            }
                            break;

                        case 2:
                            if (Settings.GhostPinkDirection != Directions.Left)
                            {
                                Settings.GhostPinkDirection = Directions.Right;
                            }
                            else
                            {
                                GhostFearMoveLRU("ghostPink");
                            }
                            break;
                        case 3:
                            if (Settings.GhostPinkDirection != Directions.Down)
                            {
                                Settings.GhostPinkDirection = Directions.Up;
                            }
                            else
                            {
                                GhostFearMoveLRU("ghostPink");
                            }
                            break;
                    }
                    pinkMoveLRU = false;
                    break;

                case "ghostOrange":
                    switch (i)
                    {
                        case 1:
                            if (Settings.GhostOrangeDirection != Directions.Right)
                            {
                                Settings.GhostOrangeDirection = Directions.Left;
                            }
                            else
                            {
                                GhostFearMoveLRU("ghostOrange");
                            }
                            break;
                        case 2:
                            if (Settings.GhostOrangeDirection != Directions.Left)
                            {
                                Settings.GhostOrangeDirection = Directions.Right;
                            }
                            else
                            {
                                GhostFearMoveLRU("ghostOrange");
                            }
                            break;
                        case 3:
                            if (Settings.GhostOrangeDirection != Directions.Down)
                            {
                                Settings.GhostOrangeDirection = Directions.Up;
                            }
                            else
                            {
                                GhostFearMoveLRU("ghostOrange");
                            }
                            break;
                    }
                    orangeMoveLRU = false;
                    break;

                case "ghostBlue":
                    switch (i)
                    {
                        case 1:
                            if (Settings.GhostBlueDirection != Directions.Right)
                            {
                                Settings.GhostBlueDirection = Directions.Left;
                            }
                            else
                            {
                                GhostFearMoveLRU("ghostBlue");
                            }
                            break;
                        case 2:
                            if (Settings.GhostBlueDirection != Directions.Left)
                            {
                                Settings.GhostBlueDirection = Directions.Right;
                            }
                            else
                            {
                                GhostFearMoveLRU("ghostBlue");
                            }
                            break;
                        case 3:
                            if (Settings.GhostBlueDirection != Directions.Down)
                            {
                                Settings.GhostBlueDirection = Directions.Up;
                            }
                            else
                            {
                                GhostFearMoveLRU("ghostBlue");
                            }
                            break;
                    }
                    blueMoveLRU = false;
                    break;
            }
        }
        public void GhostFearMoveLRD(string ghost)
        {
            int i = rnd.Next(1, 4);

            switch (ghost)
            {
                case "ghostRed":

                    switch (i)
                    {
                        case 1:
                            if (Settings.GhostRedDirection != Directions.Right)
                            {
                                Settings.GhostRedDirection = Directions.Left;
                            }
                            else
                            {
                                GhostFearMoveLRD("ghostRed");
                            }
                            break;

                        case 2:
                            if (Settings.GhostRedDirection != Directions.Left)
                            {
                                Settings.GhostRedDirection = Directions.Right;
                            }
                            else
                            {
                                GhostFearMoveLRD("ghostRed");
                            }
                            break;
                        case 3:
                            if (Settings.GhostRedDirection != Directions.Up)
                            {
                                Settings.GhostRedDirection = Directions.Down;
                            }
                            else
                            {
                                GhostFearMoveLRD("ghostRed");
                            }
                            break;
                    }
                    redMoveLRD = false;
                    break;

                case "ghostPink":
                    switch (i)
                    {
                        case 1:
                            if (Settings.GhostPinkDirection != Directions.Right)
                            {
                                Settings.GhostPinkDirection = Directions.Left;
                            }
                            else
                            {
                                GhostFearMoveLRD("ghostPink");
                            }
                            break;

                        case 2:
                            if (Settings.GhostPinkDirection != Directions.Left)
                            {
                                Settings.GhostPinkDirection = Directions.Right;
                            }
                            else
                            {
                                GhostFearMoveLRD("ghostPink");
                            }
                            break;
                        case 3:
                            if (Settings.GhostPinkDirection != Directions.Up)
                            {
                                Settings.GhostPinkDirection = Directions.Down;
                            }
                            else
                            {
                                GhostFearMoveLRD("ghostPink");
                            }
                            break;
                    }
                    pinkMoveLRD = false;
                    break;

                case "ghostOrange":
                    switch (i)
                    {
                        case 1:
                            if (Settings.GhostOrangeDirection != Directions.Right)
                            {
                                Settings.GhostOrangeDirection = Directions.Left;
                            }
                            else
                            {
                                GhostFearMoveLRD("ghostOrange");
                            }
                            break;
                        case 2:
                            if (Settings.GhostOrangeDirection != Directions.Left)
                            {
                                Settings.GhostOrangeDirection = Directions.Right;
                            }
                            else
                            {
                                GhostFearMoveLRD("ghostOrange");
                            }
                            break;
                        case 3:
                            if (Settings.GhostOrangeDirection != Directions.Up)
                            {
                                Settings.GhostOrangeDirection = Directions.Down;
                            }
                            else
                            {
                                GhostFearMoveLRD("ghostOrange");
                            }
                            break;
                    }
                    orangeMoveLRD = false;
                    break;

                case "ghostBlue":
                    switch (i)
                    {
                        case 1:
                            if (Settings.GhostBlueDirection != Directions.Right)
                            {
                                Settings.GhostBlueDirection = Directions.Left;
                            }
                            else
                            {
                                GhostFearMoveLRD("ghostBlue");
                            }
                            break;
                        case 2:
                            if (Settings.GhostBlueDirection != Directions.Left)
                            {
                                Settings.GhostBlueDirection = Directions.Right;
                            }
                            else
                            {
                                GhostFearMoveLRD("ghostBlue");
                            }
                            break;
                        case 3:
                            if (Settings.GhostBlueDirection != Directions.Up)
                            {
                                Settings.GhostBlueDirection = Directions.Down;
                            }
                            else
                            {
                                GhostFearMoveLRD("ghostBlue");
                            }
                            break;
                    }
                    blueMoveLRD = false;
                    break;
            }
        }
        public void GhostFearMoveRUD(string ghost)
        {
            int i = rnd.Next(1, 4);

            switch (ghost)
            {
                case "ghostRed":

                    switch (i)
                    {
                        case 1:
                            if (Settings.GhostRedDirection != Directions.Left)
                            {
                                Settings.GhostRedDirection = Directions.Right;
                            }
                            else
                            {
                                GhostFearMoveRUD("ghostRed");
                            }
                            break;

                        case 2:
                            if (Settings.GhostRedDirection != Directions.Down)
                            {
                                Settings.GhostRedDirection = Directions.Up;
                            }
                            else
                            {
                                GhostFearMoveRUD("ghostRed");
                            }
                            break;
                        case 3:
                            if (Settings.GhostRedDirection != Directions.Up)
                            {
                                Settings.GhostRedDirection = Directions.Down;
                            }
                            else
                            {
                                GhostFearMoveRUD("ghostRed");
                            }
                            break;
                    }
                    redMoveRUD = false;
                    break;

                case "ghostPink":
                    switch (i)
                    {
                        case 1:
                            if (Settings.GhostPinkDirection != Directions.Left)
                            {
                                Settings.GhostPinkDirection = Directions.Right;
                            }
                            else
                            {
                                GhostFearMoveRUD("ghostPink");
                            }
                            break;

                        case 2:
                            if (Settings.GhostPinkDirection != Directions.Down)
                            {
                                Settings.GhostPinkDirection = Directions.Up;
                            }
                            else
                            {
                                GhostFearMoveRUD("ghostPink");
                            }
                            break;
                        case 3:
                            if (Settings.GhostPinkDirection != Directions.Up)
                            {
                                Settings.GhostPinkDirection = Directions.Down;
                            }
                            else
                            {
                                GhostFearMoveRUD("ghostPink");
                            }
                            break;
                    }
                    pinkMoveRUD = false;
                    break;

                case "ghostOrange":
                    switch (i)
                    {
                        case 1:
                            if (Settings.GhostOrangeDirection != Directions.Down)
                            {
                                Settings.GhostOrangeDirection = Directions.Up;
                            }
                            else
                            {
                                GhostFearMoveRUD("ghostOrange");
                            }
                            break;
                        case 2:
                            if (Settings.GhostOrangeDirection != Directions.Left)
                            {
                                Settings.GhostOrangeDirection = Directions.Right;
                            }
                            else
                            {
                                GhostFearMoveRUD("ghostOrange");
                            }
                            break;
                        case 3:
                            if (Settings.GhostOrangeDirection != Directions.Up)
                            {
                                Settings.GhostOrangeDirection = Directions.Down;
                            }
                            else
                            {
                                GhostFearMoveRUD("ghostOrange");
                            }
                            break;
                    }
                    orangeMoveRUD = false;
                    break;

                case "ghostBlue":
                    switch (i)
                    {
                        case 1:
                            if (Settings.GhostBlueDirection != Directions.Down)
                            {
                                Settings.GhostBlueDirection = Directions.Up;
                            }
                            else
                            {
                                GhostFearMoveRUD("ghostBlue");
                            }
                            break;
                        case 2:
                            if (Settings.GhostBlueDirection != Directions.Left)
                            {
                                Settings.GhostBlueDirection = Directions.Right;
                            }
                            else
                            {
                                GhostFearMoveRUD("ghostBlue");
                            }
                            break;
                        case 3:
                            if (Settings.GhostBlueDirection != Directions.Up)
                            {
                                Settings.GhostBlueDirection = Directions.Down;
                            }
                            else
                            {
                                GhostFearMoveRUD("ghostBlue");
                            }
                            break;
                    }
                    blueMoveRUD = false;
                    break;
            }
        }
        public void GhostFearMoveLUD(string ghost)
        {
            int i = rnd.Next(1, 4);

            switch (ghost)
            {
                case "ghostRed":

                    switch (i)
                    {
                        case 1:
                            if (Settings.GhostRedDirection != Directions.Right)
                            {
                                Settings.GhostRedDirection = Directions.Left;
                            }
                            else
                            {
                                GhostFearMoveLUD("ghostRed");
                            }
                            break;

                        case 2:
                            if (Settings.GhostRedDirection != Directions.Down)
                            {
                                Settings.GhostRedDirection = Directions.Up;
                            }
                            else
                            {
                                GhostFearMoveLUD("ghostRed");
                            }
                            break;
                        case 3:
                            if (Settings.GhostRedDirection != Directions.Up)
                            {
                                Settings.GhostRedDirection = Directions.Down;
                            }
                            else
                            {
                                GhostFearMoveLUD("ghostRed");
                            }
                            break;
                    }
                    redMoveLUD = false;
                    break;

                case "ghostPink":
                    switch (i)
                    {
                        case 1:
                            if (Settings.GhostPinkDirection != Directions.Right)
                            {
                                Settings.GhostPinkDirection = Directions.Left;
                            }
                            else
                            {
                                GhostFearMoveLUD("ghostPink");
                            }
                            break;

                        case 2:
                            if (Settings.GhostPinkDirection != Directions.Down)
                            {
                                Settings.GhostPinkDirection = Directions.Up;
                            }
                            else
                            {
                                GhostFearMoveLUD("ghostPink");
                            }
                            break;
                        case 3:
                            if (Settings.GhostPinkDirection != Directions.Up)
                            {
                                Settings.GhostPinkDirection = Directions.Down;
                            }
                            else
                            {
                                GhostFearMoveLUD("ghostPink");
                            }
                            break;
                    }
                    pinkMoveLUD = false;
                    break;

                case "ghostOrange":
                    switch (i)
                    {
                        case 1:
                            if (Settings.GhostOrangeDirection != Directions.Down)
                            {
                                Settings.GhostOrangeDirection = Directions.Up;
                            }
                            else
                            {
                                GhostFearMoveLUD("ghostOrange");
                            }
                            break;
                        case 2:
                            if (Settings.GhostOrangeDirection != Directions.Right)
                            {
                                Settings.GhostOrangeDirection = Directions.Left;
                            }
                            else
                            {
                                GhostFearMoveLUD("ghostOrange");
                            }
                            break;
                        case 3:
                            if (Settings.GhostOrangeDirection != Directions.Up)
                            {
                                Settings.GhostOrangeDirection = Directions.Down;
                            }
                            else
                            {
                                GhostFearMoveLUD("ghostOrange");
                            }
                            break;
                    }
                    orangeMoveLUD = false;
                    break;

                case "ghostBlue":
                    switch (i)
                    {
                        case 1:
                            if (Settings.GhostBlueDirection != Directions.Down)
                            {
                                Settings.GhostBlueDirection = Directions.Up;
                            }
                            else
                            {
                                GhostFearMoveLUD("ghostBlue");
                            }
                            break;
                        case 2:
                            if (Settings.GhostBlueDirection != Directions.Right)
                            {
                                Settings.GhostBlueDirection = Directions.Left;
                            }
                            else
                            {
                                GhostFearMoveLUD("ghostBlue");
                            }
                            break;
                        case 3:
                            if (Settings.GhostBlueDirection != Directions.Up)
                            {
                                Settings.GhostBlueDirection = Directions.Down;
                            }
                            else
                            {
                                GhostFearMoveLUD("ghostBlue");
                            }
                            break;
                    }
                    blueMoveLUD = false;
                    break;
            }
        }
        public void GhostFearMoveLRUD(string ghost)
        {
            int i = rnd.Next(1, 5);

            switch (ghost)
            {
                case "ghostRed":

                    switch (i)
                    {
                        case 1:
                            if (Settings.GhostRedDirection != Directions.Right)
                            {
                                Settings.GhostRedDirection = Directions.Left;
                            }
                            else
                            {
                                GhostFearMoveLRUD("ghostRed");
                            }
                            break;
                        case 2:
                            if (Settings.GhostRedDirection != Directions.Down)
                            {
                                Settings.GhostRedDirection = Directions.Up;
                            }
                            else
                            {
                                GhostFearMoveLRUD("ghostRed");
                            }
                            break;
                        case 3:
                            if (Settings.GhostRedDirection != Directions.Up)
                            {
                                Settings.GhostRedDirection = Directions.Down;
                            }
                            else
                            {
                                GhostFearMoveLRUD("ghostRed");
                            }
                            break;
                        case 4:
                            if (Settings.GhostRedDirection != Directions.Left)
                            {
                                Settings.GhostRedDirection = Directions.Right;
                            }
                            else
                            {
                                GhostFearMoveLRUD("ghostRed");
                            }
                            break;
                    }
                    redMoveLRUD = false;
                    break;

                case "ghostPink":
                    switch (i)
                    {
                        case 1:
                            if (Settings.GhostPinkDirection != Directions.Right)
                            {
                                Settings.GhostPinkDirection = Directions.Left;
                            }
                            else
                            {
                                GhostFearMoveLRUD("ghostPink");
                            }
                            break;
                        case 2:
                            if (Settings.GhostPinkDirection != Directions.Down)
                            {
                                Settings.GhostPinkDirection = Directions.Up;
                            }
                            else
                            {
                                GhostFearMoveLRUD("ghostPink");
                            }
                            break;
                        case 3:
                            if (Settings.GhostPinkDirection != Directions.Up)
                            {
                                Settings.GhostPinkDirection = Directions.Down;
                            }
                            else
                            {
                                GhostFearMoveLRUD("ghostPink");
                            }
                            break;
                        case 4:
                            if (Settings.GhostPinkDirection != Directions.Left)
                            {
                                Settings.GhostPinkDirection = Directions.Right;
                            }
                            else
                            {
                                GhostFearMoveLRUD("ghostPink");
                            }
                            break;
                    }
                    pinkMoveLRUD = false;
                    break;

                case "ghostOrange":
                    switch (i)
                    {
                        case 1:
                            if (Settings.GhostOrangeDirection != Directions.Right)
                            {
                                Settings.GhostOrangeDirection = Directions.Left;
                            }
                            else
                            {
                                GhostFearMoveLRUD("ghostOrange");
                            }
                            break;
                        case 2:
                            if (Settings.GhostOrangeDirection != Directions.Down)
                            {
                                Settings.GhostOrangeDirection = Directions.Up;
                            }
                            else
                            {
                                GhostFearMoveLRUD("ghostOrange");
                            }
                            break;
                        case 3:
                            if (Settings.GhostOrangeDirection != Directions.Up)
                            {
                                Settings.GhostOrangeDirection = Directions.Down;
                            }
                            else
                            {
                                GhostFearMoveLRUD("ghostOrange");
                            }
                            break;
                        case 4:
                            if (Settings.GhostOrangeDirection != Directions.Left)
                            {
                                Settings.GhostOrangeDirection = Directions.Right;
                            }
                            else
                            {
                                GhostFearMoveLRUD("ghostOrange");
                            }
                            break;
                    }
                    orangeMoveLRUD = false;
                    break;

                case "ghostBlue":
                    switch (i)
                    {
                        case 1:
                            if (Settings.GhostBlueDirection != Directions.Right)
                            {
                                Settings.GhostBlueDirection = Directions.Left;
                            }
                            else
                            {
                                GhostFearMoveLRUD("ghostBlue");
                            }
                            break;
                        case 2:
                            if (Settings.GhostBlueDirection != Directions.Down)
                            {
                                Settings.GhostBlueDirection = Directions.Up;
                            }
                            else
                            {
                                GhostFearMoveLRUD("ghostBlue");
                            }
                            break;
                        case 3:
                            if (Settings.GhostBlueDirection != Directions.Up)
                            {
                                Settings.GhostBlueDirection = Directions.Down;
                            }
                            else
                            {
                                GhostFearMoveLRUD("ghostBlue");
                            }
                            break;
                        case 4:
                            if (Settings.GhostBlueDirection != Directions.Left)
                            {
                                Settings.GhostBlueDirection = Directions.Right;
                            }
                            else
                            {
                                GhostFearMoveLRUD("ghostBlue");
                            }
                            break;
                    }
                    blueMoveLRUD = false;
                    break;
            }
        }

        #endregion



    }
}

    
