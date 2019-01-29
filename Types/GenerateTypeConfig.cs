using Newtonsoft.Json;
using Pipliz.JSON;

namespace NACH0.Decor.GenerateTypes.Config
{
    class GenerateTypeConfig
    {
        public const string name = "NACH0";
        public const string modName = "Decor";
        public const string modNameSpace = name + "." + modName + ".";

        public const string generateTypesPrefix = modNameSpace + "GenerateTypes.";
        public const string generateRecipesPrefix = modNameSpace + "GenerateRecipes";

        public const string modFilePath = "./gamedata/mods/" + name + "/" + modName;
        public const string modGamedataPath = modFilePath + "/gamedata";
        public const string modMeshPath = modGamedataPath + "/meshes";
        public const string modIconPath = modGamedataPath + "/textures/icons";

        public const string typePrefix = name + ".Types";

        public const string meshType = ".ply";
        public const string iconType = ".png";
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
