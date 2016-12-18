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
using EloBuddy.SDK.Spells;
using static Brand2.Program;
using static Brand2.Menus;
using static Brand2.Spells;
using static Brand2.Damage;
using static Brand2.LaneClear;

namespace Brand2
{
    internal class Combo
    {
        static float BTarget()
        {
            float B = 0;
            if (Q.IsReady() | W.IsReady())
            {
                B = 900;
            }
            else
            {
                B = R.Range;
            }
            return B;
        }

        static bool IsBlazed(Obj_AI_Base selectedTarget) => selectedTarget.Buffs.Any(a => a.Name.ToLower().Equals("brandablaze"));
        static float HPrediction(Obj_AI_Base selectedTarget, int d) => Prediction.Health.GetPrediction(selectedTarget, d);

        public static void ComboExecute()
        {
            var CheckQ = ComboMenu["Q"].Cast<CheckBox>().CurrentValue && Player.CanUseSpell(SpellSlot.Q) == SpellState.Ready;
            var CheckW = ComboMenu["W"].Cast<CheckBox>().CurrentValue && Player.CanUseSpell(SpellSlot.W) == SpellState.Ready;
            var CheckE = ComboMenu["E"].Cast<CheckBox>().CurrentValue && Player.CanUseSpell(SpellSlot.E) == SpellState.Ready;
            var CheckR = ComboMenu["R"].Cast<CheckBox>().CurrentValue && Player.CanUseSpell(SpellSlot.R) == SpellState.Ready;
            var CheckREnemies = ComboMenu["REnemies"].Cast<Slider>().CurrentValue;

            var selectedTarget = TargetSelector.GetTarget(BTarget(), DamageType.Magical);

            if (selectedTarget != null && selectedTarget.IsValidTarget(BTarget()))
            {
                if (W.IsReady() && CheckW)
                {
                    var positionW = W.GetPrediction(selectedTarget);
                    if (positionW.HitChance >= HitChance.High)
                    {
                        W.Cast(positionW.CastPosition);
                    }
                    if (Q.IsReady() && CheckQ)
                    {
                        var positionQ = Q.GetPrediction(selectedTarget);
                        if (positionQ.HitChance >= HitChance.High)
                        {
                            if (IsBlazed(selectedTarget))
                            {
                                Q.Cast(positionQ.CastPosition);
                            }
                        }
                    }
                }
                if (E.IsReady() && CheckE)
                {
                    E.Cast(selectedTarget);
                }
                if (Q.IsReady() && CheckQ)
                {
                    var positionQ = Q.GetPrediction(selectedTarget);
                    if (positionQ.HitChance >= HitChance.High)
                    {
                            Q.Cast(positionQ.CastPosition);
                    }
                }

                if (R.IsReady() && CheckR)
                {
                    if (selectedTarget.CountEnemiesInRange(400) >= CheckREnemies && selectedTarget.HealthPercent < 75)
                    {
                        R.Cast(selectedTarget);
                    }
                }

                if (ComboMenu["Ignite"].Cast<CheckBox>().CurrentValue)
                {
                    if (selectedTarget.IsValidTarget(Spells.Ignite.Range) && selectedTarget.HealthPercent < 15 && Spells.Ignite.IsReady())
                    {
                        Spells.Ignite.Cast(selectedTarget);
                    }
                }
            }
        }
     }
 }
