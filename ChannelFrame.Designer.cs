
namespace VolCon
{
    partial class ChannelFrame
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.trackBar1 = new VolCon.ChannelFrame.NoFocusTrackBar();
            this.label = new System.Windows.Forms.Label();
            this.labelBevel = new System.Windows.Forms.Label();
            this.labelVol = new System.Windows.Forms.Label();
            this.button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 10;
            this.trackBar1.Location = new System.Drawing.Point(20, 31);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 231);
            this.trackBar1.SmallChange = 5;
            this.trackBar1.TabIndex = 0;
            this.trackBar1.TabStop = false;
            this.trackBar1.TickFrequency = 10;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // label
            // 
            this.label.AutoEllipsis = true;
            this.label.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label.Location = new System.Drawing.Point(0, 338);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(81, 40);
            this.label.TabIndex = 1;
            this.label.Text = "label1";
            this.label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelBevel
            // 
            this.labelBevel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelBevel.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelBevel.Location = new System.Drawing.Point(81, 0);
            this.labelBevel.Name = "labelBevel";
            this.labelBevel.Size = new System.Drawing.Size(2, 378);
            this.labelBevel.TabIndex = 3;
            // 
            // labelVol
            // 
            this.labelVol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelVol.Location = new System.Drawing.Point(8, 10);
            this.labelVol.Name = "labelVol";
            this.labelVol.Size = new System.Drawing.Size(70, 18);
            this.labelVol.TabIndex = 4;
            this.labelVol.Text = "label1";
            this.labelVol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button
            // 
            this.button.BackColor = System.Drawing.Color.Transparent;
            this.button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(217)))));
            this.button.FlatAppearance.BorderSize = 0;
            this.button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button.Location = new System.Drawing.Point(9, 261);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(64, 64);
            this.button.TabIndex = 5;
            this.button.TabStop = false;
            this.button.Text = "img";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            this.button.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // ChannelFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.label);
            this.Controls.Add(this.button);
            this.Controls.Add(this.labelVol);
            this.Controls.Add(this.labelBevel);
            this.Controls.Add(this.trackBar1);
            this.Name = "ChannelFrame";
            this.Size = new System.Drawing.Size(83, 378);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label;
        internal System.Windows.Forms.Label labelBevel;
        private System.Windows.Forms.Label labelVol;
        private NoFocusTrackBar trackBar1;
        private System.Windows.Forms.Button button;
    }
}
