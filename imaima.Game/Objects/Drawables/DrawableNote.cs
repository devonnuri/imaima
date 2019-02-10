using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Textures;
using osuTK;
using System;

namespace imaima.Game.Objects.Drawables {
    internal class DrawableNote : DrawableObject<Note> {
        private Box circle;

        public DrawableNote(Note note, Texture texture) : base(note) {
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
            double angle = (Note.Position * 45 + 22.5) * Math.PI / 180;
            
            circle.FadeIn(Note.IncomingTime / 4);
            circle.MoveTo(new Vector2((float) Math.Cos(angle) * 286, (float) Math.Sin(angle) * 286), Note.IncomingTime);
        }

        private void UpdateCurrentState(NoteState state) {
            switch (state) {
                case NoteState.Idle:
                    circle.Delay(300).FadeOut(200);

                    Expire(true);

                    LifetimeEnd = Note.StartTime + 300 + 200;
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
