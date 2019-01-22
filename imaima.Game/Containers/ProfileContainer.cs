using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK;

namespace imaima.Game.Containers {
    internal class ProfileContainer : Container {
        public ProfileContainer(string name, string trophy, Texture iconTexture, Texture nameplateTexture, Texture trophyBgTexture, Texture frameTexture) {
            RelativeSizeAxes = Axes.Both;

            AddRange(new Drawable[] {
                new Box {
                    RelativeSizeAxes = Axes.Both,
                    Texture = frameTexture
                },
                new Box {
                    Texture = iconTexture,
                    Size = iconTexture.Size,
                    Position = new Vector2(10, 15)
                },
                new Container {
                    Size = new Vector2(248.5f, 84),
                    Position = new Vector2(150, 0),
                    Children = new Drawable[] {
                        new Box {
                            RelativeSizeAxes = Axes.Both,
                            Texture = nameplateTexture
                        },
                        new SpriteText {
                            Position = new Vector2(17, 35),
                            Text = name,
                            TextSize = 60,
                            Shadow = true,
                            Spacing = new Vector2(7, 0)
                        }
                    }
                },
                new Container {
                    Size = new Vector2(280, 35),
                    Position = new Vector2(150, 90),
                    Children = new Drawable[] {
                        new Box {
                            RelativeSizeAxes = Axes.Both,
                            Texture = trophyBgTexture
                        },
                        new SpriteText {
                            Text = trophy,
                            TextSize = 40,
                            Position = new Vector2(15, 8)
                        }
                    }
                }
            });
        }
    }
}
