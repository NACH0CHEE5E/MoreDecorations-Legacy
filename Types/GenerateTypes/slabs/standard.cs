using System.Collections.Generic;
using static ItemTypesServer;
using Pipliz.JSON;
using Newtonsoft.Json;
using AI;
using Jobs;
using NPC;
using Pipliz;
using System;
using System.Linq;
using System.Reflection;
using Random = System.Random;
using MoreDecorations.Models;
using System.IO;
using NACH0.Decor.GenerateTypes.Config;
using UnityEngine;

namespace Nach0.Decor.GenerateTypes.Slab
{
    /*public class SlabParent : CSType
    {
        public override string categories[] { get; set; } = ["NACH0", "Decor", "Slab", "b", currentType];
        public override int maxStackSize { get; set; } = 500;
        public override bool isPlaceable { get; set; } = true;
        public override bool needsBase { get; set; } = false;
        public override bool isRotatable { get; set; } = true;
    }

    public class SlabDowm : CSType
    {
        //public override string meshUp { get; set; } = GenerateTypeConfig.modMeshPath + "up" + "." + type + GenerateTypeConfig.meshType;
        //public override string meshDown { get; set; } = GenerateTypeConfig.modMeshPath + "down" + "." + type + GenerateTypeConfig.meshType;
        //more properties
        //public override string parentType { get; set; } = GenerateTypeConfig.typePrefix + type + "." + currentType;
        public override string mesh { get; set; } = GenerateTypeConfig.modMeshPath + "down" + "." + Slab.type + GenerateTypeConfig.meshType;
        
    }*/

    [ModLoader.ModManager]
    class Slab
    {
        public const string type = "Slab";
        public const string generateTypesName = GenerateTypeConfig.generateRecipesPrefix + "." + type;

        [ModLoader.ModCallback(ModLoader.EModCallbackType.AddItemTypes, generateTypesName)]
        public static void generateTypes(Dictionary<string, ItemTypeRaw> types)
        {
            ServerLog.LogAsyncMessage(new LogMessage("Begining slab generation", LogType.Log));
            var i = 0;
            var file = File.ReadAllText(GenerateTypeConfig.modGamedataPath + "/DecorTypes.json");
            var dic = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(file);

            ServerLog.LogAsyncMessage(new LogMessage(GenerateTypeConfig.modGamedataPath + "/DecorTypes.json", LogType.Log));

            if (dic.TryGetValue("Slab", out List<string> slabTypes))
                //ServerLog.print("Found Slab in JSON");
                ServerLog.LogAsyncMessage(new LogMessage("Found Slab in JSON", LogType.Log));
                foreach (var currentType in slabTypes)
                {
                    ServerLog.print(currentType);
                    /*var newSlabType = new SlabParent();
                    newSlabType.sideall = slabType;
                    newSlabType.rotatablex- = 

                    //var newSlabDown = new SlabDown();

                    //add item type
                    var json = newSlabType.JsonSerialize();*/

                    //types.ContainsKey(currentType, new ItemTypeRaw("sideall", new ItemTypeRaw texture));

                    var typeName = GenerateTypeConfig.typePrefix + type + "." + currentType;

                    var textureName = currentType;

                    //var textureName = TypeAttributes()

                    types.Add(typeName, new ItemTypeRaw(typeName, new JSONNode()
                        .SetAs("categories", new JSONNode(NodeType.Array)
                            .AddToArray(new JSONNode("NACH0"))
                            .AddToArray(new JSONNode("Decor"))
                            .AddToArray(new JSONNode(type))
                            .AddToArray(new JSONNode("b"))
                            .AddToArray(new JSONNode(currentType))
                        )
                        .SetAs("maxStackSize", 500)
                        .SetAs("isPlaceable", true)
                        .SetAs("needsBase", false)
                        .SetAs("isRotatable", true)
                        .SetAs("sideall", textureName)
                        .SetAs("rotatablex-", typeName + ".up")
                        .SetAs("rotatablex+", typeName + ".up")
                        .SetAs("rotatablez-", typeName + ".down")
                        .SetAs("rotatablez+", typeName + ".down")));

                    types.Add(typeName + ".up", new ItemTypeRaw(typeName + ".up", new JSONNode()
                        .SetAs("parentType", typeName)
                        .SetAs("mesh", GenerateTypeConfig.modMeshPath + type + "." + "up" + GenerateTypeConfig.meshType)
                        .SetAs("customData", new JSONNode()
                            .SetAs("useNormalMap", true)
                            .SetAs("useHeightMap", true))
                        .SetAs("colliders", new JSONNode()
                            .SetAs("boxes", new JSONNode(NodeType.Array)
                                .AddToArray(new JSONNode()
                                    .SetAs("max", new JSONNode(NodeType.Array)
                                        .AddToArray(new JSONNode(0.5))
                                        .AddToArray(new JSONNode(0.5))
                                        .AddToArray(new JSONNode(0.5))
                                    )
                                    .SetAs("min", new JSONNode(NodeType.Array)
                                        .AddToArray(new JSONNode(-0.5))
                                        .AddToArray(new JSONNode((object)0))
                                        .AddToArray(new JSONNode(-0.5))
                                    )
                                )
                            )
                        )
                    ));

                    types.Add(typeName + ".down", new ItemTypeRaw(typeName + ".down", new JSONNode()
                        .SetAs("parentType", typeName)
                        .SetAs("mesh", GenerateTypeConfig.modMeshPath + type + "." + "down" + GenerateTypeConfig.meshType)
                        .SetAs("customData", new JSONNode()
                            .SetAs("useNormalMap", true)
                            .SetAs("useHeightMap", true))
                        .SetAs("colliders", new JSONNode()
                            .SetAs("boxes", new JSONNode(NodeType.Array)
                                .AddToArray(new JSONNode()
                                    .SetAs("max", new JSONNode(NodeType.Array)
                                        .AddToArray(new JSONNode(0.5))
                                        .AddToArray(new JSONNode((object)0))
                                        .AddToArray(new JSONNode(0.5))
                                    )
                                    .SetAs("min", new JSONNode(NodeType.Array)
                                        .AddToArray(new JSONNode(-0.5))
                                        .AddToArray(new JSONNode(-0.5))
                                        .AddToArray(new JSONNode(-0.5))
                                    )
                                )
                            )
                        )
                    ));
                }
        }

        /*[ModLoader.ModCallback(ModLoader.EModCallbackType.AfterStartup, GenerateTypeConfig.generateRecipesPrefix + type)]
        public static void generateRecipes()
        {
            var i = 0;
        }*/
    }
}