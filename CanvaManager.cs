using System;
using FS_Emulator;

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
            int cell_num = 0;
            for (int i = 0; i < canva.GetLength(0); i++)
            {
                bool on_cell_x = i >= Table.color_position[cell_num].Item3 + Table.table_y_position & i <= Table.color_position[cell_num].Item4 + Table.table_y_position;

                for (int j = 0; j < canva.GetLength(1); j++)
                {
                    bool on_cell_y = j + 1 >= Table.color_position[cell_num].Item1 + Table.table_y_position && j <= Table.color_position[cell_num].Item2 + Table.table_y_position;
                    bool cell_ends_y = j == Table.color_position[cell_num].Item2 + Table.table_y_position;
                    bool inside_bounds = cell_num < Table.color_position.Length - 1;

                    if (on_cell_y && on_cell_x)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(canva[i, j]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(canva[i, j]);
                    }
                    if (cell_ends_y && on_cell_x && inside_bounds) cell_num++;


                }
                
                Console.WriteLine();
            }
        }

    }
}
