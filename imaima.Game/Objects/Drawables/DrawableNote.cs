using osu.Framework.Configuration;
using osu.Framework.Graphics.Containers;

namespace imaima.Game.Objects.Drawables {
    internal abstract class DrawableNote<T> : CompositeDrawable where T : Note {
        protected readonly T Note;
        protected Bindable<NoteState> State = new Bindable<NoteState>();

        public bool Interactive = true;
        public override bool HandleNonPositionalInput => Interactive;
        public override bool HandlePositionalInput => Interactive;

        public override bool RemoveWhenNotAlive => false;
        public override bool RemoveCompletedTransforms => false;
        protected override bool RequiresChildrenUpdate => true;

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
