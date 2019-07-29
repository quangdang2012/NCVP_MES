using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Resources;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class MoldItemMasterForm
    {

        #region Variables

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(MoldItemMasterForm));

        /// <summary>
        /// initialize SortOrder
        /// </summary>
        private SortOrder sortDirection;

        /// <summary>
        /// previous value of Consumed quantity
        /// </summary>
        private string prvQtyInput = string.Empty;

        /// <summary>
        /// cursorStart
        /// </summary>
        private int cursorStart;

        #endregion

        #region Constructor

        /// <summary>
        /// constructor of the form
        /// </summary>
        public MoldItemMasterForm()
        {
            InitializeComponent();
        }
        #endregion

        #region PrivateMethods

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

        private void LoadMold()
        {

            ValueObjectList<MoldDetailVo> outVo = null;

            this.Cursor = Cursors.WaitCursor;
            try
            {
                outVo = (ValueObjectList<MoldDetailVo>)base.InvokeCbm(new GetMoldDetailMasterMntCbm(), new MoldDetailVo(), false);
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
            if (outVo == null || outVo.GetList() == null || outVo.GetList().Count == 0)
            {
                messageData = new MessageData("mmce00026", Properties.Resources.mmce00026);
                logger.Info(messageData, new NullReferenceException());
                popUpMessage.Information(messageData, Text);
                return;
            }

            ComboBind(Mold_cmb, outVo.GetList(), "MoldCode", "MoldId");


        }
        /// <summary>
        /// Load Global Item
        /// </summary>
        private void LoadSapItem()
        {
            ValueObjectList<MoldItemVo> itemOutVo = null;

            this.Cursor = Cursors.WaitCursor;
            try
            {
                itemOutVo = (ValueObjectList<MoldItemVo>)base.InvokeCbm(new GetSapItemForMESItemCbm(), new MoldItemVo(), false);
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

            if (itemOutVo == null || itemOutVo.GetList() == null || itemOutVo.GetList().Count == 0)
            {
                messageData = new MessageData("mmce00026", Properties.Resources.mmce00026);
                logger.Info(messageData, new NullReferenceException());
                popUpMessage.Information(messageData, Text);
                return;
            }

            itemOutVo.GetList().ForEach(w => w.GlobalItemCode = w.GlobalItemCode + "  " + w.GlobalItemName);

            ComboBind(SapItem_cmb, itemOutVo.GetList(), "GlobalItemCode", "GlobalItemId");
        }

        /// <summary>
        /// Creates seacrh condition as per user inputs 
        /// </summary>
        /// <returns>search condition</returns>
        private MoldItemVo FormConditionVo()
        {
            MoldItemVo inVo = new MoldItemVo();

            if (Mold_cmb.SelectedIndex > -1)
            {
                inVo.MoldId = Convert.ToInt32(Mold_cmb.SelectedValue);
            }
            if (SapItem_cmb.SelectedIndex > -1)
            {
                inVo.GlobalItemId = Convert.ToInt32(SapItem_cmb.SelectedValue);
            }

            return inVo;
        }

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(MoldItemVo conditionInVo)
        {
            MoldItem_dgv.DataSource = null;

            MoldItemVo inVo = new MoldItemVo();

            if (Mold_cmb.SelectedIndex > -1)
            {
                inVo.MoldId = Convert.ToInt32(Mold_cmb.SelectedValue);
            }

            if (SapItem_cmb.SelectedIndex > -1)
            {
                inVo.GlobalItemId = Convert.ToInt32(SapItem_cmb.SelectedValue);
            }

            try
            {

                ValueObjectList<MoldItemVo> outVo = (ValueObjectList<MoldItemVo>)base.InvokeCbm(new GetMoldItemCbm(), inVo, false);

                MoldItem_dgv.AutoGenerateColumns = false;

                if (outVo == null || outVo.GetList() == null || outVo.GetList().Count == 0)
                {
                    messageData = new MessageData("mmce00027", Properties.Resources.mmce00027);
                    logger.Info(messageData, new NullReferenceException());
                    popUpMessage.Information(messageData, Text);
                    return;
                }
                outVo.GetList().ForEach(t =>
                {
                    t.IsExists = t.GlobalItemCode != null ? "True" : "False";
                    t.StdCycleTime = t.StdCycleTime.Equals(DBNull.Value) ? default(decimal) : Convert.ToDecimal(t.StdCycleTime.ToString("N2"));
                });

                BindingSource bindingSource1 = new BindingSource(outVo.GetList(), null);


                if (bindingSource1.Count > 0)
                {
                    MoldItem_dgv.DataSource = bindingSource1;
                    if (MoldItem_dgv.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow row in MoldItem_dgv.Rows)
                        {
                            if ((bool)row.Cells["colSelect"].FormattedValue)
                            {
                                row.Cells["clmstdcycletime"].ReadOnly = false;
                            }
                            else
                            {
                                row.Cells["clmstdcycletime"].ReadOnly = true;
                            }
                        }
                    }
                    //Update_btn.Enabled = true;

                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null); //Line machine
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }

                MoldItem_dgv.ClearSelection();

            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        /// <summary>
        /// Checks mandatory fields
        /// </summary>
        /// <returns></returns>
        private bool CheckMandatory()
        {

            if (SapItem_cmb.Text == string.Empty || SapItem_cmb.SelectedIndex < 0)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, SapItem_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                SapItem_cmb.Focus();

                return false;
            }

            foreach (DataGridViewRow dr in MoldItem_dgv.Rows)
            {
                if (dr.Cells["colSelect"].Value.ToString() == "True" &&
                    (string.IsNullOrEmpty(dr.Cells["clmStdcycletime"].Value.ToString()) ||
                    dr.Cells["clmStdcycletime"].Value.ToString() == "0" ||
                    dr.Cells["clmStdcycletime"].Value.ToString() == "0.00"))
                {
                    messageData = new MessageData("mmce00022", Properties.Resources.mmce00019);
                    popUpMessage.Warning(messageData, Text);
                    MoldItem_dgv.CurrentCell = dr.Cells["clmStdcycletime"];
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// binds datasource
        /// </summary>
        /// <param name="outVo"></param>
        private void BindDataSource(List<MoldItemVo> outVo)
        {
            MoldItem_dgv.AutoGenerateColumns = false;
            BindingSource bindingSource1 = new BindingSource(outVo, null);

            if (bindingSource1 != null && bindingSource1.Count > 0)
            {
                MoldItem_dgv.DataSource = bindingSource1;
            }
            else
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null); //"Department"
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
            }
            MoldItem_dgv.ClearSelection();
        }

        #endregion

        #region FormEvents
        /// <summary>
        /// form loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoldItemMasterForm_Load(object sender, EventArgs e)
        {
            LoadMold();
            LoadSapItem();

            Mold_cmb.Select();
            Update_btn.Enabled = false;
        }
        #endregion

        #region ButtonClick

        /// <summary>
        /// event to get the record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_btn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            GridBind(FormConditionVo());

            Cursor.Current = Cursors.Default;

        }

        /// <summary>
        /// event to clear the controls of search criteria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_btn_Click(object sender, EventArgs e)
        {
            Mold_cmb.SelectedIndex = -1;
            SapItem_cmb.SelectedIndex = -1;
            MoldItem_dgv.DataSource = null;
            Update_btn.Enabled = false;
        }
        /// <summary>
        /// updates Line Machine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_btn_Click(object sender, EventArgs e)
        {

            if (MoldItem_dgv.RowCount > 0)
            { }

            ValueObjectList<MoldItemVo> inVo = new ValueObjectList<MoldItemVo>();

            foreach (DataGridViewRow row in MoldItem_dgv.Rows)
            {
                if (row.Cells["colSelect"].Value.ToString() == "True")
                {
                    MoldItemVo selectedItem = (MoldItemVo)row.DataBoundItem;

                    MoldItemVo addVo = new MoldItemVo();
                    addVo.MoldId = selectedItem.MoldId;
                    addVo.StdCycleTime = selectedItem.StdCycleTime;
                    addVo.GlobalItemId = selectedItem.GlobalItemId;

                    inVo.add(addVo);
                }
            }

            UpdateResultVo outVo = null;
            try
            {

                Cursor.Current = Cursors.WaitCursor;


                outVo = (UpdateResultVo)base.InvokeCbm(new UpdateModelItemForMultipleItemCbm(), inVo, false);


                Cursor.Current = Cursors.Default;
            }
            catch (Framework.ApplicationException exception)
            {
                Cursor.Current = Cursors.Default;
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            if (outVo == null)
            {
                return;
            }
            messageData = new MessageData("mmci00002", Properties.Resources.mmci00002, null);
            logger.Info(messageData);
            popUpMessage.Information(messageData, Text);

            GridBind(FormConditionVo());

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
        /// LineMachine_dgv_ColumnHeaderMouseClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LineMachine_dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn column = MoldItem_dgv.Columns[e.ColumnIndex];

            if (MoldItem_dgv.DataSource == null) { return; }

            BindingSource currentDatagridSource = (BindingSource)MoldItem_dgv.DataSource;

            List<MoldItemVo> dataSourceVo = (List<MoldItemVo>)currentDatagridSource.DataSource;

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
                MoldItem_dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = sortDirection;
            }
        }


        private void MoldItem_dgv_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                decimal i;

                if (!decimal.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                    e.Cancel = true;
                    messageData = new MessageData("mmce00023", Properties.Resources.mmce00023);
                    popUpMessage.Information(messageData, Text);
                    return;
                }
                if (Convert.ToDecimal(e.FormattedValue) <= 0)
                {
                    e.Cancel = true;
                    messageData = new MessageData("mmce00024", Properties.Resources.mmce00024);
                    popUpMessage.Information(messageData, Text);
                    return;
                }
            }
        }

        private void MoldItem_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                MoldItem_dgv.EndEdit();
                //if ((bool)MoldItem_dgv.CurrentRow.Cells[4].FormattedValue)
                //{
                //    MoldItem_dgv.CurrentRow.Cells[3].ReadOnly = false;
                //}
                //else
                //{
                //    MoldItem_dgv.CurrentRow.Cells[3].ReadOnly = true;
                //}
            }
        }

        private void MoldItem_dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ((TextBox)e.Control).KeyDown -= new KeyEventHandler(NumericText_KeyDown);
            ((TextBox)e.Control).TextChanged -= new EventHandler(NumericText_TextChanged);

            if (e.Control is TextBox && MoldItem_dgv.CurrentCell.OwningColumn.Name == "clmstdcycletime")
            {
                ((TextBox)e.Control).KeyDown += new KeyEventHandler(NumericText_KeyDown);
                ((TextBox)e.Control).TextChanged += new EventHandler(NumericText_TextChanged);
            }

        }


        /// <summary>
        /// check numeric
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericText_TextChanged(object sender, EventArgs e)
        {
            if (MoldItem_dgv.CurrentCell != null && MoldItem_dgv.CurrentCell.OwningColumn.Name != "clmstdcycletime")
            {
                return;
            }

            TextBox consQty_Txt = (TextBox)sender;

            if (consQty_Txt.Text == string.Empty)
            {
                prvQtyInput = string.Empty;
            }

            if (!Regex.IsMatch(consQty_Txt.Text, @"^\d{0,12}(\.\d{0,2})?$"))
            {
                consQty_Txt.Text = prvQtyInput;
                consQty_Txt.SelectionStart = cursorStart;
            }
            else
            {
                prvQtyInput = consQty_Txt.Text;
            }
        }

        /// <summary>
        /// cursor start
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericText_KeyDown(object sender, KeyEventArgs e)
        {
            cursorStart = ((TextBox)sender).SelectionStart;
        }

        #endregion
    }
}
