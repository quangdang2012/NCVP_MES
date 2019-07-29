using System;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using System.Resources;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddFactoryProductionDaysMasterForm
    {

        #region Variables

        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly FactoryProductionDaysVo updateData;

        /// <summary>
        /// Check for Database operation success
        /// </summary>
        public int IntSuccess = -1;

        public int factoryProductionDaysId;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddFactoryProductionDaysMasterForm));

        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;

        #endregion

        #region Constructor

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="pmode"></param>
        /// <param name="factoryItem"></param>
        public AddFactoryProductionDaysMasterForm(string pmode, FactoryProductionDaysVo factoryProductionDaysItem = null)
        {
            InitializeComponent();

            mode = pmode;
            updateData = factoryProductionDaysItem;

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                this.Text = UpdateText_lbl.Text;
            }
        }

        public AddFactoryProductionDaysMasterForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Checks mandatory fields
        /// </summary>
        /// <returns></returns>
        private bool CheckMandatory()
        {
            if (Building_cmb.SelectedIndex == -1)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, Building_lbl.Text);
                logger.Info(messageData);
                popUpMessage.Warning(messageData, Text);
                Building_cmb.Select();
                return false;
            }
            if (string.IsNullOrEmpty(Year_txt.Text) || Year_txt.TextLength < 4)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, Year_lbl.Text);
                logger.Info(messageData);
                popUpMessage.Warning(messageData, Text);
                Year_txt.Select();
                return false;
            }
            if (Month_cmb.SelectedIndex == -1)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, "Month");
                logger.Info(messageData);
                popUpMessage.Warning(messageData, Text);
                Month_cmb.Select();
                return false;
            }
            if (string.IsNullOrEmpty(Date_txt.Text))
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, "Date");
                logger.Info(messageData);
                popUpMessage.Warning(messageData, Text);
                Date_txt.Select();
                return false;
            }
            if (Convert.ToInt32(Date_txt.Text) > 31)
            {
                messageData = new MessageData("mmce00023", Properties.Resources.mmce00023);
                logger.Info(messageData);
                popUpMessage.Warning(messageData, Text);
                Date_txt.Text = string.Empty;
                Date_txt.Select();
                return false;
            }
            DateTime dDate;
            if (!DateTime.TryParse(Year_txt.Text + "-" + Month_cmb.Text + "-" + Date_txt.Text, out dDate))
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, "Validate Date");
                logger.Info(messageData);
                popUpMessage.Warning(messageData, Text);
                Date_txt.Text = string.Empty;
                Date_txt.Select();
                return false;
            }
            return true;
        }

        /// <summary>
        /// For setting selected factory record into respective controls(textbox and combobox) for update operation
        /// passing selected factory data as parameter 
        /// </summary>
        /// <param name="dgvFactory"></param>
        private void LoadFactoryProductionDaysData(FactoryProductionDaysVo dgvFactoryProductionDays)
        {
            if (dgvFactoryProductionDays != null)
            {
                Building_cmb.Text = dgvFactoryProductionDays.BuildingName;
                Year_txt.Text = Convert.ToString(dgvFactoryProductionDays.iYear);
                Month_cmb.SelectedIndex = Convert.ToInt32(dgvFactoryProductionDays.iMonth) - 1;
                Date_txt.Text = Convert.ToString(dgvFactoryProductionDays.iDays);
                factoryProductionDaysId = dgvFactoryProductionDays.FactoryProductionDaysId;
            }
        }

        /// <summary>
        /// checks duplicate FactoryCode
        /// </summary>
        /// <param name="factVo"></param>
        /// <returns></returns>
        private FactoryProductionDaysVo DuplicateCheck(FactoryProductionDaysVo factoryProductionDaysVo)
        {
            FactoryProductionDaysVo outVo = new FactoryProductionDaysVo();

            try
            {
                outVo = (FactoryProductionDaysVo)base.InvokeCbm(new CheckFactoryProductionDaysMasterMntCbm(), factoryProductionDaysVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            return outVo;
        }

        /// <summary>
        /// Get Building Information and set it in combo box
        /// </summary>
        private void GetBuildingInfomation()
        {
            BuildingVo buildinginVo = new BuildingVo();
            BuildingVo buildingoutVo = new BuildingVo();
            buildinginVo.FactoryCode = UserData.GetUserData().FactoryCode;

            try
            {
                buildingoutVo = (BuildingVo)DefaultCbmInvoker.Invoke(new GetBuildingMasterMntCbm(), buildinginVo);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
            if (buildingoutVo != null && buildingoutVo.BuildingListVo.Count > 0)
            {
                ComboBind(Building_cmb, buildingoutVo.BuildingListVo, "BuildingName", "BuildingId");
            }
        }

        /// <summary>
        /// For binding combo box
        /// </summary>
        /// <param name="pCombo"></param>
        /// <param name="pDatasource"></param>
        /// <param name="pDisplay"></param>
        /// <param name="pValue"></param>
        private void ComboBind<T>(ComboBox pCombo, List<T> pDatasource, string pDisplay, string pValue)
        {
            pCombo.DataSource = pDatasource;
            pCombo.DisplayMember = pDisplay;
            pCombo.ValueMember = pValue;
            pCombo.SelectedIndex = -1;
            pCombo.Text = string.Empty;
        }

        private void Building_cmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Year_txt.Select();
        }

        private void Month_cmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Date_txt.Select();
        }

        #endregion

        #region FormEvent

        /// <summary>
        /// load screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddFactoryProductionDaysMasterForm_Load(object sender, EventArgs e)
        {
            GetBuildingInfomation();
            Building_cmb.Select();

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadFactoryProductionDaysData(updateData);
                Building_cmb.Enabled = false;
                Year_txt.Enabled = false;
                Month_cmb.Enabled = false;
                Date_txt.Select();
            }
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
            var sch = StringCheckHelper.GetInstance();

            FactoryProductionDaysVo inVo = new FactoryProductionDaysVo();

            if (CheckMandatory())
            {
                inVo.iYear = Convert.ToInt32(Year_txt.Text);
                inVo.iMonth = Convert.ToInt32(Month_cmb.SelectedItem.ToString());
                inVo.iDays = Convert.ToInt32(Date_txt.Text);
                inVo.FactoryProductionDaysId = factoryProductionDaysId;
                inVo.BuildingId = Convert.ToInt32(Building_cmb.SelectedValue);
                inVo.RegistrationUserCode = UserData.GetUserData().UserCode;
                inVo.FactoryCode = UserData.GetUserData().FactoryCode;                

                try
                {
                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        FactoryProductionDaysVo checkVo = DuplicateCheck(inVo);

                        if (checkVo != null && checkVo.AffectedCount > 0)
                        {
                            messageData = new MessageData("mmce00009", Properties.Resources.mmce00009, " " + Year_lbl.Text + " or " + MonthDate_lbl.Text.Substring(0, 5));
                            logger.Info(messageData);
                            popUpMessage.Warning(messageData, Text);
                            return;
                        }

                        FactoryProductionDaysVo outVo = (FactoryProductionDaysVo)base.InvokeCbm(new AddFactoryProductionDaysMasterMntCbm(), inVo, false);
                        IntSuccess = outVo.AffectedCount;
                    }
                    else if (string.Equals(mode, CommonConstants.MODE_UPDATE))
                    {
                        FactoryProductionDaysVo outVo = (FactoryProductionDaysVo)base.InvokeCbm(new UpdateFactoryProductionDaysMasterMntCbm(), inVo, false);
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
        /// Window close when Exit button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Exit_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

    }
}
