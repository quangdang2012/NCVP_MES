using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddShelfForm
    {

        #region Variables

        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly ShelfVo updateData;

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
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddShelfForm));

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
        public AddShelfForm(string pmode, ShelfVo userItem = null)
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
            if (ShelfCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, ShelfCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                ShelfCode_txt.Focus();

                return false;
            }

            if (ShelfName_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, ShelfName_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                ShelfName_txt.Focus();

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
        private void LoadUserData(ShelfVo dgvMoldType)
        {
            if (dgvMoldType != null)
            {
                this.ShelfCode_txt.Text = dgvMoldType.ShelfCode;

                this.ShelfName_txt.Text = dgvMoldType.ShelfName;

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
        private ShelfVo DuplicateCheck(ShelfVo ShelfVo)
        {
            ShelfVo outVo = new ShelfVo();

            try
            {
                outVo = (ShelfVo)base.InvokeCbm(new CheckShelfMasterMntCbm(), ShelfVo, false);
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
        private void AddShelfForm_Load(object sender, EventArgs e)
        {
            FormDatatableFromVo();

            ComboBind(Area_cmb, areaDatatable, "name", "id");

            ShelfCode_txt.Select();

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadUserData(updateData);

                ShelfCode_txt.Enabled = false;

                ShelfName_txt.Select();

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
            ShelfVo inVo = new ShelfVo();

            if (CheckMandatory())
            {

                var sch = StringCheckHelper.GetInstance();

                if (!sch.IsASCII(ShelfCode_txt.Text) || !sch.IsASCII(ShelfName_txt.Text))
                {
                    messageData = new MessageData("mmce00003", Properties.Resources.mmce00003);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);

                    if (!sch.IsASCII(ShelfCode_txt.Text))
                    {
                        ShelfCode_txt.Focus();
                    }
                    else
                    {
                        ShelfName_txt.Focus();
                    }

                    return;
                }

                //if(ShelfCode_txt.Text.Trim().Length < 4)
                //{
                //    MessageData messageData = new MessageData("mmci00008", Properties.Resources.mmci00008, ShelfCode_lbl.Text);
                //    popUpMessage.Warning(messageData, Text);
                //    ShelfCode_txt.Focus();
                //    return;                  
                //}

                inVo.ShelfCode = ShelfCode_txt.Text.Trim();

                inVo.ShelfName = ShelfName_txt.Text.Trim();

                inVo.AreaId = Convert.ToInt32(Area_cmb.SelectedValue);

                if (string.Equals(mode, CommonConstants.MODE_ADD))
                {
                    ShelfVo checkVo = DuplicateCheck(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, ShelfCode_lbl.Text + " : " + ShelfCode_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.ConfirmationOkCancel(messageData, Text);
                        ShelfCode_txt.Focus();
                        return;
                    }
                }

                try
                {
                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        ShelfVo outVo = (ShelfVo)base.InvokeCbm(new AddShelfMasterMntCbm(), inVo, false);

                        IntSuccess = outVo.AffectedCount;
                    }
                    else if (mode.Equals(CommonConstants.MODE_UPDATE))
                    {
                        inVo.ShelfId = updateData.ShelfId;

                        ShelfVo outVo = (ShelfVo)base.InvokeCbm(new UpdateShelfMasterMntCbm(), inVo, false);

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
