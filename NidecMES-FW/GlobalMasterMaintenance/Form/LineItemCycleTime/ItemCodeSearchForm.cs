using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class ItemCodeSearchForm : FormCommonMaster
    {

        #region Variables

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(ItemCodeSearchForm));

        /// <summary>
        ///  get message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        ///  get value from current grid row selection
        /// </summary>
        public ValueObjectList<SapItemSearchVo> sapItemSearchVo = null;

        #endregion

        #region Constructor

        public ItemCodeSearchForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind()
        {
            Item_dgv.DataSource = null;

            SapItemSearchVo inVo = new SapItemSearchVo();
            //List<SapItemSearchVo> outNewVo = null;

            if (!string.IsNullOrWhiteSpace(ItemCode_txt.Text)) { inVo.SapItemCode = ItemCode_txt.Text; }

            if (!string.IsNullOrWhiteSpace(ItemName_txt.Text)) { inVo.SapItemName = ItemName_txt.Text; }

            try
            {
                ValueObjectList<SapItemSearchVo> outVo = (ValueObjectList<SapItemSearchVo>)DefaultCbmInvoker.Invoke(new GetSapItemSearchCbm(), inVo);

                Item_dgv.AutoGenerateColumns = false;

                if (outVo == null || outVo.GetList() == null || outVo.GetList().Count == 0)
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                    return;
                }

                BindingSource buildingSource;

                //if (sapItemSearchVo != null && sapItemSearchVo.GetList() != null && sapItemSearchVo.GetList().Count > 0)
                //{
                //    outVo.GetList().AddRange(sapItemSearchVo.GetList());
                //    outNewVo = outVo.GetList().Where(x => !String.IsNullOrWhiteSpace(x.SapItemCode))
                //                   .Select(x => new SapItemSearchVo { SapItemCode = x.SapItemCode, SapItemName = x.SapItemName })
                //                   .GroupBy(x => x.SapItemCode).Select(x => x.FirstOrDefault()).Distinct().ToList();
                //   buildingSource = new BindingSource(outNewVo, null);
                //}
                //else
                //{
                //    buildingSource = new BindingSource(outVo.GetList(), null);
                //}

                buildingSource = new BindingSource(outVo.GetList(), null);

                Item_dgv.DataSource = buildingSource;

                Item_dgv.ClearSelection();

                if (sapItemSearchVo != null && sapItemSearchVo.GetList() != null && sapItemSearchVo.GetList().Count > 0)
                {
                    checkComboItems();
                }

             }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        /// <summary>
        /// To check / un check grid columns 
        /// </summary>
        /// <param name="is_checked"></param>
        private void grdCellChecked(bool is_checked = false)
        {
            foreach (DataGridViewRow row in Item_dgv.Rows)
            {
                if (row.Cells["colSelect"].ReadOnly == false)
                {
                    row.Cells["colSelect"].Value = is_checked;
                }
            }
        }

        /// <summary>
        ///  To check selected items
        /// </summary>
        private void checkComboItems()
        {
            foreach (DataGridViewRow row in Item_dgv.Rows)
            {
                if (row.Cells["colItemCode"].Value != null && sapItemSearchVo.GetList().Any(v => v.SapItemCode == row.Cells["colItemCode"].Value.ToString()))
                {
                    row.Cells["colSelect"].Value = true;
                }
            }
        }

        #endregion

        #region Button events

        /// <summary>
        /// Search button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_btn_Click(object sender, EventArgs e)
        {
            if (ItemCode_txt.Text.Trim() == string.Empty && ItemName_txt.Text.Trim() == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, ItemCode_lbl.Text + " or " + ItemName_lbl.Text);
                popUpMessage.Information(messageData, Text);
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            GridBind();

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// OK button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_btn_Click(object sender, EventArgs e)
        {
            if(Item_dgv.Rows.Count > 0)
            {
                sapItemSearchVo = null;
                foreach (DataGridViewRow row in Item_dgv.Rows)
                {
                    DataGridViewCheckBoxCell checkedItem = row.Cells[0] as DataGridViewCheckBoxCell;

                    if (Convert.ToBoolean(checkedItem.Value) == true)
                    {
                        if (sapItemSearchVo == null) { sapItemSearchVo = new ValueObjectList<SapItemSearchVo>(); }
                        sapItemSearchVo.add((SapItemSearchVo)row.DataBoundItem);
                    }
                }
                this.Close();
            }
            else
            {
                messageData = new MessageData("mmci00046", Properties.Resources.mmci00046, " Minimum one " + ItemCode_lbl.Text);
                popUpMessage.Information(messageData, Text);
            }
        }

        /// <summary>
        /// Exit button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Form events

        /// <summary>
        /// Form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemCodeSearchForm_Load(object sender, EventArgs e)
        {
            //if(sapItemSearchVo != null && sapItemSearchVo.GetList() != null && sapItemSearchVo.GetList().Count > 0)
            //{
            //    sapItemSearchVo.GetList().ForEach(v => v.SapItemName = v.SapItemName.Replace(v.SapItemCode + " - ", ""));

            //    Item_dgv.AutoGenerateColumns = false;

            //    BindingSource buildingSource = new BindingSource(sapItemSearchVo.GetList(), null);
            //    Item_dgv.DataSource = buildingSource;

            //    Item_dgv.ClearSelection();

            //    grdCellChecked(true);
            //}

            ItemCode_txt.Select();      
        }

        /// <summary>
        /// To check / un check grid columns
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllCheck_chk_CheckedChanged(object sender, EventArgs e)
        {
            grdCellChecked(AllCheck_chk.Checked);            
        }

        #endregion

    }
}
