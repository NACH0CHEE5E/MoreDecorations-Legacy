using System.Collections.Generic;
using static ItemTypesServer;
using Pipliz.JSON;
using MoreDecorations.Types.GenerateTypes.Config;
using Newtonsoft.Json;
using AI;
using Jobs;
using Newtonsoft.Json;
using NPC;
using Pipliz;
using Pipliz.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Random = System.Random;

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
            {
                var objStr = JsonConvert.SerializeObject(obj, Formatting.None, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
                return JSON.DeserializeString(objStr);
            }

            public static T JsonDeerialize<T>(this JSONNode node)
            {
                return JsonConvert.DeserializeObject<T>(node.ToString(), new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            }
        }

        [ModLoader.ModCallback(ModLoader.EModCallbackType.AfterStartup, GenerateTypeConfig.generateRecipesPrefix + type)]
        public static void generateRecipes()
        {
            var i = 0;
        }
    }
}