using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Collections.Generic;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class ItemProcessWorkForm
    {

        #region Variables

        /// <summary>
        /// datatable for item data
        /// </summary>
        private DataTable processFlowRuleDatatable;

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
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(ItemProcessWorkForm));

        /// <summary>
        ///  get message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        /// Up button operation
        /// </summary>
        public const string UP = "UP";

        /// <summary>
        /// Down button operation
        /// </summary>
        private const string DOWN = "DOWN";

        /// <summary>
        /// comment column in the datagridview
        /// </summary>
        private const string COMMENT = "colComment";

        #endregion

        #region Constructor

        /// <summary>
        /// constructor of the form
        /// </summary>
        public ItemProcessWorkForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(ItemProcessWorkVo conditionInVo)
        {
            ItemProcessWork_dgv.DataSource = null;

            try
            {
                ItemProcessWorkVo outVo = (ItemProcessWorkVo)base.InvokeCbm(new GetItemProcessWorkMasterMntCbm(), conditionInVo, false);

                ItemProcessWork_dgv.AutoGenerateColumns = false;

                BindingSource bindingSource1 = new BindingSource(outVo.ItemProcessWorkListVo, null);

                DataGridViewComboBoxColumn ComboColumn = (DataGridViewComboBoxColumn)(ItemProcessWork_dgv.Columns["colComment"]);
                ComboColumn.DataSource = processFlowRuleDatatable;
                ComboColumn.DisplayMember = "Comment";
                ComboColumn.Selected = false;

                if (bindingSource1.Count > 0)
                {
                    ItemProcessWork_dgv.DataSource = bindingSource1;

                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null); //item process work
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);

                }

                ItemProcessWork_dgv.ClearSelection();


                ProcessWorkVo processWOutVo = (ProcessWorkVo)base.InvokeCbm(new GetProcessWorkMasterMntCbm(), new ProcessWorkVo(), false);

                outVo.ItemProcessWorkListVo.ForEach(t => t.OptionalProcessFlag = t.OptionalProcessFlag.Equals("1") ? "True" : "False");
                outVo.ItemProcessWorkListVo.ForEach(t => t.SkipPreventionFlag = t.SkipPreventionFlag.Equals("1") ? "True" : "False");

                List<ProcessWorkVo> exceptionList = outVo.ItemProcessWorkListVo.Select(e => new

                ProcessWorkVo
                {
                    ProcessWorkId = e.ProcessWorkId
                }
                ).ToList();

                List<ProcessWorkVo> procesWorkList = processWOutVo.ProcessWorkListVo;//.Where(p => !exceptionList.Any(p2 => p2.ProcessWorkId == p.ProcessWorkId)).ToList();

                ProcessWork_dgv.AutoGenerateColumns = false;

                BindingSource bindingSource2 = new BindingSource(procesWorkList, null);

                ProcessWork_dgv.DataSource = bindingSource2;

                ProcessWork_dgv.ClearSelection();

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
        private ItemProcessWorkVo FormConditionVo()
        {
            ItemProcessWorkVo inVo = new ItemProcessWorkVo();

            if (ItemCd_cmb.SelectedIndex > -1)
            {
                inVo.ItemId = Convert.ToInt32(ItemCd_cmb.SelectedValue);
            }

            //if (ProcessFlowRule_cmb.SelectedIndex > -1)
            //{
            //    inVo.ProcessFlowRuleId = Convert.ToInt32(ProcessFlowRule_cmb.SelectedValue);
            //}

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
        /// form country and factory data for combo
        /// </summary>
        private void FormDatatableFromVo()
        {
            itemDatatable = new DataTable();
            itemDatatable.Columns.Add("id");
            itemDatatable.Columns.Add("code");

            processFlowRuleDatatable = new DataTable();
            processFlowRuleDatatable.Columns.Add("ProcessFlowRuleId", typeof(string));
            processFlowRuleDatatable.Columns.Add("Comment", typeof(string));

            try
            {
                ItemVo ItemOutVo = (ItemVo)base.InvokeCbm(new GetItemMasterMntCbm(), new ItemVo(), false);

                foreach (ItemVo it in ItemOutVo.ItemListVo)
                {
                    itemDatatable.Rows.Add(it.ItemId, it.ItemCode + " - " + it.ItemName);
                }

                ProcessFlowRuleVo proceesFlowRuleVo = (ProcessFlowRuleVo)base.InvokeCbm(new GetProcessFlowRuleMasterMntCbm(), new ProcessFlowRuleVo(), false);

                foreach (ProcessFlowRuleVo pf in proceesFlowRuleVo.ProcessFlowRuleListVo)
                {
                    processFlowRuleDatatable.Rows.Add(pf.ProcessFlowRuleId, pf.Comment);
                }

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

            if (ItemCd_cmb.Text == string.Empty || ItemCd_cmb.SelectedIndex < 0)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, ItemCd_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                ItemCd_cmb.Focus();

                return false;
            }

            //foreach (DataGridViewRow row in ItemProcessWork_dgv.Rows)
            //{
            //    if (row.Cells["colComment"].Value == null || row.Cells["colComment"].Value.ToString() == string.Empty)
            //    {
            //        messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, row.Cells["colComment"].OwningColumn.HeaderText);
            //        popUpMessage.Warning(messageData, Text);

            //        ItemProcessWork_dgv.CurrentCell = row.Cells["colComment"];

            //        return false;
            //    }
            //}

            return true;
        }

        /// <summary>
        /// moves grid contects up / down
        /// </summary>
        /// <param name="operationType"></param>
        private void MoveGridContentsUp()
        {
            BindingSource bs = new BindingSource();
            bs = (BindingSource)ItemProcessWork_dgv.DataSource;

            int selectedIndex = ItemProcessWork_dgv.SelectedRows[0].Index;

            ItemProcessWorkVo itemPWVo = (ItemProcessWorkVo)ItemProcessWork_dgv.SelectedRows[0].DataBoundItem;

            int selectedrowindex = ItemProcessWork_dgv.SelectedCells[0].RowIndex;

            ItemProcessWorkVo prevItemPWVo = null;
            if (selectedrowindex > 0)
            {
                prevItemPWVo = (ItemProcessWorkVo)ItemProcessWork_dgv.Rows[selectedrowindex - 1].DataBoundItem;
            }

            if (prevItemPWVo != null && (prevItemPWVo.ProcessWorkId == itemPWVo.ProcessWorkId && prevItemPWVo.ProcessWorkSeq < itemPWVo.ProcessWorkSeq))
            {
                messageData = new MessageData("mmce00014", Properties.Resources.mmce00014);
                popUpMessage.ApplicationError(messageData, Text);

                return;
            }

            ((List<ItemProcessWorkVo>)(bs.DataSource)).Remove(itemPWVo);
            ((List<ItemProcessWorkVo>)(bs.DataSource)).Insert(selectedIndex - 1, itemPWVo);

            ItemProcessWork_dgv.DataSource = null;
            ItemProcessWork_dgv.DataSource = bs;
            ItemProcessWork_dgv.Rows[selectedIndex - 1].Selected = true;

        }

        /// <summary>
        /// moves grid contects up / down
        /// </summary>
        /// <param name="operationType"></param>
        private void MoveGridContentsDown()
        {
            BindingSource bs = new BindingSource();
            bs = (BindingSource)ItemProcessWork_dgv.DataSource;

            int selectedIndex = ItemProcessWork_dgv.SelectedRows[0].Index;

            ItemProcessWorkVo itemPWVo = (ItemProcessWorkVo)ItemProcessWork_dgv.SelectedRows[0].DataBoundItem;

            int selectedrowindex = ItemProcessWork_dgv.SelectedCells[0].RowIndex;

            ItemProcessWorkVo nextItemPWVo = null;
            if (ItemProcessWork_dgv.Rows.Count > selectedrowindex)
            {
                nextItemPWVo = (ItemProcessWorkVo)ItemProcessWork_dgv.Rows[selectedrowindex + 1].DataBoundItem;
            }
            if (nextItemPWVo != null && (nextItemPWVo.ProcessWorkId == itemPWVo.ProcessWorkId && nextItemPWVo.ProcessWorkSeq > itemPWVo.ProcessWorkSeq))
            {
                messageData = new MessageData("mmce00015", Properties.Resources.mmce00015);
                popUpMessage.ApplicationError(messageData, Text);

                return;
            }

            ((List<ItemProcessWorkVo>)(bs.DataSource)).Remove(itemPWVo);
            ((List<ItemProcessWorkVo>)(bs.DataSource)).Insert(selectedIndex + 1, itemPWVo);

            ItemProcessWork_dgv.DataSource = null;
            ItemProcessWork_dgv.DataSource = bs;
            ItemProcessWork_dgv.Rows[selectedIndex + 1].Selected = true;

        }

        #endregion

        #region FormEvents
        /// <summary>
        /// Loads Mold form
        /// Fill item combobox
        /// </summary>s
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemProcessWorkForm_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            FormDatatableFromVo();

            ComboBind(ItemCd_cmb, itemDatatable, "code", "id");

            ItemCd_cmb.Select();
            Update_btn.Enabled = false;

            this.Cursor = Cursors.Default;
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
            ItemCd_cmb.SelectedIndex = -1;

            ItemProcessWork_dgv.DataSource = null;

            ProcessWork_dgv.DataSource = null;

            ItemCd_cmb.Enabled = true;
            Search_btn.Enabled = true;
            Update_btn.Enabled = false;

        }

        /// <summary>
        /// event to get the record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_btn_Click(object sender, EventArgs e)
        {

            if (ItemCd_cmb.Text == string.Empty || ItemCd_cmb.SelectedIndex < 0)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, ItemCd_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                ItemCd_cmb.Focus();

                return;
            }

            this.Cursor = Cursors.WaitCursor;

            GridBind(FormConditionVo());
            Update_btn.Enabled = true;
            ItemCd_cmb.Enabled = false;
            Search_btn.Enabled = false;

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// event to open the  updatescreen 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_btn_Click(object sender, EventArgs e)
        {
            try
            {
                ItemProcessWorkVo outVo;
                if (CheckMandatory())
                {
                    this.Cursor = Cursors.WaitCursor;

                    ItemProcessWorkVo deleteVo = new ItemProcessWorkVo
                    {
                        ItemId = Convert.ToInt32(ItemCd_cmb.SelectedValue.ToString()),
                        //ProcessFlowRuleId = Convert.ToInt32(ProcessFlowRule_cmb.SelectedValue.ToString())
                    };

                    outVo = (ItemProcessWorkVo)base.InvokeCbm(new DeleteItemProcessWorkMasterMntCbm(), deleteVo, false);

                    if (ItemProcessWork_dgv.RowCount > 0)
                    {
                        foreach (DataGridViewRow row in ItemProcessWork_dgv.Rows)
                        {
                            ItemProcessWorkVo seldata = (ItemProcessWorkVo)row.DataBoundItem;
                            outVo = new ItemProcessWorkVo();

                            ItemProcessWorkVo inVo = new ItemProcessWorkVo();

                            inVo.ItemProcessWorkId = seldata.ItemProcessWorkId; // Convert.ToInt32(row.Cells["colItemProcessWorkId"].Value);
                            inVo.ItemId = seldata.ItemId; //  Convert.ToInt32(row.Cells["colItemId"].Value.ToString());
                            inVo.ProcessWorkId = seldata.ProcessWorkId; //  Convert.ToInt32(row.Cells["colProcessWorkId"].Value.ToString());
                            inVo.ProcessWorkSeq = seldata.ProcessWorkSeq; // 
                            inVo.OptionalProcessFlag = row.Cells["colIsOptionalProcess"].Value != null && row.Cells["colIsOptionalProcess"].Value.ToString() == "True" ? "1" : "0";
                            inVo.SkipPreventionFlag = row.Cells["colIsSkip"].Value != null && row.Cells["colIsSkip"].Value.ToString() == "True" ? "1" : "0";
                            inVo.WorkOrder = row.Index + 1;
                            inVo.ProcessFlowRuleId = row.Cells["colComment"].Value != null && row.Cells["colComment"].Value.ToString() != "" ? Convert.ToInt32(processFlowRuleDatatable.Select("Comment = '" + row.Cells["colComment"].Value.ToString() + "'")[0][0].ToString()) : Convert.ToInt32(null);

                            outVo = (ItemProcessWorkVo)base.InvokeCbm(new AddItemProcessWorkMasterMntCbm(), inVo, false);
                        }
                    }

                    messageData = new MessageData("mmci00002", Properties.Resources.mmci00002, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                    GridBind(FormConditionVo());

                    this.Cursor = Cursors.Default;
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
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

        /// <summary>
        /// Add item to gridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddProcessWork_btn_Click(object sender, EventArgs e)
        {
            if (this.ProcessWork_dgv.SelectedRows.Count == 0)
            {
                return;
            }
            if (ItemCd_cmb.Text == string.Empty || ItemCd_cmb.SelectedIndex < 0)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, ItemCd_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                ItemCd_cmb.Focus();

                return;
            }

            BindingSource bs;
            bs = (BindingSource)ItemProcessWork_dgv.DataSource;
            int processworkseq = 0;
            if (bs !=null)
            {
                List<ItemProcessWorkVo> binddata = (List<ItemProcessWorkVo>)bs.DataSource;
                ItemProcessWorkVo getitemprocess = binddata.Where(x => x.ProcessWorkId == Convert.ToInt32(ProcessWork_dgv.SelectedRows[0].Cells["colProcWorkId"].Value)).LastOrDefault();
                if (getitemprocess != null)
                {
                    processworkseq = getitemprocess.ProcessWorkSeq + 1;
                }
            }


            ItemProcessWorkVo itemprcvo = new ItemProcessWorkVo();
            itemprcvo.ItemProcessWorkId = 0;
            itemprcvo.ProcessWorkId = Convert.ToInt32(ProcessWork_dgv.SelectedRows[0].Cells["colProcWorkId"].Value);
            itemprcvo.ProcessWorkName = ProcessWork_dgv.SelectedRows[0].Cells["colProcessWork"].Value.ToString();
            itemprcvo.ProcessWorkSeq = processworkseq;
            itemprcvo.OptionalProcessFlag = "false";
            itemprcvo.SkipPreventionFlag = "false";
            //itemprcvo.Comment = ProcessFlowRule_cmb.Text;
            //itemprcvo.ProcessFlowRuleId = Convert.ToInt32(ProcessFlowRule_cmb.SelectedValue);
            itemprcvo.ItemId = Convert.ToInt32(ItemCd_cmb.SelectedValue.ToString());

            if (bs != null)
            {
                ((List<ItemProcessWorkVo>)(bs.DataSource)).Add(itemprcvo);
            }
            else
            {
                List<ItemProcessWorkVo> ItemProcessWorkList = new List<ItemProcessWorkVo>();
                ItemProcessWorkList.Add(itemprcvo);
                bs = new BindingSource(ItemProcessWorkList, null);
            }

            ItemProcessWork_dgv.DataSource = null;

            ItemProcessWork_dgv.DataSource = bs;

            //ProcessWork_dgv.Rows.RemoveAt(ProcessWork_dgv.SelectedRows[0].Index);

        }

        /// <summary>
        /// Remove item from gridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveProcessWork_btn_Click(object sender, EventArgs e)
        {
            if (this.ItemProcessWork_dgv.SelectedRows.Count > 0)
            {
                BindingSource bs = new BindingSource();
                bs = (BindingSource)ProcessWork_dgv.DataSource;

                ProcessWorkVo prcvo = new ProcessWorkVo
                {
                    ProcessWorkId = Convert.ToInt32(ItemProcessWork_dgv.SelectedRows[0].Cells["colProcessWorkId"].Value),
                    ProcessWorkName = ItemProcessWork_dgv.SelectedRows[0].Cells["colProcessWorkName"].Value.ToString()
                };

                ((List<ProcessWorkVo>)(bs.DataSource)).Add(prcvo);

                ProcessWork_dgv.DataSource = null;

                ProcessWork_dgv.DataSource = bs;

                ItemProcessWork_dgv.Rows.RemoveAt(ItemProcessWork_dgv.SelectedRows[0].Index);
            }
        }

        /// <summary>
        /// move process work to up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Up_btn_Click(object sender, EventArgs e)
        {
            if (ItemProcessWork_dgv.SelectedRows.Count > 0 &&
                ItemProcessWork_dgv.SelectedRows[0].Index != 0)
            {
                MoveGridContentsUp();
            }

        }

        /// <summary>
        /// move process work to down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Down_btn_Click(object sender, EventArgs e)
        {
            if (ItemProcessWork_dgv.SelectedRows.Count > 0 &&
                ItemProcessWork_dgv.SelectedRows[0].Index < ItemProcessWork_dgv.RowCount - 1)
            {
                MoveGridContentsDown();
            }

        }
        #endregion

        #region ControlEvents

        /// <summary>
        /// inserts combo item to processflowrule cell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemProcessWork_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && ItemProcessWork_dgv.Columns[e.ColumnIndex].Name.Equals(COMMENT))
            {
                DataGridViewComboBoxColumn ComboColumn = (DataGridViewComboBoxColumn)(ItemProcessWork_dgv.Columns["colComment"]);
                ComboColumn.Selected = false;

                if (ComboColumn.DataSource == null)
                {
                    ComboColumn.DataSource = processFlowRuleDatatable;
                    ComboColumn.DisplayMember = "Comment";
                }

            }
        }

        #endregion
    }
}
