using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddAreaForm
    {

        #region Variables

        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly AreaVo updateData;

        /// <summary>
        /// Check for Database operation success
        /// </summary>
        public int IntSuccess = -1;


        /// <summary>
        /// datatable for item data
        /// </summary>
        private DataTable locationDatatable;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddAreaForm));

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
        public AddAreaForm(string pmode, AreaVo userItem = null)
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
            if (AreaCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, AreaCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                AreaCode_txt.Focus();

                return false;
            }

            if (AreaName_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, AreaName_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                AreaName_txt.Focus();

                return false;
            }
            if (Location_cmb.Text == string.Empty || Location_cmb.SelectedIndex < 0)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, Location_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                Location_cmb.Focus();

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
        private void LoadUserData(AreaVo dgvMoldType)
        {
            if (dgvMoldType != null)
            {
                this.AreaCode_txt.Text = dgvMoldType.AreaCode;

                this.AreaName_txt.Text = dgvMoldType.AreaName;

                this.Location_cmb.SelectedValue = dgvMoldType.LocationId.ToString();
            }
        }

        /// <summary>
        /// form country and factory data for combo
        /// </summary>
        private void FormDatatableFromVo()
        {
            locationDatatable = new DataTable();
            locationDatatable.Columns.Add("id");
            locationDatatable.Columns.Add("name");

            try
            {
                LocationVo buOutVo = (LocationVo)base.InvokeCbm(new GetLocationMasterMntCbm(), new LocationVo(), false);

                foreach (LocationVo bu in buOutVo.LocationListVo)
                {
                    locationDatatable.Rows.Add(bu.LocationId, bu.LocationName);
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
        private AreaVo DuplicateCheck(AreaVo AreaVo)
        {
            AreaVo outVo = new AreaVo();

            try
            {
                outVo = (AreaVo)base.InvokeCbm(new CheckAreaMasterMntCbm(), AreaVo, false);
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
        private void AddAreaForm_Load(object sender, EventArgs e)
        {
            FormDatatableFromVo();

            ComboBind(Location_cmb, locationDatatable, "name", "id");

            AreaCode_txt.Select();

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadUserData(updateData);

                AreaCode_txt.Enabled = false;

                AreaName_txt.Select();

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
            AreaVo inVo = new AreaVo();

            if (CheckMandatory())
            {

                var sch = StringCheckHelper.GetInstance();

                if (!sch.IsASCII(AreaCode_txt.Text) || !sch.IsASCII(AreaName_txt.Text))
                {
                    messageData = new MessageData("mmce00003", Properties.Resources.mmce00003);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);

                    if (!sch.IsASCII(AreaCode_txt.Text))
                    {
                        AreaCode_txt.Focus();
                    }
                    else
                    {
                        AreaName_txt.Focus();
                    }

                    return;
                }

                //if(AreaCode_txt.Text.Trim().Length < 4)
                //{
                //    MessageData messageData = new MessageData("mmci00008", Properties.Resources.mmci00008, AreaCode_lbl.Text);
                //    popUpMessage.Warning(messageData, Text);
                //    AreaCode_txt.Focus();
                //    return;                  
                //}

                inVo.AreaCode = AreaCode_txt.Text.Trim();

                inVo.AreaName = AreaName_txt.Text.Trim();

                inVo.LocationId = Convert.ToInt32(Location_cmb.SelectedValue);

                if (string.Equals(mode, CommonConstants.MODE_ADD))
                {
                    AreaVo checkVo = DuplicateCheck(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, AreaCode_lbl.Text + " : " + AreaCode_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.ConfirmationOkCancel(messageData, Text);
                        AreaCode_txt.Focus();
                        return;
                    }
                }

                try
                {
                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        AreaVo outVo = (AreaVo)base.InvokeCbm(new AddAreaMasterMntCbm(), inVo, false);

                        IntSuccess = outVo.AffectedCount;
                    }
                    else if (mode.Equals(CommonConstants.MODE_UPDATE))
                    {
                        inVo.AreaId = updateData.AreaId;

                        AreaVo outVo = (AreaVo)base.InvokeCbm(new UpdateAreaMasterMntCbm(), inVo, false);

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
