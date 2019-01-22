using imaima.Game.Songs;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Input.Events;
using osuTK;
using osuTK.Graphics;
using System;

namespace imaima.Game.Screens.Select {
    class SongContainer : Container {
        public static readonly float HEIGHT = 150;

        public bool Activated {
            set {
                this.boxHoverLayer.FadeTo(value ? 0.2f : 0, 300, Easing.OutQuint);
            }
        }

        private Action clickAction;
        private Box boxHoverLayer;

        public SongContainer(Song song, Action clickAction) {
            this.clickAction = clickAction;

            this.Height = HEIGHT;

            this.Padding = new MarginPadding {
                Left = 50,
                Right = 50
            };

            this.AddRange(new Drawable[] {
                new Box {
                    RelativeSizeAxes = Axes.Both,
                    Colour = new Color4(102, 183, 208, 255)
                },
                boxHoverLayer = new Box {
                    RelativeSizeAxes = Axes.Both,
                    Colour = Color4.Black,
                    Alpha = 0
                },
                new Box {
                    Width = HEIGHT,
                    Height = HEIGHT,
                    Texture = song.Info.AlbumArt
                },
                new SpriteText {
                    Text = song.Info.Title,
                    TextSize = 50,
                    Position = new Vector2(HEIGHT + 20, 20)
                }
            });
        }

        protected override bool OnClick(ClickEvent e) {
            this.clickAction.Invoke();
            return base.OnClick(e);
        }
    }
}
