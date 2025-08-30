using SOLIDPractice.Src.Core.Interfaces;

namespace SOLIDPractice.Src.Core.Models
{
    internal class RandomNumberGenerator : INumberGenerator
    {
        public int Generate(int min, int max)
        {
            return new Random().Next(min, max + 1);
        }
    }
}
