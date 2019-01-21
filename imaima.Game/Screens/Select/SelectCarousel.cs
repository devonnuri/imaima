using imaima.Game.Songs;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using System.Collections;

namespace imaima.Game.Screens.Select {
    class SelectCarousel : ScrollContainer {
        private ArrayList songList;

        public SelectCarousel(ArrayList songList) {
            this.songList = songList;
        }

        [BackgroundDependencyLoader]
        private void load() {
            float height = 0;
            foreach (Song song in songList) {
                Add(new SongContainer(song) {
                    RelativeSizeAxes = Axes.X,
                    Y = (height += SongContainer.SONG_HEIGHT + 20)
                });
            }
        }
    }
}
