using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FS_Emulator
{
    internal class Table_old
    {

        StringManager str = new StringManager();

        public int line = 6, col = 5;
        public const int MIN_PADDING = 1;


        public string[,] fifo_table = new string[,] { {"Processo", "Tempo UCP", "Criação", "TME", "TMP"},
                                                    {"1", "2", "1", "2", "1"},
                                                    {"1", "2", "12", "2", "1"},
                                                    {"1", "2", "1", "2222", "1"},
                                                    {"1", "2", "1", "2", "1"},
                                                    {"1", "2", "1", "1", "2"} };

        public string[] table_draw;

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

        public int AdjustTablePadding(string[,] array, int bigger_string, int i, int k)
        {
            int difference = bigger_string - array[i, k].Length;
            return difference;
        }

        public void CreateTableDrawing(int table_padding)
        {
            int line_qnt = (line * 2) + 1;
            table_draw = new string[line_qnt];

            for (int i = 0; i < line_qnt; i++)
            {
                int border_item_qnt = table_padding + (MIN_PADDING * 2);

                if (i == line_qnt - 1) table_draw[i] = "╚" + str.Multiply("═", border_item_qnt) + str.Multiply("╩" + str.Multiply("═", border_item_qnt), col - 2) + "╩" + str.Multiply("═", border_item_qnt) + "╝";
                if (i == 0) table_draw[i] = "╔" + str.Multiply("═", border_item_qnt) + str.Multiply("╦" + str.Multiply("═", border_item_qnt), col - 2) + "╦" + str.Multiply("═", border_item_qnt) + "╗";
                if ((i + 1) % 2 != 0 && i != 0 && i != line_qnt - 1) table_draw[i] = "╠" + str.Multiply("═", border_item_qnt) + str.Multiply("╬" + str.Multiply("═", border_item_qnt), col - 2) + "╬" + str.Multiply("═", border_item_qnt) + "╣";
                if ((i + 1) % 2 == 0 && i != 0)
                {
                    for (int k = 0; k < fifo_table.GetLength(1); k++)
                    {
                        int cell_padding = AdjustTablePadding(fifo_table, table_padding, (i - 1) / 2, k);
                        int cell_padding_left = 0, cell_padding_right = 0;

                        if (cell_padding == 1)
                        {
                            cell_padding_right = 0 + MIN_PADDING;
                            cell_padding_left = 1 + MIN_PADDING;
                        }
                        else if (cell_padding % 2 != 0)
                        {
                            cell_padding_right = ((cell_padding - 1) / 2) + MIN_PADDING;
                            cell_padding_left = (cell_padding_right + 1);
                        }
                        else
                        {
                            cell_padding_left = cell_padding / 2 + MIN_PADDING;
                            cell_padding_right = cell_padding / 2 + MIN_PADDING;
                        }

                        table_draw[i] += "║" + str.Multiply(" ", cell_padding_left) + fifo_table[(i - 1) / 2, k] + str.Multiply(" ", cell_padding_right);
                        if (k == fifo_table.GetLength(1) - 1) table_draw[i] += "║";
                    }
                }

            }

        }


    }
}
