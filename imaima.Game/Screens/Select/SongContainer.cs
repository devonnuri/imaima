using imaima.Game.Songs;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osuTK;
using osuTK.Graphics;

namespace imaima.Game.Screens.Select {
    class SongContainer : Container {
        public static readonly float SONG_HEIGHT = 150;

        public SongContainer(Song song) {
            this.Height = SONG_HEIGHT;

            this.Padding = new MarginPadding {
                Left = 50,
                Right = 50
            };

            this.AddRange(new Drawable[] {
                new Box {
                    RelativeSizeAxes = Axes.Both,
                    Colour = new Color4(93, 168, 191, 255)
                },
                new Box {
                    Width = SONG_HEIGHT,
                    Height = SONG_HEIGHT,
                    Texture = song.Info.AlbumArt
                },
                new SpriteText {
                    Text = song.Info.Title,
                    TextSize = 50,
                    Position = new Vector2(SONG_HEIGHT + 20, 20)
                }
            });
        }
    }
}
