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
    public class SlabParent : CSType
    {
        public override List<string> categories { get; set; } = new List<string>()
        {
            GenerateTypeConfig.NAME, GenerateTypeConfig.MODNAME, "Slab", "b"
        };

        public override string mesh { get; set; } = GenerateTypeConfig.MOD_MESH_PATH + Slab.NAME + ".up" + GenerateTypeConfig.MESHTYPE;
        public override int? maxStackSize => 500;
        public override bool? isPlaceable => true;
        public override bool? needsBase => false;
        public override bool? isRotatable => true;
        public override JSONNode customData { get; set; } = new JSONNode().SetAs("useNormalMap", true).SetAs("useHeightMap", true);
        public override Colliders colliders { get; set; } = new Colliders()
        {
            boxes = new List<Colliders.Boxes>()
            {
                new Colliders.Boxes(new List<float>(){ -0.5f, 0f, -0.5f }, new List<float>(){ 0.5f, 0.5f, 0.5f })
            }
        };
    }

    public class SlabUp : CSType
    {
        public override string mesh { get; set; } = GenerateTypeConfig.MOD_MESH_PATH + Slab.NAME + ".up" + GenerateTypeConfig.MESHTYPE;
        public override Colliders colliders { get; set; } = new Colliders()
        {
            boxes = new List<Colliders.Boxes>()
            {
                new Colliders.Boxes(new List<float>(){ -0.5f, 0f, -0.5f }, new List<float>(){ 0.5f, 0.5f, 0.5f })
            }
        };
    }

    public class SlabDown : CSType
    {
        public override string mesh { get; set; } = GenerateTypeConfig.MOD_MESH_PATH + Slab.NAME + ".down" + GenerateTypeConfig.MESHTYPE;
        public override Colliders colliders { get; set; } = new Colliders()
        {
            boxes = new List<Colliders.Boxes>()
            {
                new Colliders.Boxes(new List<float>(){ 0.5f, 0f, 0.5f }, new List<float>(){ -0.5f, -0.5f, -0.5f })
            }
        };

    }

    public class SlabRecipe : ICSRecipe
    {
        public string name { get; set; } = GenerateTypeConfig.TYPEPREFIX + Slab.NAME;

        public List<RecipeItem> requires { get; set; } = new List<RecipeItem>();

        public List<RecipeItem> results { get; set; } = new List<RecipeItem>();

        public CraftPriority defaultPriority { get; set; } = CraftPriority.Medium;

        public bool isOptional { get; set; } = false;

        public int defaultLimit { get; set; } = 0;

        public string Job { get; set; } = "pipliz.crafter";
    }

    [ModLoader.ModManager]
    public class Slab
    {
        public const string NAME = "Slab";
        public const string GENERATE_TYPES_NAME = GenerateTypeConfig.GENERATE_RECIPES_PREFIX + "." + NAME;

        [ModLoader.ModCallback(ModLoader.EModCallbackType.AddItemTypes, GENERATE_TYPES_NAME)]
        public static void generateTypes(Dictionary<string, ItemTypeRaw> types)
        {
            ServerLog.LogAsyncMessage(new LogMessage("Begining slab generation", LogType.Log));

            if (GenerateTypeConfig.DecorTypes.TryGetValue("Slab", out List<string> slabTypes))
                foreach (var currentType in slabTypes)
                {
                    ServerLog.print(currentType);
                    var typeName = GenerateTypeConfig.TYPEPREFIX + NAME + "." + currentType;
                    var typeNameUp = typeName + ".up";
                    var typeNameDown = typeName + ".down";

                    var baseType = new SlabParent();
                    baseType.categories.Add(currentType);
                    baseType.name = typeName;
                    baseType.rotatablexn = typeNameUp;
                    baseType.rotatablexp = typeNameUp;
                    baseType.rotatablezn = typeNameDown;
                    baseType.rotatablezp = typeNameDown;

                    var slabUp = new SlabUp();
                    slabUp.name = typeNameUp;
                    slabUp.parentType = typeName;

                    var slabDown = new SlabDown();
                    slabDown.name = typeNameDown;
                    slabDown.parentType = typeName;


                    types.Add(typeName, new ItemTypeRaw(typeName, baseType.JsonSerialize()));
                    types.Add(typeNameUp, new ItemTypeRaw(typeNameUp, slabUp.JsonSerialize()));
                    types.Add(typeNameDown, new ItemTypeRaw(typeNameDown, slabDown.JsonSerialize()));
                }
        }

        [ModLoader.ModCallback(ModLoader.EModCallbackType.AfterStartup, GENERATE_TYPES_NAME + ".Recipies")]
        public static void generateRecipes()
        {
            if (GenerateTypeConfig.DecorTypes.TryGetValue("Slab", out List<string> slabTypes))
                foreach (var currentType in slabTypes)
                {
                    var typeName = GenerateTypeConfig.TYPEPREFIX + NAME + "." + currentType;
                    var typeNameRecipe = GenerateTypeConfig.TYPEPREFIX + NAME + "." + currentType + ".Recipe";
                    var recipe = new SlabRecipe();
                    recipe.name = typeNameRecipe;
                    recipe.results.Add(new RecipeItem(typeName));


                    recipe.LoadRecipe();
                }
            
        }
    }
}