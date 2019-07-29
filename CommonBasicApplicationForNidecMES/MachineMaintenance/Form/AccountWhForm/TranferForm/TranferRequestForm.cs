using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance;
using System.Drawing;
using System.Data;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.TransferCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.TranferForm
{
    public partial class TranferRequestForm : FormCommonNCVP
    {
        public TransferVo TransVo = new TransferVo();
        private static GetDeptCbm getDeptCbm = new GetDeptCbm();
        public string assetcodetrim;
        public string transChk;
        public string desChk;
        public string accChk;
        public TranferRequestForm()
        {
            InitializeComponent();
            BefTrans_dgv.AutoGenerateColumns = false;
            AftTrans_dgv.AutoGenerateColumns = false;
        }

        bool Checkdata()
        {
            if (Destination_cmb.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, Destination_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                Destination_cmb.Focus();
                return false;
            }
            if (Transfer_cmb.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, Transfer_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                Transfer_cmb.Focus();
                return false;
            }
            if (TransferContent_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, TransferContent_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                TransferContent_txt.Focus();
                return false;
            }
            return true;
        }

        private void Send_btn_Click(object sender, EventArgs e)
        {
            //List Request
            if (Checkdata())
            {
                TransferVo outVo = new TransferVo();
                TransferVo inVo = new TransferVo()
                {
                    TransferDeviceId = this.TransVo.TransferDeviceId,
                    TransferDeviceCode = TransferCd_txt.Text,
                    TransferContent = TransferContent_txt.Text,
                    TransferDept = Transfer_cmb.Text,
                    DestinationDept = Destination_cmb.Text,
                    RegistrationDateTime = DateTime.Now,
                    FactoryCode = UserData.GetUserData().FactoryCode,
                    RegistrationUserCode = UserData.GetUserData().UserCode
                };
                try
                {
                        outVo = (TransferVo)DefaultCbmInvoker.Invoke(new AddListRequestCbm(), inVo);
                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                    return;
                }

                //Detail Request
                TransferVo outVo1 = new TransferVo();

                for (int i = 0; i < AftTrans_dgv.Rows.Count; i++)
                {
                    try
                    {
                        outVo1 = (TransferVo)DefaultCbmInvoker.Invoke(new AddDetailRequestCbm(), new TransferVo()
                        {
                            TransferDetailId = this.TransVo.TransferDetailId,
                            TransferDeviceId = int.Parse(TransferCd_txt.Text.Substring(6)),
                            AssetID = int.Parse(AftTrans_dgv["AssetID", i].Value.ToString()),
                            RegistrationDateTime = DateTime.Now,
                            FactoryCode = UserData.GetUserData().FactoryCode,
                            RegistrationUserCode = UserData.GetUserData().UserCode
                        });
                    }
                    catch (Framework.ApplicationException exception)
                    {
                        popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                        logger.Error(exception.GetMessageData());
                        return;
                    }
                }

                if (outVo.AffectedCount > 0)
                {
                    messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, asset_code_lbl.Text + " : " + asset_code_txt.Text);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                    return;
                }
            }
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GridBind()
        {
            BefTrans_dgv.DataSource = null;
            TransferVo trvos = new TransferVo()
            {
                AssetCode = assetcodetrim,
                LocationCd = Transfer_cmb.Text,
                TransferDeviceCode = TransferCd_txt.Text
            };
            try
            {
                //Load After Trans
                if (TitleText == CommonConstants.MODE_UPDATE)
                {
                    TransferVo Aftvo = (TransferVo)DefaultCbmInvoker.Invoke(new LoadAfterTransCbm(), trvos);
                    dt = new DataTable();
                    dt = Aftvo.dt;
                    AftTrans_dgv.DataSource = Aftvo.dt;
                }

                //Load Before Trans
                ValueObjectList<TransferVo> listvo = (ValueObjectList<TransferVo>)DefaultCbmInvoker.Invoke(new LoadBeforeTransCbm(), trvos);
                BefTrans_dgv.DataSource = listvo.GetList();

                for (int i = 0; i < BefTrans_dgv.RowCount; i++)
                {
                    for (int j = 0; j < AftTrans_dgv.RowCount; j++)
                    {
                        if (BefTrans_dgv["colAssetCode", i].Value.ToString().Contains(AftTrans_dgv["AssetCode", j].Value.ToString()) && BefTrans_dgv["colAssetName", i].Value.ToString().Contains(AftTrans_dgv["AssetName", j].Value.ToString()) && BefTrans_dgv["colAssetNo", i].Value.ToString().Contains(AftTrans_dgv["AssetNo", j].Value.ToString()))
                        {
                            BefTrans_dgv.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                            BefTrans_dgv.Rows[i].DefaultCellStyle.ForeColor = Color.Gray;
                        }
                    }

                    TransferVo outVoA = new TransferVo();
                    TransferVo inVoA = new TransferVo()
                    {
                        AssetID = int.Parse(BefTrans_dgv["colAssetID", i].Value.ToString())
                    };
                    try
                    {
                        outVoA = (TransferVo)DefaultCbmInvoker.Invoke(new CheckAssetTransferCbm(), inVoA);
                        if (outVoA.AffectedCount == 1)
                        {
                            BefTrans_dgv.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                            BefTrans_dgv.Rows[i].DefaultCellStyle.ForeColor = Color.Gray;
                        }

                    }
                    catch (Framework.ApplicationException exception)
                    {
                        popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                        logger.Error(exception.GetMessageData());
                        return;
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
        public DataTable dt;
        public string usr_dept;
        private void TranferRequestForm_Load(object sender, EventArgs e)
        {
            ValueObjectList<LocationVo> locationvolist = null;
            try
            {
                locationvolist = (ValueObjectList<LocationVo>)DefaultCbmInvoker.Invoke(getDeptCbm, new LocationVo());
            }
            catch (Framework.ApplicationException ex)
            {
                logger.Error(ex.GetMessageData());
                popUpMessage.ApplicationError(ex.GetMessageData(), Text);
                return;
            }
            Transfer_cmb.DisplayMember = "LocationCode";
            BindingSource b1 = new BindingSource(locationvolist.GetList(), null);
            Transfer_cmb.DataSource = b1;
            Transfer_cmb.Text = "";

            Destination_cmb.DisplayMember = "LocationCode";
            BindingSource b2 = new BindingSource(locationvolist.GetList(), null);
            Destination_cmb.DataSource = b2;
            Destination_cmb.Text = "";

            if (TransVo.TransferDeviceId > 0)
            {
                Add_btn.Enabled = true;
                Remove_btn.Enabled = true;
                Send_btn.Enabled = false;
                transChk = TransVo.TransferStatus;
                desChk = TransVo.DestinationStatus;
                accChk = TransVo.ApproveStatus;
                RequestAppr_ptb.Visible = true;
                RequestUser_txt.Text = TransVo.UserName;
                TransCheckUser_txt.Text = TransVo.TransferApprover;
                DestinationCheckUser_txt.Text = TransVo.DestinationApprover;
                Accounter_lbl.Text = TransVo.Accounter;
                Transfer_cmb.Text = TransVo.TransferDept;
                Destination_cmb.Text = TransVo.DestinationDept;
                TransferContent_txt.Text = TransVo.TransferContent;
                TransferCd_txt.Text = TransVo.TransferDeviceCode;
                this.TitleText = CommonConstants.MODE_UPDATE;

                if (!String.IsNullOrEmpty(accChk))
                {
                    Account_lbl.Visible = true;
                    Accounter_lbl.Visible = true;
                }

                if (transChk == "Approved" && desChk == "Approved")
                {
                    AccountCheckUser_lbl.Visible = true;
                    AccountApprove_btn.Visible = true;
                    AccountReject_btn.Visible = true;                    
                }

                if (String.IsNullOrEmpty(TransCheckUser_txt.Text) && TransVo.UserName == UserData.GetUserData().UserName)
                {
                    Update_btn.Enabled = true;
                }

                if (transChk == "Rejected" && TransVo.UserName == UserData.GetUserData().UserName || desChk == "Rejected" && TransVo.UserName == UserData.GetUserData().UserName || accChk == "Rejected" && TransVo.UserName == UserData.GetUserData().UserName)
                {
                    Add_btn.Enabled = true;
                    Remove_btn.Enabled = true;
                }

                TransferVo trvos = new TransferVo()
                {
                    TransferDeviceCode = TransferCd_txt.Text
                };
                try
                {
                    TransferVo listvo = (TransferVo)DefaultCbmInvoker.Invoke(new LoadAfterTransCbm(), trvos);
                    dt = new DataTable();
                    dt = listvo.dt;
                    AftTrans_dgv.DataSource = dt;
                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                    return;
                }
                ViewStatus();
            }
            else
            {
                Add_btn.Enabled = true;
                Remove_btn.Enabled = true;
                TransferVo gettrans = new TransferVo();
                gettrans = (TransferVo)DefaultCbmInvoker.Invoke(new GetTransferCodeCbm(), new TransferVo());
                int transId = gettrans.TransferDeviceID;

                if (transId == 0)
                {
                    TransferCd_txt.Text = "DEVTR-1";
                }
                else
                {
                    TransferCd_txt.Text = "DEVTR-" + (transId + 1);
                }

                this.TitleText = Com.Nidec.Mes.GlobalMasterMaintenance.CommonConstants.MODE_ADD;
            }
        }

        private void ViewStatus()
        {
            if (transChk == "Approved")
            {
                TransferAppr_ptb.Visible = true;
            }
            else if (transChk == "Rejected")
            {
                TransferReject_ptb.Visible = true;
            }
            if (desChk == "Approved")
            {
                DestinationAppr_ptb.Visible = true;
            }
            else if (desChk == "Rejected")
            {
                DestinationReject_ptb.Visible = true;
            }
            if (accChk == "Approved")
            {
                AccountAppr_ptb.Visible = true;
                AccountApprove_btn.Enabled = false;
                AccountReject_btn.Enabled = false;
                Account_lbl.Text = "Approved By:";
            }
            else if (accChk == "Rejected")
            {
                AccountReject_ptb.Visible = true;
                AccountApprove_btn.Enabled = true;
                AccountReject_btn.Enabled = false;
                Account_lbl.Text = "Rejected By:";
            }

            //Get User Dept
            TransferVo trOutvo = new TransferVo();
            TransferVo trvo = new TransferVo()
            {
                UserName = UserData.GetUserData().UserName,
                RegistrationUserCode = UserData.GetUserData().UserCode
            };
            try
            {
                trOutvo = (TransferVo)DefaultCbmInvoker.Invoke(new GetUserDeptCbm(), trvo);
                usr_dept = trOutvo.DeptCD;

                //Get Role to show Approve - Reject button

                trOutvo = (TransferVo)DefaultCbmInvoker.Invoke(new GetRoleCbm(), trvo);
                string role = trOutvo.RegistrationUserCode;

                switch (role)
                {
                    case "mgr":
                        AccountApprove_btn.Enabled = false;
                        AccountReject_btn.Enabled = false;
                        if (String.IsNullOrEmpty(TransCheckUser_txt.Text) && usr_dept == Transfer_cmb.Text)
                        {
                            TransferApprove_btn.Enabled = true;
                            TransferReject_btn.Enabled = true;
                            DesApprove_btn.Enabled = false;
                            DesReject_btn.Enabled = false;
                        }
                        else if (String.IsNullOrEmpty(DestinationCheckUser_txt.Text) && usr_dept == Destination_cmb.Text)
                        {
                            TransferApprove_btn.Enabled = false;
                            TransferReject_btn.Enabled = false;
                            DesApprove_btn.Enabled = true;
                            DesReject_btn.Enabled = true;
                        }

                        if (TransferReject_ptb.Visible == true)
                        {
                            TransferReject_btn.Enabled = false;
                            TransferApprove_btn.Enabled = true;
                        }
                        if (DestinationReject_ptb.Visible == true)
                        {
                            DesApprove_btn.Enabled = false;
                            DesReject_btn.Enabled = true;
                        }
                        break;
                    case "account":
                        if (AccountReject_ptb.Visible == true)
                        {
                            AccountApprove_btn.Enabled = true;
                            AccountReject_btn.Enabled = false;
                        }
                        break;
                    default:
                        AccountApprove_btn.Enabled = false;
                        AccountReject_btn.Enabled = false;
                        TransferApprove_btn.Enabled = false;
                        TransferReject_btn.Enabled = false;
                        DesApprove_btn.Enabled = false;
                        DesReject_btn.Enabled = false;
                        break;
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        private void department_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridBind();
            //CheckData();
        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            if (TitleText == CommonConstants.MODE_ADD)
            {
                if (BefTrans_dgv.CurrentRow.DefaultCellStyle.BackColor != Color.LightGray)
                {
                    int i = AftTrans_dgv.RowCount;
                    AftTrans_dgv.Rows.Add(1);
                    AftTrans_dgv["AssetID", i].Value = BefTrans_dgv.CurrentRow.Cells["colAssetID"].Value;
                    AftTrans_dgv["AssetCode", i].Value = BefTrans_dgv.CurrentRow.Cells["colAssetCode"].Value;
                    AftTrans_dgv["AssetName", i].Value = BefTrans_dgv.CurrentRow.Cells["colAssetName"].Value;
                    AftTrans_dgv["AssetNo", i].Value = BefTrans_dgv.CurrentRow.Cells["colAssetNo"].Value;

                    BefTrans_dgv.CurrentRow.DefaultCellStyle.BackColor = Color.LightGray;
                    BefTrans_dgv.CurrentRow.DefaultCellStyle.ForeColor = Color.Gray;
                }
                else MessageBox.Show(Properties.Resources.vnce00002, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (BefTrans_dgv.CurrentRow.DefaultCellStyle.BackColor != Color.LightGray)
                {
                    DataRow dr = dt.NewRow();
                    dr["AssetID"] = BefTrans_dgv.CurrentRow.Cells["colAssetID"].Value;
                    dr["AssetCode"] = BefTrans_dgv.CurrentRow.Cells["colAssetCode"].Value;
                    dr["AssetName"] = BefTrans_dgv.CurrentRow.Cells["colAssetName"].Value;
                    dr["AssetNo"] = BefTrans_dgv.CurrentRow.Cells["colAssetNo"].Value;

                    dt.Rows.Add(dr);
                    AftTrans_dgv.DataSource = dt;
                    BefTrans_dgv.CurrentRow.DefaultCellStyle.BackColor = Color.LightGray;
                    BefTrans_dgv.CurrentRow.DefaultCellStyle.ForeColor = Color.Gray;
                }
                else MessageBox.Show(Properties.Resources.vnce00002, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Remove_btn_Click(object sender, EventArgs e)
        {
            if (this.TitleText == CommonConstants.MODE_ADD)
            {
                AftTrans_dgv.Rows.RemoveAt(AftTrans_dgv.CurrentRow.Index);
                GridBind();
            }
            else if (TitleText == CommonConstants.MODE_UPDATE)
            {
                if (AftTrans_dgv.RowCount > 0)
                {
                    //int selectedrowindex = AftTrans_dgv.SelectedCells[0].RowIndex;

                    TransferVo vo = new TransferVo()
                    {
                        AssetID = int.Parse(AftTrans_dgv.CurrentRow.Cells["AssetID"].Value.ToString()),
                        AssetCode = AftTrans_dgv.CurrentRow.Cells["AssetCode"].Value.ToString(),
                        AssetName = AftTrans_dgv.CurrentRow.Cells["AssetName"].Value.ToString(),
                        AssetNo = int.Parse(AftTrans_dgv.CurrentRow.Cells["AssetNo"].Value.ToString())
                    };

                    messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, vo.AssetCode);
                    logger.Info(messageData);
                    DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

                    if (dialogResult == DialogResult.OK)
                    {
                        try
                        {
                            TransferVo outVo = (TransferVo)DefaultCbmInvoker.Invoke(new DeleteTransferDetailCbm(), vo);

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
        }

        private void View_btn_Click(object sender, EventArgs e)
        {
            TranferInfoForm transinfofrm = new TranferInfoForm();
            transinfofrm.ShowDialog();
        }

        private void TransferApprove_btn_Click(object sender, EventArgs e)
        {
            TransferVo trvoapp = new TransferVo()
            {
                TransferDeviceId = TransVo.TransferDeviceId,
                TransferStatus = "Approved",
                TransferApprover = UserData.GetUserData().UserName
            };
            try
            {
                TransferVo listvo = (TransferVo)DefaultCbmInvoker.Invoke(new UpdateStatusTransferListCbm(), trvoapp);
                TransferAppr_ptb.Visible = true;
                TransferApprove_btn.Enabled = false;
                TransferReject_btn.Enabled = false;
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }
        }

        private void TransferReject_btn_Click(object sender, EventArgs e)
        {
            TransferVo trvosrej = new TransferVo()
            {
                TransferDeviceId = TransVo.TransferDeviceId,
                TransferStatus = "Rejected",
                TransferApprover = UserData.GetUserData().UserName
            };
            try
            {
                TransferVo listvo = (TransferVo)DefaultCbmInvoker.Invoke(new UpdateStatusTransferListCbm(), trvosrej);
                TransferReject_ptb.Visible = true;
                TransferApprove_btn.Enabled = true;
                TransferReject_btn.Enabled = false;
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }
        }

        private void DesApprove_btn_Click(object sender, EventArgs e)
        {
            TransferVo trvos = new TransferVo()
            {
                TransferDeviceId = TransVo.TransferDeviceId,
                DestinationStatus = "Approved",
                DestinationApprover = UserData.GetUserData().UserName
            };
            try
            {
                TransferVo listvo = (TransferVo)DefaultCbmInvoker.Invoke(new UpdateStatusTransferListCbm(), trvos);
                DestinationAppr_ptb.Visible = true;
                DesApprove_btn.Enabled = false;
                DesReject_btn.Enabled = false;
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }
        }

        private void DesReject_btn_Click(object sender, EventArgs e)
        {
            TransferVo trvos = new TransferVo()
            {
                TransferDeviceId = TransVo.TransferDeviceId,
                DestinationStatus = "Rejected",
                DestinationApprover = UserData.GetUserData().UserName
            };
            try
            {
                TransferVo listvo = (TransferVo)DefaultCbmInvoker.Invoke(new UpdateStatusTransferListCbm(), trvos);
                DestinationReject_ptb.Visible = true;
                DesApprove_btn.Enabled = true;
                DesReject_btn.Enabled = false;
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }
        }

        private void AccountApprove_btn_Click(object sender, EventArgs e)
        {
            TransferVo trvos = new TransferVo()
            {
                TransferDeviceId = TransVo.TransferDeviceId,
                ApproveStatus = "Approved",
                Accounter = UserData.GetUserData().UserName
            };
            try
            {
                TransferVo listvo = (TransferVo)DefaultCbmInvoker.Invoke(new UpdateStatusTransferListCbm(), trvos);
                AccountAppr_ptb.Visible = true;
                AccountApprove_btn.Enabled = false;
                AccountReject_btn.Enabled = false;
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }
        }

        private void AccountReject_btn_Click(object sender, EventArgs e)
        {
            TransferVo trvos = new TransferVo()
            {
                TransferDeviceId = TransVo.TransferDeviceId,
                ApproveStatus = "Rejected",
                Accounter = UserData.GetUserData().UserName
            };
            try
            {
                TransferVo listvo = (TransferVo)DefaultCbmInvoker.Invoke(new UpdateStatusTransferListCbm(), trvos);
                AccountReject_ptb.Visible = true;
                AccountApprove_btn.Enabled = true;
                AccountReject_btn.Enabled = false;
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            TransferVo upVo = new TransferVo();
            TransferVo chkVo = new TransferVo();

            for (int i = 0; i < AftTrans_dgv.Rows.Count; i++)
            {
                try
                {
                    chkVo = (TransferVo)DefaultCbmInvoker.Invoke(new CheckAssetTransferCbm(), new TransferVo()
                    {
                        AssetID = int.Parse(AftTrans_dgv["AssetID", i].Value.ToString())
                    });

                    if (chkVo.AffectedCount == 0)
                    {
                        upVo = (TransferVo)DefaultCbmInvoker.Invoke(new AddDetailRequestCbm(), new TransferVo()
                        {
                            TransferDetailId = this.TransVo.TransferDetailId,
                            TransferDeviceId = int.Parse(TransferCd_txt.Text.Substring(6)),
                            AssetID = int.Parse(AftTrans_dgv["AssetID", i].Value.ToString()),
                            RegistrationDateTime = DateTime.Now,
                            FactoryCode = UserData.GetUserData().FactoryCode,
                            RegistrationUserCode = UserData.GetUserData().UserCode
                        });
                    }
                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                    return;
                }
            }

            if (upVo.AffectedCount > 0)
            {
                messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, asset_code_lbl.Text + " : " + asset_code_txt.Text);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                return;
            }
        }

        private void asset_code_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string str = asset_code_txt.Text;
                string[] arrListStr = str.Split(',');
                asset_code_txt.Text = assetcodetrim = arrListStr[0];
                GridBind();
            }
        }
    }
}