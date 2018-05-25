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
            myNeighbours[(int)DIRECTIONS.LEFT] = neighbourLeft;
            myNeighbours[(int)DIRECTIONS.RIGHT] = neighbourRight;
            myNeighbours[(int)DIRECTIONS.TOP] = neighbourTop;
            myNeighbours[(int)DIRECTIONS.BOTTOM] = neighbourBottom;
        }

        public enum DIRECTIONS
        {
            LEFT,
            RIGHT,
            TOP,
            BOTTOM
        }
    }

}



/* OLD MOVEMENT CHECKER
         public bool[] moveArray = new bool[4]; //Array containing bool's that are used to determine whether a direction is moveable for boxes and the hero

        public void Possible_moves()
        {
            for (int i = 0; i < myNeighbours.Length; i++)
            {
                if (myNeighbours[i] != null)
                {
                    if (MyUnit is Box)
                    {
                        if (myNeighbours[i].MyUnit is Ground)
                        {
                            moveArray[i] = true;
                        }
                        else
                        {
                            moveArray[i] = false;
                        }
                    }
                    else
                    {
                        if (myNeighbours[i].MyUnit is Block || myNeighbours[i].MyUnit is Villain)
                        {
                            moveArray[i] = false;
                        }
                        else
                        {
                            moveArray[i] = true;
                        }
                    }
                }
            }
        }

        public bool[] moveArrayVillain = new bool[4];  //Array containing bool's that are used to determine whether a direction is moveable for the villain

        public void Possible_moves_villain()
        {
            for (int i = 0; i < 4; i++)
            {
                if (myNeighbours[i] != null)
                {
                    if (myNeighbours[i].MyUnit is Block || myNeighbours[i].MyUnit is Box)
                    {
                        moveArrayVillain[i] = false;
                    }
                    else
                    {
                        moveArrayVillain[i] = true;
                    }
                }
            }
        }

 
 */
