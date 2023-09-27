using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FS_Emulator
{
    public static class CanvaManager
    {


        public static string[,] BlankCanva(this string[,] canva)
        {
            for (int i = 0; i < canva.GetLength(0); i++)
            {
                for(int j = 0; j < canva.GetLength(1); j++)
                {
                    canva[i, j] = " ";
                }
            }
            return canva;
        }

        public static void DrawCanva(string[,] canva)
        {
            for (int i = 0; i < canva.GetLength(0); i++)
            {
                for (int j = 0; j < canva.GetLength(1); j++)
                {
                    Console.Write(canva[i, j]);
                }
                Console.WriteLine();
            }
        }

    }
}
