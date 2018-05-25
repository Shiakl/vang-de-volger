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

        public Ground()
        {
            myImage = null;
            allow_move = true;
            pushable = false;
        }
    }
}
