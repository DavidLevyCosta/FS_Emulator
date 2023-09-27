using FS_Emulator;


namespace FS_Emulator
{
    public class Engine
    {
        public void Draw(string[,] canva)
        {
            Console.SetCursorPosition(0, 0);
            CanvaManager.DrawCanva(canva);
            Console.ReadLine();
        }

    }
}
