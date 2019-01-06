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

            upperContainer = new Container {
                Anchor = Anchor.TopCentre,
                Origin = Anchor.TopCentre,
                RelativeSizeAxes = Axes.X,
                Height = 200
            };

            lowerContainer = new Container {
                Anchor = Anchor.BottomCentre,
                Origin = Anchor.BottomCentre,
                RelativeSizeAxes = Axes.X,
                Height = game.Window.Width
            };

            circularContainer = new CircularContainer {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Both,
                Masking = true,
                CornerRadius = lowerContainer.Height
            };

            lowerContainer.Add(circularContainer);

            AddRange(new Drawable[] {
                upperContainer,
                lowerContainer
            });
        }

        private void window_Resize(object sender, EventArgs args) {
            var window = sender as GameWindow;
            var availableHeight = window.Height - upperContainer.Height;

            lowerContainer.Height = Math.Min(window.Height - upperContainer.Height, window.Width);
            if (availableHeight < window.Width) {
                lowerContainer.Height = availableHeight;
                var padding = Math.Abs((availableHeight - window.Width) / 2);

                lowerContainer.Padding = new MarginPadding {
                    Left = padding,
                    Right = padding
                };
            } else {
                lowerContainer.Height = window.Width;
                lowerContainer.Padding = new MarginPadding(0);
            }
        }
    }
}
