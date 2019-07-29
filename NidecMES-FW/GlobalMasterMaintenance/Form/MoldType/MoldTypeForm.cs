using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class MoldTypeForm
    {
        #region Variables

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
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(MoldTypeForm));

        /// <summary>
        ///  get message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        /// Mold
        /// </summary>
        private const string MOLD = "MOLD";

        #endregion

        #region Constructor

        /// <summary>
        /// constructor of the form
        /// </summary>
        public MoldTypeForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(MoldTypeVo conditionInVo)
        {
            MoldType_dgv.DataSource = null;

            try
            {
                MoldTypeVo outVo = (MoldTypeVo)base.InvokeCbm(new GetMoldTypeMasterMntCbm(), conditionInVo, false);

                MoldType_dgv.AutoGenerateColumns = false;

                BindingSource bindingSource1 = new BindingSource(outVo.MoldTypeListVo, null);

                if (bindingSource1.Count > 0)
                {
                    MoldType_dgv.DataSource = bindingSource1;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null); //mold type
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }

                MoldType_dgv.ClearSelection();

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
        private MoldTypeVo FormConditionVo()
        {
            MoldTypeVo inVo = new MoldTypeVo();

            if (MoldTypeCode_txt.Text != string.Empty) { inVo.MoldTypeCode = MoldTypeCode_txt.Text; }

            if (MoldTypeName_txt.Text != string.Empty)
            {
                inVo.MoldTypeName = MoldTypeName_txt.Text;
            }

            if (Item_cmb.SelectedIndex > -1)
            {
                inVo.ItemId = Convert.ToInt32(Item_cmb.SelectedValue);
            }

            return inVo;

        }


        /// <summary>
        /// Handles Combobox loading for Item
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
        /// selects user record for updation and show user form
        /// </summary>
        private void BindUpdateUserData()
        {
            int selectedrowindex = MoldType_dgv.SelectedCells[0].RowIndex;

            MoldTypeVo selectedMoldType = (MoldTypeVo)MoldType_dgv.Rows[selectedrowindex].DataBoundItem;

            AddMoldTypeForm newAddForm = new AddMoldTypeForm(CommonConstants.MODE_UPDATE, selectedMoldType);

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
        /// checks moldtype relation to other tables in DB
        /// </summary>
        /// <param name="mtVo"></param>
        /// <returns></returns>
        private MoldTypeVo CheckRelation(MoldTypeVo mtVo)
        {
            MoldTypeVo outVo = new MoldTypeVo();

            try
            {
                outVo = (MoldTypeVo)base.InvokeCbm(new CheckMoldTypeRelationCbm(), mtVo, false);
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
        /// Loads MoldType form
        /// Fill item combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoldTypeForm_Load(object sender, EventArgs e)
        {
            FormDatatableFromVo();

            ComboBind(Item_cmb, itemDatatable, "code", "id");

            MoldTypeCode_txt.Select();

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
            MoldTypeCode_txt.Text = string.Empty;

            MoldTypeName_txt.Text = string.Empty;

            Item_cmb.SelectedIndex = -1;

            MoldType_dgv.DataSource = null;

            MoldTypeCode_txt.Select();
            Update_btn.Enabled = Delete_btn.Enabled = false;
        }

        /// <summary>
        /// event to get the record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Item_cmb.Text) && !(Item_cmb.SelectedIndex > -1))
            {
                messageData = new MessageData("mmce00010", Properties.Resources.mmce00010, Item_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                Item_cmb.Focus();
                return;
            }

            GridBind(FormConditionVo());
        }

        /// <summary>
        /// event to open the  add screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_btn_Click(object sender, EventArgs e)
        {
            AddMoldTypeForm newAddForm = new AddMoldTypeForm(CommonConstants.MODE_ADD, null);

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
            BindUpdateUserData();
        }

        /// <summary>
        /// event to delete the selected record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_btn_Click(object sender, EventArgs e)
        {

            int selectedrowindex = MoldType_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = MoldType_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colMoldTypeCode"].Value.ToString());

            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

            if (dialogResult == DialogResult.OK)
            {
                MoldTypeVo inVo = new MoldTypeVo
                {
                    MoldTypeId = Convert.ToInt32(selectedRow.Cells["colMoldTypeId"].Value),
                    //RegistrationDateTime = DateTime.Now.ToString("yyyy/MM/dd/ HH:mm:ss"),
                    RegistrationUserCode = UserData.GetUserData().UserCode,
                    MoldTypeCode = selectedRow.Cells["colMoldTypeCode"].Value.ToString()
                };

                try
                {

                    MoldTypeVo checkVo = CheckRelation(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00007", Properties.Resources.mmce00007, MOLD.ToString());
                        popUpMessage.Information(messageData, Text);
                        return;
                    }

                    MoldTypeVo outVo = (MoldTypeVo)base.InvokeCbm(new DeleteMoldTypeMasterMntCbm(), inVo, false);

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
            this.Close();
        }

        #endregion

        #region ControlEvents

        /// <summary>
        /// Handles user record selection for Update/Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoldType_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MoldType_dgv.SelectedRows.Count > 0)
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
        private void MoldType_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MoldType_dgv.SelectedRows.Count > 0)
            {
                BindUpdateUserData();
            }
        }

        #endregion

    }
}
