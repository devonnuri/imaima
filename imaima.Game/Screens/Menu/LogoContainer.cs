using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Textures;
using osu.Framework.Input.Events;
using System;

namespace imaima.Game.Screens.Menu {
    internal class LogoContainer : Container {
        private bool toggleClick;
        private Action<bool> clickAction;

        public LogoContainer(Texture logoTexture, Action<bool> clickAction) {
            this.clickAction = clickAction;

            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            AutoSizeAxes = Axes.Both;

            Children = new Drawable[] {
                new Box {
                    Size = logoTexture.Size,
                    Texture = logoTexture
                }
            };
        }

        protected override bool OnClick(ClickEvent e) {
            toggleClick = !toggleClick;

            if (toggleClick) {
                this.ScaleTo(0.8f, 400, Easing.OutElastic);
                this.MoveToY(-150, 200, Easing.OutExpo);
            } else {
                this.ScaleTo(1, 400, Easing.OutElastic);
                this.MoveToY(0, 200, Easing.OutExpo);
            }

            clickAction?.Invoke(toggleClick);
            
            return true;
        }
    }
}
