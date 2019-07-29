using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.DetailPositionCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.DetailPositionForm
{
    public partial class DetailPositionForm : FormCommonNCVP
    {
        public DetailPositionForm()
        {
            InitializeComponent();
        }
        private void GridBind()
        {
            Detail_Position_dgv.DataSource = null;
            try
            {
                DetailPositionVo vo = new DetailPositionVo
                {
                    DetailPositionCode = DetailPositionCode_txt.Text,
                    DetailPositionName = DetailPositionName_txt.Text,
                    LocationCd = locationcd_cbm.Text,
                   
                };

                ValueObjectList<DetailPositionVo> volist = (ValueObjectList<DetailPositionVo>)DefaultCbmInvoker.Invoke(new GetDetailPositionCbm(), vo);
                if (volist.GetList() != null && volist.GetList().Count > 0)
                {
                    Detail_Position_dgv.AutoGenerateColumns = false;
                    BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                    Detail_Position_dgv.DataSource = bindingsource;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }
                Detail_Position_dgv.ClearSelection();
                Update_btn.Enabled = false;
                Delete_btn.Enabled = false;
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }
        private void Add_btn_Click(object sender, EventArgs e)
        {
            AddDetailPositionForm Formadd = new AddDetailPositionForm();
            Formadd.vo = new DetailPositionVo();
            if (Formadd.ShowDialog() == DialogResult.OK)
            {
                GridBind();
            }
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {

            DetailPositionCode_txt.Text = string.Empty;
            DetailPositionName_txt.Text = string.Empty;
            Detail_Position_dgv.DataSource = null;
            Update_btn.Enabled = Delete_btn.Enabled = false;
            DetailPositionCode_txt.Select();

        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            if (Detail_Position_dgv.SelectedRows.Count > 0)
            {
                BindUpdateCavityData();
            }
        }
        private void BindUpdateCavityData()
        {
            int selectedrowindex = Detail_Position_dgv.SelectedCells[0].RowIndex;

            DetailPositionVo vo = (DetailPositionVo)Detail_Position_dgv.Rows[selectedrowindex].DataBoundItem;

            AddDetailPositionForm addform = new AddDetailPositionForm();
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
        private void Delete_btn_Click(object sender, EventArgs e)
        {

            if (Detail_Position_dgv.SelectedRows.Count > 0)
            {
                int selectedrowindex = Detail_Position_dgv.SelectedCells[0].RowIndex;

                DetailPositionVo vo = (DetailPositionVo)Detail_Position_dgv.Rows[selectedrowindex].DataBoundItem;

                messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, vo.DetailPositionCode);
                logger.Info(messageData);
                DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        DetailPositionVo outVo = (DetailPositionVo)DefaultCbmInvoker.Invoke(new DeleteDetailPositionCbm(), vo);

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

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void Search_btn_Click(object sender, EventArgs e)
        {
            GridBind();
        }

      
        private void Detail_Position_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Detail_Position_dgv.SelectedRows.Count > 0)
            {
                BindUpdateCavityData();
            }
        }

        private void Detail_Position_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Update_btn.Enabled = Delete_btn.Enabled = Detail_Position_dgv.SelectedRows.Count > 0;
        }

        private void DetailPositionForm_Load(object sender, EventArgs e)
        {
            LocationVo Locationvo = (LocationVo)DefaultCbmInvoker.Invoke(new GetLocationMasterMntCbm(), new LocationVo());
            locationcd_cbm.DataSource = Locationvo.LocationListVo;
            locationcd_cbm.DisplayMember = "LocationCode";
            locationcd_cbm.Text = "";

        }
    }
}
