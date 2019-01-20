using osu.Framework.Graphics.Textures;

namespace imaima.Game.Songs {
    class Song {
        public string title { get; set; }
        public string alphabetTitle { get; set; }
        public string artist { get; set; }
        public string alphabetArtist { get; set; }
        public Texture albumArt { get; set; }
        public string noteDesigner { get; set; }
        public string[] tags { get; set; }
        public string filepath { get; set; }
        public string difficulty { get; set; }
    }
}
