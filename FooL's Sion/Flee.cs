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
    internal class Flee
    {
        public static void FleeExecute()
        {
            var FleeE = FleeMenu["E"].Cast<CheckBox>().CurrentValue && Player.CanUseSpell(SpellSlot.E) == SpellState.Ready;
            var FleeR = FleeMenu["R"].Cast<CheckBox>().CurrentValue && Player.CanUseSpell(SpellSlot.R) == SpellState.Ready;
            var target = TargetSelector.GetTarget(Spells.E.Range, DamageType.Physical);

            if (FleeE)
            {
                var positionE = E.GetPrediction(target);
                if (positionE.HitChance >= HitChance.High)
                {
                    E.Cast(positionE.CastPosition);
                }
            }

            /*if (FleeR)
            {
                var tempPos = Game.CursorPos;
                if (tempPos.IsInRange(Player.Instance.Position, R.Range))
                {
                    R.Cast(tempPos);
                }
                else
                {
                    R.Cast(Player.Instance.Position.Extend(tempPos, 800).To3DWorld());
                }
            }*/

        }
}
}
