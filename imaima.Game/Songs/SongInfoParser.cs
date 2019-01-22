using osu.Framework.Graphics.Textures;
using System;
using System.IO;
using System.Linq;

namespace imaima.Game.Songs {
    internal static class SongInfoParser {
        public static SongInfo parse(string filepath) {
            SongInfo songInfo = new SongInfo();

            var keys = typeof(SongInfo)
                        .GetProperties()
                        .Select(item => item.Name)
                        .ToArray();

            string parentDirectory = Directory.GetParent(filepath).FullName;

            using (StreamReader reader = File.OpenText(filepath)) {
                string line;

                while ((line = reader.ReadLine()) != null) {
                    var splited = line.Split(':', 2);

                    if (splited.Length < 2) {
                        continue;
                    }

                    var key = splited[0].Trim();
                    var value = splited[1].Trim();

                    if (Array.IndexOf(keys, key) == -1) continue;
                    switch (key) {
                        case "AlbumArt":
                            songInfo.AlbumArt = Texture.FromStream(File.Open(Path.Combine(parentDirectory, value), FileMode.Open));
                            break;
                        case "Audio":
                            songInfo.Audio = Path.Combine(parentDirectory, value);
                            break;
                        case "AudioPreviewTime":
                            songInfo.AudioPreviewTime = Convert.ToDouble(value);
                            break;
                        case "Tags":
                            songInfo.Tags = value.Split(',');
                            break;
                        default:
                            songInfo[key] = value;
                            break;
                    }
                }
            }

            return songInfo;
        }
    }
}
