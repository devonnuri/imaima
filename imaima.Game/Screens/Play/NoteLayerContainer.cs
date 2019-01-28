using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Textures;
using osu.Framework.Timing;
using System;

namespace imaima.Game.Screens.Play {
    class NoteLayerContainer : Container {
        private Box[] testBox;

        public NoteLayerContainer(DecoupleableInterpolatingFramedClock adjustableClock) {
            Clock = adjustableClock;
            ProcessCustomClock = false;
        }

        [BackgroundDependencyLoader]
        private void load(LargeTextureStore textureStore) {
            var noteTexture = textureStore.Get("Notes/singlenote.png");

            testBox = new Box[10];
            for (int i = 0; i < 10; i++) {
                testBox[i] = new Box {
                    Origin = Anchor.Centre,
                    Anchor = Anchor.Centre,
                    Rotation = -22.5f,
                    Size = noteTexture.Size / 4,
                    Texture = noteTexture,
                };
            }

            AddRange(testBox);
        }

        protected override void Update() {
            for (int i = 0; i < 10; i++) {
                testBox[i].X += 1f / (i + 1) * (float) Math.Cos((testBox[i].Rotation + 90) * Math.PI / 180);
                testBox[i].Y += 1f / (i + 1) * (float) Math.Sin((testBox[i].Rotation + 90) * Math.PI / 180);
            }
            base.Update();
        }
    }
}
