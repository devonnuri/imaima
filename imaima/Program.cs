using osu.Framework;
using osu.Framework.Platform;
using System;

namespace imaima {
    class Program {
        [STAThread]
        static void Main(string[] args) {
            using (Game game = new ImaimaGame())
            using (GameHost host = Host.GetSuitableHost(@"imaima")) {
                host.Run(game);
            }
        }
    }
}
