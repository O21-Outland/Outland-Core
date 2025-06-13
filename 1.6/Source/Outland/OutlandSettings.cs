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
        public float boneFactor = 1f;
        public bool smithyToForge = false;


        public override void ExposeData()
        {
            base.ExposeData();

            Scribe_Values.Look(ref boneFactor, "boneFactor", 1f);
            Scribe_Values.Look(ref smithyToForge, "smithyToForge", false);
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
