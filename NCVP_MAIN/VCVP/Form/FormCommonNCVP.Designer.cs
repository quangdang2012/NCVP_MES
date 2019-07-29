using System;


namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    partial class FormCommonNCVP
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
            this.Title_pnl = new System.Windows.Forms.Panel();
            this.UserName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.FactoryCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Title_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Title_pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // Title_pnl
            // 
            this.Title_pnl.Controls.Add(this.UserName_lbl);
            this.Title_pnl.Controls.Add(this.FactoryCode_lbl);
            this.Title_pnl.Controls.Add(this.Title_lbl);
            this.Title_pnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title_pnl.Location = new System.Drawing.Point(0, 70);
            this.Title_pnl.Name = "Title_pnl";
            this.Title_pnl.Size = new System.Drawing.Size(512, 33);
            this.Title_pnl.TabIndex = 4;
            // 
            // UserName_lbl
            // 
            this.UserName_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UserName_lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.UserName_lbl.ControlId = null;
            this.UserName_lbl.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.UserName_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UserName_lbl.Location = new System.Drawing.Point(197, 0);
            this.UserName_lbl.Name = "UserName_lbl";
            this.UserName_lbl.Size = new System.Drawing.Size(315, 18);
            this.UserName_lbl.TabIndex = 4;
            this.UserName_lbl.Text = "User Name : ";
            this.UserName_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FactoryCode_lbl
            // 
            this.FactoryCode_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FactoryCode_lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.FactoryCode_lbl.ControlId = null;
            this.FactoryCode_lbl.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.FactoryCode_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.FactoryCode_lbl.Location = new System.Drawing.Point(197, 17);
            this.FactoryCode_lbl.Name = "FactoryCode_lbl";
            this.FactoryCode_lbl.Size = new System.Drawing.Size(315, 15);
            this.FactoryCode_lbl.TabIndex = 3;
            this.FactoryCode_lbl.Text = "Factory : ";
            this.FactoryCode_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Title_lbl
            // 
            this.Title_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Title_lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Title_lbl.ControlId = null;
            this.Title_lbl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.Title_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Title_lbl.Location = new System.Drawing.Point(-4, 0);
            this.Title_lbl.Name = "Title_lbl";
            this.Title_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Title_lbl.Size = new System.Drawing.Size(204, 33);
            this.Title_lbl.TabIndex = 0;
            this.Title_lbl.Text = "Title_lbl";
            this.Title_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormCommonNCVP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(512, 211);
            this.Controls.Add(this.Title_pnl);
            this.Name = "FormCommonNCVP";
            this.Load += new System.EventHandler(this.FormCommonNCVP_Load);
            this.Controls.SetChildIndex(this.Title_pnl, 0);
            this.Title_pnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

    

        #endregion

        private System.Windows.Forms.Panel Title_pnl;
        private Framework.LabelCommon UserName_lbl;
        private Framework.LabelCommon FactoryCode_lbl;
        private Framework.LabelCommon Title_lbl;
    }
}
