using imaima.Game.Songs;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.MathUtils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace imaima.Game.Screens.Select {
    class SelectCarousel : ScrollContainer {
        private SongContainer[] containers;
        private int selectedIndex;

        public SelectCarousel(IEnumerable<Song> songList, Action<Song> playPreview) {
            this.containers = songList
                .Select((song, index) => new SongContainer(song, delegate {
                    this.selectedIndex = index;
                    for (int i = 0; i < this.containers.Length; i++) {
                        this.containers[i].Activated = index == i;
                    }

                    playPreview.Invoke(song);
                }) {
                    RelativeSizeAxes = Axes.X,
                    Y = (SongContainer.HEIGHT + 20) * (index + 1)
                })
                .ToArray();

            AddRange(this.containers);

            selectedIndex = RNG.Next(0, this.containers.Length);
        }
    }
}
