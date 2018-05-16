using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Vang_de_volger
{
    class Tile
    {
        public Unit MyUnit;
        public Panel MyPanel = new Panel();
        private PictureBox panelPb;

        public Tile( Panel gridPanel)
        {
            MyPanel = gridPanel;
            MyPanel.BackgroundImage = Properties.Resources.Tile;

            panelPb = new PictureBox();
            panelPb.BackColor = Color.Transparent;
            MyPanel.Controls.Add(panelPb);
        }

        public void Redraw()
        {
            panelPb.Image = MyUnit.myImage;
        }


        public Tile neighbourLeft;
        public Tile neighbourRight;
        public Tile neighbourTop;
        public Tile neighbourBottom;
        public Tile[] myNeighbours = new Tile[4];
        public void AddNeighbours()
        {
            myNeighbours[0] = neighbourLeft;
            myNeighbours[1] = neighbourRight;
            myNeighbours[2] = neighbourTop;
            myNeighbours[3] = neighbourBottom;
        }

        public enum NEIGHBOURS
        {
            LEFT,
            RIGHT,
            TOP,
            BOTTOM
        }
    }

}
