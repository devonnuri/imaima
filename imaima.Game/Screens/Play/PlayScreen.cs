using imaima.Game.Containers;
using imaima.Game.Songs;
using osu.Framework;
using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Audio.Track;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Textures;
using osu.Framework.Timing;
using osuTK;
using System.IO;

namespace imaima.Game.Screens.Play {
    internal class PlayScreen : SplitScreen {
        private readonly Song song;
        private readonly Difficulty difficulty;

        private DecoupleableInterpolatingFramedClock adjustableClock;

        public PlayScreen(Song song, Difficulty difficulty) {
            this.song = song;
            this.difficulty = difficulty;
        }

        [BackgroundDependencyLoader]
        private void load(AudioManager audio, LargeTextureStore textureStore) {
            Stream stream = File.Open(song.Info.Audio, FileMode.Open);
            var track = new TrackBass(stream);
            audio.Track.AddItem(track);
            track.Start();

            adjustableClock = new DecoupleableInterpolatingFramedClock {
                IsCoupled = false
            };
            adjustableClock.Start();

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

            circularContainer.AddRange(new Drawable[] {
                new Box {
                    RelativeSizeAxes = Axes.Both,
                    Texture = textureStore.Get("Borders/white.png")
                },
                new NoteLayerContainer(adjustableClock) {
                    RelativeSizeAxes = Axes.Both
                }
            });
        }

        protected override void Update() {
            adjustableClock.ProcessFrame();

            base.Update();
        }
    }
}
