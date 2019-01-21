using osu.Framework.Graphics.Textures;
using System;
using System.IO;

namespace imaima.Game.Songs {
    class SongInfo {
        public object this[string propertyName] {
            set {
                typeof(SongInfo).GetProperty(propertyName).SetValue(this, value, null);
            }
        }

        public string Title { get; set; }
        public string AlphabetTitle { get; set; }
        public string Artist { get; set; }
        public string AlphabetArtist { get; set; }
        public Texture AlbumArt { get; set; }
        public Stream audio { get; set; }
        public string NoteDesigner { get; set; }
        public string[] Tags { get; set; }
    }
}
