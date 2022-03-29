using TestingOpenGL.GameLoop;
namespace TestingOpenGL
{
    class Program
    {
        public static void Main()
        {
            Game game = new TestGame(800, 600, "test");
            game.Run();
        }
    }
}