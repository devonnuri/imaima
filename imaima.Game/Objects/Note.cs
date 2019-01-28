using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Textures;
using osuTK;
using System;

namespace imaima.Game.Objects {
    internal class Note : Box {
        protected int position;

        protected float velocity = 0.5f;
        protected Vector2 size = new Vector2(250, 250);

        public Note(Texture texture, int position) {
            this.position = position;

            Origin = Anchor.Centre;
            Anchor = Anchor.Centre;
            Rotation = position * 45 -22.5f;
            Size = size;
            Texture = texture;
        }

        protected override void Update() {
            X += velocity * (float) Math.Cos((Rotation + 90) * Math.PI / 180);
            Y += velocity * (float) Math.Sin((Rotation + 90) * Math.PI / 180);

            base.Update();
        }
    }
}
