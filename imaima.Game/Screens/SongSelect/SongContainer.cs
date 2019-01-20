using imaima.Game.Songs;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osuTK;
using osuTK.Graphics;

namespace imaima.Game.Screens.SongSelect {
    class SongContainer : Container {
        private const float HEIGHT = 200;

        public SongContainer(Song song) {
            this.RelativeSizeAxes = Axes.X;
            this.Height = HEIGHT;

            this.Padding = new MarginPadding {
                Left = 50,
                Right = 50
            };

            this.AddRange(new Drawable[] {
                new Box {
                    RelativeSizeAxes = Axes.Both,
                    Colour = Color4.Blue
                },
                new Box {
                    Width = Height = HEIGHT,
                    Texture = song.albumArt
                },
                new SpriteText {
                    Text = song.title,
                    TextSize = 60,
                    Position = new Vector2(HEIGHT + 50, 20)
                }
            });
        }
    }
}
