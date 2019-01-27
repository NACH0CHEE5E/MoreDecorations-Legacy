using System.Collections.Generic;
using static ItemTypesServer;
using Pipliz.JSON;
using MoreDecorations.Types.GenerateTypes.Config;

namespace Nach0.Decor.GenerateTypes.Slab
{
    [ModLoader.ModManager]
    class Slab
    {
        public static string type = "Slab";

        [ModLoader.ModCallback(ModLoader.EModCallbackType.AddItemTypes, GenerateTypeConfig.generateTypesPrefix + type)]
        static void generateTypes(Dictionary<string, ItemTypeRaw> types)
        {
            var i = 0;
            public static JSONNode JsonSerialize<T>(this T obj)
            //public static string[] typeList = JSON.Deserialize(GenerateTypeConfig.modGamedataPath);
        }

        [ModLoader.ModCallback(ModLoader.EModCallbackType.AfterStartup, GenerateTypeConfig.generateRecipesPrefix + type)]
        public static void generateRecipes()
        {
            var i = 0;
        }
    }
}