using BlockTypes.Builtin;
using Pipliz.Mods.APIProvider.Jobs;
using Server.NPCs;

namespace Jobs
{
    public class Nach0QuarterBlockMakerJob : CraftingJobBase, IBlockJobBase, INPCTypeDefiner
    {
        public static float StaticCraftingCooldown = 5f;

        public override string NPCTypeKey { get { return "Nach0QuarterBlockMakerJob"; } }

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
                printName = "Quarter Block Maker",
                maskColor1 = new UnityEngine.Color32(84, 2, 2, 1),
                type = NPCTypeID.GetNextID()
            };
        }
    }
}