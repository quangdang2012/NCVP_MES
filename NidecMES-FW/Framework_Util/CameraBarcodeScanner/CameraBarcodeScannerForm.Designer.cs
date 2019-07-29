using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Framework_Util
{
    partial class CameraBarcodeScannerForm
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraBarcodeScannerForm));
            this.Title_chc = new Com.Nidec.Mes.Framework.CommonHeaderControl();
            this.Camera_pbx = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Camera_pbx)).BeginInit();
            this.SuspendLayout();
            // 
            // Title_chc
            // 
            this.Title_chc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Title_chc.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title_chc.Location = new System.Drawing.Point(0, 0);
            this.Title_chc.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Title_chc.Name = "Title_chc";
            this.Title_chc.Size = new System.Drawing.Size(536, 70);
            this.Title_chc.TabIndex = 0;
            // 
            // Camera_pbx
            // 
            this.Camera_pbx.BackColor = System.Drawing.Color.LightGray;
            this.Camera_pbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Camera_pbx.Location = new System.Drawing.Point(0, 70);
            this.Camera_pbx.Name = "Camera_pbx";
            this.Camera_pbx.Size = new System.Drawing.Size(536, 434);
            this.Camera_pbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Camera_pbx.TabIndex = 3;
            this.Camera_pbx.TabStop = false;
            // 
            // CameraBarcodeScannerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(247)))), ((int)(((byte)(236)))));
            this.ClientSize = new System.Drawing.Size(536, 504);
            this.Controls.Add(this.Camera_pbx);
            this.Controls.Add(this.Title_chc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CameraBarcodeScannerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CameraBarcodeScannerForm";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CameraBarcodeScannerForm_FormClosing);
            this.Load += new System.EventHandler(this.CameraBarcodeScannerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Camera_pbx)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CommonHeaderControl Title_chc;
        private System.Windows.Forms.PictureBox Camera_pbx;
    }
}