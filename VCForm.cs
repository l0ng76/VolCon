using AudioSwitcher.AudioApi.CoreAudio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VolCon
{
    public partial class VCForm : System.Windows.Forms.Form
    {
        CoreAudioController cac;

        const int PACK_HEIGHT = 85;
        const int MARGIN = 20;
        public VCForm()
        {
            InitializeComponent();
            Width = 20;
            cac = new CoreAudioController();                        
        }
        
        private void Form_Shown(object sender, EventArgs e)
        {
            Visible = false;            
        }

        internal void reShow()
        {
            Visible = false;

            panel1.Controls.Clear();

            var pbDevs = cac.GetDevices(AudioSwitcher.AudioApi.DeviceType.Playback, AudioSwitcher.AudioApi.DeviceState.Active).ToList();
            var defaultDevice = pbDevs.SingleOrDefault(x => x.IsDefaultDevice);
            if (defaultDevice != null) {
                pbDevs.Remove(defaultDevice);
                pbDevs.Insert(0, defaultDevice);
            }

            if (pbDevs.Count == 0) {
                MessageBox.Show("No (enabled) audio devices found!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ChannelFrame cf = null;
            for (int i = 0; i < pbDevs.Count; i++) {
                CoreAudioDevice dev = pbDevs[i];

                cf = new ChannelFrame(this, dev, pbDevs.Count);
                cf.Parent = panel1;
                panel1.Controls.Add(cf);
                cf.Left = i * cf.Width;
            }

            if (cf == null) {

            } else {
                cf.labelBevel.Visible = false;
                Width = cf.Right;
                Height = cf.Height;
            }
            
            Left = MousePosition.X - Width / 2;
            int right = Left + Width;

            var tbPos = Taskbar.GetLocation();
            if (tbPos == TaskBarLocation.BOTTOM || tbPos == TaskBarLocation.RIGHT || tbPos == TaskBarLocation.TOP) {
                if (Left+Width > Screen.PrimaryScreen.WorkingArea.Right)
                    Left = Screen.PrimaryScreen.WorkingArea.Width - Width;

                if (tbPos == TaskBarLocation.TOP)
                    Top = Screen.PrimaryScreen.WorkingArea.Y;
                else
                    Top = Screen.PrimaryScreen.WorkingArea.Height - Height;
                            
            } else if (tbPos == TaskBarLocation.LEFT) {
                if (Left < Screen.PrimaryScreen.WorkingArea.X)
                    Left = Screen.PrimaryScreen.WorkingArea.X;
                Top = Screen.PrimaryScreen.WorkingArea.Height - Height;
            } 

            this.Deactivate += Form1_Deactivate;
            Visible = true;
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {            
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {            
            Visible = false;            
            Deactivate -= Form1_Deactivate;            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        internal static void launchSoundCpl(string arg = "")
        {
            try {
                string mmCplArgs = "shell32.dll,Control_RunDLL mmsys.cpl" + arg;
                Process.Start(Environment.SystemDirectory + "\\rundll32.exe", mmCplArgs);
            } catch (Exception exc) {
                MessageBox.Show(exc.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void soundPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            launchSoundCpl();
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                reShow();

                BringToFront();
                Activate();
            }
        }
    }
}
