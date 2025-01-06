using BSNoCustomMapMarkers.Model;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.Synthesis;
using System.Text;

namespace BSNoCustomMapMarkers.CoMAPGenerator
{
    internal class CoMAPGenerator
    {
        public static void WriteCoMapFile(IPatcherState<ISkyrimMod, ISkyrimModGetter> state, List<CoMAPInfo> coMAPInfos)
        {
            Console.WriteLine("Generate Comap File");

            using (var outputfile = new StreamWriter(Path.Combine(state.DataFolderPath, $"MapMarkers/{state.PatchMod.ModKey.Name}.json"), false, Encoding.UTF8))
            {
                outputfile.WriteLine(@"{");
                outputfile.WriteLine(@"  ""mapMarkers"": [");

                foreach (var comapInfo in coMAPInfos)
                {
                    outputfile.WriteLine("    {");

                    outputfile.Write(@"      ""refID"": """);
                    outputfile.Write(comapInfo.ModName);
                    outputfile.Write("|");
                    outputfile.Write("{0:X}", comapInfo.Id);
                    outputfile.Write(@""" // ");
                    outputfile.Write(comapInfo.MarkerName);
                    outputfile.WriteLine($"(Original Marker: {comapInfo.OriginalMarker})");

                    outputfile.Write(@"      ""iconName"": """);
                    outputfile.Write(comapInfo.IconName);
                    outputfile.WriteLine(@"""");

                    outputfile.WriteLine("    },");
                }

                outputfile.WriteLine("  ]");
                outputfile.WriteLine(@"}");
            }
        }
    }
}
