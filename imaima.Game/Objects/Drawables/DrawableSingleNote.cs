using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Textures;
using osuTK;
using System;

namespace imaima.Game.Objects.Drawables {
    internal class DrawableSingleNote : DrawableNote<SingleNote> {
        private Box circle;

        public DrawableSingleNote(SingleNote note, Texture texture) : base(note) {
            

            Origin = Anchor.Centre;
            Anchor = Anchor.Centre;

            InternalChildren = new Drawable[] {
                circle = new Box {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Size = new Vector2(75, 75),
                    Rotation = Note.Position * 45f + 90,
                    Alpha = 0,
                    AlwaysPresent = true,
                    Texture = texture
                }
            };
        }

        protected override void LoadComplete() {
            base.LoadComplete();

            State.Value = NoteState.Idle;
        }

        protected override void UpdateState(NoteState state) {
            var transformTime = Note.StartTime - Note.IncomingTime;
            

            base.ApplyTransformsAt(transformTime, true);
            base.ClearTransformsAfter(transformTime, true);

            using (BeginAbsoluteSequence(transformTime, true)) {
                UpdateIncoming();

                using (BeginDelayedSequence(Note.IncomingTime, true)) {
                    UpdateCurrentState(state);
                }
            }
        }

        private void UpdateIncoming() {
            double angle = Note.Position * 45f + 67.5f;
            
            circle.FadeIn(Note.IncomingTime / 4);
            circle.MoveTo(new Vector2((float) Math.Cos(angle) * 200, (float) Math.Sin(angle) * 200), Note.IncomingTime);
        }

        private void UpdateCurrentState(NoteState state) {
            switch (state) {
                case NoteState.Idle:
                    circle.Delay(Note.IncomingTime).FadeOut(200);

                    Expire(true);

                    LifetimeEnd = Note.StartTime + Note.IncomingTime + 200;
                    break;
                case NoteState.Hit:
                    // this.FadeOut(500);
                    break;
                case NoteState.None:
                    break;
                case NoteState.Miss:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
    }
}
