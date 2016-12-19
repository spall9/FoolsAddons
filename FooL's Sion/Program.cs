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
using static FooL_s_Sion.Combo;
using static FooL_s_Sion.Harass;
using static FooL_s_Sion.LaneClear;
using static FooL_s_Sion.Jungle;
using static FooL_s_Sion.Menus;
using static FooL_s_Sion.Drawings;
using static FooL_s_Sion.Spells;
using static FooL_s_Sion.Flee;


namespace FooL_s_Sion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
            //Gapcloser.OnGapcloser += OnGapcloser;
        }

        /*private static void OnGapcloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs e)
        {
            if (config.Item("usewgc", true).GetValue<bool>() && gapcloser.End.Distance(player.Position) < 200)
            {
                W.Cast();
            }
        }*/

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            if (Player.Instance.Hero != Champion.Sion) return;

            Chat.Print("Welcome to FooL's Sion V1.6");

            Game.OnTick += OnTick;

            Menus.CreateMenu();

            Spells.InitializeSpells();

            Spells.InitializeSummonerSpells();

            Drawings.CreateDrawings();
        }

        private static void OnTick(EventArgs args)
        {
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo)) ComboExecute();
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass)) HarassExecute();
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee)) FleeExecute();
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear))
            {
                var ManaSlider = JungleMenu["MinManaQWE"].Cast<Slider>().CurrentValue;
                if (Player.Instance.ManaPercent >= ManaSlider)
                {
                    JungleExecute();
                }
            }
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear))
            {
                var ManaSlider = LaneClearMenu["MinManaQWE"].Cast<Slider>().CurrentValue;
                if (Player.Instance.ManaPercent >= ManaSlider)
                    {
                        LaneExecute();
                    }
            }
        }
    }
}
