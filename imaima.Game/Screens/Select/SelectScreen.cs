using imaima.Game.Containers;
using imaima.Game.Songs;
using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Audio.Track;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Textures;
using osu.Framework.Platform;
using osuTK.Graphics;
using System.Collections.Generic;
using System.IO;

namespace imaima.Game.Screens.Select {
    internal class SelectScreen : SplitScreen {

        private TrackBass currentTrack;
        private Song currentSong;

        [BackgroundDependencyLoader]
        private void load(ImaimaGame game, AudioManager audio, LargeTextureStore textureStore, DesktopStorage storage) {
            upperContainer.Add(
                new ProfileContainer(
                    "DEVONNURI",
                    "ソルトとJAVASCRIPT大好き！",
                    textureStore.Get("Icons/umaru.png"),
                    textureStore.Get("Nameplates/norato.png"),
                    textureStore.Get("TrophyBg/purple.png"),
                    textureStore.Get("Frames/gochuumon.png")
                )
            );

            circularContainer.Add(new Box {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Both,
                Colour = new Color4(111, 198, 225, 255)
            });

            if (!storage.ExistsDirectory("./Songs")) {
                Directory.CreateDirectory(storage.GetFullPath("./Songs"));
            }

            var songList = new List<Song>();
            
            foreach (var directory in storage.GetDirectories("./Songs")) {
                var folder = storage.GetStorageForDirectory(directory);
                var song = new Song();

                if (!folder.Exists("./songinfo"))
                    continue;

                songList.Add(SongInfoParser.parse(song, folder.GetFullPath("./songinfo")));
            }

            circularContainer.Add(new SelectCarousel(songList.ToArray(), async delegate (Song song) {
                currentTrack?.Dispose();
                Stream stream = File.Open(song.Info.Audio, FileMode.Open);
                currentTrack = new TrackBass(stream);
                currentSong = song;
                currentTrack.Looping = true;
                audio.Track.AddItem(currentTrack);
                await currentTrack.StartAsync();
                await currentTrack.SeekAsync(song.Info.AudioPreviewTime);
            }) {
                RelativeSizeAxes = Axes.Both
            });
        }
    }
}
