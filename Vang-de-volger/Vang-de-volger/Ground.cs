using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Vang_de_volger
{
    class Ground : FieldComponent
    {

        public Ground(bool move, bool villain_move, bool push) : base(move, villain_move, push)
        {
            myImage = null;
            allow_move = move;
            allow_villain_move = villain_move;
            pushable = push;
        }

    }
}
