using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Screens;
using osuTK;
using System;

namespace imaima.Game.Screens {
    class SplitScreen : Screen {
        protected Container upperContainer;
        protected Container lowerContainer;

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

            AddRange(new Drawable[] {
                upperContainer,
                lowerContainer
            });
        }

        private void window_Resize(object sender, EventArgs args) {
            var window = sender as GameWindow;

            if (lowerContainer != null && window != null) {
                lowerContainer.Height = window.Width;
            }
        }
    }
}
