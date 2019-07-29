namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    partial class AddPlanWorkingStatusForm
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
            this.update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.section_cbm = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.section_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.total_machine_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.datetime_add_dtp = new Com.Nidec.Mes.Framework.DateTimePickerCommon();
            this.datetime_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.total_machine_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.plan_machine_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.plan_machine_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.rate_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.rate_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.SuspendLayout();
            // 
            // update_btn
            // 
            this.update_btn.BackColor = System.Drawing.SystemColors.Control;
            this.update_btn.ControlId = null;
            this.update_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.update_btn.Location = new System.Drawing.Point(73, 377);
            this.update_btn.Name = "update_btn";
            this.update_btn.Size = new System.Drawing.Size(80, 33);
            this.update_btn.TabIndex = 2;
            this.update_btn.Text = "Update";
            this.update_btn.UseVisualStyleBackColor = false;
            this.update_btn.Click += new System.EventHandler(this.update_btn_Click);
            // 
            // exit_btn
            // 
            this.exit_btn.BackColor = System.Drawing.SystemColors.Control;
            this.exit_btn.ControlId = null;
            this.exit_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.exit_btn.Location = new System.Drawing.Point(197, 377);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.Size = new System.Drawing.Size(80, 33);
            this.exit_btn.TabIndex = 2;
            this.exit_btn.Text = "Exit";
            this.exit_btn.UseVisualStyleBackColor = false;
            this.exit_btn.Click += new System.EventHandler(this.exit_btn_Click);
            // 
            // section_cbm
            // 
            this.section_cbm.ControlId = null;
            this.section_cbm.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.section_cbm.FormattingEnabled = true;
            this.section_cbm.Location = new System.Drawing.Point(135, 149);
            this.section_cbm.Name = "section_cbm";
            this.section_cbm.Size = new System.Drawing.Size(124, 23);
            this.section_cbm.TabIndex = 3;
            this.section_cbm.SelectedIndexChanged += new System.EventHandler(this.section_cbm_SelectedIndexChanged);
            // 
            // section_lbl
            // 
            this.section_lbl.AutoSize = true;
            this.section_lbl.ControlId = null;
            this.section_lbl.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.section_lbl.Location = new System.Drawing.Point(78, 157);
            this.section_lbl.Name = "section_lbl";
            this.section_lbl.Size = new System.Drawing.Size(51, 15);
            this.section_lbl.TabIndex = 4;
            this.section_lbl.Text = "Section:";
            // 
            // total_machine_txt
            // 
            this.total_machine_txt.ControlId = null;
            this.total_machine_txt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_machine_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.Numeric;
            this.total_machine_txt.Location = new System.Drawing.Point(135, 238);
            this.total_machine_txt.Name = "total_machine_txt";
            this.total_machine_txt.Size = new System.Drawing.Size(124, 21);
            this.total_machine_txt.TabIndex = 5;
            // 
            // datetime_add_dtp
            // 
            this.datetime_add_dtp.BackColor = System.Drawing.SystemColors.Control;
            this.datetime_add_dtp.ControlId = null;
            this.datetime_add_dtp.DisplayFormat = Com.Nidec.Mes.Framework.DateTimePickerCommon.DisplayFormatList.ShortDatePattern;
            this.datetime_add_dtp.Font = new System.Drawing.Font("Arial", 9F);
            this.datetime_add_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datetime_add_dtp.Location = new System.Drawing.Point(135, 192);
            this.datetime_add_dtp.Name = "datetime_add_dtp";
            this.datetime_add_dtp.Size = new System.Drawing.Size(124, 21);
            this.datetime_add_dtp.TabIndex = 6;
            // 
            // datetime_lbl
            // 
            this.datetime_lbl.AutoSize = true;
            this.datetime_lbl.ControlId = null;
            this.datetime_lbl.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datetime_lbl.Location = new System.Drawing.Point(70, 198);
            this.datetime_lbl.Name = "datetime_lbl";
            this.datetime_lbl.Size = new System.Drawing.Size(59, 15);
            this.datetime_lbl.TabIndex = 7;
            this.datetime_lbl.Text = "Date Add:";
            // 
            // total_machine_lbl
            // 
            this.total_machine_lbl.AutoSize = true;
            this.total_machine_lbl.ControlId = null;
            this.total_machine_lbl.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_machine_lbl.Location = new System.Drawing.Point(44, 241);
            this.total_machine_lbl.Name = "total_machine_lbl";
            this.total_machine_lbl.Size = new System.Drawing.Size(85, 15);
            this.total_machine_lbl.TabIndex = 7;
            this.total_machine_lbl.Text = "Total Machine:";
            // 
            // plan_machine_txt
            // 
            this.plan_machine_txt.ControlId = null;
            this.plan_machine_txt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plan_machine_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.Numeric;
            this.plan_machine_txt.Location = new System.Drawing.Point(135, 277);
            this.plan_machine_txt.Name = "plan_machine_txt";
            this.plan_machine_txt.Size = new System.Drawing.Size(124, 21);
            this.plan_machine_txt.TabIndex = 5;
            this.plan_machine_txt.TextChanged += new System.EventHandler(this.plan_machine_txt_TextChanged);
            // 
            // plan_machine_lbl
            // 
            this.plan_machine_lbl.AutoSize = true;
            this.plan_machine_lbl.ControlId = null;
            this.plan_machine_lbl.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plan_machine_lbl.Location = new System.Drawing.Point(45, 280);
            this.plan_machine_lbl.Name = "plan_machine_lbl";
            this.plan_machine_lbl.Size = new System.Drawing.Size(84, 15);
            this.plan_machine_lbl.TabIndex = 7;
            this.plan_machine_lbl.Text = "Plan Machine:";
            // 
            // rate_txt
            // 
            this.rate_txt.ControlId = null;
            this.rate_txt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rate_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.rate_txt.Location = new System.Drawing.Point(135, 317);
            this.rate_txt.Name = "rate_txt";
            this.rate_txt.Size = new System.Drawing.Size(124, 21);
            this.rate_txt.TabIndex = 5;
            // 
            // rate_lbl
            // 
            this.rate_lbl.AutoSize = true;
            this.rate_lbl.ControlId = null;
            this.rate_lbl.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rate_lbl.Location = new System.Drawing.Point(93, 320);
            this.rate_lbl.Name = "rate_lbl";
            this.rate_lbl.Size = new System.Drawing.Size(36, 15);
            this.rate_lbl.TabIndex = 7;
            this.rate_lbl.Text = "Rate:";
            // 
            // AddPlanWorkingStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(384, 422);
            this.Controls.Add(this.rate_lbl);
            this.Controls.Add(this.plan_machine_lbl);
            this.Controls.Add(this.total_machine_lbl);
            this.Controls.Add(this.datetime_lbl);
            this.Controls.Add(this.datetime_add_dtp);
            this.Controls.Add(this.rate_txt);
            this.Controls.Add(this.plan_machine_txt);
            this.Controls.Add(this.total_machine_txt);
            this.Controls.Add(this.section_lbl);
            this.Controls.Add(this.section_cbm);
            this.Controls.Add(this.exit_btn);
            this.Controls.Add(this.update_btn);
            this.Name = "AddPlanWorkingStatusForm";
            this.Text = "Add Plan";
            this.TitleText = "Add Plan";
            this.Load += new System.EventHandler(this.AddPlanWorkingStatusForm_Load);
            this.Controls.SetChildIndex(this.update_btn, 0);
            this.Controls.SetChildIndex(this.exit_btn, 0);
            this.Controls.SetChildIndex(this.section_cbm, 0);
            this.Controls.SetChildIndex(this.section_lbl, 0);
            this.Controls.SetChildIndex(this.total_machine_txt, 0);
            this.Controls.SetChildIndex(this.plan_machine_txt, 0);
            this.Controls.SetChildIndex(this.rate_txt, 0);
            this.Controls.SetChildIndex(this.datetime_add_dtp, 0);
            this.Controls.SetChildIndex(this.datetime_lbl, 0);
            this.Controls.SetChildIndex(this.total_machine_lbl, 0);
            this.Controls.SetChildIndex(this.plan_machine_lbl, 0);
            this.Controls.SetChildIndex(this.rate_lbl, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.ButtonCommon update_btn;
        private Framework.ButtonCommon exit_btn;
        private Framework.ComboBoxCommon section_cbm;
        private Framework.LabelCommon section_lbl;
        private Framework.TextBoxCommon total_machine_txt;
        private Framework.DateTimePickerCommon datetime_add_dtp;
        private Framework.LabelCommon datetime_lbl;
        private Framework.LabelCommon total_machine_lbl;
        private Framework.TextBoxCommon plan_machine_txt;
        private Framework.LabelCommon plan_machine_lbl;
        private Framework.TextBoxCommon rate_txt;
        private Framework.LabelCommon rate_lbl;
    }
}
