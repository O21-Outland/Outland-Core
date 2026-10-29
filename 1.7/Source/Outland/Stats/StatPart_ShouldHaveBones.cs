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
    public class StatPart_ShouldHaveBones : StatPart
    {
        public override string ExplanationPart(StatRequest req)
        {
            if (req.HasThing)
            {
                Pawn pawn = req.Thing as Pawn;
                if (pawn != null)
                {
                    if (IsValidForBones(req.Pawn))
                    {
                        return "Pawn has bones: 1.00x";
                    }
                    return "Pawn has no bones: 0.00x";
                }
            }
            return "";
        }

        public override void TransformValue(StatRequest req, ref float val)
        {
            if (req.HasThing)
            {
                Pawn pawn = req.Thing as Pawn;
                if (pawn != null)
                {
                    if (IsValidForBones(req.Pawn))
                    {
                        val *= 1f;
                    }
                    val *= 0f;
                }
            }
        }

        public bool IsValidForBones(Pawn pawn)
        {
            if(pawn.RaceProps.FleshType == FleshTypeDefOf.Mechanoid
                || pawn.RaceProps.FleshType == FleshTypeDefOf.Insectoid)
            {
                return false;
            }
            return true;
        }
    }
}
