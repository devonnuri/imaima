using imaima.Game.Screens.Select;
using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Audio.Track;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK.Graphics;

namespace imaima.Game.Screens.Menu {
    internal class MenuScreen : SplitScreen {
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
                Size = logoTexture.Size / 2
            });

            circularContainer.Children = new Drawable[] {
                new Box {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    RelativeSizeAxes = Axes.Both,
                    Colour = new Color4(111, 198, 225, 255)
                },
                new MenuMainContainer(logoTexture) {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    RelativeSizeAxes = Axes.Both,

                    OnPlay = delegate {
                        track.Stop();

                        Push(new SelectScreen());
                    }
                }
            };
        }

        protected override void LoadComplete() {
            base.LoadComplete();

            track.Start();
        }
    }
}
