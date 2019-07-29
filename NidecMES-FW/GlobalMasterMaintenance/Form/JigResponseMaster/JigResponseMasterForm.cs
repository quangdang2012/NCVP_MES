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
    public partial class JigResponseMasterForm : FormCommonNCVP
    {
        public JigResponseMasterForm()
        {
            InitializeComponent();
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            JigResponseCode_txt.Text = string.Empty;

            JigResponseName_txt.Text = string.Empty;

            JigResponse_dgv.DataSource = null;

            JigResponseCode_txt.Select();
        }
        private void GridBind()
        {
            JigResponse_dgv.DataSource = null;

            try
            {
                JigResponseVo v = new Vo.JigResponseVo
                {
                    JigResponseCode = JigResponseCode_txt.Text,
                    JigResponseName = JigResponseName_txt.Text
                };
                ValueObjectList<JigResponseVo> volist = (ValueObjectList<JigResponseVo>)DefaultCbmInvoker.Invoke(new GetJigResponseCbm(), v);
                if (volist.GetList() != null && volist.GetList().Count > 0)
                {
                    JigResponse_dgv.AutoGenerateColumns = false;
                    BindingSource bindingSource1 = new BindingSource(volist.GetList(), null);
                    JigResponse_dgv.DataSource = bindingSource1;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }
                JigResponse_dgv.ClearSelection();

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
            AddJigResponseMasterForm newAddForm = new AddJigResponseMasterForm();
            newAddForm.vo = new JigResponseVo();
            if (newAddForm.ShowDialog() == DialogResult.OK)
            {
                GridBind();
            }
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            if (JigResponse_dgv.SelectedRows.Count > 0)
            {
                BindUpdateCavityData();
            }
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            if (JigResponse_dgv.SelectedRows.Count > 0)
            {
                int selectedrowindex = JigResponse_dgv.SelectedCells[0].RowIndex;

                JigResponseVo vo = (JigResponseVo)JigResponse_dgv.Rows[selectedrowindex].DataBoundItem;

                messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, vo.JigResponseCode);
                logger.Info(messageData);
                DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);


                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        JigResponseVo outVo = (JigResponseVo)DefaultCbmInvoker.Invoke(new DeleteJigResponseCbm(), vo);

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

        private void JigResponse_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Update_btn.Enabled = Delete_btn.Enabled = JigResponse_dgv.SelectedRows.Count > 0;
        }

        private void JigResponse_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        /// <summary>
        /// selects user record for updation and show user form
        /// </summary>
        private void BindUpdateCavityData()
        {
            int selectedrowindex = JigResponse_dgv.SelectedCells[0].RowIndex;

            JigResponseVo vo = (JigResponseVo)JigResponse_dgv.Rows[selectedrowindex].DataBoundItem;

            AddJigResponseMasterForm addform = new AddJigResponseMasterForm();
            addform.vo = vo;

            if (addform.ShowDialog() == DialogResult.OK)
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
