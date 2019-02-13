using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Textures;
using osuTK;

namespace imaima.Game.Notes.Drawables {
    internal class DrawableHoldNote : DrawableNote<HoldNote> {
        private readonly Box headBox;
        private readonly Box bodyBox;
        private readonly Box tailBox;

        public DrawableHoldNote(HoldNote note, Texture headTexture, Texture bodyTexture, int index) : base(note) {
            Origin = Anchor.Centre;
            Anchor = Anchor.Centre;
            Depth = index;

            InternalChildren = new Drawable[] {
                headBox = new Box {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Size = new Vector2(75, 75),
                    Rotation = Note.Position * 45f + 90,
                    Alpha = 0,
                    AlwaysPresent = true,
                    Texture = headTexture
                }
            };
        }

        protected override void UpdateState(NoteState state) {
            throw new System.NotImplementedException();
        }
    }
}
