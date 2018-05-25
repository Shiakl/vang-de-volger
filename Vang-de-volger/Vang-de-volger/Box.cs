using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vang_de_volger
{
    class Box : FieldComponent
    {

        public Box(bool move, bool villain_move, bool push) : base(move, villain_move, push)
        {
            allow_move = move;
            allow_villain_move = villain_move;
            pushable = push;
            myImage = Image.FromFile(@"..\..\Resources\Box.png");
        }
    }
}
