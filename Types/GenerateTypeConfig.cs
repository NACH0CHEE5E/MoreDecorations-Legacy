
namespace MoreDecorations.Types.GenerateTypes.Config
{
    class GenerateTypeConfig
    {
        public static string name = "Nach0.";
        static string modFilePath = "./gamedata/mods/NACH0/MoreDecorations";
        public static string typePrefix = name + "Types.";
        public static string[] nonTiledList = {"crate", "cratebread", "ironblock" };
        public static string[] tiledList = { "adobe", "berrybush", "blackplanks", "bricks", "cherryblossom", "clay", "coatedplanks", "dirt", "darkstone", "leavestaiga", "leavestemperate", "logtemperate", "logtaiga", "planks", "plasterblock", "redplanks", "sand", "snow", "stoneblock", "stonebricks", "straw" };
        public static string[] standardList = { "adobe", "berrybush", "blackplanks", "bricks", "cherryblossom", "clay", "coatedplanks", "dirt", "darkstone", "leavestaiga", "leavestemperate", "logtemperate", "logtaiga", "planks", "plasterblock", "redplanks", "sand", "snow", "stoneblock", "stonebricks", "straw", "crate", "cratebread", "ironblock" };
        public static string iconPath = modFilePath + "/gamedata/textures/icons/";
        public static string iconFileType = ".png";
        public static string meshPath = modFilePath + "/gamedata/meshes/";
        public static string meshFileType = ".obj";
        public static string meshFileType2 = ".ply";
        public static string modNamespace = name + "MoreDecorations.";
    }
}
