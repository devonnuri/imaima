using imaima.Game.Containers;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Textures;
using osuTK.Graphics;

namespace imaima.Game.Screens.SongSelect {
    class SongSelectScreen : SplitScreen {
        [BackgroundDependencyLoader]
        private void load(ImaimaGame game, LargeTextureStore textureStore) {
            this.upperContainer.Add(new ProfileContainer("devonnuri", "ソルト♥JAVASCRIPT大好き！", textureStore.Get("Icons/umaru.png"), textureStore.Get("Nameplates/blue.png"), textureStore.Get("Frames/gochuumon.png")));

            this.circularContainer.Children = new Drawable[] {
                new Box {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    RelativeSizeAxes = Axes.Both,
                    Colour = new Color4(111, 198, 225, 255)
                }
            };
        }
    }
}
