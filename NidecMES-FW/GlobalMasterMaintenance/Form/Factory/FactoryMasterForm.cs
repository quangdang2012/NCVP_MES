using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Collections.Generic;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class FactoryMasterForm
    {
        #region Variables

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(FactoryMasterForm));

        /// <summary>
        ///  get message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        /// USER
        /// </summary>
        private const string USER = "USER";

        /// <summary>
        /// initialize SortOrder
        /// </summary>
        private SortOrder sortDirection;

        #endregion

        #region Constructor

        /// <summary>
        /// constructor of the form
        /// </summary>
        public FactoryMasterForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(FactoryVo conditionInVo)
        {
            FactoryDetails_dgv.DataSource = null;

            try
            {
                FactoryVo outVo = (FactoryVo)base.InvokeCbm(new GetFactoryMasterMntCbm(), conditionInVo, false);

                FactoryDetails_dgv.AutoGenerateColumns = false;

                BindingSource factoryBindingSource = new BindingSource(outVo.FactoryListVo, null);

                if (factoryBindingSource.Count > 0)
                {
                    FactoryDetails_dgv.DataSource = factoryBindingSource;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null); //"factory"
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }

                FactoryDetails_dgv.ClearSelection();

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
        private FactoryVo FormConditionVo()
        {
            FactoryVo inVo = new FactoryVo();


            if (FactoryCode_txt.Text != string.Empty)
            {
                inVo.FactoryCode = FactoryCode_txt.Text;
            }

            if (FactoryName_txt.Text != string.Empty)
            {
                inVo.FactoryName = FactoryName_txt.Text;
            }

            return inVo;
        }

        /// <summary>
        /// selects user record for updation and show factory form
        /// </summary>
        private void BindUpdateFactoryData()
        {
            int selectedrowindex = FactoryDetails_dgv.SelectedCells[0].RowIndex;

            FactoryVo selectedFactory = (FactoryVo)FactoryDetails_dgv.Rows[selectedrowindex].DataBoundItem;

            AddFactoryMasterForm newAddForm = new AddFactoryMasterForm(CommonConstants.MODE_UPDATE, selectedFactory);

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
        /// binds datasource
        /// </summary>
        /// <param name="outVo"></param>
        private void BindDataSource(List<FactoryVo> outVo)
        {
            FactoryDetails_dgv.AutoGenerateColumns = false;
            BindingSource bindingSource1 = new BindingSource(outVo, null);

            if (bindingSource1 != null && bindingSource1.Count > 0)
            {
                FactoryDetails_dgv.DataSource = bindingSource1;
            }
            else
            {
                messageData = new MessageData("tpci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
            }
            FactoryDetails_dgv.ClearSelection();
        }

        /// <summary>
        /// checks factory relation to other tables in DB
        /// </summary>
        /// <param name="facVo"></param>
        /// <returns></returns>
        private FactoryVo CheckRelation(FactoryVo facVo)
        {
            FactoryVo outVo = new FactoryVo();

            try
            {
                outVo = (FactoryVo)base.InvokeCbm(new CheckFactoryRelationCbm(), facVo, false);
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
        /// form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FactoryMasterForm_Load(object sender, EventArgs e)
        {
            Update_btn.Enabled = Delete_btn.Enabled = false;
            FactoryCode_txt.Select();
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
            FactoryCode_txt.Text = string.Empty;
            FactoryName_txt.Text = string.Empty;
            FactoryDetails_dgv.DataSource = null;
            Update_btn.Enabled = Delete_btn.Enabled = false;
        }

        /// <summary>
        /// event to get the record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param
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
            AddFactoryMasterForm newAddForm = new AddFactoryMasterForm(CommonConstants.MODE_ADD, null);

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
            BindUpdateFactoryData();
        }

        /// <summary>
        /// event to delete the selected record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Delete_btn_Click(object sender, EventArgs e)
        {

            int selectedrowindex = FactoryDetails_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = FactoryDetails_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colFactoryName"].Value.ToString());
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

            if (dialogResult == DialogResult.OK)
            {
                FactoryVo inVo = new FactoryVo
                {
                    FactoryCode = selectedRow.Cells["colFactoryCode"].Value.ToString(),
                };

                try
                {

                    FactoryVo checkVo = CheckRelation(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00007", Properties.Resources.mmce00007, USER.ToString());
                        popUpMessage.Information(messageData, Text);
                        return;
                    }

                    FactoryVo outVo = (FactoryVo)base.InvokeCbm(new DeleteFactoryMasterMntCbm(), inVo, false);

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
        protected virtual void Exit_btn_Click(object sender, EventArgs e)
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
        protected virtual void FactoryDetails_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (FactoryDetails_dgv.SelectedRows.Count > 0)
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
        protected virtual void FactoryDetails_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (FactoryDetails_dgv.SelectedRows.Count > 0)
            {
                BindUpdateFactoryData();
            }
        }



        /// <summary>
        /// sorting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void FactoryDetails_dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn column = FactoryDetails_dgv.Columns[e.ColumnIndex];

            if (FactoryDetails_dgv.DataSource == null) { return; }

            BindingSource currentDatagridSource = (BindingSource)FactoryDetails_dgv.DataSource;

            List<FactoryVo> dataSourceVo = (List<FactoryVo>)currentDatagridSource.DataSource;

            if (!string.IsNullOrEmpty(column.DataPropertyName) && dataSourceVo.Count > 0 &&
                                                   column.CellType != typeof(DataGridViewButtonCell))
            {
                switch (sortDirection)
                {
                    case SortOrder.None:
                        sortDirection = SortOrder.Ascending;
                        break;
                    case SortOrder.Ascending:
                        sortDirection = SortOrder.Descending;
                        break;
                    case SortOrder.Descending:
                        sortDirection = SortOrder.Ascending;
                        break;
                }

                if (sortDirection == SortOrder.Ascending)
                {
                    dataSourceVo = dataSourceVo.OrderBy(t => t.GetType().GetProperty(column.DataPropertyName).GetValue(t)).ToList();
                }
                else if (sortDirection == SortOrder.Descending)
                {
                    dataSourceVo = dataSourceVo.OrderByDescending(t => t.GetType().GetProperty(column.DataPropertyName).GetValue(t)).ToList();
                }

                BindDataSource(dataSourceVo);
                FactoryDetails_dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = sortDirection;
            }
        }


        #endregion
    }
}
