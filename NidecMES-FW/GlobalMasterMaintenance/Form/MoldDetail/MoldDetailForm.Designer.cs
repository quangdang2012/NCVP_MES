namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class MoldDetailForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoldDetailForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MoldCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.MoldCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Mold_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colMoldId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMoldCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMoldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMoldDrawingNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMoldCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMoldItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSapItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLifeShotCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLifeAlarmShotCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPeriodicAlarmShotCount1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPeriodicAlarmShotCount2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPeriodicAlarmShotCount3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Save_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Download_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Upload_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.ExcelExport_sfdlg = new System.Windows.Forms.SaveFileDialog();
            this.Export_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            ((System.ComponentModel.ISupportInitialize)(this.Mold_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // MoldCode_txt
            // 
            resources.ApplyResources(this.MoldCode_txt, "MoldCode_txt");
            this.MoldCode_txt.ControlId = null;
            this.MoldCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.MoldCode_txt.Name = "MoldCode_txt";
            // 
            // MoldCode_lbl
            // 
            resources.ApplyResources(this.MoldCode_lbl, "MoldCode_lbl");
            this.MoldCode_lbl.ControlId = null;
            this.MoldCode_lbl.Name = "MoldCode_lbl";
            // 
            // Clear_btn
            // 
            resources.ApplyResources(this.Clear_btn, "Clear_btn");
            this.Clear_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Clear_btn.ControlId = null;
            this.Clear_btn.Name = "Clear_btn";
            this.Clear_btn.UseVisualStyleBackColor = true;
            this.Clear_btn.Click += new System.EventHandler(this.Clear_btn_Click);
            // 
            // Exit_btn
            // 
            resources.ApplyResources(this.Exit_btn, "Exit_btn");
            this.Exit_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Exit_btn.ControlId = null;
            this.Exit_btn.Name = "Exit_btn";
            this.Exit_btn.UseVisualStyleBackColor = true;
            this.Exit_btn.Click += new System.EventHandler(this.Exit_btn_Click);
            // 
            // Delete_btn
            // 
            resources.ApplyResources(this.Delete_btn, "Delete_btn");
            this.Delete_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Delete_btn.ControlId = null;
            this.Delete_btn.Name = "Delete_btn";
            this.Delete_btn.UseVisualStyleBackColor = true;
            this.Delete_btn.Click += new System.EventHandler(this.Delete_btn_Click);
            // 
            // Update_btn
            // 
            resources.ApplyResources(this.Update_btn, "Update_btn");
            this.Update_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Update_btn.ControlId = null;
            this.Update_btn.Name = "Update_btn";
            this.Update_btn.UseVisualStyleBackColor = true;
            this.Update_btn.Click += new System.EventHandler(this.Update_btn_Click);
            // 
            // Add_btn
            // 
            resources.ApplyResources(this.Add_btn, "Add_btn");
            this.Add_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Add_btn.ControlId = null;
            this.Add_btn.Name = "Add_btn";
            this.Add_btn.UseVisualStyleBackColor = true;
            this.Add_btn.Click += new System.EventHandler(this.Add_btn_Click);
            // 
            // Search_btn
            // 
            resources.ApplyResources(this.Search_btn, "Search_btn");
            this.Search_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Search_btn.ControlId = null;
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // Mold_dgv
            // 
            resources.ApplyResources(this.Mold_dgv, "Mold_dgv");
            this.Mold_dgv.AllowUserToAddRows = false;
            this.Mold_dgv.AllowUserToDeleteRows = false;
            this.Mold_dgv.AllowUserToOrderColumns = true;
            this.Mold_dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Mold_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.Mold_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Mold_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMoldId,
            this.colMoldCode,
            this.colMoldName,
            this.colMoldDrawingNo,
            this.colMoldCategory,
            this.colModel,
            this.colMoldItemCode,
            this.colSapItemCode,
            this.colWidth,
            this.colDepth,
            this.colHeight,
            this.colWeight,
            this.colProductionDate,
            this.colLifeShotCount,
            this.colLifeAlarmShotCount,
            this.colPeriodicAlarmShotCount1,
            this.colPeriodicAlarmShotCount2,
            this.colPeriodicAlarmShotCount3,
            this.colComment,
            this.colRemarks});
            this.Mold_dgv.ControlId = null;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Mold_dgv.DefaultCellStyle = dataGridViewCellStyle25;
            this.Mold_dgv.EnableHeadersVisualStyles = false;
            this.Mold_dgv.MultiSelect = false;
            this.Mold_dgv.Name = "Mold_dgv";
            this.Mold_dgv.ReadOnly = true;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Mold_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle26;
            this.Mold_dgv.RowHeadersVisible = false;
            this.Mold_dgv.RowTemplate.Height = 21;
            this.Mold_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.Mold_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Mold_dgv_CellClick);
            this.Mold_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Mold_dgv_CellDoubleClick);
            this.Mold_dgv.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Mold_dgv_ColumnHeaderMouseClick);
            // 
            // colMoldId
            // 
            this.colMoldId.DataPropertyName = "MoldId";
            resources.ApplyResources(this.colMoldId, "colMoldId");
            this.colMoldId.Name = "colMoldId";
            this.colMoldId.ReadOnly = true;
            // 
            // colMoldCode
            // 
            this.colMoldCode.DataPropertyName = "MoldCode";
            resources.ApplyResources(this.colMoldCode, "colMoldCode");
            this.colMoldCode.Name = "colMoldCode";
            this.colMoldCode.ReadOnly = true;
            // 
            // colMoldName
            // 
            this.colMoldName.DataPropertyName = "MoldName";
            resources.ApplyResources(this.colMoldName, "colMoldName");
            this.colMoldName.Name = "colMoldName";
            this.colMoldName.ReadOnly = true;
            // 
            // colMoldDrawingNo
            // 
            this.colMoldDrawingNo.DataPropertyName = "MoldDrawingNo";
            resources.ApplyResources(this.colMoldDrawingNo, "colMoldDrawingNo");
            this.colMoldDrawingNo.Name = "colMoldDrawingNo";
            this.colMoldDrawingNo.ReadOnly = true;
            // 
            // colMoldCategory
            // 
            this.colMoldCategory.DataPropertyName = "MoldCategoryCode";
            resources.ApplyResources(this.colMoldCategory, "colMoldCategory");
            this.colMoldCategory.Name = "colMoldCategory";
            this.colMoldCategory.ReadOnly = true;
            // 
            // colModel
            // 
            this.colModel.DataPropertyName = "ModelCode";
            resources.ApplyResources(this.colModel, "colModel");
            this.colModel.Name = "colModel";
            this.colModel.ReadOnly = true;
            // 
            // colMoldItemCode
            // 
            this.colMoldItemCode.DataPropertyName = "MoldItemCode";
            resources.ApplyResources(this.colMoldItemCode, "colMoldItemCode");
            this.colMoldItemCode.Name = "colMoldItemCode";
            this.colMoldItemCode.ReadOnly = true;
            // 
            // colSapItemCode
            // 
            this.colSapItemCode.DataPropertyName = "SapItemCode";
            resources.ApplyResources(this.colSapItemCode, "colSapItemCode");
            this.colSapItemCode.Name = "colSapItemCode";
            this.colSapItemCode.ReadOnly = true;
            // 
            // colWidth
            // 
            this.colWidth.DataPropertyName = "Width";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colWidth.DefaultCellStyle = dataGridViewCellStyle15;
            resources.ApplyResources(this.colWidth, "colWidth");
            this.colWidth.Name = "colWidth";
            this.colWidth.ReadOnly = true;
            // 
            // colDepth
            // 
            this.colDepth.DataPropertyName = "Depth";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colDepth.DefaultCellStyle = dataGridViewCellStyle16;
            resources.ApplyResources(this.colDepth, "colDepth");
            this.colDepth.Name = "colDepth";
            this.colDepth.ReadOnly = true;
            // 
            // colHeight
            // 
            this.colHeight.DataPropertyName = "Height";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colHeight.DefaultCellStyle = dataGridViewCellStyle17;
            resources.ApplyResources(this.colHeight, "colHeight");
            this.colHeight.Name = "colHeight";
            this.colHeight.ReadOnly = true;
            // 
            // colWeight
            // 
            this.colWeight.DataPropertyName = "Weight";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colWeight.DefaultCellStyle = dataGridViewCellStyle18;
            resources.ApplyResources(this.colWeight, "colWeight");
            this.colWeight.Name = "colWeight";
            this.colWeight.ReadOnly = true;
            // 
            // colProductionDate
            // 
            this.colProductionDate.DataPropertyName = "ProductionDate";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colProductionDate.DefaultCellStyle = dataGridViewCellStyle19;
            resources.ApplyResources(this.colProductionDate, "colProductionDate");
            this.colProductionDate.Name = "colProductionDate";
            this.colProductionDate.ReadOnly = true;
            this.colProductionDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colLifeShotCount
            // 
            this.colLifeShotCount.DataPropertyName = "LifeShotCount";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colLifeShotCount.DefaultCellStyle = dataGridViewCellStyle20;
            resources.ApplyResources(this.colLifeShotCount, "colLifeShotCount");
            this.colLifeShotCount.Name = "colLifeShotCount";
            this.colLifeShotCount.ReadOnly = true;
            // 
            // colLifeAlarmShotCount
            // 
            this.colLifeAlarmShotCount.DataPropertyName = "LifeAlarmShotCount";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colLifeAlarmShotCount.DefaultCellStyle = dataGridViewCellStyle21;
            resources.ApplyResources(this.colLifeAlarmShotCount, "colLifeAlarmShotCount");
            this.colLifeAlarmShotCount.Name = "colLifeAlarmShotCount";
            this.colLifeAlarmShotCount.ReadOnly = true;
            // 
            // colPeriodicAlarmShotCount1
            // 
            this.colPeriodicAlarmShotCount1.DataPropertyName = "PeriodicAlarmShotCount1";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colPeriodicAlarmShotCount1.DefaultCellStyle = dataGridViewCellStyle22;
            resources.ApplyResources(this.colPeriodicAlarmShotCount1, "colPeriodicAlarmShotCount1");
            this.colPeriodicAlarmShotCount1.Name = "colPeriodicAlarmShotCount1";
            this.colPeriodicAlarmShotCount1.ReadOnly = true;
            // 
            // colPeriodicAlarmShotCount2
            // 
            this.colPeriodicAlarmShotCount2.DataPropertyName = "PeriodicAlarmShotCount2";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colPeriodicAlarmShotCount2.DefaultCellStyle = dataGridViewCellStyle23;
            resources.ApplyResources(this.colPeriodicAlarmShotCount2, "colPeriodicAlarmShotCount2");
            this.colPeriodicAlarmShotCount2.Name = "colPeriodicAlarmShotCount2";
            this.colPeriodicAlarmShotCount2.ReadOnly = true;
            // 
            // colPeriodicAlarmShotCount3
            // 
            this.colPeriodicAlarmShotCount3.DataPropertyName = "PeriodicAlarmShotCount3";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colPeriodicAlarmShotCount3.DefaultCellStyle = dataGridViewCellStyle24;
            resources.ApplyResources(this.colPeriodicAlarmShotCount3, "colPeriodicAlarmShotCount3");
            this.colPeriodicAlarmShotCount3.Name = "colPeriodicAlarmShotCount3";
            this.colPeriodicAlarmShotCount3.ReadOnly = true;
            // 
            // colComment
            // 
            this.colComment.DataPropertyName = "Comment";
            resources.ApplyResources(this.colComment, "colComment");
            this.colComment.Name = "colComment";
            this.colComment.ReadOnly = true;
            // 
            // colRemarks
            // 
            this.colRemarks.DataPropertyName = "Remarks";
            resources.ApplyResources(this.colRemarks, "colRemarks");
            this.colRemarks.Name = "colRemarks";
            this.colRemarks.ReadOnly = true;
            // 
            // Save_btn
            // 
            resources.ApplyResources(this.Save_btn, "Save_btn");
            this.Save_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Save_btn.ControlId = null;
            this.Save_btn.Name = "Save_btn";
            this.Save_btn.UseVisualStyleBackColor = true;
            this.Save_btn.Click += new System.EventHandler(this.Save_btn_Click);
            // 
            // Download_btn
            // 
            resources.ApplyResources(this.Download_btn, "Download_btn");
            this.Download_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Download_btn.ControlId = null;
            this.Download_btn.Name = "Download_btn";
            this.Download_btn.UseVisualStyleBackColor = true;
            this.Download_btn.Click += new System.EventHandler(this.Download_btn_Click);
            // 
            // Upload_btn
            // 
            resources.ApplyResources(this.Upload_btn, "Upload_btn");
            this.Upload_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Upload_btn.ControlId = null;
            this.Upload_btn.Name = "Upload_btn";
            this.Upload_btn.UseVisualStyleBackColor = true;
            this.Upload_btn.Click += new System.EventHandler(this.Upload_btn_Click);
            // 
            // ExcelExport_sfdlg
            // 
            resources.ApplyResources(this.ExcelExport_sfdlg, "ExcelExport_sfdlg");
            // 
            // Export_btn
            // 
            resources.ApplyResources(this.Export_btn, "Export_btn");
            this.Export_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Export_btn.ControlId = null;
            this.Export_btn.Name = "Export_btn";
            this.Export_btn.UseVisualStyleBackColor = true;
            this.Export_btn.Click += new System.EventHandler(this.Export_btn_Click);
            // 
            // MoldDetailForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf019";
            this.Controls.Add(this.Export_btn);
            this.Controls.Add(this.Save_btn);
            this.Controls.Add(this.Download_btn);
            this.Controls.Add(this.Upload_btn);
            this.Controls.Add(this.MoldCode_txt);
            this.Controls.Add(this.MoldCode_lbl);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.Mold_dgv);
            this.Name = "MoldDetailForm";
            this.TitleText = "FormCommon";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MoldDetailForm_Load);
            this.Controls.SetChildIndex(this.Mold_dgv, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.MoldCode_lbl, 0);
            this.Controls.SetChildIndex(this.MoldCode_txt, 0);
            this.Controls.SetChildIndex(this.Upload_btn, 0);
            this.Controls.SetChildIndex(this.Download_btn, 0);
            this.Controls.SetChildIndex(this.Save_btn, 0);
            this.Controls.SetChildIndex(this.Export_btn, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Mold_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Com.Nidec.Mes.Framework.TextBoxCommon MoldCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon MoldCode_lbl;
        private Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        internal Com.Nidec.Mes.Framework.DataGridViewCommon Mold_dgv;
        protected Framework.ButtonCommon Save_btn;
        private Framework.ButtonCommon Download_btn;
        private Framework.ButtonCommon Upload_btn;
        private System.Windows.Forms.SaveFileDialog ExcelExport_sfdlg;
        private Framework.ButtonCommon Export_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMoldId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMoldCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMoldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMoldDrawingNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMoldCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMoldItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSapItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLifeShotCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLifeAlarmShotCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPeriodicAlarmShotCount1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPeriodicAlarmShotCount2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPeriodicAlarmShotCount3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemarks;
    }
}