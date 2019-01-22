using imaima.Game;
using osu.Framework;
using osu.Framework.Platform;

namespace imaima.Desktop {
    internal class Program {
        private static void Main(string[] args) {
            using (osu.Framework.Game game = new ImaimaGame())
            using (GameHost host = Host.GetSuitableHost(@"imaima")) {
                host.Run(game);
            }
        }
    }
}
