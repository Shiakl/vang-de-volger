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
                /*
                if (myTile.myNeighbours[(int)direction].MyUnit is Box)
                {
                    myTile.myNeighbours[(int)direction].Possible_moves();
                    if (Check_Box_Row(heroTile, hero_Direction) == true)
                    {
                        _chosen_Direction = heroTile.all_Directions[hero_Direction];
                        for (int b = _boxes_to_push.Count() - 1; b >= 0; b--)
                        {
                            Move_Unit(_boxes_to_push[b], _chosen_Direction, _tiles_to_swap[b]);
                        }

                        Move_Unit(_player, _chosen_Direction, heroTile);
                    }
                }
                */
                if (myTile.moveArray[(int)direction] == true)
                {
                    //executemovement
                    Swap_MyUnit(myTile, myTile.myNeighbours[(int)direction]);

                    //Redraw tile
                    myTile.Redraw();
                    myTile.myNeighbours[(int)direction].Redraw();
                }
            }
        }
    }
}
