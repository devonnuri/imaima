using imaima.Game.Objects;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Textures;
using osu.Framework.Timing;
using System;

namespace imaima.Game.Screens.Play {
    class NoteLayerContainer : Container {
        private DecoupleableInterpolatingFramedClock adjustableClock;

        private Note[] testNote;

        public NoteLayerContainer(DecoupleableInterpolatingFramedClock adjustableClock) {
            this.adjustableClock = adjustableClock;

            Clock = adjustableClock;
            ProcessCustomClock = false;
        }

        [BackgroundDependencyLoader]
        private void load(LargeTextureStore textureStore) {
            var noteTexture = textureStore.Get("Notes/singlenote.png");

            testNote = new Note[10];
            for (int i = 0; i < 10; i++) {
                testNote[i] = new Note(noteTexture, i % 8) {
                    Clock = adjustableClock,
                    ProcessCustomClock = false
                };
            }

            AddRange(testNote);
        }
    }
}
