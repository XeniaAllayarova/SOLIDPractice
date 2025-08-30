using Microsoft.Extensions.Configuration;
using SOLIDPractice.Src.Core.Interfaces;

namespace SOLIDPractice.Src.Core.Models
{
    internal class JsonGameSettings : IGameSettings
    {
        public int Tries { get; }
        public int MinRange { get; }
        public int MaxRange { get; }

        public JsonGameSettings() {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfiguration config = builder.Build();

            Tries = config.GetSection("Tries").Get<int>();
            var range = config.GetSection("Range").Get<List<int>>() ?? new List<int> { 1, 100 };
            
            MinRange = range[0];
            MaxRange = range[1];
        }
    }
}
