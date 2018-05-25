using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace Vang_de_volger
{
    class Field
    {
        const int NUM_OF_TILES = MainForm.x_gridSize * MainForm.y_gridSize; //Number of tiles on the field
        private Tile[] _playfield; //Tile class array

        public Hero player;
        public Villain enemy;

        private FieldComponent[] _fieldUnits = new FieldComponent[NUM_OF_TILES];

        public Field()
        {
            _playfield = new Tile[NUM_OF_TILES];            
        }

        private enum SpawnTile
        {
            FirstTile = 0,
            LastTile = NUM_OF_TILES-1
        }

        private void Shuffle_Tiles()
        {
            //Shuffle the tileArray
            Random rndShuffle = new Random();
            Tile tempTile;

            //shuffle 100 times
            for (int shuffle = 0; shuffle < 100; shuffle++)
            {
                for (int j = 1; j < NUM_OF_TILES - 1; j++)
                {
                    //swap 2 types
                    int randomTypeNR = rndShuffle.Next(1, NUM_OF_TILES - 2);
                    tempTile = _playfield[j];
                    _playfield[j] = _playfield[randomTypeNR];
                    _playfield[randomTypeNR] = tempTile;
                }
            }
        }

        public void CreateField(Form PlayForm)
        {
            int tilecounter = 0;

            //Create all the Tiles and put Units on the tiles
            for (int y = 0; y < MainForm.y_gridSize; y++)
            {
                for (int x = 0; x < MainForm.x_gridSize; x++)
                {
                    Panel tempPanel = new Panel
                    {
                        Size = new Size(MainForm.tileSize, MainForm.tileSize),
                        Location = new Point(x * MainForm.tileSize, y * MainForm.tileSize)
                    };

                    _playfield[tilecounter] = new Tile(tempPanel);
                    PlayForm.Controls.Add(_playfield[tilecounter].MyPanel);
                    tilecounter++;                 
                }
            }

            //Add tile neighbours
            for (int tc = 0; tc < NUM_OF_TILES; tc++)
            {
                //Add neighbours to Array in Tile Class
                if (tc > MainForm.x_gridSize - 1)
                {
                    _playfield[tc].neighbourTop = _playfield[tc - MainForm.x_gridSize];
                }
                if (tc < NUM_OF_TILES - MainForm.x_gridSize)
                {
                    _playfield[tc].neighbourBottom = _playfield[tc + MainForm.x_gridSize];
                }
                if (tc % MainForm.x_gridSize < MainForm.x_gridSize - 1)
                {
                    _playfield[tc].neighbourRight = _playfield[tc + 1];
                }
                if (tc % MainForm.x_gridSize > 0)
                {
                    _playfield[tc].neighbourLeft = _playfield[tc - 1];
                }
                _playfield[tc].AddNeighbours();
            }
            Reload();
        }//CreateField


        //Assign Type values to tiles in a Tile class array depending on playfield size
        private const double _boxRatio = 0.2; //Determine the ratio of boxes:tiles
        private int _boxAmount = Convert.ToInt32(Math.Floor(NUM_OF_TILES * _boxRatio));
        public void Reload()
        {
            Shuffle_Tiles();

            //Assign Fieldcomponents to their Tiles
            int i = 0;
            double wallRatio = 0.05; //Determines the ratio of blocks:tiles
            double tileRatio = 1 - wallRatio;

            while (i < NUM_OF_TILES)
            {
                if (i <= (NUM_OF_TILES * wallRatio) && i > 0)
                {
                    Block Block = new Block();
                    _playfield[i].MyUnit = Block;
                    _playfield[i].Redraw();
                    i++;
                }
                else if (i <= (NUM_OF_TILES * wallRatio + _boxAmount) && i > (NUM_OF_TILES * wallRatio))
                {
                    Box newBox = new Box();
                    _playfield[i].MyUnit = newBox;
                    _playfield[i].Redraw();
                    i++;
                }
                else
                {
                    Ground EmptyTile = new Ground();
                    _playfield[i].MyUnit = EmptyTile;
                    _playfield[i].Redraw();
                    i++;
                }
            }

            player = new Hero(_playfield[(int)SpawnTile.FirstTile]);
            _playfield[(int)SpawnTile.FirstTile].MyUnit = player;
            _playfield[(int)SpawnTile.FirstTile].Redraw();

            enemy = new Villain(_playfield[(int)SpawnTile.LastTile]);
            _playfield[(int)SpawnTile.LastTile].MyUnit = enemy;
            _playfield[(int)SpawnTile.LastTile].Redraw();
        }//Reload
    }//Field

}
