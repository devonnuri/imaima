using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Audio.Track;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Textures;
using osu.Framework.Screens;
using osuTK;
using osuTK.Graphics;
using System;

namespace imaima.Game.Screens.Menu {
    class MenuScreen : Screen {
        private Box upperBox;
        private Box lowerBox;
        private TrackBass track;
        private LargeTextureStore textureStore;

        [BackgroundDependencyLoader]
        private void load(osu.Framework.Game game, AudioManager audio, LargeTextureStore textureStore) {
            this.textureStore = textureStore;
            
            track = new TrackBass(game.Resources.GetStream(@"Samples/title-screen.mp3"));
            audio.Track.AddItem(track);

            game.Window.Resize += window_Resize;

            Add(upperBox = new Box {
                Anchor = Anchor.TopCentre,
                Origin = Anchor.TopCentre,
                RelativeSizeAxes = Axes.X,
                Height = 200,
                Colour = Color4.White
            });

            Add(lowerBox = new Box {
                Anchor = Anchor.BottomCentre,
                Origin = Anchor.BottomCentre,
                RelativeSizeAxes = Axes.X,
                Height = game.Window.Width,
                Colour = Color4.Cyan
            });
        }

        protected override void LoadComplete() {
            base.LoadComplete();

            track.Start();
        }

        private void window_Resize(object sender, EventArgs args) {
            var window = sender as GameWindow;

            lowerBox.Height = window.Width;
        }
    }
}
