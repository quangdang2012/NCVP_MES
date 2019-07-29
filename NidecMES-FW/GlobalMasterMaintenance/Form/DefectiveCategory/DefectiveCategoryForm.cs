using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class DefectiveCategoryForm
    {
        #region Variables

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(DefectiveCategoryForm));

        /// <summary>
        ///  get message data
        /// </summary>
        private MessageData messageData;

        #endregion

        #region Constructor

        /// <summary>
        /// constructor of the form
        /// </summary>
        public DefectiveCategoryForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(DefectiveCategoryVo conditionInVo)
        {
            DefectiveCategoryDetails_dgv.DataSource = null;

            try
            {
                DefectiveCategoryVo outVo = (DefectiveCategoryVo)base.InvokeCbm(new GetDefectiveCategoryMasterMntCbm(), conditionInVo, false);

                DefectiveCategoryDetails_dgv.AutoGenerateColumns = false;

                BindingSource defectiveCategoryBindingSource = new BindingSource(outVo.DefectiveCategoryListVo, null);

                if (defectiveCategoryBindingSource.Count > 0)
                {
                    DefectiveCategoryDetails_dgv.DataSource = defectiveCategoryBindingSource;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }

                DefectiveCategoryDetails_dgv.ClearSelection();

                Update_btn.Enabled = false;

                Delete_btn.Enabled = false;

            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        /// <summary>
        /// Creates seacrh condition as per user inputs 
        /// </summary>
        /// <returns>search condition</returns>
        private DefectiveCategoryVo FormConditionVo()
        {
            DefectiveCategoryVo inVo = new DefectiveCategoryVo();


            if (DefectiveCategoryCode_txt.Text != string.Empty)
            {
                inVo.DefectiveCategoryCode = DefectiveCategoryCode_txt.Text;
            }

            if (DefectiveCategoryName_txt.Text != string.Empty)
            {
                inVo.DefectiveCategoryName = DefectiveCategoryName_txt.Text;
            }

            return inVo;
        }

        /// <summary>
        /// selects user record for updation and show DefectiveCategory form
        /// </summary>
        private void BindUpdateDefectiveCategoryData()
        {
            int selectedrowindex = DefectiveCategoryDetails_dgv.SelectedCells[0].RowIndex;

            DefectiveCategoryVo selectedDefectiveCategory = (DefectiveCategoryVo)DefectiveCategoryDetails_dgv.Rows[selectedrowindex].DataBoundItem;

            AddDefectiveCategoryForm newAddForm = new AddDefectiveCategoryForm(CommonConstants.MODE_UPDATE, selectedDefectiveCategory);

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
                messageData = new MessageData("mmci00007", Properties.Resources.mmci00007, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                GridBind(FormConditionVo());
            }
        }


        #endregion

        #region FormEvents
        /// <summary>
        /// form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DefectiveCategoryForm_Load(object sender, EventArgs e)
        {
            Update_btn.Enabled = Delete_btn.Enabled = false;
            DefectiveCategoryCode_txt.Select();
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
            DefectiveCategoryCode_txt.Text = string.Empty;
            DefectiveCategoryName_txt.Text = string.Empty;
            DefectiveCategoryDetails_dgv.DataSource = null;
            Update_btn.Enabled = Delete_btn.Enabled = false;
        }

        /// <summary>
        /// event to get the record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param
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
            AddDefectiveCategoryForm newAddForm = new AddDefectiveCategoryForm(CommonConstants.MODE_ADD, null);

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
            BindUpdateDefectiveCategoryData();
        }

        /// <summary>
        /// event to delete the selected record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_btn_Click(object sender, EventArgs e)
        {

            int selectedrowindex = DefectiveCategoryDetails_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = DefectiveCategoryDetails_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colDefectiveCategoryName"].Value.ToString());
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

            if (dialogResult == DialogResult.OK)
            {
                DefectiveCategoryVo inVo = new DefectiveCategoryVo
                {
                    DefectiveCategoryId = Convert.ToInt32(selectedRow.Cells["colDefectiveCategoryId"].Value)
                };

                try
                {
                    DefectiveCategoryVo outVo = (DefectiveCategoryVo)base.InvokeCbm(new DeleteDefectiveCategoryMasterMntCbm(), inVo, false);

                    if (outVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmci00003", Properties.Resources.mmci00003, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);

                        GridBind(FormConditionVo());
                    }
                    else if (outVo.AffectedCount == 0)
                    {
                        messageData = new MessageData("mmci00007", Properties.Resources.mmci00007, null);
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
            Close();
        }

        #endregion

        #region ControlEvents

        /// <summary>
        /// Handles factory record selection for Update/Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DefectiveCategoryDetails_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DefectiveCategoryDetails_dgv.SelectedRows.Count > 0)
            {
                Update_btn.Enabled = Delete_btn.Enabled = true;
            }
            else
            {
                Update_btn.Enabled = Delete_btn.Enabled = false;
            }
        }

        /// <summary>
        /// Handles update factory form show on row double click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DefectiveCategoryDetails_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DefectiveCategoryDetails_dgv.SelectedRows.Count > 0)
            {
                BindUpdateDefectiveCategoryData();
            }
        }

        #endregion

    }
}
