using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

using HarmonyLib;

namespace Outland_MedievalOverhaul
{
	[HarmonyPatch(typeof(Thing))]
	[HarmonyPatch("ButcherProducts")]
	public class RemoveBoneSpawnPatch
	{
		[HarmonyAfter(new string[] { "lalapyhon.rimworld.medievaloverhaul" })]
		public static IEnumerable<Thing> Postfix(IEnumerable<Thing> result, Pawn butcher, float efficiency)
		{
			foreach (Thing t in result)
			{
				if (t.def.defName != "DankPyon_Bone")
				{
					yield return t;
				}
			}
			yield break;
		}
	}
}
