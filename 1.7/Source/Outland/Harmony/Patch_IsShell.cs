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
    [HarmonyPatch(typeof(ThingDef), nameof(ThingDef.IsShell), MethodType.Getter)]
    public static class Patch_IsShell
    {
        public static void Postfix(ref bool __result, ThingDef __instance)
        {
            __result = __result && !__instance.HasModExtension<DefModExt_UnconventionalShell>();
        }
    }
}
