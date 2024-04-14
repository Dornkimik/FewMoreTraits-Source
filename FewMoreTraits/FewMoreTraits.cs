using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Verse;
using RimWorld;
using Verse.AI;

namespace FewMoreTraits
{
    public class ThoughtWorker_IsCarryingMeleeWeapon : ThoughtWorker
    {
        protected override ThoughtState CurrentStateInternal(Pawn p)
        {
            return p.equipment.Primary != null && p.equipment.Primary.def.IsRangedWeapon != true;
        }
    }

    public class ThoughtWorker_SawThingsInWar : ThoughtWorker
    {
        protected override ThoughtState CurrentStateInternal(Pawn p)
        {

            if (p.HasTrait(FMTDefOf.Sehr_Veteran))
            {
                return ThoughtState.ActiveDefault;
            }
            return ThoughtState.Inactive;
            //return true;
        }
    }

    public class ThoughtWorker_Swimming : ThoughtWorker
    {
        protected override ThoughtState CurrentStateInternal(Pawn p)
        {
            if (p.IsColonistPlayerControlled)
            {
                if (p.Position.GetTerrain(Find.CurrentMap).IsWater)
                {
                    p?.skills.Learn(FMTDefOf.FMT_Swimming, 10000);
                    return ThoughtState.ActiveDefault;
                }
            }

            return ThoughtState.Inactive;
        }
    }

    public class ThoughtWorker_PassionateCleaning : ThoughtWorker
    {
        protected override ThoughtState CurrentStateInternal(Pawn p)
        {
            if (p.HasTrait(FMTDefOf.Sehr_Clean) && p.CurJobDef == JobDefOf.Clean)
            {
                return ThoughtState.ActiveDefault;
            }

            return ThoughtState.Inactive;
        }
    }

    public class ThoughtWorker_IsPrisoned : ThoughtWorker
    {
        protected override ThoughtState CurrentStateInternal(Pawn p)
        {
            return p.IsPrisoner;
        }
    }

    public class Alert_VeteranWithoutRangedWeapon : Alert
    {
        public List<Pawn> VeteranWithoutRangedWeapon
        {
            get
            {
                veteransWithoutRangedWeaponResult.Clear();
                foreach (Pawn pawn in PawnsFinder.AllMaps_FreeColonistsSpawned)
                {
                    if (pawn.story.traits.HasTrait(FMTDefOf.Sehr_Veteran) && pawn.equipment.Primary != null && pawn.equipment.Primary.def.IsRangedWeapon != true)
                    {
                        veteransWithoutRangedWeaponResult.Add(pawn);
                    }
                }
                return veteransWithoutRangedWeaponResult;
            }
        }

        public Alert_VeteranWithoutRangedWeapon()
        {
            this.defaultLabel = "VeteranHasNoWeapon".Translate();
            this.defaultExplanation = "VeteranHasNoWeaponDesc".Translate();
        }

        public override AlertReport GetReport()
        {
            return AlertReport.CulpritsAre(VeteranWithoutRangedWeapon);
        }

        public List<Pawn> veteransWithoutRangedWeaponResult = new List<Pawn>();
    }
}
