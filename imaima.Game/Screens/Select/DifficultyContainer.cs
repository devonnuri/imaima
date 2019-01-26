using imaima.Game.Songs;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Input.Events;
using osuTK;
using osuTK.Graphics;
using System;

namespace imaima.Game.Screens.Select {
    class DifficultyContainer : Container {
        private Difficulty difficulty;
        private Action<Difficulty> clickAction;

        private Box boxHoverLayer;

        public DifficultyContainer(Difficulty difficulty, Action<Difficulty> clickAction) {
            this.difficulty = difficulty;
            this.clickAction = clickAction;

            AddRange(new Drawable[] {
                new Box {
                    RelativeSizeAxes = Axes.Y,
                    Colour = difficulty.Color,
                    Width = 40,
                },
                boxHoverLayer = new Box {
                    RelativeSizeAxes = Axes.Both,
                    Colour = Color4.Black,
                    Alpha = 0,
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
            clickAction.Invoke(difficulty);

            return base.OnClick(e);
        }

        protected override bool OnMouseDown(MouseDownEvent e) {
            boxHoverLayer.FadeTo(0.15f, 100, Easing.InQuad);

            return base.OnMouseDown(e);
        }

        protected override bool OnMouseUp(MouseUpEvent e) {
            boxHoverLayer.FadeTo(0, 200, Easing.InQuad);

            return base.OnMouseUp(e);
        }
    }
}
