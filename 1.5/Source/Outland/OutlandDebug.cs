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
    public static class OutlandDebug
    {
        //[DebugAction("Outland", "Alchemical: Give Class...", false, false, actionType = DebugActionType.ToolMapForPawns, allowedGameStates = AllowedGameStates.PlayingOnMap)]
        //public static void DebugCommand_ArcaneMakeAlchemist(Pawn pawn)
        //{
        //    Find.WindowStack.Add(new Dialog_DebugOptionListLister(DebugOptions_ArcaneMakeAlchemist(pawn)));
        //}

        //public static List<DebugMenuOption> DebugOptions_ArcaneMakeAlchemist(Pawn pawn)
        //{
        //    List<DebugMenuOption> list = new List<DebugMenuOption>();
        //    foreach (ClassDef ac in DefDatabase<ClassDef>.AllDefs.Where(c => c.classType == ClassType.Alchemical).OrderBy(d => d.label.ToStringSafe()))
        //    {
        //        list.Add(new DebugMenuOption(ac.LabelCap, DebugMenuOptionMode.Action, delegate
        //        {
        //            if (pawn != null && pawn.RaceProps.Humanlike)
        //            {
        //                BodyPartRecord bodyPartRecord = pawn.RaceProps.body.GetPartsWithDef(BodyPartDefOf.Brain).FirstOrFallback();
        //                if (bodyPartRecord != null)
        //                {
        //                    Hediff_ArcaneAbilities firstHediffOfDef = (Hediff_ArcaneAbilities)pawn.health.hediffSet.GetFirstHediffOfDef(OutlandDefOf.Outland_ArcaneClass);
        //                    if (firstHediffOfDef == null)
        //                    {
        //                        Hediff_ArcaneAbilities arcaneHediff = (Hediff_ArcaneAbilities)HediffMaker.MakeHediff(OutlandDefOf.Outland_ArcaneClass, pawn, bodyPartRecord);
        //                        arcaneHediff.knownClasses.Add(ac);

        //                        pawn.health.AddHediff(arcaneHediff);
        //                    }
        //                    else
        //                    {
        //                        firstHediffOfDef.knownClasses.Add(ac);
        //                    }
        //                }
        //            }
        //        }));
        //    }
        //    return list;
        //}

        //[DebugAction("Outland", "Arcane: Give Class...", false, false, actionType = DebugActionType.ToolMapForPawns, allowedGameStates = AllowedGameStates.PlayingOnMap)]
        //public static void DebugCommand_ArcaneMakeMage(Pawn pawn)
        //{
        //    Find.WindowStack.Add(new Dialog_DebugOptionListLister(DebugOptions_ArcaneMakeMage(pawn)));
        //}

        //public static List<DebugMenuOption> DebugOptions_ArcaneMakeMage(Pawn pawn)
        //{
        //    List<DebugMenuOption> list = new List<DebugMenuOption>();
        //    foreach(ClassDef ac in DefDatabase<ClassDef>.AllDefs.Where(c => c.classType == ClassType.Arcane).OrderBy(d => d.label.ToStringSafe()))
        //    {
        //        list.Add(new DebugMenuOption(ac.LabelCap, DebugMenuOptionMode.Action, delegate
        //        {
        //            if (pawn != null && pawn.RaceProps.Humanlike)
        //            {
        //                BodyPartRecord bodyPartRecord = pawn.RaceProps.body.GetPartsWithDef(BodyPartDefOf.Brain).FirstOrFallback();
        //                if (bodyPartRecord != null)
        //                {
        //                    Hediff_ArcaneAbilities firstHediffOfDef = (Hediff_ArcaneAbilities)pawn.health.hediffSet.GetFirstHediffOfDef(OutlandDefOf.Outland_ArcaneClass);
        //                    if (firstHediffOfDef == null)
        //                    {
        //                        Hediff_ArcaneAbilities arcaneHediff = (Hediff_ArcaneAbilities)HediffMaker.MakeHediff(OutlandDefOf.Outland_ArcaneClass, pawn, bodyPartRecord);
        //                        arcaneHediff.knownClasses.Add(ac);

        //                        pawn.health.AddHediff(arcaneHediff);
        //                    }
        //                    else
        //                    {
        //                        firstHediffOfDef.knownClasses.Add(ac);
        //                    }
        //                }
        //            }
        //        }));
        //    }
        //    return list;
        //}

        //[DebugAction("Outland", "Arcane: Fill Energy", false, false, actionType = DebugActionType.ToolMapForPawns, allowedGameStates = AllowedGameStates.PlayingOnMap)]
        //public static void DebugCommand_ArcaneFillEnergy(Pawn pawn)
        //{
        //    Hediff_ArcaneAbilities arcaneHediff = (Hediff_ArcaneAbilities)pawn.health.hediffSet.GetFirstHediffOfDef(OutlandDefOf.Outland_ArcaneClass);

        //    if (arcaneHediff != null)
        //    {
        //        arcaneHediff.arcaneEnergy = pawn.GetStatValue(OutlandDefOf.Outland_ArcaneEnergyMax);
        //    }
        //    else
        //    {
        //        Messages.Message("Pawn does not have Arcane class to modify.", MessageTypeDefOf.RejectInput);
        //    }
        //}

        //[DebugAction("Outland", "Arcane: Add Level", false, false, actionType = DebugActionType.ToolMapForPawns, allowedGameStates = AllowedGameStates.PlayingOnMap)]
        //public static void DebugCommand_ArcaneAddLevel(Pawn pawn)
        //{
        //    Hediff_ArcaneAbilities arcaneHediff = (Hediff_ArcaneAbilities)pawn.health.hediffSet.GetFirstHediffOfDef(OutlandDefOf.Outland_ArcaneClass);

        //    if (arcaneHediff != null)
        //    {
        //        arcaneHediff.ExpGain(arcaneHediff.ExpForNextLevel);
        //    }
        //    else
        //    {
        //        Messages.Message("Pawn does not have Arcane class to modify.", MessageTypeDefOf.RejectInput);
        //    }
        //}
    }
}
