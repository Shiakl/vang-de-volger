using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Vang_de_volger
{
    class Villain : Unit
    {
        
        public Villain(UNITTYPE setType) : base(setType)
        {
            MyType = setType;
            myImage = Image.FromFile(@"..\..\Resources\Villain.png");
        }
    }
}
