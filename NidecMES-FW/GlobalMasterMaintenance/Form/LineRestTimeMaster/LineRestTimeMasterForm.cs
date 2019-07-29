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
    public partial class LineRestTimeMasterForm
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
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(LineRestTimeMasterForm));

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
        
        #endregion

        #region Constructor

        /// <summary>
        /// constructor of the form
        /// </summary>
        public LineRestTimeMasterForm()
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
        private LineRestTimeVo FormConditionVo()
        {
            LineRestTimeVo inVo = new LineRestTimeVo();

            inVo.LineId = Convert.ToInt32(Line_cmb.SelectedValue);
           
            return inVo;
        }

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(LineRestTimeVo conditionInVo)
        {
            LineRestTime_dgv.DataSource = null;
            ValueObjectList<LineRestTimeVo> loadVo = new ValueObjectList<LineRestTimeVo>();
            loadVo.SetNewList(getShiftTemplateVo().GetList());

            try
            {
                ValueObjectList<LineRestTimeVo> outVo = (ValueObjectList<LineRestTimeVo>)base.InvokeCbm(new GetLineRestTimeMasterMntCbm(), conditionInVo, false);

                LineRestTime_dgv.AutoGenerateColumns = false;

                if (outVo != null && outVo.GetList() != null && outVo.GetList().Count > 0)
                {
                    foreach(LineRestTimeVo lineRestVo in outVo.GetList())
                    {
                        if(lineRestVo.Shift == Convert.ToInt32(GlobalMasterDataTypeEnum.SHIFT_DAY.GetValue()))
                        {
                            foreach (LineRestTimeVo restVo in loadVo.GetList().Where(v => v.Shift == Convert.ToInt32(GlobalMasterDataTypeEnum.SHIFT_DAY.GetValue())))
                            {
                                restVo.LineRestTimeId = lineRestVo.LineRestTimeId;
                                restVo.LineId = lineRestVo.LineId;
                                restVo.PlanRestMinutes = lineRestVo.PlanRestMinutes;
                            }
                        }
                        else if (lineRestVo.Shift == Convert.ToInt32(GlobalMasterDataTypeEnum.SHIFT_NIGHT.GetValue()))
                        {
                            foreach (LineRestTimeVo restVo in loadVo.GetList().Where(v => v.Shift == Convert.ToInt32(GlobalMasterDataTypeEnum.SHIFT_NIGHT.GetValue())))
                            {
                                restVo.LineRestTimeId = lineRestVo.LineRestTimeId;
                                restVo.LineId = lineRestVo.LineId;
                                restVo.PlanRestMinutes = lineRestVo.PlanRestMinutes;
                            }
                        }
                    }
                }

                LineRestTime_dgv.DataSource = loadVo.GetList();
                
                LineRestTime_dgv.ClearSelection();

            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        /// <summary>
        /// Create Shift TemplateVo
        /// </summary>
        private ValueObjectList<LineRestTimeVo> getShiftTemplateVo()
        {
            LineRestTimeVo dayVo = new LineRestTimeVo();
            dayVo.Shift = Convert.ToInt32(GlobalMasterDataTypeEnum.SHIFT_DAY.GetValue());
            dayVo.ShiftText = GlobalMasterDataTypeEnum.SHIFT_DAY.ToString();

            LineRestTimeVo nightVo = new LineRestTimeVo();
            nightVo.Shift = Convert.ToInt32(GlobalMasterDataTypeEnum.SHIFT_NIGHT.GetValue());
            nightVo.ShiftText = GlobalMasterDataTypeEnum.SHIFT_NIGHT.ToString();

            ValueObjectList<Vo.LineRestTimeVo> shiftVo = new ValueObjectList<Vo.LineRestTimeVo>();
            shiftVo.add(dayVo);
            shiftVo.add(nightVo);
            return shiftVo;
        }

        #endregion

        #region FormEvents
        /// <summary>
        /// form loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LineRestTimeMasterForm_Load(object sender, EventArgs e)
        {
            LoadLine();

            Line_cmb.Select();

            Ok_btn.Enabled = false;
        }
        #endregion

        #region ButtonClick


        /// <summary>
        /// To save shift rest time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_btn_Click(object sender, EventArgs e)
        {
            if (LineRestTime_dgv.RowCount == 0)
            { return; }

            ValueObjectList<LineRestTimeVo> inVo = new ValueObjectList<LineRestTimeVo>();

            inVo.SetNewList((List<LineRestTimeVo>)LineRestTime_dgv.DataSource);

            foreach(LineRestTimeVo restVo in inVo.GetList())
            {
                restVo.LineId = Convert.ToInt32(Line_cmb.SelectedValue);
                if(restVo.PlanRestMinutes == null) { restVo.PlanRestMinutes = 0; }
            }
            
            UpdateResultVo outVo = null;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                outVo = (UpdateResultVo)base.InvokeCbm(new AddLineRestTimeCbm(), inVo, false);
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
            Clear_btn_Click(sender, e);
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
            LineRestTime_dgv.DataSource = null;
            Ok_btn.Enabled = false;
        }

        /// <summary>
        /// Search 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_btn_Click(object sender, EventArgs e)
        {
            if (Line_cmb.Text == string.Empty || Line_cmb.SelectedIndex < 0)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, LineId_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                Line_cmb.Select();
                return;
            }

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
        /// check numeric
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericText_TextChanged(object sender, EventArgs e)
        {
            if (LineRestTime_dgv.CurrentCell != null && LineRestTime_dgv.CurrentCell.OwningColumn.Name != "colPlanRestMinutes")
            {
                return;
            }

            TextBox consQty_Txt = (TextBox)sender;

            if (consQty_Txt.Text == string.Empty)
            {
                prvQtyInput = string.Empty;
            }

            if (!Regex.IsMatch(consQty_Txt.Text, @"^\d{0,12}(\d{0,2})?$"))
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

        /// <summary>
        /// Edit Control Showing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LineItem_dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ((TextBox)e.Control).KeyDown -= new KeyEventHandler(NumericText_KeyDown);
            ((TextBox)e.Control).TextChanged -= new EventHandler(NumericText_TextChanged);

            if (e.Control is TextBox && LineRestTime_dgv.CurrentCell.OwningColumn.Name == "colPlanRestMinutes")
            {
                ((TextBox)e.Control).KeyDown += new KeyEventHandler(NumericText_KeyDown);
                ((TextBox)e.Control).TextChanged += new EventHandler(NumericText_TextChanged);
            }
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

                if (!decimal.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                    e.Cancel = true;
                    messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, LineRestTime_dgv.Columns[e.ColumnIndex].HeaderText);
                    popUpMessage.Information(messageData, Text);
                    return;
                }
            }
        }

        /// <summary>
        /// Line grid cell click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LineItem_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (LineRestTime_dgv.SelectedCells.Count > 0)
            {
                Ok_btn.Enabled = Ok_btn .Enabled = true;
            }
            else
            {
                Ok_btn.Enabled = Ok_btn.Enabled = false;
            }
        }

        /// <summary>
        /// Selection Change Committed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Line_cmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //if (Line_cmb.Text == string.Empty || Line_cmb.SelectedIndex < 0)
            //{
            //    return;
            //}

            //GridBind(FormConditionVo());
        }

        #endregion        
    }
}
