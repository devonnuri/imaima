using osu.Framework;
using osu.Framework.Graphics;
using osuTK;
using osuTK.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Allocation;
using imaima.Screens.Menu;
using osu.Framework.IO.Stores;
using osu.Framework.Graphics.Textures;

namespace imaima {
    class ImaimaGame : Game {
        private DependencyContainer dependencies;

        protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent) =>
            dependencies = new DependencyContainer(base.CreateChildDependencies(parent));

        [BackgroundDependencyLoader]
        private void load() {
            Window.Size = new System.Drawing.Size(540, 960);
            Window.Title = @"imaima v0.1";

            Resources.AddStore(new DllResourceStore(@"imaimaResources.dll"));

            LargeTextureStore largeStore = new LargeTextureStore(new TextureLoaderStore(new NamespacedResourceStore<byte[]>(Resources, @"Textures")));
            largeStore.AddStore(new TextureLoaderStore(new OnlineStore()));
            dependencies.Cache(largeStore);

            dependencies.CacheAs(this);
            dependencies.Cache(Fonts = new FontStore(new GlyphStore(Resources, @"Fonts/Ubuntu-Regular")));
            Fonts.AddStore(new FontStore(new GlyphStore(Resources, @"Fonts/Ubuntu-Italic")));
            Fonts.AddStore(new FontStore(new GlyphStore(Resources, @"Fonts/Ubuntu-Bold")));
            Fonts.AddStore(new FontStore(new GlyphStore(Resources, @"Fonts/Ubuntu-BoldItalic")));
            Fonts.AddStore(new FontStore(new GlyphStore(Resources, @"Fonts/Ubuntu-Light")));
            Fonts.AddStore(new FontStore(new GlyphStore(Resources, @"Fonts/Ubuntu-LightItalic")));

            Add(new MenuScreen());
        }
    }
}
