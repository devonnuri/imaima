using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Graphics.UserInterface;
using osuTK.Graphics;

namespace imaima.Game.Screens.Menu {
    class SelectContainer : GridContainer {
        private Texture logoTexture;

        public SelectContainer(Texture logoTexture) {
            this.logoTexture = logoTexture;

            this.RowDimensions = this.ColumnDimensions = new[] {
                new Dimension(GridSizeMode.Absolute, 300),
                new Dimension(GridSizeMode.Absolute, 50),
                new Dimension(GridSizeMode.Absolute, 50),
                new Dimension(GridSizeMode.Absolute, 50)
            };
        }

        [BackgroundDependencyLoader]
        private void load(LargeTextureStore textureStore) {
            this.Content = new[] {
                new Drawable[] {
                    new Sprite {
                        Width = logoTexture.Width,
                        Height = logoTexture.Height,
                        Texture = logoTexture,
                    },
                },
                new Drawable[] {
                    new Button {
                        Anchor = Anchor.TopCentre,
                        Width = 200,
                        Height = 50,
                        Text = "Play",
                        Colour = Color4.White,
                        BackgroundColour = new Color4(128, 211, 237, 255),
                    },
                },
                new Drawable[] {
                    new Button {
                        Width = 200,
                        Height = 50,
                        Text = "Edit",
                        Colour = Color4.White,
                        BackgroundColour = new Color4(128, 211, 237, 255),
                    },
                },
                new Drawable[] {
                    new Button {
                        Width = 200,
                        Height = 50,
                        Text = "Setting",
                        Colour = Color4.White,
                        BackgroundColour = new Color4(128, 211, 237, 255),
                    },
                }
            };

        }
    }
}
