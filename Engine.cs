using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FS_Emulator
{
    public class Engine
    {
        private const int TARGET_FPS = 30;
        private int frame_counter = 0;
        public FrameManager frame_manager;
        private Table table;
        private Canva screen;

        public Engine()
        {        
            frame_manager = new FrameManager(TARGET_FPS);
            frame_manager.FrameUpdated += OnFrameUpdated;
            table = new Table();
            screen = new Canva();
        }

        public void OnFrameUpdated(double delta_time)
        {
            frame_counter++;
            Console.SetCursorPosition(0, 0);
            if (frame_counter % 30 == 0)
            {
                table.CreateTableDrawing(table.GetTablePadding(table.fifo_table));
                Draw();
            }

        }

        public void Draw()
        {       
            table.DrawTable(0, 0);
            for (int i = 0; i < screen.canva.GetLength(0); i++)
            {
                for (int j = 0; j < screen.canva.GetLength(1); j++)
                {
                    Console.Write(screen.canva[i, j]);
                }
                
                Console.WriteLine();
            }
        }


    }
}
