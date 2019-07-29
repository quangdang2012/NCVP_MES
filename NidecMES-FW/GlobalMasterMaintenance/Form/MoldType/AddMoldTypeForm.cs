using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Resources;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddMoldTypeForm
    {
        #region Variables

        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly MoldTypeVo updateData;

        /// <summary>
        /// Check for Database operation success
        /// </summary>
        public int IntSuccess = -1;


        /// <summary>
        /// datatable for item data
        /// </summary>
        private DataTable itemDatatable;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddMoldTypeForm));

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
        public AddMoldTypeForm(string pmode, MoldTypeVo userItem = null)
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
            if (MoldTypeCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, MoldTypeCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                MoldTypeCode_txt.Focus();

                return false;
            }

            if (MoldTypeName_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, MoldTypeName_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                MoldTypeName_txt.Focus();

                return false;
            }
            if (Item_cmb.Text == string.Empty || Item_cmb.SelectedIndex < 0)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, Item_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                Item_cmb.Focus();

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
        private void LoadUserData(MoldTypeVo dgvMoldType)
        {
            if (dgvMoldType != null)
            {
                this.MoldTypeCode_txt.Text = dgvMoldType.MoldTypeCode;

                this.MoldTypeName_txt.Text = dgvMoldType.MoldTypeName;

                this.Item_cmb.SelectedValue = dgvMoldType.ItemId.ToString();
            }
        }

         /// <summary>
        /// form country and factory data for combo
        /// </summary>
        private void FormDatatableFromVo()
        {
            itemDatatable = new DataTable();
            itemDatatable.Columns.Add("id");
            itemDatatable.Columns.Add("code");

            try
            {
                ItemVo itemOutVo = (ItemVo)base.InvokeCbm(new GetItemMasterMntCbm(), new ItemVo(), false);

                foreach (ItemVo item in itemOutVo.ItemListVo)
                {
                    itemDatatable.Rows.Add(item.ItemId, item.ItemCode);
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        /// <summary>
        /// checks duplicate mold type Code
        /// </summary>
        /// <param name="mtypecVo"></param>
        /// <returns></returns>
        private MoldTypeVo DuplicateCheck(MoldTypeVo mtypecVo)
        {
            MoldTypeVo outVo = new MoldTypeVo();

            try
            {
                outVo = (MoldTypeVo)base.InvokeCbm(new CheckMoldTypeMasterMntCbm(), mtypecVo, false);
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
        /// Handles Load event for moldtype data Insert/Update operations 
        /// Loading moldtype data for update moldtype data and binding controls with selected moldtype record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddMoldTypeForm_Load(object sender, EventArgs e)
        {
            FormDatatableFromVo();

            ComboBind(Item_cmb, itemDatatable, "code", "id");

            MoldTypeCode_txt.Select();

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadUserData(updateData);

                MoldTypeCode_txt.Enabled = false;

                MoldTypeName_txt.Select();

            }
        }
        #endregion

        #region ButtonClick
        /// <summary>
        /// inserts/updates mold type on button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_btn_Click(object sender, EventArgs e)
        {
            var sch = StringCheckHelper.GetInstance();
            if (CheckMandatory())
            {
                if (string.IsNullOrEmpty(MoldTypeCode_txt.Text) || string.IsNullOrEmpty(MoldTypeName_txt.Text))
                {
                    messageData = new MessageData("mmce00003", Properties.Resources.mmce00003);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);

                    if (string.IsNullOrEmpty(MoldTypeCode_txt.Text))
                    {
                        MoldTypeCode_txt.Focus();
                    }
                    else if (string.IsNullOrEmpty(MoldTypeName_txt.Text))
                    {
                        MoldTypeName_txt.Focus();
                    }
                    return;
                }
                MoldTypeVo inVo = new MoldTypeVo
                {
                    MoldTypeCode = MoldTypeCode_txt.Text.Trim(),
                    MoldTypeName = MoldTypeName_txt.Text.Trim(),
                    ItemId = Convert.ToInt32(Item_cmb.SelectedValue),
                    //RegistrationDateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    RegistrationUserCode = UserData.GetUserData().UserCode,
                    FactoryCode = UserData.GetUserData().FactoryCode
                };

                if (string.Equals(mode, CommonConstants.MODE_ADD))
                {
                    MoldTypeVo checkVo = DuplicateCheck(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, MoldTypeCode_lbl.Text +  " : " + MoldTypeCode_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.ApplicationError(messageData, Text);
                        return;
                    }
                }
              

                try
                {
                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        MoldTypeVo outVo = (MoldTypeVo)base.InvokeCbm(new AddMoldTypeMasterMntCbm(), inVo, false);

                        IntSuccess = outVo.AffectedCount;
                    }
                    else if (mode.Equals(CommonConstants.MODE_UPDATE))
                    {
                        inVo.MoldTypeId = updateData.MoldTypeId;

                        MoldTypeVo outVo = (MoldTypeVo)base.InvokeCbm(new UpdateMoldTypeMasterMntCbm(), inVo, false);

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
        /// closes form on exit click
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
