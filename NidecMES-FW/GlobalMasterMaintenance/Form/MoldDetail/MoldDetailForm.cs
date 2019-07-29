using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using System.Collections.Generic;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using System.Linq;
using System.IO;
using System.Text;
using System.Data.OleDb;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class MoldDetailForm
    {
        #region Variables

        /// <summary>
        /// excel upload check
        /// </summary>
        private bool isExcelUpload = false;

        /// <summary>
        /// processWorkList
        /// </summary>
        private List<ProcessWorkVo> processWorkList = new List<ProcessWorkVo>();

        /// <summary>
        /// excel upload data
        /// </summary>
        private DataTable excelUploadDt = new DataTable();

        /// <summary>
        /// excel upload cavity data
        /// </summary>
        private DataTable cavityDataTable = new DataTable();

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(MoldDetailForm));

        /// <summary>
        ///  get message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        /// initialize SortOrder
        /// </summary>
        private SortOrder sortDirection;

        /// <summary>
        /// Mold Model
        /// </summary>
        private const string MODEL = "Mold Model";

        /// <summary>
        /// CAVITY_CODE_LENGTH
        /// </summary>
        private const int CAVITY_CODE_LENGTH = 32;

        /// <summary>
        /// CAVITY_CODE_LENGTH
        /// </summary>
        private const int CAVITY_NAME_LENGTH = 16;

        /// <summary>
        /// MOLD_CODE_LENGTH
        /// </summary>
        private const int MOLD_CODE_LENGTH = 16;

        private CbmController getCavityCbm = new GetCavityMasterMntCbm();

        #endregion

        #region Constructor

        /// <summary>
        /// constructor of the form
        /// </summary>
        public MoldDetailForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// create mold Vo object from mold data table
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private MoldDetailVo FormMoldDetailVo(DataRow row)
        {

            decimal width = 0;
            decimal depth = 0;
            decimal height = 0;
            decimal weight = 0;
            DateTime productionDate;
            int lifeShotCount = 0;
            int lifeAlaramShotCount = 0;
            int periodicAlarmShotCount1 = 0;
            int periodicAlarmShotCount2 = 0;
            int periodicAlarmShotCount3 = 0;

            MoldDetailVo addMoldDetailInVo = new MoldDetailVo();

            addMoldDetailInVo.MoldCode = row["MoldCode"].ToString().Trim();
            addMoldDetailInVo.MoldName = row["MoldCode"].ToString().Trim();

            if (row["Width"] != null && !string.IsNullOrWhiteSpace(row["Width"].ToString()) && Decimal.TryParse(row["Width"].ToString(), out width))
            {
                addMoldDetailInVo.Width = width;
            }
            if (row["Depth"] != null && !string.IsNullOrWhiteSpace(row["Depth"].ToString()) && Decimal.TryParse(row["Depth"].ToString(), out depth))
            {
                addMoldDetailInVo.Depth = depth;
            }
            if (row["Height"] != null && !string.IsNullOrWhiteSpace(row["Height"].ToString()) && Decimal.TryParse(row["Height"].ToString(), out height))
            {
                addMoldDetailInVo.Height = height;
            }
            if (row["Weight"] != null && !string.IsNullOrWhiteSpace(row["Weight"].ToString()) && Decimal.TryParse(row["Weight"].ToString(), out weight))
            {
                addMoldDetailInVo.Weight = weight;
            }
            if (row["ProductionDate"] != null && !string.IsNullOrWhiteSpace(row["ProductionDate"].ToString()) && DateTime.TryParse(row["ProductionDate"].ToString(), out productionDate))
            {
                addMoldDetailInVo.ProductionDate = productionDate;
            }
            if (row["LifeShotCount"] != null && !string.IsNullOrWhiteSpace(row["LifeShotCount"].ToString()) && int.TryParse(row["LifeShotCount"].ToString(), out lifeShotCount))
            {
                addMoldDetailInVo.LifeShotCount = lifeShotCount;
            }
            if (row["LifeAlarmShotCount"] != null && !string.IsNullOrWhiteSpace(row["LifeAlarmShotCount"].ToString()) && int.TryParse(row["LifeAlarmShotCount"].ToString(), out lifeAlaramShotCount))
            {
                addMoldDetailInVo.LifeAlarmShotCount = lifeAlaramShotCount;
            }
            if (row["PeriodicAlarmShotCount1"] != null && !string.IsNullOrWhiteSpace(row["PeriodicAlarmShotCount1"].ToString()) && int.TryParse(row["PeriodicAlarmShotCount1"].ToString(), out periodicAlarmShotCount1))
            {
                addMoldDetailInVo.PeriodicAlarmShotCount1 = periodicAlarmShotCount1;
            }
            if (row["PeriodicAlarmShotCount2"] != null && !string.IsNullOrWhiteSpace(row["PeriodicAlarmShotCount2"].ToString()) && int.TryParse(row["PeriodicAlarmShotCount2"].ToString(), out periodicAlarmShotCount2))
            {
                addMoldDetailInVo.PeriodicAlarmShotCount2 = periodicAlarmShotCount2;
            }
            if (row["PeriodicAlarmShotCount3"] != null && !string.IsNullOrWhiteSpace(row["PeriodicAlarmShotCount3"].ToString()) && int.TryParse(row["PeriodicAlarmShotCount3"].ToString(), out periodicAlarmShotCount3))
            {
                addMoldDetailInVo.PeriodicAlarmShotCount3 = periodicAlarmShotCount3;
            }


            addMoldDetailInVo.MoldCategoryCode = row["MoldCategoryCode"].ToString().Trim();


            if (row["Comment"] != null && !string.IsNullOrWhiteSpace(row["Comment"].ToString()))
            {
                addMoldDetailInVo.Comment = row["Comment"].ToString();
            }

            return addMoldDetailInVo;
        }

        /// <summary>
        /// create cavity Vo object from cavity data table
        /// </summary>
        /// <returns></returns>
        private ValueObjectList<CavityVo> FormMoldCavityVo()
        {
            ValueObjectList<CavityVo> cavityInVo = new ValueObjectList<CavityVo>();

            CavityVo addCavityInVo;

            foreach (DataRow cavityRow in cavityDataTable.Rows)
            {
                addCavityInVo = new CavityVo();

                addCavityInVo.CavityCode = cavityRow["CavityCode"].ToString().Trim();
                addCavityInVo.CavityName = cavityRow["CavityName"].ToString().Trim();
                addCavityInVo.MoldCode = cavityRow["MoldCode"].ToString().Trim();

                cavityInVo.add(addCavityInVo);
            }

            return cavityInVo;

        }

        /// <summary>
        /// Creates seacrh condition as per user inputs 
        /// </summary>
        /// <returns>search condition</returns>
        private MoldDetailVo FormConditionVo()
        {
            MoldDetailVo inVo = new MoldDetailVo();

            if (MoldCode_txt.Text != string.Empty)
            {
                inVo.MoldCode = MoldCode_txt.Text;
            }

            //if (MoldName_txt.Text != string.Empty)
            //{
            //    inVo.MoldName = MoldName_txt.Text;
            //}

            return inVo;

        }
        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(MoldDetailVo conditionInVo)
        {
            Mold_dgv.DataSource = null;
            isExcelUpload = false;

            ValueObjectList<MoldDetailVo> outVo = null;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                outVo = (ValueObjectList<MoldDetailVo>)base.InvokeCbm(new GetMoldDetailMasterMntCbm(), conditionInVo, false);

            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            if (outVo == null || outVo.GetList().Count == 0)
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null); //"item"
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                Export_btn.Enabled = false;
                return;
            }

            Export_btn.Enabled = true;

            BindDataSource(outVo.GetList());

            Mold_dgv.Columns["colRemarks"].Visible = false;

            Save_btn.Enabled = false;

            Update_btn.Enabled = false;

            Delete_btn.Enabled = false;

        }

        /// <summary>
        /// bind the grid
        /// </summary>
        /// <param name="outVo"></param>
        private void BindDataSource(List<MoldDetailVo> outVo)
        {
            Mold_dgv.AutoGenerateColumns = false;
            BindingSource bindingSource1 = new BindingSource(outVo, null);
            Mold_dgv.DataSource = bindingSource1;
            Mold_dgv.ClearSelection();
        }
        /// <summary>
        /// For binding combo box
        /// </summary>
        /// <param name="pCombo"></param>
        /// <param name="pDatasource"></param>
        /// <param name="pDisplay"></param>
        /// <param name="pValue"></param>
        private void ComboBind<T>(ComboBox pCombo, List<T> pDatasource, string pDisplay, string pValue)
        {
            pCombo.DataSource = pDatasource;
            pCombo.DisplayMember = pDisplay;
            pCombo.ValueMember = pValue;
            pCombo.SelectedIndex = -1;
            pCombo.Text = string.Empty;
        }


        /// <summary>
        /// selects user record for updation and show user form
        /// </summary>
        private void BindUpdateData()
        {
            int selectedrowindex = Mold_dgv.SelectedCells[0].RowIndex;

            MoldDetailVo moDetInVo = (MoldDetailVo)Mold_dgv.Rows[selectedrowindex].DataBoundItem;

            AddMoldDetailForm newAddForm = new AddMoldDetailForm(CommonConstants.MODE_UPDATE, moDetInVo);

            newAddForm.ShowDialog(this);

            if (newAddForm.IntSuccess > 0)
            {
                messageData = new MessageData("mmci00002", Properties.Resources.mmci00002, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);

                GridBind(FormConditionVo());
            }
            else if (newAddForm.IntSuccess == 0)
            {
                messageData = new MessageData("mmci00007", Properties.Resources.mmci00007, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                GridBind(FormConditionVo());
            }
        }
        /// <summary>
        /// Loads processwork
        /// </summary>
        private void GetProcessWork()
        {
            try
            {
                ProcessWorkVo outVo = null;

                outVo = (ProcessWorkVo)DefaultCbmInvoker.Invoke(new GetProcessWorkMasterMntCbm(), new ProcessWorkVo());

                if (outVo != null && outVo.ProcessWorkListVo.Count > 0)
                {
                    processWorkList = outVo.ProcessWorkListVo;
                }

            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        /// <summary>
        /// checks duplicate mold Code
        /// </summary>
        /// <returns></returns>
        private MoldVo DuplicateCheck(MoldVo checkInVo)
        {
            MoldVo outVo = new MoldVo();

            try
            {
                outVo = (MoldVo)base.InvokeCbm(new CheckMoldMasterMntCbm(), checkInVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
            return outVo;
        }

        /// <summary>
        /// checks ValidMoldCode
        /// </summary>
        /// <returns></returns>
        private bool IsMoldCodeExists(string moldCode)
        {
            MoldVo moldInVo = new MoldVo();

            moldInVo.MoldCode = moldCode;

            MoldVo outVo = null;

            try
            {
                outVo = (MoldVo)base.InvokeCbm(new GetMoldMasterMntCbm(), moldInVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            if (outVo != null && outVo.MoldListVo.Count > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// checks duplicate mold Code
        /// </summary>
        /// <returns></returns>
        private CavityVo DuplicateCheckCavity(CavityVo checkInVo)
        {
            CavityVo outVo = new CavityVo();

            try
            {
                outVo = (CavityVo)base.InvokeCbm(new CheckCavityMasterMntCbm(), checkInVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
            return outVo;
        }

        private bool DuplicateMoldCodeExistsInExcelFile(DataTable selectedMold)
        {
            var duplicates = selectedMold.AsEnumerable().GroupBy(r => new { Col1 = r["MoldCode"], Col2 = r["SapItemCode"] }).Where(gr => gr.Count() > 1).ToList();

            if (duplicates.Count > 0)
            {
                return true;
            }

            return false;
        }

        private bool OneToOneRelationOfSapItemAndMoldItem(DataTable selectedSapItem)
        {
            selectedSapItem = selectedSapItem.DefaultView.ToTable(true, "SapItemCode", "MoldItemCode");

            if (selectedSapItem != null && selectedSapItem.Rows.Count > 1)
            {
                return true;
            }

            return false;
        }
        private bool OneToOneRelationOfSapItemWithMoldItemDetailInExcelFile(DataTable selectedSapItem)
        {

            selectedSapItem = selectedSapItem.DefaultView.ToTable(true, "StdCycleTime", "ModelCode", "MoldDrawingNo"); //, "ModelCode", "MoldDrawingNo"

            if (selectedSapItem != null && selectedSapItem.Rows.Count > 1)
            {
                return true;
            }

            return false;
        }

        private bool DuplicateCavityNameForMoldCodeExistsInExcelFile(DataTable selectedMoldCavity)
        {
            var duplicates = selectedMoldCavity.AsEnumerable().GroupBy(r => new { Col1 = r["MoldCode"], Col2 = r["CavityName"] }).Where(gr => gr.Count() > 1).ToList();

            if (duplicates.Count > 0)
            {
                return true;
            }

            return false;
        }

        private bool IsValidMoldCode(DataTable excelUploadDt, string columnValue)
        {
            DataRow[] moldCodes = excelUploadDt.Select("MoldCode = '" + columnValue + "' ");

            if (moldCodes.Count() > 0)
            {
                return true;
            }

            return false;

        }

        private string CavityValidationFailed(DataTable cavityOfSelectedMold)
        {
            if (cavityOfSelectedMold == null)
            {
                return null;
            }
            var sch = StringCheckHelper.GetInstance();

            string cavityNGReason = string.Empty;

            foreach (DataRow cavityRow in cavityOfSelectedMold.Rows)
            {
                //if (cavityRow["CavityCode"] == null || string.IsNullOrWhiteSpace(cavityRow["CavityCode"].ToString()))
                //{
                //    cavityNGReason = string.Format(Properties.Resources.mmci00018, Properties.Resources.CavityCode);
                //    break;
                //}

                //if (!sch.IsASCII(cavityRow["CavityCode"].ToString()))
                //{
                //    cavityNGReason = string.Format(Properties.Resources.mmci00020, Properties.Resources.CavityCode);
                //    break;
                //}

                //if (cavityRow["CavityCode"].ToString().Length > CAVITY_CODE_LENGTH)
                //{
                //    cavityNGReason = string.Format(Properties.Resources.mmce00018, new string[] { Properties.Resources.CavityCode, CAVITY_CODE_LENGTH.ToString() });
                //}

                if (cavityRow["CavityName"] == null || string.IsNullOrWhiteSpace(cavityRow["CavityName"].ToString()))
                {
                    cavityNGReason = string.Format(Properties.Resources.mmci00018, Properties.Resources.CavityName);
                    break;
                }
                if (cavityRow["CavityName"].ToString().Length > CAVITY_NAME_LENGTH)
                {
                    cavityNGReason = string.Format(Properties.Resources.mmce00017, new string[] { Properties.Resources.CavityCode, CAVITY_CODE_LENGTH.ToString() });
                }

                if (DuplicateCavityNameForMoldCodeExistsInExcelFile(cavityOfSelectedMold))
                {
                    cavityNGReason = string.Format(Properties.Resources.mmce00020, cavityRow["MoldCode"].ToString(), cavityRow["CavityName"].ToString());
                    break;
                }

                cavityRow["CavityCode"] = cavityRow["MoldCode"].ToString() + "-" + cavityRow["CavityName"].ToString();
                if (cavityRow["CavityCode"] != null && !string.IsNullOrWhiteSpace(cavityRow["CavityCode"].ToString()))
                {
                    CavityVo checkCavityInVo = new CavityVo();

                    checkCavityInVo.CavityCode = cavityRow["CavityCode"].ToString();

                    CavityVo checkVo = DuplicateCheckCavity(checkCavityInVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        cavityNGReason = string.Format(Properties.Resources.mmce00013, Properties.Resources.CavityCode + " : " + checkCavityInVo.CavityCode);
                        break;
                    }
                }

                //if (cavityRow["MoldCode"] == null || string.IsNullOrWhiteSpace(cavityRow["MoldCode"].ToString()))
                //{
                //    cavityNGReason = string.Format(Properties.Resources.mmce00019);
                //    break;
                //}

            }

            return cavityNGReason;
        }

        /// <summary>
        /// checks mold to other tables in DB
        /// </summary>
        /// <param name="moVo"></param>
        /// <returns></returns>
        private MoldDetailVo CheckMoldRelation(MoldDetailVo moVo)
        {
            MoldDetailVo outVo = new MoldDetailVo();

            try
            {
                outVo = (MoldDetailVo)base.InvokeCbm(new CheckMoldDetailRelationCbm(), moVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            return outVo;
        }


        /// <summary>
        /// sorting for the data loaded from database using vo
        /// </summary>
        /// <param name="GridDatasource"></param>
        /// <param name="column"></param>
        private void ValueObjectListSorting(List<MoldDetailVo> GridDatasource, DataGridViewColumn column)
        {

            if (!string.IsNullOrEmpty(column.DataPropertyName) && GridDatasource.Count > 0 &&
                                                    column.CellType != typeof(DataGridViewButtonCell))
            {
                switch (sortDirection)
                {
                    case SortOrder.None:
                        sortDirection = SortOrder.Ascending;
                        break;
                    case SortOrder.Ascending:
                        sortDirection = SortOrder.Descending;
                        break;
                    case SortOrder.Descending:
                        sortDirection = SortOrder.Ascending;
                        break;
                }

                if (sortDirection == SortOrder.Ascending)
                {
                    GridDatasource = GridDatasource.OrderBy(t => t.GetType().GetProperty(column.DataPropertyName).GetValue(t)).ToList();
                }
                else if (sortDirection == SortOrder.Descending)
                {
                    GridDatasource = GridDatasource.OrderByDescending(t => t.GetType().GetProperty(column.DataPropertyName).GetValue(t)).ToList();
                }

                BindDataSource(GridDatasource);
            }
        }

        /// <summary>
        /// sorting for the data loaded from excel
        /// </summary>
        /// <param name="GridDatasource"></param>
        /// <param name="column"></param>
        private void DataTableSorting(DataTable GridDatasource, DataGridViewColumn column)
        {

            if (!string.IsNullOrEmpty(column.DataPropertyName) && GridDatasource.Rows.Count > 0 &&
                                                    column.CellType != typeof(DataGridViewButtonCell))
            {
                switch (sortDirection)
                {
                    case SortOrder.None:
                        sortDirection = SortOrder.Ascending;
                        break;
                    case SortOrder.Ascending:
                        sortDirection = SortOrder.Descending;
                        break;
                    case SortOrder.Descending:
                        sortDirection = SortOrder.Ascending;
                        break;
                }

                if (sortDirection == SortOrder.Ascending)
                {
                    GridDatasource.DefaultView.Sort = column.DataPropertyName + " asc";
                    GridDatasource = GridDatasource.DefaultView.ToTable(true);
                }
                else if (sortDirection == SortOrder.Descending)
                {
                    GridDatasource.DefaultView.Sort = column.DataPropertyName + " desc";
                    GridDatasource = GridDatasource.DefaultView.ToTable(true);
                    //GridDatasource = GridDatasource.OrderByDescending(t => t.GetType().GetProperty(column.DataPropertyName).GetValue(t)).ToList();
                }

                Mold_dgv.AutoGenerateColumns = false;
                BindingSource bindingSource1 = new BindingSource(GridDatasource, null);
                Mold_dgv.DataSource = bindingSource1;
                Mold_dgv.ClearSelection();

                List<DataGridViewRow> rowList = Mold_dgv.Rows
                  .Cast<DataGridViewRow>()
                  .Where(r => r.Cells["colRemarks"].Value.ToString() != string.Empty).ToList();

                foreach (DataGridViewRow row in rowList)
                {
                    row.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                }

            }
        }


        /// <summary>
        /// Form list of valueobject from excel to update in database
        /// </summary>
        /// <returns></returns>
        private ValueObjectList<ValueObject> FormValueObjectListFromExcelToDB()
        {

            ValueObjectList<MoldCategoryVo> moldCategoryInVo = new ValueObjectList<MoldCategoryVo>();

            ValueObjectList<MoldDetailVo> moldDetailInVo = new ValueObjectList<MoldDetailVo>();

            ValueObjectList<GlobalItemVo> globalItemInVo = new ValueObjectList<GlobalItemVo>();

            ValueObjectList<ItemVo> localItemInVo = new ValueObjectList<ItemVo>();

            ValueObjectList<MoldItemVo> moldItemInVo = new ValueObjectList<MoldItemVo>();

            ValueObjectList<CavityVo> cavityInVo = null;


            foreach (DataRow row in excelUploadDt.Rows)
            {
                if (processWorkList.Count == 0)
                {
                    GetProcessWork();
                }

                bool moldAlreadyAdded = false;
                //form mold and molddetailvo data from excel
                if (moldDetailInVo.GetList() != null && moldDetailInVo.GetList().Count > 0)
                {
                    moldAlreadyAdded = moldDetailInVo.GetList().Exists(r => r.MoldCode == row["MoldCode"].ToString().Trim());
                }

                if (moldAlreadyAdded == false)
                {
                    MoldDetailVo addMoldDetailInVo = FormMoldDetailVo(row);
                    moldDetailInVo.add(addMoldDetailInVo);

                    //form moldcategory data from excel
                    MoldCategoryVo addMoldCategoryInVo = new MoldCategoryVo();
                    addMoldCategoryInVo.MoldCategoryCode = row["MoldCategoryCode"].ToString().Trim();
                    addMoldCategoryInVo.MoldCategoryName = row["MoldCategoryCode"].ToString().Trim();
                    moldCategoryInVo.add(addMoldCategoryInVo);


                }

                //form moldstdcycletime data from excel
                MoldItemVo addMoldItemInVo = new MoldItemVo();
                addMoldItemInVo.GlobalItemCode = row["SapItemCode"].ToString().Trim();
                addMoldItemInVo.LocalItemCode = row["MoldItemCode"].ToString().Trim();
                addMoldItemInVo.MoldCode = row["MoldCode"].ToString().Trim();
                addMoldItemInVo.ModelCode = row["ModelCode"].ToString().Trim();
                addMoldItemInVo.DrawingNo = row["MoldDrawingNo"].ToString().Trim();

                int stdCycleTime;
                if (row["StdCycleTime"] != null && !string.IsNullOrWhiteSpace(row["StdCycleTime"].ToString()) && int.TryParse(row["StdCycleTime"].ToString(), out stdCycleTime))
                {
                    addMoldItemInVo.StdCycleTime = stdCycleTime;
                }

                moldItemInVo.add(addMoldItemInVo);

            }

            ValueObjectList<ValueObject> inVoList = new ValueObjectList<ValueObject>();
            //mold category
            moldCategoryInVo.SetNewList(moldCategoryInVo.GetList().GroupBy(t => t.MoldCategoryCode).Select(g => g.First()).ToList());
            inVoList.add(moldCategoryInVo);

            //mold detail
            inVoList.add(moldDetailInVo);

            //molditem(mesitem,sapitem link with stdcycletime)
            moldItemInVo.SetNewList(moldItemInVo.GetList().GroupBy(x => new { x.MoldCode, x.GlobalItemCode, x.LocalItemCode, x.ModelCode, x.DrawingNo }).Select(g => g.First()).ToList());
            inVoList.add(moldItemInVo);

            //cavity
            cavityInVo = FormMoldCavityVo();
            inVoList.add(cavityInVo);

            return inVoList;
        }

        private bool ExcelDataValidationFailed()
        {

            excelUploadDt.Columns.Add("Remarks");

            bool inputDataNG = false;

            var sch = StringCheckHelper.GetInstance();

            foreach (DataRow row in excelUploadDt.Rows)
            {
                if (row["MoldCode"] == null || string.IsNullOrWhiteSpace(row["MoldCode"].ToString()))
                {
                    row["Remarks"] = string.Format(Properties.Resources.mmci00018, MoldCode_lbl.Text);
                    inputDataNG = true;
                    continue;
                }

                if (!sch.IsASCII(row["MoldCode"].ToString().Trim()))
                {
                    row["Remarks"] = string.Format(Properties.Resources.mmci00020, MoldCode_lbl.Text);
                    inputDataNG = true;
                    continue;
                }

                if (row["MoldCategoryCode"] == null || string.IsNullOrWhiteSpace(row["MoldCategoryCode"].ToString()))
                {
                    row["Remarks"] = string.Format(Properties.Resources.mmci00018, Properties.Resources.MoldCategoryCode);
                    inputDataNG = true;
                    continue;
                }

                if (!sch.IsASCII(row["MoldCategoryCode"].ToString().Trim()))
                {
                    row["Remarks"] = string.Format(Properties.Resources.mmci00020, Properties.Resources.MoldCategoryCode);
                    inputDataNG = true;
                    continue;
                }

                if (row["ModelCode"] == null || string.IsNullOrWhiteSpace(row["ModelCode"].ToString()))
                {
                    row["Remarks"] = string.Format(Properties.Resources.mmci00018, Properties.Resources.ModelCode);
                    inputDataNG = true;
                    continue;
                }

                if (!sch.IsASCII(row["ModelCode"].ToString().Trim()))
                {
                    row["Remarks"] = string.Format(Properties.Resources.mmci00020, Properties.Resources.ModelCode);
                    inputDataNG = true;
                    continue;
                }

                if (row["MoldCode"].ToString().Trim().Length > MOLD_CODE_LENGTH)
                {
                    row["Remarks"] = string.Format(Properties.Resources.mmce00017, new string[] { MoldCode_lbl.Text, MOLD_CODE_LENGTH.ToString() });
                    inputDataNG = true;
                    continue;
                }

                if (row["MoldItemCode"] == null || string.IsNullOrWhiteSpace(row["MoldItemCode"].ToString()))
                {
                    row["Remarks"] = string.Format(Properties.Resources.mmci00018, Properties.Resources.MoldItemCode);
                    inputDataNG = true;
                    continue;
                }

                if (!sch.IsASCII(row["MoldItemCode"].ToString().Trim()))
                {
                    row["Remarks"] = string.Format(Properties.Resources.mmci00020, Properties.Resources.MoldItemCode);
                    inputDataNG = true;
                    continue;
                }

                DataRow[] selectedMold = excelUploadDt.Select("MoldCode ='" + row["MoldCode"].ToString().Trim() + "'");

                if (selectedMold != null && selectedMold.Count() > 0 &&
                    DuplicateMoldCodeExistsInExcelFile(selectedMold.CopyToDataTable()))
                {
                    row["Remarks"] = string.Format(Properties.Resources.mmce00014, MoldCode_lbl.Text + " : " + row["MoldCode"].ToString());
                    inputDataNG = true;
                    continue;
                }

                //check 1 : 1 relation ( sapitem : mes)
                DataRow[] selectedSapItem = excelUploadDt.Select("SapItemCode ='" + row["SapItemCode"].ToString().Trim() + "'");

                //mmce00025
                if (selectedSapItem != null && selectedSapItem.Count() > 0 &&
                    OneToOneRelationOfSapItemAndMoldItem(selectedSapItem.CopyToDataTable()))
                {
                    row["Remarks"] = string.Format(Properties.Resources.mmce00022, row["SapItemCode"].ToString());
                    inputDataNG = true;
                    continue;
                }

                ////check 1 : 1 relation (mold, sapitem) : (stdcycletime, model, drawing no))

                DataRow[] selectedSapItemforCurrentMold = selectedSapItem.CopyToDataTable().Select("MoldCode ='" + row["MoldCode"].ToString().Trim() + "'");
                if (selectedSapItemforCurrentMold != null && selectedSapItemforCurrentMold.Count() > 0 &&
                    OneToOneRelationOfSapItemWithMoldItemDetailInExcelFile(selectedSapItemforCurrentMold.CopyToDataTable()))
                {
                    row["Remarks"] = string.Format(Properties.Resources.mmce00021, row["SapItemCode"].ToString());
                    inputDataNG = true;
                    continue;
                }


                if (row["StdCycleTime"] == null || string.IsNullOrWhiteSpace(row["StdCycleTime"].ToString()))
                {
                    row["Remarks"] = string.Format(Properties.Resources.mmci00018, Properties.Resources.StdCycleTime);
                    inputDataNG = true;
                    continue;
                }

                MoldVo checkInVo = new MoldVo();

                checkInVo.MoldCode = row["MoldCode"].ToString().Trim();
                checkInVo.MoldName = row["MoldCode"].ToString().Trim();

                MoldVo checkVo = DuplicateCheck(checkInVo);

                ValueObjectList<CavityVo> cavityOutVo = null;
                if (checkVo != null && checkVo.AffectedCount > 0)
                {
                    CavityVo cavityInVo = new CavityVo();
                    cavityInVo.MoldCode = checkInVo.MoldCode;

                    cavityOutVo = (ValueObjectList<CavityVo>)base.InvokeCbm(getCavityCbm, cavityInVo, false);

                    //row["Remarks"] = string.Format(Properties.Resources.mmce00013, MoldCode_lbl.Text + " : " + checkInVo.MoldCode);
                    //inputDataNG = true;
                    //continue;
                }

                DataRow[] cavityMold = cavityDataTable.Select("MoldCode ='" + checkInVo.MoldCode + "'");

                if ((cavityOutVo == null || cavityOutVo.GetList() == null || cavityOutVo.GetList().Count == 0) && cavityMold.Count() == 0)
                {
                    row["Remarks"] = string.Format(Properties.Resources.mmce00018, checkInVo.MoldCode);
                    inputDataNG = true;
                    continue;
                }

                DataTable cavityMoldTable = null;
                if (cavityMold != null && cavityMold.Count() > 0)
                {
                    cavityMoldTable = cavityMold.CopyToDataTable();
                }
                string cavityNGReason = CavityValidationFailed(cavityMoldTable);

                if (!string.IsNullOrEmpty(cavityNGReason))
                {
                    row["Remarks"] = cavityNGReason;
                    inputDataNG = true;
                    continue;
                }

            }

            return inputDataNG;
        }

        /// <summary>
        /// Creates Mold data from excel export
        /// </summary>
        /// <returns></returns>
        private DataTable BindMoldDataForExcel()
        {
            ValueObjectList<MoldDetailVo> outVo = null;
            try
            {
                MoldDetailVo conditionInVo = FormConditionVo();

                outVo = (ValueObjectList<MoldDetailVo>)base.InvokeCbm(new GetMoldDetailMasterMntCbm(), conditionInVo, false);

            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            DataTable dt = new DataTable();
            CreateMoldHeaderColumns(dt);

            DataRow dr;
            if (outVo == null)
            {
                return dt;
            }

            if (outVo.GetList().Count > 0)
            {
                foreach (MoldDetailVo vo in outVo.GetList())
                {
                    dr = dt.NewRow();

                    dr[Mold_dgv.Columns["colMoldCode"].HeaderText] = vo.MoldCode;
                    dr[Mold_dgv.Columns["colMoldDrawingNo"].HeaderText] = vo.MoldDrawingNo;
                    dr[Mold_dgv.Columns["colMoldCategory"].HeaderText] = vo.MoldCategoryCode;
                    dr[Mold_dgv.Columns["colModel"].HeaderText] = vo.ModelCode;
                    dr[Mold_dgv.Columns["colMoldItemCode"].HeaderText] = vo.MoldItemCode;
                    dr[Mold_dgv.Columns["colSapItemCode"].HeaderText] = vo.SapItemCode;
                    dr[Mold_dgv.Columns["colWidth"].HeaderText] = vo.Weight;
                    dr[Mold_dgv.Columns["colDepth"].HeaderText] = vo.Depth;
                    dr[Mold_dgv.Columns["colHeight"].HeaderText] = vo.Height;
                    dr[Mold_dgv.Columns["colWeight"].HeaderText] = vo.Weight;
                    dr[Mold_dgv.Columns["colProductionDate"].HeaderText] = vo.ProductionDate == null || vo.ProductionDate == DateTime.MinValue ?
                                                                                                    string.Empty : vo.ProductionDate.ToString();
                    dr[Mold_dgv.Columns["colLifeShotCount"].HeaderText] = vo.LifeShotCount;
                    dr[Mold_dgv.Columns["colLifeAlarmShotCount"].HeaderText] = vo.LifeAlarmShotCount;
                    dr[Mold_dgv.Columns["colPeriodicAlarmShotCount1"].HeaderText] = vo.PeriodicAlarmShotCount1;
                    dr[Mold_dgv.Columns["colPeriodicAlarmShotCount2"].HeaderText] = vo.PeriodicAlarmShotCount2;
                    dr[Mold_dgv.Columns["colPeriodicAlarmShotCount3"].HeaderText] = vo.PeriodicAlarmShotCount3;
                    dr[Mold_dgv.Columns["colComment"].HeaderText] = vo.Comment;

                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }

        /// <summary>
        /// Binds Cavity data for excel export
        /// </summary>
        /// <returns></returns>
        private DataTable BindCavityDataForExcel()
        {
            ValueObjectList<CavityVo> outVo = null;

            CavityVo conditionInVo = new CavityVo();

            if (!string.IsNullOrEmpty(MoldCode_txt.Text))
            {
                conditionInVo.MoldCode = MoldCode_txt.Text;
            }

            try
            {
                outVo = (ValueObjectList<CavityVo>)base.InvokeCbm(new GetCavityMasterMntCbm(), conditionInVo, false);

            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            DataTable dt = new DataTable();
            CreateCavityHeaderColumns(dt);

            DataRow dr;
            if (outVo == null)
            {
                return dt;
            }
            if (outVo.GetList().Count > 0)
            {

                foreach (CavityVo vo in outVo.GetList().OrderBy(t => t.MoldCode))
                {
                    dr = dt.NewRow();

                    dr[Mold_dgv.Columns["colMoldCode"].HeaderText] = vo.MoldCode;
                    dr[Properties.Resources.CavityName] = vo.CavityName;

                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }

        /// <summary>
        /// Creates Mold Header for Excel export 
        /// </summary>
        /// <param name="dtOutput"></param>
        private void CreateMoldHeaderColumns(DataTable dtOutput)
        {
            dtOutput.Columns.Add(Mold_dgv.Columns["colMoldCode"].HeaderText);
            dtOutput.Columns.Add(Mold_dgv.Columns["colMoldDrawingNo"].HeaderText);
            dtOutput.Columns.Add(Mold_dgv.Columns["colMoldCategory"].HeaderText);
            dtOutput.Columns.Add(Mold_dgv.Columns["colModel"].HeaderText);
            dtOutput.Columns.Add(Mold_dgv.Columns["colMoldItemCode"].HeaderText);
            dtOutput.Columns.Add(Mold_dgv.Columns["colSapItemCode"].HeaderText);
            dtOutput.Columns.Add(Mold_dgv.Columns["colWidth"].HeaderText);
            dtOutput.Columns.Add(Mold_dgv.Columns["colDepth"].HeaderText);
            dtOutput.Columns.Add(Mold_dgv.Columns["colHeight"].HeaderText);
            dtOutput.Columns.Add(Mold_dgv.Columns["colWeight"].HeaderText);
            dtOutput.Columns.Add(Mold_dgv.Columns["colProductionDate"].HeaderText);
            dtOutput.Columns.Add(Mold_dgv.Columns["colLifeShotCount"].HeaderText);
            dtOutput.Columns.Add(Mold_dgv.Columns["colLifeAlarmShotCount"].HeaderText);
            dtOutput.Columns.Add(Mold_dgv.Columns["colPeriodicAlarmShotCount1"].HeaderText);
            dtOutput.Columns.Add(Mold_dgv.Columns["colPeriodicAlarmShotCount2"].HeaderText);
            dtOutput.Columns.Add(Mold_dgv.Columns["colPeriodicAlarmShotCount3"].HeaderText);
            dtOutput.Columns.Add(Mold_dgv.Columns["colComment"].HeaderText);
        }

        /// <summary>
        /// Creates Cavity Header for Excel export 
        /// </summary>
        /// <param name="dtOutput"></param>
        private void CreateCavityHeaderColumns(DataTable dtOutput)
        {
            dtOutput.Columns.Add(Mold_dgv.Columns["colMoldCode"].HeaderText);
            dtOutput.Columns.Add(Properties.Resources.CavityName);
        }

        #endregion

        #region FormEvents
        /// <summary>
        /// Loads building form
        /// Fill item combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoldDetailForm_Load(object sender, EventArgs e)
        {
            Export_btn.Enabled = Save_btn.Enabled = Update_btn.Enabled = Delete_btn.Enabled = false;
        }

        #endregion

        #region ButtonClick

        /// <summary>
        /// upload mold data from excel file and display in gridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Upload_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog_dlg = new OpenFileDialog();

            openDialog_dlg.Filter = "Excel Files(*.xls) |*.xls";

            if (openDialog_dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            this.StartProgress(Properties.Resources.mmci00013);

            ///read mold excel sheet and return as datatable
            try
            {
                excelUploadDt = new ExcelUpload().ReadExcel(openDialog_dlg.FileName, Properties.Settings.Default.EXCEL_SHEET_MOLD);
            }
            catch (Framework.ApplicationException exception)
            {
                this.CompleteProgress();
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }

            ///read cavity excel sheet and return as datatable
            try
            {
                cavityDataTable = new ExcelUpload().ReadExcel(openDialog_dlg.FileName, Properties.Settings.Default.EXCEL_SHEET_CAVITY);
                cavityDataTable.Columns.Add("CavityCode");
                cavityDataTable.AcceptChanges();
            }
            catch (Framework.ApplicationException exception)
            {
                this.CompleteProgress();
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }



            //check the validation for excel data
            bool inputDataNG=false;
            try
            {
                inputDataNG = ExcelDataValidationFailed();
            }
            catch(Exception ex)
            {
                //mmce00028
                messageData = new MessageData("mmce00022", Properties.Resources.mmce00022);
                logger.Info(messageData,ex);
                popUpMessage.ApplicationError(messageData, Text);
            }

            if (excelUploadDt.Rows.Count > 0)
            {
                if (excelUploadDt.Rows[0]["MoldCode"] == null || string.IsNullOrWhiteSpace(excelUploadDt.Rows[0]["MoldCode"].ToString()))
                {
                    this.CompleteProgress();
                    messageData = new MessageData("mmce00020", Properties.Resources.mmce00020, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                    inputDataNG = true;
                    return;
                }
            }



            cavityDataTable.Select().ToList<DataRow>().ForEach(r => { r["CavityCode"] = r["MoldCode"] + "-" + r["CavityName"]; });

            Mold_dgv.DataSource = null;
            Mold_dgv.AutoGenerateColumns = false;
            isExcelUpload = true;
            Mold_dgv.Columns["colRemarks"].Visible = true;

            excelUploadDt.DefaultView.Sort = "Remarks desc";
            excelUploadDt = excelUploadDt.DefaultView.ToTable();

            BindingSource bindingSource1 = new BindingSource(excelUploadDt, null);
            Mold_dgv.DataSource = bindingSource1;


            List<DataGridViewRow> rowList = Mold_dgv.Rows.Cast<DataGridViewRow>()
                                            .Where(r => r.Cells["colRemarks"].Value.ToString() != string.Empty).ToList();

            foreach (DataGridViewRow row in rowList)
            {
                row.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
            }

            this.CompleteProgress();

            if (inputDataNG)
            {
                Save_btn.Enabled = false;
                return;
            }

            Save_btn.Enabled = true;

        }

        /// <summary>
        /// download excel template for uploading data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Download_btn_Click(object sender, EventArgs e)
        {
            string xlsFileName = Application.StartupPath + "\\" + Properties.Settings.Default.TEMPLATE_FILE_MOLD;

            if (!File.Exists(xlsFileName))
            {
                messageData = new MessageData("mmci00031", Properties.Resources.mmci00031, Properties.Settings.Default.TEMPLATE_FILE_MOLD);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                return;
            }

            ExcelExport_sfdlg.FileName = string.Empty;
            ExcelExport_sfdlg.Filter = "Excel Files(*.xls) |*.xls";

            if (ExcelExport_sfdlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.Copy(xlsFileName, ExcelExport_sfdlg.FileName, true);

                    messageData = new MessageData("mmci00021", Properties.Resources.mmci00021, Properties.Settings.Default.TEMPLATE_FILE_MOLD);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);

                }
                catch (IOException copyError)
                {
                    this.CompleteProgress();
                    messageData = new MessageData("mmcc00001", Properties.Resources.mmcc00001, copyError.Message);
                    popUpMessage.ApplicationError(messageData, Text);
                    logger.Error(messageData);
                    return;
                }
                catch (Framework.ApplicationException ex)
                {
                    this.CompleteProgress();
                    popUpMessage.ApplicationError(ex.GetMessageData(), Text);
                    logger.Error(ex.GetMessageData());
                    return;
                }

            }
        }


        /// <summary>
        /// insert excel data into DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_btn_Click(object sender, EventArgs e)
        {

            foreach (DataRow cavityRow in cavityDataTable.Rows)
            {
                if (!IsValidMoldCode(excelUploadDt, cavityRow["MoldCode"].ToString()) &&
                    !IsMoldCodeExists(cavityRow["MoldCode"].ToString()))
                {
                    messageData = new MessageData("mmce00018", Properties.Resources.mmce00018, cavityRow["MoldCode"].ToString());
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                    return;
                }
            }


            ValueObjectList<ValueObject> inVoList = FormValueObjectListFromExcelToDB();

            UpdateResultVo outVo = null;


            this.StartProgress(Properties.Resources.mmci00009);
            try
            {
                outVo = (UpdateResultVo)base.InvokeCbm(new AddMoldDetailsUsingExcelUploadCbm(), inVoList, false);
            }
            catch (Framework.ApplicationException exception)
            {
                this.CompleteProgress();
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }
            this.CompleteProgress();

            if (outVo != null && outVo.AffectedCount > 0)
            {
                messageData = new MessageData("mmci00010", Properties.Resources.mmci00010, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                GridBind(FormConditionVo());
            }
        }

        /// <summary>
        /// event to clear the controls of search criteria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_btn_Click(object sender, EventArgs e)
        {
            MoldCode_txt.Text = string.Empty;

            ///MoldName_txt.Text = string.Empty;

            Mold_dgv.DataSource = null;

            Export_btn.Enabled = Save_btn.Enabled = Update_btn.Enabled = Delete_btn.Enabled = false;

        }

        /// <summary>
        /// event to get the record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_btn_Click(object sender, EventArgs e)
        {
            GridBind(FormConditionVo());
        }

        /// <summary>
        /// event to open the  add screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_btn_Click(object sender, EventArgs e)
        {
            AddMoldDetailForm newAddForm = new AddMoldDetailForm(CommonConstants.MODE_ADD, null);

            newAddForm.ShowDialog();

            if (newAddForm.IntSuccess > 0)
            {
                messageData = new MessageData("mmci00001", Properties.Resources.mmci00001, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);

                GridBind(FormConditionVo());
            }
        }

        /// <summary>
        /// event to open the  updatescreen 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_btn_Click(object sender, EventArgs e)
        {
            if (Mold_dgv.SelectedCells.Count == 0) return;

            this.Cursor = Cursors.WaitCursor;
            BindUpdateData();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// event to delete the selected record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_btn_Click(object sender, EventArgs e)
        {
            if (Mold_dgv.SelectedCells.Count == 0) return;

            int selectedrowindex = Mold_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = Mold_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colMoldCode"].Value.ToString());
            logger.Info(messageData);
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);


            if (dialogResult == DialogResult.OK)
            {
                MoldDetailVo inVo = new MoldDetailVo
                {
                    MoldId = Convert.ToInt32(selectedRow.Cells["colMoldId"].Value),
                    MoldCode = selectedRow.Cells["colMoldCode"].Value.ToString()
                };

                try
                {

                    this.Cursor = Cursors.WaitCursor;
                    MoldDetailVo outVo = (MoldDetailVo)base.InvokeCbm(new DeleteMoldAndMoldRelationCbm(), inVo, false);

                    if (outVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmci00003", Properties.Resources.mmci00003, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);

                        GridBind(FormConditionVo());
                    }
                    else if (outVo.AffectedCount == 0)
                    {
                        messageData = new MessageData("mmci00007", Properties.Resources.mmci00007, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                        GridBind(FormConditionVo());
                    }
                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                //do something else
            }
        }

        /// <summary>
        /// close form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Export excel data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Export_btn_Click(object sender, EventArgs e)
        {
            SaveFileDialog ExcelExport_dlg = new SaveFileDialog();

            ExcelExport_dlg.FileName = string.Empty;
            ExcelExport_dlg.Filter = "Excel Files(*.xls) |*.xls";

            if (ExcelExport_dlg.ShowDialog() == DialogResult.OK)
            {
                ExportExcelProcess exportData = new ExportExcelProcess();
                DataSet dsExport = new DataSet();

                this.StartProgress(Properties.Resources.mmci00013);

                DataTable moldData = BindMoldDataForExcel();
                moldData.TableName = Properties.Settings.Default.EXCEL_SHEET_MOLD;
                dsExport.Tables.Add(moldData);

                DataTable cavityData = BindCavityDataForExcel();
                cavityData.TableName = Properties.Settings.Default.EXCEL_SHEET_CAVITY;
                dsExport.Tables.Add(cavityData);

                bool created = exportData.WriteToExcel(dsExport, ExcelExport_dlg.FileName);

                this.CompleteProgress();

                if (created)
                {
                    MessageData messageData = new MessageData("mmci00032", Properties.Resources.mmci00032, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }
            }
        }
        #endregion

        #region ControlEvents

        /// <summary>
        /// Handles user record selection for Update/Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mold_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Mold_dgv.SelectedCells.Count > 0 && isExcelUpload == false)
            {
                Update_btn.Enabled = Delete_btn.Enabled = true;
            }
            else
            {
                Update_btn.Enabled = Delete_btn.Enabled = false;
            }
        }

        /// <summary>
        /// Handles update user form show on row double click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mold_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Mold_dgv.SelectedCells.Count > 0 && isExcelUpload == false)
            {
                BindUpdateData();
            }
        }

        /// <summary>
        /// datagridview header mouse click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mold_dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {


            if (Mold_dgv.DataSource == null) { return; }

            DataGridViewColumn column = Mold_dgv.Columns[e.ColumnIndex];
            BindingSource currentDatagridSource = (BindingSource)Mold_dgv.DataSource;

            if (currentDatagridSource.Current.GetType() == typeof(MoldDetailVo))
            {
                List<MoldDetailVo> datasourcevo = (List<MoldDetailVo>)currentDatagridSource.DataSource;
                ValueObjectListSorting(datasourcevo, column);
            }
            else
            {
                DataTable datasourcevo = (DataTable)currentDatagridSource.DataSource;
                DataTableSorting(datasourcevo, column);
            }

            Mold_dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = sortDirection;

        }



        #endregion


    }
}
