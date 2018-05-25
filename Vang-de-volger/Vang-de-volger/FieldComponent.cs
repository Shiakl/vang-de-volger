using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Vang_de_volger
{
    class FieldComponent
    {
        public Image myImage;

        public bool allow_move;
        public bool allow_villain_move;
        public bool pushable;


        public FieldComponent(bool move, bool villain_move, bool push)
        {
            allow_move = move;
            allow_villain_move = villain_move;
            pushable = push;
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

        //Checks allowed in parent class for different implementations of the children.
        //Twee verschillende move functies
        //decorator pattern, strategy pattern

    }
}
