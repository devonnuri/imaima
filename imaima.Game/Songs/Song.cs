using osu.Framework.Graphics.Textures;
using System;
using System.Collections.Generic;
using System.IO;

namespace imaima.Game.Songs {
    internal class Song {
        public SongInfo Info { get; set; }
        public List<Difficulty> Difficulties { get; set; }

        public static Song Parse(string filepath) {
            var song = new Song();
            var songInfo = new SongInfo();

            var parentDirectory = Directory.GetParent(filepath).FullName;

            using (var reader = File.OpenText(filepath)) {
                string line;

                while ((line = reader.ReadLine()) != null) {
                    var splited = line.Split(':', 2);

                    if (splited.Length < 2) {
                        continue;
                    }

                    var key = splited[0].Trim();
                    var value = splited[1].Trim();

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
                        case "Difficulty":
                            song.Difficulties = new List<Difficulty>();
                            var diffStr = value.Split(',');
                            foreach (var diffParamStr in diffStr) {
                                var diffParam = diffParamStr.Split(':');
                                song.Difficulties.Add(new Difficulty {
                                    Level = diffParam[0],
                                    Name = diffParam[1],
                                    Filename = diffParam[2]
                                });
                            }
                            break;
                        default:
                            songInfo[key] = value;
                            break;
                    }
                }
            }

            song.Info = songInfo;

            return song;
        }
    }
}
