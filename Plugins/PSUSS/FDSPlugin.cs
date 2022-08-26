extern alias Drawing;
using MissionPlanner.Grid;
using System;
using System.Windows.Forms;
using MissionPlanner.Plugin;
using System.Drawing;
using MissionPlanner.MsgBox;
using MissionPlanner;
using MissionPlanner.Controls;

namespace PSUSS
{
    public class FDSPlugin : MissionPlanner.Plugin.Plugin

    {
        private static FDSUI fire_gui;

        public override string Name
        {
            get { return "Asat"; }
        }

        public override string Version
        {
            get { return "1.0"; }
        }

        public override string Author
        {
            get { return "Nota"; }
        }

        public override bool Init()
        {
            return true;
        }

    
        public override bool Loaded()
        {
            var MenuCustom = new ToolStripButton();
            MenuCustom.Name = "MenuCustom";
            MenuCustom.Margin = new System.Windows.Forms.Padding(0);
            MenuCustom.Size = new Size(56, 47);
            MenuCustom.Text = "ASAT";
            MenuCustom.TextAlign = ContentAlignment.BottomCenter;
            MenuCustom.TextImageRelation = TextImageRelation.ImageAboveText;
            Host.MainForm.MainMenu.Items.Insert(0, MenuCustom);

            MenuCustom.Image = Resources.asat;
            MenuCustom.Click += (s, e) =>
            {
                System.Diagnostics.Process.Start("https://www.asat.gr");
            };

            var Fire = new System.Windows.Forms.ToolStripButton();
            Fire.Name = "Fire";
            Fire.Margin = new System.Windows.Forms.Padding(0);
            Fire.Size = new Size(56, 47);
            Fire.Text = "FIRE";
            Fire.TextAlign = ContentAlignment.BottomCenter;
            Fire.TextImageRelation = TextImageRelation.ImageAboveText;
            Host.MainForm.MainMenu.Items.Insert(7, Fire);

            fire_gui = new FDSUI();
            MissionPlanner.Utilities.ThemeManager.ApplyThemeTo(fire_gui);
            MainV2.View.AddScreen(new MainSwitcher.Screen("FDSUI", fire_gui, true));

            Fire.Image = Resources.fire;
            Fire.Click += fire_Click;

            return true;
        }

        public void fire_Click(object sender, EventArgs e)
        {
            MainV2.View.ShowScreen("FDSUI");
        }

        public override bool Loop()
        {
            return true;
        }

        public override bool Exit()
        {
            return true;
        }
    }
}
