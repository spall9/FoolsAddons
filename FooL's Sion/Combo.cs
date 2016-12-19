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
using EloBuddy.SDK.Rendering;

namespace FooL_s_Sion
{
    internal class Combo
    {
        public static void ComboExecute()
        {
            var target = TargetSelector.GetTarget(Spells.Q.Range, DamageType.Physical);
            if ((target == null) || target.IsInvulnerable)
                return;

            eSpell(target);
            qSpell(target);
            wSpell(target);
            rSpell(target);

            if (ComboMenu["Ignite"].Cast<CheckBox>().CurrentValue)
            {
                if (target.IsValidTarget(Spells.Ignite.Range) && target.HealthPercent < 15 && Spells.Ignite.IsReady())
                {
                    Spells.Ignite.Cast(target);
                }
            }
        }

        public static void qSpell(AIHeroClient target)
        {
            var CheckQ = ComboMenu["Q"].Cast<CheckBox>().CurrentValue;
            if (target.IsInRange(Player.Instance, Spells.Q.Range) && !Spells.Q.IsOnCooldown && CheckQ)
            {
                Spells.Q.Cast(target);
            }
        }

        /*public static void qSpell(AIHeroClient target)
        {
            var CheckQ = ComboMenu["Q"].Cast<CheckBox>().CurrentValue;
            if (target.IsInRange(Player.Instance, Spells.Q.MaximumRange) && !Spells.Q.IsOnCooldown && CheckQ)
            {
                Spells.Q.StartCharging();
            }
        }*/

        public static void wSpell(AIHeroClient target)
        {
            var CheckW = ComboMenu["W"].Cast<CheckBox>().CurrentValue;
            if (target.IsInRange(Player.Instance, Spells.W.Range) && !Spells.W.IsOnCooldown && CheckW)
            {
                Spells.W.Cast(target);
            }
        }

        public static void eSpell(AIHeroClient target)
        {
            var CheckE = ComboMenu["E"].Cast<CheckBox>().CurrentValue;
            if (target.IsInRange(Player.Instance, Spells.E.Range) && !Spells.E.IsOnCooldown && CheckE)
            {
                Spells.E.Cast(target);
            }
        }

        public static void rSpell(AIHeroClient target)
        {
            var CheckREnemies = ComboMenu["REnemies"].Cast<Slider>().CurrentValue;
            var CheckR = ComboMenu["R"].Cast<CheckBox>().CurrentValue && Player.CanUseSpell(SpellSlot.R) == SpellState.Ready;
            if (target.CountEnemiesInRange(500) >= CheckREnemies && target.HealthPercent < 80)
            {
                Spells.R.Cast(target);
            }
        }
    }
}
