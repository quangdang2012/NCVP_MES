using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class LineItemCycleTimeForm
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
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(LineItemCycleTimeForm));

        /// <summary>
        /// initialize SortOrder
        /// </summary>
        //private SortOrder sortDirection;

        /// <summary>
        /// previous value of Consumed quantity
        /// </summary>
        private string prvQtyInput = string.Empty;

        /// <summary>
        /// cursorStart
        /// </summary>
        private int cursorStart;

        private CbmController getLineItemCycleTimeMasterCbm = new GetLineItemCycleTimeMasterCbm();
        #endregion

        #region Constructor

        /// <summary>
        /// constructor of the form
        /// </summary>
        public LineItemCycleTimeForm()
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
            pCombo.DisplayMember = pDisplay;
            pCombo.ValueMember = pValue;
            pCombo.DataSource = pDatasource;
            pCombo.SelectedIndex = -1;
            pCombo.Text = string.Empty;
        }

        private void LoadLine()
        {

            LineVo outVo = new LineVo();

            try
            {
                outVo = (LineVo)base.InvokeCbm(new GetLineMasterMntCbm(), new LineVo(), false);

                outVo.LineListVo.ForEach(p => p.LineName = p.LineCode + " " + p.LineName);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }

            ComboBind(Line_cmb, outVo.LineListVo, "LineName", "LineId");


        }

        /// <summary>
        /// Creates seacrh condition as per user inputs 
        /// </summary>
        /// <returns>search condition</returns>
        private LineItemCycleTimeVo FormConditionVo()
        {
            LineItemCycleTimeVo inVo = new LineItemCycleTimeVo();

            inVo.LineId = Convert.ToInt32(Line_cmb.SelectedValue);
            if (SapItem_cmb.SelectedIndex > -1)
            {
                inVo.SapItemCode = SapItem_cmb.SelectedValue.ToString();
            }
            else
            {
                inVo.SapItemCode = null;
            }

            return inVo;
        }

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(LineItemCycleTimeVo conditionInVo)
        {
            StartProgress(Properties.Resources.mmci00009);

            LineItem_dgv.DataSource = null;

            ValueObjectList<LineItemCycleTimeVo> outVo = null;
            try
            {
                outVo = (ValueObjectList<LineItemCycleTimeVo>)base.InvokeCbm(getLineItemCycleTimeMasterCbm, conditionInVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                CompleteProgress();
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
            CompleteProgress();

            LineItem_dgv.AutoGenerateColumns = false;

            if (outVo == null || outVo.GetList() == null || outVo.GetList().Count == 0)
            {

                SapItem_cmb.DataSource = null;
                SapItem_cmb.SelectedIndex = -1;
                SapItem_cmb.Text = string.Empty;

                return;
            }
            LineItem_dgv.DataSource = outVo.GetList();

            if (SapItem_cmb.SelectedIndex > -1)
            {
                // do nothing
            }
            else
            {
                SapItem_cmb.DataSource = null;
                SapItem_cmb.DisplayMember = "SapItemCode";
                SapItem_cmb.ValueMember = "SapItemCode";
                SapItem_cmb.DataSource = outVo.GetList();
                SapItem_cmb.SelectedIndex = -1;
            }

            LineItem_dgv.ClearSelection();

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

            //foreach (DataGridViewRow dr in MoldItem_dgv.Rows)
            //{
            //    if (dr.Cells["colSelect"].Value.ToString() == "True" &&
            //        (string.IsNullOrEmpty(dr.Cells["clmStdcycletime"].Value.ToString()) ||
            //        dr.Cells["clmStdcycletime"].Value.ToString() == "0" ||
            //        dr.Cells["clmStdcycletime"].Value.ToString() == "0.00"))
            //    {
            //        messageData = new MessageData("mmce00022", Properties.Resources.mmce00022);
            //        popUpMessage.Warning(messageData, Text);
            //        MoldItem_dgv.CurrentCell = dr.Cells["clmStdcycletime"];
            //        return false;
            //    }
            //}

            return true;
        }

        /// <summary>
        /// binds datasource
        /// </summary>
        /// <param name="outVo"></param>
        private void BindDataSource(List<LineItemCycleTimeVo> outVo)
        {
            LineItem_dgv.AutoGenerateColumns = false;
            BindingSource bindingSource1 = new BindingSource(outVo, null);

            if (bindingSource1 != null && bindingSource1.Count > 0)
            {
                LineItem_dgv.DataSource = bindingSource1;
            }
            else
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null); //"Department"
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
            }
            LineItem_dgv.ClearSelection();
        }

        #endregion

        #region FormEvents
        /// <summary>
        /// form loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LineItemCycleTimeForm_Load(object sender, EventArgs e)
        {
            LoadLine();
            //LoadSapItem();

            Line_cmb.Select();
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
            if (Line_cmb.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, LineId_lbl.Text);
                logger.Info(messageData);
                popUpMessage.ConfirmationOkCancel(messageData, Text);
                Line_cmb.Focus();
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            string sapItem = SapItem_cmb.Text;

            GridBind(FormConditionVo());

            SapItem_cmb.Text = sapItem;

            Cursor.Current = Cursors.Default;

        }

        /// <summary>
        /// event to clear the controls of search criteria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_btn_Click(object sender, EventArgs e)
        {
            Line_cmb.SelectedIndex = -1;
            Line_cmb.Text = string.Empty;
            SapItem_cmb.DataSource = null;
            SapItem_cmb.SelectedIndex = -1;
            SapItem_cmb.Text = string.Empty;
            LineItem_dgv.DataSource = null;
            Update_btn.Enabled = false;
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
        /// check numeric
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericText_TextChanged(object sender, EventArgs e)
        {
            if (LineItem_dgv.CurrentCell != null && LineItem_dgv.CurrentCell.OwningColumn.Name != "clmstdcycletime")
            {
                return;
            }

            TextBox consQty_Txt = (TextBox)sender;

            if (consQty_Txt.Text == string.Empty)
            {
                prvQtyInput = string.Empty;
            }

            if (!Regex.IsMatch(consQty_Txt.Text, @"^\d{0,12}(\.\d{0,3})?$"))
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

        /// <summary>
        /// Edit Control Showing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LineItem_dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ((TextBox)e.Control).KeyDown -= new KeyEventHandler(NumericText_KeyDown);
            ((TextBox)e.Control).TextChanged -= new EventHandler(NumericText_TextChanged);

            if (e.Control is TextBox && LineItem_dgv.CurrentCell.OwningColumn.Name == "clmstdcycletime")
            {
                ((TextBox)e.Control).KeyDown += new KeyEventHandler(NumericText_KeyDown);
                ((TextBox)e.Control).TextChanged += new EventHandler(NumericText_TextChanged);
            }
        }

        /// <summary>
        /// CellContentClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LineItem_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 4)
            //{
            //    LineItem_dgv.EndEdit();
            //}
        }

        /// <summary>
        /// Cell Validating
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LineItem_dgv_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                decimal i;

                if (!decimal.TryParse(Convert.ToString(e.FormattedValue), out i) && !e.FormattedValue.ToString().Equals(string.Empty))
                {
                    e.Cancel = true;
                    messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, LineItem_dgv.Columns[e.ColumnIndex].HeaderText);
                    popUpMessage.Information(messageData, Text);
                    return;
                }
                //if (Convert.ToDecimal(e.FormattedValue) <= 0)
                //{
                //    e.Cancel = true;
                //    messageData = new MessageData("mmce00027", Properties.Resources.mmce00027);
                //    popUpMessage.Information(messageData, Text);
                //    return;
                //}
            }
        }

        /// <summary>
        /// LineItem_dgv_ColumnHeaderMouseClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LineItem_dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //DataGridViewColumn column = LineItem_dgv.Columns[e.ColumnIndex];

            //if (LineItem_dgv.DataSource == null) { return; }

            //BindingSource currentDatagridSource = (BindingSource)LineItem_dgv.DataSource;

            //List<LineItemCycleTimeVo> dataSourceVo = (List<LineItemCycleTimeVo>)currentDatagridSource.DataSource;

            //if (!string.IsNullOrEmpty(column.DataPropertyName) && dataSourceVo.Count > 0 &&
            //                                       column.CellType != typeof(DataGridViewButtonCell))
            //{
            //    switch (sortDirection)
            //    {
            //        case SortOrder.None:
            //            sortDirection = SortOrder.Ascending;
            //            break;
            //        case SortOrder.Ascending:
            //            sortDirection = SortOrder.Descending;
            //            break;
            //        case SortOrder.Descending:
            //            sortDirection = SortOrder.Ascending;
            //            break;
            //    }

            //    if (sortDirection == SortOrder.Ascending)
            //    {
            //        dataSourceVo = dataSourceVo.OrderBy(t => t.GetType().GetProperty(column.DataPropertyName).GetValue(t)).ToList();
            //    }
            //    else if (sortDirection == SortOrder.Descending)
            //    {
            //        dataSourceVo = dataSourceVo.OrderByDescending(t => t.GetType().GetProperty(column.DataPropertyName).GetValue(t)).ToList();
            //    }

            //    BindDataSource(dataSourceVo);
            //    LineItem_dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = sortDirection;
            //}
        }

        private void LineItem_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (LineItem_dgv.SelectedCells.Count > 0)
            {
                Update_btn.Enabled = Update_btn.Enabled = true;
            }
            else
            {
                Update_btn.Enabled = Update_btn.Enabled = false;
            }
        }

        /// <summary>
        /// updates Line Machine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_btn_Click(object sender, EventArgs e)
        {
            if (LineItem_dgv.RowCount == 0) // || LineItem_dgv.SelectedRows.Count == 0
            { return; }

            if (Line_cmb.Text == string.Empty || Line_cmb.SelectedIndex < 0)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, LineId_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                Line_cmb.Focus();
                return;
            }

            ValueObjectList<ValueObject> inVoList = new ValueObjectList<ValueObject>();

            LineItemCycleTimeVo deleteInVo = new LineItemCycleTimeVo();
            deleteInVo.LineId = Convert.ToInt32(Line_cmb.SelectedValue);

            ValueObjectList<LineItemCycleTimeVo> addInVo = new ValueObjectList<LineItemCycleTimeVo>();

            foreach (DataGridViewRow row in LineItem_dgv.Rows)
            {
                if (row.Cells["clmstdcycletime"].Value != null && !row.Cells["clmstdcycletime"].Value.ToString().Equals(string.Empty))
                {
                    decimal cycleTime = Convert.ToDecimal(row.Cells["clmstdcycletime"].Value);
                    if (cycleTime > 0)
                    {
                        LineItemCycleTimeVo selectedItem = (LineItemCycleTimeVo)row.DataBoundItem;

                        LineItemCycleTimeVo addVo = new LineItemCycleTimeVo();
                        addVo.LineId = Convert.ToInt32(Line_cmb.SelectedValue);
                        addVo.StdCycleTime = cycleTime;
                        addVo.SapItemCode = row.Cells["colSapItemCode"].Value.ToString();

                        addInVo.add(addVo);
                    }
                }
            }

            inVoList.add(deleteInVo);
            inVoList.add(addInVo);
            //if (inVo == null || inVo.GetList() == null || inVo.GetList().Count == 0)
            //{
            //    messageData = new MessageData("mmci00047", Properties.Resources.mmci00047, LineId_lbl.Text);
            //    popUpMessage.Information(messageData, Text);
            //    LineItem_dgv.Focus();
            //    return;
            //}

            UpdateResultVo outVo = null;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                outVo = (UpdateResultVo)base.InvokeCbm(new AddUpdateLineItemCycleTimeMasterMntCbm(), inVoList, false);
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
        /// Item code search click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemSearch_btn_Click(object sender, EventArgs e)
        {
            ItemCodeSearchForm frm = new ItemCodeSearchForm();
            frm.ShowDialog();

            if (frm.sapItemSearchVo != null && frm.sapItemSearchVo.GetList() != null && frm.sapItemSearchVo.GetList().Count > 0)
            {
                ValueObjectList<SapItemSearchVo> sapItemSearchVo = frm.sapItemSearchVo;

                sapItemSearchVo.GetList().ForEach(v => v.SapItemName = v.SapItemCode + " - " + v.SapItemName);

                ValueObjectList<LineItemCycleTimeVo> sapItemVo = new ValueObjectList<LineItemCycleTimeVo>();

                foreach (SapItemSearchVo itmVo in sapItemSearchVo.GetList())
                {
                    LineItemCycleTimeVo sapItmVo = new LineItemCycleTimeVo();
                    sapItmVo.SapItemCode = itmVo.SapItemCode;
                    sapItemVo.add(sapItmVo);
                }

                ValueObjectList<LineItemCycleTimeVo> grdCycleVo = new ValueObjectList<LineItemCycleTimeVo>();
                ValueObjectList<LineItemCycleTimeVo> itmCycleVo = new ValueObjectList<LineItemCycleTimeVo>();

                if ((List<LineItemCycleTimeVo>)LineItem_dgv.DataSource != null)
                {
                    itmCycleVo.SetNewList((List<LineItemCycleTimeVo>)LineItem_dgv.DataSource);
                }

                if (itmCycleVo != null && itmCycleVo.GetList() != null && itmCycleVo.GetList().Count > 0)
                {
                    List<string> sapitemlist = itmCycleVo.GetList().Select(v => v.SapItemCode).ToList();

                    List<LineItemCycleTimeVo> selectedItem = sapItemVo.GetList().Where(x => !sapitemlist.Contains(x.SapItemCode)).ToList();

                    itmCycleVo.GetList().AddRange(selectedItem);
                }
                else
                {
                    itmCycleVo.GetList().AddRange(sapItemVo.GetList());
                }


                grdCycleVo.SetNewList(itmCycleVo.GetList().Where(x => !String.IsNullOrWhiteSpace(x.SapItemCode))
                                   .Select(x => new LineItemCycleTimeVo { SapItemCode = x.SapItemCode, StdCycleTimeNull = x.StdCycleTimeNull })
                                   .GroupBy(x => x.SapItemCode).Select(x => x.FirstOrDefault()).Distinct().ToList());

                LineItem_dgv.AutoGenerateColumns = false;
                LineItem_dgv.DataSource = null;
                LineItem_dgv.DataSource = grdCycleVo.GetList();
                LineItem_dgv.ClearSelection();

                ValueObjectList<LineItemCycleTimeVo> cmbCycleVo = new ValueObjectList<LineItemCycleTimeVo>();

                if ((List<LineItemCycleTimeVo>)LineItem_dgv.DataSource != null)
                {
                    cmbCycleVo.SetNewList((List<LineItemCycleTimeVo>)LineItem_dgv.DataSource);
                    if ((List<LineItemCycleTimeVo>)SapItem_cmb.DataSource != null)
                    {
                        cmbCycleVo.GetList().AddRange((List<LineItemCycleTimeVo>)SapItem_cmb.DataSource);
                    }
                }

                SapItem_cmb.DataSource = null;
                SapItem_cmb.DisplayMember = "SapItemCode";
                SapItem_cmb.ValueMember = "SapItemCode";
                SapItem_cmb.DataSource = cmbCycleVo.GetList().Where(x => !String.IsNullOrWhiteSpace(x.SapItemCode))
                                                    .Select(x => new LineItemCycleTimeVo { SapItemCode = x.SapItemCode, StdCycleTimeNull = x.StdCycleTimeNull })
                                                    .GroupBy(x => x.SapItemCode).Select(x => x.FirstOrDefault()).Distinct().ToList();
                SapItem_cmb.SelectedIndex = -1;
            }
        }

        private void Line_cmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LineItem_dgv.DataSource = null;
            SapItem_cmb.DataSource = null;
            SapItem_cmb.Text = string.Empty;
        }
    }
}
