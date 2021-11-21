using System;
using System.IO;

namespace PlatinumOutfitUnlocker {
    class Program {
        static int Main(string[] args) {
            Console.WriteLine("PlatinumOutfitUnlocker v1.0");
            Console.WriteLine("You can thank theSLAYER on ProjectPokemon.org for finding the right address for this :)");
            if (args.Length > 0) {
                for (int i = 0; i < args.Length; i++) {
                    if (File.Exists(args[i])) {
                        if (File.Exists(args[i] + ".bak"))
                            File.Delete(args[i] + ".bak");
                        File.Copy(args[i], args[i] + ".bak");
                        using (FileStream TIK = new FileStream(args[i], FileMode.Open, FileAccess.ReadWrite)) {
                            TIK.Position = 0x1B54;
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