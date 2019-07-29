using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using System.Resources;
using System.Data;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddDefectiveReasonNewForm
    {

        #region Variables

        private DataTable defectiveCategoryDatatable;
        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly DefectiveReasonVo updateData;

        /// <summary>
        /// Check for Database operation success
        /// </summary>
        public int IntSuccess = -1;

        private bool rowbool = false;

        private int SelectOldRow = 0;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddDefectiveReasonNewForm));

        #endregion

        #region Constructor
        /// <summary>
        /// constructor for the form
        /// </summary>
        /// <param name="pmode"></param>
        /// <param name="dataItem"></param>
        public AddDefectiveReasonNewForm(string pmode, DefectiveReasonVo dataItem = null)
        {
            InitializeComponent();

            mode = pmode;
           
            updateData = dataItem;
            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                this.Text = UpdateText_lbl.Text;
            }
        }

        private void ComboBind(ComboBox pCombo, DataTable pDatasource, string pDisplay, string pValue)
        {
            pCombo.DataSource = pDatasource;
            pCombo.DisplayMember = pDisplay;
            pCombo.ValueMember = pValue;
            pCombo.SelectedIndex = -1;
            pCombo.Text = string.Empty;
        }

        private void FormDatatableFromVo()
        {
            defectiveCategoryDatatable = new DataTable();
            defectiveCategoryDatatable.Columns.Add("id");
            defectiveCategoryDatatable.Columns.Add("name");

            try
            {
                DefectiveCategoryVo defectiveCategoryOutVo = (DefectiveCategoryVo)base.InvokeCbm(new GetDefectiveCategoryMasterMntCbm(), new DefectiveCategoryVo(), false);

                foreach (DefectiveCategoryVo defectiveCategory in defectiveCategoryOutVo.DefectiveCategoryListVo)
                {
                    defectiveCategoryDatatable.Rows.Add(defectiveCategory.DefectiveCategoryId, defectiveCategory.DefectiveCategoryName);
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }
        #endregion

        #region PrivateMethods

        /// <summary>
        /// Checks mandatory fields
        /// </summary>
        /// <returns></returns>
        private bool CheckMandatory()
        {
            if (DefectiveReasonCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, DefectiveReasonCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                DefectiveReasonCode_txt.Focus();

                return false;
            }
            if (DefectiveReasonName_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, DefectiveReasonName_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                DefectiveReasonName_txt.Focus();

                return false;
            }
            if (DisplayOrder_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, DisplayOrder_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                DisplayOrder_txt.Focus();

                return false;
            }
            return true;
        }

        /// <summary>
        /// For setting selected user record into respective controls(textbox and combobox) for update operation
        /// passing selected user data as parameter 
        /// </summary>
        /// <param name="dgvData"></param>
        private void LoadUserData(DefectiveReasonVo dgvData)
        {
            if (dgvData != null)
            {
                DefectiveReasonCode_txt.Text = dgvData.DefectiveReasonCode;
                DefectiveReasonName_txt.Text = dgvData.DefectiveReasonName;
                DefectiveCategory_cmb.SelectedValue = dgvData.DefectiveCategoryId.ToString();
                DisplayOrder_txt.Text = dgvData.DisplayOrder.ToString();
            }
        }

        /// <summary>
        /// checks duplicate Defective reason Code
        /// </summary>
        /// <param name="defectVo"></param>
        /// <returns></returns>
        private DefectiveReasonVo DuplicateCheck(DefectiveReasonVo defectVo)
        {
            DefectiveReasonVo outVo = new DefectiveReasonVo();

            try
            {
                outVo = (DefectiveReasonVo)base.InvokeCbm(new CheckDefectiveReasonMasterMntCbm(), defectVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            return outVo;
        }

        /// <summary>
        /// checks duplicate Display Record
        /// </summary>
        /// <param name="defectVo"></param>
        /// <returns></returns>
        private DefectiveReasonVo DuplicateDisplayCheck(DefectiveReasonVo defectVo)
        {
            DefectiveReasonVo outVo = new DefectiveReasonVo();

            try
            {
                outVo = (DefectiveReasonVo)base.InvokeCbm(new CheckDisplayRecordMasterMntCbm(), defectVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            return outVo;
        }

        private ProcessDefectiveReasonVo GetSelectedProcessWork()
        {
            BindingSource bsProcessWork = (BindingSource)ProcessWork_dgv.DataSource;
            ProcessDefectiveReasonVo processDefectiveRsnInVo = new ProcessDefectiveReasonVo();

            if (bsProcessWork != null && bsProcessWork.List.Count > 0)
            {
                foreach (ProcessWorkVo processWorkVo in bsProcessWork.List)
                {
                    if (processWorkVo.IsExists == "True")
                    {
                        ProcessDefectiveReasonVo addVo = new ProcessDefectiveReasonVo
                        {
                            ProcessWorkId = processWorkVo.ProcessWorkId
                        };
                        processDefectiveRsnInVo.ProcessDefectiveReasonListVo.Add(addVo);
                    }
                }
            }

            return processDefectiveRsnInVo;
        }

        /// <summary>
        /// binds grid
        /// </summary>
        /// <param name="defectiveReasonId"></param>
        private void BindGrid(int defectiveReasonId)
        {
            ProcessWorkVo outVo = null;

            try
            {
                outVo = (ProcessWorkVo)DefaultCbmInvoker.Invoke(new GetProcessWorkMasterMntCbm(), new ProcessWorkVo());

                outVo.ProcessWorkListVo.ForEach(t => t.ProcessWorkName = string.Concat(t.ProcessWorkCode + "  ", t.ProcessWorkName));
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }


            ProcessDefectiveReasonVo processDefectRsnOutVo = null;
            ProcessDefectiveReasonVo inVo = new ProcessDefectiveReasonVo();
            inVo.DefectiveReasonId = defectiveReasonId;

            try
            {
                processDefectRsnOutVo = (ProcessDefectiveReasonVo)DefaultCbmInvoker.Invoke(new GetProcessDefectiveReasonMasterMntCbm(), inVo);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }

            if (outVo != null && defectiveReasonId > 0)
            {
                foreach (ProcessWorkVo item in outVo.ProcessWorkListVo)
                {
                    item.IsExists = processDefectRsnOutVo.ProcessDefectiveReasonListVo.Exists(t => t.ProcessWorkId == item.ProcessWorkId) ? "True" : "False";
                }
            }

            BindingSource bindingSource = new BindingSource(outVo.ProcessWorkListVo, null);
            ProcessWork_dgv.AutoGenerateColumns = false;
            ProcessWork_dgv.DataSource = bindingSource;

        }
        #endregion

        #region FormEvents
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDefectiveReasonNewForm_Load(object sender, EventArgs e)
        {

            FormDatatableFromVo();

            if (defectiveCategoryDatatable.Rows.Count > 0)
            {
                ComboBind(DefectiveCategory_cmb, defectiveCategoryDatatable, "name", "id");
            }
            else
            {
                DefectiveCategory_cmb.Enabled = false;
            }

            DefectiveReasonCode_txt.Select();
            int defectRsnId = 0;

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadUserData(updateData);

                defectRsnId = updateData.DefectiveReasonId;

                DefectiveReasonCode_txt.Enabled = false;

                DefectiveReasonName_txt.Select();
            }
            else
            {
                DefectiveReasonVo outVo = null;
                try
                {
                    outVo = (DefectiveReasonVo)base.InvokeCbm(new GetDefectiveReasonDisplayOrderCbm(), null, false);
                }
                catch (Framework.ApplicationException ex)
                {
                    popUpMessage.ApplicationError(ex.GetMessageData(), this.TitleText);
                }
               
                if (outVo != null)
                {
                    DisplayOrder_txt.Text = outVo.DisplayOrder.ToString();
                }
                else
                {
                    DisplayOrder_txt.Text = "1";
                }
            }

            BindGrid(defectRsnId);

        }
        #endregion

        #region ButtonClick

        /// <summary>
        /// form close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// inserts/updates def reason
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_btn_Click(object sender, EventArgs e)
        {
            DefectiveReasonVo inVo = new DefectiveReasonVo();

            if (CheckMandatory())
            {
                var sch = StringCheckHelper.GetInstance();

                if (!sch.IsASCII(DefectiveReasonCode_txt.Text))
                {
                    messageData = new MessageData("mmce00003", Properties.Resources.mmce00003);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);
                    DefectiveReasonCode_txt.Focus();
                    return;
                }

                

                ValueObjectList<ValueObject> inVoList = new ValueObjectList<ValueObject>();

                inVo.DefectiveReasonCode = DefectiveReasonCode_txt.Text.Trim();

                inVo.DefectiveReasonName = DefectiveReasonName_txt.Text.Trim();

                inVo.DefectiveCategoryId = Convert.ToInt32(DefectiveCategory_cmb.SelectedValue);

                inVo.DisplayOrder = Convert.ToInt32(DisplayOrder_txt.Text);

                inVo.RegistrationUserCode = UserData.GetUserData().UserCode;

                inVo.FactoryCode = UserData.GetUserData().FactoryCode;

                if (string.Equals(mode, CommonConstants.MODE_ADD))
                {
                    DefectiveReasonVo checkVo = DuplicateCheck(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001,  DefectiveReasonCode_lbl.Text + " : " + DefectiveReasonCode_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.ConfirmationOkCancel(messageData, Text);
                        DefectiveReasonCode_txt.Focus();
                        return;
                    }
                    DefectiveReasonVo checkDisplayVo = DuplicateDisplayCheck(inVo);
                    if (checkDisplayVo != null && checkDisplayVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, DisplayOrder_lbl.Text + " : " + DisplayOrder_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.ConfirmationOkCancel(messageData, Text);
                        DisplayOrder_txt.Focus();
                        return;
                    }

                }

                try
                {
                    this.StartProgress(Properties.Resources.mmci00009);

                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        inVoList.add(inVo);

                        inVoList.add(GetSelectedProcessWork());

                        DefectiveReasonVo outVo = (DefectiveReasonVo)base.InvokeCbm(new AddDefectiveReasonMasterMntNewCbm(), inVoList, false);

                        IntSuccess = outVo.AffectedCount;
                    }
                    else if (mode.Equals(CommonConstants.MODE_UPDATE))
                    {
                        inVo.DefectiveReasonId = updateData.DefectiveReasonId;

                        inVoList.add(inVo);

                        inVoList.add(GetSelectedProcessWork());

                        DefectiveReasonVo outVo = (DefectiveReasonVo)base.InvokeCbm(new UpdateDefectiveReasonMasterMntNewCbm(), inVoList, false);

                        IntSuccess = outVo.AffectedCount;

                    }

                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                    return;
                }
                finally
                {
                    this.CompleteProgress();
                }

                if ((IntSuccess > 0) || (IntSuccess == 0))
                {
                    this.Close();
                }

            }
        }
        #endregion

        #region control events

        /// <summary>
        /// select all  process work
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckAll_chk_CheckedChanged(object sender, EventArgs e)
        {
            if (!CheckAll_chk.Checked)
            {
                foreach (DataGridViewRow row in ProcessWork_dgv.Rows)
                {
                    if (row.Cells["colSelect"].ReadOnly == false)
                    {
                        row.Cells["colSelect"].Value = null;
                    }

                }
            }
            else
            {
                foreach (DataGridViewRow row in ProcessWork_dgv.Rows)
                {
                    if (row.Cells["colSelect"].ReadOnly == false)
                    {
                        row.Cells["colSelect"].Value = "True";
                    }

                }
            }
        }


        private void ProcessWork_dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (rowbool && (!Convert.ToBoolean(ProcessWork_dgv.Rows[e.RowIndex].Cells["colSelect"].Value)))
            {
                CheckWorkCenterReasonVo InVo = new CheckWorkCenterReasonVo();
                CheckWorkCenterReasonVo outVo = new CheckWorkCenterReasonVo();
                InVo.Defective_Reason_ID = DefectiveReasonCode_txt.Text;
                InVo.Flag = 0;
                InVo.Work_Center = Convert.ToInt32(ProcessWork_dgv.Rows[SelectOldRow].Cells["colProcessWorkId"].Value.ToString().Trim());
                outVo = (CheckWorkCenterReasonVo)base.InvokeCbm(new Cbm.DefectiveReason.CheckWorkCenterReasonCbm(), InVo, false);

                if (outVo.Flag > 0)
                {
                    ProcessWork_dgv.Rows[SelectOldRow].Cells["colSelect"].Value = true;
                }
            }
        }

        private void ProcessWork_dgv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            rowbool = Convert.ToBoolean(ProcessWork_dgv.Rows[e.RowIndex].Cells["colSelect"].Value);
            SelectOldRow = e.RowIndex;
        }



        #endregion

    }
}
