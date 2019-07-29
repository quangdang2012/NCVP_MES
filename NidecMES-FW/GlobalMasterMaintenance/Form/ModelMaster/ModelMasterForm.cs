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
    public partial class ModelMasterForm : FormCommonNCVP
    {
        public ModelMasterForm()
        {
            InitializeComponent();
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            ModelCode_txt.Text = string.Empty;

            ModelName_txt.Text = string.Empty;

            Machine_dgv.DataSource = null;

            ModelCode_txt.Select();
        }
        private void GridBind()
        {
            Machine_dgv.DataSource = null;

            try
            {
                ModelVo vo = new Vo.ModelVo
                {
                    ModelCode = ModelCode_txt.Text,
                    ModelName = ModelName_txt.Text
                };
                ValueObjectList<ModelVo> volist = (ValueObjectList<ModelVo>)DefaultCbmInvoker.Invoke(new GetModelCbm(), vo);
                if (volist.GetList() != null && volist.GetList().Count > 0)
                {
                    Machine_dgv.AutoGenerateColumns = false;
                    BindingSource bindingSource1 = new BindingSource(volist.GetList(), null);
                    Machine_dgv.DataSource = bindingSource1;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }
                Machine_dgv.ClearSelection();

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
            AddModelMasterForm newAddForm = new AddModelMasterForm();
            newAddForm.vo = new ModelVo();
            if (newAddForm.ShowDialog() == DialogResult.OK)
            {
                GridBind();
            }
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            if (Machine_dgv.SelectedRows.Count > 0)
            {
                BindUpdateCavityData();
            }
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            if (Machine_dgv.SelectedRows.Count > 0)
            {
                int selectedrowindex = Machine_dgv.SelectedCells[0].RowIndex;

                ModelVo vo = (ModelVo)Machine_dgv.Rows[selectedrowindex].DataBoundItem;

                messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, vo.ModelCode);
                logger.Info(messageData);
                DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);


                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        ModelVo outVo = (ModelVo)DefaultCbmInvoker.Invoke(new DeleteModelCbm(), vo);

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
            Update_btn.Enabled = Delete_btn.Enabled = Machine_dgv.SelectedRows.Count > 0;
        }

        private void Machine_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Machine_dgv.SelectedRows.Count > 0)
            {
                BindUpdateCavityData();
            }
        }
        /// <summary>
        /// selects user record for updation and show user form
        /// </summary>
        private void BindUpdateCavityData()
        {
            int selectedrowindex = Machine_dgv.SelectedCells[0].RowIndex;

            ModelVo vo = (ModelVo)Machine_dgv.Rows[selectedrowindex].DataBoundItem;

            AddModelMasterForm addform = new AddModelMasterForm();
            addform.vo = vo;
            addform.ShowDialog();
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
