namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    partial class PQMDataViewerForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PQMDataViewerForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsSernoRows = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsSpace = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsProcessing = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.sfSaveCSV = new System.Windows.Forms.SaveFileDialog();
            this.ofCSV = new System.Windows.Forms.OpenFileDialog();
            this.dgvdt = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.groupBoxCommon1 = new Com.Nidec.Mes.Framework.GroupBoxCommon();
            this.trInspect = new Com.Nidec.Mes.Framework.TreeViewCommon();
            this.panelCommon1 = new Com.Nidec.Mes.Framework.PanelCommon();
            this.btnClear = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.txtBarcode = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.cmbModel = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.groupBoxCommon2 = new Com.Nidec.Mes.Framework.GroupBoxCommon();
            this.dtDatef = new Com.Nidec.Mes.Framework.CommonControls.DateTimePickerControl();
            this.groupBoxCommon3 = new Com.Nidec.Mes.Framework.GroupBoxCommon();
            this.dtDatet = new Com.Nidec.Mes.Framework.CommonControls.DateTimePickerControl();
            this.groupBoxCommon4 = new Com.Nidec.Mes.Framework.GroupBoxCommon();
            this.btnBrowser = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.txtURL = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.btnCSV = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.btnSearch = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.btnLoad = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.bgwGetData = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdt)).BeginInit();
            this.groupBoxCommon1.SuspendLayout();
            this.panelCommon1.SuspendLayout();
            this.groupBoxCommon2.SuspendLayout();
            this.groupBoxCommon3.SuspendLayout();
            this.groupBoxCommon4.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsSernoRows,
            this.tsSpace,
            this.toolStripStatusLabel2,
            this.tsProcessing,
            this.toolStripStatusLabel3,
            this.tsTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 390);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(693, 24);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(88, 19);
            this.toolStripStatusLabel1.Text = "Serial numbers:";
            // 
            // tsSernoRows
            // 
            this.tsSernoRows.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsSernoRows.Name = "tsSernoRows";
            this.tsSernoRows.Size = new System.Drawing.Size(45, 19);
            this.tsSernoRows.Text = "0 rows";
            // 
            // tsSpace
            // 
            this.tsSpace.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.tsSpace.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsSpace.Name = "tsSpace";
            this.tsSpace.Size = new System.Drawing.Size(373, 19);
            this.tsSpace.Spring = true;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(66, 19);
            this.toolStripStatusLabel2.Text = "Data rows:";
            // 
            // tsProcessing
            // 
            this.tsProcessing.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsProcessing.Name = "tsProcessing";
            this.tsProcessing.Size = new System.Drawing.Size(40, 19);
            this.tsProcessing.Text = "None";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(41, 19);
            this.toolStripStatusLabel3.Text = "Time:";
            // 
            // tsTime
            // 
            this.tsTime.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsTime.Name = "tsTime";
            this.tsTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsTime.Size = new System.Drawing.Size(25, 19);
            this.tsTime.Text = "0 s";
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 10;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // sfSaveCSV
            // 
            this.sfSaveCSV.CheckFileExists = true;
            this.sfSaveCSV.DefaultExt = "csv";
            this.sfSaveCSV.InitialDirectory = "D:\\";
            // 
            // ofCSV
            // 
            this.ofCSV.FileName = "openFileDialog1";
            // 
            // dgvdt
            // 
            this.dgvdt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvdt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdt.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvdt.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvdt.Location = new System.Drawing.Point(3, 306);
            this.dgvdt.Name = "dgvdt";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdt.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvdt.Size = new System.Drawing.Size(687, 81);
            this.dgvdt.TabIndex = 23;
            // 
            // groupBoxCommon1
            // 
            this.groupBoxCommon1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCommon1.ControlId = null;
            this.groupBoxCommon1.Controls.Add(this.trInspect);
            this.groupBoxCommon1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCommon1.Location = new System.Drawing.Point(474, 108);
            this.groupBoxCommon1.Name = "groupBoxCommon1";
            this.groupBoxCommon1.Size = new System.Drawing.Size(216, 191);
            this.groupBoxCommon1.TabIndex = 24;
            this.groupBoxCommon1.TabStop = false;
            this.groupBoxCommon1.Text = "Inspect";
            // 
            // trInspect
            // 
            this.trInspect.CheckBoxes = true;
            this.trInspect.ControlId = null;
            this.trInspect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trInspect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trInspect.Location = new System.Drawing.Point(3, 17);
            this.trInspect.Name = "trInspect";
            this.trInspect.Size = new System.Drawing.Size(210, 171);
            this.trInspect.TabIndex = 0;
            this.trInspect.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trInspect_AfterCheck);
            // 
            // panelCommon1
            // 
            this.panelCommon1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCommon1.ControlId = null;
            this.panelCommon1.Controls.Add(this.btnClear);
            this.panelCommon1.Controls.Add(this.labelCommon2);
            this.panelCommon1.Controls.Add(this.txtBarcode);
            this.panelCommon1.Controls.Add(this.labelCommon1);
            this.panelCommon1.Controls.Add(this.cmbModel);
            this.panelCommon1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelCommon1.Location = new System.Drawing.Point(273, 109);
            this.panelCommon1.Name = "panelCommon1";
            this.panelCommon1.Size = new System.Drawing.Size(198, 191);
            this.panelCommon1.TabIndex = 25;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.SystemColors.Control;
            this.btnClear.ControlId = null;
            this.btnClear.Font = new System.Drawing.Font("Arial", 9F);
            this.btnClear.Location = new System.Drawing.Point(124, 45);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(71, 27);
            this.btnClear.TabIndex = 34;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // labelCommon2
            // 
            this.labelCommon2.AutoSize = true;
            this.labelCommon2.ControlId = null;
            this.labelCommon2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCommon2.Location = new System.Drawing.Point(3, 51);
            this.labelCommon2.Name = "labelCommon2";
            this.labelCommon2.Size = new System.Drawing.Size(53, 15);
            this.labelCommon2.TabIndex = 3;
            this.labelCommon2.Text = "Barcode";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBarcode.ControlId = null;
            this.txtBarcode.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.txtBarcode.Location = new System.Drawing.Point(3, 75);
            this.txtBarcode.Multiline = true;
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(192, 110);
            this.txtBarcode.TabIndex = 2;
            // 
            // labelCommon1
            // 
            this.labelCommon1.AutoSize = true;
            this.labelCommon1.ControlId = null;
            this.labelCommon1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCommon1.Location = new System.Drawing.Point(3, 22);
            this.labelCommon1.Name = "labelCommon1";
            this.labelCommon1.Size = new System.Drawing.Size(40, 15);
            this.labelCommon1.TabIndex = 1;
            this.labelCommon1.Text = "Model";
            // 
            // cmbModel
            // 
            this.cmbModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbModel.ControlId = null;
            this.cmbModel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbModel.FormattingEnabled = true;
            this.cmbModel.Location = new System.Drawing.Point(49, 19);
            this.cmbModel.Name = "cmbModel";
            this.cmbModel.Size = new System.Drawing.Size(146, 23);
            this.cmbModel.TabIndex = 0;
            this.cmbModel.SelectedIndexChanged += new System.EventHandler(this.cmbModel_SelectedIndexChanged);
            // 
            // groupBoxCommon2
            // 
            this.groupBoxCommon2.ControlId = null;
            this.groupBoxCommon2.Controls.Add(this.dtDatef);
            this.groupBoxCommon2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCommon2.Location = new System.Drawing.Point(9, 109);
            this.groupBoxCommon2.Name = "groupBoxCommon2";
            this.groupBoxCommon2.Size = new System.Drawing.Size(258, 51);
            this.groupBoxCommon2.TabIndex = 28;
            this.groupBoxCommon2.TabStop = false;
            this.groupBoxCommon2.Text = "From date";
            // 
            // dtDatef
            // 
            this.dtDatef.ControlId = null;
            this.dtDatef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtDatef.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtDatef.InputType = Com.Nidec.Mes.Framework.CommonControls.DateTimePickerControl.InputTypeList.FromDate;
            this.dtDatef.Location = new System.Drawing.Point(3, 17);
            this.dtDatef.Name = "dtDatef";
            this.dtDatef.Size = new System.Drawing.Size(252, 31);
            this.dtDatef.TabIndex = 28;
            // 
            // groupBoxCommon3
            // 
            this.groupBoxCommon3.ControlId = null;
            this.groupBoxCommon3.Controls.Add(this.dtDatet);
            this.groupBoxCommon3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCommon3.Location = new System.Drawing.Point(9, 165);
            this.groupBoxCommon3.Name = "groupBoxCommon3";
            this.groupBoxCommon3.Size = new System.Drawing.Size(258, 51);
            this.groupBoxCommon3.TabIndex = 29;
            this.groupBoxCommon3.TabStop = false;
            this.groupBoxCommon3.Text = "To date";
            // 
            // dtDatet
            // 
            this.dtDatet.ControlId = null;
            this.dtDatet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtDatet.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtDatet.InputType = Com.Nidec.Mes.Framework.CommonControls.DateTimePickerControl.InputTypeList.ToDate;
            this.dtDatet.Location = new System.Drawing.Point(3, 17);
            this.dtDatet.Name = "dtDatet";
            this.dtDatet.Size = new System.Drawing.Size(252, 31);
            this.dtDatet.TabIndex = 29;
            // 
            // groupBoxCommon4
            // 
            this.groupBoxCommon4.ControlId = null;
            this.groupBoxCommon4.Controls.Add(this.btnBrowser);
            this.groupBoxCommon4.Controls.Add(this.txtURL);
            this.groupBoxCommon4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCommon4.Location = new System.Drawing.Point(9, 222);
            this.groupBoxCommon4.Name = "groupBoxCommon4";
            this.groupBoxCommon4.Size = new System.Drawing.Size(258, 47);
            this.groupBoxCommon4.TabIndex = 30;
            this.groupBoxCommon4.TabStop = false;
            this.groupBoxCommon4.Text = "Serial from CSV";
            // 
            // btnBrowser
            // 
            this.btnBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowser.BackColor = System.Drawing.SystemColors.Control;
            this.btnBrowser.ControlId = null;
            this.btnBrowser.Font = new System.Drawing.Font("Arial", 9F);
            this.btnBrowser.Location = new System.Drawing.Point(195, 19);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(57, 22);
            this.btnBrowser.TabIndex = 31;
            this.btnBrowser.Text = "Browser";
            this.btnBrowser.UseVisualStyleBackColor = false;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // txtURL
            // 
            this.txtURL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtURL.ControlId = null;
            this.txtURL.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtURL.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.txtURL.Location = new System.Drawing.Point(6, 20);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(183, 21);
            this.txtURL.TabIndex = 0;
            // 
            // btnCSV
            // 
            this.btnCSV.BackColor = System.Drawing.SystemColors.Control;
            this.btnCSV.ControlId = null;
            this.btnCSV.Font = new System.Drawing.Font("Arial", 9F);
            this.btnCSV.Location = new System.Drawing.Point(9, 275);
            this.btnCSV.Name = "btnCSV";
            this.btnCSV.Size = new System.Drawing.Size(71, 27);
            this.btnCSV.TabIndex = 31;
            this.btnCSV.Text = "To CSV";
            this.btnCSV.UseVisualStyleBackColor = false;
            this.btnCSV.Click += new System.EventHandler(this.btnCSV_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.Control;
            this.btnSearch.ControlId = null;
            this.btnSearch.Font = new System.Drawing.Font("Arial", 9F);
            this.btnSearch.Location = new System.Drawing.Point(102, 275);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(71, 27);
            this.btnSearch.TabIndex = 32;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.SystemColors.Control;
            this.btnLoad.ControlId = null;
            this.btnLoad.Font = new System.Drawing.Font("Arial", 9F);
            this.btnLoad.Location = new System.Drawing.Point(195, 275);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(71, 27);
            this.btnLoad.TabIndex = 33;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // PQMDataViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 414);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnCSV);
            this.Controls.Add(this.groupBoxCommon4);
            this.Controls.Add(this.groupBoxCommon3);
            this.Controls.Add(this.groupBoxCommon2);
            this.Controls.Add(this.panelCommon1);
            this.Controls.Add(this.groupBoxCommon1);
            this.Controls.Add(this.dgvdt);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PQMDataViewerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PQM Get Data";
            this.TitleText = "PQM Data Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PQMDataViewerForm_Load);
            this.Controls.SetChildIndex(this.statusStrip1, 0);
            this.Controls.SetChildIndex(this.dgvdt, 0);
            this.Controls.SetChildIndex(this.groupBoxCommon1, 0);
            this.Controls.SetChildIndex(this.panelCommon1, 0);
            this.Controls.SetChildIndex(this.groupBoxCommon2, 0);
            this.Controls.SetChildIndex(this.groupBoxCommon3, 0);
            this.Controls.SetChildIndex(this.groupBoxCommon4, 0);
            this.Controls.SetChildIndex(this.btnCSV, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.btnLoad, 0);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdt)).EndInit();
            this.groupBoxCommon1.ResumeLayout(false);
            this.panelCommon1.ResumeLayout(false);
            this.panelCommon1.PerformLayout();
            this.groupBoxCommon2.ResumeLayout(false);
            this.groupBoxCommon3.ResumeLayout(false);
            this.groupBoxCommon4.ResumeLayout(false);
            this.groupBoxCommon4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsProcessing;
        private System.Windows.Forms.ToolStripStatusLabel tsTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolStripStatusLabel tsSpace;
        private System.Windows.Forms.SaveFileDialog sfSaveCSV;
        private System.Windows.Forms.OpenFileDialog ofCSV;
        private Framework.DataGridViewCommon dgvdt;
        private Framework.GroupBoxCommon groupBoxCommon1;
        private Framework.TreeViewCommon trInspect;
        private Framework.PanelCommon panelCommon1;
        private Framework.LabelCommon labelCommon2;
        private Framework.TextBoxCommon txtBarcode;
        private Framework.LabelCommon labelCommon1;
        private Framework.ComboBoxCommon cmbModel;
        private Framework.GroupBoxCommon groupBoxCommon2;
        private Framework.CommonControls.DateTimePickerControl dtDatef;
        private Framework.GroupBoxCommon groupBoxCommon3;
        private Framework.CommonControls.DateTimePickerControl dtDatet;
        private Framework.GroupBoxCommon groupBoxCommon4;
        private Framework.ButtonCommon btnBrowser;
        private Framework.TextBoxCommon txtURL;
        private Framework.ButtonCommon btnCSV;
        private Framework.ButtonCommon btnSearch;
        private Framework.ButtonCommon btnLoad;
        private Framework.ButtonCommon btnClear;
        private System.ComponentModel.BackgroundWorker bgwGetData;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsSernoRows;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
    }
}

