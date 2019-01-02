using osu.Framework;
using osu.Framework.Allocation;
using osu.Framework.IO.Stores;
using osu.Framework.Graphics.Textures;
using osu.Framework.Platform;
using osu.Framework.Configuration;
using System.Drawing;

namespace imaima {
    class ImaimaGameBase : Game {
        private DependencyContainer dependencies;
        private Storage storage;

        protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent) =>
            dependencies = new DependencyContainer(base.CreateChildDependencies(parent));

        public ImaimaGameBase() {
            Name = @"imaima";

            storage = new DesktopStorage("imaima", Host);
        }

        [BackgroundDependencyLoader]
        private void load() {
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

            dependencies.Cache(storage);
        }

        public override void SetHost(GameHost host) {
            base.SetHost(host);

            var config = new FrameworkConfigManager(storage);

            config.Set(FrameworkSetting.WindowMode, WindowMode.Windowed);
            config.Set(FrameworkSetting.WindowedSize, new Size(540, 960));
        }
    }
}
