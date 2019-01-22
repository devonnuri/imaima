using osu.Framework.Graphics.Textures;
using osu.Framework.Platform;
using System;
using System.IO;
using System.Linq;

namespace imaima.Game.Songs {
    class SongInfoParser {
        public static SongInfo parse(string filepath) {
            SongInfo songInfo = new SongInfo();

            var keys = typeof(SongInfo)
                        .GetProperties()
                        .Select(item => item.Name)
                        .ToArray();

            string parentDirectory = Directory.GetParent(filepath).FullName;

            using (StreamReader reader = File.OpenText(filepath)) {
                string line = "";

                while ((line = reader.ReadLine()) != null) {
                    string[] splited = line.Split(':', 2);

                    if (splited.Length < 2) {
                        continue;
                    }

                    string key = splited[0].Trim();
                    string value = splited[1].Trim();

                    if (Array.IndexOf(keys, key) != -1) {
                        if (key == "AlbumArt") {
                            songInfo.AlbumArt = Texture.FromStream(File.Open(Path.Combine(parentDirectory, value), FileMode.Open));
                        } else if (key == "Audio") {
                            songInfo.Audio = Path.Combine(parentDirectory, value);
                        } else if (key == "AudioPreviewTime") {
                            songInfo.AudioPreviewTime = Convert.ToDouble(value);
                        } else if (key == "Tags") {
                            songInfo.Tags = value.Split(',');
                        } else {
                            songInfo[key] = value;
                        }
                    }
                }
            }

            return songInfo;
        }
    }
}
