using FS_Emulator;

namespace FS_Emulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Table table = new Table(6, 5, 1);
            Engine engine = new Engine();
            string[,] canva = new string[30, 70];
            canva.BlankCanva();
            string[,] table_draw = table.CreateTableDraw();
            table.PlaceInCanva(canva, table_draw, 1, 1);

            engine.Draw(canva);


        }


    }
}