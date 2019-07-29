namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    partial class AddDrawForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDrawForm));
            this.device_code_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.device_code_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.timereceive_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.model_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.model_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Cancel_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.OK_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.drawing_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.drawing_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.revision_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.revision_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.timereceive_dtp = new Com.Nidec.Mes.Framework.DateTimePickerCommon();
            this.Machine_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.machine_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.DrawType_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.DrawType_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.depart_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.depart_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.SuspendLayout();
            // 
            // device_code_txt
            // 
            this.device_code_txt.ControlId = null;
            resources.ApplyResources(this.device_code_txt, "device_code_txt");
            this.device_code_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.device_code_txt.Name = "device_code_txt";
            // 
            // device_code_lbl
            // 
            resources.ApplyResources(this.device_code_lbl, "device_code_lbl");
            this.device_code_lbl.ControlId = null;
            this.device_code_lbl.Name = "device_code_lbl";
            // 
            // timereceive_lbl
            // 
            resources.ApplyResources(this.timereceive_lbl, "timereceive_lbl");
            this.timereceive_lbl.ControlId = null;
            this.timereceive_lbl.Name = "timereceive_lbl";
            // 
            // model_cmb
            // 
            this.model_cmb.ControlId = null;
            resources.ApplyResources(this.model_cmb, "model_cmb");
            this.model_cmb.FormattingEnabled = true;
            this.model_cmb.Name = "model_cmb";
            this.model_cmb.SelectedIndexChanged += new System.EventHandler(this.model_cmb_SelectedIndexChanged);
            // 
            // model_lbl
            // 
            resources.ApplyResources(this.model_lbl, "model_lbl");
            this.model_lbl.ControlId = null;
            this.model_lbl.Name = "model_lbl";
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Cancel_btn.ControlId = null;
            resources.ApplyResources(this.Cancel_btn, "Cancel_btn");
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.UseVisualStyleBackColor = false;
            this.Cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // OK_btn
            // 
            this.OK_btn.BackColor = System.Drawing.SystemColors.Control;
            this.OK_btn.ControlId = null;
            resources.ApplyResources(this.OK_btn, "OK_btn");
            this.OK_btn.Name = "OK_btn";
            this.OK_btn.UseVisualStyleBackColor = false;
            this.OK_btn.Click += new System.EventHandler(this.OK_btn_Click);
            // 
            // drawing_cmb
            // 
            this.drawing_cmb.ControlId = null;
            resources.ApplyResources(this.drawing_cmb, "drawing_cmb");
            this.drawing_cmb.FormattingEnabled = true;
            this.drawing_cmb.Name = "drawing_cmb";
            this.drawing_cmb.SelectedIndexChanged += new System.EventHandler(this.drawing_cmb_SelectedIndexChanged);
            // 
            // drawing_lbl
            // 
            resources.ApplyResources(this.drawing_lbl, "drawing_lbl");
            this.drawing_lbl.ControlId = null;
            this.drawing_lbl.Name = "drawing_lbl";
            // 
            // revision_lbl
            // 
            resources.ApplyResources(this.revision_lbl, "revision_lbl");
            this.revision_lbl.ControlId = null;
            this.revision_lbl.Name = "revision_lbl";
            // 
            // revision_txt
            // 
            this.revision_txt.ControlId = null;
            resources.ApplyResources(this.revision_txt, "revision_txt");
            this.revision_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.revision_txt.Name = "revision_txt";
            // 
            // timereceive_dtp
            // 
            this.timereceive_dtp.BackColor = System.Drawing.SystemColors.Control;
            this.timereceive_dtp.ControlId = null;
            resources.ApplyResources(this.timereceive_dtp, "timereceive_dtp");
            this.timereceive_dtp.DisplayFormat = Com.Nidec.Mes.Framework.DateTimePickerCommon.DisplayFormatList.ShortDatePattern;
            this.timereceive_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timereceive_dtp.Name = "timereceive_dtp";
            // 
            // Machine_cmb
            // 
            resources.ApplyResources(this.Machine_cmb, "Machine_cmb");
            this.Machine_cmb.ControlId = null;
            this.Machine_cmb.FormattingEnabled = true;
            this.Machine_cmb.Name = "Machine_cmb";
            // 
            // machine_lbl
            // 
            resources.ApplyResources(this.machine_lbl, "machine_lbl");
            this.machine_lbl.ControlId = null;
            this.machine_lbl.Name = "machine_lbl";
            // 
            // DrawType_lbl
            // 
            resources.ApplyResources(this.DrawType_lbl, "DrawType_lbl");
            this.DrawType_lbl.ControlId = null;
            this.DrawType_lbl.Name = "DrawType_lbl";
            // 
            // DrawType_txt
            // 
            this.DrawType_txt.ControlId = null;
            resources.ApplyResources(this.DrawType_txt, "DrawType_txt");
            this.DrawType_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.DrawType_txt.Name = "DrawType_txt";
            // 
            // depart_lbl
            // 
            resources.ApplyResources(this.depart_lbl, "depart_lbl");
            this.depart_lbl.ControlId = null;
            this.depart_lbl.Name = "depart_lbl";
            // 
            // depart_txt
            // 
            this.depart_txt.ControlId = null;
            resources.ApplyResources(this.depart_txt, "depart_txt");
            this.depart_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.depart_txt.Name = "depart_txt";
            // 
            // AddDrawForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.depart_lbl);
            this.Controls.Add(this.Machine_cmb);
            this.Controls.Add(this.machine_lbl);
            this.Controls.Add(this.timereceive_dtp);
            this.Controls.Add(this.revision_txt);
            this.Controls.Add(this.drawing_cmb);
            this.Controls.Add(this.drawing_lbl);
            this.Controls.Add(this.revision_lbl);
            this.Controls.Add(this.Cancel_btn);
            this.Controls.Add(this.OK_btn);
            this.Controls.Add(this.depart_txt);
            this.Controls.Add(this.DrawType_txt);
            this.Controls.Add(this.DrawType_lbl);
            this.Controls.Add(this.device_code_txt);
            this.Controls.Add(this.device_code_lbl);
            this.Controls.Add(this.timereceive_lbl);
            this.Controls.Add(this.model_cmb);
            this.Controls.Add(this.model_lbl);
            this.Name = "AddDrawForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.AddJigDrawForm_Load);
            this.Controls.SetChildIndex(this.model_lbl, 0);
            this.Controls.SetChildIndex(this.model_cmb, 0);
            this.Controls.SetChildIndex(this.timereceive_lbl, 0);
            this.Controls.SetChildIndex(this.device_code_lbl, 0);
            this.Controls.SetChildIndex(this.device_code_txt, 0);
            this.Controls.SetChildIndex(this.DrawType_lbl, 0);
            this.Controls.SetChildIndex(this.DrawType_txt, 0);
            this.Controls.SetChildIndex(this.depart_txt, 0);
            this.Controls.SetChildIndex(this.OK_btn, 0);
            this.Controls.SetChildIndex(this.Cancel_btn, 0);
            this.Controls.SetChildIndex(this.revision_lbl, 0);
            this.Controls.SetChildIndex(this.drawing_lbl, 0);
            this.Controls.SetChildIndex(this.drawing_cmb, 0);
            this.Controls.SetChildIndex(this.revision_txt, 0);
            this.Controls.SetChildIndex(this.timereceive_dtp, 0);
            this.Controls.SetChildIndex(this.machine_lbl, 0);
            this.Controls.SetChildIndex(this.Machine_cmb, 0);
            this.Controls.SetChildIndex(this.depart_lbl, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.TextBoxCommon device_code_txt;
        private Framework.LabelCommon device_code_lbl;
        private Framework.LabelCommon timereceive_lbl;
        private Framework.ComboBoxCommon model_cmb;
        private Framework.LabelCommon model_lbl;
        private Framework.ButtonCommon Cancel_btn;
        private Framework.ButtonCommon OK_btn;
        private Framework.ComboBoxCommon drawing_cmb;
        private Framework.LabelCommon drawing_lbl;
        private Framework.LabelCommon revision_lbl;
        private Framework.TextBoxCommon revision_txt;
        private Framework.DateTimePickerCommon timereceive_dtp;
        private Framework.ComboBoxCommon Machine_cmb;
        private Framework.LabelCommon machine_lbl;
        private Framework.LabelCommon DrawType_lbl;
        private Framework.TextBoxCommon DrawType_txt;
        private Framework.LabelCommon depart_lbl;
        private Framework.TextBoxCommon depart_txt;
    }
}
