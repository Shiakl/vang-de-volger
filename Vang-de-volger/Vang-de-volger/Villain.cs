using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Vang_de_volger
{
    class Villain : FieldComponent
    {
        public Tile myTile;

        public Villain(Tile spawnTile)
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

        //VILLAIN FUNCTION
        /// <summary>
        ///     Method for randomly moving the Villain.   
        /// </summary>
        private Tile.DIRECTIONS _chosen_Random_Direction; //For the Villain
        private Tile.DIRECTIONS[] _possible_Directions = new Tile.DIRECTIONS[4];
        public void Villain_random_move(Tile villainTile)
        {
            //villainTile.Possible_moves_villain();
            int move_Numbers = 0;
            int arraycount = 0;

                for (int a = 0; a < villainTile.myNeighbours.Length; a++)
                {
                    if(villainTile.myNeighbours[a] != null)
                    {
                        if (villainTile.myNeighbours[a].MyUnit.allow_move == true && villainTile.myNeighbours[a].MyUnit.pushable == false)
                        {
                            _possible_Directions[arraycount] = (Tile.DIRECTIONS)a;
                            arraycount++;
                        }
                    }
                }

                Random rndDirection = new Random();
                int villain_Direction = rndDirection.Next(0, arraycount);
                _chosen_Random_Direction = _possible_Directions[villain_Direction];
                Swap_MyUnit(villainTile, villainTile.myNeighbours[(int)_chosen_Random_Direction]);
                myTile = villainTile.myNeighbours[(int)_chosen_Random_Direction];
            
        }
    }
}
