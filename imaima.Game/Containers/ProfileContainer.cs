using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK;
using osuTK.Graphics;

namespace imaima.Game.Containers {
    class ProfileContainer : Container {
        private string name;
        private string trophy;
        private Texture nameplateTexture;
        private Texture frameTexture;

        public ProfileContainer(string name, string trophy, Texture iconTexture, Texture nameplateTexture, Texture frameTexture) {
            this.name = name;
            this.trophy = trophy;
            this.nameplateTexture = nameplateTexture;
            this.frameTexture = frameTexture;

            this.RelativeSizeAxes = Axes.Both;
            this.Children = new Drawable[] {
                new Box {
                    RelativeSizeAxes = Axes.Both,
                    Texture = frameTexture
                },
                new Box {
                    Texture = iconTexture,
                    Size = iconTexture.Size
                },
                new Container {
                    EdgeEffect = new EdgeEffectParameters {
                        Type = EdgeEffectType.None,
                        Roundness = 5,
                        Radius = 10
                    },
                    Width = 200,
                    Height = 50,
                    Children = new Drawable[] {
                        new Box {
                            RelativeSizeAxes = Axes.Both,
                            Texture = nameplateTexture
                        },
                        new SpriteText {
                            Text = name,
                            TextSize = 70,
                            Spacing = new Vector2(10, 0),
                        }
                    }
                },
                new Container {
                    Width = 300,
                    Height = 30,
                    Children = new Drawable[] {
                        new Box {
                            RelativeSizeAxes = Axes.Both,
                            Colour = Color4.Red
                        },
                        new SpriteText {
                            Text = trophy,
                            TextSize = 40
                        }
                    }
                }
            };
        }
    }
}
