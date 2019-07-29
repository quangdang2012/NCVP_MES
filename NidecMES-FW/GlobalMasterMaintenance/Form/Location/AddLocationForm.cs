using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddLocationForm
    {

        #region Variables

        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly LocationVo updateData;

        /// <summary>
        /// Check for Database operation success
        /// </summary>
        public int IntSuccess = -1;


        /// <summary>
        /// datatable for item data
        /// </summary>
        private DataTable buildingDatatable;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddLocationForm));

        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for the  form
        /// </summary>
        /// <param name="pmode"></param>
        /// <param name="userItem"></param>
        public AddLocationForm(string pmode, LocationVo userItem = null)
        {
            InitializeComponent();

            mode = pmode;
         
            updateData = userItem;

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
            if (LocationCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, LocationCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                LocationCode_txt.Focus();

                return false;
            }

            if (LocationName_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, LocationName_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                LocationName_txt.Focus();

                return false;
            }
            if (Building_cmb.Text == string.Empty || Building_cmb.SelectedIndex < 0)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, Mold_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                Building_cmb.Focus();

                return false;
            }

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
        private void LoadUserData(LocationVo dgvMoldType)
        {
            if (dgvMoldType != null)
            {
                this.LocationCode_txt.Text = dgvMoldType.LocationCode;

                this.LocationName_txt.Text = dgvMoldType.LocationName;

                this.Building_cmb.SelectedValue = dgvMoldType.BuildingId.ToString();
            }
        }

        /// <summary>
        /// form country and factory data for combo
        /// </summary>
        private void FormDatatableFromVo()
        {
            buildingDatatable = new DataTable();
            buildingDatatable.Columns.Add("id");
            buildingDatatable.Columns.Add("name");

            try
            {
                BuildingVo buOutVo = (BuildingVo)base.InvokeCbm(new GetBuildingMasterMntCbm(), new BuildingVo(), false);

                foreach (BuildingVo bu in buOutVo.BuildingListVo)
                {
                    buildingDatatable.Rows.Add(bu.BuildingId, bu.BuildingName);
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
        private LocationVo DuplicateCheck(LocationVo LocationVo)
        {
            LocationVo outVo = new LocationVo();

            try
            {
                outVo = (LocationVo)base.InvokeCbm(new CheckLocationMasterMntCbm(), LocationVo, false);
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
        private void AddLocationForm_Load(object sender, EventArgs e)
        {
            FormDatatableFromVo();

            ComboBind(Building_cmb, buildingDatatable, "name", "id");

            LocationCode_txt.Select();

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadUserData(updateData);

                LocationCode_txt.Enabled = false;

                LocationName_txt.Select();

            }


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
            LocationVo inVo = new LocationVo();

            if (CheckMandatory())
            {

                var sch = StringCheckHelper.GetInstance();

                if (!sch.IsASCII(LocationCode_txt.Text) || !sch.IsASCII(LocationName_txt.Text))
                {
                    messageData = new MessageData("mmce00003", Properties.Resources.mmce00003);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);

                    if (!sch.IsASCII(LocationCode_txt.Text))
                    {
                        LocationCode_txt.Focus();
                    }
                    else
                    {
                        LocationName_txt.Focus();
                    }

                    return;
                }

                //if(LocationCode_txt.Text.Trim().Length < 4)
                //{
                //    MessageData messageData = new MessageData("mmci00008", Properties.Resources.mmci00008, LocationCode_lbl.Text);
                //    popUpMessage.Warning(messageData, Text);
                //    LocationCode_txt.Focus();
                //    return;                  
                //}

                inVo.LocationCode = LocationCode_txt.Text.Trim();

                inVo.LocationName = LocationName_txt.Text.Trim();

                inVo.BuildingId = Convert.ToInt32(Building_cmb.SelectedValue);

                if (string.Equals(mode, CommonConstants.MODE_ADD))
                {
                    LocationVo checkVo = DuplicateCheck(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, LocationCode_lbl.Text + " : " + LocationCode_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.ConfirmationOkCancel(messageData, Text);
                        LocationCode_txt.Focus();
                        return;
                    }
                }

                try
                {
                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        LocationVo outVo = (LocationVo)base.InvokeCbm(new AddLocationMasterMntCbm(), inVo, false);

                        IntSuccess = outVo.AffectedCount;
                    }
                    else if (mode.Equals(CommonConstants.MODE_UPDATE))
                    {
                        inVo.LocationId = updateData.LocationId;

                        LocationVo outVo = (LocationVo)base.InvokeCbm(new UpdateLocationMasterMntCbm(), inVo, false);

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
