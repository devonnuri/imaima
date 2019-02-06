using imaima.Game.Objects;
using imaima.Game.Objects.Drawables;
using osu.Framework.Allocation;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Textures;
using osu.Framework.Timing;
using System;

namespace imaima.Game.Screens.Play {
    internal class NoteLayerContainer : Container {
        private DecoupleableInterpolatingFramedClock adjustableClock;

        public NoteLayerContainer(DecoupleableInterpolatingFramedClock adjustableClock) {
            this.adjustableClock = adjustableClock;

            Clock = adjustableClock;
            ProcessCustomClock = false;
        }

        [BackgroundDependencyLoader]
        private void load(LargeTextureStore textureStore) {
            var noteTexture = textureStore.Get("Notes/singlenote.png");

            var testNote = new DrawableSingleNote[100];
            for (var i = 0; i < 100; i++) {
                testNote[i] = new DrawableSingleNote(new SingleNote {
                    StartTime = i * 150 + 1000,
                    Position = i % 8,
                    IncomingTime = 1000
                }, noteTexture) {
                    Clock = adjustableClock,
                    ProcessCustomClock = false
                };
            }

            AddRange(testNote);
        }
    }
}
