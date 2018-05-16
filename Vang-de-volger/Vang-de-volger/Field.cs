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
        public Tile heroTile;
        public Tile villainTile;

        public Hero _player;
        public Villain _enemy;
        public Box[] _box;

        private Unit.UNITTYPE[] _unityTypeArray = new Unit.UNITTYPE[NUM_OF_TILES];
        public Field()
        {
            _playfield = new Tile[NUM_OF_TILES];
        }

        //Assign Type values to tiles in a Tile class array depending on playfield size
        private const double _boxRatio = 0.2; //Determine the ratio of boxes:tiles
        private int _boxAmount = Convert.ToInt32(Math.Floor(NUM_OF_TILES * _boxRatio));
        private void _Assign_Unit_Types()
        {
            //Put MYTYPE values in an array
            int i = 0;
            double wallRatio = 0.05; //Determines the ratio of blocks:tiles
            double tileRatio = 1 - wallRatio;

            while (i < NUM_OF_TILES)
            {
                if (i <= (NUM_OF_TILES * wallRatio) && i > 0)
                {
                    _unityTypeArray[i] = Unit.UNITTYPE.BLOCK;
                    i++;
                }
                else if (i <= (NUM_OF_TILES * wallRatio + _boxAmount) && i > (NUM_OF_TILES * wallRatio))
                {
                    _unityTypeArray[i] = Unit.UNITTYPE.BOX;
                    i++;
                }
                else
                {
                    _unityTypeArray[i] = Unit.UNITTYPE.TILE;
                    i++;
                }
            }

            //Shuffle the tileArray
            Random rndShuffle = new Random();
            Unit.UNITTYPE tempType;

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
            _Assign_Unit_Types();

            int tilecounter = 0;

            //Create all the Tiles and Units
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

                    if (_unityTypeArray[tilecounter] == Unit.UNITTYPE.BOX)
                    {
                        Box newBox = new Box(Unit.UNITTYPE.BOX);
                        _playfield[tilecounter].MyUnit = newBox;
                    }
                    else if (_unityTypeArray[tilecounter] == Unit.UNITTYPE.BLOCK)
                    {
                        Unit Block = new Unit(Unit.UNITTYPE.BLOCK);
                        _playfield[tilecounter].MyUnit = Block;
                    }
                    else if (_unityTypeArray[tilecounter] == Unit.UNITTYPE.TILE)
                    {
                        Unit Tile = new Unit(Unit.UNITTYPE.TILE);
                        _playfield[tilecounter].MyUnit = Tile;
                    }


                    PlayForm.Controls.Add(_playfield[tilecounter].MyPanel);
                    _playfield[tilecounter].Redraw();
                    tilecounter++;
                    
                }
            }
      
            _player = new Hero(Unit.UNITTYPE.HERO);
            _playfield[0].MyUnit = _player;
            _playfield[0].Redraw();

            _enemy = new Villain(Unit.UNITTYPE.VILLAIN);
            _playfield[NUM_OF_TILES - 1].MyUnit = _enemy;
            _playfield[NUM_OF_TILES - 1].Redraw();

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


    }//Field

}
