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
using Decor.Models;

namespace Nach0.Decor.GenerateTypes.Stairs
{
    public class LocalGenerateConfig
    {
        public const string NAME = "Stairs";
    }

    public class TypeParent : CSType
    {
        public override List<string> categories { get; set; } = new List<string>()
        {
            GenerateTypeConfig.NAME, GenerateTypeConfig.MODNAME, LocalGenerateConfig.NAME, "b"
        };

        public override int? maxStackSize => 500;
        public override bool? isPlaceable => true;
        public override bool? needsBase => false;
        public override bool? isRotatable => true;
        public override JSONNode customData { get; set; } = new JSONNode().SetAs("useNormalMap", true).SetAs("useHeightMap", true);
    }

    public class TypeXP : CSType
    {
        public override string mesh { get; set; } = GenerateTypeConfig.MOD_MESH_PATH + Type.NAME + ".xp" + GenerateTypeConfig.MESHTYPE;
        public override Colliders colliders { get; set; } = new Colliders()
        {
            boxes = new List<Colliders.Boxes>()
            {
                new Colliders.Boxes(new List<float>(){ 0.5f, -0.25f, 0.5f }, new List<float>(){ -0.5f, -0.5f, -0.5f }),
                new Colliders.Boxes(new List<float>(){ 0.5f, 0f, 0.5f }, new List<float>(){ -0.25f, -0.25f, -0.5f }),
                new Colliders.Boxes(new List<float>(){ 0.5f, 0.25f, 0.5f }, new List<float>(){ 0f, 0f, -0.5f }),
                new Colliders.Boxes(new List<float>(){ 0.5f, 0.5f, 0.5f }, new List<float>(){ 0.25f, 0.25f, -0.5f })
            }
        };
    }

    public class TypeXM : CSType
    {
        public override string mesh { get; set; } = GenerateTypeConfig.MOD_MESH_PATH + Type.NAME + ".xm" + GenerateTypeConfig.MESHTYPE;
        public override Colliders colliders { get; set; } = new Colliders()
        {
            boxes = new List<Colliders.Boxes>()
            {
                new Colliders.Boxes(new List<float>(){ 0.5f, -0.25f, 0.5f }, new List<float>(){ -0.5f, -0.5f, -0.5f }),
                new Colliders.Boxes(new List<float>(){ 0.25f, 0f, 0.5f }, new List<float>(){ -0.5f, -0.25f, -0.5f }),
                new Colliders.Boxes(new List<float>(){ 0f, 0.25f, 0.5f }, new List<float>(){ -0.5f, 0f, -0.5f }),
                new Colliders.Boxes(new List<float>(){ -0.25f, 0.5f, 0.5f }, new List<float>(){ -0.5f, 0.25f, -0.5f })
            }
        };

    }

    public class TypeZP : CSType
    {
        public override string mesh { get; set; } = GenerateTypeConfig.MOD_MESH_PATH + Type.NAME + ".zp" + GenerateTypeConfig.MESHTYPE;
        public override Colliders colliders { get; set; } = new Colliders()
        {
            boxes = new List<Colliders.Boxes>()
            {
                new Colliders.Boxes(new List<float>(){ 0.5f, -0.25f, 0.5f }, new List<float>(){ -0.5f, -0.5f, -0.5f }),
                new Colliders.Boxes(new List<float>(){ 0.5f, 0f, 0.5f }, new List<float>(){ -0.25f, -0.25f, -0.5f }),
                new Colliders.Boxes(new List<float>(){ 0.5f, 0.25f, 0.5f }, new List<float>(){ 0f, 0f, -0.5f }),
                new Colliders.Boxes(new List<float>(){ 0.5f, 0.5f, 0.5f }, new List<float>(){ 0.25f, 0.25f, -0.5f })
            }
        };

    }

    public class TypeZM : CSType
    {
        public override string mesh { get; set; } = GenerateTypeConfig.MOD_MESH_PATH + Type.NAME + ".xm" + GenerateTypeConfig.MESHTYPE;
        public override Colliders colliders { get; set; } = new Colliders()
        {
            boxes = new List<Colliders.Boxes>()
            {
                new Colliders.Boxes(new List<float>(){ 0.5f, 0.5f, 0f }, new List<float>(){ -0.5f, -0.5f, -0.5f }),
                new Colliders.Boxes(new List<float>(){ 0.5f, 0f, 0.5f }, new List<float>(){ -0.25f, -0.25f, -0.5f }),
                new Colliders.Boxes(new List<float>(){ 0.5f, 0.25f, 0.5f }, new List<float>(){ 0f, 0f, -0.5f }),
                new Colliders.Boxes(new List<float>(){ 0.5f, 0.5f, 0.5f }, new List<float>(){ 0.25f, 0.25f, -0.5f })
            }
        };

    }

    public class TypeRecipe : ICSRecipe
    {
        public string name { get; set; } = GenerateTypeConfig.TYPEPREFIX + Type.NAME;

        public List<RecipeItem> requires { get; set; } = new List<RecipeItem>();

        public List<RecipeItem> results { get; set; } = new List<RecipeItem>();

        public CraftPriority defaultPriority { get; set; } = CraftPriority.Medium;

        public bool isOptional { get; set; } = false;

        public int defaultLimit { get; set; } = 0;

        public string Job { get; set; } = GenerateTypeConfig.NAME + ".Jobs." + LocalGenerateConfig.NAME + "Maker";
    }



    [ModLoader.ModManager]
    public class Type
    {
        public const string NAME = LocalGenerateConfig.NAME;
        public const string GENERATE_TYPES_NAME = GenerateTypeConfig.GENERATE_TYPES_PREFIX + NAME;
        public const string GENERATE_RECIPES_NAME = GenerateTypeConfig.GENERATE_RECIPES_PREFIX + NAME;

        [ModLoader.ModCallback(ModLoader.EModCallbackType.AddItemTypes, GENERATE_TYPES_NAME)]
        public static void generateTypes(Dictionary<string, ItemTypeRaw> types)
        {
            ServerLog.LogAsyncMessage(new LogMessage("Begining " + NAME + " generation", LogType.Log));

            if (GenerateTypeConfig.DecorTypes.TryGetValue(NAME, out List<DecorType> blockTypes))
                foreach (var currentType in blockTypes)
                {
                    //ServerLog.LogAsyncMessage(new LogMessage("Found parent " + currentType.type, LogType.Log));
                    //ServerLog.LogAsyncMessage(new LogMessage("Found texture " + currentType.texture, LogType.Log));
                    var typeName = GenerateTypeConfig.TYPEPREFIX + NAME + "." + currentType.type;

                    ServerLog.LogAsyncMessage(new LogMessage("Generating type " + typeName, LogType.Log));

                    var baseType = new TypeParent();
                    baseType.categories.Add(currentType.type);
                    baseType.name = typeName;
                    baseType.sideall = currentType.texture;
                    baseType.rotatablexn = typeName + "x+";
                    baseType.rotatablexp = typeName + "x-";
                    baseType.rotatablezn = typeName + "z+";
                    baseType.rotatablezp = typeName + "z-";

                    var typeXP = new TypeXP();
                    typeXP.name = typeName + "x+";
                    typeXP.parentType = typeName;

                    var typeXM = new TypeXM();
                    typeXM.name = typeName + "x-";
                    typeXM.parentType = typeName;

                    var typeZP = new TypeXM();
                    typeZP.name = typeName + "z+";
                    typeZP.parentType = typeName;

                    var typeZM = new TypeXM();
                    typeZM.name = typeName + "z-";
                    typeZM.parentType = typeName;


                    types.Add(typeName, new ItemTypeRaw(typeName, baseType.JsonSerialize()));
                    types.Add(typeName + "x+", new ItemTypeRaw(typeName + "x+", typeXP.JsonSerialize()));
                    types.Add(typeName + "x-", new ItemTypeRaw(typeName + "x-", typeXM.JsonSerialize()));
                    types.Add(typeName + "z+", new ItemTypeRaw(typeName + "z+", typeZP.JsonSerialize()));
                    types.Add(typeName + "z-", new ItemTypeRaw(typeName + "z-", typeZM.JsonSerialize()));
                }
        }

        [ModLoader.ModCallback(ModLoader.EModCallbackType.AfterWorldLoad, GENERATE_RECIPES_NAME)]
        public static void generateRecipes()
        {
            if (GenerateTypeConfig.DecorTypes.TryGetValue(LocalGenerateConfig.NAME, out List<DecorType> blockTypes))
                foreach (var currentType in blockTypes)
                {
                    var typeName = GenerateTypeConfig.TYPEPREFIX + NAME + "." + currentType.type;
                    var typeNameRecipe = GenerateTypeConfig.TYPEPREFIX + NAME + "." + currentType.type + ".Recipe";

                    ServerLog.LogAsyncMessage(new LogMessage("Generating type " + typeNameRecipe, LogType.Log));

                    var recipe = new TypeRecipe();
                    recipe.name = typeNameRecipe;
                    recipe.requires.Add(new RecipeItem(currentType.type));
                    recipe.results.Add(new RecipeItem(typeName));


                    recipe.LoadRecipe();
                }
        }
    }
}