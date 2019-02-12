namespace imaima.Game.Notes {
    internal class TapNote {
        public byte Position { get; set; }
        public double StartTime { get; set; }
        public double IncomingTime => 600;
    }
}
