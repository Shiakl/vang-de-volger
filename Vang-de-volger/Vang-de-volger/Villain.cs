﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Vang_de_volger
{
    class Villain : FieldComponent
    {
        
        public Villain()
        {
            myImage = Image.FromFile(@"..\..\Resources\Villain.png");
        }
    }
}
