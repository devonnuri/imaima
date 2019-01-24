using imaima.Game.Songs;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Input.Events;
using osuTK;
using System;

namespace imaima.Game.Screens.Select {
    class DifficultyContainer : Container {
        private Action clickAction;

        public DifficultyContainer(Difficulty difficulty, Action clickAction) {
            this.clickAction = clickAction;

            AddRange(new Drawable[] {
                new Box {
                    RelativeSizeAxes = Axes.Y,
                    Colour = difficulty.Color,
                    Width = 40,
                },
                new SpriteText {
                    Origin = Anchor.Centre,
                    Position = new Vector2(20, 30),
                    Text = difficulty.Level,
                    TextSize = 50,
                },
                new SpriteText {
                    Origin = Anchor.CentreLeft,
                    Position = new Vector2(50, 30),
                    Text = difficulty.Name,
                    TextSize = 40
                }
            });
        }

        protected override bool OnClick(ClickEvent e) {
            clickAction.Invoke();

            return base.OnClick(e);
        }
    }
}
