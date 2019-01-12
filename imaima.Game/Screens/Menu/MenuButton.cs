using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK;
using osuTK.Graphics;
using System;

namespace imaima.Game.Screens.Menu {
    class MenuButton : Container {
        private Container box;
        private Box boxHoverLayer;
        private Container iconText;

        public MenuButton(string text, Color4 color, Action clickAction) {
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
                    Size = new Vector2(120, 30),
                    Children = new[] {
                        new Box {
                            EdgeSmoothness = new Vector2(1.5f, 0),
                            RelativeSizeAxes = Axes.Both,
                            Colour = color,
                        },
                        boxHoverLayer = new Box {
                            EdgeSmoothness = new Vector2(1.5f, 0),
                            RelativeSizeAxes = Axes.Both,
                            Blending = BlendingMode.Additive,
                            Colour = Color4.White,
                            Alpha = 0
                        }
                    }
                },
                iconText = new Container {
                    AutoSizeAxes = Axes.Both,
                    Position = new Vector2(0, 0),
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Children = new Drawable[] {
                        new SpriteText {
                            Shadow = true,
                            AllowMultiline = false,
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            TextSize = 16,
                            Position = new Vector2(0, 35),
                            Text = text
                        }
                    }
                }
            };
        }
    }
}
