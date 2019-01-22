using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Input.Events;
using osuTK;
using osuTK.Graphics;
using System;

namespace imaima.Game.Screens.Menu {
    internal class MenuButton : Container {
        private readonly Container box;
        private readonly Box boxHoverLayer;
        private readonly Container iconText;

        public Action clickAction;

        public bool Visible {
            set {
                if (value) {
                    box.MoveToY(0, 200, Easing.OutExpo);
                    box.ScaleTo(new Vector2(1f, 1), 300, Easing.OutElastic);
                    iconText.FadeTo(1, 100);
                } else {
                    box.MoveToY(200, 200, Easing.OutExpo);
                    box.ScaleTo(new Vector2(0, 1), 300, Easing.OutExpo);
                    iconText.FadeTo(0, 100);
                }
            }
        }

        private const float BUTTON_WIDTH = 300;
        private const float BUTTON_HEIGHT = 50;

        public MenuButton(string text, Color4 color) {
            AddRange(new Drawable[] {
                box = new Container {
                    Masking = true,
                    MaskingSmoothness = 2,
                    EdgeEffect = new EdgeEffectParameters {
                        Type = EdgeEffectType.Shadow,
                        Colour = Color4.Black.Opacity(0.2f),
                        Roundness = 5,
                        Radius = 8
                    },
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Scale = new Vector2(0, 1),
                    Size = new Vector2(BUTTON_WIDTH, BUTTON_HEIGHT),
                    Children = new[] {
                        new Box {
                            EdgeSmoothness = new Vector2(1.5f, 0),
                            RelativeSizeAxes = Axes.Both,
                            Colour = color,
                        },
                        boxHoverLayer = new Box {
                            EdgeSmoothness = new Vector2(1.5f, 0),
                            RelativeSizeAxes = Axes.Both,
                            Colour = Color4.Black,
                            Alpha = 0
                        }
                    }
                },
                iconText = new Container {
                    AutoSizeAxes = Axes.Both,
                    Anchor = Anchor.TopCentre,
                    Origin = Anchor.TopCentre,
                    Alpha = 0,
                    Children = new Drawable[] {
                        new SpriteText {
                            Shadow = true,
                            AllowMultiline = false,
                            Anchor = Anchor.TopCentre,
                            Origin = Anchor.TopCentre,
                            Position = new Vector2(0, BUTTON_HEIGHT / 2),
                            Text = text,
                            TextSize = 75,
                            Font = "Ubuntu-Medium"
                        }
                    }
                }
            });
        }

        protected override bool OnMouseDown(MouseDownEvent e) {
            boxHoverLayer.FadeTo(0.1f, 500, Easing.OutQuint);
            return base.OnMouseDown(e);
        }

        protected override bool OnMouseUp(MouseUpEvent e) {
            boxHoverLayer.FadeTo(0, 500, Easing.OutQuint);
            return base.OnMouseUp(e);
        }

        protected override bool OnClick(ClickEvent e) {
            clickAction?.Invoke();
            return true;
        }
    }
}
