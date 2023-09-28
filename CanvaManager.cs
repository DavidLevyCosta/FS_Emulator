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
                bool on_cell_x = i >= Table.color_position[cell_num].Item3 + Table.table_y_start & i <= Table.color_position[cell_num].Item4 + Table.table_y_start;

                for (int j = 0; j < canva.GetLength(1); j++)
                {
                    bool on_cell_y = j + 1 >= Table.color_position[cell_num].Item1 + Table.table_y_start && j <= Table.color_position[cell_num].Item2 + Table.table_y_start;
                    bool cell_ends_y = j == Table.color_position[cell_num].Item2 + Table.table_y_start;
                    bool inside_bounds = cell_num < Table.color_position.Length - 1;
                    bool first_row = cell_num < Table.col;
                    bool InsideTaleBounds(int i, int j)
                    {
                        return i - 1 < Table.table_x_end && j - 1 < Table.table_y_end && i + 1 > Table.table_x_start && j + 1 > Table.table_y_start;
                    }

                    if (first_row)
                    {
                        if (on_cell_y && on_cell_x)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.Write(canva[i, j]);
                            Console.ResetColor();
                        }
                        else if (InsideTaleBounds(i, j))
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Write(canva[i, j]);
                            Console.ResetColor();
                        }
                        else Console.Write(canva[i, j]);
                    }
                    else
                    {
                        if (on_cell_y && on_cell_x)
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write(canva[i, j]);
                            Console.ResetColor();
                        }
                        else if (InsideTaleBounds(i, j))
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Write(canva[i, j]);
                            Console.ResetColor();
                        }
                        else Console.Write(canva[i, j]);
                    }

                    if (cell_ends_y && on_cell_x && inside_bounds) cell_num++;



                }
                
                Console.WriteLine();
            }
        }

    }
}
