using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using System.Drawing;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.AssetMasterCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.Asset
{
    public partial class AssetForm : FormCommonNCVP
    {
        public AssetForm()
        {
            InitializeComponent();
            AssetDetails_dgv.AutoGenerateColumns = false;
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            AssetCode_txt.Text = string.Empty;

            AssetName_txt.Text = string.Empty;

            AssetDetails_dgv.DataSource = null;

            AssetCode_txt.Select();
        }
        private void GridBind()
        {
            AssetDetails_dgv.DataSource = null;
            try
            {
                AssetVo vo = new AssetVo
                {
                    AssetCode = AssetCode_txt.Text,
                    AssetName = AssetName_txt.Text,
                    AssetNo = 10000, //ne vao trong gia tri o, nen chuyen database lai voi asset_no string  Long
                  
                };

                ValueObjectList<AssetVo> volist = (ValueObjectList<AssetVo>)DefaultCbmInvoker.Invoke(new GetAssetCbm(), vo);
                if (volist.GetList() != null && volist.GetList().Count > 0)
                {
                    BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                    AssetDetails_dgv.DataSource = bindingsource;

                    AssetDetails_dgv.Columns["colAssetCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }
                AssetDetails_dgv.ClearSelection();
                setColor();
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

            AddAssetForm Formadd = new AddAssetForm();
            Formadd.vo = new AssetVo();
            if (Formadd.ShowDialog() == DialogResult.OK)
            {
                GridBind();
            }
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            if (AssetDetails_dgv.SelectedRows.Count > 0)
            {
                BindUpdateCavityData();
            }
        }
         private void BindUpdateCavityData()
        {
            int selectedrowindex = AssetDetails_dgv.SelectedCells[0].RowIndex;

            AssetVo vo = (AssetVo)AssetDetails_dgv.Rows[selectedrowindex].DataBoundItem;

            AddAssetForm addform = new AddAssetForm();
            addform.vo = vo;
            addform.ShowDialog(); //
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
            if (AssetDetails_dgv.SelectedRows.Count > 0)
            {
                int selectedrowindex = AssetDetails_dgv.SelectedCells[0].RowIndex;

                AssetVo vo = (AssetVo)AssetDetails_dgv.Rows[selectedrowindex].DataBoundItem;

                messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, vo.AssetCode);
                logger.Info(messageData);
                DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        AssetVo outVo = (AssetVo)DefaultCbmInvoker.Invoke(new DeleteAssetCbm(), vo);

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
            if (AssetCode_txt.TextLength >10)
            {
                string str = AssetCode_txt.Text;
                string[] arrListStr = str.Split(',');
                AssetCode_txt.Text = arrListStr[0];
               
            }
            GridBind();
        }

        private void AssetDetails_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Update_btn.Enabled = Delete_btn.Enabled = AssetDetails_dgv.SelectedRows.Count > 0;
        }

        private void AssetDetails_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (AssetDetails_dgv.SelectedRows.Count > 0)
            {
                BindUpdateCavityData();
            }
        }
        
        private void setColor()
        {
            string lblStatus;
            for (int i = 0; i < AssetDetails_dgv.RowCount; i++)
            {
                lblStatus = AssetDetails_dgv["colLabelStatus", i].Value.ToString();
                switch (lblStatus)
                {
                    case "Not Paste":
                        AssetDetails_dgv.Rows[i].DefaultCellStyle.BackColor = Color.Violet;
                        break;
                    case "Cannot Paste":
                        AssetDetails_dgv.Rows[i].DefaultCellStyle.BackColor = Color.LightCoral;
                        break;
                }
            }
        }
        private void AssetForm_Load(object sender, EventArgs e)
        {
            AcceptButton = Search_btn;
        }
    }
}
