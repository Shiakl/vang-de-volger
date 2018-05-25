﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Vang_de_volger
{
    abstract class FieldComponent
    {
        public Image myImage;

        public bool allow_move;
        public bool pushable;


        public FieldComponent()
        {
            myImage = null;
            allow_move = true;
            pushable = false;
        }

        public void Swap_MyUnit(Tile old_Tile, Tile new_Tile)
        {
            FieldComponent temp_Unit;
            temp_Unit = old_Tile.MyUnit;
            old_Tile.MyUnit = new_Tile.MyUnit;
            new_Tile.MyUnit = temp_Unit;
            old_Tile.Redraw();
            new_Tile.Redraw();
        }
    }
}
