using imaima.Game.Notes;
using imaima.Game.Notes.Drawables;
using imaima.Game.Songs;
using osu.Framework.Allocation;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Textures;
using osu.Framework.Timing;

namespace imaima.Game.Screens.Play {
    internal class NoteLayerContainer : Container {
        private DecoupleableInterpolatingFramedClock adjustableClock;
        private readonly Difficulty difficulty;

        public NoteLayerContainer(DecoupleableInterpolatingFramedClock adjustableClock, Difficulty difficulty) {
            this.adjustableClock = adjustableClock;
            this.difficulty = difficulty;
        }

        [BackgroundDependencyLoader]
        private void load(LargeTextureStore textureStore) {
            var singleTexture = textureStore.Get("Notes/singlenote.png");
            var multiTexture = textureStore.Get("Notes/multinote.png");

            NoteData data = NoteData.Parse(difficulty);

            var drawableNotes = new DrawableTapNote[data.NoteCount];
            int i = 0;
            foreach (var pair in data.SyncedNotes) {
                bool isMulti = pair.Value.Count > 1;
                foreach (var note in pair.Value) {
                    drawableNotes[i] = new DrawableTapNote(note, isMulti ? multiTexture : singleTexture, i) {
                        Clock = adjustableClock,
                        ProcessCustomClock = false
                    };

                    i++;
                }
            }

            AddRange(drawableNotes);
        }
    }
}
