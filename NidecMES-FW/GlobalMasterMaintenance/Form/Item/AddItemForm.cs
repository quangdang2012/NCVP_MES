using System;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using System.Data;
using System.Windows.Forms;
using System.Resources;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddItemForm
    {
        #region Variables
        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private ItemVo updateData;

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
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddItemForm));

        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;

        #endregion

        #region Constructor
        /// <summary>
        /// constructor for the form
        /// </summary>
        /// <param name="pmode"></param>
        /// <param name="dataItem"></param>
        public AddItemForm()
        {
            InitializeComponent();

        }

        public AddItemForm  CreateForm(string pmode, ItemVo dataItem = null)
        {
            mode = pmode;
          
            updateData = dataItem;

            return new AddItemForm();
        }


        #endregion

        #region PrivateMethods

        /// <summary>
        /// Loads Unit Type
        /// </summary>
        private void LoadUnityType()
        {
            DataTable dtUnitType = new DataTable();
            dtUnitType = new DataTable();
            dtUnitType.Columns.Add("name");
            dtUnitType.Columns.Add("id");

            foreach (System.Configuration.SettingsProperty property in Properties.Settings.Default.Properties)
            {
                if (property.Name == UnityType.Count.ToString())
                {
                    dtUnitType.Rows.Add(property.Name, property.DefaultValue);
                }

                if (property.Name == UnityType.Weight.ToString())
                {
                    dtUnitType.Rows.Add(property.Name, property.DefaultValue);
                }
            }

            ComboBind(UnitType_cmb, dtUnitType, "name", "id");
        }

        /// For binding unit type
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
        /// Checks mandatory fields
        /// </summary>
        /// <returns></returns>
        private bool CheckMandatory()
        {
            if (ItemCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, ItemCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                ItemCode_txt.Focus();

                return false;
            }
            if (ItemName_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, ItemName_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                ItemName_txt.Focus();

                return false;
            }
           
            if (UnitType_cmb.Text == string.Empty || UnitType_cmb.SelectedIndex < 0)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, UnitType_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                UnitType_cmb.Focus();

                return false;
            }
            return true;
        }

        /// <summary>
        /// For setting selected user record into respective controls(textbox and combobox) for update operation
        /// passing selected user data as parameter 
        /// </summary>
        /// <param name="dgvData"></param>
        private void LoadUserData(ItemVo dgvData)
        {
            if (dgvData != null)
            {
                ItemCode_txt.Text = dgvData.ItemCode;

                ItemName_txt.Text = dgvData.ItemName;

                UnitType_cmb.SelectedValue = dgvData.UnitType.ToString();
            }
        }

        /// <summary>
        /// checks duplicate Item Code
        /// </summary>
        /// <param name="itemcVo"></param>
        /// <returns></returns>
        private ItemVo DuplicateCheck(ItemVo itemcVo)
        {
            ItemVo outVo = new ItemVo();

            try
            {
                outVo = (ItemVo)base.InvokeCbm(new CheckItemMasterMntCbm(), itemcVo, false);
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
        /// form load, loads item data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddItemForm_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                ItemCode_txt.Select();

                LoadUnityType();

                if (string.Equals(mode, CommonConstants.MODE_UPDATE))
                {
                    LoadUserData(updateData);

                    ItemCode_txt.Enabled = false;

                    ItemName_txt.Select();

                    var resourceMngr = new ResourceManager(this.GetType());
                    this.Text = resourceMngr.GetString("UpdateForm");

                }
            }
        }

        #endregion

        #region ButtonClick

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// inserts/updates item details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Ok_btn_Click(object sender, EventArgs e)
        {
            
            if (CheckMandatory())
            {
                ItemVo inVo = new ItemVo
                {
                    ItemCode = ItemCode_txt.Text,
                    ItemName = ItemName_txt.Text,
                    UnitType = Convert.ToInt32(UnitType_cmb.SelectedValue),
                    //RegistrationDateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    RegistrationUserCode = UserData.GetUserData().UserCode,
                    FactoryCode = UserData.GetUserData().FactoryCode
                };

                if (string.Equals(mode, CommonConstants.MODE_ADD))
                {
                    ItemVo checkVo = DuplicateCheck(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, ItemCode_lbl.Text + " : " + ItemCode_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.ApplicationError(messageData, Text);
                        return;
                    }
                }

                try
                {
                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        ItemVo outVo = (ItemVo)base.InvokeCbm(new AddItemMasterMntCbm(), inVo, false);

                        IntSuccess = outVo.AffectedCount;
                    }
                    else if (mode.Equals(CommonConstants.MODE_UPDATE))
                    {
                        inVo.ItemId = updateData.ItemId;

                        ItemVo outVo = (ItemVo)base.InvokeCbm(new UpdateItemMasterMntCbm(), inVo, false);

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
        #endregion

    }

    public enum UnityType
    {
        Weight = 1,
        Count = 0
    }
}
