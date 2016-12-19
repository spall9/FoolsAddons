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
    internal class Menus
    {
        public static Menu FirstMenu;
        public static Menu ComboMenu;
        public static Menu HarassMenu;
        public static Menu LaneClearMenu;
        public static Menu JungleMenu;
        public static Menu DrawingsMenu;
        public static Menu FleeMenu;
        public static Menu MiscMenu;

        public static void CreateMenu()
        {
            FirstMenu = MainMenu.AddMenu("FooL's " + Player.Instance.ChampionName, Player.Instance.ChampionName.ToLower());

            ComboMenu = FirstMenu.AddSubMenu("Combo");
            HarassMenu = FirstMenu.AddSubMenu("Harass");
            LaneClearMenu = FirstMenu.AddSubMenu("Laneclear");
            JungleMenu = FirstMenu.AddSubMenu("Jungle");
            FleeMenu = FirstMenu.AddSubMenu("Flee");
            DrawingsMenu = FirstMenu.AddSubMenu("Drawings");
            MiscMenu = FirstMenu.AddSubMenu("Misc");

            //Combo Menu
            ComboMenu.AddGroupLabel("Combo Settings");
            ComboMenu.AddLabel("Combo Q + W + E + R");
            ComboMenu.AddSeparator(8);
            ComboMenu.Add("Q", new CheckBox("Use Q"));
            ComboMenu.Add("W", new CheckBox("Use W"));
            ComboMenu.Add("E", new CheckBox("Use E"));
            ComboMenu.Add("R", new CheckBox("Use R"));
            ComboMenu.Add("Ignite", new CheckBox("Use Ignite"));
            ComboMenu.AddSeparator(8);
            ComboMenu.Add("REnemies", new Slider("Number of Enemies to use R", 2, 1, 6));

            //Harass Menu
            HarassMenu.AddGroupLabel("Harass Settings");
            HarassMenu.AddLabel("Harass is W->Q->E or E->Q");
            HarassMenu.Add("Q", new CheckBox("Use Q"));
            HarassMenu.Add("W", new CheckBox("Use W"));
            HarassMenu.Add("E", new CheckBox("Use E"));

            //Laneclear Menu
            LaneClearMenu.AddGroupLabel("LaneClear Settings");
            LaneClearMenu.Add("MinManaQWE", new Slider("Min Mana to LaneClear", 30, 1, 99));
            LaneClearMenu.AddSeparator(8);
            LaneClearMenu.Add("Q", new CheckBox("Use Q"));
            LaneClearMenu.Add("QMinions", new Slider("Number of Minions to use Q", 3, 1, 6));
            LaneClearMenu.Add("W", new CheckBox("Use W"));
            LaneClearMenu.AddSeparator(8);
            LaneClearMenu.Add("E", new CheckBox("Use E"));

            //Jungle Menu
            JungleMenu.AddGroupLabel("Jungle Settings");
            JungleMenu.Add("MinManaQWE", new Slider("Min Mana to Jungle", 30, 1, 99));
            JungleMenu.AddSeparator(8);
            JungleMenu.Add("Q", new CheckBox("Use Q"));
            JungleMenu.AddSeparator(8);
            JungleMenu.Add("W", new CheckBox("Use W"));
            JungleMenu.AddSeparator(8);
            JungleMenu.Add("E", new CheckBox("Use E"));

            //Drawings Menu
            DrawingsMenu.AddGroupLabel("Drawings Settings");
            DrawingsMenu.Add("Q", new CheckBox("Draw Q"));
            DrawingsMenu.Add("W", new CheckBox("Draw W"));
            DrawingsMenu.Add("E", new CheckBox("Draw E"));

            //Flee Menu
            FleeMenu.AddLabel("Use this to run away");
            FleeMenu.AddSeparator(8);
            FleeMenu.Add("E", new CheckBox("Use E to slow pursuers"));
            FleeMenu.AddSeparator(8);
            FleeMenu.Add("R", new CheckBox("Use R (!DOES NOT WORK ATM!)"));
            
            //Misc Menu: Soon
            MiscMenu.AddLabel("Let me Know What you want");
            MiscMenu.AddSeparator(12);
        }
    }
}
