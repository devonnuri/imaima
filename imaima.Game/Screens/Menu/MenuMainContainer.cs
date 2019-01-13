using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Textures;
using osuTK.Graphics;

namespace imaima.Game.Screens.Menu {
    class MenuMainContainer : Container {
        private LogoContainer logo;
        private MenuButton playButton;

        public MenuMainContainer(Texture logoTexture) {
            this.Children = new Drawable[] {
                this.logo = new LogoContainer(logoTexture, delegate (bool toggleClick) {
                    this.playButton.changeState(toggleClick);
                }),
                this.playButton = new MenuButton("Play", new Color4(93, 168, 191, 255), null) {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    AutoSizeAxes = Axes.Both
                }
            };
        }
    }
}
