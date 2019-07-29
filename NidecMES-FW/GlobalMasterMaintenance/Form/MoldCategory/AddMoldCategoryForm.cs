using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Resources;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddMoldCategoryForm
    {

        #region Variables

        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly MoldCategoryVo updateData;

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
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddMoldCategoryForm));

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
        //public AddBuldingForm(string pmode, MoldCategoryVo userItem = null)
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
            if (MoldCategoryCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, MoldCategoryCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                MoldCategoryCode_txt.Focus();

                return false;
            }

            if (MoldCategoryName_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, MoldCategoryName_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                MoldCategoryName_txt.Focus();

                return false;
            }
            //if (DisplayOrder_txt.Text == string.Empty)
            //{
            //    messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, DisplayOrder_lbl.Text);
            //    popUpMessage.Warning(messageData, Text);

            //    DisplayOrder_txt.Focus();

            //    return false;
            //}

            return true;
        }


        #region Constructor
        /// <summary>
        /// Constructor for the  form
        /// </summary>
        /// <param name="pmode"></param>
        /// <param name="userItem"></param>
        public AddMoldCategoryForm(string pmode, MoldCategoryVo userItem = null)
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
        private void LoadUserData(MoldCategoryVo dgvMoldType)
        {
            if (dgvMoldType != null)
            {
                this.MoldCategoryCode_txt.Text = dgvMoldType.MoldCategoryCode;

                this.MoldCategoryName_txt.Text = dgvMoldType.MoldCategoryName;
                //this.DisplayOrder_txt.Text = dgvMoldType.DisplayOrder.ToString();
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
        private MoldCategoryVo DuplicateCheck(MoldCategoryVo MoldCategoryVo)
        {
            MoldCategoryVo outVo = new MoldCategoryVo();

            try
            {
                this.Cursor = Cursors.WaitCursor;
                outVo = (MoldCategoryVo)base.InvokeCbm(new CheckMoldCategoryMasterMntCbm(), MoldCategoryVo, false);
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

        /// <summary>
        /// checks duplicate Display Record
        /// </summary>
        /// <param name="defectVo"></param>
        /// <returns></returns>
        private MoldCategoryVo DuplicateDisplayCheck(MoldCategoryVo defectVo)
        {
            MoldCategoryVo outVo = new MoldCategoryVo();

            try
            {
                outVo = (MoldCategoryVo)base.InvokeCbm(new CheckDisplayRecordMasterMntCbm(), defectVo, false);
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
        private void AddMoldCategoryForm_Load(object sender, EventArgs e)
        {
            // FormDatatableFromVo();

            MoldCategoryCode_txt.Select();

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadUserData(updateData);

                MoldCategoryCode_txt.Enabled = false;

                MoldCategoryName_txt.Select();

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
            MoldCategoryVo inVo = new MoldCategoryVo();

            if (CheckMandatory())
            {

                var sch = StringCheckHelper.GetInstance();

                if (!sch.IsASCII(MoldCategoryCode_txt.Text) || !sch.IsASCII(MoldCategoryName_txt.Text)) //|| !sch.IsASCII(DisplayOrder_txt.Text)
                {
                    messageData = new MessageData("mmce00003", Properties.Resources.mmce00003);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);

                    if (!sch.IsASCII(MoldCategoryCode_txt.Text))
                    {
                        MoldCategoryCode_txt.Focus();
                    }
                    else if (!sch.IsASCII(MoldCategoryName_txt.Text))
                    {
                        MoldCategoryName_txt.Focus();
                    }
                    else
                    {
                        DisplayOrder_txt.Focus();
                    }

                    return;
                }
                inVo.MoldCategoryCode = MoldCategoryCode_txt.Text.Trim();

                inVo.MoldCategoryName = MoldCategoryName_txt.Text.Trim();
               // inVo.DisplayOrder = Convert.ToInt32(DisplayOrder_txt.Text.Trim());

                if (string.Equals(mode, CommonConstants.MODE_ADD))
                {
                    MoldCategoryVo checkVo = DuplicateCheck(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, MoldCategoryCode_lbl.Text + " : " + MoldCategoryCode_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.ConfirmationOkCancel(messageData, Text);
                        MoldCategoryCode_txt.Focus();
                        return;
                    }

                    //MoldCategoryVo checkDisplayVo = DuplicateDisplayCheck(inVo);
                    //if (checkDisplayVo != null && checkDisplayVo.AffectedCount > 0)
                    //{
                    //    messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, DisplayOrder_lbl.Text + " : " + DisplayOrder_txt.Text);
                    //    logger.Info(messageData);
                    //    popUpMessage.ConfirmationOkCancel(messageData, Text);
                    //    DisplayOrder_txt.Focus();
                    //    return;
                    //}
                }

                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        MoldCategoryVo outVo = (MoldCategoryVo)base.InvokeCbm(new AddMoldCategoryMasterMntCbm(), inVo, false);

                        IntSuccess = outVo.MoldCategoryId;
                    }
                    else if (mode.Equals(CommonConstants.MODE_UPDATE))
                    {

                        //if (updateData.DisplayOrder != Convert.ToInt32(DisplayOrder_txt.Text))
                        //{
                        //    MoldCategoryVo checkDisplayVo = DuplicateDisplayCheck(inVo);
                        //    if (checkDisplayVo != null && checkDisplayVo.AffectedCount > 0)
                        //    {
                        //        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, DisplayOrder_lbl.Text + " : " + DisplayOrder_txt.Text);
                        //        logger.Info(messageData);
                        //        popUpMessage.ConfirmationOkCancel(messageData, Text);
                        //        DisplayOrder_txt.Focus();
                        //        return;
                        //    }
                        //}
                        inVo.MoldCategoryId = updateData.MoldCategoryId;
                        MoldCategoryVo outVo = (MoldCategoryVo)base.InvokeCbm(new UpdateMoldCategoryMasterMntCbm(), inVo, false);
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