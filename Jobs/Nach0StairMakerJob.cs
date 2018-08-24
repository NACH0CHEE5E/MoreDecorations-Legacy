using BlockTypes.Builtin;
using Pipliz.Mods.APIProvider.Jobs;
using Server.NPCs;
using Pipliz;
using NPC;


namespace Jobs
{
    public class Nach0StairMakerJob : CraftingJobBase, IBlockJobBase, INPCTypeDefiner
    {
        public static float StaticCraftingCooldown = 5f;

        public override string NPCTypeKey { get { return "Nach0StairMakerJob"; } }

        public override float CraftingCooldown
        {
            get { return StaticCraftingCooldown; }
            set { StaticCraftingCooldown = value; }
        }
        public override int MaxRecipeCraftsPerHaul { get { return 4; } }

        NPCTypeStandardSettings INPCTypeDefiner.GetNPCTypeDefinition()
        {
            return new NPCTypeStandardSettings()
            {
                keyName = NPCTypeKey,
                printName = "Stair Maker",
                maskColor1 = new UnityEngine.Color32(84, 2, 2, 1),
                type = NPCTypeID.GetNextID()
            };
        }
    }
}