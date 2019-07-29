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
    public partial class DrawMasterForm : FormCommonNCVP
    {
        public DrawMasterForm()
        {
            InitializeComponent();
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            DrawCode_txt.Text = string.Empty;

            DrawName_txt.Text = string.Empty;

            Draw_dgv.DataSource = null;

            DrawCode_txt.Select();
        }
        private void GridBind()
        {
            Draw_dgv.DataSource = null;

            try
            {
                DrawVo vo = new Vo.DrawVo
                {
                    DrawCode = DrawCode_txt.Text,
                    DrawName = DrawName_txt.Text
                };
                ValueObjectList<DrawVo> volist = (ValueObjectList<DrawVo>)DefaultCbmInvoker.Invoke(new GetDrawCbm(), vo);
                if (volist.GetList() != null && volist.GetList().Count > 0)
                {
                    Draw_dgv.AutoGenerateColumns = false;
                    BindingSource bindingSource1 = new BindingSource(volist.GetList(), null);
                    Draw_dgv.DataSource = bindingSource1;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }
                Draw_dgv.ClearSelection();

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
            AddDrawMasterForm newAddForm = new AddDrawMasterForm();
            newAddForm.vo = new DrawVo();
            if (newAddForm.ShowDialog() == DialogResult.OK)
            {
                GridBind();
            }
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            if (Draw_dgv.SelectedRows.Count > 0)
            {
                BindUpdateCavityData();
            }
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            if (Draw_dgv.SelectedRows.Count > 0)
            {
                int selectedrowindex = Draw_dgv.SelectedCells[0].RowIndex;

                DrawVo vo = (DrawVo)Draw_dgv.Rows[selectedrowindex].DataBoundItem;

                messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, vo.DrawCode);
                logger.Info(messageData);
                DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);


                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        DrawVo outVo = (DrawVo)DefaultCbmInvoker.Invoke(new DeleteDrawCbm(), vo);

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

        private void Machine_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Update_btn.Enabled = Delete_btn.Enabled = Draw_dgv.SelectedRows.Count > 0;
        }

        private void Machine_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Draw_dgv.SelectedRows.Count > 0)
            {
                BindUpdateCavityData();
            }
        }
        /// <summary>
        /// selects user record for updation and show user form
        /// </summary>
        private void BindUpdateCavityData()
        {
            int selectedrowindex = Draw_dgv.SelectedCells[0].RowIndex;

            DrawVo vo = (DrawVo)Draw_dgv.Rows[selectedrowindex].DataBoundItem;

            AddDrawMasterForm addform = new AddDrawMasterForm();
            addform.vo = vo;

            if (addform.IntSuccess > 0)
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
