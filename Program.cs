using System;

namespace rpsls_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Program game = new Program();
            game.RunGame();
        }
        public void RunGame()
        {
            Game gamer = new Game();
            gamer.GameStart();
        }
    }
}
