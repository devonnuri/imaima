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

            var logoTexture = textureStore.Get(@"Logo/milkplus");

            upperContainer.Add(new Box {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Both,
                Colour = new Color4(111, 198, 225, 255)
            });

            upperContainer.Add(new Sprite {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Texture = logoTexture,
                Width = logoTexture.Width / 2,
                Height = logoTexture.Height / 2
            });

            circularContainer.Add(new Box {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Both,
                Colour = new Color4(111, 198, 225, 255)
            });


            circularContainer.Add(new Sprite {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Texture = logoTexture,
                Width = logoTexture.Width,
                Height = logoTexture.Height
            });
        }

        protected override void LoadComplete() {
            base.LoadComplete();

            track.Start();
        }
    }
}
