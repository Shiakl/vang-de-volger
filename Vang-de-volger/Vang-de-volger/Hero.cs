using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vang_de_volger
{
    class Hero : FieldComponent
    {
        public Hero()
        {
            myImage = Image.FromFile(@"..\..\Resources\Hero.png");
        }


        public void move(Tile myTile,Tile.DIRECTIONS direction)
        {
            myTile.Possible_moves();

            if (myTile.myNeighbours[(int)direction] != null)
            {
                //Box Push Start here
                if (myTile.myNeighbours[(int)direction].MyUnit is Box)
                {
                    myTile.myNeighbours[(int)direction].Possible_moves();
                    if (Check_Box_Row(myTile, (int)direction) == true)
                    {
                        for (int b = _tiles_to_swap.Count() - 1; b >= 0; b--)
                        {
                            Swap_MyUnit(_tiles_to_swap[b], _tiles_to_swap[b].myNeighbours[(int)direction]);
                        }
                        Swap_MyUnit(myTile, myTile.myNeighbours[(int)direction]);
                    }
                }
                //Box push ends here
                else if (myTile.moveArray[(int)direction] == true)
                {
                    //executemovement
                    Swap_MyUnit(myTile, myTile.myNeighbours[(int)direction]);
                }
            }
            _tiles_to_swap.Clear();
        }

        private List<Tile> _tiles_to_swap = new List<Tile>(); /// tiles_to_swap is used to swap the unit on the tile in the direction with the current tile
        public bool Check_Box_Row(Tile heroTile, int direction)
        {
            if (heroTile.myNeighbours[direction] != null)
            {
                if (heroTile.myNeighbours[direction].MyUnit is Box)
                {
                    _tiles_to_swap.Add(heroTile.myNeighbours[direction]);
                    return Check_Box_Row(heroTile.myNeighbours[direction], direction);
                }
                else if (heroTile.myNeighbours[direction].MyUnit is Ground)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else return false;
        }
    }
}
