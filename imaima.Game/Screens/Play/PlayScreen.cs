using imaima.Game.Containers;
using imaima.Game.Songs;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Textures;
using osu.Framework.Screens;

namespace imaima.Game.Screens.Play {
    class PlayScreen : SplitScreen {
        private readonly Difficulty difficulty;

        public PlayScreen(Difficulty difficulty) {
            this.difficulty = difficulty;
        }

        [BackgroundDependencyLoader]
        private void load(LargeTextureStore textureStore) {
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
                }
            });
        }
    }
}
