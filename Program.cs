using SOLIDPractice.Src.Core.Interfaces;
using SOLIDPractice.Src.Core.Models;

namespace SOLIDPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IGameSettings settings = new JsonGameSettings();
            INumberGenerator numberGenerator = new RandomNumberGenerator();

            var game = new GameController(numberGenerator, settings);

            game.Run();
        }
    }
}
