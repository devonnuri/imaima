using imaima.Game.Screens.Menu;
using osu.Framework.Graphics;

namespace imaima.Game {
    public class ImaimaGame : ImaimaGameBase {
        private MenuScreen screen;

        protected override void LoadComplete() {
            base.LoadComplete();

            this.Add(screen = new MenuScreen());
        }
    }
}
