namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.Units
{
    partial class AddUnitForm
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
            this.UpdateText_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.UnitName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.UnitName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.UnitCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.UnitCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.SuspendLayout();
            // 
            // UpdateText_lbl
            // 
            this.UpdateText_lbl.AutoSize = true;
            this.UpdateText_lbl.ControlId = null;
            this.UpdateText_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.UpdateText_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UpdateText_lbl.Location = new System.Drawing.Point(11, 107);
            this.UpdateText_lbl.Name = "UpdateText_lbl";
            this.UpdateText_lbl.Size = new System.Drawing.Size(72, 15);
            this.UpdateText_lbl.TabIndex = 32;
            this.UpdateText_lbl.Text = "Update Unit";
            this.UpdateText_lbl.Visible = false;
            // 
            // labelCommon1
            // 
            this.labelCommon1.AutoSize = true;
            this.labelCommon1.ControlId = null;
            this.labelCommon1.Font = new System.Drawing.Font("Arial", 9F);
            this.labelCommon1.ForeColor = System.Drawing.Color.DarkRed;
            this.labelCommon1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCommon1.Location = new System.Drawing.Point(365, 171);
            this.labelCommon1.Name = "labelCommon1";
            this.labelCommon1.Size = new System.Drawing.Size(27, 15);
            this.labelCommon1.TabIndex = 30;
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
            this.labelCommon2.Location = new System.Drawing.Point(365, 129);
            this.labelCommon2.Name = "labelCommon2";
            this.labelCommon2.Size = new System.Drawing.Size(27, 15);
            this.labelCommon2.TabIndex = 31;
            this.labelCommon2.Text = "(＊)";
            this.labelCommon2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Exit_btn
            // 
            this.Exit_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Exit_btn.ControlId = null;
            this.Exit_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Exit_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Exit_btn.Location = new System.Drawing.Point(253, 211);
            this.Exit_btn.Name = "Exit_btn";
            this.Exit_btn.Size = new System.Drawing.Size(80, 33);
            this.Exit_btn.TabIndex = 29;
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
            this.Ok_btn.Location = new System.Drawing.Point(146, 211);
            this.Ok_btn.Name = "Ok_btn";
            this.Ok_btn.Size = new System.Drawing.Size(80, 33);
            this.Ok_btn.TabIndex = 28;
            this.Ok_btn.Text = "OK";
            this.Ok_btn.UseVisualStyleBackColor = true;
            this.Ok_btn.Click += new System.EventHandler(this.Ok_btn_Click);
            // 
            // UnitName_txt
            // 
            this.UnitName_txt.ControlId = null;
            this.UnitName_txt.Font = new System.Drawing.Font("Arial", 9F);
            this.UnitName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.UnitName_txt.Location = new System.Drawing.Point(178, 169);
            this.UnitName_txt.MaxLength = 32;
            this.UnitName_txt.Name = "UnitName_txt";
            this.UnitName_txt.Size = new System.Drawing.Size(187, 21);
            this.UnitName_txt.TabIndex = 27;
            // 
            // UnitName_lbl
            // 
            this.UnitName_lbl.AutoSize = true;
            this.UnitName_lbl.ControlId = null;
            this.UnitName_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.UnitName_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UnitName_lbl.Location = new System.Drawing.Point(94, 172);
            this.UnitName_lbl.Name = "UnitName_lbl";
            this.UnitName_lbl.Size = new System.Drawing.Size(66, 15);
            this.UnitName_lbl.TabIndex = 26;
            this.UnitName_lbl.Text = "Unit Name";
            // 
            // UnitCode_txt
            // 
            this.UnitCode_txt.ControlId = null;
            this.UnitCode_txt.Font = new System.Drawing.Font("Arial", 9F);
            this.UnitCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.UnitCode_txt.Location = new System.Drawing.Point(178, 126);
            this.UnitCode_txt.MaxLength = 32;
            this.UnitCode_txt.Name = "UnitCode_txt";
            this.UnitCode_txt.Size = new System.Drawing.Size(187, 21);
            this.UnitCode_txt.TabIndex = 25;
            // 
            // UnitCode_lbl
            // 
            this.UnitCode_lbl.AutoSize = true;
            this.UnitCode_lbl.ControlId = null;
            this.UnitCode_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.UnitCode_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UnitCode_lbl.Location = new System.Drawing.Point(94, 129);
            this.UnitCode_lbl.Name = "UnitCode_lbl";
            this.UnitCode_lbl.Size = new System.Drawing.Size(62, 15);
            this.UnitCode_lbl.TabIndex = 24;
            this.UnitCode_lbl.Text = "Unit Code";
            // 
            // AddUnitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(457, 286);
            this.Controls.Add(this.UpdateText_lbl);
            this.Controls.Add(this.labelCommon1);
            this.Controls.Add(this.labelCommon2);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.UnitName_txt);
            this.Controls.Add(this.UnitName_lbl);
            this.Controls.Add(this.UnitCode_txt);
            this.Controls.Add(this.UnitCode_lbl);
            this.Name = "AddUnitForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.AddUnitForm_Load);
            this.Controls.SetChildIndex(this.UnitCode_lbl, 0);
            this.Controls.SetChildIndex(this.UnitCode_txt, 0);
            this.Controls.SetChildIndex(this.UnitName_lbl, 0);
            this.Controls.SetChildIndex(this.UnitName_txt, 0);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.labelCommon2, 0);
            this.Controls.SetChildIndex(this.labelCommon1, 0);
            this.Controls.SetChildIndex(this.UpdateText_lbl, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.LabelCommon UpdateText_lbl;
        private Framework.LabelCommon labelCommon1;
        private Framework.LabelCommon labelCommon2;
        private Framework.ButtonCommon Exit_btn;
        private Framework.ButtonCommon Ok_btn;
        private Framework.TextBoxCommon UnitName_txt;
        private Framework.LabelCommon UnitName_lbl;
        private Framework.TextBoxCommon UnitCode_txt;
        private Framework.LabelCommon UnitCode_lbl;
    }
}
