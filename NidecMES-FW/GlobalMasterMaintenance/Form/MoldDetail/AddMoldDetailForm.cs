using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Resources;
using System.Collections.Generic;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddMoldDetailForm : AddMoldForm
    {

        #region Variables

        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly MoldDetailVo updateData;

        /// <summary>
        /// Check for Database operation success
        /// </summary>
        //public int IntSuccess = -1;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddMoldDetailForm));

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
        public AddMoldDetailForm(string pmode, MoldDetailVo dataItem = null)
        {
            InitializeComponent();

            mode = pmode;

            updateData = dataItem;

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
            if (MoldCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, MoldCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                MoldCode_txt.Focus();

                return false;
            }

            //if (string.IsNullOrWhiteSpace(GlobalItemCode_txt.Text))
            //{
            //    messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, GlobalItemCode_lbl.Text);
            //    popUpMessage.Warning(messageData, Text);

            //    MoldCode_txt.Focus();

            //    return false;
            //}

            //if (MoldName_txt.Text == string.Empty)
            //{
            //    messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, MoldName_lbl.Text);
            //    popUpMessage.Warning(messageData, Text);

            //    MoldName_txt.Focus();

            //    return false;
            //}


            //if (Width_txt.Text == string.Empty)
            //{
            //    messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, Width_lbl.Text);
            //    popUpMessage.Warning(messageData, Text);

            //    Width_txt.Focus();

            //    return false;
            //}

            //if (Depth_txt.Text == string.Empty)
            //{
            //    messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, Depth_lbl.Text);
            //    popUpMessage.Warning(messageData, Text);

            //    Depth_txt.Focus();

            //    return false;
            //}

            //if (Height_txt.Text == string.Empty)
            //{
            //    messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, Height_lbl.Text);
            //    popUpMessage.Warning(messageData, Text);

            //    Height_txt.Focus();

            //    return false;
            //}

            //if (Weight_txt.Text == string.Empty)
            //{
            //    messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, Weight_lbl.Text);
            //    popUpMessage.Warning(messageData, Text);

            //    Weight_txt.Focus();

            //    return false;
            //}

            //if (FixedAssetNo_txt.Text == string.Empty)
            //{
            //    messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, FixedAssetNo_lbl.Text);
            //    popUpMessage.Warning(messageData, Text);

            //    FixedAssetNo_txt.Focus();

            //    return false;
            //}

            //if (LifeShotCount_txt.Text == string.Empty || LifeShotCount_txt.Text == "0")
            //{
            //    messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, LifeShotCount_lbl.Text);
            //    popUpMessage.Warning(messageData, Text);

            //    LifeShotCount_txt.Focus();

            //    return false;
            //}

            if (!(MoldCategory_cmb.SelectedIndex > -1))
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, MoldCategory_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                MoldCategory_cmb.Focus();

                return false;
            }

            if (!(Model_cmb.SelectedIndex > -1))
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, Model_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                Model_cmb.Focus();

                return false;
            }

            //if (LifeAlarmShot_txt.Text == string.Empty || LifeAlarmShot_txt.Text == "0")
            //{
            //    messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, LifeAlarmShotCount_lbl.Text);
            //    popUpMessage.Warning(messageData, Text);

            //    LifeAlarmShot_txt.Focus();

            //    return false;
            //}
            if (string.IsNullOrWhiteSpace(MoldDrawingNo_txt.Text))
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, MoldDrawingNo_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                MoldDrawingNo_txt.Focus();

                return false;
            }
            return true;
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

        /// <summary>
        /// For setting selected user record into respective controls(textbox and combobox) for update operation
        /// passing selected user data as parameter 
        /// </summary>
        /// <param name="dgvMoldType"></param>
        private void LoadUserData(MoldDetailVo dgvMoldType)
        {
            if (dgvMoldType != null)
            {

                this.MoldCode_txt.Text = dgvMoldType.MoldCode;

                this.MoldName_txt.Text = dgvMoldType.MoldName;


                //Shelf_cmb.SelectedValue = outVo.MoldDetailListVo[0].FixedShelfId;

                Weight_txt.Text = dgvMoldType.Weight.ToString();

                Width_txt.Text = dgvMoldType.Width.ToString();

                Height_txt.Text = dgvMoldType.Height.ToString();

                Depth_txt.Text = dgvMoldType.Depth.ToString();

                PASC1_txt.Text = dgvMoldType.PeriodicAlarmShotCount1.ToString();

                PASC2_txt.Text = dgvMoldType.PeriodicAlarmShotCount2.ToString();

                PASC3_txt.Text = dgvMoldType.PeriodicAlarmShotCount3.ToString();

                LifeAlarmShot_txt.Text = dgvMoldType.LifeAlarmShotCount.ToString();

                LifeShotCount_txt.Text = dgvMoldType.LifeShotCount.ToString();

                Comment_txt.Text = dgvMoldType.Comment;

                MoldDrawingNo_txt.Text = dgvMoldType.MoldDrawingNo;

                if (dgvMoldType.ProductionDate != DateTime.MinValue)
                { ProductionDate_dtp.Text = dgvMoldType.ProductionDate.ToString(); }

                if (dgvMoldType.MoldCategoryId > 0)
                {
                    MoldCategory_cmb.SelectedValue = dgvMoldType.MoldCategoryId;
                }

                if (dgvMoldType.ModelId > 0)
                {
                    Model_cmb.SelectedValue = dgvMoldType.ModelId;
                }

                if (!string.IsNullOrEmpty(dgvMoldType.MoldItemCode))
                {
                    GlobalItemCode_txt.Text = dgvMoldType.SapItemCode ;
                }

                if (!string.IsNullOrEmpty(dgvMoldType.SapItemCode))
                {
                    MoldItemCode_txt.Text = dgvMoldType.MoldItemCode;
                }

            }
        }

        ///// <summary>
        ///// checks duplicate Item Code
        ///// </summary>
        ///// <param name="gItemVo"></param>
        ///// <returns></returns>
        //private GlobalItemVo DuplicateCheckGlobalItem(GlobalItemVo gItemVo)
        //{
        //    GlobalItemVo outVo = new GlobalItemVo();

        //    try
        //    {
        //        outVo = (GlobalItemVo)base.InvokeCbm(new CheckGlobalItemMasterMntCbm(), gItemVo, false);
        //    }
        //    catch (Framework.ApplicationException exception)
        //    {
        //        popUpMessage.ApplicationError(exception.GetMessageData(), Text);
        //        logger.Error(exception.GetMessageData());
        //    }

        //    return outVo;
        //}

        /// <summary>
        /// checks duplicate mold Code
        /// </summary>
        /// <returns></returns>
        private MoldDetailVo DuplicateCheck(MoldDetailVo moldDetailVo)
        {
            MoldDetailVo outVo = new MoldDetailVo();

            try
            {
                this.Cursor = Cursors.WaitCursor;
                outVo = (MoldDetailVo)base.InvokeCbm(new CheckMoldDetailMasterMntCbm(), moldDetailVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            return outVo;
        }

        private void LoadMoldCategoryCombo()
        {
            MoldCategoryVo inVo = new MoldCategoryVo();

            ValueObjectList<MoldCategoryVo> outVo = (ValueObjectList<MoldCategoryVo>)DefaultCbmInvoker.Invoke(new GetMoldCategoryMasterMntCbm(), inVo);

            MoldCategory_cmb.DataSource = outVo.GetList();
            MoldCategory_cmb.DisplayMember = "MoldCategoryName";
            MoldCategory_cmb.ValueMember = "MoldCategoryId";

            MoldCategory_cmb.SelectedIndex = -1;
        }

        private void LoadModelCombo()
        {
            ModelVo inVo = new ModelVo();

            ValueObjectList<ModelVo> outVo = (ValueObjectList<ModelVo>)DefaultCbmInvoker.Invoke(new GetModelMasterMntCbm(), inVo);

            Model_cmb.DataSource = outVo.GetList();
            Model_cmb.DisplayMember = "ModelName";
            Model_cmb.ValueMember = "ModelId";

            Model_cmb.SelectedIndex = -1;
        }

        #endregion

        #region FormEvents
        /// <summary>
        /// Handles Load event for mold data Insert/Update operations 
        /// Loading mold data for update mold data and binding controls with selected mold record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddMoldDetailForm_Load(object sender, EventArgs e)
        {
            GlobalItemCode_txt.Enabled = false;

            if (!this.DesignMode)
            {

            }
            this.ProductionDate_dtp.Clear();

            LoadMoldCategoryCombo();

            LoadModelCombo();

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadUserData(updateData);

                MoldCode_txt.ReadOnly = true;
                
            }
        }
        #endregion

        #region ButtonClick

        /// <summary>
        /// update the  record to db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Ok_btn_Click(object sender, EventArgs e)
        {
            MoldDetailVo inVo = new MoldDetailVo();

            if (CheckMandatory())
            {

                var sch = StringCheckHelper.GetInstance();

                if (!sch.IsASCII(MoldCode_txt.Text))
                {
                    messageData = new MessageData("mmce00003", Properties.Resources.mmce00003);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);

                    if (!sch.IsASCII(MoldCode_txt.Text))
                    {
                        MoldCode_txt.Focus();
                    }
                    //else
                    //{
                    //    MoldName_txt.Focus();
                    //}

                    return;
                }

                inVo.MoldCode = MoldCode_txt.Text.Trim();

                inVo.MoldName = MoldCode_txt.Text.Trim();

                if (!string.IsNullOrEmpty(Width_txt.Text))
                {
                    inVo.Width = Convert.ToDecimal(Width_txt.Text);
                }
                if (!string.IsNullOrEmpty(Depth_txt.Text))
                {
                    inVo.Depth = Convert.ToDecimal(Depth_txt.Text);
                }
                if (!string.IsNullOrEmpty(Weight_txt.Text))
                {
                    inVo.Weight = Convert.ToDecimal(Weight_txt.Text);
                }
                if (!string.IsNullOrEmpty(Height_txt.Text))
                {
                    inVo.Height = Convert.ToDecimal(Height_txt.Text);
                }

                if (!string.IsNullOrEmpty(LifeAlarmShot_txt.Text))
                {
                    inVo.LifeAlarmShotCount = Convert.ToInt32(LifeAlarmShot_txt.Text);
                }
                if (!string.IsNullOrEmpty(PASC1_txt.Text))
                {
                    inVo.PeriodicAlarmShotCount1 = Convert.ToInt32(PASC1_txt.Text);
                }

                if (!string.IsNullOrEmpty(PASC2_txt.Text))
                {
                    inVo.PeriodicAlarmShotCount2 = Convert.ToInt32(PASC2_txt.Text);
                }

                if (!string.IsNullOrEmpty(PASC3_txt.Text))
                {
                    inVo.PeriodicAlarmShotCount3 = Convert.ToInt32(PASC3_txt.Text);
                }
                if (!string.IsNullOrWhiteSpace(ProductionDate_dtp.Text))
                {
                    inVo.ProductionDate = Convert.ToDateTime(ProductionDate_dtp.Value);
                }
                if (!string.IsNullOrWhiteSpace(MoldDrawingNo_txt.Text))
                {
                    inVo.MoldDrawingNo = MoldDrawingNo_txt.Text;
                }
                inVo.Comment = Comment_txt.Text;

                if (!string.IsNullOrWhiteSpace(LifeShotCount_txt.Text))
                { inVo.LifeShotCount = Convert.ToInt32(LifeShotCount_txt.Text); }


                if (MoldCategory_cmb.SelectedIndex > -1)
                {
                    inVo.MoldCategoryId = (int)MoldCategory_cmb.SelectedValue;
                }

                if (Model_cmb.SelectedIndex > -1)
                {
                    inVo.ModelId = (int)Model_cmb.SelectedValue;
                }

                if (!string.IsNullOrWhiteSpace(MoldItemCode_txt.Text))
                {
                    inVo.MoldItemCode = MoldItemCode_txt.Text;
                    inVo.MoldItemId = updateData.MoldItemId;
                }

                //if (!string.IsNullOrWhiteSpace(GlobalItemCode_txt.Text))
                //{
                //    inVo.MoldItemCode = GlobalItemCode_txt.Text;
                //}

                MoldDetailVo checkVo = DuplicateCheck(inVo);

                //GlobalItemVo globalItemInVo = new GlobalItemVo();
                //globalItemInVo.GlobalItemCode = inVo.MoldItemCode;

                //GlobalItemVo checkGlobalItemVo = DuplicateCheckGlobalItem(globalItemInVo);

                if (string.Equals(mode, CommonConstants.MODE_ADD))
                {
                    //if (checkGlobalItemVo != null && checkGlobalItemVo.AffectedCount > 0)
                    //{
                    //    messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, GlobalItemCode_lbl.Text + " : " + globalItemInVo.GlobalItemCode);
                    //    logger.Info(messageData);
                    //    popUpMessage.ApplicationError(messageData, Text);
                    //    return;
                    //}

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, MoldCode_lbl.Text + " : " + MoldCode_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.ApplicationError(messageData, Text);
                        return;
                    }
                }
                else if (string.Equals(mode, CommonConstants.MODE_UPDATE))
                {
                    if (checkVo != null && checkVo.AffectedCount > 1)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, MoldCode_lbl.Text + " : " + MoldCode_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.ApplicationError(messageData, Text);
                        return;
                    }
                }

                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        MoldDetailVo outVo = (MoldDetailVo)base.InvokeCbm(new AddMoldAndMoldDetailMasterMntCbm(), inVo, false);

                        IntSuccess = outVo.AffectedCount;
                    }
                    if (mode.Equals(CommonConstants.MODE_UPDATE))
                    {
                        inVo.MoldId = updateData.MoldId;

                        MoldDetailVo outVo = (MoldDetailVo)base.InvokeCbm(new UpdateMoldDetailMasterMntCbm(), inVo, false);

                        if (outVo != null && outVo.AffectedCount > 0)
                        {
                            IntSuccess = outVo.AffectedCount;
                        }
                        else
                        {
                            IntSuccess = 0;
                        }
                    }

                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                    return;
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }

                this.Close();

                //if ((IntSuccess > 0) || (IntSuccess == 0))
                //{
                //    this.Close();
                //}

            }
        }

        /// <summary>
        /// close the screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Exit_btn_Click(object sender, EventArgs e)
        {
            IntSuccess = -1;
            this.Close();
        }
        #endregion

    }

}
