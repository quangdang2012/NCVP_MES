using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Resources;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddModelForm : FormCommonMaster
    {

        #region Variables

        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
       private readonly ModelVo updateData;

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
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddModelForm));

        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;

        #endregion

        #region Constructor
        ///// <summary>
        ///// Constructor for the  form
        ///// </summary>
        ///// <param name="pmode"></param>
        ///// <param name="userItem"></param>
        //public AddModelForm(string pmode, ModelVo userItem = null)
        //{
        //    InitializeComponent();

        //    mode = pmode;

        //    updateData = userItem;

        //    if (string.Equals(mode, CommonConstants.MODE_UPDATE))
        //    {
        //        this.Text = UpdateText_lbl.Text;
        //    }
        //}

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Checks mandatory fields
        /// </summary>
        /// <returns></returns>
        private bool CheckMandatory()
        {
            if (ModelCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, ModelCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                ModelCode_txt.Focus();

                return false;
            }

            if (ModelName_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, ModelName_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                ModelName_txt.Focus();

                return false;
            }

            return true;
        }


        #region Constructor
        /// <summary>
        /// Constructor for the  form
        /// </summary>
        /// <param name="pmode"></param>
        /// <param name="userItem"></param>
        public AddModelForm(string pmode, ModelVo userItem = null)
        {
            InitializeComponent();

            mode = pmode;

            updateData = userItem;

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                this.Text = UpdateText_lbl.Text;
            }
        }

        /// <summary>
        /// For setting selected user record into respective controls(textbox and combobox) for update operation
        /// passing selected user data as parameter 
        /// </summary>
        /// <param name="dgvMoldType"></param>
        private void LoadUserData(ModelVo dgvMoldType)
        {
            if (dgvMoldType != null)
            {
                this.ModelCode_txt.Text = dgvMoldType.ModelCode;

                this.ModelName_txt.Text = dgvMoldType.ModelName;              
            }
        }

        /// <summary>
        /// form country and factory data for combo
        /// </summary>
        //private void FormDatatableFromVo()
        //{
        //    moldDatatable = new DataTable();
        //    moldDatatable.Columns.Add("id");
        //    moldDatatable.Columns.Add("code");

        //    try
        //    {
        //        MoldVo moldOutVo = (MoldVo)base.InvokeCbm(new GetMoldMasterMntCbm(), new MoldVo (), false);

        //        foreach (MoldVo mold in moldOutVo.MoldListVo)
        //        {
        //            moldDatatable.Rows.Add(mold.MoldId, mold.MoldCode);
        //        }
        //    }
        //    catch (Framework.ApplicationException exception)
        //    {
        //        popUpMessage.ApplicationError(exception.GetMessageData(), Text);
        //        logger.Error(exception.GetMessageData());
        //    }
        //}

        /// <summary>
        /// checks duplicate mold Code
        /// </summary>
        /// <returns></returns>
        private ModelVo DuplicateCheck(ModelVo ModelVo)
        {
            ModelVo outVo = new ModelVo();

            try
            {
                this.Cursor = Cursors.WaitCursor;
                outVo = (ModelVo)base.InvokeCbm(new CheckModelMasterMntCbm(), ModelVo, false);
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
        #endregion

        #region FormEvents
        /// <summary>
        /// Handles Load event for mold data Insert/Update operations 
        /// Loading mold data for update mold data and binding controls with selected mold record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddModelForm_Load(object sender, EventArgs e)
        {
           // FormDatatableFromVo();

            ModelCode_txt.Select();

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadUserData(updateData);

                ModelCode_txt.Enabled = false;

                ModelName_txt.Select();

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
            ModelVo inVo = new ModelVo();
            
            if (CheckMandatory())
            {

                var sch = StringCheckHelper.GetInstance();

                if (!sch.IsASCII(ModelCode_txt.Text) || !sch.IsASCII(ModelName_txt.Text))
                {
                    messageData = new MessageData("mmce00003", Properties.Resources.mmce00003);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);

                    if (!sch.IsASCII(ModelCode_txt.Text))
                    {
                        ModelCode_txt.Focus();
                    }
                    else
                    {
                        ModelName_txt.Focus();
                    }

                    return;
                }
                inVo.ModelCode = ModelCode_txt.Text.Trim();

                inVo.ModelName = ModelName_txt.Text.Trim();

                if (string.Equals(mode, CommonConstants.MODE_ADD))
                {
                    ModelVo checkVo = DuplicateCheck(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, ModelCode_lbl.Text + " : " + ModelCode_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.ConfirmationOkCancel(messageData, Text);
                        ModelCode_txt.Focus();
                        return;
                    }
                }

                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        ModelVo outVo = (ModelVo)base.InvokeCbm(new AddModelMasterMntCbm(), inVo, false);

                        IntSuccess = outVo.ModelId;
                    }
                    else if (mode.Equals(CommonConstants.MODE_UPDATE))
                    {
                        inVo.ModelId = updateData.ModelId;

                        ModelVo outVo = (ModelVo)base.InvokeCbm(new UpdateModelMasterMntCbm(), inVo, false);

                        IntSuccess = outVo.AffectedCount;
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

        #endregion
    }
}