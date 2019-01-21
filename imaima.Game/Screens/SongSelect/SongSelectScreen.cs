﻿using imaima.Game.Containers;
using imaima.Game.Songs;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Textures;
using osu.Framework.Platform;
using osuTK.Graphics;
using System.Collections;
using System.IO;

namespace imaima.Game.Screens.SongSelect {
    class SongSelectScreen : SplitScreen {
        private ArrayList songList;

        [BackgroundDependencyLoader]
        private void load(ImaimaGame game, LargeTextureStore textureStore, DesktopStorage storage) {
            this.upperContainer.Add(new ProfileContainer("DEVONNURI", "ソルトとJAVASCRIPT大好き！", textureStore.Get("Icons/umaru.png"), textureStore.Get("Nameplates/norato.png"), textureStore.Get("TrophyBg/purple.png"), textureStore.Get("Frames/gochuumon.png")));

            this.circularContainer.Children = new Drawable[] {
                new Box {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    RelativeSizeAxes = Axes.Both,
                    Colour = new Color4(111, 198, 225, 255)
                }
            };

            if (!storage.ExistsDirectory("./Songs")) {
                Directory.CreateDirectory(storage.GetFullPath("./Songs"));
            }

            songList = new ArrayList();

            foreach (var directory in storage.GetDirectories("./Songs")) {
                Storage folder = storage.GetStorageForDirectory(directory);
                Song song = new Song();

                if (!folder.Exists("./songinfo"))
                    continue;

                song.Info = SongInfoParser.parse(folder.GetFullPath("./songinfo"));

                songList.Add(song);
            }

            foreach (Song song in songList) {
                circularContainer.Add(new SongContainer(song));
            }
        }
    }
}
