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
using static Brand2.Menus;

namespace Brand2
{
    static class Damage
    {
        private static readonly Dictionary<SpellSlot, int[]> BaseDamage = new Dictionary<SpellSlot, int[]>();
        private static readonly Dictionary<SpellSlot, float[]> BonusDamage = new Dictionary<SpellSlot, float[]>();

        static Damage()
        {
            BaseDamage.Add(SpellSlot.Q, new[] { 80, 110, 140, 170, 200 });
            BaseDamage.Add(SpellSlot.W, new[] { 75, 120, 165, 210, 255 });
            BaseDamage.Add(SpellSlot.E, new[] { 70, 90, 110, 130, 150 });
            BaseDamage.Add(SpellSlot.R, new[] { 100, 200, 300 });

            BonusDamage.Add(SpellSlot.Q, new[] { 0.56f, 0.56f, 0.56f, 0.56f, 0.56f });
            BonusDamage.Add(SpellSlot.W, new[] { 0.6f, 0.6f, 0.6f, 0.6f, 0.6f });
            BonusDamage.Add(SpellSlot.E, new[] { 0.35f, 0.35f, 0.35f, 0.35f, 0.35f });
            BonusDamage.Add(SpellSlot.R, new[] { 0.25f, 0.25f, 0.25f });
        }

        public static float DamageCalculation(SpellSlot slot, Obj_AI_Base unit)
        {
            if (slot == SpellSlot.Internal)
            {
                return Player.Instance.CalculateDamageOnUnit(unit, DamageType.Magical, unit.MaxHealth * 0.08f) - unit.FlatHPRegenMod * 4;
            }

            var Slevel = Player.GetSpell(slot).Level;
            var AP = Player.Instance.TotalMagicalDamage;
            var BaseDmg = BaseDamage[slot];
            var BonusDmg = BonusDamage[slot];

            if (Slevel == 0)
            {
                return 0;
            }
            return Player.Instance.CalculateDamageOnUnit(unit, DamageType.Magical, BaseDmg[Slevel - 1] + BonusDmg[Slevel - 1] * AP);
        }

        public static float TDamage(SpellSlot slot, Obj_AI_Base unit)
        {
            return DamageCalculation(slot, unit) + DamageCalculation(SpellSlot.Internal, unit);
        }

        public static bool KillYON(this Obj_AI_Base target, SpellSlot slot)
        {
            return TDamage(slot, target) >= target.Health;
        }

        static bool HasIgnite => SummonerSpells.PlayerHas(SummonerSpellsEnum.Ignite);

        static float GetIgniteDMG(Obj_AI_Base e) => DamageLibrary.GetSummonerSpellDamage(Player.Instance, e, DamageLibrary.SummonerSpells.Ignite);

        public static float OnFireDMG(Obj_AI_Base unit)
        {
            var buff = unit.GetBuff("BrandAblaze");

            if (buff == null)
            {
                return 0;
            }

            return Player.Instance.CalculateDamageOnUnit(unit, DamageType.Magical, unit.MaxHealth * 0.02f * (float)Math.Floor(buff.EndTime - Game.Time));
        }

        public static bool EnemyWillDie(this Obj_AI_Base unit)
        {
            return OnFireDMG(unit) >= unit.Health;
        }
    }
}