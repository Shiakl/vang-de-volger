using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Vang_de_volger
{
    class Villain : Hero
    {
        public Villain(Tile spawnTile) :base(spawnTile)
        {
            myTile = spawnTile;
            allow_move = false;
            pushable = false;
            myImage = Image.FromFile(@"..\..\Resources\Villain.png");
        }

        //VILLAIN FUNCTION
        //Count the not-possible moves for the villain, if the move_count is 4 the villain has no possible moves and loses
        private int _move_count;
        public bool villain_Lose(Tile myTile)
        {
            //myTile.Possible_moves_villain();
            _move_count = 0;
            for (int vd = 0; vd < 4; vd++)
            {
                if(myTile.myNeighbours[vd] != null)
                {
                    if (myTile.myNeighbours[vd].MyUnit.pushable == true || myTile.myNeighbours[vd].MyUnit.allow_move == false)
                    {
                        _move_count++;
                    }
                }
                else
                {
                    _move_count++;
                }
            }
            if (_move_count == 4)
            {
                return true;
            }
            return false;
        }

        //VILLAIN FUNCTION
        /// <summary>
        /// Function added to enable Villain to catch the Hero
        /// </summary>
        /// <param name="myTile"> The tile the villain is on.</param>
        /// <returns></returns>
        public bool Catch_Hero(Tile myTile)
        {
            for (int scan = 0; scan < 4; scan++)
            {
                if (myTile.myNeighbours[scan] != null)
                {
                    if (myTile.myNeighbours[scan].MyUnit is Hero)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override void move(Tile thisTile, Tile.DIRECTIONS direction)
        {
            Swap_MyUnit(thisTile, thisTile.myNeighbours[(int)direction]);
            myTile = thisTile.myNeighbours[(int)direction];
        }

        private Tile.DIRECTIONS[] _possible_Directions = new Tile.DIRECTIONS[4];
        public Tile.DIRECTIONS Random_Direction()
        {
            Tile.DIRECTIONS _chosen_Random_Direction;

            int move_Numbers = 0;
            int arraycount = 0;

            for (int a = 0; a < myTile.myNeighbours.Length; a++)
            {
                if (myTile.myNeighbours[a] != null)
                {
                    if (myTile.myNeighbours[a].MyUnit.allow_move == true && myTile.myNeighbours[a].MyUnit.pushable == false)
                    {
                        _possible_Directions[arraycount] = (Tile.DIRECTIONS)a;
                        arraycount++;
                    }
                }
            }
            Random rndDirection = new Random();
            int villain_Direction = rndDirection.Next(0, arraycount);
            _chosen_Random_Direction = _possible_Directions[villain_Direction];
            return _chosen_Random_Direction;
        }
    }
}
