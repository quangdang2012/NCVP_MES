using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class MoldCategoryForm
    {
        #region Variables

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(MoldCategoryForm));

        /// <summary>
        ///  get message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        /// Category
        /// </summary>
        private const string CATEGORY = "Category";

        #endregion

        #region Constructor

        /// <summary>
        /// constructor of the form
        /// </summary>
        public MoldCategoryForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(MoldCategoryVo conditionInVo)
        {
            MoldCategory_dgv.DataSource = null;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                ValueObjectList<MoldCategoryVo> outVo = (ValueObjectList<MoldCategoryVo>)base.InvokeCbm(new GetMoldCategoryMasterMntCbm(), conditionInVo, false);

                MoldCategory_dgv.AutoGenerateColumns = false;

                BindingSource bindingSource1 = new BindingSource(outVo.GetList(), null);

                if (bindingSource1 != null && bindingSource1.Count > 0)
                {
                    MoldCategory_dgv.DataSource = bindingSource1;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null); //"MoldCategory"
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }
                MoldCategory_dgv.ClearSelection();

                Update_btn.Enabled = false;

                Delete_btn.Enabled = false;
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
        }


        /// <summary>
        /// Creates seacrh condition as per user inputs 
        /// </summary>
        /// <returns>search condition</returns>
        private MoldCategoryVo FormConditionVo()
        {
            MoldCategoryVo inVo = new MoldCategoryVo();

            if (MoldCategoryCode_txt.Text != string.Empty) { inVo.MoldCategoryCode = MoldCategoryCode_txt.Text; }

            if (MoldCategoryName_txt.Text != string.Empty)
            {
                inVo.MoldCategoryName = MoldCategoryName_txt.Text;
            }

            return inVo;

        }

        /// <summary>
        /// selects user record for updation and show user form
        /// </summary>
        private void BindUpdateMoldCategoryData()
        {
            int selectedrowindex = MoldCategory_dgv.SelectedCells[0].RowIndex;

            MoldCategoryVo cavInVo = (MoldCategoryVo)MoldCategory_dgv.Rows[selectedrowindex].DataBoundItem;

            AddMoldCategoryForm newAddForm = new AddMoldCategoryForm(CommonConstants.MODE_UPDATE, cavInVo);

            newAddForm.ShowDialog(this);

            if (newAddForm.IntSuccess > 0)
            {
                messageData = new MessageData("mmci00002", Properties.Resources.mmci00002, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);

                GridBind(FormConditionVo());
            }
            else if (newAddForm.IntSuccess == 0)
            {
                messageData = new MessageData("mmci00007", Properties.Resources.mmci00004, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                GridBind(FormConditionVo());
            }
        }

        /// <summary>
        /// checks mold category relation to other tables in DB
        /// </summary>
        /// <param name="moVo"></param>
        /// <returns></returns>
        private MoldCategoryVo CheckRelation(MoldCategoryVo moVo)
        {
            MoldCategoryVo outVo = new MoldCategoryVo();

            try
            {
                this.Cursor = Cursors.WaitCursor;
                outVo = (MoldCategoryVo)base.InvokeCbm(new CheckMoldCategoryRelationCbm(), moVo, false);
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
        /// Loads Mold form
        /// Fill item combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoldCategoryForm_Load(object sender, EventArgs e)
        {
          
            MoldCategoryCode_txt.Select();

            Update_btn.Enabled = Delete_btn.Enabled = false;
        }

        #endregion

        #region ButtonClick

        /// <summary>
        /// event to clear the controls of search criteria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_btn_Click(object sender, EventArgs e)
        {
            MoldCategoryCode_txt.Text = string.Empty;

            MoldCategoryName_txt.Text = string.Empty;           

            MoldCategory_dgv.DataSource = null;

            MoldCategoryCode_txt.Select();
            Update_btn.Enabled = Delete_btn.Enabled = false;
        }

        /// <summary>
        /// event to get the record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_btn_Click(object sender, EventArgs e)
        {
            GridBind(FormConditionVo());
        }

        /// <summary>
        /// event to open the  add screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_btn_Click(object sender, EventArgs e)
        {
            AddMoldCategoryForm newAddForm = new AddMoldCategoryForm(CommonConstants.MODE_ADD, null);

            newAddForm.ShowDialog();

            if (newAddForm.IntSuccess > 0)
            {
                messageData = new MessageData("mmci00001", Properties.Resources.mmci00001, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);

                GridBind(FormConditionVo());
            }
        }

        /// <summary>
        /// event to open the  updatescreen 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_btn_Click(object sender, EventArgs e)
        {
            BindUpdateMoldCategoryData();
        }

        /// <summary>
        /// event to delete the selected record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_btn_Click(object sender, EventArgs e)
        {
            int selectedrowindex = MoldCategory_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = MoldCategory_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colMoldCategoryCode"].Value.ToString());
            logger.Info(messageData);
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);


            if (dialogResult == DialogResult.OK)
            {
                MoldCategoryVo inVo = new MoldCategoryVo();

                inVo.MoldCategoryId = Convert.ToInt32(selectedRow.Cells["colMoldCategoryId"].Value);
                inVo.MoldCategoryCode = selectedRow.Cells["colMoldCategoryCode"].Value.ToString();

                try
                {
                    MoldCategoryVo checkVo = CheckRelation(inVo);
                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00007", Properties.Resources.mmce00007, "Mold");
                        popUpMessage.Information(messageData, Text);
                        return;
                    }

                    this.Cursor = Cursors.WaitCursor;
                    MoldCategoryVo outVo = (MoldCategoryVo)base.InvokeCbm(new DeleteMoldCategoryMasterMntCbm(), inVo, false);

                    if (outVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmci00003", Properties.Resources.mmci00003, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);

                        GridBind(FormConditionVo());
                    }
                    else if (outVo.AffectedCount == 0)
                    {
                        messageData = new MessageData("mmci00007", Properties.Resources.mmci00004, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                        GridBind(FormConditionVo());
                    }
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
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                //do something else
            }
        }

        /// <summary>
        /// close form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region ControlEvents

        /// <summary>
        /// Handles user record selection for Update/Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cavity_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MoldCategory_dgv.SelectedRows.Count > 0)
            {
                Update_btn.Enabled = Delete_btn.Enabled = true;
            }
            else
            {
                Update_btn.Enabled = Delete_btn.Enabled = false;
            }
        }

        /// <summary>
        /// Handles update user form show on row double click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cavity_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MoldCategory_dgv.SelectedRows.Count > 0)
            {
                BindUpdateMoldCategoryData();
            }
        }

        #endregion

    }
}
