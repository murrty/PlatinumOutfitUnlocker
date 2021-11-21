using System;
using System.IO;

namespace PlatinumOutfitUnlocker {
    class Program {
        static int Main(string[] args) {
            if (args.Length > 0) {
                for (int i = 0; i < args.Length; i++) {
                    if (File.Exists(args[i])) {
                        File.Copy(args[i], Path.GetDirectoryName(args[i]) + "\\" + Path.GetFileName(args[i]) + ".bak");
                        using (FileStream TIK = new FileStream(args[i], FileMode.Open, FileAccess.Read)) {
                            TIK.Position = 0x1B50;
                            TIK.WriteByte(0x01);
                            TIK.Flush();
                            TIK.Close();
                        }
                        Console.WriteLine(Path.GetFileNameWithoutExtension(args[i]) + " has \"earned\" the platinum outfit.");
                    }
                }
                return 0;
            }
            else {
                Console.WriteLine("Usage: platinumoutfitunlocker.exe <files>...");
                return 1;
            }
        }
    }
}