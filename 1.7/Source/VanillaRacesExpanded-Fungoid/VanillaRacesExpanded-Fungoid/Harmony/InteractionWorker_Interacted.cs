using HarmonyLib;
using RimWorld;
using RimWorld.Planet;
using Verse;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Verse.AI;



namespace VanillaRacesExpandedFungoid
{


    [HarmonyPatch(typeof(InteractionWorker))]
    [HarmonyPatch("Interacted")]
    public static class VanillaRacesExpandedFungoid_InteractionWorker_Interacted_Patch
    {
        [HarmonyPostfix]
        static void VomitIfFungoid(Pawn initiator, Pawn recipient)
        {
            if (Rand.Chance(0.2f))
            {
                if (initiator.genes?.HasActiveGene(InternalDefOf.VRE_Repulsive) == true && recipient.genes?.HasActiveGene(InternalDefOf.VRE_Repulsive) == false)
                {
                    recipient.jobs.StartJob(JobMaker.MakeJob(JobDefOf.Vomit), JobCondition.InterruptForced, null, resumeCurJobAfterwards: true);
                    MoteMaker.ThrowText(recipient.Position.ToVector3(), recipient.Map, "VRE_TextMote_RepulsiveColonist".Translate(), 6f);
                }
                else if (initiator.genes?.HasActiveGene(InternalDefOf.VRE_Repulsive) == false && recipient.genes?.HasActiveGene(InternalDefOf.VRE_Repulsive) == true)
                {
                    initiator.jobs.StartJob(JobMaker.MakeJob(JobDefOf.Vomit), JobCondition.InterruptForced, null, resumeCurJobAfterwards: true);
                    MoteMaker.ThrowText(initiator.Position.ToVector3(), initiator.Map, "VRE_TextMote_RepulsiveColonist".Translate(), 6f);
                }
            }
            

        }
    }








}
