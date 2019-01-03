using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Configuration;
using osu.Framework.Graphics.Textures;
using osu.Framework.IO.Stores;
using osu.Framework.Platform;
using osuTK;
using System.Drawing;

namespace imaima.Game {
    public class ImaimaGameBase : osu.Framework.Game {
        private DependencyContainer dependencies;
        private Storage storage;

        protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent) {
            return dependencies = new DependencyContainer(base.CreateChildDependencies(parent));
        }

        public ImaimaGameBase() {
            Name = @"imaima";

            storage = new DesktopStorage("imaima", Host);
        }

        [BackgroundDependencyLoader]
        private void load() {
            Resources.AddStore(new DllResourceStore("imaima.Resources.dll"));

            var largeStore = new LargeTextureStore(new TextureLoaderStore(new NamespacedResourceStore<byte[]>(Resources, @"Textures")));
            largeStore.AddStore(new TextureLoaderStore(new OnlineStore()));
            dependencies.Cache(largeStore);

            dependencies.Cache(this);
            dependencies.Cache(storage);
        }

        public override void SetHost(GameHost host) {
            base.SetHost(host);

            var config = new FrameworkConfigManager(storage);

            config.Set(FrameworkSetting.WindowMode, WindowMode.Windowed);
            config.Set(FrameworkSetting.WindowedSize, new Size(540, 960));

            Window.WindowBorder = WindowBorder.Fixed;
            Window.Title = @"imaima (indev)";

            Window.SetupWindow(config);
        }
    }
}
