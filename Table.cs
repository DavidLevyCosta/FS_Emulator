using System;
using System.Threading;

namespace FS_Emulator
{
    public class Table
    {
        int line_qnt;
        int col_pixels;
        int cell_space;
        int bigger_string;
        int min_padding;
        string[,] fifo_table = new string[,] { {"Processo", "Tempo UCP", "Criação", "TME", "TMP"},
                                                      {"1", "2", "1", "2", "1"},
                                                      {"1", "2", "12", "2", "1"},
                                                      {"1", "2", "1", "2222", "1"},
                                                      {"1", "2", "1", "2", "1"},
                                                      {"1", "2", "1", "1", "2"} };

        
        internal Table(int line, int col, int min_padding)
        {
            bigger_string = GetTablePadding(fifo_table);
            this.min_padding = min_padding; 
            col_pixels = (col * ((bigger_string + (min_padding * 2)) + 1)) + 1;
            cell_space = bigger_string + (min_padding * 2);
            line_qnt = (line * 2) + 1;
        }

        internal int GetTablePadding(string[,] array)
        {
            int bigger = 0;
            for (int i = 0; i < fifo_table.GetLength(0); i++)
            {
                for (int j = 0; j < fifo_table.GetLength(1); j++)
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
                        if (j != 0 && j != col_pixels - 1 && i != line_qnt && j % (cell_space + 1) != 0)
                        {
                            for (int k = 0; k <= cell_space; k++)
                            {
                                table_draw[i, j + k] = "═";
                                if (k < cell_space) j++;
                            }
                        }
                        if (j != 0 && j % (cell_space + 1) == 0) table_draw[i, j] = "╦";
                        if (j == col_pixels - 1) table_draw[i, j] = "╗";
                    }
                    if ((i + 1) % 2 == 0)
                    {

                        if (j % (cell_space + 1) == 0) table_draw[i, j] = "║";
                        if (j % (cell_space + 1) != 0)
                        {
                            int cell_left_padding = 0;
                            int cell_right_padding = 0;
                            int cell_padding = AdjustTablePadding(fifo_table, bigger_string, line_position, col_position);
                            if (cell_left_padding == 0)
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
                                table_draw[i, j + k] = " ";
                                if (k < cell_space) j++;
                            }

                            for (int k = 0; k < fifo_table[line_position, col_position].Length; k++)
                            {
                                table_draw[i, j + k] = fifo_table[line_position, col_position][k].ToString();
                                if (k < cell_space) j++;
                            }

                        }
                    }

                }
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
        }



    }
}
