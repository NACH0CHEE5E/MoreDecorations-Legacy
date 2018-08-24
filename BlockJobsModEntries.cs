using Pipliz.Mods.APIProvider.Jobs;
using System.IO;

namespace jobentrys
{
    [ModLoader.ModManager]
    public static class jobentrys
    {
        public static string ModGamedataDirectory;

        [ModLoader.ModCallback(ModLoader.EModCallbackType.OnAssemblyLoaded, "nach0.moredecorations.assemblyload")]
        [ModLoader.ModDocumentation("Sets MoreDecorations gamedata directory")]
        public static void OnAssemblyLoaded(string path)
        {
            ModGamedataDirectory = Path.Combine(Path.GetDirectoryName(path), "gamedata/");
        }

        [ModLoader.ModCallback(ModLoader.EModCallbackType.AfterItemTypesDefined, "nach0.moredecorations.registerjobs")]
        [ModLoader.ModCallbackProvidesFor("pipliz.apiprovider.jobs.resolvetypes")]
        [ModLoader.ModDocumentation("Adds all the job block implementations to BlockJobManagerTracker")]
        public static void AfterDefiningNPCTypes()
        {
            BlockJobManagerTracker.Register<Jobs.Nach0SlabMakerJob>("Nach0SlabMaker");
            BlockJobManagerTracker.Register<Jobs.Nach0StairMakerJob>("Nach0StairMaker");
        }
    }
}
