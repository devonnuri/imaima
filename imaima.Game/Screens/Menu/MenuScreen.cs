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
                Colour = Color4.Blue
            });

            lowerContainer.Add(new Box {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Both,
                Colour = Color4.Red
            });
        }

        protected override void LoadComplete() {
            base.LoadComplete();

            track.Start();
        }
    }
}
