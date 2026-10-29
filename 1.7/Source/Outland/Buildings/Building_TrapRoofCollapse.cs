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
    public class Building_TrapRoofCollapse : Building_Trap
    {
        public bool collapseAdjacent = true;

        public bool allowedToSpring = false;

        public bool naturalThickRoof;
        public bool naturalThinRoof;

        public bool isTriggered = false;
        public int triggerTimer = 10;

        public override void SpawnSetup(Map map, bool respawningAfterLoad)
        {
            base.SpawnSetup(map, respawningAfterLoad);
            if (!respawningAfterLoad)
            {
                naturalThickRoof = map.roofGrid.RoofAt(Position) == RoofDefOf.RoofRockThick;
                naturalThinRoof = map.roofGrid.RoofAt(Position) == RoofDefOf.RoofRockThin;

                map.roofGrid.SetRoof(Position, RoofDefOf.RoofRockThick);
            }
        }

        public override void DeSpawn(DestroyMode mode = DestroyMode.Vanish)
        {
            RestoreRoofIfNeeded(naturalThickRoof, naturalThinRoof, Position);
            base.DeSpawn(mode);
        }

        public override void Destroy(DestroyMode mode = DestroyMode.Vanish)
        {
            RestoreRoofIfNeeded(naturalThickRoof, naturalThinRoof, Position);
            base.Destroy(mode);
        }

        public override void Tick()
        {
            base.Tick();
            if (isTriggered)
            {
                triggerTimer--;
                if(triggerTimer <= 0)
                {
                    CollapseNow();
                }
            }
        }

        public override float SpringChance(Pawn p)
        {
            if (allowedToSpring && (p.Faction != Faction.OfPlayer || !p.RaceProps.Humanlike))
            {
                return 1.0f;
            }
            return 0f;
        }

        public override void SpringSub(Pawn p)
        {
            isTriggered = true;
        }

        public void CollapseNow()
        {
            if (collapseAdjacent)
            {
                TriggerAdjacent();
            }
            RoofCollapserImmediate.DropRoofInCells(Position, Map);
        }

        public void RestoreRoofIfNeeded(bool thick, bool thin, IntVec3 pos)
        {
            if (thick)
            {
                Map.roofGrid.SetRoof(pos, RoofDefOf.RoofRockThick);
            }
            else if (thin)
            {
                Map.roofGrid.SetRoof(pos, RoofDefOf.RoofRockThin);
            }
            else
            {
                Map.roofGrid.SetRoof(pos, null);
            }
        }

        public void TriggerAdjacent()
        {
            foreach(IntVec3 cell in GenAdj.CellsAdjacentCardinal(this))
            {
                if (!cell.GetThingList(Map).NullOrEmpty())
                {
                    Building_TrapRoofCollapse trap = cell.GetFirstThing<Building_TrapRoofCollapse>(Map);
                    if(trap != null)
                    {
                        trap.isTriggered = true;
                    }
                }
            }
        }

        public override IEnumerable<Gizmo> GetGizmos()
        {
            foreach(Gizmo gizmo in base.GetGizmos())
            {
                yield return gizmo;
            }
            {
                Command_Toggle command = new Command_Toggle();
                command.defaultLabel = "Outland.CollapseTrapTriggerable".Translate();
                command.defaultDesc = "Outland.CollapseTrapTriggerableDesc".Translate();
                command.icon = TexCommand.RearmTrap;
                command.isActive = () => allowedToSpring;
                command.toggleAction = delegate
                {
                    allowedToSpring = !allowedToSpring;
                };
                yield return command;
            }
            {
                Command_Toggle command = new Command_Toggle();
                command.defaultLabel = "Outland.CollapseAdjacent".Translate();
                command.defaultDesc = "Outland.CollapseAdjacentDesc".Translate();
                command.icon = TexCommand.RearmTrap;
                command.isActive = () => collapseAdjacent;
                command.toggleAction = delegate
                {
                    collapseAdjacent = !collapseAdjacent;
                };
                yield return command;
            }
        }
    }
}
