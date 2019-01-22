using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Textures;
using osu.Framework.Screens;
using osuTK.Graphics;
using System;

namespace imaima.Game.Screens.Menu {
    internal class MenuMainContainer : Container {
        private LogoContainer logo;
        private MenuButton playButton;
        private MenuButton editButton;
        private MenuButton settingButton;

        public Action OnPlay {
            set {
                playButton.clickAction = value;
            }
        }
        private Action OnEdit {
            set {
                editButton.clickAction = value;
            }
        }
        private Action OnSetting {
            set {
                settingButton.clickAction = value;
            }
        }

        public MenuMainContainer(Texture logoTexture) {
            Children = new Drawable[] {
                logo = new LogoContainer(logoTexture, delegate (bool toggleClick) {
                    playButton.Visible = editButton.Visible = settingButton.Visible = toggleClick;
                }),
                playButton = new MenuButton("Play", new Color4(93, 168, 191, 255)) {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Y = 10,
                    AutoSizeAxes = Axes.Both
                },
                editButton = new MenuButton("Edit", new Color4(93, 168, 191, 255)) {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Y = 80,
                    AutoSizeAxes = Axes.Both
                },
                settingButton = new MenuButton("Setting", new Color4(93, 168, 191, 255)) {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Y = 150,
                    AutoSizeAxes = Axes.Both
                }
            };
        }
    }
}
