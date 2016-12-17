using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static firstScript.Combo;
using static firstScript.Harass;
using static firstScript.LaneClear;
using static firstScript.Menus;
using static firstScript.Spells;

namespace firstScript
{
    internal class Harass
    {
        public static void HcomboExecute()
        {
            var CheckQ = HarassMenu["Q"].Cast<CheckBox>().CurrentValue;
            var CheckW = HarassMenu["W"].Cast<CheckBox>().CurrentValue;

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
        }
    }
}
