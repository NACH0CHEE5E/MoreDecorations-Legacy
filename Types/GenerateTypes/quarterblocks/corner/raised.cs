using System.Collections.Generic;
using static ItemTypesServer;
using Pipliz.JSON;
using MoreDecorations.Types.GenerateTypes.Config;

namespace MoreDecorations.Types.GenerateTypes.CornerBlocks
{
    [ModLoader.ModManager]
    class RaisedCornerBlocks
    {

        [ModLoader.ModCallback(ModLoader.EModCallbackType.AddItemTypes, "Nach0.MoreDecorations.GenerateTypes.raisedcornerblocks")]
        static void generateTypes(Dictionary<string, ItemTypeRaw> types)
        {
            var i = 0;
            var type = "raisedcornerblock";

            while (i < GenerateTypeConfig.standardList.Length)
            {
                var currentType = GenerateTypeConfig.standardList.GetValue(i);
                var typeName = GenerateTypeConfig.typePrefix + type + "." + currentType;

                types.Add(typeName, new ItemTypeRaw(typeName, new JSONNode()
                     .SetAs("categories", new JSONNode(NodeType.Array)
                        .AddToArray(new JSONNode("nach0"))
                        .AddToArray(new JSONNode("moredecorations"))
                        .AddToArray(new JSONNode("decorblocks"))
                        .AddToArray(new JSONNode("quarterblock"))
                        .AddToArray(new JSONNode("c"))
                        .AddToArray(new JSONNode("cornerblock"))
                        .AddToArray(new JSONNode("b"))
                        .AddToArray(new JSONNode("raised"))
                        .AddToArray(new JSONNode(currentType))
                     )
                    .SetAs("icon", GenerateTypeConfig.iconPath + type + "/" + currentType + GenerateTypeConfig.iconFileType)
                     .SetAs("maxStackSize", 200)
                     .SetAs("isPlaceable", true)
                     .SetAs("needsBase", false)
                     .SetAs("isRotatable", true)
                     .SetAs("sideall", currentType)
                     .SetAs("rotatablex-", typeName + "x-")
                     .SetAs("rotatablex+", typeName + "x+")
                     .SetAs("rotatablez-", typeName + "z-")
                     .SetAs("rotatablez+", typeName + "z+")));

                types.Add(typeName + "x-", new ItemTypeRaw(typeName + "x-", new JSONNode()
                     .SetAs("parentType", typeName)
                     .SetAs("mesh", GenerateTypeConfig.meshPath + type + "x-" + GenerateTypeConfig.meshFileType)
                     .SetAs("customData", new JSONNode()
                        .SetAs("useNormalMap", true)
                        .SetAs("useHeightMap", true))
                     .SetAs("colliders", new JSONNode()
                        .SetAs("boxes", new JSONNode(NodeType.Array)
                            .AddToArray(new JSONNode()
                                .SetAs("max", new JSONNode(NodeType.Array)
                                    .AddToArray(new JSONNode((object)0))
                                    .AddToArray(new JSONNode(0.5))
                                    .AddToArray(new JSONNode(0.5))
                                )
                                .SetAs("min", new JSONNode(NodeType.Array)
                                    .AddToArray(new JSONNode(-0.5))
                                    .AddToArray(new JSONNode((object)0))
                                    .AddToArray(new JSONNode(-0.5))
                                )
                            )
                                                        .AddToArray(new JSONNode()
                                .SetAs("max", new JSONNode(NodeType.Array)
                                    .AddToArray(new JSONNode(0.5))
                                    .AddToArray(new JSONNode(0.5))
                                    .AddToArray(new JSONNode(0.5))
                                )
                                .SetAs("min", new JSONNode(NodeType.Array)
                                    .AddToArray(new JSONNode((object)0))
                                    .AddToArray(new JSONNode((object)0))
                                    .AddToArray(new JSONNode((object)0))
                                )
                            )))));

                types.Add(typeName + "x+", new ItemTypeRaw(typeName + "x+", new JSONNode()
                    .SetAs("parentType", typeName)
                    .SetAs("mesh", GenerateTypeConfig.meshPath + type + "x+" + GenerateTypeConfig.meshFileType)
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
                                    .AddToArray(new JSONNode((object)0))
                                    .AddToArray(new JSONNode((object)0))
                                    .AddToArray(new JSONNode(-0.5))
                                )
                                )
                                .AddToArray(new JSONNode()
                                .SetAs("max", new JSONNode(NodeType.Array)
                                    .AddToArray(new JSONNode((object)0))
                                    .AddToArray(new JSONNode(0.5))
                                    .AddToArray(new JSONNode((object)0))
                                )
                                .SetAs("min", new JSONNode(NodeType.Array)
                                    .AddToArray(new JSONNode(-0.5))
                                    .AddToArray(new JSONNode((object)0))
                                    .AddToArray(new JSONNode(-0.5))
                                )
                            )))));

                types.Add(typeName + "z-", new ItemTypeRaw(typeName + "z-", new JSONNode()
                    .SetAs("parentType", typeName)
                    .SetAs("mesh", GenerateTypeConfig.meshPath + type + "z-" + GenerateTypeConfig.meshFileType)
                    .SetAs("customData", new JSONNode()
                        .SetAs("useNormalMap", true)
                        .SetAs("useHeightMap", true))
                   .SetAs("colliders", new JSONNode()
                        .SetAs("boxes", new JSONNode(NodeType.Array)
                            .AddToArray(new JSONNode()
                                .SetAs("max", new JSONNode(NodeType.Array)
                                    .AddToArray(new JSONNode(0.5))
                                    .AddToArray(new JSONNode(0.5))
                                    .AddToArray(new JSONNode((object)0))
                                )
                                .SetAs("min", new JSONNode(NodeType.Array)
                                    .AddToArray(new JSONNode(-0.5))
                                    .AddToArray(new JSONNode((object)0))
                                    .AddToArray(new JSONNode(-0.5))
                                )
                            )
                                                        .AddToArray(new JSONNode()
                                .SetAs("max", new JSONNode(NodeType.Array)
                                    .AddToArray(new JSONNode((object)0))
                                    .AddToArray(new JSONNode(0.5))
                                    .AddToArray(new JSONNode(0.5))
                                )
                                .SetAs("min", new JSONNode(NodeType.Array)
                                    .AddToArray(new JSONNode(-0.5))
                                    .AddToArray(new JSONNode((object)0))
                                    .AddToArray(new JSONNode((object)0))
                                )
                            )))));

                types.Add(typeName + "z+", new ItemTypeRaw(typeName + "z+", new JSONNode()
                    .SetAs("parentType", typeName)
                    .SetAs("mesh", GenerateTypeConfig.meshPath + type + "z+" + GenerateTypeConfig.meshFileType)
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
                                    .AddToArray(new JSONNode((object)0))
                                )
                            )
                            .AddToArray(new JSONNode()
                                .SetAs("max", new JSONNode(NodeType.Array)
                                    .AddToArray(new JSONNode(0.5))
                                    .AddToArray(new JSONNode(0.5))
                                    .AddToArray(new JSONNode((object)0))
                                )
                                .SetAs("min", new JSONNode(NodeType.Array)
                                    .AddToArray(new JSONNode((object)0))
                                    .AddToArray(new JSONNode((object)0))
                                    .AddToArray(new JSONNode(-0.5))
                                )
                            )))));

                i++;
            }
        }

        [ModLoader.ModCallback(ModLoader.EModCallbackType.AfterStartup, "Nach0.MoreDecorations.GenerateRecipes.raisedcornerblocks")]
        public static void RegisterRecipes()
        {
            var i = 0;
            var type = "raisedcornerblock";
            var jobType = "RaisedCornerBlock";
            var typeRequired = "cornerblock";

            while (i < GenerateTypeConfig.tiledList.Length)
            {
                var currentType = GenerateTypeConfig.tiledList.GetValue(i);
                var recipeName = GenerateTypeConfig.name + jobType + "Maker." + currentType;
                var typeName = GenerateTypeConfig.typePrefix + type + "." + currentType;
                var typeRequiredName = GenerateTypeConfig.typePrefix + typeRequired + "." + currentType;

                List<JSONNode> recipes = new List<JSONNode>();
                recipes.Add(new JSONNode()
                    .SetAs("name", recipeName)
                    .SetAs("defaultLimit", 0)
                    .SetAs("requires", new JSONNode(NodeType.Array)
                        .AddToArray(new JSONNode()
                            .SetAs("amount", 1)
                            .SetAs("type", typeRequiredName)
                        )
                    )
                    .SetAs("results", new JSONNode(NodeType.Array)
                        .AddToArray(new JSONNode()
                            .SetAs("amount", 1)
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
