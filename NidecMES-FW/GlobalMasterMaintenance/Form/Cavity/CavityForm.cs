using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class CavityForm
    {
        #region Variables

        /// <summary>
        /// datatable for item data
        /// </summary>
        private DataTable moldDatatable;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(CavityForm));

        /// <summary>
        ///  get message data
        /// </summary>
        private MessageData messageData;

        #endregion

        #region Constructor

        /// <summary>
        /// constructor of the form
        /// </summary>
        public CavityForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(CavityVo conditionInVo)
        {
            if(conditionInVo == null)
            {
                return;
            }

            Cavity_dgv.DataSource = null;

            ValueObjectList<CavityVo> outVo = null;
            try
            {
                outVo = (ValueObjectList<CavityVo>)base.InvokeCbm(new GetCavityMasterMntCbm(), conditionInVo, false);

            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            if (outVo == null || outVo.GetList() == null || outVo.GetList().Count == 0)
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                return;
            }
            Cavity_dgv.AutoGenerateColumns = false;

            BindingSource bindingSource1 = new BindingSource(outVo.GetList(), null);

            if (bindingSource1 != null && bindingSource1.Count > 0)
            {
                Cavity_dgv.DataSource = bindingSource1;
            }
            else
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null); //"cavity"
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
            }
            Cavity_dgv.ClearSelection();

            Update_btn.Enabled = false;

            Delete_btn.Enabled = false;
        }


        /// <summary>
        /// Creates seacrh condition as per user inputs 
        /// </summary>
        /// <returns>search condition</returns>
        private CavityVo FormConditionVo()
        {

            if (!string.IsNullOrWhiteSpace(Mold_cmb.Text) && Mold_cmb.SelectedIndex <0)
            {
                messageData = new MessageData("mmce00013", Properties.Resources.mmce00013);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);

                return null;
            }

            CavityVo inVo = new CavityVo();

            if (Mold_cmb.SelectedIndex > -1)
            {
                inVo.MoldId = Convert.ToInt32(Mold_cmb.SelectedValue);
            }
            if (CavityCode_txt.Text != string.Empty) { inVo.CavityCode = CavityCode_txt.Text; }

            if (CavityName_txt.Text != string.Empty)
            {
                inVo.CavityName = CavityName_txt.Text;
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
        private void BindUpdateCavityData()
        {
            int selectedrowindex = Cavity_dgv.SelectedCells[0].RowIndex;

            CavityVo cavInVo = (CavityVo)Cavity_dgv.Rows[selectedrowindex].DataBoundItem;

            AddCavityForm newAddForm = new AddCavityForm(CommonConstants.MODE_UPDATE, cavInVo);
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
            moldDatatable = new DataTable();
            moldDatatable.Columns.Add("id");
            moldDatatable.Columns.Add("code");

            try
            {
                MoldVo moldOutVo = (MoldVo)base.InvokeCbm(new GetMoldMasterMntCbm(), new MoldVo(), false);

                foreach (MoldVo mold in moldOutVo.MoldListVo)
                {
                    moldDatatable.Rows.Add(mold.MoldId, mold.MoldCode);
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }


        #endregion

        #region FormEvents
        /// <summary>
        /// Loads Mold form
        /// Fill item combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CavityForm_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                FormDatatableFromVo();

                ComboBind(Mold_cmb, moldDatatable, "code", "id");

                CavityCode_txt.Select();

                Update_btn.Enabled = Delete_btn.Enabled = false;
            }

        }

        #endregion

        #region ButtonClick

        /// <summary>
        /// event to clear the controls of search criteria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Clear_btn_Click(object sender, EventArgs e)
        {
            CavityCode_txt.Text = string.Empty;

            CavityName_txt.Text = string.Empty;

            Mold_cmb.Text = string.Empty;

            Mold_cmb.SelectedIndex = -1;

            Cavity_dgv.DataSource = null;

            Mold_cmb.Select();
            Update_btn.Enabled = Delete_btn.Enabled = false;
        }

        /// <summary>
        /// event to get the record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Search_btn_Click(object sender, EventArgs e)
        {
            GridBind(FormConditionVo());
        }

        /// <summary>
        /// event to open the  add screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Add_btn_Click(object sender, EventArgs e)
        {
            AddCavityForm newAddForm = new AddCavityForm(CommonConstants.MODE_ADD, null);
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
        protected virtual void Update_btn_Click(object sender, EventArgs e)
        {
            BindUpdateCavityData();
        }

        /// <summary>
        /// event to delete the selected record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Delete_btn_Click(object sender, EventArgs e)
        {
            int selectedrowindex = Cavity_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = Cavity_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colCavityCode"].Value.ToString());
            logger.Info(messageData);
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);


            if (dialogResult == DialogResult.OK)
            {
                CavityVo inVo = new CavityVo
                {
                    CavityId = Convert.ToInt32(selectedRow.Cells["colCavityId"].Value),
                    RegistrationDateTime = Convert.ToDateTime(DateTime.Now.ToString(UserData.GetUserData().DateTimeFormat)),
                    RegistrationUserCode = UserData.GetUserData().UserCode,
                };

                try
                {
                    CavityVo outVo = (CavityVo)base.InvokeCbm(new DeleteCavityMasterMntCbm(), inVo, false);

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
        protected virtual void Cavity_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Cavity_dgv.SelectedRows.Count > 0)
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
        protected virtual void Cavity_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Cavity_dgv.SelectedRows.Count > 0)
            {
                BindUpdateCavityData();
            }
        }

        #endregion

    }
}
