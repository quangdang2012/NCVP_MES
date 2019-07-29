using System;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using System.Data;
using System.Windows.Forms;
using System.Resources;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddStockLocationForm
    {
        #region Variables
        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private StockLocationVo updateData;

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
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddStockLocationForm));

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
        public AddStockLocationForm()
        {
            InitializeComponent();

        }

        public AddStockLocationForm  CreateForm(string pmode, StockLocationVo dataItem = null)
        {
            mode = pmode;
          
            updateData = dataItem;

            return new AddStockLocationForm();
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

        }



        /// <summary>
        /// Checks mandatory fields
        /// </summary>
        /// <returns></returns>
        private bool CheckMandatory()
        {
            if (StockLocationCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, StockLocationCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                StockLocationCode_txt.Focus();

                return false;
            }
            if (StockLocationName_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, StockLocationName_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                StockLocationName_txt.Focus();

                return false;
            }

            if (DisplayOrder_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, DisplayOrder_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                DisplayOrder_txt.Focus();

                return false;
            }

            if ( LocationType_cmb.Text == string.Empty || LocationType_cmb.SelectedIndex < 0)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, LocationType_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                LocationType_cmb.Focus();

                return false;
            }            

            return true;
        }

        /// <summary>
        /// For setting selected user record into respective controls(textbox and combobox) for update operation
        /// passing selected user data as parameter 
        /// </summary>
        /// <param name="dgvData"></param>
        private void LoadUserData(StockLocationVo dgvData)
        {
            if (dgvData != null)
            {
                StockLocationCode_txt.Text = dgvData.StockLocationCode;
                StockLocationName_txt.Text = dgvData.StockLocationName;
                DisplayOrder_txt.Text = dgvData.DisplayOrder.ToString();
                if (dgvData.LocationTypeDisplay != null)
                {
                    LocationType_cmb.Text = dgvData.LocationTypeDisplay.ToString();
                }
            }
        }

        /// <summary>
        /// checks duplicate Item Code
        /// </summary>
        /// <param name="itemcVo"></param>
        /// <returns></returns>
        private StockLocationVo DuplicateCheck(StockLocationVo itemcVo)
        {
            StockLocationVo outVo = new StockLocationVo();

            try
            {
                outVo = (StockLocationVo)base.InvokeCbm(new CheckStockLocationMasterMntCbm(), itemcVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            return outVo;
        }

        /// <summary>
        /// Loads LocationType
        /// </summary>
        private void LoadLocationType()
        {
            //modeDt = new DataTable();
            DataTable LocType = new DataTable();
            LocType = new DataTable();
            LocType.Columns.Add("name");
            LocType.Columns.Add("id");


            LocType.Rows.Add(GlobalMasterDataTypeEnum.LOCATION_TYPE_PROCESS.ToString(), GlobalMasterDataTypeEnum.LOCATION_TYPE_PROCESS.GetValue());
            LocType.Rows.Add(GlobalMasterDataTypeEnum.LOCATION_TYPE_WAREHOUSE.ToString(), GlobalMasterDataTypeEnum.LOCATION_TYPE_WAREHOUSE.GetValue());
           
            ComboBind(LocationType_cmb, LocType, "name", "id");
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
        /// check duplicate Display Record
        /// </summary>
        /// <param name="defectVo"></param>
        /// <returns></returns>
        private StockLocationVo DuplicateDisplayCheck(StockLocationVo chkvo)
        {
            StockLocationVo outVo = new StockLocationVo();

            try
            {
                outVo = (StockLocationVo)base.InvokeCbm(new CheckStockLocationDisplayMasterMntCbm(), chkvo, false);
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
        protected void AddStockLocationForm_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                StockLocationCode_txt.Select();

                LoadUnityType();
                LoadLocationType();

                if (string.Equals(mode, CommonConstants.MODE_UPDATE))
                {
                    LoadUserData(updateData);

                    StockLocationCode_txt.Enabled = false;

                    StockLocationName_txt.Select();

                    var resourceMngr = new ResourceManager(this.GetType());
                    this.Text = resourceMngr.GetString("UpdateForm");
                }
                else
                {
                    StockLocationVo outVo = (StockLocationVo)base.InvokeCbm(new GetDisplayOrderNextValForStockLocCbm(), null, false);
                    if (outVo != null)
                    {
                        DisplayOrder_txt.Text = outVo.DisplayOrder.ToString();
                    }
                    else
                    {
                        DisplayOrder_txt.Text = "1";
                    }

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
                StockLocationVo inVo = new StockLocationVo
                {
                    StockLocationCode = StockLocationCode_txt.Text,
                    StockLocationName = StockLocationName_txt.Text,
                    //RegistrationDateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    LocationType = Convert.ToInt32(LocationType_cmb.SelectedValue.ToString()),
                    DisplayOrder = Convert.ToInt32(DisplayOrder_txt.Text),
                    RegistrationUserCode = UserData.GetUserData().UserCode,
                    FactoryCode = UserData.GetUserData().FactoryCode
                };

                if (string.Equals(mode, CommonConstants.MODE_ADD))
                {
                    StockLocationVo checkVo = DuplicateCheck(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, StockLocationCode_lbl.Text + " : " + StockLocationCode_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.ApplicationError(messageData, Text);
                        return;
                    }

                    StockLocationVo checkDisplayVo = DuplicateDisplayCheck(inVo);
                    if (checkDisplayVo != null && checkDisplayVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, DisplayOrder_lbl.Text + " : " + DisplayOrder_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.ConfirmationOkCancel(messageData, Text);
                        DisplayOrder_txt.Focus();
                        return;
                    }
                }

                else if (string.Equals(mode, CommonConstants.MODE_UPDATE))
                {
                    if (updateData.DisplayOrder != Convert.ToInt32(DisplayOrder_txt.Text))
                    {
                        StockLocationVo checkDisplayVo = DuplicateDisplayCheck(inVo);
                        if (checkDisplayVo != null && checkDisplayVo.AffectedCount > 0)
                        {
                            messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, DisplayOrder_lbl.Text + " : " + DisplayOrder_txt.Text);
                            logger.Info(messageData);
                            popUpMessage.ConfirmationOkCancel(messageData, Text);
                            DisplayOrder_txt.Focus();
                            return;
                        }
                    }
                }


                try
                {
                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        StockLocationVo outVo = (StockLocationVo)base.InvokeCbm(new AddStockLocationMasterMntCbm(), inVo, false);

                        IntSuccess = outVo.AffectedCount;
                    }
                    else if (mode.Equals(CommonConstants.MODE_UPDATE))
                    {
                        inVo.StockLocationId = updateData.StockLocationId;

                        StockLocationVo outVo = (StockLocationVo)base.InvokeCbm(new UpdateStockLocationMasterMntCbm(), inVo, false);

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
