using EloBuddy.SDK.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using static FooL_s_Sion.Menus;
using static FooL_s_Sion.Spells;
using static FooL_s_Sion.Combo;
using EloBuddy.SDK.Rendering;

namespace FooL_s_Sion
{
    internal class Harass
    {
        public static void HarassExecute()
        {
            var CheckQ = HarassMenu["Q"].Cast<CheckBox>().CurrentValue;
            var CheckW = HarassMenu["W"].Cast<CheckBox>().CurrentValue;
            var CheckE = HarassMenu["E"].Cast<CheckBox>().CurrentValue;

            var target = TargetSelector.GetTarget(Spells.Q.Range, DamageType.Magical);
            if ((target == null) || target.IsInvulnerable)
                return;
            if (CheckQ)
            {
                qSpell(target);
            }
            if (CheckW)
            {
                wSpell(target);
            }
            if (CheckE)
            {
                eSpell(target);
            }
        }
    }
}
