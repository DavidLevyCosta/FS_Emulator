using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FS_Emulator
{
    internal class Table
    {

        StringManager str;
        Canva screen;

        public int line = 6, col = 5;
        private int line_qnt, col_qnt;
        public const int MIN_PADDING = 1;
        int cell_space = 0;



        public string[,] fifo_table = new string[,] { {"Processo", "Tempo UCP", "Criação", "TME", "TMP"},
                                                    {"1", "2", "1", "2", "1"},
                                                    {"1", "2", "12", "2", "1"},
                                                    {"1", "2", "1", "2222", "1"},
                                                    {"1", "2", "1", "2", "1"},
                                                    {"1", "2", "1", "1", "2"} };
            
        public string[,] table_draw;


        public Table()
        {
            cell_space = GetTablePadding(fifo_table) + (MIN_PADDING * 2);
            str = new StringManager();
            screen = new Canva();
            line_qnt = (line * 2) + 1;
            col_qnt = (col * 2) + 1;
        }

        public int GetTablePadding(string[,] array)
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

        public int AdjustTablePadding(string[,] array, int bigger_string, int i, int j)
        {
            int difference = bigger_string - array[i, j].Length;
            return difference;
        }

        public void CreateTableDrawing(int table_padding)
        {
            int border_item_qnt = table_padding + (MIN_PADDING * 2);
            int col_pixels = (col_qnt * border_item_qnt) + 1;
            table_draw = new string[line_qnt, col_pixels];

            for (int i = 0; i < line_qnt; i++)
            {

                for (int j = 0; j < col_pixels; j++)
                {

                    if (i == 0 && j == 0) table_draw[i, j] = "╔";
                    if (i == 0 && j != 0 && j != col_pixels - 1 && i != line_qnt && j % (cell_space + 2) != 0)
                    {
                        int k = 0;
                        for (k = 0; k <= cell_space; k++)
                        {
                            table_draw[i, j + k] = "═";
                        }
                        j += k - 1;
                    }
                    if (i == 0 && j != 0 && j % (cell_space + 2) == 0) table_draw[i, j] = "╦";
                    if (j == col_pixels - 1 && i == line_qnt - 1) table_draw[i, j] = "╗";
                }
                
            }

        }

        public void DrawTable(int y, int x)
        {
            for (int i = 0; i < table_draw.GetLength(0); i++)
            {
                for (int j = 0; j < table_draw.GetLength(1); j++)
                {
                    screen.canva[i + x, j + y] = table_draw[i, j];
                }
            }
        }


    }
}
