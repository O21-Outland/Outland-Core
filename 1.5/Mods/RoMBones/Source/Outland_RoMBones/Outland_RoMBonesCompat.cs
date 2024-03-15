using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

using HarmonyLib;
using Outland;

namespace Outland_RoMBones
{
    public class Outland_RoMBonesCompat : Mod
    {
        public Outland_RoMBonesCompat mod;

        public Outland_RoMBonesCompat(ModContentPack content) : base(content)
        {
            this.mod = this;
            LogUtil.LogMessage("Rim of Madness - Bones Detected :: Patch Active ::");

            new Harmony("neronix17.outland.rombonescompat").PatchAll();
        }
    }
}
