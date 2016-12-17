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
    internal class LaneClear
    {
        public static void FcomboExecute()
        {
            var CheckQ = LaneClearMenu["Q"].Cast<CheckBox>().CurrentValue;
            var CheckW = LaneClearMenu["W"].Cast<CheckBox>().CurrentValue;

            var qMinions = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.Instance.ServerPosition, Spells.Q.Range).OrderBy(minion => minion.Distance(Player.Instance.Position.To2D()));
            if (CheckQ && qMinions.Any())
            {
                Spells.Q.Cast(qMinions.First());
            }
            if (CheckW && qMinions.First().IsInRange(Player.Instance.Position, Spells.W.Range))
            {
                Spells.W.Cast(qMinions.First());
            }
        }

        public static void autoQ()
        {
            var CheckAutoQ = LaneClearMenu["AutoQ"].Cast<CheckBox>().CurrentValue;
            //var minions = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.Instance.ServerPosition, Spells.Q.Range);
            //var qMinions = EntityManager.MinionsAndMonsters.GetCircularFarmLocation(minions, Spells.Q.Range, (int)Spells.Q.Range);
            var qMinions = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.Instance.ServerPosition, Spells.Q.Range).Where(minion => minion.Health <= Spells.Q.GetSpellDamage(minion)).OrderBy(minion => minion.Distance(Player.Instance.Position.To2D()));
            if (qMinions.Any())
            {
                if (CheckAutoQ && Player.Instance.CountEnemiesInRange(700) == 0)
                    Spells.Q.Cast(qMinions.First());
            }
        }
    }
}
