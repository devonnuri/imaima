using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Audio.Track;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Textures;
using osu.Framework.Screens;
using osuTK;
using osuTK.Graphics;

namespace imaima.Game.Screens.Menu {
    class MenuScreen : Screen {
        private Box box;
        private TrackBass track;
        private LargeTextureStore textureStore;

        [BackgroundDependencyLoader]
        private void load(osu.Framework.Game game, AudioManager audio, LargeTextureStore textureStore) {
            this.textureStore = textureStore;
            
            track = new TrackBass(game.Resources.GetStream(@"Samples/title-screen.mp3"));
            audio.Track.AddItem(track);

            Add(box = new Box {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Both,
                Colour = Color4.White
            });
        }

        protected override void LoadComplete() {
            base.LoadComplete();

            if (box != null)
                box.Texture = textureStore.Get(@"Backgrounds/finale.png");

            track.Start();
        }
    }
}
