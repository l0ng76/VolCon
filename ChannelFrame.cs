using AudioSwitcher.AudioApi;
using AudioSwitcher.AudioApi.CoreAudio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VolCon
{
    public partial class ChannelFrame : UserControl, IObserver<DeviceVolumeChangedArgs>
    {
        CoreAudioDevice cad;

        Color defaultBackColor;
        internal class NoFocusTrackBar : System.Windows.Forms.TrackBar
        {
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            public extern static int SendMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

            private static int MakeParam(int loWord, int hiWord)
            {
                return (hiWord << 16) | (loWord & 0xffff);
            }

            protected override void OnGotFocus(EventArgs e)
            {
                base.OnGotFocus(e);
                SendMessage(this.Handle, 0x0128, MakeParam(1, 0x1), 0);
            }
        }

        [DllImport("Shell32.dll", EntryPoint = "ExtractIconExW", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern int ExtractIconEx(string sFile, int iIndex, out IntPtr piLargeVersion, out IntPtr piSmallVersion, int amountIcons);

        public ChannelFrame(CoreAudioDevice dev)
        {
            InitializeComponent();
            defaultBackColor = this.BackColor;

            cad = dev;
            label.Text = cad.Name;

            if (cad.IsDefaultDevice)
                label.Font = new Font(label.Font, label.Font.Style | FontStyle.Bold);

            updateControls((int)cad.Volume);
            
            try {
                string[] ipa = cad.IconPath.Split(',');
                if (ipa.Length == 2) {
                    Icon ic = IconExtractor.Extract(ipa[0], Convert.ToInt32(ipa[1]), true);
                    button.Image = ic.ToBitmap();
                    button.Text = "";
                    
                }
            } catch {
                button.Text = "no img";
            }

            cad.VolumeChanged.Subscribe(this);
        }
                
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {            
            cad.Volume = trackBar1.Value;                        
        }

        void updateControls(int volume)
        {           
            trackBar1.Value = volume;
            labelVol.Text = volume + " %";
        }

        public void OnNext(DeviceVolumeChangedArgs value)
        {
            Invoke(new Action(()=> {
                trackBar1.ValueChanged -= trackBar1_ValueChanged;
                updateControls((int)value.Volume);
                trackBar1.ValueChanged += trackBar1_ValueChanged;
            }));
        }

        public void OnError(Exception error)
        {
            //throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            //throw new NotImplementedException();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Form.launchSoundCpl(",,{0.0.0.00000000}.{" + cad.Id.ToString() + "},general");            
        }

        private void button_MouseEnter(object sender, EventArgs e)
        {
            button.FlatAppearance.BorderSize = 1;
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            button.FlatAppearance.BorderSize = 0;
        }
    }
}
