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

namespace Brand2
{
    class Menus
    {
        public static Menu FirstMenu;
        public static Menu ComboMenu;
        public static Menu HarassMenu;
        public static Menu LaneClearMenu;
        public static Menu DrawingsMenu;
        public static Menu MiscMenu;

        public static void CreateMenu()
        {
            FirstMenu = MainMenu.AddMenu("SwiftBrand", "SwiftBrand");

            ComboMenu = FirstMenu.AddSubMenu("Combo");
            HarassMenu = FirstMenu.AddSubMenu("Harass");
            LaneClearMenu = FirstMenu.AddSubMenu("Laneclear");
            DrawingsMenu = FirstMenu.AddSubMenu("Drawings");
            MiscMenu = FirstMenu.AddSubMenu("Misc");

            //Combo Menu
            ComboMenu.AddGroupLabel("Combo Settings");
            ComboMenu.AddLabel("Combo is W->Q->E->R unless W misses then it is E>Q>R");
            ComboMenu.AddSeparator(8);
            ComboMenu.Add("Q", new CheckBox("Use Q"));
            ComboMenu.Add("W", new CheckBox("Use W"));
            ComboMenu.Add("E", new CheckBox("Use E"));
            ComboMenu.Add("R", new CheckBox("Use R"));
            //ComboMenu.Add("RK", new CheckBox("Use R if will kill"));
            ComboMenu.Add("Ignite", new CheckBox("Use Ignite"));
            ComboMenu.AddSeparator(8);
            ComboMenu.Add("REnemies", new Slider("Enemies in range to use R", 2, 1, 5));

            //Harass Menu
            HarassMenu.AddGroupLabel("Harass Settings");
            HarassMenu.AddLabel("Harass is W->Q->E or E->Q");
            HarassMenu.Add("Q", new CheckBox("Use Q"));
            HarassMenu.Add("W", new CheckBox("Use W"));
            HarassMenu.Add("E", new CheckBox("Use E"));

            //Laneclear & Jungle Menu
            LaneClearMenu.AddGroupLabel("LaneClear Settings");
            LaneClearMenu.Add("EnableMana", new CheckBox("Enable Mana Restriction"));
            LaneClearMenu.Add("MinManaQWE", new Slider("Min Mana to LaneClear", 30, 1, 99));
            LaneClearMenu.AddSeparator(8);
            LaneClearMenu.Add("Q", new CheckBox("Use Q"));
            LaneClearMenu.Add("W", new CheckBox("Use W"));
            LaneClearMenu.Add("WMinions", new Slider("Number of Minions to use W", 3, 1, 6));
            LaneClearMenu.AddSeparator(8);
            LaneClearMenu.Add("E", new CheckBox("Use E"));
            LaneClearMenu.Add("EMinions", new Slider("Number of Minions to use E", 3, 1, 6));


            //Drawings Menu
            DrawingsMenu.AddGroupLabel("Drawings Settings");
            DrawingsMenu.Add("Q", new CheckBox("Draw Q"));
            DrawingsMenu.Add("W", new CheckBox("Draw W"));
            DrawingsMenu.Add("E", new CheckBox("Draw E"));
            DrawingsMenu.Add("R", new CheckBox("Draw R"));

            //Misc Menu: Soon
            MiscMenu.AddLabel("Let me Know What you want");
            MiscMenu.AddSeparator(12);
            MiscMenu.AddLabel("Working On Support Mode!");
            //MiscMenu.Add("SMODE", new CheckBox("Enable Support Mode WIP"));
        }
    }
}
