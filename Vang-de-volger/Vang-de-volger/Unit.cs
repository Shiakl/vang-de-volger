using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Vang_de_volger
{
    class Unit
    {
        public Image myImage;                     //Reserve the image of an Unit
        public UNITTYPE MyType { get; set; }


        public Unit(UNITTYPE setType)
        {
            MyType = setType;
            if(MyType == UNITTYPE.BLOCK)
            {
                myImage = Image.FromFile(@"..\..\Resources\Block.jpg");
            }
            else if (MyType == UNITTYPE.TILE)
            {
                myImage = Image.FromFile(@"..\..\Resources\Tile.jpg");
            }
        }

        public enum UNITTYPE
        {
            BLOCK,
            TILE,
            BOX,
            HERO,
            VILLAIN
        }

        public void Swap_MyUnit(Tile old_Tile, Tile new_Tile)
        {
            Unit temp_Unit;
            temp_Unit = old_Tile.MyUnit;
            old_Tile.MyUnit = new_Tile.MyUnit;
            new_Tile.MyUnit = temp_Unit;
        }

    }
}
