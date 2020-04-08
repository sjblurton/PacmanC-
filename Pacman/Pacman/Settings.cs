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

        public static Directions playerDirection { get; set; }
        public static Directions GhostRedDirection { get; set; }
        public static Directions GhostPinkDirection { get; set; }
        public static Directions GhostOrangeDirection { get; set; }
        public static Directions GhostBlueDirection { get; set; }

        public Settings()
        {
            //default settings
        }

    }



}

