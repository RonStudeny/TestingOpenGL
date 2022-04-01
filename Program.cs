using TestingOpenGL.GameLoop;
namespace TestingOpenGL
{
    class Program
    {
        public static void Main()
        {
            Game game = new TestingGame(800, 600, "test");
            game.Run();
        }
    }
}