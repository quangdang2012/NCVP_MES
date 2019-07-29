using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddPaletteForm
    {

        #region Variables

        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly PaletteVo updateData;

        /// <summary>
        /// Check for Database operation success
        /// </summary>
        public int IntSuccess = -1;


        /// <summary>
        /// datatable for item data
        /// </summary>
        private DataTable areaDatatable;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddPaletteForm));

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
        public AddPaletteForm(string pmode, PaletteVo userItem = null)
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
            if (PaletteCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, PaletteCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                PaletteCode_txt.Focus();

                return false;
            }

            if (PaletteName_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, PaletteName_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                PaletteName_txt.Focus();

                return false;
            }
            if (Area_cmb.Text == string.Empty || Area_cmb.SelectedIndex < 0)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, Area_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                Area_cmb.Focus();

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
        private void LoadUserData(PaletteVo dgvMoldType)
        {
            if (dgvMoldType != null)
            {
                this.PaletteCode_txt.Text = dgvMoldType.PaletteCode;

                this.PaletteName_txt.Text = dgvMoldType.PaletteName;

                this.Area_cmb.SelectedValue = dgvMoldType.AreaId.ToString();
            }
        }

        /// <summary>
        /// form country and factory data for combo
        /// </summary>
        private void FormDatatableFromVo()
        {
            areaDatatable = new DataTable();
            areaDatatable.Columns.Add("id");
            areaDatatable.Columns.Add("name");

            try
            {
                AreaVo buOutVo = (AreaVo)base.InvokeCbm(new GetAreaMasterMntCbm(), new AreaVo(), false);

                foreach (AreaVo bu in buOutVo.AreaListVo)
                {
                    areaDatatable.Rows.Add(bu.AreaId, bu.AreaName);
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
        private PaletteVo DuplicateCheck(PaletteVo PaletteVo)
        {
            PaletteVo outVo = new PaletteVo();

            try
            {
                outVo = (PaletteVo)base.InvokeCbm(new CheckPaletteMasterMntCbm(), PaletteVo, false);
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
        private void AddPaletteForm_Load(object sender, EventArgs e)
        {
            FormDatatableFromVo();

            ComboBind(Area_cmb, areaDatatable, "name", "id");

            PaletteCode_txt.Select();

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadUserData(updateData);

                PaletteCode_txt.Enabled = false;

                PaletteName_txt.Select();

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
            PaletteVo inVo = new PaletteVo();

            if (CheckMandatory())
            {

                var sch = StringCheckHelper.GetInstance();

                if (!sch.IsASCII(PaletteCode_txt.Text) || !sch.IsASCII(PaletteName_txt.Text))
                {
                    messageData = new MessageData("mmce00003", Properties.Resources.mmce00003);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);

                    if (!sch.IsASCII(PaletteCode_txt.Text))
                    {
                        PaletteCode_txt.Focus();
                    }
                    else
                    {
                        PaletteName_txt.Focus();
                    }

                    return;
                }

                //if(PaletteCode_txt.Text.Trim().Length < 4)
                //{
                //    MessageData messageData = new MessageData("mmci00008", Properties.Resources.mmci00008, PaletteCode_lbl.Text);
                //    popUpMessage.Warning(messageData, Text);
                //    PaletteCode_txt.Focus();
                //    return;                  
                //}

                inVo.PaletteCode = PaletteCode_txt.Text.Trim();

                inVo.PaletteName = PaletteName_txt.Text.Trim();

                inVo.AreaId = Convert.ToInt32(Area_cmb.SelectedValue);

                if (string.Equals(mode, CommonConstants.MODE_ADD))
                {
                    PaletteVo checkVo = DuplicateCheck(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, PaletteCode_lbl.Text + " : " + PaletteCode_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.ConfirmationOkCancel(messageData, Text);
                        PaletteCode_txt.Focus();
                        return;
                    }
                }

                try
                {
                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        PaletteVo outVo = (PaletteVo)base.InvokeCbm(new AddPaletteMasterMntCbm(), inVo, false);

                        IntSuccess = outVo.AffectedCount;
                    }
                    else if (mode.Equals(CommonConstants.MODE_UPDATE))
                    {
                        inVo.PaletteId = updateData.PaletteId;

                        PaletteVo outVo = (PaletteVo)base.InvokeCbm(new UpdatePaletteMasterMntCbm(), inVo, false);

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
