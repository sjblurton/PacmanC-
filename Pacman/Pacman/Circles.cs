using System;
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
            coin.BackColor = Color.Yellow;
            coin.Size = new Size(2, 2);
            coin.Tag = "coin";
            coin.Left = coinLeft;
            coin.Top = coinTop;
            coin.BringToFront();
            form.Controls.Add(coin);

        }
        public void mkBig(Form form)
        {
            coin.BackColor = Color.Yellow;
            coin.Size = new Size(5, 5);
            coin.Tag = "big";
            coin.Left = coinLeft;
            coin.Top = coinTop;
            coin.BringToFront();
            form.Controls.Add(coin);

        }

    }
}
