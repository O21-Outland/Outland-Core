using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

using HarmonyLib;

namespace Outland
{
	[HarmonyPatch(typeof(Pawn), "ButcherProducts")]
	public class Patch_Corpse_SpecialDisplayStats
	{
		[HarmonyPostfix]
		public static void Postfix(Corpse __instance, ref IEnumerable<StatDrawEntry> __result)
        {
            List<StatDrawEntry> NewList = new List<StatDrawEntry>();

            foreach (StatDrawEntry entry in __result)
            {
                NewList.Add(entry);
            }

            StatDef BoneAmount = DefDatabase<StatDef>.GetNamed("Outland_BoneAmount", true);
            float pawnBoneCount = __instance.InnerPawn.GetStatValue(BoneAmount, true) * BoneModSettings.boneFactor;
            NewList.Add(new StatDrawEntry(BoneAmount.category, BoneAmount, pawnBoneCount, StatRequest.For(__instance.InnerPawn), ToStringNumberSense.Undefined));

            IEnumerable<StatDrawEntry> output = NewList;

            __result = output;
        }
	}
}
