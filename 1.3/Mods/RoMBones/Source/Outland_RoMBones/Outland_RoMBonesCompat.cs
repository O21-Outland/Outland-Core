using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

using HarmonyLib;

namespace Outland_RoMBones
{
    public class Outland_RoMBonesCompat : Mod
    {
        public Outland_RoMBonesCompat mod;

        public Outland_RoMBonesCompat(ModContentPack content) : base(content)
        {
            this.mod = this;
            Log.Message("Outland :: Rim of Madness - Bones Detected :: Patching...");

            new Harmony("neronix17.outland.rombonescompat").PatchAll();
        }
    }
}
