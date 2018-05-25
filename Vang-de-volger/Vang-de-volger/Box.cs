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

        public Box()
        {
            allow_move = true;
            pushable = true;
            myImage = Image.FromFile(@"..\..\Resources\Box.png");
        }
    }
}
