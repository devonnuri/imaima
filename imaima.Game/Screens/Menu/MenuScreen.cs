using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Audio.Track;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK.Graphics;

namespace imaima.Game.Screens.Menu {
    class MenuScreen : SplitScreen {
        private TrackBass track;
        private LargeTextureStore textureStore;

        [BackgroundDependencyLoader]
        private void load(ImaimaGame game, AudioManager audio, LargeTextureStore textureStore) {
            this.textureStore = textureStore;

            track = new TrackBass(game.Resources.GetStream(@"Samples/title-screen.mp3"));
            audio.Track.AddItem(track);

            upperContainer.Add(new Box {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Both,
                Colour = new Color4(111, 198, 225, 255)
            });

            lowerContainer.Add(new Box {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Both,
                Colour = new Color4(111, 198, 225, 255)
            });
        }

        protected override void LoadComplete() {
            base.LoadComplete();

            track.Start();
        }
    }
}
