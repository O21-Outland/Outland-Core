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
    public class Hediff_AntiTox : HediffWithComps
    {
        public override void Tick()
        {
            base.Tick();
            Hediff toxBuildup = pawn.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.ToxicBuildup);
            if (toxBuildup != null)
            {
                toxBuildup.Severity -= (Severity * 0.06f) / 300f;
            }
        }
    }
}
