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
using static Brand2.Damage;

namespace Brand2
{
    internal static class Spells
    {
        public static Spell.Skillshot Q;
        public static Spell.Skillshot W;
        public static Spell.Targeted E;
        public static Spell.Targeted R;
        public static Spell.Targeted Ignite;

        public static void InitializeSpells()
        {
            Q = new Spell.Skillshot(SpellSlot.Q, 1050, SkillShotType.Linear, 250, 1600, 60);
            W = new Spell.Skillshot(SpellSlot.W, 900, SkillShotType.Circular, 650, -1, 250);
            E = new Spell.Targeted(SpellSlot.E, 625);
            R = new Spell.Targeted(SpellSlot.R, 750);
        }

        public static void InitializeSummonerSpells()
        {
            var slot = Player.Instance.GetSpellSlotFromName("summonerdot");

            if (slot != SpellSlot.Unknown)
                Ignite = new Spell.Targeted(slot, 600);
        }

        public static bool OnFire(this Obj_AI_Base target)
        {
            return target.HasBuff("BrandAblaze");
        }
    }
}
