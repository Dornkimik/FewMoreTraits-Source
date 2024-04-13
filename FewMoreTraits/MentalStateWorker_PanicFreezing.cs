using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Verse;
using Verse.AI;
using RimWorld;
using UnityEngine;

namespace FewMoreTraits
{
    public class MentalStateWorker_PanicFreezing : MentalStateWorker
    {
        public override bool StateCanOccur(Pawn pawn)
        {
            return pawn.Faction == Faction.OfPlayer && Rand.Chance(0.5f);
            // return pawn.Faction == Faction.OfPlayer && Rand.Chance(0.5f) && pawn.HasTrait(VTEDefOf.VTE_Kleptomaniac) && pawn.Map.mapPawns.AllPawns.Where
              //  (x => !x.Dead && x.Spawned && x.Position.IsValid && x.RaceProps.Humanlike && x.Faction != pawn.Faction && !x.HostileTo(pawn)).Any();
        }
    }
}
