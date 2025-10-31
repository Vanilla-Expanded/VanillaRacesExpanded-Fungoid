using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using VEF;
using Verse;

namespace VanillaRacesExpandedFungoid
{
    [HarmonyPatch(typeof(IncidentWorker_RaidEnemy), "GenerateRaidLoot")]
    public static class VanillaRacesExpandedFungoid_IncidentWorker_RaidEnemy_GenerateRaidLoot_Patch
    {
        public static void Postfix(IncidentParms parms, List<Pawn> pawns)
        {
            if (VanillaRacesExpandedFungoid_Settings.fungoidApocalypse)
            {
                foreach (Pawn pawn in pawns)
                {

                    pawn.genes?.SetXenotype(InternalDefOf.VRE_Fungoid);

                }
            }


        }
    }
}
