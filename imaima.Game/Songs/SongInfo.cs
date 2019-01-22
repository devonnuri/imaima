using osu.Framework.Graphics.Textures;

namespace imaima.Game.Songs {
    internal class SongInfo {
        public object this[string propertyName] {
            set => typeof(SongInfo).GetProperty(propertyName).SetValue(this, value, null);
        }

        public string Title { get; set; }
        public string AlphabetTitle { get; set; }
        public string Artist { get; set; }
        public string AlphabetArtist { get; set; }
        public Texture AlbumArt { get; set; }
        public string Audio { get; set; }
        public double AudioPreviewTime { get; set; }
        public string NoteDesigner { get; set; }
        public string[] Tags { get; set; }
    }
}
