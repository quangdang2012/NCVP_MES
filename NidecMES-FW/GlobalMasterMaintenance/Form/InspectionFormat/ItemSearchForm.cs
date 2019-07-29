using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class ItemSearchForm
    {
        #region Variables

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(ItemSearchForm));

        /// <summary>
        ///  get message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        ///  get value from current grid row selection
        /// </summary>
        public SapItemSearchVo sapItemSearchVo = null;

        #endregion

        #region Constructor

        /// <summary>
        /// constructor of the form
        /// </summary>
        public ItemSearchForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(SapItemSearchVo conditionInVo)
        {
            Item_dgv.DataSource = null;

            try
            {
                ValueObjectList<SapItemSearchVo> outVo = (ValueObjectList<SapItemSearchVo>)base.InvokeCbm(new GetSapItemSearchCbm(), conditionInVo, false);

                Item_dgv.AutoGenerateColumns = false;

                if(outVo != null && outVo.GetList() != null && outVo.GetList().Count > 0)
                {
                    BindingSource buildingSource = new BindingSource(outVo.GetList(), null);
                    Item_dgv.DataSource = buildingSource;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null); 
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }
                Item_dgv.ClearSelection();

                Ok_btn.Enabled = false;
                
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
        private SapItemSearchVo FormConditionVo()
        {
            SapItemSearchVo inVo = new SapItemSearchVo();

            if (ItemCode_txt.Text != string.Empty) { inVo.SapItemCode = ItemCode_txt.Text; }

            if (ItemName_txt.Text != string.Empty) { inVo.SapItemName = ItemName_txt.Text; }
            
            return inVo;

        }
        
        #endregion

        #region FormEvents

        /// <summary>
        /// Loads Mold form
        /// Fill item combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemSearchForm_Load(object sender, EventArgs e)
        {          
            ItemCode_txt.Select();
            Ok_btn.Enabled = false;
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

            if (ItemCode_txt.Text.Trim() == string.Empty && ItemName_txt.Text.Trim() == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, ItemCode_lbl.Text + " or " + ItemName_lbl.Text);
                popUpMessage.Information(messageData, Text);
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            GridBind(FormConditionVo());

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Selected the record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_btn_Click(object sender, EventArgs e)
        {
            sapItemSearchVo = (SapItemSearchVo)Item_dgv.Rows[Item_dgv.CurrentCell.RowIndex].DataBoundItem;
            this.Close();
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
        /// Handles user record selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Item_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Item_dgv.SelectedRows.Count > 0)
            {
                Ok_btn.Enabled = true;
            }
            else
            {
                Ok_btn.Enabled = false;
            }
        }

        private void Item_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            sapItemSearchVo = (SapItemSearchVo)Item_dgv.Rows[Item_dgv.CurrentCell.RowIndex].DataBoundItem;
            this.Close();
        }

        #endregion

    }
}
