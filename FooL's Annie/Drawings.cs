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
using static firstScript.Menus;
using static firstScript.Spells;
using EloBuddy.SDK.Rendering;

namespace firstScript
{
    internal class Drawings
    {
        public static void CreateDrawings()
        {
            Drawing.OnDraw += Drawing_OnDraw;
        }

        private static void Drawing_OnDraw(EventArgs args)
        {
            if (DrawingsMenu["Q"].Cast<CheckBox>().CurrentValue && Q.IsReady())
            {
                Circle.Draw(SharpDX.Color.Red, Q.Range, Player.Instance);
            }
            if (DrawingsMenu["W"].Cast<CheckBox>().CurrentValue && W.IsReady())
            {
                Circle.Draw(SharpDX.Color.Red, W.Range, Player.Instance);
            }
            if (DrawingsMenu["R"].Cast<CheckBox>().CurrentValue && R.IsReady())
            {
                Circle.Draw(SharpDX.Color.Red, R.Range, Player.Instance);
            }
        }
    }
}
