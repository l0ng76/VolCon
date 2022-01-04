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
    public partial class Form : System.Windows.Forms.Form
    {
        CoreAudioController cc;

        const int PACK_HEIGHT = 85;
        const int MARGIN = 20;
        public Form()
        {
            InitializeComponent();
            Width = 20;
            cc = new CoreAudioController();                        
        }
        
        private void Form_Shown(object sender, EventArgs e)
        {
            Visible = false;            
        }

        void reshow()
        {
            Visible = false;

            panel1.Controls.Clear();

            var pbDevs = cc.GetDevices(AudioSwitcher.AudioApi.DeviceType.Playback, AudioSwitcher.AudioApi.DeviceState.Active).ToList();
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

                cf = new ChannelFrame(dev);
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

            var tbPos = Taskbar.GetLocation();
            if (tbPos == TaskBarLocation.BOTTOM || tbPos == TaskBarLocation.RIGHT) {
                Left = Screen.PrimaryScreen.WorkingArea.Width - Width;
                Top = Screen.PrimaryScreen.WorkingArea.Height - Height;
            } else if (tbPos == TaskBarLocation.TOP) {
                Left = Screen.PrimaryScreen.WorkingArea.Width - Width;
                Top = Screen.PrimaryScreen.WorkingArea.Y;
            } else if (tbPos == TaskBarLocation.LEFT) {
                Left = Screen.PrimaryScreen.WorkingArea.X;
                Top = Screen.PrimaryScreen.WorkingArea.Height - Height;
            } 

            this.Deactivate += Form1_Deactivate;
            Visible = true;
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            reshow();

            BringToFront();
            Activate();
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {            
            Visible = false;            
            Deactivate -= Form1_Deactivate;            
        }
    }
}
