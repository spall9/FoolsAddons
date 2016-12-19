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
    internal class Jungle
    {
        public static void JungleExecute()
        {
            var LaneQ = JungleMenu["Q"].Cast<CheckBox>().CurrentValue && Player.CanUseSpell(SpellSlot.Q) == SpellState.Ready;
            var LaneW = JungleMenu["W"].Cast<CheckBox>().CurrentValue && Player.CanUseSpell(SpellSlot.W) == SpellState.Ready;
            var LaneE = JungleMenu["E"].Cast<CheckBox>().CurrentValue && Player.CanUseSpell(SpellSlot.E) == SpellState.Ready;

            int monsters = EntityManager.MinionsAndMonsters.Monsters.Where(monster => monster.IsValidTarget(W.Range * 2)).Count();
            if (monsters != 0)
            {
                if (LaneQ)
                {
                    var targetmonster = EntityManager.MinionsAndMonsters.Monsters.Where(monster => monster.IsValidTarget(Q.Range));
                    Q.Cast(targetmonster.FirstOrDefault());
                }
                if (LaneW)
                {
                    var targetmonster = EntityManager.MinionsAndMonsters.Monsters.Where(monster => monster.IsValidTarget(W.Range));
                    W.Cast(targetmonster.FirstOrDefault());
                }

                if (LaneE)
                {
                    var targetmonster = EntityManager.MinionsAndMonsters.Monsters.Where(monster => monster.IsValidTarget(E.Range));
                    E.Cast(targetmonster.FirstOrDefault());
                }
            }
        }
    }
}
