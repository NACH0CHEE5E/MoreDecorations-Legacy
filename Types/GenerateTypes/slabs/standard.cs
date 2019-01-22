using System.Collections.Generic;
using static ItemTypesServer;
using Pipliz.JSON;
using MoreDecorations.Types.GenerateTypes.Config;

namespace MoreDecorations.Types.GenerateTypes.Slabs
{
    [ModLoader.ModManager]
    class Slabs
    {

        [ModLoader.ModCallback(ModLoader.EModCallbackType.AddItemTypes, "Nach0.MoreDecorations.GenerateTypes.slabs")]
        static void generateTypes(Dictionary<string, ItemTypeRaw> types)
        {
            var i = 0;
            var type = "slab";

            while (i < GenerateTypeConfig.standardList.Length)
            {
                var currentType = GenerateTypeConfig.standardList.GetValue(i);
                var typeName = GenerateTypeConfig.typePrefix + type + "." + currentType;

                types.Add(typeName, new ItemTypeRaw(typeName, new JSONNode()
                     .SetAs("categories", new JSONNode(NodeType.Array)
                        .AddToArray(new JSONNode("nach0"))
                        .AddToArray(new JSONNode("moredecorations"))
                        .AddToArray(new JSONNode("decorblocks"))
                        .AddToArray(new JSONNode("slabs"))
                        .AddToArray(new JSONNode("a"))
                        .AddToArray(new JSONNode("standard"))
                        .AddToArray(new JSONNode(currentType))
                     )
                    .SetAs("icon", GenerateTypeConfig.iconPath + type + "/" + currentType + GenerateTypeConfig.iconFileType)
                     .SetAs("maxStackSize", 200)
                     .SetAs("isPlaceable", true)
                     .SetAs("needsBase", false)
                     .SetAs("isRotatable", true)
                     .SetAs("sideall", currentType)
                     .SetAs("rotatablex-", typeName + ".up")
                     .SetAs("rotatablex+", typeName + ".up")
                     .SetAs("rotatablez-", typeName + ".down")
                     .SetAs("rotatablez+", typeName + ".down")));

                types.Add(typeName + ".up", new ItemTypeRaw(typeName + ".up", new JSONNode()
                     .SetAs("parentType", typeName)
                     .SetAs("mesh", GenerateTypeConfig.meshPath + "up" + "." + type + GenerateTypeConfig.meshFileType)
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
                                ))))));

                types.Add(typeName + ".down", new ItemTypeRaw(typeName + ".down", new JSONNode()
                     .SetAs("parentType", typeName)
                     .SetAs("mesh", GenerateTypeConfig.meshPath + "down" + "." + type + GenerateTypeConfig.meshFileType)
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
                                ))))));

                i++;
            }
        }

        [ModLoader.ModCallback(ModLoader.EModCallbackType.AfterStartup, "Nach0.MoreDecorations.GenerateRecipes.slabs")]
        public static void RegisterRecipes()
        {
            var i = 0;
            var type = "slab";
            var jobType = "Slab";

            while (i < GenerateTypeConfig.standardList.Length)
            {
                var currentType = GenerateTypeConfig.standardList.GetValue(i);
                var recipeName = GenerateTypeConfig.name + jobType + "Maker." + currentType;
                var typeName = GenerateTypeConfig.typePrefix + type + "." + currentType;

                List<JSONNode> recipes = new List<JSONNode>();
                recipes.Add(new JSONNode()
                    .SetAs("name", recipeName)
                    .SetAs("defaultLimit", 0)
                    .SetAs("requires", new JSONNode(NodeType.Array)
                        .AddToArray(new JSONNode()
                            .SetAs("amount", 1)
                            .SetAs("type", currentType)
                        )
                    )
                    .SetAs("results", new JSONNode(NodeType.Array)
                        .AddToArray(new JSONNode()
                            .SetAs("amount", 2)
                            .SetAs("type", typeName)
                        )
                    )
                );

                Recipes.RecipeStorage.NPCRecipePatch patch = new Recipes.RecipeStorage.NPCRecipePatch(
                    Recipes.RecipeStorage.ENPCRecipePatchType.AddOrReplace,
                    18000,
                    recipes,
                    "Nach0.Jobs." + jobType + "Maker"
                );
                Recipes.RecipeStorage.QueueLimitsMapping("Nach0.Types." + jobType + "Maker", "Nach0.Jobs." + jobType + "Maker");
                Recipes.RecipeStorage.QueueNPCRecipes(patch);

                i++;
            }
        }
    }
}
