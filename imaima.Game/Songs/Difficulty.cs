using osuTK.Graphics;

namespace imaima.Game.Songs {
    internal class Difficulty {
        public string Level { get; set; }
        public string Name { get; set; }
        public string Filename { get; set; }

        public Color4 Color {
            get {
                switch (Name) {
                    case "Easy":
                        return new Color4(41, 128, 185, 255);
                    case "Basic":
                        return new Color4(39, 174, 96, 255);
                    case "Advanced":
                        return new Color4(243, 156, 18, 255);
                    case "Expert":
                        return new Color4(192, 57, 43, 255);
                    case "Master":
                        return new Color4(142, 68, 173, 255);
                    case "Re:Master":
                        return new Color4(155, 89, 182, 255);
                    default:
                        return new Color4(44, 62, 80, 255);
                }
            }
        }
    }
}