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
using static FooL_s_Sion.Spells;
using static FooL_s_Sion.Menus;

namespace FooL_s_Sion
{
    internal class LaneClear
    {
        static float BTarget()
        {
            float B = 0;
            if (Q.IsReady() | W.IsReady())
            {
                B = 600;
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
            var LaneQC = LaneClearMenu["QMinions"].Cast<Slider>().CurrentValue;
            var LaneW = LaneClearMenu["W"].Cast<CheckBox>().CurrentValue && Player.CanUseSpell(SpellSlot.W) == SpellState.Ready;
            var LaneE = LaneClearMenu["E"].Cast<CheckBox>().CurrentValue && Player.CanUseSpell(SpellSlot.E) == SpellState.Ready;

            if (LaneQ)
            {
                var Qminion = EntityManager.MinionsAndMonsters.GetLaneMinions().Where(x => x.IsValidTarget(BTarget()));
                if (Qminion != null)
                {
                    if (Q.IsReady())
                    {
                        var position = Q.GetBestLinearCastPosition(Qminion);
                        if (position.HitNumber >= LaneQC)
                        {
                            Q.Cast(position.CastPosition);
                        }
                    }
                }
            }
            /*if (LaneQ)
            {
                var Qminion = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.Instance.ServerPosition, Spells.W.Range).OrderBy(minion => minion.Distance(Player.Instance.Position.To2D()));
                if (LaneW && Wminion.First().IsInRange(Player.Instance.Position, Spells.W.Range))
                {
                    Spells.W.Cast(Wminion.First());
                }
            }*/
            if (LaneW)
            {
                var Wminion = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.Instance.ServerPosition, Spells.W.Range).OrderBy(minion => minion.Distance(Player.Instance.Position.To2D()));
                if (LaneW && Wminion.First().IsInRange(Player.Instance.Position, Spells.W.Range))
                {
                    Spells.W.Cast(Wminion.First());
                }
            }

            if (LaneE)
            {
                var Eminion = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.Instance.ServerPosition, Spells.E.Range).OrderBy(minion => minion.Distance(Player.Instance.Position.To2D()));
                if (Eminion != null && LaneE)
                {
                    var position = E.GetBestLinearCastPosition(Eminion);
                    if (position.HitNumber >= 1)
                    {
                        E.Cast(position.CastPosition);
                    }
                }
            }
        }
    }
}
