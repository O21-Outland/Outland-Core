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
    public class StatPart_BoneFactor : StatPart
    {
        public override string ExplanationPart(StatRequest req)
        {
            return "Bone Factor Settings: " + OutlandMod.settings.boneFactor.ToString() + "x";
        }

        public override void TransformValue(StatRequest req, ref float val)
        {
            val *= OutlandMod.settings.boneFactor;
        }
    }
}
