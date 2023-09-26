using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS_Emulator
{
    internal class Canva
    {
        public string[,] canva = new string[500, 500]; 

        public T[,] AdjustCanva<T>(T[,] canva, int y, int x)
        {
            var new_canva = new T[y, x];
            int minRows = Math.Min(y, canva.GetLength(0));
            int minCols = Math.Min(x, canva.GetLength(1));
            for (int i = 0; i < minRows; i++)
                for (int j = 0; j < minCols; j++)
                    new_canva[i, j] = canva[i, j];
            return new_canva;
        }
    }
}
