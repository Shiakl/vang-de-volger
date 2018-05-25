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
        public FieldComponent MyUnit;
        public Panel MyPanel = new Panel();
        private PictureBox panelPb;

        public Tile(Panel gridPanel)
        {
            MyPanel = gridPanel;
            MyPanel.BackgroundImage = Properties.Resources.Tile;
            panelPb = new PictureBox();
            panelPb.BackColor = Color.Transparent;
            MyPanel.Controls.Add(panelPb);
        }

        /// <summary>
        /// Redraw all the pictureboxes on the Tile panel with the image of the unit it contains.
        /// </summary>
        public void Redraw()
        {
            panelPb.Image = MyUnit.myImage;
        }

        /// <summary>
        /// Properties that hold the tiles neighbouring this Tile object.
        /// </summary>
        public Tile neighbourLeft;
        public Tile neighbourRight;
        public Tile neighbourTop;
        public Tile neighbourBottom;
        public Tile[] myNeighbours = new Tile[4];
        public void AddNeighbours()
        {
            myNeighbours[(int)DIRECTIONS.LEFT] = neighbourLeft;
            myNeighbours[(int)DIRECTIONS.RIGHT] = neighbourRight;
            myNeighbours[(int)DIRECTIONS.TOP] = neighbourTop;
            myNeighbours[(int)DIRECTIONS.BOTTOM] = neighbourBottom;
        }

        /// <summary>
        /// Enum used to specify a direction for movement or neighbour position.
        /// </summary>
        public enum DIRECTIONS
        {
            LEFT,
            RIGHT,
            TOP,
            BOTTOM
        }
    }
}


