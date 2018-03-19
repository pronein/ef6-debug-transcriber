using System.Diagnostics;
using EF6DebugTranscriber.Data;
using EF6DebugTranscriber.Migrations;

namespace EF6DebugTranscriber {
    class Program {
        static void Main(string[] args) {
            using (var ctx = new HeroContext()) {
                var config = new Configuration();

                config.RunSeed(ctx);
            }
        }
    }
}
