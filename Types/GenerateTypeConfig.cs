
namespace MoreDecorations.Types.GenerateTypes.Config
{
    class GenerateTypeConfig
    {
        public static string name = "NACH0";
        public static string modName = "Decor";
        public static string modNameSpace = name + "." + modName + ".";

        public static string generateTypesPrefix = modNameSpace + "GenerateTypes.";
        public static string generateRecipesPrefix = modNameSpace + "GenerateRecipes";

        public static string modFilePath = "./gamedata/mods/" + name + "/" + modName;
        public static string modGamedataPath = modFilePath + "/gamedata";
        public static string modMeshPath = modGamedataPath + "/meshes";
        public static string modIconPath = modGamedataPath + "/textures/icons";

        public static string typePrefix = name + ".Types";
        
        public static string meshType = ".ply";
        public static string iconType = ".png";
    }
}
