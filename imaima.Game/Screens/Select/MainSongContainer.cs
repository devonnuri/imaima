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
    class MainSongContainer : Container {
        Action clickAction;

        public MainSongContainer(Song song, Action clickAction) {
            this.clickAction = clickAction;

            AddRange(new Drawable[] {
                new Box {
                    Width = SongContainer.HEIGHT,
                    Height = SongContainer.HEIGHT,
                    Texture = song.Info.AlbumArt
                },
                new SpriteText {
                    Text = song.Info.Title,
                    TextSize = 50,
                    Position = new Vector2(SongContainer.HEIGHT + 20, 20)
                },
                new SpriteText {
                    Text = song.Info.Artist,
                    TextSize = 40,
                    Position = new Vector2(SongContainer.HEIGHT + 20, 50)
                },
            });
        }

        protected override bool OnClick(ClickEvent e) {
            clickAction.Invoke();

            return base.OnClick(e);
        }
    }
}
