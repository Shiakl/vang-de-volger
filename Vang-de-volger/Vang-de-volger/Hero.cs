﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vang_de_volger
{
    class Hero : FieldComponent
    {
        public Tile myTile;
        private Tile.DIRECTIONS _facing;
        private Image[] _heroSprites = new Image[4];
        private List<Tile> _tiles_to_swap = new List<Tile>(); /// tiles_to_swap is used to swap the unit on the tile in the direction with the current tile


        public Hero(Tile spawnTile)
        {
            myTile = spawnTile;

            allow_move = false;
            pushable = false;

            myImage = Image.FromFile(@"..\..\Resources\Hero.png");
            _facing = Tile.DIRECTIONS.BOTTOM;

            _heroSprites[0] = Image.FromFile(@"..\..\Resources\HeroSprites\HeroLeft.png");
            _heroSprites[1] = Image.FromFile(@"..\..\Resources\HeroSprites\HeroRight.png");
            _heroSprites[2] = Image.FromFile(@"..\..\Resources\HeroSprites\HeroUp.png");
            _heroSprites[3] = Image.FromFile(@"..\..\Resources\HeroSprites\Hero.png");
        }

        public void SetFacing(Tile.DIRECTIONS LastFace)
        {
            _facing = LastFace;
            myImage = _heroSprites[(int)LastFace];
        }

        public virtual void move(Tile.DIRECTIONS direction)
        {
            SetFacing(direction);
            myTile.Redraw();

            if (myTile.myNeighbours[(int)direction] != null)
            {
                //Box Push Start here
                if (myTile.myNeighbours[(int)direction].MyUnit.pushable == true)
                {
                    //myTile.myNeighbours[(int)direction].Possible_moves();
                    if (Check_Box_Row(myTile, (int)direction) == true)
                    {
                        for (int b = _tiles_to_swap.Count() - 1; b >= 0; b--)
                        {
                            Swap_MyUnit(_tiles_to_swap[b], _tiles_to_swap[b].myNeighbours[(int)direction]);
                        }
                        Swap_MyUnit(myTile, myTile.myNeighbours[(int)direction]);
                        this.myTile = myTile.myNeighbours[(int)direction];
                    }
                }
                //Box push ends here
                else if (myTile.myNeighbours[(int)direction].MyUnit.allow_move == true)
                {
                    //executemovement
                    Swap_MyUnit(myTile, myTile.myNeighbours[(int)direction]);
                    this.myTile = myTile.myNeighbours[(int)direction];
                }
            }
            _tiles_to_swap.Clear();
        }

        /// <summary>
        /// Check if the Unit on the tile next to the hero is pushable. 
        /// </summary>
        /// <param name="heroTile">the Tile the hero is on</param>
        /// <param name="direction">The direction the hero wants to move to.</param>
        /// <returns>bool</returns>
        public bool Check_Box_Row(Tile heroTile, int direction)
        {
            if (heroTile.myNeighbours[direction] != null)
            {
                if (heroTile.myNeighbours[direction].MyUnit.pushable == true)
                {
                    _tiles_to_swap.Add(heroTile.myNeighbours[direction]);
                    return Check_Box_Row(heroTile.myNeighbours[direction], direction);
                }
                else if (heroTile.myNeighbours[direction].MyUnit.allow_move == true && heroTile.myNeighbours[direction].MyUnit.pushable == false)
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
