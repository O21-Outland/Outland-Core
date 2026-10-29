using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace Outland
{
    [DefOf]
    public static class OutlandDefOf
    {
        static OutlandDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(OutlandDefOf));
        }

        // Production Buildings
        public static ThingDef Outland_DiggingSpot;
        public static ThingDef Outland_Forge;

        // Artillery
        public static ThingDef Outland_Ballista;
        public static ThingDef Outland_Mangonel;

        // Items
        public static ThingDef Outland_Chitin;
        public static ThingDef Outland_Bones;

        // Stats
        public static StatDef Outland_BoneAmount;
    }
}
