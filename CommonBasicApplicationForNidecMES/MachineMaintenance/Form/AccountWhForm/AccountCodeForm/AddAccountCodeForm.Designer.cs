namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.AccountCodeForm
{
    partial class AddAccountCodeForm
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
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.AccountName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.AccountName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.AccountCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.AccountCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.SuspendLayout();
            // 
            // labelCommon1
            // 
            this.labelCommon1.AutoSize = true;
            this.labelCommon1.ControlId = null;
            this.labelCommon1.Font = new System.Drawing.Font("Arial", 9F);
            this.labelCommon1.ForeColor = System.Drawing.Color.DarkRed;
            this.labelCommon1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCommon1.Location = new System.Drawing.Point(322, 216);
            this.labelCommon1.Name = "labelCommon1";
            this.labelCommon1.Size = new System.Drawing.Size(27, 15);
            this.labelCommon1.TabIndex = 36;
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
            this.labelCommon2.Location = new System.Drawing.Point(322, 154);
            this.labelCommon2.Name = "labelCommon2";
            this.labelCommon2.Size = new System.Drawing.Size(27, 15);
            this.labelCommon2.TabIndex = 37;
            this.labelCommon2.Text = "(＊)";
            this.labelCommon2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AccountName_txt
            // 
            this.AccountName_txt.ControlId = null;
            this.AccountName_txt.Font = new System.Drawing.Font("Arial", 9F);
            this.AccountName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.AccountName_txt.Location = new System.Drawing.Point(135, 214);
            this.AccountName_txt.MaxLength = 64;
            this.AccountName_txt.Name = "AccountName_txt";
            this.AccountName_txt.Size = new System.Drawing.Size(187, 21);
            this.AccountName_txt.TabIndex = 35;
            // 
            // AccountName_lbl
            // 
            this.AccountName_lbl.AutoSize = true;
            this.AccountName_lbl.ControlId = null;
            this.AccountName_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.AccountName_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AccountName_lbl.Location = new System.Drawing.Point(34, 216);
            this.AccountName_lbl.Name = "AccountName_lbl";
            this.AccountName_lbl.Size = new System.Drawing.Size(87, 15);
            this.AccountName_lbl.TabIndex = 34;
            this.AccountName_lbl.Text = "Account Name";
            // 
            // AccountCode_txt
            // 
            this.AccountCode_txt.ControlId = null;
            this.AccountCode_txt.Font = new System.Drawing.Font("Arial", 9F);
            this.AccountCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.AccountCode_txt.Location = new System.Drawing.Point(135, 151);
            this.AccountCode_txt.MaxLength = 128;
            this.AccountCode_txt.Name = "AccountCode_txt";
            this.AccountCode_txt.Size = new System.Drawing.Size(187, 21);
            this.AccountCode_txt.TabIndex = 33;
            // 
            // AccountCode_lbl
            // 
            this.AccountCode_lbl.AutoSize = true;
            this.AccountCode_lbl.ControlId = null;
            this.AccountCode_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.AccountCode_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AccountCode_lbl.Location = new System.Drawing.Point(38, 157);
            this.AccountCode_lbl.Name = "AccountCode_lbl";
            this.AccountCode_lbl.Size = new System.Drawing.Size(83, 15);
            this.AccountCode_lbl.TabIndex = 32;
            this.AccountCode_lbl.Text = "Account Code";
            // 
            // Exit_btn
            // 
            this.Exit_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Exit_btn.ControlId = null;
            this.Exit_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Exit_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Exit_btn.Location = new System.Drawing.Point(225, 291);
            this.Exit_btn.Name = "Exit_btn";
            this.Exit_btn.Size = new System.Drawing.Size(80, 33);
            this.Exit_btn.TabIndex = 39;
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
            this.Ok_btn.Location = new System.Drawing.Point(118, 291);
            this.Ok_btn.Name = "Ok_btn";
            this.Ok_btn.Size = new System.Drawing.Size(80, 33);
            this.Ok_btn.TabIndex = 38;
            this.Ok_btn.Text = "OK";
            this.Ok_btn.UseVisualStyleBackColor = true;
            this.Ok_btn.Click += new System.EventHandler(this.Ok_btn_Click);
            // 
            // AddAccountCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(449, 378);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.labelCommon1);
            this.Controls.Add(this.labelCommon2);
            this.Controls.Add(this.AccountName_txt);
            this.Controls.Add(this.AccountName_lbl);
            this.Controls.Add(this.AccountCode_txt);
            this.Controls.Add(this.AccountCode_lbl);
            this.Name = "AddAccountCodeForm";
            this.Text = "Add Account Code";
            this.TitleText = "Add Account Code";
            this.Load += new System.EventHandler(this.AddAccountCodeForm_Load);
            this.Controls.SetChildIndex(this.AccountCode_lbl, 0);
            this.Controls.SetChildIndex(this.AccountCode_txt, 0);
            this.Controls.SetChildIndex(this.AccountName_lbl, 0);
            this.Controls.SetChildIndex(this.AccountName_txt, 0);
            this.Controls.SetChildIndex(this.labelCommon2, 0);
            this.Controls.SetChildIndex(this.labelCommon1, 0);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.LabelCommon labelCommon1;
        private Framework.LabelCommon labelCommon2;
        private Framework.TextBoxCommon AccountName_txt;
        private Framework.LabelCommon AccountName_lbl;
        private Framework.TextBoxCommon AccountCode_txt;
        private Framework.LabelCommon AccountCode_lbl;
        private Framework.ButtonCommon Exit_btn;
        private Framework.ButtonCommon Ok_btn;
    }
}
