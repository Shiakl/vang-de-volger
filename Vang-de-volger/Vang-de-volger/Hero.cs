using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vang_de_volger
{
    class Hero : Unit
    {

        public Hero(UNITTYPE setType) : base(setType)
        {
            MyType = setType;
            myImage = Image.FromFile(@"..\..\Resources\Hero.png");
        }
    }
}
