using osu.Framework.Configuration;
using osu.Framework.Graphics.Containers;

namespace imaima.Game.Objects.Drawables {
    internal abstract class DrawableNote<T> : CompositeDrawable where T : Note {
        protected readonly T Note;
        protected Bindable<NoteState> State = new Bindable<NoteState>();

        protected DrawableNote(T note) {
            Note = note;

            LifetimeStart = note.StartTime - note.IncomingTime;
        }

        protected override void LoadComplete() {
            base.LoadComplete();

            State.ValueChanged += UpdateState;
        }

        protected abstract void UpdateState(NoteState state);
    }
}
