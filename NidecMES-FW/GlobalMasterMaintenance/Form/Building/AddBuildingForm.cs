using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Resources;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddBuildingForm
    {

        #region Variables

        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
       private readonly BuildingVo updateData;

        /// <summary>
        /// Check for Database operation success
        /// </summary>
        public int IntSuccess = -1;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddBuildingForm));

        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        /// declares factory data table
        /// </summary>
        private DataTable factoryDatatable;

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for the  form
        /// </summary>
        /// <param name="pmode"></param>
        /// <param name="userItem"></param>
        //public AddBuldingForm(string pmode, buildingVo userItem = null)
        //{
        //    InitializeComponent();

        //    mode = pmode;

        //    updateData = userItem;

        //    if (string.Equals(mode, CommonConstants.MODE_UPDATE))
        //    {
        //        this.Text = UpdateText_lbl.Text;
        //    }
        //}

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Checks mandatory fields
        /// </summary>
        /// <returns></returns>
        private bool CheckMandatory()
        {
            if (BuildingCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, BuildingCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                BuildingCode_txt.Focus();

                return false;
            }

            if (BuildingName_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, BuildingName_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                BuildingName_txt.Focus();

                return false;
            }
            if (FactoryCode_cmb.Text == string.Empty || FactoryCode_cmb.SelectedIndex < 0)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, Factory_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                FactoryCode_cmb.Focus();

                return false;
            }

            return true;
        }

        /// <summary>
        /// For binding Country , Language and factory controls
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
        /// loads factory and country data table
        /// </summary>
        private void FormDatatableFromVo()
        {
            factoryDatatable = new DataTable();
            factoryDatatable.Columns.Add("code");
            factoryDatatable.Columns.Add("Name");
            try
            {
                FactoryVo factoryOutVo = (FactoryVo)base.InvokeCbm(new GetFactoryMasterMntCbm(), new FactoryVo(), false);

                foreach (FactoryVo fac in factoryOutVo.FactoryListVo)
                {
                    factoryDatatable.Rows.Add(fac.FactoryCode, fac.FactoryName);
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for the  form
        /// </summary>
        /// <param name="pmode"></param>
        /// <param name="userItem"></param>
        public AddBuildingForm(string pmode, BuildingVo userItem = null)
        {
            InitializeComponent();

            mode = pmode;

            updateData = userItem;

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                this.Text = UpdateText_lbl.Text;
            }
        }

        /// <summary>
        /// For setting selected user record into respective controls(textbox and combobox) for update operation
        /// passing selected user data as parameter 
        /// </summary>
        /// <param name="dgvMoldType"></param>
        private void LoadUserData(BuildingVo dgvMoldType)
        {
            if (dgvMoldType != null)
            {
                this.BuildingCode_txt.Text = dgvMoldType.BuildingCode;

                this.BuildingName_txt.Text = dgvMoldType.BuildingName;
                this.FactoryCode_cmb.SelectedValue = dgvMoldType.FactoryCode;
            }
        }

        /// <summary>
        /// form country and factory data for combo
        /// </summary>
        //private void FormDatatableFromVo()
        //{
        //    moldDatatable = new DataTable();
        //    moldDatatable.Columns.Add("id");
        //    moldDatatable.Columns.Add("code");

        //    try
        //    {
        //        MoldVo moldOutVo = (MoldVo)base.InvokeCbm(new GetMoldMasterMntCbm(), new MoldVo (), false);

        //        foreach (MoldVo mold in moldOutVo.MoldListVo)
        //        {
        //            moldDatatable.Rows.Add(mold.MoldId, mold.MoldCode);
        //        }
        //    }
        //    catch (Framework.ApplicationException exception)
        //    {
        //        popUpMessage.ApplicationError(exception.GetMessageData(), Text);
        //        logger.Error(exception.GetMessageData());
        //    }
        //}

        /// <summary>
        /// checks duplicate mold Code
        /// </summary>
        /// <returns></returns>
        private BuildingVo DuplicateCheck(BuildingVo BuildingVo)
        {
            BuildingVo outVo = new BuildingVo();

            try
            {
                outVo = (BuildingVo)base.InvokeCbm(new CheckBuildingMasterMntCbm(), BuildingVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
            return outVo;
        }
        #endregion

        #region FormEvents
        /// <summary>
        /// Handles Load event for mold data Insert/Update operations 
        /// Loading mold data for update mold data and binding controls with selected mold record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBuildingForm_Load(object sender, EventArgs e)
        {
           FormDatatableFromVo();

            BuildingCode_txt.Select();
            ComboBind(FactoryCode_cmb, factoryDatatable, "code", "code");

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadUserData(updateData);
                BuildingCode_txt.Enabled = false;
                BuildingName_txt.Select();

            }
            BuildingCode_txt.Focus();
        }
        #endregion

        #region ButtonClick

        /// <summary>
        /// update the  record to db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_btn_Click(object sender, EventArgs e)
        {
            BuildingVo inVo = new BuildingVo();

            if (CheckMandatory())
            {

                var sch = StringCheckHelper.GetInstance();

                if (!sch.IsASCII(BuildingCode_txt.Text))
                {
                    messageData = new MessageData("mmce00003", Properties.Resources.mmce00003);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);

                    if (!sch.IsASCII(BuildingCode_txt.Text))
                    {
                        BuildingCode_txt.Focus();
                    }
                    else
                    {
                        BuildingName_txt.Focus();
                    }

                    return;
                }
                inVo.BuildingCode = BuildingCode_txt.Text.Trim();

                inVo.BuildingName = BuildingName_txt.Text.Trim();
                inVo.FactoryCode = FactoryCode_cmb.SelectedValue.ToString();

                if (string.Equals(mode, CommonConstants.MODE_ADD))
                {
                    BuildingVo checkVo = DuplicateCheck(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, BuildingCode_lbl.Text + " : " + BuildingCode_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.ConfirmationOkCancel(messageData, Text);
                        BuildingCode_txt.Focus();
                        return;
                    }
                }

                try
                {
                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        BuildingVo outVo = (BuildingVo)base.InvokeCbm(new AddBuildingMasterMntCbm(), inVo, false);

                        IntSuccess = outVo.AffectedCount;
                    }
                    else if (mode.Equals(CommonConstants.MODE_UPDATE))
                    {
                        inVo.BuildingId = updateData.BuildingId;

                        BuildingVo outVo = (BuildingVo)base.InvokeCbm(new UpdateBuildingMasterMntCbm(), inVo, false);

                        IntSuccess = outVo.AffectedCount;
                    }

                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                    return;
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
        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}