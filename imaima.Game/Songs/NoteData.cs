using imaima.Game.Notes;
using System;
using System.Collections.Generic;
using System.IO;

namespace imaima.Game.Songs {
    internal class NoteData {
        public Dictionary<double, List<TapNote>> SyncedNotes = new Dictionary<double, List<TapNote>>();

        public static NoteData Parse(Difficulty difficulty) {
            NoteData noteData = new NoteData();

            using (var reader = File.OpenText(difficulty.Filename)) {
                string line;
                double prevTime = -1;

                List<TapNote> syncedNote = new List<TapNote>();

                while ((line = reader.ReadLine()) != null) {
                    string[] args = line.Split("/");
                    
                    double startTime = double.Parse(args[0]);
                    byte position = byte.Parse(args[2]);

                    switch (args[1]) {
                        case "0":
                            syncedNote.Add(new TapNote {
                                StartTime = startTime,
                                Position = position
                            });
                            break;
                        case "1":
                            syncedNote.Add(new HoldNote {
                                StartTime = startTime,
                                EndTime = double.Parse(args[3]),
                                Position = position
                            });
                            break;
                        case "2":
                            syncedNote.Add(new BreakNote {
                                StartTime = startTime,
                                Position = position
                            });
                            break;
                        default:
                            throw new ArgumentOutOfRangeException("Incorrect Note Type", args[1], null);
                    }

                    if (prevTime != startTime) {
                        noteData.SyncedNotes.Add(startTime, syncedNote);
                        syncedNote = new List<TapNote>();
                    }

                    prevTime = startTime;
                }
            }
            
            return null;
        }
    }
}
