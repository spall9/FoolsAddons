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
using static Brand2.Spells;
using static Brand2.Damage;
using static Brand2.Menus;
using static Brand2.Combo;

namespace Brand2
{
    internal class Harass
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

        public static void HarassExecute()
        {
            var CheckQ = HarassMenu["Q"].Cast<CheckBox>().CurrentValue && Player.CanUseSpell(SpellSlot.Q) == SpellState.Ready;
            var CheckW = HarassMenu["W"].Cast<CheckBox>().CurrentValue && Player.CanUseSpell(SpellSlot.W) == SpellState.Ready;
            var CheckE = HarassMenu["E"].Cast<CheckBox>().CurrentValue && Player.CanUseSpell(SpellSlot.E) == SpellState.Ready;
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
                                     if (IsBlazed(selectedTarget))
                                           {
                                                Q.Cast(positionQ.CastPosition);
                                           }
                                }
                   }
                        
                }
            }
        }
  }
