using imaima.Screens.Backgrounds;
using osu.Framework.Allocation;
using osu.Framework.Screens;

namespace imaima.Screens.Menu {
    class MenuScreen : Screen {
        private Background background;

        public MenuScreen() {
            background = new Background(@"Backgrounds/finale.png");

            Add(background);
        }

        [BackgroundDependencyLoader(true)]
        private void load() {
            LoadComponentAsync(background);
        }
    }
}
