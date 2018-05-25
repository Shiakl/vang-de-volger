using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Vang_de_volger
{
    class Block :FieldComponent
    {

        public Block(bool move, bool villain_move, bool push) : base(move, villain_move, push)
        {
            allow_move = move;
            allow_villain_move = villain_move;
            pushable = push;
            myImage = Image.FromFile(@"..\..\Resources\Block.jpg");

        }

    }
}
