using System;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using System.Resources;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Drawing;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class ProcessStockLocationForm
    {
        #region Variables

        /// <summary>
        /// Check for Database operation success
        /// </summary>
        public int IntSuccess = -1;
        public int IntDelSuccess = -1;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(ProcessStockLocationForm));

        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        /// 
        /// </summary>
        private bool isProcessListLoading = false;
        #endregion

        #region Constructor
        /// <summary>
        /// constructor for the form
        /// </summary>
        /// <param name="pmode"></param>
        /// <param name="dataItem"></param>
        public ProcessStockLocationForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods


        private void LoadProcessListBox()
        {
            isProcessListLoading = true;
            ProcessVo outPwVo = (ProcessVo)DefaultCbmInvoker.Invoke(new GetProcessMasterMntCbm(), new ProcessVo());


            if (outPwVo.ProcessListVo.Count > 0)
            {
                outPwVo.ProcessListVo.ForEach(p => p.ProcessName = p.ProcessCode + " " + p.ProcessName);

                Process_lst.DataSource = outPwVo.ProcessListVo;
                Process_lst.DisplayMember = "ProcessName";
                Process_lst.ValueMember = "ProcessId";
                Process_lst.SelectedIndex = -1;
                isProcessListLoading = false;
                Update_btn.Enabled = true;
            }
            else
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, Process_lbl.Text);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                Update_btn.Enabled = false;

            }
        }


        private void LoadStockLocationListBox()
        {

            ValueObjectList<StockLocationVo> outMVo = null;
            try
            {
                outMVo = (ValueObjectList<StockLocationVo>)DefaultCbmInvoker.Invoke(new GetStockLocationMasterMntCbm(), new StockLocationVo());
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }

            if (outMVo == null || outMVo.GetList() == null || outMVo.GetList().Count == 0)
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, StockLocation_lbl.Text);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                Update_btn.Enabled = false;
                return;
            }
            outMVo.GetList().ForEach(l => l.StockLocationName = l.StockLocationCode + " " + l.StockLocationName);

            StockLocation_chlst.DataSource = outMVo.GetList().OrderBy(o => o.StockLocationCode).ToList();
            StockLocation_chlst.DisplayMember = "StockLocationName";
            StockLocation_chlst.ValueMember = "StockLocationId";
            Update_btn.Enabled = true;


        }

        /// <summary>
        /// Checks mandatory fields
        /// </summary>
        /// <returns></returns>
        private bool CheckMandatory()
        {
            if (Process_lst.SelectedValue == null || Process_lst.SelectedValue.ToString() == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, Process_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                Process_lst.Focus();
                return false;
            }

            if (StockLocation_chlst.Items != null && StockLocation_chlst.Items.Count > 0 && StockLocation_chlst.CheckedItems.Count > 1)
            {
                messageData = new MessageData("mmce00016", Properties.Resources.mmce00016, Process_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                StockLocation_chlst.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// checks duplicate Process Code
        /// </summary>
        /// <param name="processVo"></param>
        /// <returns></returns>
        private ProcessWorkLineVo DuplicateCheck(ProcessWorkLineVo pwLineVo)
        {
            ProcessWorkLineVo outVo = new ProcessWorkLineVo();

            try
            {
                outVo = (ProcessWorkLineVo)base.InvokeCbm(new CheckProcessWorkLineMasterMntCbm(), pwLineVo, false);
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
        /// load the screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessWorkLineForm_Load(object sender, EventArgs e)
        {
            LoadProcessListBox();

            Process_lst.ClearSelected();

        }
        #endregion

        #region ButtonClick

        /// <summary>
        /// closes form on exit click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// inserts/updates process on ok click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_btn_Click(object sender, EventArgs e)
        {

            if (CheckMandatory())
            {
                ProcessStockLocationVo inVo = new ProcessStockLocationVo();
                inVo.ProcessId = Convert.ToInt32(Process_lst.SelectedValue);

                ValueObjectList<ProcessStockLocationVo> outDeleteCheckVo = null;
                try
                {
                    outDeleteCheckVo = (ValueObjectList<ProcessStockLocationVo>)base.InvokeCbm(new GetProcessStockLocationMasterMntCbm(), inVo, false);
                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                    return;
                }
                if (outDeleteCheckVo != null && outDeleteCheckVo.GetList() != null && outDeleteCheckVo.GetList().Count > 0)
                {
                    UpdateResultVo outDeleteVo = null;
                    try
                    {
                        outDeleteVo = (UpdateResultVo)base.InvokeCbm(new DeleteProcessStockLocationMasterMntCbm(), inVo, false);
                    }
                    catch (Framework.ApplicationException exception)
                    {
                        popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                        logger.Error(exception.GetMessageData());
                        return;
                    }
                    IntDelSuccess = outDeleteVo.AffectedCount;
                }

                foreach (var item in StockLocation_chlst.CheckedItems)
                {
                    var stocklocation = (StockLocationVo)item;
                    inVo.StockLocationId = stocklocation.StockLocationId;
                    UpdateResultVo outVo = null;
                    try
                    {
                        outVo = (UpdateResultVo)base.InvokeCbm(new AddProcessStockLocationMasterMntCbm(), inVo, false);
                    }
                    catch (Framework.ApplicationException exception)
                    {
                        popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                        logger.Error(exception.GetMessageData());
                        return;
                    }
                    IntSuccess = outVo.AffectedCount;
                }



                if ((IntSuccess > 0) || (IntDelSuccess > 0))
                {
                    messageData = new MessageData("mmci00002", Properties.Resources.mmci00002, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }
            }




        }
        #endregion

        #region ControlEvents
        private void Process_lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isProcessListLoading) return;

            if (Process_lst.SelectedIndex < 0) { return; }

            if (StockLocation_chlst.Items.Count == 0) { LoadStockLocationListBox(); }

            ProcessStockLocationVo inVo = new ProcessStockLocationVo();

            inVo.ProcessId = Convert.ToInt32(Process_lst.SelectedValue.ToString());

            // ValueObjectList<ProcessStockLocationVo> checkVo = (ProcessStockLocationVo)base.InvokeCbm(new GetProcessStockLocationMasterMntCbm(), new ProcessStockLocationVo(), false);

            StockLocation_chlst.ClearSelected();

            ValueObjectList<ProcessStockLocationVo> outVo = null;
            try
            {
                outVo = (ValueObjectList<ProcessStockLocationVo>)base.InvokeCbm(new GetProcessStockLocationMasterMntCbm(), inVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }


            for (int i = 0; i < StockLocation_chlst.Items.Count; i++)
            {
                var stocklocation = (StockLocationVo)StockLocation_chlst.Items[i];
                if (outVo == null || outVo.GetList() == null || outVo.GetList().Count == 0)
                {
                    StockLocation_chlst.SetItemChecked(i, false);
                }
                else
                {
                    StockLocation_chlst.SetItemChecked(i, outVo.GetList().Exists(x => x.StockLocationId == stocklocation.StockLocationId));
                }

            }
        }
        #endregion


    }
}
