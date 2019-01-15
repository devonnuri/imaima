using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Screens;
using osuTK;
using System;

namespace imaima.Game.Screens {
    class SplitScreen : Screen {
        protected Container upperContainer;
        private Container lowerContainer;
        protected CircularContainer circularContainer;

        [BackgroundDependencyLoader]
        private void load(ImaimaGame game) {
            game.Window.Resize += window_Resize;

            this.upperContainer = new Container {
                Anchor = Anchor.TopCentre,
                Origin = Anchor.TopCentre,
                RelativeSizeAxes = Axes.X,
                Height = 250
            };

            this.lowerContainer = new Container {
                Anchor = Anchor.BottomCentre,
                Origin = Anchor.BottomCentre,
                RelativeSizeAxes = Axes.X,
                Height = game.Window.Width
            };

            this.circularContainer = new CircularContainer {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Both,
                Masking = true,
                CornerRadius = lowerContainer.Height
            };

            this.lowerContainer.Add(circularContainer);

            this.AddRange(new Drawable[] {
                upperContainer,
                lowerContainer
            });
        }

        private void window_Resize(object sender, EventArgs args) {
            var window = sender as GameWindow;
            var availableHeight = window.Height - this.upperContainer.Height;

            this.lowerContainer.Height = Math.Min(window.Height - this.upperContainer.Height, window.Width);
            if (availableHeight < window.Width) {
                this.lowerContainer.Height = availableHeight;
                var padding = Math.Abs((availableHeight - window.Width) / 2);

                this.lowerContainer.Padding = new MarginPadding {
                    Left = padding,
                    Right = padding
                };
            } else {
                this.lowerContainer.Height = window.Width;
                this.lowerContainer.Padding = new MarginPadding(0);
            }
        }
    }
}
