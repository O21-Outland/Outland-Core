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
    public class OutlandSettings : ModSettings
    {
        // Bones
        public float boneFactor = 1f;

        // Kalocite
        public bool kalociteSpawnsNaturally = true;
        public float kalociteCommonality = 1f;
        public bool kalociteGlow = false;
        // Toxocite
        public bool toxociteSpread = true;

        // Alchemical
        public float alchemical_capacityBase = 100f;
        public float alchemical_capacityPerLevel = 50f;
        public float alchemical_pointsPerLevel = 1f;
        public float alchemical_expMulti = 1f;

        // Arcane
        public float arcane_capacityBase = 100f;
        public float arcane_capacityPerLevel = 25f;
        public float arcane_regenBase = 1f;
        public float arcane_regenPerLevel = 0.1f;
        public float arcane_pointsPerLevel = 1f;
        public float arcane_expMulti = 1f;

        // Martial
        public float martial_capacityBase = 100f;
        public float martial_capacityPerLevel = 50f;
        public float martial_regenBase = 1f;
        public float martial_regenPerLevel = 0.1f;
        public float martial_pointsPerLevel = 1f;
        public float martial_expMulti = 1f;


        public override void ExposeData()
        {
            base.ExposeData();

            Scribe_Values.Look(ref boneFactor, "boneFactor", 1f);

            Scribe_Values.Look(ref kalociteSpawnsNaturally, "kalociteSpawnsNaturally", true);
            Scribe_Values.Look(ref kalociteCommonality, "kalociteCommonality", 1f);
            Scribe_Values.Look(ref kalociteGlow, "kalociteGlow", false);
            Scribe_Values.Look(ref toxociteSpread, "toxociteSpread", false);

            Scribe_Values.Look(ref alchemical_capacityBase, "alchemical_capacityBase", 100f);
            Scribe_Values.Look(ref alchemical_capacityPerLevel, "alchemical_capacityPerLevel", 50f);
            Scribe_Values.Look(ref alchemical_pointsPerLevel, "alchemical_pointsPerLevel", 1f);
            Scribe_Values.Look(ref alchemical_expMulti, "alchemical_expMulti", 1f);

            Scribe_Values.Look(ref arcane_capacityBase, "arcane_capacityBase", 100f);
            Scribe_Values.Look(ref arcane_capacityPerLevel, "arcane_capacityPerLevel", 50f);
            Scribe_Values.Look(ref arcane_regenBase, "arcane_regenBase", 1f);
            Scribe_Values.Look(ref arcane_regenPerLevel, "arcane_regenPerLevel", 0.1f);
            Scribe_Values.Look(ref arcane_pointsPerLevel, "arcane_pointsPerLevel", 1f);
            Scribe_Values.Look(ref arcane_expMulti, "arcane_expMulti", 1f);

            Scribe_Values.Look(ref martial_capacityBase, "martial_capacityBase", 100f);
            Scribe_Values.Look(ref martial_capacityPerLevel, "martial_capacityPerLevel", 50f);
            Scribe_Values.Look(ref martial_regenBase, "martial_regenBase", 1f);
            Scribe_Values.Look(ref martial_regenPerLevel, "martial_regenPerLevel", 0.1f);
            Scribe_Values.Look(ref martial_pointsPerLevel, "martial_pointsPerLevel", 1f);
            Scribe_Values.Look(ref martial_expMulti, "martial_expMulti", 1f);
        }

        public IEnumerable<string> GetEnabledSettings
        {
            get
            {
                return GetType().GetFields().Where(p => p.FieldType == typeof(bool) && (bool)p.GetValue(this)).Select(p => p.Name);
            }
        }
    }
}
