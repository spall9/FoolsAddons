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

namespace firstScript
{
    internal class Menus
    {
        public static Menu FirstMenu;
        public static Menu ComboMenu;
        public static Menu HarassMenu;
        public static Menu LaneClearMenu;
        public static Menu DrawingsMenu;
        public static Menu MiscMenu;

        public static void createMenu() {
            FirstMenu = MainMenu.AddMenu(Player.Instance.ChampionName, Player.Instance.ChampionName.ToLower());
            
            ComboMenu = FirstMenu.AddSubMenu("Combo Settings");
            ComboMenu.AddSeparator(8);
            ComboMenu.Add("Q", new CheckBox("Use Q"));
            ComboMenu.Add("W", new CheckBox("Use W"));
            ComboMenu.Add("E", new CheckBox("Use E"));
            ComboMenu.Add("R", new CheckBox("Use R"));
            ComboMenu.Add("Ignite", new CheckBox("Use Ignite"));
            ComboMenu.AddSeparator(8);
            ComboMenu.Add("REnemies", new Slider("Enemies in Range to use R", 2, 1, 5));

            HarassMenu = FirstMenu.AddSubMenu("Harass Settings");
            HarassMenu.AddSeparator(8);
            HarassMenu.Add("Q", new CheckBox("Use Q"));
            HarassMenu.Add("W", new CheckBox("Use W"));

            LaneClearMenu = FirstMenu.AddSubMenu("LaneClear Settings");
            LaneClearMenu.AddSeparator(8);
            LaneClearMenu.Add("Q", new CheckBox("Use Q"));
            LaneClearMenu.Add("AutoQ", new CheckBox("Use Auto-Q"));
            LaneClearMenu.Add("W", new CheckBox("Use W"));

            DrawingsMenu = FirstMenu.AddSubMenu("Drawings Settings");
            DrawingsMenu.AddSeparator(8);
            DrawingsMenu.Add("Q", new CheckBox("Draw Q"));
            DrawingsMenu.Add("W", new CheckBox("Draw W"));
            DrawingsMenu.Add("R", new CheckBox("Draw R"));

            MiscMenu = FirstMenu.AddSubMenu("Misc Menu");
            MiscMenu.AddSeparator(8);
        }
    }
}
