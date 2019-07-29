namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.Rank
{
    partial class AddRankForm
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
            this.RankName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.RankName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.RankCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.RankCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
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
            this.UpdateText_lbl.Size = new System.Drawing.Size(79, 15);
            this.UpdateText_lbl.TabIndex = 32;
            this.UpdateText_lbl.Text = "Update Rank";
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
            // RankName_txt
            // 
            this.RankName_txt.ControlId = null;
            this.RankName_txt.Font = new System.Drawing.Font("Arial", 9F);
            this.RankName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.RankName_txt.Location = new System.Drawing.Point(178, 169);
            this.RankName_txt.MaxLength = 32;
            this.RankName_txt.Name = "RankName_txt";
            this.RankName_txt.Size = new System.Drawing.Size(187, 21);
            this.RankName_txt.TabIndex = 27;
            // 
            // RankName_lbl
            // 
            this.RankName_lbl.AutoSize = true;
            this.RankName_lbl.ControlId = null;
            this.RankName_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.RankName_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RankName_lbl.Location = new System.Drawing.Point(94, 172);
            this.RankName_lbl.Name = "RankName_lbl";
            this.RankName_lbl.Size = new System.Drawing.Size(73, 15);
            this.RankName_lbl.TabIndex = 26;
            this.RankName_lbl.Text = "Rank Name";
            // 
            // RankCode_txt
            // 
            this.RankCode_txt.ControlId = null;
            this.RankCode_txt.Font = new System.Drawing.Font("Arial", 9F);
            this.RankCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.RankCode_txt.Location = new System.Drawing.Point(178, 126);
            this.RankCode_txt.MaxLength = 32;
            this.RankCode_txt.Name = "RankCode_txt";
            this.RankCode_txt.Size = new System.Drawing.Size(187, 21);
            this.RankCode_txt.TabIndex = 25;
            // 
            // RankCode_lbl
            // 
            this.RankCode_lbl.AutoSize = true;
            this.RankCode_lbl.ControlId = null;
            this.RankCode_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.RankCode_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RankCode_lbl.Location = new System.Drawing.Point(94, 129);
            this.RankCode_lbl.Name = "RankCode_lbl";
            this.RankCode_lbl.Size = new System.Drawing.Size(69, 15);
            this.RankCode_lbl.TabIndex = 24;
            this.RankCode_lbl.Text = "Rank Code";
            // 
            // AddRankForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(457, 286);
            this.Controls.Add(this.UpdateText_lbl);
            this.Controls.Add(this.labelCommon1);
            this.Controls.Add(this.labelCommon2);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.RankName_txt);
            this.Controls.Add(this.RankName_lbl);
            this.Controls.Add(this.RankCode_txt);
            this.Controls.Add(this.RankCode_lbl);
            this.Name = "AddRankForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.AddRankForm_Load);
            this.Controls.SetChildIndex(this.RankCode_lbl, 0);
            this.Controls.SetChildIndex(this.RankCode_txt, 0);
            this.Controls.SetChildIndex(this.RankName_lbl, 0);
            this.Controls.SetChildIndex(this.RankName_txt, 0);
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
        private Framework.TextBoxCommon RankName_txt;
        private Framework.LabelCommon RankName_lbl;
        private Framework.TextBoxCommon RankCode_txt;
        private Framework.LabelCommon RankCode_lbl;
    }
}
