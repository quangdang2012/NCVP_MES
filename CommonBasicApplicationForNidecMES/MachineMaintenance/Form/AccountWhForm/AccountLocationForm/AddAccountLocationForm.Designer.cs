namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.AccountLocationForm
{
    partial class AddAccountLocationForm
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
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.AccountLocationName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.AccountLocationName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.AccountLocationCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.AccountLocationCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.AccountLocationType_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.AccountLocationType_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.labelCommon4 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.SuspendLayout();
            // 
            // Exit_btn
            // 
            this.Exit_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Exit_btn.ControlId = null;
            this.Exit_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Exit_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Exit_btn.Location = new System.Drawing.Point(246, 293);
            this.Exit_btn.Name = "Exit_btn";
            this.Exit_btn.Size = new System.Drawing.Size(80, 33);
            this.Exit_btn.TabIndex = 47;
            this.Exit_btn.Text = "Exit";
            this.Exit_btn.UseVisualStyleBackColor = true;
            this.Exit_btn.Click += new System.EventHandler(this.Exit_btn_Click);
            // 
            // Ok_btn
            // 
            this.Ok_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Ok_btn.ControlId = null;
            this.Ok_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Ok_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Ok_btn.Location = new System.Drawing.Point(139, 293);
            this.Ok_btn.Name = "Ok_btn";
            this.Ok_btn.Size = new System.Drawing.Size(80, 33);
            this.Ok_btn.TabIndex = 46;
            this.Ok_btn.Text = "OK";
            this.Ok_btn.UseVisualStyleBackColor = true;
            this.Ok_btn.Click += new System.EventHandler(this.Ok_btn_Click);
            // 
            // labelCommon1
            // 
            this.labelCommon1.AutoSize = true;
            this.labelCommon1.ControlId = null;
            this.labelCommon1.Font = new System.Drawing.Font("Arial", 9F);
            this.labelCommon1.ForeColor = System.Drawing.Color.DarkRed;
            this.labelCommon1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCommon1.Location = new System.Drawing.Point(359, 199);
            this.labelCommon1.Name = "labelCommon1";
            this.labelCommon1.Size = new System.Drawing.Size(27, 15);
            this.labelCommon1.TabIndex = 44;
            this.labelCommon1.Text = "(＊)";
            this.labelCommon1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCommon2
            // 
            this.labelCommon2.AutoSize = true;
            this.labelCommon2.ControlId = null;
            this.labelCommon2.Font = new System.Drawing.Font("Arial", 9F);
            this.labelCommon2.ForeColor = System.Drawing.Color.DarkRed;
            this.labelCommon2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCommon2.Location = new System.Drawing.Point(359, 154);
            this.labelCommon2.Name = "labelCommon2";
            this.labelCommon2.Size = new System.Drawing.Size(27, 15);
            this.labelCommon2.TabIndex = 45;
            this.labelCommon2.Text = "(＊)";
            this.labelCommon2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AccountLocationName_txt
            // 
            this.AccountLocationName_txt.ControlId = null;
            this.AccountLocationName_txt.Font = new System.Drawing.Font("Arial", 9F);
            this.AccountLocationName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.AccountLocationName_txt.Location = new System.Drawing.Point(172, 197);
            this.AccountLocationName_txt.MaxLength = 64;
            this.AccountLocationName_txt.Name = "AccountLocationName_txt";
            this.AccountLocationName_txt.Size = new System.Drawing.Size(187, 21);
            this.AccountLocationName_txt.TabIndex = 43;
            this.AccountLocationName_txt.TextChanged += new System.EventHandler(this.AccountLocationName_txt_TextChanged);
            // 
            // AccountLocationName_lbl
            // 
            this.AccountLocationName_lbl.AutoSize = true;
            this.AccountLocationName_lbl.ControlId = null;
            this.AccountLocationName_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.AccountLocationName_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AccountLocationName_lbl.Location = new System.Drawing.Point(27, 199);
            this.AccountLocationName_lbl.Name = "AccountLocationName_lbl";
            this.AccountLocationName_lbl.Size = new System.Drawing.Size(137, 15);
            this.AccountLocationName_lbl.TabIndex = 42;
            this.AccountLocationName_lbl.Text = "Account Location Name";
            // 
            // AccountLocationCode_txt
            // 
            this.AccountLocationCode_txt.ControlId = null;
            this.AccountLocationCode_txt.Font = new System.Drawing.Font("Arial", 9F);
            this.AccountLocationCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.AccountLocationCode_txt.Location = new System.Drawing.Point(172, 151);
            this.AccountLocationCode_txt.MaxLength = 128;
            this.AccountLocationCode_txt.Name = "AccountLocationCode_txt";
            this.AccountLocationCode_txt.Size = new System.Drawing.Size(187, 21);
            this.AccountLocationCode_txt.TabIndex = 41;
            // 
            // AccountLocationCode_lbl
            // 
            this.AccountLocationCode_lbl.AutoSize = true;
            this.AccountLocationCode_lbl.ControlId = null;
            this.AccountLocationCode_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.AccountLocationCode_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AccountLocationCode_lbl.Location = new System.Drawing.Point(31, 157);
            this.AccountLocationCode_lbl.Name = "AccountLocationCode_lbl";
            this.AccountLocationCode_lbl.Size = new System.Drawing.Size(133, 15);
            this.AccountLocationCode_lbl.TabIndex = 40;
            this.AccountLocationCode_lbl.Text = "Account Location Code";
            // 
            // AccountLocationType_lbl
            // 
            this.AccountLocationType_lbl.AutoSize = true;
            this.AccountLocationType_lbl.ControlId = null;
            this.AccountLocationType_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.AccountLocationType_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AccountLocationType_lbl.Location = new System.Drawing.Point(27, 240);
            this.AccountLocationType_lbl.Name = "AccountLocationType_lbl";
            this.AccountLocationType_lbl.Size = new System.Drawing.Size(131, 15);
            this.AccountLocationType_lbl.TabIndex = 42;
            this.AccountLocationType_lbl.Text = "Account Location Type:";
            // 
            // AccountLocationType_txt
            // 
            this.AccountLocationType_txt.ControlId = null;
            this.AccountLocationType_txt.Font = new System.Drawing.Font("Arial", 9F);
            this.AccountLocationType_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.AccountLocationType_txt.Location = new System.Drawing.Point(172, 238);
            this.AccountLocationType_txt.MaxLength = 64;
            this.AccountLocationType_txt.Name = "AccountLocationType_txt";
            this.AccountLocationType_txt.Size = new System.Drawing.Size(187, 21);
            this.AccountLocationType_txt.TabIndex = 43;
            // 
            // labelCommon4
            // 
            this.labelCommon4.AutoSize = true;
            this.labelCommon4.ControlId = null;
            this.labelCommon4.Font = new System.Drawing.Font("Arial", 9F);
            this.labelCommon4.ForeColor = System.Drawing.Color.DarkRed;
            this.labelCommon4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCommon4.Location = new System.Drawing.Point(359, 240);
            this.labelCommon4.Name = "labelCommon4";
            this.labelCommon4.Size = new System.Drawing.Size(27, 15);
            this.labelCommon4.TabIndex = 44;
            this.labelCommon4.Text = "(＊)";
            this.labelCommon4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddAccountLocationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(475, 365);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.labelCommon4);
            this.Controls.Add(this.labelCommon1);
            this.Controls.Add(this.labelCommon2);
            this.Controls.Add(this.AccountLocationType_txt);
            this.Controls.Add(this.AccountLocationType_lbl);
            this.Controls.Add(this.AccountLocationName_txt);
            this.Controls.Add(this.AccountLocationName_lbl);
            this.Controls.Add(this.AccountLocationCode_txt);
            this.Controls.Add(this.AccountLocationCode_lbl);
            this.Name = "AddAccountLocationForm";
            this.Text = "Add Account Location";
            this.TitleText = "Add Account Location";
            this.Load += new System.EventHandler(this.AddAccountLocationForm_Load);
            this.Controls.SetChildIndex(this.AccountLocationCode_lbl, 0);
            this.Controls.SetChildIndex(this.AccountLocationCode_txt, 0);
            this.Controls.SetChildIndex(this.AccountLocationName_lbl, 0);
            this.Controls.SetChildIndex(this.AccountLocationName_txt, 0);
            this.Controls.SetChildIndex(this.AccountLocationType_lbl, 0);
            this.Controls.SetChildIndex(this.AccountLocationType_txt, 0);
            this.Controls.SetChildIndex(this.labelCommon2, 0);
            this.Controls.SetChildIndex(this.labelCommon1, 0);
            this.Controls.SetChildIndex(this.labelCommon4, 0);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.ButtonCommon Exit_btn;
        private Framework.ButtonCommon Ok_btn;
        private Framework.LabelCommon labelCommon1;
        private Framework.LabelCommon labelCommon2;
        private Framework.TextBoxCommon AccountLocationName_txt;
        private Framework.LabelCommon AccountLocationName_lbl;
        private Framework.TextBoxCommon AccountLocationCode_txt;
        private Framework.LabelCommon AccountLocationCode_lbl;
        private Framework.LabelCommon AccountLocationType_lbl;
        private Framework.TextBoxCommon AccountLocationType_txt;
        private Framework.LabelCommon labelCommon4;
    }
}
