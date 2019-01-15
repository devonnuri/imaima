using imaima.Game.Screens.SongSelect;
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

            this.track = new TrackBass(game.Resources.GetStream(@"Samples/title-screen.mp3"));
            audio.Track.AddItem(track);

            var logoTexture = textureStore.Get(@"Logo/milkplus");

            this.upperContainer.Add(new Box {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Both,
                Colour = new Color4(111, 198, 225, 255)
            });

            this.upperContainer.Add(new Sprite {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Texture = logoTexture,
                Size = logoTexture.Size / 2
            });

            this.circularContainer.Children = new Drawable[] {
                new Box {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    RelativeSizeAxes = Axes.Both,
                    Colour = new Color4(111, 198, 225, 255)
                },
                new MenuMainContainer(this, logoTexture) {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    RelativeSizeAxes = Axes.Both,

                    OnPlay = delegate {
                        this.track.Stop();

                        Push(new SongSelectScreen());
                    }
                }
            };
        }

        protected override void LoadComplete() {
            base.LoadComplete();

            this.track.Start();
        }
    }
}
