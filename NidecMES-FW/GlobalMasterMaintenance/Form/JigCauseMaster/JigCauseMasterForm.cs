using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class JigCauseMasterForm : FormCommonNCVP
    {
        public JigCauseMasterForm()
        {
            InitializeComponent();
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            JigCauseCode_txt.Text = string.Empty;

            JigCauseName_txt.Text = string.Empty;

            JigCause_dgv.DataSource = null;

            JigCauseCode_txt.Select();
        }
        private void GridBind()
        {
            JigCause_dgv.DataSource = null;

            try
            {
                JigCauseVo v = new Vo.JigCauseVo
                {
                    JigCauseCode = JigCauseCode_txt.Text,
                    JigCauseName = JigCauseName_txt.Text
                };
                ValueObjectList<JigCauseVo> volist = (ValueObjectList<JigCauseVo>)DefaultCbmInvoker.Invoke(new GetJigCauseCbm(), v);
                if (volist.GetList() != null && volist.GetList().Count > 0)
                {
                    JigCause_dgv.AutoGenerateColumns = false;
                    BindingSource bindingSource1 = new BindingSource(volist.GetList(), null);
                    JigCause_dgv.DataSource = bindingSource1;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }
                JigCause_dgv.ClearSelection();

                Update_btn.Enabled = false;

                Delete_btn.Enabled = false;
            }
            catch (Com.Nidec.Mes.Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }
        private void Add_btn_Click(object sender, EventArgs e)
        {
            AddJigCauseMasterForm newAddForm = new AddJigCauseMasterForm();
            newAddForm.vo = new JigCauseVo();
            if (newAddForm.ShowDialog() == DialogResult.OK)
            {
                GridBind();
            }
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            if (JigCause_dgv.SelectedRows.Count > 0)
            {
                BindUpdateCavityData();
            }
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            if (JigCause_dgv.SelectedRows.Count > 0)
            {
                int selectedrowindex = JigCause_dgv.SelectedCells[0].RowIndex;

                JigCauseVo vo = (JigCauseVo)JigCause_dgv.Rows[selectedrowindex].DataBoundItem;

                messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, vo.JigCauseCode);
                logger.Info(messageData);
                DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);


                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        JigCauseVo outVo = (JigCauseVo)DefaultCbmInvoker.Invoke(new DeleteJigCauseCbm(), vo);

                        if (outVo.AffectedCount > 0)
                        {
                            messageData = new MessageData("mmci00003", Properties.Resources.mmci00003, null);
                            logger.Info(messageData);
                            popUpMessage.Information(messageData, Text);

                            GridBind();
                        }
                        else if (outVo.AffectedCount == 0)
                        {
                            messageData = new MessageData("mmci00007", Properties.Resources.mmci00007, null);
                            logger.Info(messageData);
                            popUpMessage.Information(messageData, Text);
                            GridBind();
                        }
                    }
                    catch (Com.Nidec.Mes.Framework.ApplicationException exception)
                    {
                        popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                        logger.Error(exception.GetMessageData());
                    }
                }
            }
        }

        private void Search_btn_Click(object sender, EventArgs e)
        {
            GridBind();
        }

        private void JigCause_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Update_btn.Enabled = Delete_btn.Enabled = JigCause_dgv.SelectedRows.Count > 0;
        }

        private void JigCause_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        /// <summary>
        /// selects user record for updation and show user form
        /// </summary>
        private void BindUpdateCavityData()
        {
            int selectedrowindex = JigCause_dgv.SelectedCells[0].RowIndex;

            JigCauseVo vo = (JigCauseVo)JigCause_dgv.Rows[selectedrowindex].DataBoundItem;

            AddJigCauseMasterForm addform = new AddJigCauseMasterForm();
            addform.vo = vo;

            if (addform.IntSuccess >0)
            {
                messageData = new MessageData("mmci00002", Properties.Resources.mmci00002, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);

                GridBind();
            }
            else if (addform.IntSuccess == 0)
            {
                messageData = new MessageData("mmci00007", Properties.Resources.mmci00007, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                GridBind();
            }
        }
    }
}
