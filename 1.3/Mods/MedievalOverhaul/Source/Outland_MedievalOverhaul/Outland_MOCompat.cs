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
    public class Outland_MOCompat : Mod
    {
        public Outland_MOCompat mod;

        public Outland_MOCompat(ModContentPack content) : base(content)
        {
            this.mod = this;
            Log.Message("Outland :: Medieval Overhaul Detected :: Patching...");

            new Harmony("neronix17.outland.mocompat").PatchAll();
        }
    }
}
