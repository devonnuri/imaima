using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Textures;
using osu.Framework.Input.Events;
using osuTK;

namespace imaima.Game.Screens.Menu {
    class LogoContainer : Container {
        public bool toggleClick = false;

        private Box logo;

        public LogoContainer(Texture logoTexture) {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            AutoSizeAxes = Axes.Both;

            Children = new Drawable[] {
                this.logo = new Box {
                    Size = logoTexture.Size,
                    Scale = new Vector2(0.9f, 0.9f),
                    Texture = logoTexture
                }
            };
        }

        protected override bool OnClick(ClickEvent e) {
            this.toggleClick = !this.toggleClick;

            if (this.toggleClick) {
                this.logo.ScaleTo(1.1f, 400, Easing.OutElastic);
            } else {
                this.logo.ScaleTo(0.9f, 400, Easing.OutElastic);
            }
            
            return true;
        }
    }
}
