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


        private UNITTYPE[] _unityTypeArray = new UNITTYPE[NUM_OF_TILES];
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

        private enum UNITTYPE
        {
            BLOCK,
            TILE,
            BOX,
            HERO,
            VILLAIN
        }

        //Assign Type values to tiles in a Tile class array depending on playfield size
        private const double _boxRatio = 0.2; //Determine the ratio of boxes:tiles
        private int _boxAmount = Convert.ToInt32(Math.Floor(NUM_OF_TILES * _boxRatio));
        private void _Create_UnitTypeArray()
        {
            //Put MYTYPE values in an array
            int i = 0;
            double wallRatio = 0.05; //Determines the ratio of blocks:tiles
            double tileRatio = 1 - wallRatio;

            while (i < NUM_OF_TILES)
            {
                if (i <= (NUM_OF_TILES * wallRatio) && i > 0)
                {
                    _unityTypeArray[i] = UNITTYPE.BLOCK;
                    i++;
                }
                else if (i <= (NUM_OF_TILES * wallRatio + _boxAmount) && i > (NUM_OF_TILES * wallRatio))
                {
                    _unityTypeArray[i] = UNITTYPE.BOX;
                    i++;
                }
                else
                {
                    _unityTypeArray[i] = UNITTYPE.TILE;
                    i++;
                }
            }

            //Shuffle the tileArray
            Random rndShuffle = new Random();
            UNITTYPE tempType;

            //shuffle 100 times
            for (int shuffle = 0; shuffle < 100; shuffle++)
            {
                for (int j = 1; j < NUM_OF_TILES - 1; j++)
                {
                    //swap 2 types
                    int randomTypeNR = rndShuffle.Next(1, NUM_OF_TILES - 2);
                    tempType = _unityTypeArray[j];
                    _unityTypeArray[j] = _unityTypeArray[randomTypeNR];
                    _unityTypeArray[randomTypeNR] = tempType;
                }
            }
        }

        public void CreateField(Form PlayForm)
        {
            _Create_UnitTypeArray();

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

                    if (_unityTypeArray[tilecounter] == UNITTYPE.BOX)
                    {
                        Box newBox = new Box();
                        _playfield[tilecounter].MyUnit = newBox;
                    }
                    else if (_unityTypeArray[tilecounter] == UNITTYPE.BLOCK)
                    {
                        Block Block = new Block();
                        _playfield[tilecounter].MyUnit = Block;
                    }
                    else if (_unityTypeArray[tilecounter] == UNITTYPE.TILE)
                    {
                        Ground EmptyTile = new Ground();
                        _playfield[tilecounter].MyUnit = EmptyTile;
                    }
                    PlayForm.Controls.Add(_playfield[tilecounter].MyPanel);
                    _playfield[tilecounter].Redraw();
                    tilecounter++;                 
                }
            }
      
            player = new Hero(_playfield[(int)SpawnTile.FirstTile]);
            _playfield[(int)SpawnTile.FirstTile].MyUnit = player;
            _playfield[(int)SpawnTile.FirstTile].Redraw();

            enemy = new Villain(_playfield[(int)SpawnTile.LastTile]);
            _playfield[(int)SpawnTile.LastTile].MyUnit = enemy;
            _playfield[(int)SpawnTile.LastTile].Redraw();

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
        }//CreateField

        public void Reload_Units()
        {
            _Create_UnitTypeArray();
            int tilecounter = 0;
            for (int tc = 0; tc < NUM_OF_TILES; tc++)
            {
                if (_unityTypeArray[tilecounter] == UNITTYPE.BOX)
                {
                    Box newBox = new Box();
                    _playfield[tilecounter].MyUnit = newBox;
                }
                else if (_unityTypeArray[tilecounter] == UNITTYPE.BLOCK)
                {
                    Block Block = new Block();
                    _playfield[tilecounter].MyUnit = Block;
                }
                else if (_unityTypeArray[tilecounter] == UNITTYPE.TILE)
                {
                    Ground EmptyTile = new Ground();
                    _playfield[tilecounter].MyUnit = EmptyTile;
                }
                _playfield[tilecounter].Redraw();
                tilecounter++;
            }

            player = new Hero(_playfield[(int)SpawnTile.FirstTile]);
            _playfield[(int)SpawnTile.FirstTile].MyUnit = player;
            _playfield[(int)SpawnTile.FirstTile].Redraw();

            enemy = new Villain(_playfield[(int)SpawnTile.LastTile]);
            _playfield[(int)SpawnTile.LastTile].MyUnit = enemy;
            _playfield[(int)SpawnTile.LastTile].Redraw();

        }//Reload Units

    }//Field

}
