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
    public class Patch_Pawn_ButcherProducts
	{
		[HarmonyPostfix]
		public static void Postfix(Pawn __instance, ref IEnumerable<Thing> __result, float efficiency)
		{
			int boneCount = GenMath.RoundRandom(__instance.GetStatValue(OutlandDefOf.Outland_BoneAmount, true) * efficiency);
			int meatCountCheck = GenMath.RoundRandom(__instance.GetStatValue(StatDefOf.MeatAmount, true));
			if (boneCount > 0)
			{

				List<Thing> NewList = new List<Thing>();
				foreach (Thing entry in __result)
				{
					NewList.Add(entry);
				}
				if (meatCountCheck > 1)
				{
					if (__result.Any(t => FoodUtility.GetMeatSourceCategory(t.def) != MeatSourceCategory.Insect))
                    {
                        Thing bones = ThingMaker.MakeThing(OutlandDefOf.Outland_Bones, null);
                        bones.stackCount = boneCount;
                        NewList.Add(bones);
                    }
					else
					{
                        Thing bones = ThingMaker.MakeThing(OutlandDefOf.Outland_Bones, null);
                        bones.stackCount = boneCount;
                        NewList.Add(bones);
                    }
				}

				IEnumerable<Thing> output = NewList;
				__result = output;
			}
		}
	}
}
