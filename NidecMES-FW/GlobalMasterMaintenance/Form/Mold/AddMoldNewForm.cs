using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using System.Resources;
using System.Data;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddMoldNewForm
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
        private readonly MoldVo updateData;

        /// <summary>
        /// datatable for item data
        /// </summary>
        private DataTable moldTypeDatatable;

        /// <summary>
        /// Check for Database operation success
        /// </summary>
        public int IntSuccess = -1;

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
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddMoldNewForm));

        #endregion

        #region Constructor
        /// <summary>
        /// constructor for the form
        /// </summary>
        /// <param name="pmode"></param>
        /// <param name="dataItem"></param>
        public AddMoldNewForm(string pmode, MoldVo dataItem = null)
        {
            InitializeComponent();

            mode = pmode;
           
            updateData = dataItem;
            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                this.Text = UpdateText_lbl.Text;
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
            if (MoldCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, MoldCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                MoldCode_txt.Focus();

                return false;
            }

            if (MoldName_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, MoldName_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                MoldName_txt.Focus();

                return false;
            }

            //if (MoldType_cmb.Text == string.Empty || MoldType_cmb.SelectedIndex < 0)
            //{
            //    messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, MoldType_lbl.Text);
            //    popUpMessage.Warning(messageData, Text);

            //    MoldType_cmb.Focus();

            //    return false;
            //}

            return true;
        }


        /// <summary>
        /// For binding item
        /// </summary>
        /// <param name="pCombo"></param>
        /// <param name="pDatasource"></param>
        /// <param name="pDisplay"></param>
        /// <param name="pValue"></param>
        private void ComboBind(ComboBox pCombo, DataTable pDatasource, string pDisplay, string pValue)
        {
            pCombo.DataSource = pDatasource;
            pCombo.DisplayMember = pDisplay;
            pCombo.ValueMember = pValue;
            pCombo.SelectedIndex = -1;
            pCombo.Text = string.Empty;
        }

        /// <summary>
        /// For setting selected user record into respective controls(textbox and combobox) for update operation
        /// passing selected user data as parameter 
        /// </summary>
        /// <param name="dgvMoldType"></param>
        private void LoadUserData(MoldVo dgvMoldType)
        {
            if (dgvMoldType != null)
            {
                this.MoldCode_txt.Text = dgvMoldType.MoldCode;

                this.MoldName_txt.Text = dgvMoldType.MoldName;

                this.MoldType_cmb.SelectedValue = dgvMoldType.MoldTypeId.ToString();

                MoldVo conditionInVo = new MoldVo();
                conditionInVo.MoldId = dgvMoldType.MoldId;

                MoldVo outVo = (MoldVo)base.InvokeCbm(new GetMoldMasterMntCbm(), conditionInVo, false);

                if (outVo.MoldListVo.Count > 0)
                {
                    Weight_txt.Text = outVo.MoldListVo[0].Weight.ToString();

                    Width_txt.Text = outVo.MoldListVo[0].Width.ToString();

                    Height_txt.Text = outVo.MoldListVo[0].Height.ToString();

                    Depth_txt.Text = outVo.MoldListVo[0].Depth.ToString();

                    LifeShotCount_txt.Text = outVo.MoldListVo[0].LifeShotCount.ToString();

                    Comment_txt.Text = outVo.MoldListVo[0].Comment;

                    if (outVo.MoldListVo[0].ProductionDate != null && outVo.MoldListVo[0].ProductionDate != DateTime.MinValue)
                    {
                        ProductionDate_dtp.Value = outVo.MoldListVo[0].ProductionDate;
                    }

                }
            }
        }

        /// <summary>
        /// form country and factory data for combo
        /// </summary>
        private void FormDatatableFromVo()
        {
            moldTypeDatatable = new DataTable();
            moldTypeDatatable.Columns.Add("id");
            moldTypeDatatable.Columns.Add("code");

            try
            {
                MoldTypeVo moldTypeOutVo = (MoldTypeVo)base.InvokeCbm(new GetMoldTypeMasterMntCbm(), new MoldTypeVo(), false);

                foreach (MoldTypeVo moldType in moldTypeOutVo.MoldTypeListVo)
                {
                    moldTypeDatatable.Rows.Add(moldType.MoldTypeId, moldType.MoldTypeCode);
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
        /// <param name="moldVo"></param>
        /// <returns></returns>
        private MoldVo DuplicateCheck(MoldVo moldVo)
        {
            MoldVo outVo = new MoldVo();

            try
            {
                outVo = (MoldVo)base.InvokeCbm(new CheckMoldMasterMntCbm(), moldVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            return outVo;
        }

        /// <summary>
        /// binds grid
        /// </summary>
        /// <param name="processMoldId"></param>
        private void BindGrid(int processMoldId)
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


            ProcessWorkMoldVo processWorkMoldOutVo = null;
            ProcessWorkMoldVo inVo = new ProcessWorkMoldVo();
            inVo.MoldId = processMoldId;

            try
            {
                processWorkMoldOutVo = (ProcessWorkMoldVo)DefaultCbmInvoker.Invoke(new GetProcessWorkMoldMasterMntCbm(), inVo);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }

            if (outVo != null && processMoldId > 0)
            {
                foreach (ProcessWorkVo item in outVo.ProcessWorkListVo)
                {
                    item.IsExists = processWorkMoldOutVo.ProcessWorkMoldListVo.Exists(t => t.ProcessWorkId == item.ProcessWorkId) ? "True" : "False";
                }
            }

            BindingSource bindingSource = new BindingSource(outVo.ProcessWorkListVo, null);
            ProcessWork_dgv.AutoGenerateColumns = false;
            ProcessWork_dgv.DataSource = bindingSource;

        }

        /// <summary>
        /// To Get the Selected ProcessWork from the Grid
        /// </summary>
        /// <returns></returns>
        private ProcessWorkMoldVo GetSelectedProcessWork()
        {
            BindingSource bsProcessWork = (BindingSource)ProcessWork_dgv.DataSource;
            ProcessWorkMoldVo processworkmoldInVo = new ProcessWorkMoldVo();

            if (bsProcessWork != null && bsProcessWork.List.Count > 0)
            {
                foreach (ProcessWorkVo processWorkVo in bsProcessWork.List)
                {
                    if (processWorkVo.IsExists == "True")
                    {
                        ProcessWorkMoldVo addVo = new ProcessWorkMoldVo
                        {
                            ProcessWorkId = processWorkVo.ProcessWorkId
                        };
                        processworkmoldInVo.ProcessWorkMoldListVo.Add(addVo);
                    }
                }
            }

            return processworkmoldInVo;
        }

        #endregion

        #region FormEvents
        /// <summary>
        /// Handles Load event for mold data Insert/Update operations 
        /// Loading mold data for update mold data and binding controls with selected mold record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddMoldNewForm_Load(object sender, EventArgs e)
        {
           
                this.ProductionDate_dtp.Clear();

                FormDatatableFromVo();

                ComboBind(MoldType_cmb, moldTypeDatatable, "code", "id");

                MoldCode_txt.Select();
                int ProcessMoldId = 0;

                if (string.Equals(mode, CommonConstants.MODE_UPDATE))
                {
                    LoadUserData(updateData);

                    ProcessMoldId = updateData.MoldId;

                    MoldCode_txt.Enabled = false;

                    MoldName_txt.Select();

                }
                
                BindGrid(ProcessMoldId);
            
        }
        

        #endregion

        #region ButtonClick

        /// <summary>
        /// update data to db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Ok_btn_Click(object sender, EventArgs e)
        {

            if (CheckMandatory())
            {
                ValueObjectList<ValueObject> inVoList = new ValueObjectList<ValueObject>();

                var sch = StringCheckHelper.GetInstance();

                if (!sch.IsASCII(MoldCode_txt.Text))
                {
                    messageData = new MessageData("mmce00003", Properties.Resources.mmce00003);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);
                    MoldCode_txt.Focus();

                    return;
                }

                MoldVo inVo = new MoldVo();

                inVo.MoldCode = MoldCode_txt.Text.Trim();
                inVo.MoldName = MoldName_txt.Text.Trim();
                inVo.MoldTypeId = Convert.ToInt32(MoldType_cmb.SelectedValue);

                if (!string.IsNullOrEmpty(Weight_txt.Text))
                { inVo.Weight = Convert.ToDecimal(Weight_txt.Text); }

                if (!string.IsNullOrEmpty(Height_txt.Text))
                { inVo.Height = Convert.ToDecimal(Height_txt.Text); }

                if (!string.IsNullOrEmpty(Width_txt.Text))
                { inVo.Width = Convert.ToDecimal(Width_txt.Text); }

                if (!string.IsNullOrEmpty(Depth_txt.Text))
                { inVo.Depth = Convert.ToDecimal(Depth_txt.Text); }

                if (!string.IsNullOrWhiteSpace(ProductionDate_dtp.Text))
                {
                    inVo.ProductionDate = Convert.ToDateTime(ProductionDate_dtp.Value);
                }

                inVo.Comment = Comment_txt.Text;

                if (!string.IsNullOrEmpty(LifeShotCount_txt.Text))
                { inVo.LifeShotCount = Convert.ToInt32(LifeShotCount_txt.Text); }

                if (string.Equals(mode, CommonConstants.MODE_ADD))
                {
                    MoldVo checkVo = DuplicateCheck(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, MoldCode_lbl.Text + " : " + MoldCode_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.ApplicationError(messageData, Text);

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

                        MoldVo outVo = (MoldVo)base.InvokeCbm(new AddMoldMasterMntNewCbm(), inVoList, false);

                        IntSuccess = outVo.AffectedCount;
                    }
                    else if (mode.Equals(CommonConstants.MODE_UPDATE))
                    {
                        inVo.MoldId = updateData.MoldId;

                        inVoList.add(inVo);

                        inVoList.add(GetSelectedProcessWork());

                        MoldVo outVo = (MoldVo)base.InvokeCbm(new UpdateMoldMasterMntNewCbm(), inVoList, false);

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

        /// <summary>
        /// close the screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Control Events
        private void ProductionDate_dtp_ValueChanged(object sender, EventArgs e)
        {
            ProductionDate_dtp.CustomFormat = UserData.GetUserData().DateTimeFormat.ShortDatePattern;
        }

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

        #endregion

    }
}
