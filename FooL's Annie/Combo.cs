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
    internal class Combo
    {
        public static void comboExecute()
        {
            //Player.Instance.AutoAttackTargettingFlags
            var target = TargetSelector.GetTarget(Spells.Q.Range, DamageType.Magical);
            if ((target == null) || target.IsInvulnerable)
                return;
            eSpell();
            rSpell(target);
            qSpell(target);
            wSpell(target);

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
        public static void wSpell(AIHeroClient target)
        {
            var CheckW = ComboMenu["W"].Cast<CheckBox>().CurrentValue;
            if (target.IsInRange(Player.Instance, Spells.W.Range) && !Spells.W.IsOnCooldown && CheckW)
            {
               // if (Prediction.Position.Collision.LinearMissileCollision(target, Player.Instance.Position.To2D(), target.Position.To2D(), Spells.W.Speed, Spells.W.Width, Spells.W.CastDelay))
                
                    var wHitChance = Spells.W.GetPrediction(target);
                    if (wHitChance.HitChancePercent >= 90)
                        Spells.W.Cast(target);
                
            }
        }
        public static void eSpell()
        {
            var CheckE = ComboMenu["E"].Cast<CheckBox>().CurrentValue;
            if (!Player.HasBuff("pyromania_particle") && Player.Instance.ManaPercent >= 30 && CheckE)
            {
                Spells.E.Cast();
            }
        }
        public static void rSpell(AIHeroClient target)
        {
            var CheckR = ComboMenu["R"].Cast<CheckBox>().CurrentValue;
            var CheckREnemies = ComboMenu["REnemies"].Cast<Slider>().CurrentValue;
            //&& (target.Health <= Spells.R.GetSpellDamage(target)
            if (target.IsInRange(Player.Instance, Spells.R.Range) && CheckR && !Spells.R.IsOnCooldown && ((target.Health <= Spells.R.GetSpellDamage(target) + 300) || target.CountEnemiesInRange(400) >= CheckREnemies))
            {
                var rHitChance = Spells.R.GetPrediction(target);
                if (rHitChance.HitChancePercent >= 85)
                    Spells.R.Cast(target);
            }
        }
    }
}
