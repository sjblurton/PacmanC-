﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    class Circles
    {
        PictureBox coin = new PictureBox();
        public int coinLeft;
        public int coinTop;

        public void mkCoin(Form form)
        {
            coin.BackColor = Color.White;
            coin.Size = new Size (3, 3);
            coin.Tag = "coin";
            coin.Left = coinLeft;
            coin.Top = coinTop;
            coin.BringToFront();
            form.Controls.Add(coin);

        }
        public void mkBig(Form form)
        {
            coin.BackColor = Color.Transparent;
            coin.Image = Properties.Resources.ball;
            coin.Size = new Size(10, 10);
            coin.Tag = "big";
            coin.Left = coinLeft;
            coin.Top = coinTop;
            coin.BringToFront();
            form.Controls.Add(coin);

        }

    }
}
