using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Spells;
using static Brand2.Menus;
using static Brand2.Combo;
using static Brand2.LaneClear;
using static Brand2.Spells;
using static Brand2.Drawings;
using static Brand2.Harass;
using static Brand2.Damage;

namespace Brand2
{
   internal class Program
    {
        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            if (Player.Instance.Hero != Champion.Brand) return;

            Chat.Print("Welcome to FooL's Brand V3.2");

            Game.OnTick += OnTick;

            Menus.CreateMenu();

            Spells.InitializeSpells();

            Spells.InitializeSummonerSpells();

            Drawings.CreateDrawings();

            //Orbwalker.OnPreAttack += BeforeAttack;
        }

        /*private static void BeforeAttack(AttackableUnit target, Orbwalker.PreAttackArgs args)
        {
            var CheckS = MiscMenu["SMODE"].Cast<CheckBox>().CurrentValue;
            if (CheckS)
                {
                var lasthitmode = Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LastHit);

                if (lasthitmode)
                {
                    return;
                }
                }
        }*/

        private static void OnTick(EventArgs args)
        {
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo)) ComboExecute();
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass)) HarassExecute();
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear))
            {
                var CheckMana = LaneClearMenu["EnableMana"].Cast<CheckBox>().CurrentValue;
                var ManaSlider = LaneClearMenu["MinManaQWE"].Cast<Slider>().CurrentValue;
                if (CheckMana)
                {
                    if (Player.Instance.ManaPercent > ManaSlider)
                    {
                        LaneExecute();
                    }
                }
            } 
        }
    }
}