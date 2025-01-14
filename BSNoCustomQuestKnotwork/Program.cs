using Mutagen.Bethesda;
using Mutagen.Bethesda.Synthesis;
using Mutagen.Bethesda.Skyrim;

namespace BSNoCustomQuestKnotwork
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            return await SynthesisPipeline.Instance
                .AddPatch<ISkyrimMod, ISkyrimModGetter>(RunPatch)
                .SetTypicalOpen(GameRelease.SkyrimSE, "BSNoCustomQuestKnotwork.esp")
                .Run(args);
        }

        public static void RunPatch(IPatcherState<ISkyrimMod, ISkyrimModGetter> state)
        {
            Console.WriteLine(">>>Patch Beyond Skyrim - No Custom Quest Knotwork");

            int counter = 0;

            var customTypeQuests = state.LoadOrder.PriorityOrder.Quest()
                .WinningContextOverrides().Where(q => q.Record.Type > Quest.TypeEnum.Dragonborn);

            foreach (var customTypeQuest in customTypeQuests)
            {
                IQuest copiedQuest = customTypeQuest.GetOrAddAsOverride(state.PatchMod);

                copiedQuest.Type = Quest.TypeEnum.SideQuest;
                counter++;
            }

            Console.WriteLine($"Processed {counter} quests");
        }
    }
}
