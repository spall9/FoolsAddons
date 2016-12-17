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
using EloBuddy.SDK.Notifications;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Spells;
using static Brand2.Spells;
using static Brand2.Damage;
using static Brand2.Menus;

namespace Brand2
{
    internal class LaneClear
    {
        static bool IsBlazed(Obj_AI_Base e) => e.Buffs.Any(a => a.Name.ToLower().Equals("brandablaze"));
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

        public static void LaneExecute()
        {
            var LaneQ = LaneClearMenu["Q"].Cast<CheckBox>().CurrentValue && Player.CanUseSpell(SpellSlot.Q) == SpellState.Ready;
            var LaneW = LaneClearMenu["W"].Cast<CheckBox>().CurrentValue &&  Player.CanUseSpell(SpellSlot.W) == SpellState.Ready;
            var LaneWC = LaneClearMenu["WMinions"].Cast<Slider>().CurrentValue;
            var LaneE = LaneClearMenu["E"].Cast<CheckBox>().CurrentValue && Player.CanUseSpell(SpellSlot.E) == SpellState.Ready;
            var LaneEC = LaneClearMenu["EMinions"].Cast<Slider>().CurrentValue;

            if (LaneQ)
            {
                var Qminion = EntityManager.MinionsAndMonsters.GetLaneMinions().Where(x => x.IsValidTarget(BTarget()));
                if (Qminion != null)
                {
                    if (Q.IsReady())
                    {
                        var position = Q.GetBestLinearCastPosition(Qminion);
                        if (position.HitNumber == 1)
                        {
                            Q.Cast(position.CastPosition);
                        }
                    }
                }
            }
            if (LaneE)
            {
                var Eminion = EntityManager.MinionsAndMonsters.GetLaneMinions().Where(x => x.IsValidTarget(BTarget()) && IsBlazed(x)).FirstOrDefault();
                if (Eminion != null)
                {
                    if (E.IsReady())
                    {
                        if (Eminion.CountEnemyMinionsInRange(300) >= LaneEC)
                        {
                            E.Cast(Eminion);
                        }
                    }
                }
            }
            if (LaneW)
            {
                var Wminion = EntityManager.MinionsAndMonsters.GetLaneMinions().Where(x => x.IsValidTarget(BTarget())).OrderBy(o => o.Health);
                if (Wminion != null)
                {
                    if (W.IsReady())
                    {
                        var p = W.GetBestCircularCastPosition(Wminion);
                        if (p.HitNumber >= LaneWC)
                        {
                            W.Cast(p.CastPosition);
                        }
                    }
                }
            }
            /*var Qlanemonster = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy,
                Player.Instance.ServerPosition, Spells.Q.Range);
           // var Wlanemonster = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy,
                Player.Instance.ServerPosition, Spells.W.Range);
            var Elanemonster = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy,
                Player.Instance.ServerPosition, Spells.E.Range);*/

            /*if (LaneClearMenu["Q"].Cast<CheckBox>().CurrentValue && Spells.Q.IsReady())
            {
                if (Player.Instance.ManaPercent >= LaneClearMenu["MinManaQ"].Cast<Slider>().CurrentValue)
                {
                    foreach (var minion in Qlanemonster)
                    {
                        if (minion.IsValidTarget())
                        {
                            Spells.Q.Cast(minion);
                        }
                    }
                }
            }

            if (LaneClearMenu["W"].Cast<CheckBox>().CurrentValue && Spells.W.IsReady())
            {
                if (Player.Instance.CountEnemyMinionsInRange(900) == LaneClearMenu["WMinions"].Cast<Slider>().CurrentValue)
                {
                    foreach (var minion in Wlanemonster)
                    {
                        if (minion.IsValidTarget())
                        {
                            Spells.W.Cast(minion);
                        }
                    }
                }
            }

            if (LaneClearMenu["E"].Cast<CheckBox>().CurrentValue && Spells.E.IsReady())
            {
                if (Player.Instance.ManaPercent >= LaneClearMenu["MinManaE"].Cast<Slider>().CurrentValue)
                {
                    foreach (var minion in Elanemonster)
                    {
                        if (minion.IsValidTarget())
                        {
                            Spells.E.Cast(minion);
                        }
                    }
                }
            }*/
        }
    }
}
