using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Textures;
using osu.Framework.Input.Events;
using osuTK;
using System;

namespace imaima.Game.Screens.Menu {
    class LogoContainer : Container {
        private Box logo;
        private bool toggleClick = false;
        private Action<bool> clickAction;

        public LogoContainer(Texture logoTexture, Action<bool> clickAction) {
            this.clickAction = clickAction;

            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            AutoSizeAxes = Axes.Both;

            Children = new Drawable[] {
                this.logo = new Box {
                    Size = logoTexture.Size,
                    Texture = logoTexture,
                }
            };
        }

        protected override bool OnClick(ClickEvent e) {
            this.toggleClick = !this.toggleClick;

            if (this.toggleClick) {
                this.ScaleTo(0.8f, 400, Easing.OutElastic);
                this.MoveToY(-150, 200, Easing.OutExpo);
            } else {
                this.ScaleTo(1, 400, Easing.OutElastic);
                this.MoveToY(0, 200, Easing.OutExpo);
            }

            this.clickAction(this.toggleClick);
            
            return true;
        }
    }
}
