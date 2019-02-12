using imaima.Game.Notes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace imaima.Game.Songs {
    internal class NoteData {
        public Dictionary<double, List<TapNote>> SyncedNotes { get; private set; }
        public int NoteCount { get; private set; }

        public override string ToString() {
            StringBuilder builder = new StringBuilder();

            foreach (var pair in SyncedNotes) {
                builder.Append(pair.Key + " : ");
                builder.AppendLine(
                    pair.Value
                    .Select(note => "Tap@" + note.Position)
                    .Aggregate((a, b) => a + ", " + b)
                );
            }

            return builder.ToString();
        }

        public static NoteData Parse(Difficulty difficulty) {
            NoteData noteData = new NoteData {
                SyncedNotes = new Dictionary<double, List<TapNote>>()
            };
            noteData.NoteCount = 0;

            using (var reader = File.OpenText(difficulty.Filename)) {
                string line;
                double prevTime = -1;

                List<TapNote> syncedNote = new List<TapNote>();

                while ((line = reader.ReadLine()) != null) {
                    string[] args = line.Split("/");
                    
                    double startTime = double.Parse(args[0]);
                    byte position = byte.Parse(args[2]);

                    if (prevTime > 0 && prevTime != startTime) {
                        noteData.SyncedNotes.Add(prevTime, syncedNote);
                        syncedNote = new List<TapNote>();
                    }

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
                            throw new ArgumentOutOfRangeException("args[1]", args[1], "Incorrect Note Type");
                    }

                    prevTime = startTime;

                    noteData.NoteCount++;
                }

                noteData.SyncedNotes.Add(prevTime, syncedNote);
            }
            
            return noteData;
        }
    }
}
