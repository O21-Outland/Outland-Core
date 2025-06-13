using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
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

        // Kalocite
        //public static ThingDef Outland_KalociteFormation;

        //[MayRequireBiotech]
        //public static ThingDef Outland_ToxociteFormation;

        // Artillery
        public static ThingDef Outland_Ballista;
        public static ThingDef Outland_Mangonel;

        // Arcane Stuff
        //public static StatDef Outland_ArcaneEnergyMax;
        //public static StatDef Outland_ArcaneEnergyRecoveryRate;
        //public static StatDef Outland_MagicAbilityCostMultiplier;

        //public static HediffDef Outland_ArcaneClass;
        //public static HediffDef Outland_SoulTrapped;
        //public static HediffDef Outland_SoullessRage;

        //public static SoundDef Outland_Spell_Equip;

        // Soul Gems
        //public static ThingDef Outland_SoulGemPetty, Outland_SoulGemLesser, Outland_SoulGemCommon, Outland_SoulGemGreater, Outland_SoulGemGrand, Outland_SoulGemBlack;
    }
}
