namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    partial class AddAcountMainForm
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
            this.user_location_name_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.user_location_code_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.Comment_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.comments_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.start_depreciation_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.start_depreciation_dtp = new Com.Nidec.Mes.Framework.DateTimePickerCommon();
            this.exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.unit_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.rank_code_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.location_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.unit_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.rank_code_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.location_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.UserCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.qty_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.asset_code_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.asset_model_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.account_code_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.account_code_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.section_cd_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.section_cd_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.acquisition_cost_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.end_depreciation_dtp = new Com.Nidec.Mes.Framework.DateTimePickerCommon();
            this.end_depreciation_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.value_gbc = new Com.Nidec.Mes.Framework.GroupBoxCommon();
            this.monthl_depreciation_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.net_value_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.accum_depreciation_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.current_depreciation_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.acquisition_cost_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.asset_life_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.accum_depreciation_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.current_depreciation_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.life_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.net_value_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.monthl_depreciation_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.datetime_view_dtp = new Com.Nidec.Mes.Framework.DateTimePickerCommon();
            this.datetime_view_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.no_cbm = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.no_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.user_location_name_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.asset_model_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.qty_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.asset_code_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.value_gbc.SuspendLayout();
            this.SuspendLayout();
            // 
            // user_location_name_lbl
            // 
            this.user_location_name_lbl.AutoSize = true;
            this.user_location_name_lbl.ControlId = null;
            this.user_location_name_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.user_location_name_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.user_location_name_lbl.Location = new System.Drawing.Point(15, 204);
            this.user_location_name_lbl.Name = "user_location_name_lbl";
            this.user_location_name_lbl.Size = new System.Drawing.Size(74, 15);
            this.user_location_name_lbl.TabIndex = 81;
            this.user_location_name_lbl.Text = "User Name:";
            // 
            // user_location_code_txt
            // 
            this.user_location_code_txt.ControlId = null;
            this.user_location_code_txt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_location_code_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.user_location_code_txt.Location = new System.Drawing.Point(99, 130);
            this.user_location_code_txt.MaxLength = 13;
            this.user_location_code_txt.Name = "user_location_code_txt";
            this.user_location_code_txt.Size = new System.Drawing.Size(152, 21);
            this.user_location_code_txt.TabIndex = 80;
            this.user_location_code_txt.UseSystemPasswordChar = true;
            this.user_location_code_txt.TextChanged += new System.EventHandler(this.user_location_code_txt_TextChanged);
            // 
            // Comment_lbl
            // 
            this.Comment_lbl.AutoSize = true;
            this.Comment_lbl.ControlId = null;
            this.Comment_lbl.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Comment_lbl.Location = new System.Drawing.Point(15, 413);
            this.Comment_lbl.Name = "Comment_lbl";
            this.Comment_lbl.Size = new System.Drawing.Size(65, 15);
            this.Comment_lbl.TabIndex = 79;
            this.Comment_lbl.Text = "Comment:";
            // 
            // comments_txt
            // 
            this.comments_txt.ControlId = null;
            this.comments_txt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comments_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.comments_txt.Location = new System.Drawing.Point(85, 413);
            this.comments_txt.Multiline = true;
            this.comments_txt.Name = "comments_txt";
            this.comments_txt.Size = new System.Drawing.Size(908, 64);
            this.comments_txt.TabIndex = 78;
            // 
            // start_depreciation_lbl
            // 
            this.start_depreciation_lbl.AutoSize = true;
            this.start_depreciation_lbl.ControlId = null;
            this.start_depreciation_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.start_depreciation_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.start_depreciation_lbl.Location = new System.Drawing.Point(760, 129);
            this.start_depreciation_lbl.Name = "start_depreciation_lbl";
            this.start_depreciation_lbl.Size = new System.Drawing.Size(108, 15);
            this.start_depreciation_lbl.TabIndex = 77;
            this.start_depreciation_lbl.Text = "Start Depreciation ";
            // 
            // start_depreciation_dtp
            // 
            this.start_depreciation_dtp.BackColor = System.Drawing.SystemColors.Control;
            this.start_depreciation_dtp.ControlId = null;
            this.start_depreciation_dtp.CustomFormat = "yyyy/MM/dd";
            this.start_depreciation_dtp.DisplayFormat = Com.Nidec.Mes.Framework.DateTimePickerCommon.DisplayFormatList.ShortDatePattern;
            this.start_depreciation_dtp.Font = new System.Drawing.Font("Arial", 9F);
            this.start_depreciation_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.start_depreciation_dtp.Location = new System.Drawing.Point(873, 126);
            this.start_depreciation_dtp.Name = "start_depreciation_dtp";
            this.start_depreciation_dtp.Size = new System.Drawing.Size(120, 21);
            this.start_depreciation_dtp.TabIndex = 76;
            this.start_depreciation_dtp.CloseUp += new System.EventHandler(this.start_depreciation_dtp_CloseUp);
            // 
            // exit_btn
            // 
            this.exit_btn.BackColor = System.Drawing.SystemColors.Control;
            this.exit_btn.ControlId = null;
            this.exit_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.exit_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.exit_btn.Location = new System.Drawing.Point(545, 496);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.Size = new System.Drawing.Size(110, 47);
            this.exit_btn.TabIndex = 75;
            this.exit_btn.Text = "Exit";
            this.exit_btn.UseVisualStyleBackColor = false;
            this.exit_btn.Click += new System.EventHandler(this.exit_btn_Click);
            // 
            // ok_btn
            // 
            this.ok_btn.BackColor = System.Drawing.SystemColors.Control;
            this.ok_btn.ControlId = null;
            this.ok_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.ok_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ok_btn.Location = new System.Drawing.Point(336, 496);
            this.ok_btn.Name = "ok_btn";
            this.ok_btn.Size = new System.Drawing.Size(110, 47);
            this.ok_btn.TabIndex = 74;
            this.ok_btn.Text = "OK";
            this.ok_btn.UseVisualStyleBackColor = false;
            this.ok_btn.Click += new System.EventHandler(this.ok_btn_Click);
            // 
            // unit_lbl
            // 
            this.unit_lbl.AutoSize = true;
            this.unit_lbl.ControlId = null;
            this.unit_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.unit_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.unit_lbl.Location = new System.Drawing.Point(528, 169);
            this.unit_lbl.Name = "unit_lbl";
            this.unit_lbl.Size = new System.Drawing.Size(32, 15);
            this.unit_lbl.TabIndex = 70;
            this.unit_lbl.Text = "Unit:";
            // 
            // rank_code_lbl
            // 
            this.rank_code_lbl.AutoSize = true;
            this.rank_code_lbl.ControlId = null;
            this.rank_code_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.rank_code_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rank_code_lbl.Location = new System.Drawing.Point(272, 169);
            this.rank_code_lbl.Name = "rank_code_lbl";
            this.rank_code_lbl.Size = new System.Drawing.Size(72, 15);
            this.rank_code_lbl.TabIndex = 69;
            this.rank_code_lbl.Text = "Rank Code:";
            // 
            // location_cmb
            // 
            this.location_cmb.ControlId = null;
            this.location_cmb.Font = new System.Drawing.Font("Arial", 9F);
            this.location_cmb.FormattingEnabled = true;
            this.location_cmb.Location = new System.Drawing.Point(591, 201);
            this.location_cmb.Name = "location_cmb";
            this.location_cmb.Size = new System.Drawing.Size(152, 23);
            this.location_cmb.TabIndex = 68;
            // 
            // unit_cmb
            // 
            this.unit_cmb.ControlId = null;
            this.unit_cmb.Font = new System.Drawing.Font("Arial", 9F);
            this.unit_cmb.FormattingEnabled = true;
            this.unit_cmb.Location = new System.Drawing.Point(591, 164);
            this.unit_cmb.Name = "unit_cmb";
            this.unit_cmb.Size = new System.Drawing.Size(152, 23);
            this.unit_cmb.TabIndex = 66;
            this.unit_cmb.SelectedIndexChanged += new System.EventHandler(this.unit_cmb_SelectedIndexChanged);
            // 
            // rank_code_cmb
            // 
            this.rank_code_cmb.ControlId = null;
            this.rank_code_cmb.Font = new System.Drawing.Font("Arial", 9F);
            this.rank_code_cmb.FormattingEnabled = true;
            this.rank_code_cmb.Location = new System.Drawing.Point(359, 164);
            this.rank_code_cmb.Name = "rank_code_cmb";
            this.rank_code_cmb.Size = new System.Drawing.Size(152, 23);
            this.rank_code_cmb.TabIndex = 65;
            // 
            // location_lbl
            // 
            this.location_lbl.AutoSize = true;
            this.location_lbl.ControlId = null;
            this.location_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.location_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.location_lbl.Location = new System.Drawing.Point(528, 204);
            this.location_lbl.Name = "location_lbl";
            this.location_lbl.Size = new System.Drawing.Size(57, 15);
            this.location_lbl.TabIndex = 63;
            this.location_lbl.Text = "Location:";
            // 
            // UserCode_lbl
            // 
            this.UserCode_lbl.AutoSize = true;
            this.UserCode_lbl.ControlId = null;
            this.UserCode_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.UserCode_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UserCode_lbl.Location = new System.Drawing.Point(15, 132);
            this.UserCode_lbl.Name = "UserCode_lbl";
            this.UserCode_lbl.Size = new System.Drawing.Size(70, 15);
            this.UserCode_lbl.TabIndex = 62;
            this.UserCode_lbl.Text = "User Code:";
            // 
            // qty_lbl
            // 
            this.qty_lbl.AutoSize = true;
            this.qty_lbl.ControlId = null;
            this.qty_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.qty_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.qty_lbl.Location = new System.Drawing.Point(528, 134);
            this.qty_lbl.Name = "qty_lbl";
            this.qty_lbl.Size = new System.Drawing.Size(27, 15);
            this.qty_lbl.TabIndex = 64;
            this.qty_lbl.Text = "Qty:";
            // 
            // asset_code_lbl
            // 
            this.asset_code_lbl.AutoSize = true;
            this.asset_code_lbl.ControlId = null;
            this.asset_code_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.asset_code_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.asset_code_lbl.Location = new System.Drawing.Point(15, 169);
            this.asset_code_lbl.Name = "asset_code_lbl";
            this.asset_code_lbl.Size = new System.Drawing.Size(74, 15);
            this.asset_code_lbl.TabIndex = 61;
            this.asset_code_lbl.Text = "Asset Code:";
            // 
            // asset_model_lbl
            // 
            this.asset_model_lbl.AutoSize = true;
            this.asset_model_lbl.ControlId = null;
            this.asset_model_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.asset_model_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.asset_model_lbl.Location = new System.Drawing.Point(15, 242);
            this.asset_model_lbl.Name = "asset_model_lbl";
            this.asset_model_lbl.Size = new System.Drawing.Size(77, 15);
            this.asset_model_lbl.TabIndex = 81;
            this.asset_model_lbl.Text = "Asset Model:";
            // 
            // account_code_cmb
            // 
            this.account_code_cmb.ControlId = null;
            this.account_code_cmb.Font = new System.Drawing.Font("Arial", 9F);
            this.account_code_cmb.FormattingEnabled = true;
            this.account_code_cmb.Location = new System.Drawing.Point(359, 201);
            this.account_code_cmb.Name = "account_code_cmb";
            this.account_code_cmb.Size = new System.Drawing.Size(152, 23);
            this.account_code_cmb.TabIndex = 65;
            // 
            // account_code_lbl
            // 
            this.account_code_lbl.AutoSize = true;
            this.account_code_lbl.ControlId = null;
            this.account_code_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.account_code_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.account_code_lbl.Location = new System.Drawing.Point(272, 204);
            this.account_code_lbl.Name = "account_code_lbl";
            this.account_code_lbl.Size = new System.Drawing.Size(86, 15);
            this.account_code_lbl.TabIndex = 69;
            this.account_code_lbl.Text = "Account Code:";
            // 
            // section_cd_cmb
            // 
            this.section_cd_cmb.ControlId = null;
            this.section_cd_cmb.Font = new System.Drawing.Font("Arial", 9F);
            this.section_cd_cmb.FormattingEnabled = true;
            this.section_cd_cmb.Location = new System.Drawing.Point(359, 239);
            this.section_cd_cmb.Name = "section_cd_cmb";
            this.section_cd_cmb.Size = new System.Drawing.Size(152, 23);
            this.section_cd_cmb.TabIndex = 65;
            // 
            // section_cd_lbl
            // 
            this.section_cd_lbl.AutoSize = true;
            this.section_cd_lbl.ControlId = null;
            this.section_cd_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.section_cd_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.section_cd_lbl.Location = new System.Drawing.Point(272, 242);
            this.section_cd_lbl.Name = "section_cd_lbl";
            this.section_cd_lbl.Size = new System.Drawing.Size(84, 15);
            this.section_cd_lbl.TabIndex = 69;
            this.section_cd_lbl.Text = "Section Code:";
            // 
            // acquisition_cost_lbl
            // 
            this.acquisition_cost_lbl.AutoSize = true;
            this.acquisition_cost_lbl.ControlId = null;
            this.acquisition_cost_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.acquisition_cost_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.acquisition_cost_lbl.Location = new System.Drawing.Point(17, 68);
            this.acquisition_cost_lbl.Name = "acquisition_cost_lbl";
            this.acquisition_cost_lbl.Size = new System.Drawing.Size(102, 15);
            this.acquisition_cost_lbl.TabIndex = 64;
            this.acquisition_cost_lbl.Text = "Acquisition Cost: ";
            // 
            // end_depreciation_dtp
            // 
            this.end_depreciation_dtp.BackColor = System.Drawing.SystemColors.Control;
            this.end_depreciation_dtp.ControlId = null;
            this.end_depreciation_dtp.CustomFormat = "yyyy/MM/dd";
            this.end_depreciation_dtp.DisplayFormat = Com.Nidec.Mes.Framework.DateTimePickerCommon.DisplayFormatList.ShortDatePattern;
            this.end_depreciation_dtp.Font = new System.Drawing.Font("Arial", 9F);
            this.end_depreciation_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.end_depreciation_dtp.Location = new System.Drawing.Point(873, 164);
            this.end_depreciation_dtp.Name = "end_depreciation_dtp";
            this.end_depreciation_dtp.Size = new System.Drawing.Size(120, 21);
            this.end_depreciation_dtp.TabIndex = 76;
            // 
            // end_depreciation_lbl
            // 
            this.end_depreciation_lbl.AutoSize = true;
            this.end_depreciation_lbl.ControlId = null;
            this.end_depreciation_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.end_depreciation_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.end_depreciation_lbl.Location = new System.Drawing.Point(760, 167);
            this.end_depreciation_lbl.Name = "end_depreciation_lbl";
            this.end_depreciation_lbl.Size = new System.Drawing.Size(105, 15);
            this.end_depreciation_lbl.TabIndex = 77;
            this.end_depreciation_lbl.Text = "End Depreciation ";
            // 
            // value_gbc
            // 
            this.value_gbc.ControlId = null;
            this.value_gbc.Controls.Add(this.monthl_depreciation_txt);
            this.value_gbc.Controls.Add(this.net_value_txt);
            this.value_gbc.Controls.Add(this.accum_depreciation_txt);
            this.value_gbc.Controls.Add(this.current_depreciation_txt);
            this.value_gbc.Controls.Add(this.acquisition_cost_cmb);
            this.value_gbc.Controls.Add(this.asset_life_cmb);
            this.value_gbc.Controls.Add(this.accum_depreciation_lbl);
            this.value_gbc.Controls.Add(this.current_depreciation_lbl);
            this.value_gbc.Controls.Add(this.life_lbl);
            this.value_gbc.Controls.Add(this.net_value_lbl);
            this.value_gbc.Controls.Add(this.monthl_depreciation_lbl);
            this.value_gbc.Controls.Add(this.acquisition_cost_lbl);
            this.value_gbc.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.value_gbc.Location = new System.Drawing.Point(12, 275);
            this.value_gbc.Name = "value_gbc";
            this.value_gbc.Size = new System.Drawing.Size(907, 113);
            this.value_gbc.TabIndex = 83;
            this.value_gbc.TabStop = false;
            this.value_gbc.Text = "Value Cost";
            // 
            // monthl_depreciation_txt
            // 
            this.monthl_depreciation_txt.ControlId = null;
            this.monthl_depreciation_txt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthl_depreciation_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.monthl_depreciation_txt.Location = new System.Drawing.Point(425, 65);
            this.monthl_depreciation_txt.Name = "monthl_depreciation_txt";
            this.monthl_depreciation_txt.Size = new System.Drawing.Size(152, 21);
            this.monthl_depreciation_txt.TabIndex = 85;
            // 
            // net_value_txt
            // 
            this.net_value_txt.ControlId = null;
            this.net_value_txt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.net_value_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.net_value_txt.Location = new System.Drawing.Point(713, 65);
            this.net_value_txt.Name = "net_value_txt";
            this.net_value_txt.Size = new System.Drawing.Size(152, 21);
            this.net_value_txt.TabIndex = 85;
            // 
            // accum_depreciation_txt
            // 
            this.accum_depreciation_txt.ControlId = null;
            this.accum_depreciation_txt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accum_depreciation_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.accum_depreciation_txt.Location = new System.Drawing.Point(713, 26);
            this.accum_depreciation_txt.Name = "accum_depreciation_txt";
            this.accum_depreciation_txt.Size = new System.Drawing.Size(152, 21);
            this.accum_depreciation_txt.TabIndex = 85;
            // 
            // current_depreciation_txt
            // 
            this.current_depreciation_txt.ControlId = null;
            this.current_depreciation_txt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.current_depreciation_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.current_depreciation_txt.Location = new System.Drawing.Point(425, 27);
            this.current_depreciation_txt.Name = "current_depreciation_txt";
            this.current_depreciation_txt.Size = new System.Drawing.Size(152, 21);
            this.current_depreciation_txt.TabIndex = 85;
            // 
            // acquisition_cost_cmb
            // 
            this.acquisition_cost_cmb.ControlId = null;
            this.acquisition_cost_cmb.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acquisition_cost_cmb.FormattingEnabled = true;
            this.acquisition_cost_cmb.Location = new System.Drawing.Point(136, 65);
            this.acquisition_cost_cmb.Name = "acquisition_cost_cmb";
            this.acquisition_cost_cmb.Size = new System.Drawing.Size(152, 23);
            this.acquisition_cost_cmb.TabIndex = 84;
            // 
            // asset_life_cmb
            // 
            this.asset_life_cmb.ControlId = null;
            this.asset_life_cmb.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asset_life_cmb.FormattingEnabled = true;
            this.asset_life_cmb.Location = new System.Drawing.Point(136, 27);
            this.asset_life_cmb.Name = "asset_life_cmb";
            this.asset_life_cmb.Size = new System.Drawing.Size(152, 23);
            this.asset_life_cmb.TabIndex = 84;
            // 
            // accum_depreciation_lbl
            // 
            this.accum_depreciation_lbl.AutoSize = true;
            this.accum_depreciation_lbl.ControlId = null;
            this.accum_depreciation_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.accum_depreciation_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.accum_depreciation_lbl.Location = new System.Drawing.Point(594, 32);
            this.accum_depreciation_lbl.Name = "accum_depreciation_lbl";
            this.accum_depreciation_lbl.Size = new System.Drawing.Size(120, 15);
            this.accum_depreciation_lbl.TabIndex = 64;
            this.accum_depreciation_lbl.Text = "Accum Depreciation:";
            // 
            // current_depreciation_lbl
            // 
            this.current_depreciation_lbl.AutoSize = true;
            this.current_depreciation_lbl.ControlId = null;
            this.current_depreciation_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.current_depreciation_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.current_depreciation_lbl.Location = new System.Drawing.Point(301, 29);
            this.current_depreciation_lbl.Name = "current_depreciation_lbl";
            this.current_depreciation_lbl.Size = new System.Drawing.Size(124, 15);
            this.current_depreciation_lbl.TabIndex = 64;
            this.current_depreciation_lbl.Text = "Current Depreciation:";
            // 
            // life_lbl
            // 
            this.life_lbl.AutoSize = true;
            this.life_lbl.ControlId = null;
            this.life_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.life_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.life_lbl.Location = new System.Drawing.Point(54, 30);
            this.life_lbl.Name = "life_lbl";
            this.life_lbl.Size = new System.Drawing.Size(65, 15);
            this.life_lbl.TabIndex = 64;
            this.life_lbl.Text = "Life (Year):";
            // 
            // net_value_lbl
            // 
            this.net_value_lbl.AutoSize = true;
            this.net_value_lbl.ControlId = null;
            this.net_value_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.net_value_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.net_value_lbl.Location = new System.Drawing.Point(645, 68);
            this.net_value_lbl.Name = "net_value_lbl";
            this.net_value_lbl.Size = new System.Drawing.Size(62, 15);
            this.net_value_lbl.TabIndex = 64;
            this.net_value_lbl.Text = "Net Value:";
            // 
            // monthl_depreciation_lbl
            // 
            this.monthl_depreciation_lbl.AutoSize = true;
            this.monthl_depreciation_lbl.ControlId = null;
            this.monthl_depreciation_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.monthl_depreciation_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.monthl_depreciation_lbl.Location = new System.Drawing.Point(301, 68);
            this.monthl_depreciation_lbl.Name = "monthl_depreciation_lbl";
            this.monthl_depreciation_lbl.Size = new System.Drawing.Size(124, 15);
            this.monthl_depreciation_lbl.TabIndex = 64;
            this.monthl_depreciation_lbl.Text = "Monthly Depreciation:";
            // 
            // datetime_view_dtp
            // 
            this.datetime_view_dtp.BackColor = System.Drawing.SystemColors.Control;
            this.datetime_view_dtp.ControlId = null;
            this.datetime_view_dtp.CustomFormat = "yyyy/MM/dd";
            this.datetime_view_dtp.DisplayFormat = Com.Nidec.Mes.Framework.DateTimePickerCommon.DisplayFormatList.ShortDatePattern;
            this.datetime_view_dtp.Font = new System.Drawing.Font("Arial", 9F);
            this.datetime_view_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datetime_view_dtp.Location = new System.Drawing.Point(873, 204);
            this.datetime_view_dtp.Name = "datetime_view_dtp";
            this.datetime_view_dtp.Size = new System.Drawing.Size(120, 21);
            this.datetime_view_dtp.TabIndex = 76;
            this.datetime_view_dtp.CloseUp += new System.EventHandler(this.start_depreciation_dtp_CloseUp);
            // 
            // datetime_view_lbl
            // 
            this.datetime_view_lbl.AutoSize = true;
            this.datetime_view_lbl.ControlId = null;
            this.datetime_view_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.datetime_view_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.datetime_view_lbl.Location = new System.Drawing.Point(760, 208);
            this.datetime_view_lbl.Name = "datetime_view_lbl";
            this.datetime_view_lbl.Size = new System.Drawing.Size(93, 15);
            this.datetime_view_lbl.TabIndex = 77;
            this.datetime_view_lbl.Text = "DateTime View:";
            // 
            // no_cbm
            // 
            this.no_cbm.ControlId = null;
            this.no_cbm.Font = new System.Drawing.Font("Arial", 9F);
            this.no_cbm.FormattingEnabled = true;
            this.no_cbm.Location = new System.Drawing.Point(358, 129);
            this.no_cbm.Name = "no_cbm";
            this.no_cbm.Size = new System.Drawing.Size(152, 23);
            this.no_cbm.TabIndex = 65;
            this.no_cbm.SelectedIndexChanged += new System.EventHandler(this.no_cbm_SelectedIndexChanged);
            // 
            // no_lbl
            // 
            this.no_lbl.AutoSize = true;
            this.no_lbl.ControlId = null;
            this.no_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.no_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.no_lbl.Location = new System.Drawing.Point(272, 129);
            this.no_lbl.Name = "no_lbl";
            this.no_lbl.Size = new System.Drawing.Size(74, 15);
            this.no_lbl.TabIndex = 69;
            this.no_lbl.Text = "No Number:";
            // 
            // user_location_name_cmb
            // 
            this.user_location_name_cmb.ControlId = null;
            this.user_location_name_cmb.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_location_name_cmb.FormattingEnabled = true;
            this.user_location_name_cmb.Location = new System.Drawing.Point(99, 201);
            this.user_location_name_cmb.Name = "user_location_name_cmb";
            this.user_location_name_cmb.Size = new System.Drawing.Size(152, 23);
            this.user_location_name_cmb.TabIndex = 84;
            // 
            // asset_model_cmb
            // 
            this.asset_model_cmb.ControlId = null;
            this.asset_model_cmb.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asset_model_cmb.FormattingEnabled = true;
            this.asset_model_cmb.Location = new System.Drawing.Point(99, 239);
            this.asset_model_cmb.Name = "asset_model_cmb";
            this.asset_model_cmb.Size = new System.Drawing.Size(152, 23);
            this.asset_model_cmb.TabIndex = 84;
            // 
            // qty_txt
            // 
            this.qty_txt.ControlId = null;
            this.qty_txt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qty_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.Numeric;
            this.qty_txt.Location = new System.Drawing.Point(591, 130);
            this.qty_txt.Name = "qty_txt";
            this.qty_txt.Size = new System.Drawing.Size(152, 21);
            this.qty_txt.TabIndex = 85;
            // 
            // asset_code_txt
            // 
            this.asset_code_txt.ControlId = null;
            this.asset_code_txt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asset_code_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.asset_code_txt.Location = new System.Drawing.Point(99, 166);
            this.asset_code_txt.Name = "asset_code_txt";
            this.asset_code_txt.Size = new System.Drawing.Size(152, 21);
            this.asset_code_txt.TabIndex = 85;
            // 
            // AddAcountMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1001, 559);
            this.Controls.Add(this.asset_code_txt);
            this.Controls.Add(this.qty_txt);
            this.Controls.Add(this.asset_model_cmb);
            this.Controls.Add(this.user_location_name_cmb);
            this.Controls.Add(this.value_gbc);
            this.Controls.Add(this.asset_model_lbl);
            this.Controls.Add(this.user_location_name_lbl);
            this.Controls.Add(this.user_location_code_txt);
            this.Controls.Add(this.Comment_lbl);
            this.Controls.Add(this.comments_txt);
            this.Controls.Add(this.end_depreciation_lbl);
            this.Controls.Add(this.datetime_view_lbl);
            this.Controls.Add(this.start_depreciation_lbl);
            this.Controls.Add(this.end_depreciation_dtp);
            this.Controls.Add(this.datetime_view_dtp);
            this.Controls.Add(this.start_depreciation_dtp);
            this.Controls.Add(this.exit_btn);
            this.Controls.Add(this.ok_btn);
            this.Controls.Add(this.unit_lbl);
            this.Controls.Add(this.section_cd_lbl);
            this.Controls.Add(this.account_code_lbl);
            this.Controls.Add(this.no_lbl);
            this.Controls.Add(this.rank_code_lbl);
            this.Controls.Add(this.location_cmb);
            this.Controls.Add(this.unit_cmb);
            this.Controls.Add(this.section_cd_cmb);
            this.Controls.Add(this.account_code_cmb);
            this.Controls.Add(this.no_cbm);
            this.Controls.Add(this.rank_code_cmb);
            this.Controls.Add(this.location_lbl);
            this.Controls.Add(this.UserCode_lbl);
            this.Controls.Add(this.qty_lbl);
            this.Controls.Add(this.asset_code_lbl);
            this.Name = "AddAcountMainForm";
            this.Text = "Account Equipments";
            this.TitleText = "Add Account Equipments";
            this.Load += new System.EventHandler(this.AddAcountMainForm_Load);
            this.Controls.SetChildIndex(this.asset_code_lbl, 0);
            this.Controls.SetChildIndex(this.qty_lbl, 0);
            this.Controls.SetChildIndex(this.UserCode_lbl, 0);
            this.Controls.SetChildIndex(this.location_lbl, 0);
            this.Controls.SetChildIndex(this.rank_code_cmb, 0);
            this.Controls.SetChildIndex(this.no_cbm, 0);
            this.Controls.SetChildIndex(this.account_code_cmb, 0);
            this.Controls.SetChildIndex(this.section_cd_cmb, 0);
            this.Controls.SetChildIndex(this.unit_cmb, 0);
            this.Controls.SetChildIndex(this.location_cmb, 0);
            this.Controls.SetChildIndex(this.rank_code_lbl, 0);
            this.Controls.SetChildIndex(this.no_lbl, 0);
            this.Controls.SetChildIndex(this.account_code_lbl, 0);
            this.Controls.SetChildIndex(this.section_cd_lbl, 0);
            this.Controls.SetChildIndex(this.unit_lbl, 0);
            this.Controls.SetChildIndex(this.ok_btn, 0);
            this.Controls.SetChildIndex(this.exit_btn, 0);
            this.Controls.SetChildIndex(this.start_depreciation_dtp, 0);
            this.Controls.SetChildIndex(this.datetime_view_dtp, 0);
            this.Controls.SetChildIndex(this.end_depreciation_dtp, 0);
            this.Controls.SetChildIndex(this.start_depreciation_lbl, 0);
            this.Controls.SetChildIndex(this.datetime_view_lbl, 0);
            this.Controls.SetChildIndex(this.end_depreciation_lbl, 0);
            this.Controls.SetChildIndex(this.comments_txt, 0);
            this.Controls.SetChildIndex(this.Comment_lbl, 0);
            this.Controls.SetChildIndex(this.user_location_code_txt, 0);
            this.Controls.SetChildIndex(this.user_location_name_lbl, 0);
            this.Controls.SetChildIndex(this.asset_model_lbl, 0);
            this.Controls.SetChildIndex(this.value_gbc, 0);
            this.Controls.SetChildIndex(this.user_location_name_cmb, 0);
            this.Controls.SetChildIndex(this.asset_model_cmb, 0);
            this.Controls.SetChildIndex(this.qty_txt, 0);
            this.Controls.SetChildIndex(this.asset_code_txt, 0);
            this.value_gbc.ResumeLayout(false);
            this.value_gbc.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Framework.LabelCommon user_location_name_lbl;
        private Framework.TextBoxCommon user_location_code_txt;
        private Framework.LabelCommon Comment_lbl;
        private Framework.TextBoxCommon comments_txt;
        private Framework.LabelCommon start_depreciation_lbl;
        private Framework.DateTimePickerCommon start_depreciation_dtp;
        private Framework.ButtonCommon exit_btn;
        private Framework.ButtonCommon ok_btn;
        private Framework.LabelCommon unit_lbl;
        private Framework.LabelCommon rank_code_lbl;
        private Framework.ComboBoxCommon location_cmb;
        private Framework.ComboBoxCommon unit_cmb;
        private Framework.ComboBoxCommon rank_code_cmb;
        private Framework.LabelCommon location_lbl;
        private Framework.LabelCommon UserCode_lbl;
        private Framework.LabelCommon qty_lbl;
        private Framework.LabelCommon asset_code_lbl;
        private Framework.LabelCommon asset_model_lbl;
        private Framework.ComboBoxCommon account_code_cmb;
        private Framework.LabelCommon account_code_lbl;
        private Framework.ComboBoxCommon section_cd_cmb;
        private Framework.LabelCommon section_cd_lbl;
        private Framework.LabelCommon acquisition_cost_lbl;
        private Framework.DateTimePickerCommon end_depreciation_dtp;
        private Framework.LabelCommon end_depreciation_lbl;
        private Framework.GroupBoxCommon value_gbc;
        private Framework.LabelCommon accum_depreciation_lbl;
        private Framework.LabelCommon current_depreciation_lbl;
        private Framework.LabelCommon life_lbl;
        private Framework.LabelCommon net_value_lbl;
        private Framework.LabelCommon monthl_depreciation_lbl;
        private Framework.DateTimePickerCommon datetime_view_dtp;
        private Framework.LabelCommon datetime_view_lbl;
        private Framework.ComboBoxCommon no_cbm;
        private Framework.LabelCommon no_lbl;
        private Framework.ComboBoxCommon user_location_name_cmb;
        private Framework.ComboBoxCommon asset_model_cmb;
        private Framework.TextBoxCommon qty_txt;
        private Framework.TextBoxCommon asset_code_txt;
        private Framework.TextBoxCommon monthl_depreciation_txt;
        private Framework.TextBoxCommon accum_depreciation_txt;
        private Framework.TextBoxCommon current_depreciation_txt;
        private Framework.ComboBoxCommon acquisition_cost_cmb;
        private Framework.ComboBoxCommon asset_life_cmb;
        private Framework.TextBoxCommon net_value_txt;
    }
}
