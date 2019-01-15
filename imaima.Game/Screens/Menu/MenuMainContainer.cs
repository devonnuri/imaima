using imaima.Game.Screens.SongSelect;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Textures;
using osu.Framework.Screens;
using osuTK.Graphics;
using System;

namespace imaima.Game.Screens.Menu {
    class MenuMainContainer : Container {
        private LogoContainer logo;
        private MenuButton playButton;
        private MenuButton editButton;
        private MenuButton settingButton;

        private Action onPlay;
        private Action onEdit;
        private Action onSetting;

        public Action OnPlay {
            get {
                return this.onPlay;
            }
            set {
                this.playButton.clickAction = value;
            }
        }
        private Action OnEdit {
            get {
                return this.onEdit;
            }
            set {
                this.editButton.clickAction = value;
            }
        }
        private Action OnSetting {
            get {
                return this.onSetting;
            }
            set {
                this.settingButton.clickAction = value;
            }
        }

        public MenuMainContainer(Screen screen, Texture logoTexture) {
            this.Children = new Drawable[] {
                this.logo = new LogoContainer(logoTexture, delegate (bool toggleClick) {
                    this.playButton.changeState(toggleClick);
                    this.editButton.changeState(toggleClick);
                    this.settingButton.changeState(toggleClick);
                }),
                this.playButton = new MenuButton("Play", new Color4(93, 168, 191, 255)) {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Y = 10,
                    AutoSizeAxes = Axes.Both
                },
                this.editButton = new MenuButton("Edit", new Color4(93, 168, 191, 255)) {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Y = 80,
                    AutoSizeAxes = Axes.Both
                },
                this.settingButton = new MenuButton("Setting", new Color4(93, 168, 191, 255)) {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Y = 150,
                    AutoSizeAxes = Axes.Both
                }
            };
        }
    }
}
