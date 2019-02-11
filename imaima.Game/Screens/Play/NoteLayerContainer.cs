﻿using imaima.Game.Notes;
using imaima.Game.Notes.Drawables;
using osu.Framework.Allocation;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Textures;
using osu.Framework.MathUtils;
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

            var testNote = new DrawableTapNote[200];
            for (var i = 0; i < 200; i++) {
                testNote[i] = new DrawableTapNote(new TapNote {
                    Index = i,
                    StartTime = i * 500 + 1000,
                    Position = (byte) (i % 8),
                    IncomingTime = 500
                }, noteTexture) {
                    Clock = adjustableClock,
                    ProcessCustomClock = false
                };
            }

            AddRange(testNote);
        }
    }
}
