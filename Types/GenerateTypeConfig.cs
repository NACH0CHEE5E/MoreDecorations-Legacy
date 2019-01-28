using Newtonsoft.Json;
using Pipliz.JSON;

namespace NACH0.Decor.GenerateTypes.Config
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

    public static class ExtentionMethods
    {
        public static JSONNode JsonSerialize<T>(this T obj)
        {
            var objStr = JsonConvert.SerializeObject(obj, Formatting.None, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            return JSON.DeserializeString(objStr);
        }

        public static T JsonDeerialize<T>(this JSONNode node)
        {
            return JsonConvert.DeserializeObject<T>(node.ToString(), new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
