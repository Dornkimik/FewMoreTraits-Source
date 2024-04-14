using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FewMoreTraits
{
    [DefOf]
    public static class FMTDefOf
    {
        public static SkillDef FMT_Swimming;
        public static TraitDef Sehr_Veteran;
        public static TraitDef Sehr_Clean;

        static FMTDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(FMTDefOf));
        }

    }
}
