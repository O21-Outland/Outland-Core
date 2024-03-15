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
    [StaticConstructorOnStartup]
    public static class OutlandStartup
    {
        private static readonly Dictionary<ThingDef, ThingRequestGroup> registeredUnconventionalShells = new Dictionary<ThingDef, ThingRequestGroup>();

        public static HediffStage arcaneNoneStage;

        static OutlandStartup()
        {
            FindAndRegisterUnconventionalShellsToTurrets();

            //if (OutlandMod.settings.kalociteSpawnsNaturally)
            //{
            //    AddKalociteToBiomes();
            //    if (ModLister.BiotechInstalled)
            //    {
            //        AddToxociteToBiomes();
            //        AdjustToxociteIfNeeded();
            //    }
            //}

            //OutlandDefOf.Outland_ArcaneClass.maxSeverity = float.MaxValue;
        }

        public static void FindAndRegisterUnconventionalShellsToTurrets()
        {
            List<ThingDef> unconventionalTurrets = DefDatabase<ThingDef>.AllDefs.Where(t => t.HasModExtension<DefModExt_UnconventionalTurret>()).ToList();

            foreach (ThingDef thing in unconventionalTurrets)
            {
                RegisterUnconventionalShells(thing, ThingRequestGroup.HaulableEver);
            }
        }

        public static void RegisterUnconventionalShells(ThingDef def, ThingRequestGroup ammoGroup)
        {
            if (!registeredUnconventionalShells.ContainsKey(def))
            {
                registeredUnconventionalShells.Add(def, ammoGroup);
            }
        }

        public static bool TryGetShells(this Thing thing, out ThingRequestGroup group) => registeredUnconventionalShells.TryGetValue(thing.def, out group);

        //public static void AdjustToxociteIfNeeded()
        //{
        //    if (!OutlandMod.settings.toxociteSpread)
        //    {
        //        CompProperties compProps = (CompProperties)OutlandDefOf.Outland_ToxociteFormation.GetCompProperties<CompProperties_Toxifier>();
        //        OutlandDefOf.Outland_ToxociteFormation.comps.Remove(compProps);
        //    }
        //}

        //public static void ArcaneLevelingSetup(OutlandSettings s)
        //{
        //    if (arcaneNoneStage == null)
        //    {
        //        arcaneNoneStage = OutlandDefOf.Outland_ArcaneClass.stages.FirstOrDefault();
        //    }
        //    HediffDef arcaneHediff = OutlandDefOf.Outland_ArcaneClass;
        //    arcaneHediff.maxSeverity = float.MaxValue;
        //    arcaneHediff.stages.Clear();
        //    arcaneHediff.stages.Add(arcaneNoneStage);
        //    for (int i = 1; i <= s.arcane_LevelCap; i++)
        //    {
        //        HediffStage curStage = new HediffStage();
        //        curStage.minSeverity = i;
        //        curStage.statOffsets = new List<StatModifier>();

        //        StatModifier statMod_manaCap = new StatModifier();
        //        statMod_manaCap.stat = OutlandDefOf.Outland_ArcaneEnergyMax;
        //        statMod_manaCap.value = s.arcane_capacityPerLevel + (i * s.arcane_capacityPerLevel);
        //        curStage.statOffsets.Add(statMod_manaCap);

        //        StatModifier statMod_manaRegen = new StatModifier();
        //        statMod_manaRegen.stat = OutlandDefOf.Outland_ArcaneEnergyRecoveryRate;
        //        statMod_manaRegen.value = s.arcane_regenPerLevel + (i * s.arcane_regenPerLevel);
        //        curStage.statOffsets.Add(statMod_manaRegen);

        //        arcaneHediff.stages.Add(curStage);
        //    }

        //    DefModExt_LevelingHediff modExt = arcaneHediff.GetModExtension<DefModExt_LevelingHediff>();
        //    modExt.experienceCurve = new SimpleCurve();
        //    modExt.experienceCurve.Add(0, 1);

        //    for (int i = 1; i <= s.arcane_LevelCap; i++)
        //    {
        //        float expForCurrentLevel = s.arcane_expBase + (s.arcane_expMulti * i);
        //        modExt.experienceCurve.Add(expForCurrentLevel, i);
        //    }
        //}

        //public static void AddKalociteToBiomes()
        //{
        //    List<BiomeDef> biomeDefs = new List<BiomeDef>();

        //    foreach (BiomeDef biomeDef in DefDatabase<BiomeDef>.AllDefs)
        //    {
        //        if(biomeDef != null) { biomeDefs.Add(biomeDef); }
        //    }

        //    for (int i = 0; i < biomeDefs.Count; i++)
        //    {
        //        if (!biomeDefs[i].wildPlants.Any(bpr => bpr.plant == OutlandDefOf.Outland_KalociteFormation))
        //        {
        //            float commonality = 0f;
        //            foreach (BiomePlantRecord biomePlant in biomeDefs[i].wildPlants)
        //            {
        //                if (biomePlant != null)
        //                {
        //                    commonality += biomePlant.commonality;
        //                }
        //            }

        //            BiomePlantRecord kalociteRecord = new BiomePlantRecord();
        //            kalociteRecord.plant = OutlandDefOf.Outland_KalociteFormation;
        //            kalociteRecord.commonality = commonality / (100f / (OutlandMod.settings.kalociteCommonality));
        //            biomeDefs[i].wildPlants.Add(kalociteRecord);
        //        }
        //    }
        //}

        //public static void AddToxociteToBiomes()
        //{
        //    List<BiomeDef> biomeDefs = new List<BiomeDef>();

        //    foreach (BiomeDef biomeDef in DefDatabase<BiomeDef>.AllDefs)
        //    {
        //        if (biomeDef != null) { biomeDefs.Add(biomeDef); }
        //    }

        //    for (int i = 0; i < biomeDefs.Count; i++)
        //    {
        //        if(!biomeDefs[i].wildPlants.Any(bpr => bpr.plant == OutlandDefOf.Outland_ToxociteFormation))
        //        {
        //            float commonality = 0f;
        //            foreach (BiomePlantRecord biomePlant in biomeDefs[i].wildPlants)
        //            {
        //                if (biomePlant != null)
        //                {
        //                    commonality += biomePlant.commonality;
        //                }
        //            }

        //            BiomePlantRecord ToxociteRecord = new BiomePlantRecord();
        //            ToxociteRecord.plant = OutlandDefOf.Outland_ToxociteFormation;
        //            ToxociteRecord.commonality = commonality / (100f / (OutlandMod.settings.kalociteCommonality));
        //            biomeDefs[i].wildPlants.Add(ToxociteRecord);
        //        }
        //    }
        //}
    }
}
