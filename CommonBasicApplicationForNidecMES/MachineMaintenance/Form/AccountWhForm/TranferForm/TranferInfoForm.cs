using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Drawing;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.TransferCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.TranferForm
{
    public partial class TranferInfoForm : FormCommonNCVP
    {
        private static GetDeptCbm getDeptCbm = new GetDeptCbm();
        public TranferInfoForm()
        {
            InitializeComponent();
            TranferInfo_dgv.AutoGenerateColumns = false;
        }

        private void Search_btn_Click(object sender, EventArgs e)
        {
            TransferVo trvos = new TransferVo()
            {
                UserName = UserData.GetUserData().UserName,
                DestinationDept = Destination_cmb.Text
            };

            ValueObjectList<TransferVo> listvo = (ValueObjectList<TransferVo>)DefaultCbmInvoker.Invoke(new LoadTransferListCbm(), trvos);
            TranferInfo_dgv.DataSource = listvo.GetList();
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void setColor()
        {
            for (int i = 0; i < TranferInfo_dgv.RowCount; i++)
            {
                for (int j = 0; j < TranferInfo_dgv.ColumnCount; j++)
                {
                    string status = TranferInfo_dgv[j, i].Value.ToString();
                    switch (status)
                    {
                        case "Approved":
                            TranferInfo_dgv[j, i].Style.BackColor = Color.Green;
                            break;
                        case "Rejected":
                            TranferInfo_dgv[j, i].Style.BackColor = Color.Red;
                            break;
                    }
                }
            }
        }

        private void TranferInfoForm_Load(object sender, EventArgs e)
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
            Destination_cmb.DisplayMember = "LocationCode";
            BindingSource b2 = new BindingSource(locationvolist.GetList(), null);
            Destination_cmb.DataSource = b2;
            Destination_cmb.Text = "";

            GridBind();
            setColor();
        }

        private void GridBind()
        {
            TransferVo transOutVo = new TransferVo();
            TransferVo transVo = new TransferVo()
            {
                RegistrationUserCode = UserData.GetUserData().UserCode
            };
            try
            {
                transOutVo = (TransferVo)DefaultCbmInvoker.Invoke(new GetRoleCbm(), transVo);
                string role = transOutVo.RegistrationUserCode;

                switch (role)
                {
                    case "account":
                        TransferVo trvo = new TransferVo()
                        {
                            UserName = UserData.GetUserData().UserName
                        };

                        ValueObjectList<TransferVo> vo = (ValueObjectList<TransferVo>)DefaultCbmInvoker.Invoke(new LoadAllTransferListCbm(), trvo);
                        TranferInfo_dgv.DataSource = vo.GetList();
                        break;
                    default:
                        TransferVo trvos = new TransferVo()
                        {
                            UserName = UserData.GetUserData().UserName
                        };

                        ValueObjectList<TransferVo> listvo = (ValueObjectList<TransferVo>)DefaultCbmInvoker.Invoke(new LoadTransferListCbm(), trvos);
                        TranferInfo_dgv.DataSource = listvo.GetList();
                        break;
                } 
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        private void View_btn_Click(object sender, EventArgs e)
        {
            if (TranferInfo_dgv.SelectedCells.Count > 0)
            {
                TransferVo uvo = (TransferVo)TranferInfo_dgv.CurrentRow.DataBoundItem;
                if (new TranferRequestForm { TransVo = uvo }.ShowDialog() != DialogResult.OK)
                {
                    GridBind();
                    setColor();
                }
            }
        }
    }
}