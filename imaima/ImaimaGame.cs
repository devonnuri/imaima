using osu.Framework;
using osu.Framework.Graphics;
using osuTK;
using osuTK.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Allocation;

namespace imaima {
    class ImaimaGame: Game {
        private Box box;

        [BackgroundDependencyLoader]
        private void load() {
            Add(box = new Box {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(150, 150),
                Colour = Color4.Tomato
            });
        }

        protected override void Update() {
            base.Update();
            box.Rotation += (float) Time.Elapsed / 10;
        }
    }
}
