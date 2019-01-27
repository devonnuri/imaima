using imaima.Game.Songs;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Input.Events;
using osuTK;
using osuTK.Graphics;
using System;
using System.Linq;

namespace imaima.Game.Screens.Select {
    internal class SongContainer : Container {
        private SelectState state = SelectState.NotSelected;
        private Box boxHoverLayer;
        private Container detailContainer;

        public static readonly float HEIGHT = 100;

        public SelectState State {
            get => state;
            set {
                state = value;
                
                switch (value) {
                    case SelectState.NotSelected:
                        boxHoverLayer.FadeTo(0, 300, Easing.OutQuint);
                        detailContainer.ScaleTo(new Vector2(1, 0), 500, Easing.OutQuint);
                        break;
                    case SelectState.Selected:
                        boxHoverLayer.FadeTo(0.2f, 300, Easing.OutQuint);
                        detailContainer.ScaleTo(new Vector2(1, 0), 500, Easing.OutQuint);
                        break;
                    case SelectState.DetailShowing:
                        boxHoverLayer.FadeTo(0.4f, 300, Easing.OutQuint);
                        detailContainer.ScaleTo(new Vector2(1, 1), 500, Easing.OutQuint);
                        break;
                }
            }
        }

        public SongContainer(Song song, Action clickAction, Action<Song, Difficulty> selectAction) {
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
                new MainSongContainer(song, clickAction) {
                    RelativeSizeAxes = Axes.X,
                    Height = HEIGHT
                },
                detailContainer = new Container {
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y,
                    Y = HEIGHT,
                    Scale = new Vector2(1, 0),
                    Children = new Drawable[] {
                        new Box {
                            RelativeSizeAxes = Axes.Both,
                            Colour = new Color4(93, 168, 191, 255)
                        },
                        new FillFlowContainer {
                            Direction = FillDirection.Vertical,
                            RelativeSizeAxes = Axes.X,
                            AutoSizeAxes = Axes.Y,
                            Children = song.Difficulties
                                .Select(difficulty => new DifficultyContainer(difficulty, () => selectAction.Invoke(song, difficulty)) {
                                    RelativeSizeAxes = Axes.X,
                                    Height = 40
                                })
                                .ToArray()
                        }
                    }
                }
            });
        }
    }
}
