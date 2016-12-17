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
using static firstScript.Drawings;

namespace firstScript
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += OnloadingComplete;
        }

        private static void OnloadingComplete(EventArgs args)
        {
            if (Player.Instance.Hero != Champion.Annie)
                return;
            Chat.Print("Welcome to FooL's Annie V2");
            Game.OnTick += OnTick;
            Spells.intializeSpells();
            Spells.InitializeSummonerSpells();
            Menus.createMenu();
            Drawings.CreateDrawings();
        }

        private static void OnTick(EventArgs args)
        {
            autoQ();
            Orbwalker.DisableAttacking = true;
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
                comboExecute();
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass))
                HcomboExecute();
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear))
                FcomboExecute();
            Orbwalker.DisableAttacking = false;

        }

    }
}
