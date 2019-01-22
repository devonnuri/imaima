using imaima.Game.Songs;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace imaima.Game.Screens.Select {
    internal class SelectCarousel : ScrollContainer {
        private SongContainer[] containers;

        public SelectCarousel(IEnumerable<Song> songList, Action<Song> playPreview) {
            containers = songList
                .Select((song, index) => new SongContainer(song, delegate {
                    for (var i = 0; i < containers.Length; i++) {
                        containers[i].Activated = index == i;
                    }

                    playPreview.Invoke(song);
                }) {
                    RelativeSizeAxes = Axes.X,
                    Y = (SongContainer.HEIGHT + 20) * (index + 1)
                })
                .ToArray();

            AddRange(containers);
        }
    }
}
