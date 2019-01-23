﻿using imaima.Game.Songs;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Input.Events;
using osuTK;
using osuTK.Graphics;
using System;

namespace imaima.Game.Screens.Select {
    internal class SongContainer : Container {
        public static readonly float HEIGHT = 150;

        public SelectState State {
            get {
                return state;
            }
            set {
                state = value;
                
                switch (value) {
                    case SelectState.NotSelected:
                        boxHoverLayer.FadeTo(0, 300, Easing.OutQuint);
                        break;
                    case SelectState.Selected:
                        boxHoverLayer.FadeTo(0.2f, 300, Easing.OutQuint);
                        break;
                    case SelectState.DetailShowing:
                        boxHoverLayer.FadeTo(0.4f, 300, Easing.OutQuint);
                        break;
                }
            }
        }

        private SelectState state = SelectState.NotSelected;
        private Action clickAction;
        private Box boxHoverLayer;

        public SongContainer(Song song, Action clickAction) {
            this.clickAction = clickAction;

            Height = HEIGHT;

            Padding = new MarginPadding {
                Left = 50,
                Right = 50
            };

            AddRange(new Drawable[] {
                new Box {
                    RelativeSizeAxes = Axes.Both,
                    Colour = new Color4(102, 183, 208, 255)
                },
                boxHoverLayer = new Box {
                    RelativeSizeAxes = Axes.Both,
                    Colour = Color4.Black,
                    Alpha = 0
                },
                new Box {
                    Width = HEIGHT,
                    Height = HEIGHT,
                    Texture = song.Info.AlbumArt
                },
                new SpriteText {
                    Text = song.Info.Title,
                    TextSize = 50,
                    Position = new Vector2(HEIGHT + 20, 20)
                }
            });
        }

        protected override bool OnClick(ClickEvent e) {
            clickAction.Invoke();
            return base.OnClick(e);
        }
    }
}
