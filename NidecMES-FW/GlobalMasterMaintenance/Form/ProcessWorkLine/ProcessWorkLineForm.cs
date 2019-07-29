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
    public partial class ProcessWorkLineForm
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
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddProcessForm));

        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;

        private bool isProcessListLoading = false;
        #endregion

        #region Constructor
        /// <summary>
        /// constructor for the form
        /// </summary>
        /// <param name="pmode"></param>
        /// <param name="dataItem"></param>
        public ProcessWorkLineForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods


        private void LoadProcessWorkListBox()
        {
            isProcessListLoading = true;
            ProcessWorkVo outPwVo = (ProcessWorkVo)DefaultCbmInvoker.Invoke(new GetProcessWorkMasterMntCbm(), new ProcessWorkVo());


            if (outPwVo.ProcessWorkListVo.Count > 0)
            {
                outPwVo.ProcessWorkListVo.ForEach(p => p.ProcessWorkName = p.ProcessWorkCode + " " + p.ProcessWorkName);

                ProcessWork_lst.DataSource = outPwVo.ProcessWorkListVo;
                ProcessWork_lst.DisplayMember = "ProcessWorkName";
                ProcessWork_lst.ValueMember = "ProcessWorkId";
                ProcessWork_lst.SelectedIndex = -1;
                isProcessListLoading = false;
                Update_btn.Enabled = true;
            }
            else
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, ProcessWork_lbl.Text);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                Update_btn.Enabled = false;

            }
        }


        private void LoadLineListBox()
        {

            LineVo outMVo = (LineVo)DefaultCbmInvoker.Invoke(new GetLineMasterMntCbm(), new LineVo());

            outMVo.LineListVo.ForEach(l => l.LineName = l.LineCode + " " + l.LineName);

            if (outMVo.LineListVo.Count > 0)
            {
                Line_chlst.DataSource = outMVo.LineListVo.OrderBy(o => o.LineCode).ToList();
                Line_chlst.DisplayMember = "LineName";
                Line_chlst.ValueMember = "LineId";
                Update_btn.Enabled = true;
            }
            else
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, Line_lbl.Text);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                Update_btn.Enabled = false;

            }

        }

        /// <summary>
        /// Checks mandatory fields
        /// </summary>
        /// <returns></returns>
        private bool CheckMandatory()
        {
            if (ProcessWork_lst.SelectedValue == null || ProcessWork_lst.SelectedValue.ToString() == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, ProcessWork_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                ProcessWork_lst.Focus();

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
            LoadProcessWorkListBox();

            ProcessWork_lst.ClearSelected();

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
            try
            {
                if (CheckMandatory())
                {
                    ProcessWorkLineVo inVo = new ProcessWorkLineVo();

                    inVo.ProcessWorkId = Convert.ToInt32(ProcessWork_lst.SelectedValue);

                    ProcessWorkLineVo outDeleteCheckVo = (ProcessWorkLineVo)base.InvokeCbm(new GetProcessWorkLineMasterMntCbm(), inVo, false);

                    if (outDeleteCheckVo.ProcessWorkLineListVo.Count > 0)
                    {
                        ProcessWorkLineVo outDeleteVo = (ProcessWorkLineVo)base.InvokeCbm(new DeleteProcessWorkLineMasterMntCbm(), inVo, false);
                        IntDelSuccess = outDeleteVo.AffectedCount;
                    }

                    ProcessWorkLineVo outVo = new ProcessWorkLineVo();

                    inVo.FactoryCode = UserData.GetUserData().FactoryCode;
                    inVo.RegistrationUserCode = UserData.GetUserData().UserCode;

                    foreach (var item in Line_chlst.CheckedItems)
                    {
                        var Line = (LineVo)item;
                        inVo.LineId = Line.LineId;

                        if (Properties.Settings.Default.LINE_PER_PROCESSWORK_CONSTRAINT)
                        {
                            ProcessWorkLineVo checkVo = DuplicateCheck(inVo);

                            if (checkVo != null && checkVo.AffectedCount > 0)
                            {
                                messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, Line_lbl.Text + " : " + Line_chlst.Text);
                                logger.Info(messageData);
                                popUpMessage.ApplicationError(messageData, Text);
                                return;
                            }
                        }

                        outVo = (ProcessWorkLineVo)base.InvokeCbm(new AddProcessWorkLineMasterMntCbm(), inVo, false);
                    }

                    IntSuccess = outVo.AffectedCount;

                    if ((IntSuccess > 0) || (IntDelSuccess > 0))
                    {
                        messageData = new MessageData("mmci00002", Properties.Resources.mmci00002, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                    }
                }

            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }

        }
        #endregion


        private void ProcessWork_lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isProcessListLoading) return;

            if (ProcessWork_lst.SelectedIndex < 0) { return; }

            if (Line_chlst.Items.Count == 0) { LoadLineListBox(); }

            this.Cursor = Cursors.WaitCursor;

            ProcessWorkLineVo inVo = new ProcessWorkLineVo();

            inVo.ProcessWorkId = Convert.ToInt32(ProcessWork_lst.SelectedValue.ToString());

            ProcessWorkLineVo checkVo = (ProcessWorkLineVo)base.InvokeCbm(new GetProcessWorkLineMasterMntCbm(), new ProcessWorkLineVo(), false);

            Line_chlst.ClearSelected();

            ProcessWorkLineVo outVo = (ProcessWorkLineVo)base.InvokeCbm(new GetProcessWorkLineMasterMntCbm(), inVo, false);

            for (int i = 0; i < Line_chlst.Items.Count; i++)
            {
                var Line = (LineVo)Line_chlst.Items[i];
                Line_chlst.SetItemChecked(i, outVo.ProcessWorkLineListVo.Exists(x => x.LineId == Line.LineId));
            }

            this.Cursor = Cursors.Default;
        }
    }
}
