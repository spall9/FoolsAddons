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

namespace FooL_s_Sion
{
    internal static class Spells
    {
        //public static Spell.Chargeable Q;
        public static Spell.Skillshot Q;
        public static Spell.Active W;
        public static Spell.Skillshot E;
        public static Spell.Skillshot R;
        public static Spell.Targeted Ignite;

        public static void InitializeSpells()
        {
            //Q = new Spell.Chargeable(SpellSlot.Q, 300, 600, 2000, 250, 1600, 140);
            Q = new Spell.Skillshot(SpellSlot.Q, 600, SkillShotType.Cone, 250, 1600, 140);
            W = new Spell.Active(SpellSlot.W, 550);
            E = new Spell.Skillshot(SpellSlot.E, 725, SkillShotType.Linear, 250, 1600, 60);
            R = new Spell.Skillshot(SpellSlot.R, 550, SkillShotType.Cone, 300, 900, 140);
        }

        public static void InitializeSummonerSpells()
        {
            var slot = Player.Instance.GetSpellSlotFromName("summonerdot");

            if (slot != SpellSlot.Unknown)
                Ignite = new Spell.Targeted(slot, 600);
        }

        public static bool SionDeath(this Obj_AI_Base target)
        {
            return Player.Instance.HasBuff("GloryinDeath");
        }
    }
}
