using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using System.Resources;
using System.Collections.Generic;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddLineRestTimeForm
    {

        #region Variables
        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly LineVo updateData;

        /// <summary>
        /// Check for Database operation success
        /// </summary>
        public int IntSuccess = -1;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddFactoryMasterForm));

        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;

        private bool CheckBoxClicked = false;

        private bool GridCheckBoxClicked = false;
        #endregion

        #region Constructor
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="pmode"></param>
        /// <param name="LineItem"></param>
        public AddLineRestTimeForm(string pmode, LineVo LineItem = null)
        {
            InitializeComponent();

            mode = pmode;

            updateData = LineItem;
            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                this.Text = UpdateText_lbl.Text;
            }
        }
        #endregion

        #region PrivateMethods

        /// <summary>
        /// Checks mandatory fields
        /// </summary>
        /// <returns></returns>
        private bool CheckMandatory()
        {
            if (LineCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, LineCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                LineCode_txt.Focus();

                return false;
            }

            if (LineName_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, LineName_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                LineName_txt.Focus();

                return false;
            }

            return true;
        }

        /// <summary>
        /// For setting selected Line record into respective controls(textbox and combobox) for update operation
        /// passing selected Line data as parameter 
        /// </summary>
        /// <param name="dgvLine"></param>
        private void LoadLineData(LineVo dgvLine)
        {
            if (dgvLine != null)
            {
                this.LineCode_txt.Text = dgvLine.LineCode;
                this.LineName_txt.Text = dgvLine.LineName;
            }
        }

        /// <summary>
        /// checks duplicate FactoryCode
        /// </summary>
        /// <param name="lineVo"></param>
        /// <returns></returns>
        private LineVo DuplicateCheck(LineVo lineVo)
        {
            LineVo outVo = new LineVo();

            try
            {
                outVo = (LineVo)base.InvokeCbm(new CheckLineMasterMntCbm(), lineVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            return outVo;
        }

        #endregion

        #region FormEvent
        /// <summary>
        /// load screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddLineRestTimeForm_Load(object sender, EventArgs e)
        {
            LineCode_txt.Select();

            int lineCd = 0;

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadLineData(updateData);

                lineCd = updateData.LineId;

                LineCode_txt.Enabled = false;

                LineName_txt.Select();

            }

            LoadProcessWork(lineCd);
        }



        private void LoadProcessWork(int pLineId)
        {
            ProcessWorkVo outVo = null;

            try
            {
                outVo = (ProcessWorkVo)DefaultCbmInvoker.Invoke(new GetProcessWorkMasterMntCbm(), new ProcessWorkVo());

                outVo.ProcessWorkListVo.ForEach(t => t.ProcessWorkName = string.Concat(t.ProcessWorkCode + "  ", t.ProcessWorkName));
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            ProcessWorkLineVo processWorkLineInVo = new ProcessWorkLineVo();
            processWorkLineInVo.LineId = pLineId;

            ProcessWorkLineVo processWorkLineOutVo = (ProcessWorkLineVo)DefaultCbmInvoker.Invoke(new GetProcessWorkLineMasterMntCbm(), processWorkLineInVo);

            if (processWorkLineOutVo != null && pLineId > 0)
            {
                foreach (ProcessWorkVo item in outVo.ProcessWorkListVo)
                {
                    item.IsExists = processWorkLineOutVo.ProcessWorkLineListVo.Exists(t => t.ProcessWorkId == item.ProcessWorkId) ? "True" : "False";
                }
            }
            CheckAll_chk.Checked = !(outVo.ProcessWorkListVo.Exists(t => t.IsExists == "False"));
            BindingSource bindingSource = new BindingSource(outVo.ProcessWorkListVo, null);
            ProcessWork_dgv.AutoGenerateColumns = false;
            ProcessWork_dgv.DataSource = bindingSource;
        }
        #endregion

        #region ButtonClick
        /// <summary>
        /// update data to db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_btn_Click(object sender, EventArgs e)
        {

            LineVo inVo = new LineVo();

            if (CheckMandatory())
            {


                var sch = StringCheckHelper.GetInstance();

                if (!sch.IsASCII(LineCode_txt.Text))
                {
                    messageData = new MessageData("mmce00003", Properties.Resources.mmce00003);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);
                    LineCode_txt.Focus();
                    return;
                }

                inVo.LineCode = LineCode_txt.Text.Trim();
                inVo.LineName = LineName_txt.Text.Trim();
                //inVo.RegistrationDateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                inVo.RegistrationUserCode = UserData.GetUserData().UserCode;
                inVo.FactoryCode = UserData.GetUserData().FactoryCode;

                if (string.Equals(mode, CommonConstants.MODE_ADD))
                {
                    LineVo checkVo = DuplicateCheck(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, LineCode_lbl.Text + " : " + LineCode_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.ApplicationError(messageData, Text);

                        return;
                    }
                }

                ValueObjectList<ValueObject> inVoList = new ValueObjectList<ValueObject>();


                try
                {
                    this.StartProgress(Properties.Resources.mmci00009);

                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        inVoList.add(inVo);
                        inVoList.add(GetSelectedProcessWork());

                        LineVo outVo = (LineVo)base.InvokeCbm(new AddLineMasterAndProcessworkCbm(), inVoList, false);

                        IntSuccess = (outVo.LineId > 0) ? 1 : 0;

                    }
                    else if (string.Equals(mode, CommonConstants.MODE_UPDATE))
                    {
                        inVo.LineId = updateData.LineId;

                        inVoList.add(inVo);
                        inVoList.add(GetSelectedProcessWork());

                        LineVo outVo = (LineVo)base.InvokeCbm(new UpdateLineMasterAndProcessworkCbm(), inVoList, false);
                        IntSuccess = (outVo.AffectedCount > 0) ? 1 : 0;
                    }

                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                    return;
                }
                finally
                {
                    this.CompleteProgress();
                }



                if ((IntSuccess > 0) || (IntSuccess == 0))
                {
                    this.Close();
                }
            }
        }

        private ProcessWorkLineVo GetSelectedProcessWork()
        {
            BindingSource bsProcessWork = (BindingSource)ProcessWork_dgv.DataSource;
            ProcessWorkLineVo processWorkLineInVo = new ProcessWorkLineVo();

            if (bsProcessWork != null && bsProcessWork.List.Count > 0)
            {
                foreach (ProcessWorkVo processWorkVo in bsProcessWork.List)
                {
                    if (processWorkVo.IsExists == "True")
                    {
                        ProcessWorkLineVo addVo = new ProcessWorkLineVo()
                        {
                            ProcessWorkId = processWorkVo.ProcessWorkId
                        };
                        processWorkLineInVo.ProcessWorkLineListVo.Add(addVo);
                    }
                }
            }

            return processWorkLineInVo;
        }

        /// <summary>
        /// Window close when Exit button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_btn_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        /// <summary>
        /// Select and Deselect all Processwork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckAll_chk_CheckedChanged(object sender, EventArgs e)
        {
            if(GridCheckBoxClicked)
            {
                GridCheckBoxClicked = false;
                return;
            }

            CheckBoxClicked = true;

            foreach (DataGridViewRow Row in ProcessWork_dgv.Rows)
            {
                ((DataGridViewCheckBoxCell)Row.Cells["colSelect"]).Value = CheckAll_chk.Checked;
            }

            CheckBoxClicked = false;
        }

        private void ProcessWork_dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (ProcessWork_dgv.DataSource == null || e.ColumnIndex != 0 || CheckBoxClicked) return;
            //List<ProcessWorkVo> outVo = (List<ProcessWorkVo>)((BindingSource)ProcessWork_dgv.DataSource).DataSource;
            //CheckAll_chk.Checked = !(outVo.Exists(t => t.IsExists == "False"));
        }

        private void ProcessWork_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GridCheckBoxClicked = true;
            if (ProcessWork_dgv.Rows.Count > 0 && e.RowIndex > -1)
            {
                if ((ProcessWork_dgv.CurrentCell.Value != null) && !CheckBoxClicked)
                {
                    if (Convert.ToBoolean(ProcessWork_dgv.Rows[e.RowIndex].Cells["colSelect"].Value) == true)
                    {
                        ProcessWork_dgv.Rows[e.RowIndex].Cells["colSelect"].Value = false;
                    }
                    else
                    {
                       ProcessWork_dgv.Rows[e.RowIndex].Cells["colSelect"].Value = true;
                    }
                }             
                ProcessWork_dgv.EndEdit();
                List<ProcessWorkVo> outVo = (List<ProcessWorkVo>)((BindingSource)ProcessWork_dgv.DataSource).DataSource;
                CheckAll_chk.Checked = !(outVo.Exists(t => t.IsExists == "False"));

            }
        }

        private void ProcessWork_dgv_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (ProcessWork_dgv.CurrentCell is DataGridViewCheckBoxCell)
                ProcessWork_dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
}
