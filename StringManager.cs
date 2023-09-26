using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS_Emulator
{
    public class StringManager
    {

        public string Multiply(string source, int multiplier)
        {
           string target = source;

            for (int i = 0; i <= multiplier - 2; i++)
            {
                target += source;
            }

            if (multiplier == 0) return "";
            else return target;
        }
    }

}

    
