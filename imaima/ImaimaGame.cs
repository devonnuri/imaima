using imaima.Screens.Menu;
using osu.Framework.Graphics;

namespace imaima {
    class ImaimaGame : ImaimaGameBase {
        private MenuScreen screen;

        protected override void LoadComplete() {
            base.LoadComplete();

            AddRange(new Drawable[] {
                screen = new MenuScreen()
            });
        }
    }
}
