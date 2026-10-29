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
    public class PlaceWorker_OnMudOrNearWater : PlaceWorker
    {
        public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map, Thing thingToIgnore = null, Thing thing = null)
        {
            if(base.AllowsPlacing(checkingDef, loc, rot, map, thingToIgnore, thing))
            {
                TerrainDef terrainAt = loc.GetTerrain(map);
                if (terrainAt.defName == "MarshyTerrain" || terrainAt.defName == "Mud")
                {
                    return true;
                }
                if (terrainAt.HasTag("Soil"))
                {
                    foreach (IntVec3 spot in GenAdj.CellsAdjacent8Way(new TargetInfo(loc, map)))
                    {
                        if (spot.GetTerrain(map).HasTag("Water"))
                        {
                            return true;
                        }
                    }
                }
            }
            return "Outland.PlaceOnMudOrNextToWater".Translate();
        }
    }
}
