using System;
using System.Threading;

namespace FS_Emulator
{
    public class Table
    {
        int line_qnt;
        int col_pixels;
        public static int cell_space;
        int bigger_string;
        int min_padding;
        public static int col;


        public static int table_x_start = 0;
        public static int table_y_start = 0;
        public static int table_x_end = 0;
        public static int table_y_end = 0;

        public static (int, int, int, int)[] color_position;
        string[,] fifo_table = new string[,] { {"Processo", "Tempo UCP", "Criação", "TME", "TMP"},
                                                      {"1", "2", "1", "2", "1"},
                                                      {"1", "2", "12", "2", "1"},
                                                      {"1", "2", "1", "2222", "1"},
                                                      {"1", "2", "1", "2", "1"},
                                                      {"1", "2", "1", "1", "2"} };

        string[,] new_array;

        
        internal Table(int line, int _col, int min_padding)
        {
            col = _col;
            color_position = new (int, int, int, int)[line * col];
            new_array = new string[line, col];
            BlankArray(new_array);
            PassTableToArray(fifo_table, new_array);
            this.min_padding = min_padding;
            bigger_string = GetTablePadding(new_array);
            col_pixels = (col * ((bigger_string + (min_padding * 2)) + 1)) + 1;
            cell_space = bigger_string + (min_padding * 2);
            line_qnt = (line * 2) + 1;

        }

        public static bool CellPlace(int j, int cell_space)
        {
            return j % (cell_space + 1) != 0;
        }

        public static bool BorderPlace(int j, int cell_space)
        {
            return j % (cell_space + 1) == 0;
        }

        internal void PassTableToArray(string[,] table, string[,] other_array)
        {
            for (int i = 0; i < Math.Min(table.GetLength(0), table.GetLength(0)); i++)
            {
                for (int j = 0; j < Math.Min(table.GetLength(1), table.GetLength(1)); j++)
                {
                    other_array[i, j] = table[i, j];
                }
            }
        }

        public static string[,] BlankArray(string[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = " ";
                }
            }
            return array;
        }

        internal int GetTablePadding(string[,] array)
        {
            int bigger = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j].Length > bigger) bigger = array[i, j].Length;
                }
            }
            return bigger;
        }

        internal int AdjustTablePadding(string[,] array, int bigger_string, int i, int j)
        {
            int difference = bigger_string - array[i, j].Length;
            return difference;
        }


        public string[,] CreateTableDraw()
        {
            string[,] table_draw = new string[line_qnt, col_pixels];
            int col_position = 0;
            int line_position = 0;

            for (int i = 0; i < table_draw.GetLength(0); i++)
            {
                for (int j = 0; j < table_draw.GetLength(1); j++)
                {
                    if (i == 0)
                    {
                        if (j == 0) table_draw[i, j] = "╔";
                        if (j != 0 && j != col_pixels - 1 && i != line_qnt && CellPlace(j, cell_space))
                        {
                            for (int k = 0; k <= cell_space; k++)
                            {
                                table_draw[i, j] = "═";
                                if (k < cell_space) j++;
                            }
                        }
                        if (j != 0 && BorderPlace(j, cell_space)) table_draw[i, j] = "╦";
                        if (j == col_pixels - 1)
                        {
                            table_draw[i, j] = "╗";
                        }
                    }
                    if ((i + 1) % 2 == 0)
                    {
                        color_position[(line_position * col) + col_position].Item3 = i;
                        color_position[(line_position * col) + col_position].Item4 = i;
                        if (BorderPlace(j, cell_space)) table_draw[i, j] = "║";
                        if (BorderPlace(j, cell_space) && j != 0) col_position++;
                        if (CellPlace(j, cell_space))
                        {
                            int cell_left_padding = 0;
                            int cell_right_padding = 0;
                            int cell_padding = AdjustTablePadding(new_array, bigger_string, line_position, col_position);
                            if (cell_padding == 0)
                            {
                                cell_left_padding = min_padding;
                                cell_right_padding = min_padding;
                            }
                            if (cell_padding % 2 == 0)
                            {
                                cell_left_padding = cell_padding / 2;
                                cell_right_padding = cell_left_padding;
                            }
                            if (cell_padding % 2 != 0)
                            {
                                cell_left_padding = (cell_padding - 1) / 2;
                                cell_right_padding = cell_left_padding + 1;
                            }

                            for (int k = 0; k <= cell_left_padding; k++)
                            {
                                table_draw[i, j] = " ";
                                if (k < cell_space) j++;
                            }

                            color_position[(line_position * col) + col_position].Item1 = j - cell_left_padding;

                            for (int k = 0; k < new_array[line_position, col_position].Length; k++)
                            {
                                table_draw[i, j] = new_array[line_position, col_position][k].ToString();
                                if (k < cell_space) j++;
                            }

                            color_position[(line_position * col) + col_position].Item2 = j + cell_right_padding;

                            for (int k = 0; k <= cell_right_padding; k++)
                            {
                                table_draw[i, j] = " ";
                                if (k < cell_space) j++;
                            }
                            j--;
                        }
                    }
                    if ((i + 1) % 2 != 0 && i != line_qnt - 1 && i != 0 && line_position == 1)
                    {
                        if (j == 0) table_draw[i, j] = "╠";
                        if (j != 0 && j != col_pixels - 1 && i != line_qnt && CellPlace(j, cell_space))
                        {
                            for (int k = 0; k <= cell_space; k++)
                            {
                                table_draw[i, j] = "═";
                                if (k < cell_space) j++;
                            }
                        }
                        if (j != 0 && BorderPlace(j, cell_space)) table_draw[i, j] = "╬";
                        if (j == col_pixels - 1) table_draw[i, j] = "╣";
                    }

                    if ((i + 1) % 2 != 0 && i != line_qnt - 1 && i != 0 && line_position > 1)
                    {
                        if (j == 0) table_draw[i, j] = "╟";
                        if (j != 0 && j != col_pixels - 1 && i != line_qnt && CellPlace(j, cell_space))
                        {
                            for (int k = 0; k <= cell_space; k++)
                            {
                                table_draw[i, j] = "─";
                                if (k < cell_space) j++;
                            }
                        }
                        if (j != 0 && BorderPlace(j, cell_space)) table_draw[i, j] = "╫";
                        if (j == col_pixels - 1) table_draw[i, j] = "╢";
                    }

                    if (i == line_qnt - 1)
                    {
                        if (j == 0) table_draw[i, j] = "╚";
                        if (j != 0 && j != col_pixels - 1 && i != line_qnt && CellPlace(j, cell_space))
                        {
                            for (int k = 0; k <= cell_space; k++)
                            {
                                table_draw[i, j] = "═";
                                if (k < cell_space) j++;
                            }
                        }
                        if (j != 0 && BorderPlace(j, cell_space)) table_draw[i, j] = "╩";
                        if (j == col_pixels - 1)
                        {
                            table_draw[i, j] = "╝";
                        }
                    }
                    
                }
                if ((i + 1) % 2 == 0) line_position++;
                col_position = 0;
            }

            return table_draw;
        }

        public void PlaceInCanva(string[,] canva, string[,] array, int x, int y)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0;  j < array.GetLength(1); j++)
                {
                    canva[i + y, j + x] = array[i, j];
                }
            }

            table_x_start = x;
            table_y_start = y;
            table_x_end += line_qnt - 1 + table_x_start;
            table_y_end += col_pixels - 1 + table_y_start;
        }



    }
}
