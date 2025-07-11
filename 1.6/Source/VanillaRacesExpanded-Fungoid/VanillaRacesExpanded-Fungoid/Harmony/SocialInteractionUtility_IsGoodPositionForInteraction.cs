﻿using HarmonyLib;
using RimWorld;
using RimWorld.Planet;
using Verse;
using UnityEngine;
using System.Collections.Generic;
using System;
using Verse.AI;



namespace VanillaRacesExpandedFungoid
{


    [HarmonyPatch(typeof(SocialInteractionUtility))]
    [HarmonyPatch("IsGoodPositionForInteraction")]
    [HarmonyPatch(new Type[] { typeof(Pawn), typeof(Pawn) })]
    public static class VanillaRacesExpandedFungoid_SocialInteractionUtility_IsGoodPositionForInteraction_Patch
    {
        [HarmonyPostfix]
        static void AlwaysInteract(Pawn p, Pawn recipient,ref bool __result)
        {
            if (p.genes?.HasActiveGene(InternalDefOf.VRE_Telepathy) == true && recipient.genes?.HasActiveGene(InternalDefOf.VRE_Telepathy) == true)
            {
                __result = true;
            }
           

        }
    }








}
