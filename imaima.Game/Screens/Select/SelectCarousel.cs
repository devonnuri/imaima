using imaima.Game.Songs;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace imaima.Game.Screens.Select {
    internal class SelectCarousel : ScrollContainer {
        private SongContainer[] containers;
        private Action<Song> playPreview;
        private Song[] songList;

        private int selectedIndex = -1;

        public int SelectedIndex {
            get => selectedIndex;
            set {
                if (containers[value].State == SelectState.Selected) {
                    containers[value].State = SelectState.DetailShowing;
                } else {
                    containers[value].State = SelectState.Selected;
                }

                if (selectedIndex != value) {
                    if (selectedIndex > -1) {
                        containers[selectedIndex].State = SelectState.NotSelected;
                    }
                    containers[value].State = SelectState.Selected;
                    playPreview.Invoke(songList[value]);
                }

                selectedIndex = value;
            }
        }

        public SelectCarousel(Song[] songList, Action<Song> playPreview) {
            this.songList = songList;
            this.playPreview = playPreview;

            containers = songList
                .Select((song, index) => new SongContainer(song, delegate {
                    SelectedIndex = index;
                }) {
                    RelativeSizeAxes = Axes.X,
                    Y = (SongContainer.HEIGHT + 20) * (index + 1)
                })
                .ToArray();

            AddRange(containers);
        }
    }
}
