using imaima.Game.Screens.Menu;

namespace imaima.Game {
    public class ImaimaGame : ImaimaGameBase {
        private MenuScreen screen;

        protected override void LoadComplete() {
            base.LoadComplete();

            Add(screen = new MenuScreen());
        }
    }
}
