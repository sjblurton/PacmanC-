using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public enum Directions//enum directions
    {
        Left,
        Right,
        Up,
        Down,
        Stop
    };

    class Settings
    {
        public static int GhostSpeed { get; set; }

        public static int Score { get; set; }
        public static int SmallPoints { get; set; }
        public static int KillPoints { get; set; }
        public static bool GameOver { get; set; }
        public static Directions playerDirection { get; set; }
        public static Directions ghost1Direction { get; set; }
        public static Directions ghost2Direction { get; set; }
        public static Directions ghost3Direction { get; set; }
        public static Directions ghost4Direction { get; set; }

        public Settings()
        {
            //default settings
            GhostSpeed = 5;
            Score = 0;
            SmallPoints = 10;
            KillPoints = 100;
            GameOver = false;
            playerDirection = Directions.Left;
            ghost1Direction = Directions.Stop;
            ghost2Direction = Directions.Stop;
            ghost3Direction = Directions.Stop;
            ghost4Direction = Directions.Stop;

        }

    }



}

