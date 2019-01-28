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
using MoreDecorations.Models;
using System.IO;

namespace Nach0.Decor.GenerateTypes.Slab
{
    public class SlabBase : CSType
    {
        //public override string meshUp { get; set; } = GenerateTypeConfig.modMeshPath + "up" + "." + type + GenerateTypeConfig.meshType;
        //public override string meshDown { get; set; } = GenerateTypeConfig.modMeshPath + "down" + "." + type + GenerateTypeConfig.meshType;
        //more properties
        public override string mesh { get; set; } = GenerateTypeConfig.modMeshPath + "down" + "." + Slab.type + GenerateTypeConfig.meshType;
    }

    [ModLoader.ModManager]
    class Slab
    {
        public const string type = "Slab";

        [ModLoader.ModCallback(ModLoader.EModCallbackType.AddItemTypes, type)]
        public static void generateTypes(Dictionary<string, ItemTypeRaw> types)
        {
            var i = 0;
            var file = File.ReadAllText("DecorTypes.json");
            var dic = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(file);

            if (dic.TryGetValue("Slab", out List<string> slabTypes))
                foreach (var slabType in slabTypes)
                {
                    var newSlabType = new SlabBase();
                    newSlabType.sideall = slabType;

                    //add item type
                    var json = newSlabType.JsonSerialize();
                }
        }

        [ModLoader.ModCallback(ModLoader.EModCallbackType.AfterStartup, GenerateTypeConfig.generateRecipesPrefix + type)]
        public static void generateRecipes()
        {
            var i = 0;
        }
    }
}