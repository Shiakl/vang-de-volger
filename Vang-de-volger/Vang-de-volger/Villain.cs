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

        /// <summary>
        /// Count the not-possible moves for the villain, if the blocked_move_count is equal to the amount of neighbours the villain has the villain has no more possible moves and it returns true.
        /// </summary>
        /// <param name="myTile">The tile the villain class object is located on.</param>
        /// <returns>bool</returns>
        public bool villain_Lose(Tile myTile)
        {
        int blocked_move_count;
            blocked_move_count = 0;
            for (int vd = 0; vd < myTile.myNeighbours.Length; vd++)
            {
                if(myTile.myNeighbours[vd] != null)
                {
                    if (myTile.myNeighbours[vd].MyUnit.pushable == true || myTile.myNeighbours[vd].MyUnit.allow_move == false)
                    {
                        blocked_move_count++;
                    }
                }
                else
                {
                    blocked_move_count++;
                }
            }
            if (blocked_move_count == myTile.myNeighbours.Length)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Function added to enable the Villain to catch the Hero
        /// </summary>
        /// <param name="myTile"> The tile the villain is on.</param>
        /// <returns>bool</returns>
        public bool Catch_Hero(Tile myTile)
        {
            for (int scan = 0; scan < myTile.myNeighbours.Length; scan++)
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

        /// <summary>
        /// Move handler of the villain.
        /// </summary>
        /// <param name="thisTile">The tile the villain is on</param>
        /// <param name="direction"></param>
        public override void move(Tile.DIRECTIONS direction)
        {
            Swap_MyUnit(myTile, myTile.myNeighbours[(int)direction]);
            myTile = myTile.myNeighbours[(int)direction];
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
