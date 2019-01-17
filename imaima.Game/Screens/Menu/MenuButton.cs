using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Input.Events;
using osuTK;
using osuTK.Graphics;
using System;

namespace imaima.Game.Screens.Menu {
    class MenuButton : Container {
        private Container box;
        private Box boxHoverLayer;
        private Container iconText;

        public Action clickAction;

        private const float BUTTON_WIDTH = 300;
        private const float BUTTON_HEIGHT = 50;

        public MenuButton(string text, Color4 color) {
            this.Children = new Drawable[] {
                this.box = new Container {
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
                            Colour = new Color4(0, 0, 0, 255),
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
            };
        }

        protected override bool OnMouseDown(MouseDownEvent e) {
            this.boxHoverLayer.FadeTo(0.1f, 500, Easing.OutQuint);
            return base.OnMouseDown(e);
        }

        protected override bool OnMouseUp(MouseUpEvent e)
        {
            this.boxHoverLayer.FadeTo(0, 500, Easing.OutQuint);
            return base.OnMouseUp(e);
        }

        protected override bool OnClick(ClickEvent e) {
            this.clickAction?.Invoke();
            return true;
        }

        public void changeState(bool state) {
            if (state) {
                this.box.MoveToY(0, 200, Easing.OutExpo);
                this.box.ScaleTo(new Vector2(1f, 1), 300, Easing.OutElastic);
                this.iconText.FadeTo(1, 100);
            } else {
                this.box.MoveToY(200, 200, Easing.OutExpo);
                this.box.ScaleTo(new Vector2(0, 1), 300, Easing.OutExpo);
                this.iconText.FadeTo(0, 100);
            }
        }
    }
}
