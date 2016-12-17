using System;
using EloBuddy.SDK.Menu;
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
using static firstScript.Combo;
using static firstScript.Harass;
using static firstScript.LaneClear;
using static firstScript.Menus;
using static firstScript.Spells;

namespace firstScript
{
    internal static class Spells
    {
        public static Spell.Targeted Q;
        public static Spell.Skillshot W;
        public static Spell.Active E;
        public static Spell.Skillshot R;
        public static Spell.Targeted Ignite;

        public static void intializeSpells()
        {
            Q = new Spell.Targeted(SpellSlot.Q, 625);
            W = new Spell.Skillshot(SpellSlot.W, 625, SkillShotType.Cone, 250, int.MaxValue, 210);
            E = new Spell.Active(SpellSlot.E);
            R = new Spell.Skillshot(SpellSlot.R, 600, SkillShotType.Circular, 50, int.MaxValue, 250);
        }

        public static void InitializeSummonerSpells()
        {
            var slot = Player.Instance.GetSpellSlotFromName("summonerdot");

            if (slot != SpellSlot.Unknown)
                Ignite = new Spell.Targeted(slot, 600);
        }
    }
}
