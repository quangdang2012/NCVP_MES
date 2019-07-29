namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    partial class ProductionControllerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductionControllerForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.model_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.model_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.line_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.line_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.timeto_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.timeto_dtp = new Com.Nidec.Mes.Framework.DateTimePickerCommon();
            this.timefrom_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.setting_gbc = new Com.Nidec.Mes.Framework.GroupBoxCommon();
            this.time_rab = new Com.Nidec.Mes.Framework.RadioButtonCommon();
            this.date_rab = new Com.Nidec.Mes.Framework.RadioButtonCommon();
            this.timefrom_dtp = new Com.Nidec.Mes.Framework.DateTimePickerCommon();
            this.production_controller_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStarday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInput = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOutCoreInRotor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOutRotorInMotor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOutput = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalNG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRateNG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHolderNG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAppCheck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFundou = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInsertCase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalNGMotor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRANG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSolder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSolderWire = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWingding = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalNGRotor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWelding = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalNGCore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.input_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.ng_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.output_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.extant_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.input_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.output_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.extant_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ng_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.groupBoxCommon2 = new Com.Nidec.Mes.Framework.GroupBoxCommon();
            this.linksave_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.browser_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.exportexcel_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.chart_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.groupBoxCommon1 = new Com.Nidec.Mes.Framework.GroupBoxCommon();
            this.groupBoxCommon3 = new Com.Nidec.Mes.Framework.GroupBoxCommon();
            this.person_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.groupBoxCommon4 = new Com.Nidec.Mes.Framework.GroupBoxCommon();
            this.groupBoxCommon5 = new Com.Nidec.Mes.Framework.GroupBoxCommon();
            this.sum_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.setting_gbc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.production_controller_dgv)).BeginInit();
            this.groupBoxCommon2.SuspendLayout();
            this.groupBoxCommon1.SuspendLayout();
            this.groupBoxCommon3.SuspendLayout();
            this.groupBoxCommon4.SuspendLayout();
            this.groupBoxCommon5.SuspendLayout();
            this.SuspendLayout();
            // 
            // model_lbl
            // 
            resources.ApplyResources(this.model_lbl, "model_lbl");
            this.model_lbl.ControlId = null;
            this.model_lbl.Name = "model_lbl";
            // 
            // model_cmb
            // 
            this.model_cmb.ControlId = null;
            resources.ApplyResources(this.model_cmb, "model_cmb");
            this.model_cmb.FormattingEnabled = true;
            this.model_cmb.Name = "model_cmb";
            // 
            // line_lbl
            // 
            resources.ApplyResources(this.line_lbl, "line_lbl");
            this.line_lbl.ControlId = null;
            this.line_lbl.Name = "line_lbl";
            // 
            // line_cmb
            // 
            this.line_cmb.ControlId = null;
            resources.ApplyResources(this.line_cmb, "line_cmb");
            this.line_cmb.FormattingEnabled = true;
            this.line_cmb.Name = "line_cmb";
            // 
            // timeto_lbl
            // 
            resources.ApplyResources(this.timeto_lbl, "timeto_lbl");
            this.timeto_lbl.ControlId = null;
            this.timeto_lbl.Name = "timeto_lbl";
            // 
            // timeto_dtp
            // 
            this.timeto_dtp.BackColor = System.Drawing.SystemColors.Control;
            this.timeto_dtp.ControlId = null;
            resources.ApplyResources(this.timeto_dtp, "timeto_dtp");
            this.timeto_dtp.DisplayFormat = Com.Nidec.Mes.Framework.DateTimePickerCommon.DisplayFormatList.ShortDatePattern;
            this.timeto_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeto_dtp.Name = "timeto_dtp";
            // 
            // timefrom_lbl
            // 
            resources.ApplyResources(this.timefrom_lbl, "timefrom_lbl");
            this.timefrom_lbl.ControlId = null;
            this.timefrom_lbl.Name = "timefrom_lbl";
            // 
            // search_btn
            // 
            this.search_btn.BackColor = System.Drawing.SystemColors.Control;
            this.search_btn.ControlId = null;
            resources.ApplyResources(this.search_btn, "search_btn");
            this.search_btn.Name = "search_btn";
            this.search_btn.UseVisualStyleBackColor = false;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // setting_gbc
            // 
            this.setting_gbc.ControlId = null;
            this.setting_gbc.Controls.Add(this.model_cmb);
            this.setting_gbc.Controls.Add(this.model_lbl);
            this.setting_gbc.Controls.Add(this.line_lbl);
            this.setting_gbc.Controls.Add(this.line_cmb);
            resources.ApplyResources(this.setting_gbc, "setting_gbc");
            this.setting_gbc.Name = "setting_gbc";
            this.setting_gbc.TabStop = false;
            // 
            // time_rab
            // 
            resources.ApplyResources(this.time_rab, "time_rab");
            this.time_rab.ControlId = null;
            this.time_rab.Name = "time_rab";
            this.time_rab.TabStop = true;
            this.time_rab.UseVisualStyleBackColor = true;
            this.time_rab.CheckedChanged += new System.EventHandler(this.time_rab_CheckedChanged);
            // 
            // date_rab
            // 
            resources.ApplyResources(this.date_rab, "date_rab");
            this.date_rab.ControlId = null;
            this.date_rab.Name = "date_rab";
            this.date_rab.TabStop = true;
            this.date_rab.UseVisualStyleBackColor = true;
            this.date_rab.CheckedChanged += new System.EventHandler(this.date_rab_CheckedChanged);
            // 
            // timefrom_dtp
            // 
            this.timefrom_dtp.BackColor = System.Drawing.SystemColors.Control;
            this.timefrom_dtp.ControlId = null;
            resources.ApplyResources(this.timefrom_dtp, "timefrom_dtp");
            this.timefrom_dtp.DisplayFormat = Com.Nidec.Mes.Framework.DateTimePickerCommon.DisplayFormatList.ShortDatePattern;
            this.timefrom_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timefrom_dtp.Name = "timefrom_dtp";
            // 
            // production_controller_dgv
            // 
            this.production_controller_dgv.AllowUserToAddRows = false;
            this.production_controller_dgv.AllowUserToDeleteRows = false;
            this.production_controller_dgv.AllowUserToOrderColumns = true;
            this.production_controller_dgv.AllowUserToResizeRows = false;
            this.production_controller_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.production_controller_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.production_controller_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.production_controller_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colModel,
            this.colLine,
            this.colStarday,
            this.colEndday,
            this.colInput,
            this.colOutCoreInRotor,
            this.colOutRotorInMotor,
            this.colOutput,
            this.colTotalNG,
            this.colRateNG,
            this.colHolderNG,
            this.colAppCheck,
            this.colEn2,
            this.colFundou,
            this.colEn1,
            this.colInsertCase,
            this.colTotalNGMotor,
            this.colRANG,
            this.colSolder,
            this.colSolderWire,
            this.colWingding,
            this.colTotalNGRotor,
            this.colWelding,
            this.colCore,
            this.colTotalNGCore});
            this.production_controller_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.production_controller_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.production_controller_dgv, "production_controller_dgv");
            this.production_controller_dgv.Name = "production_controller_dgv";
            this.production_controller_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.production_controller_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.production_controller_dgv.RowHeadersVisible = false;
            this.production_controller_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.production_controller_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.production_controller_dgv_CellClick);
            this.production_controller_dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.production_controller_dgv_CellContentClick);
            this.production_controller_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.production_controller_dgv_CellDoubleClick);
            // 
            // colModel
            // 
            this.colModel.DataPropertyName = "ProModel";
            resources.ApplyResources(this.colModel, "colModel");
            this.colModel.Name = "colModel";
            this.colModel.ReadOnly = true;
            // 
            // colLine
            // 
            this.colLine.DataPropertyName = "ProLine";
            resources.ApplyResources(this.colLine, "colLine");
            this.colLine.Name = "colLine";
            this.colLine.ReadOnly = true;
            // 
            // colStarday
            // 
            this.colStarday.DataPropertyName = "StartDay";
            resources.ApplyResources(this.colStarday, "colStarday");
            this.colStarday.Name = "colStarday";
            this.colStarday.ReadOnly = true;
            // 
            // colEndday
            // 
            this.colEndday.DataPropertyName = "EndDay";
            resources.ApplyResources(this.colEndday, "colEndday");
            this.colEndday.Name = "colEndday";
            this.colEndday.ReadOnly = true;
            // 
            // colInput
            // 
            this.colInput.DataPropertyName = "ProInput";
            resources.ApplyResources(this.colInput, "colInput");
            this.colInput.Name = "colInput";
            this.colInput.ReadOnly = true;
            // 
            // colOutCoreInRotor
            // 
            resources.ApplyResources(this.colOutCoreInRotor, "colOutCoreInRotor");
            this.colOutCoreInRotor.Name = "colOutCoreInRotor";
            this.colOutCoreInRotor.ReadOnly = true;
            // 
            // colOutRotorInMotor
            // 
            resources.ApplyResources(this.colOutRotorInMotor, "colOutRotorInMotor");
            this.colOutRotorInMotor.Name = "colOutRotorInMotor";
            this.colOutRotorInMotor.ReadOnly = true;
            // 
            // colOutput
            // 
            this.colOutput.DataPropertyName = "ProOutput";
            resources.ApplyResources(this.colOutput, "colOutput");
            this.colOutput.Name = "colOutput";
            this.colOutput.ReadOnly = true;
            // 
            // colTotalNG
            // 
            this.colTotalNG.DataPropertyName = "TotalNG";
            resources.ApplyResources(this.colTotalNG, "colTotalNG");
            this.colTotalNG.Name = "colTotalNG";
            this.colTotalNG.ReadOnly = true;
            // 
            // colRateNG
            // 
            resources.ApplyResources(this.colRateNG, "colRateNG");
            this.colRateNG.Name = "colRateNG";
            this.colRateNG.ReadOnly = true;
            // 
            // colHolderNG
            // 
            this.colHolderNG.DataPropertyName = "HolderNG";
            resources.ApplyResources(this.colHolderNG, "colHolderNG");
            this.colHolderNG.Name = "colHolderNG";
            this.colHolderNG.ReadOnly = true;
            // 
            // colAppCheck
            // 
            this.colAppCheck.DataPropertyName = "AppCheckNG";
            resources.ApplyResources(this.colAppCheck, "colAppCheck");
            this.colAppCheck.Name = "colAppCheck";
            this.colAppCheck.ReadOnly = true;
            // 
            // colEn2
            // 
            this.colEn2.DataPropertyName = "En2NG";
            resources.ApplyResources(this.colEn2, "colEn2");
            this.colEn2.Name = "colEn2";
            this.colEn2.ReadOnly = true;
            // 
            // colFundou
            // 
            this.colFundou.DataPropertyName = "FundouNG";
            resources.ApplyResources(this.colFundou, "colFundou");
            this.colFundou.Name = "colFundou";
            this.colFundou.ReadOnly = true;
            // 
            // colEn1
            // 
            this.colEn1.DataPropertyName = "En1NG";
            resources.ApplyResources(this.colEn1, "colEn1");
            this.colEn1.Name = "colEn1";
            this.colEn1.ReadOnly = true;
            // 
            // colInsertCase
            // 
            this.colInsertCase.DataPropertyName = "InsertCaseNG";
            resources.ApplyResources(this.colInsertCase, "colInsertCase");
            this.colInsertCase.Name = "colInsertCase";
            this.colInsertCase.ReadOnly = true;
            // 
            // colTotalNGMotor
            // 
            resources.ApplyResources(this.colTotalNGMotor, "colTotalNGMotor");
            this.colTotalNGMotor.Name = "colTotalNGMotor";
            this.colTotalNGMotor.ReadOnly = true;
            // 
            // colRANG
            // 
            this.colRANG.DataPropertyName = "RANG";
            resources.ApplyResources(this.colRANG, "colRANG");
            this.colRANG.Name = "colRANG";
            this.colRANG.ReadOnly = true;
            // 
            // colSolder
            // 
            this.colSolder.DataPropertyName = "SolderRingNG";
            resources.ApplyResources(this.colSolder, "colSolder");
            this.colSolder.Name = "colSolder";
            this.colSolder.ReadOnly = true;
            // 
            // colSolderWire
            // 
            this.colSolderWire.DataPropertyName = "SolderWireNG";
            resources.ApplyResources(this.colSolderWire, "colSolderWire");
            this.colSolderWire.Name = "colSolderWire";
            this.colSolderWire.ReadOnly = true;
            // 
            // colWingding
            // 
            this.colWingding.DataPropertyName = "WindingNG";
            resources.ApplyResources(this.colWingding, "colWingding");
            this.colWingding.Name = "colWingding";
            this.colWingding.ReadOnly = true;
            // 
            // colTotalNGRotor
            // 
            resources.ApplyResources(this.colTotalNGRotor, "colTotalNGRotor");
            this.colTotalNGRotor.Name = "colTotalNGRotor";
            this.colTotalNGRotor.ReadOnly = true;
            // 
            // colWelding
            // 
            this.colWelding.DataPropertyName = "WeldingNG";
            resources.ApplyResources(this.colWelding, "colWelding");
            this.colWelding.Name = "colWelding";
            this.colWelding.ReadOnly = true;
            // 
            // colCore
            // 
            this.colCore.DataPropertyName = "CoreNG";
            resources.ApplyResources(this.colCore, "colCore");
            this.colCore.Name = "colCore";
            this.colCore.ReadOnly = true;
            // 
            // colTotalNGCore
            // 
            resources.ApplyResources(this.colTotalNGCore, "colTotalNGCore");
            this.colTotalNGCore.Name = "colTotalNGCore";
            this.colTotalNGCore.ReadOnly = true;
            // 
            // total_lbl
            // 
            resources.ApplyResources(this.total_lbl, "total_lbl");
            this.total_lbl.ControlId = null;
            this.total_lbl.Name = "total_lbl";
            // 
            // input_lbl
            // 
            resources.ApplyResources(this.input_lbl, "input_lbl");
            this.input_lbl.ControlId = null;
            this.input_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.input_lbl.Name = "input_lbl";
            // 
            // ng_lbl
            // 
            resources.ApplyResources(this.ng_lbl, "ng_lbl");
            this.ng_lbl.ControlId = null;
            this.ng_lbl.ForeColor = System.Drawing.Color.Red;
            this.ng_lbl.Name = "ng_lbl";
            // 
            // output_lbl
            // 
            resources.ApplyResources(this.output_lbl, "output_lbl");
            this.output_lbl.ControlId = null;
            this.output_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.output_lbl.Name = "output_lbl";
            // 
            // extant_lbl
            // 
            resources.ApplyResources(this.extant_lbl, "extant_lbl");
            this.extant_lbl.ControlId = null;
            this.extant_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.extant_lbl.Name = "extant_lbl";
            // 
            // input_txt
            // 
            this.input_txt.BackColor = System.Drawing.Color.White;
            this.input_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.input_txt.ControlId = null;
            resources.ApplyResources(this.input_txt, "input_txt");
            this.input_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.input_txt.Name = "input_txt";
            this.input_txt.ReadOnly = true;
            // 
            // output_txt
            // 
            this.output_txt.BackColor = System.Drawing.Color.White;
            this.output_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.output_txt.ControlId = null;
            resources.ApplyResources(this.output_txt, "output_txt");
            this.output_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.output_txt.Name = "output_txt";
            this.output_txt.ReadOnly = true;
            // 
            // extant_txt
            // 
            this.extant_txt.BackColor = System.Drawing.Color.White;
            this.extant_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.extant_txt.ControlId = null;
            resources.ApplyResources(this.extant_txt, "extant_txt");
            this.extant_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.extant_txt.Name = "extant_txt";
            this.extant_txt.ReadOnly = true;
            // 
            // ng_txt
            // 
            this.ng_txt.BackColor = System.Drawing.Color.White;
            this.ng_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ng_txt.ControlId = null;
            resources.ApplyResources(this.ng_txt, "ng_txt");
            this.ng_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ng_txt.Name = "ng_txt";
            this.ng_txt.ReadOnly = true;
            // 
            // groupBoxCommon2
            // 
            this.groupBoxCommon2.ControlId = null;
            this.groupBoxCommon2.Controls.Add(this.linksave_txt);
            this.groupBoxCommon2.Controls.Add(this.browser_btn);
            this.groupBoxCommon2.Controls.Add(this.exportexcel_btn);
            resources.ApplyResources(this.groupBoxCommon2, "groupBoxCommon2");
            this.groupBoxCommon2.Name = "groupBoxCommon2";
            this.groupBoxCommon2.TabStop = false;
            // 
            // linksave_txt
            // 
            this.linksave_txt.ControlId = null;
            resources.ApplyResources(this.linksave_txt, "linksave_txt");
            this.linksave_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.linksave_txt.Name = "linksave_txt";
            // 
            // browser_btn
            // 
            this.browser_btn.BackColor = System.Drawing.SystemColors.Control;
            this.browser_btn.ControlId = null;
            resources.ApplyResources(this.browser_btn, "browser_btn");
            this.browser_btn.Name = "browser_btn";
            this.browser_btn.UseVisualStyleBackColor = false;
            this.browser_btn.Click += new System.EventHandler(this.browser_btn_Click);
            // 
            // exportexcel_btn
            // 
            this.exportexcel_btn.BackColor = System.Drawing.SystemColors.Control;
            this.exportexcel_btn.ControlId = null;
            resources.ApplyResources(this.exportexcel_btn, "exportexcel_btn");
            this.exportexcel_btn.Name = "exportexcel_btn";
            this.exportexcel_btn.UseVisualStyleBackColor = false;
            this.exportexcel_btn.Click += new System.EventHandler(this.exportexcel_btn_Click);
            // 
            // chart_btn
            // 
            this.chart_btn.BackColor = System.Drawing.SystemColors.Control;
            this.chart_btn.ControlId = null;
            resources.ApplyResources(this.chart_btn, "chart_btn");
            this.chart_btn.Name = "chart_btn";
            this.chart_btn.UseVisualStyleBackColor = false;
            this.chart_btn.Click += new System.EventHandler(this.chart_btn_Click);
            // 
            // groupBoxCommon1
            // 
            this.groupBoxCommon1.ControlId = null;
            this.groupBoxCommon1.Controls.Add(this.time_rab);
            this.groupBoxCommon1.Controls.Add(this.date_rab);
            this.groupBoxCommon1.Controls.Add(this.timeto_dtp);
            this.groupBoxCommon1.Controls.Add(this.timeto_lbl);
            this.groupBoxCommon1.Controls.Add(this.timefrom_dtp);
            this.groupBoxCommon1.Controls.Add(this.timefrom_lbl);
            resources.ApplyResources(this.groupBoxCommon1, "groupBoxCommon1");
            this.groupBoxCommon1.Name = "groupBoxCommon1";
            this.groupBoxCommon1.TabStop = false;
            // 
            // groupBoxCommon3
            // 
            this.groupBoxCommon3.ControlId = null;
            this.groupBoxCommon3.Controls.Add(this.person_btn);
            this.groupBoxCommon3.Controls.Add(this.search_btn);
            this.groupBoxCommon3.Controls.Add(this.chart_btn);
            resources.ApplyResources(this.groupBoxCommon3, "groupBoxCommon3");
            this.groupBoxCommon3.Name = "groupBoxCommon3";
            this.groupBoxCommon3.TabStop = false;
            // 
            // person_btn
            // 
            this.person_btn.BackColor = System.Drawing.SystemColors.Control;
            this.person_btn.ControlId = null;
            resources.ApplyResources(this.person_btn, "person_btn");
            this.person_btn.Name = "person_btn";
            this.person_btn.UseVisualStyleBackColor = false;
            this.person_btn.Click += new System.EventHandler(this.person_btn_Click);
            // 
            // groupBoxCommon4
            // 
            this.groupBoxCommon4.ControlId = null;
            this.groupBoxCommon4.Controls.Add(this.extant_txt);
            this.groupBoxCommon4.Controls.Add(this.total_lbl);
            this.groupBoxCommon4.Controls.Add(this.input_lbl);
            this.groupBoxCommon4.Controls.Add(this.output_lbl);
            this.groupBoxCommon4.Controls.Add(this.ng_lbl);
            this.groupBoxCommon4.Controls.Add(this.ng_txt);
            this.groupBoxCommon4.Controls.Add(this.extant_lbl);
            this.groupBoxCommon4.Controls.Add(this.output_txt);
            this.groupBoxCommon4.Controls.Add(this.input_txt);
            resources.ApplyResources(this.groupBoxCommon4, "groupBoxCommon4");
            this.groupBoxCommon4.Name = "groupBoxCommon4";
            this.groupBoxCommon4.TabStop = false;
            // 
            // groupBoxCommon5
            // 
            this.groupBoxCommon5.ControlId = null;
            this.groupBoxCommon5.Controls.Add(this.sum_txt);
            this.groupBoxCommon5.Controls.Add(this.labelCommon1);
            resources.ApplyResources(this.groupBoxCommon5, "groupBoxCommon5");
            this.groupBoxCommon5.Name = "groupBoxCommon5";
            this.groupBoxCommon5.TabStop = false;
            // 
            // sum_txt
            // 
            this.sum_txt.BackColor = System.Drawing.Color.White;
            this.sum_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sum_txt.ControlId = null;
            resources.ApplyResources(this.sum_txt, "sum_txt");
            this.sum_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.sum_txt.Name = "sum_txt";
            this.sum_txt.ReadOnly = true;
            // 
            // labelCommon1
            // 
            resources.ApplyResources(this.labelCommon1, "labelCommon1");
            this.labelCommon1.ControlId = null;
            this.labelCommon1.Name = "labelCommon1";
            // 
            // ProductionControllerForm
            // 
            resources.ApplyResources(this, "$this");
            this.ControlId = "";
            this.Controls.Add(this.groupBoxCommon5);
            this.Controls.Add(this.groupBoxCommon4);
            this.Controls.Add(this.groupBoxCommon3);
            this.Controls.Add(this.groupBoxCommon1);
            this.Controls.Add(this.groupBoxCommon2);
            this.Controls.Add(this.setting_gbc);
            this.Controls.Add(this.production_controller_dgv);
            this.Name = "ProductionControllerForm";
            this.TitleText = "Production Controller";
            this.Load += new System.EventHandler(this.ProductionControllerForm_Load);
            this.Resize += new System.EventHandler(this.ProductionControllerForm_Resize);
            this.Controls.SetChildIndex(this.production_controller_dgv, 0);
            this.Controls.SetChildIndex(this.setting_gbc, 0);
            this.Controls.SetChildIndex(this.groupBoxCommon2, 0);
            this.Controls.SetChildIndex(this.groupBoxCommon1, 0);
            this.Controls.SetChildIndex(this.groupBoxCommon3, 0);
            this.Controls.SetChildIndex(this.groupBoxCommon4, 0);
            this.Controls.SetChildIndex(this.groupBoxCommon5, 0);
            this.setting_gbc.ResumeLayout(false);
            this.setting_gbc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.production_controller_dgv)).EndInit();
            this.groupBoxCommon2.ResumeLayout(false);
            this.groupBoxCommon2.PerformLayout();
            this.groupBoxCommon1.ResumeLayout(false);
            this.groupBoxCommon1.PerformLayout();
            this.groupBoxCommon3.ResumeLayout(false);
            this.groupBoxCommon4.ResumeLayout(false);
            this.groupBoxCommon4.PerformLayout();
            this.groupBoxCommon5.ResumeLayout(false);
            this.groupBoxCommon5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Framework.LabelCommon model_lbl;
        private Framework.ComboBoxCommon model_cmb;
        private Framework.LabelCommon line_lbl;
        private Framework.ComboBoxCommon line_cmb;
        private Framework.LabelCommon timeto_lbl;
        private Framework.DateTimePickerCommon timeto_dtp;
        private Framework.LabelCommon timefrom_lbl;
        private Framework.ButtonCommon search_btn;
        private Framework.GroupBoxCommon setting_gbc;
        private Framework.DateTimePickerCommon timefrom_dtp;
        private Framework.RadioButtonCommon date_rab;
        private Framework.RadioButtonCommon time_rab;
        private Framework.LabelCommon total_lbl;
        private Framework.LabelCommon input_lbl;
        private Framework.LabelCommon ng_lbl;
        private Framework.LabelCommon output_lbl;
        private Framework.LabelCommon extant_lbl;
        private Framework.TextBoxCommon input_txt;
        private Framework.TextBoxCommon output_txt;
        private Framework.TextBoxCommon extant_txt;
        private Framework.TextBoxCommon ng_txt;
        internal Framework.DataGridViewCommon production_controller_dgv;
        private Framework.GroupBoxCommon groupBoxCommon2;
        private Framework.TextBoxCommon linksave_txt;
        private Framework.ButtonCommon browser_btn;
        private Framework.ButtonCommon exportexcel_btn;
        private Framework.ButtonCommon chart_btn;
        private Framework.GroupBoxCommon groupBoxCommon1;
        private Framework.GroupBoxCommon groupBoxCommon3;
        private Framework.GroupBoxCommon groupBoxCommon4;
        private Framework.ButtonCommon person_btn;
        private Framework.GroupBoxCommon groupBoxCommon5;
        private Framework.LabelCommon labelCommon1;
        private Framework.TextBoxCommon sum_txt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStarday;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndday;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInput;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOutCoreInRotor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOutRotorInMotor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOutput;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalNG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRateNG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHolderNG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAppCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFundou;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInsertCase;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalNGMotor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRANG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSolder;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSolderWire;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWingding;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalNGRotor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWelding;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCore;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalNGCore;
    }
}
