using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Textures;
using osuTK;
using System;

namespace imaima.Game.Objects {
    internal class Note : Box {
        protected double timing;
        protected int position;

        protected float velocity = 1.5f;
        protected Vector2 size = new Vector2(250, 250);

        private float scale = 0.5f;

        public Note(Texture texture, double timing, int position) {
            this.timing = timing;
            this.position = position;

            Origin = Anchor.Centre;
            Anchor = Anchor.Centre;
            Rotation = position * 45 - 22.5f;
            Size = size;
            Scale = new Vector2(scale);
            Alpha = 0;
            AlwaysPresent = true;
            Texture = texture;
        }

        protected override void Update() {
            if (timing < Clock.CurrentTime) {
                if (Alpha < 1) {
                    Alpha = Math.Min(1f, Alpha + 0.03f);
                }

                if (Scale.X < 1) {
                    Scale = new Vector2(scale, scale);
                    scale += 0.03f;
                }

                X += velocity * (float) Math.Cos((Rotation + 90) * Math.PI / 180);
                Y += velocity * (float) Math.Sin((Rotation + 90) * Math.PI / 180);
            }

            base.Update();
        }
    }
}
