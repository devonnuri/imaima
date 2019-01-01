using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

namespace imaima.Screens.Backgrounds {
    class Background : BufferedContainer {
        public Sprite sprite;
        private readonly string textureName;
        
        public Background(string textureName = @"") {
            CacheDrawnFrameBuffer = true;

            this.textureName = textureName;
            RelativeSizeAxes = Axes.Both;

            Add(sprite = new Sprite {
                RelativeSizeAxes = Axes.Both,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                FillMode = FillMode.Fill
            });
        }

        [BackgroundDependencyLoader]
        private void load(LargeTextureStore textures) {
            if (!string.IsNullOrEmpty(textureName))
                sprite.Texture = textures.Get(textureName);
        }
    }
}
