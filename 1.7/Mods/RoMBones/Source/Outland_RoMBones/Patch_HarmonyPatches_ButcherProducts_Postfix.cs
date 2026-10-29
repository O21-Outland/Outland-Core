using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

using BoneMod;
using HarmonyLib;

namespace Outland_RoMBones
{
	[HarmonyPatch(typeof(HarmonyPatches), "ButcherProducts_PostFix")]
	public class Patch_HarmonyPatches_ButcherProducts_PostFix
	{
		[HarmonyPrefix]
		public static bool Prefix()
		{
			return false;
		}
	}
}
