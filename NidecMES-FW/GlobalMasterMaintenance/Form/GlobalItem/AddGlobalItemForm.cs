using System;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using System.Data;
using System.Windows.Forms;
using System.Resources;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddGlobalItemForm
    {
        #region Variables
        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private GlobalItemVo updateData;

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
        public AddGlobalItemForm()
        {
            InitializeComponent();

        }

        public void CreateForm(string pmode, GlobalItemVo dataItem = null)
        {
            mode = pmode;
          
            updateData = dataItem;
        }


        #endregion

        #region PrivateMethods


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
            if (GlobalItemCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, GlobalItemCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                GlobalItemCode_txt.Focus();

                return false;
            }
            if (GlobalItemName_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, GlobalItemName_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                GlobalItemName_txt.Focus();

                return false;
            }
           
            return true;
        }

        /// <summary>
        /// For setting selected user record into respective controls(textbox and combobox) for update operation
        /// passing selected user data as parameter 
        /// </summary>
        /// <param name="dgvData"></param>
        private void LoadUserData(GlobalItemVo dgvData)
        {
            if (dgvData != null)
            {
                GlobalItemCode_txt.Text = dgvData.GlobalItemCode;

                GlobalItemName_txt.Text = dgvData.GlobalItemName;
            }
        }

        /// <summary>
        /// checks duplicate Item Code
        /// </summary>
        /// <param name="gItemVo"></param>
        /// <returns></returns>
        private GlobalItemVo DuplicateCheck(GlobalItemVo gItemVo)
        {
            GlobalItemVo outVo = new GlobalItemVo();

            try
            {
                outVo = (GlobalItemVo) base.InvokeCbm(new CheckGlobalItemMasterMntCbm(), gItemVo, false);
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
                GlobalItemCode_txt.Select();

                if (string.Equals(mode, CommonConstants.MODE_UPDATE))
                {
                    LoadUserData(updateData);

                    GlobalItemCode_txt.Enabled = false;

                    GlobalItemName_txt.Select();

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
                GlobalItemVo inVo = new GlobalItemVo
                {
                    GlobalItemCode = GlobalItemCode_txt.Text,
                    GlobalItemName = GlobalItemName_txt.Text
                };

                if (string.Equals(mode, CommonConstants.MODE_ADD))
                {
                    GlobalItemVo checkVo = DuplicateCheck(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, GlobalItemCode_lbl.Text + " : " + GlobalItemCode_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.ApplicationError(messageData, Text);
                        return;
                    }
                }

                try
                {
                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        GlobalItemVo outVo = (GlobalItemVo)base.InvokeCbm(new AddGlobalItemMasterMntCbm(), inVo, false);

                        IntSuccess = outVo.GlobalItemId;
                    }
                    else if (mode.Equals(CommonConstants.MODE_UPDATE))
                    {
                        inVo.GlobalItemId = updateData.GlobalItemId;

                        GlobalItemVo outVo = (GlobalItemVo)base.InvokeCbm(new UpdateGlobalItemMasterMntCbm(), inVo, false);

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
}
