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

        private const double _boxRatio = 0.2; //Determine the ratio of boxes:tiles
        const double blockRatio = 0.05; //Determines the ratio of blocks:tiles
        const double tileRatio = 1 - blockRatio; //The amount of empty tiles on the playfield.
        private int _boxAmount = Convert.ToInt32(Math.Floor(NUM_OF_TILES * _boxRatio)); //The amount of boxes that are to be created on the playfield.

        public Field()
        {
            _playfield = new Tile[NUM_OF_TILES];            
        }

        /// <summary>
        /// SpawnTile Enum is used to specify the tile on which the Hero en Villain spawn.
        /// It is used as index for the _playfield Tile array.
        /// </summary>
        private enum SpawnTile
        {
            FirstTile = 0,
            LastTile = NUM_OF_TILES-1
        }

        /// <summary>
        /// Call upon this method to randomize the tiles in the Tile array.
        /// </summary>
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

        /// <summary>
        /// This method creates an amount of Tile class objects equal to the grid size specified on the form the Field object is created on.
        /// it also assigns each tile it's neighbouring tiles.
        /// </summary>
        /// <param name="PlayForm"> The form the Field class object is created on.</param>
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


        /// <summary>
        /// Creates Field Component objects and puts them on a Tile. The MyTile attribute in the Tile class is used for this.
        /// </summary>
        public void Reload()
        {
            Shuffle_Tiles(); //_playfield[] Tile array is shuffled to create a randomized field.

            //Assign Fieldcomponents to their Tiles
            int i = 0;
            while (i < NUM_OF_TILES)
            {
                if (i <= (NUM_OF_TILES * blockRatio) && i > 0)
                {
                    Block Block = new Block();
                    _playfield[i].MyUnit = Block;
                    _playfield[i].Redraw();
                    i++;
                }
                else if (i <= (NUM_OF_TILES * blockRatio + _boxAmount) && i > (NUM_OF_TILES * blockRatio))
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

            //The hero spawns on the first tile on the playfield by default.
            player = new Hero(_playfield[(int)SpawnTile.FirstTile]);
            _playfield[(int)SpawnTile.FirstTile].MyUnit = player;
            _playfield[(int)SpawnTile.FirstTile].Redraw();

            //The villain spawn on the last tile on the playfield by default.
            enemy = new Villain(_playfield[(int)SpawnTile.LastTile]);
            _playfield[(int)SpawnTile.LastTile].MyUnit = enemy;
            _playfield[(int)SpawnTile.LastTile].Redraw();
        }//Reload
    }//Field

}
