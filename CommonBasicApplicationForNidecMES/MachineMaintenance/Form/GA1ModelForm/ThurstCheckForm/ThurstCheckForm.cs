using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using System;
using System.Windows.Forms;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.GA1ModelCbm;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class ThurstCheckForm : FormCommonNCVP
    {
        public ThurstCheckForm()
        {
            InitializeComponent();
            dgv_thurst.AutoGenerateColumns = false;
        }
        void callModel()
        {
            ValueObjectList<ModelVo> modelvolist = (ValueObjectList<ModelVo>)DefaultCbmInvoker.Invoke(new GetModelCbm(), new ModelVo());
            cmb_model.DisplayMember = "ModelCode";
            BindingSource b1 = new BindingSource(modelvolist.GetList(), null);
            cmb_model.DataSource = b1;
            cmb_model.Text = "";
        }
        void callLine()
        {
            ValueObjectList<GA1ModelVo> assetvoinvoice = (ValueObjectList<GA1ModelVo>)DefaultCbmInvoker.Invoke(new GetLineCodeCbm(), new GA1ModelVo { ModelCode = cmb_model.Text });
            cmb_line.DisplayMember = "LineCode";
            cmb_line.DataSource = assetvoinvoice.GetList();
            cmb_line.Text = "";
        }

        private void ThurstCheckForm_Load(object sender, EventArgs e)
        {
            callModel();
            txt_barcode.SelectNextControl(txt_barcode, true, false, true, true);
        }

        private void cmb_model_SelectedIndexChanged(object sender, EventArgs e)
        {
            callLine();
        }

        bool Checkdata()
        {
            if (cmb_model.SelectedItem == null)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, lbl_model.Text);
                popUpMessage.Warning(messageData, Text);
                cmb_model.Focus();
                return false;
            }
            if (cmb_line.SelectedItem == null)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, lbl_line.Text);
                popUpMessage.Warning(messageData, Text);
                cmb_line.Focus();
                return false;
            }
            if (cmb_model.Text == "")
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, lbl_model.Text);
                popUpMessage.Warning(messageData, Text);
                cmb_model.Focus();
                return false;
            }
            if (cmb_line.Text == "")
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, lbl_line.Text);
                popUpMessage.Warning(messageData, Text);
                cmb_line.Focus();
                return false;
            }
            if (cmb_machine.Text == "")
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, "Machine");
                popUpMessage.Warning(messageData, Text);
                cmb_machine.Focus();
                return false;
            }
            if (txt_barcode.Text == "")
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, lbl_barcode.Text);
                popUpMessage.Warning(messageData, Text);
                txt_barcode.Focus();
                return false;
            }
            return true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = int.Parse(txt_timer.Text) * 1000;
            lbl_status.Text = "WAITING";
            lbl_status.ForeColor = System.Drawing.Color.DarkGoldenrod;
            pb_OK.Visible = false;
            pb_NG.Visible = false;
            timer1.Enabled = false;
        }
        /*
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            string check = "";
            if (Checkdata())
            {
                GA1ModelVo outVo = new GA1ModelVo();
                GA1ModelVo inVo = new GA1ModelVo();
                if (e.Button == MouseButtons.Right)
                {
                    inVo = new GA1ModelVo()
                    {
                        A90Model = ((ModelVo)this.cmb_model.SelectedItem).ModelCode,
                        A90Line = ((GA1ModelVo)this.cmb_line.SelectedItem).LineCode,
                        A90Barcode = txt_barcode.Text,
                        A90Shipping = false,
                        Date = DateTime.Today,
                        Time = DateTime.Parse(DateTime.Now.ToShortTimeString()),
                        FactoryCode = cmb_machine.Text,
                        A90ThurstStatus = "OK",
                        RegistrationUserCode = UserData.GetUserData().UserName,
                    };
                    check = "OK";
                }
                if (e.Button == MouseButtons.Left)
                {
                    inVo = new GA1ModelVo()
                    {
                        A90Model = ((ModelVo)this.cmb_model.SelectedItem).ModelCode,
                        A90Line = ((GA1ModelVo)this.cmb_line.SelectedItem).LineCode,
                        A90Barcode = txt_barcode.Text,
                        A90Shipping = false,
                        Date = DateTime.Today,
                        Time = DateTime.Parse(DateTime.Now.ToShortTimeString()),
                        FactoryCode = cmb_machine.Text,
                        A90ThurstStatus = "NG",
                        RegistrationUserCode = UserData.GetUserData().UserName,
                    };
                    check = "NG";
                }
                outVo = (GA1ModelVo)DefaultCbmInvoker.Invoke(new Cbm.AddGA1ModelThurstCbm(), inVo);
                GridBind();
                if (check == "OK")
                {
                    pb_OK.Visible = true;
                    pb_NG.Visible = false;
                    lbl_status.Text = "CHECKED";
                    timer1.Enabled = true;
                    lbl_status.ForeColor = System.Drawing.Color.Green;
                }
                else if (check == "NG")
                {
                    pb_OK.Visible = false;
                    pb_NG.Visible = true;
                    lbl_status.Text = "CHECKED";
                    timer1.Enabled = true;
                    lbl_status.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lbl_status.Text = "WAITING";
                    messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, lbl_barcode.Text);
                    popUpMessage.Warning(messageData, Text);
                    txt_barcode.Focus();
                }
                txt_barcode.Text = "";
            }
        }
        */
        private void GridBind()
        {
            try
            {
                GA1ModelVo calldgv = new GA1ModelVo()
                {
                    A90Model = cmb_model.Text,
                    A90Line = cmb_line.Text,
                };

                ValueObjectList<GA1ModelVo> listvo = (ValueObjectList<GA1ModelVo>)DefaultCbmInvoker.Invoke(new SearchThurstDGVCbm(), calldgv);
                dgv_thurst.DataSource = listvo.GetList();
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txt_barcode_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txt_barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_barcode.Text.Length == 8)
                {
                    if (Checkdata())
                    {
                        GA1ModelVo outVo = new GA1ModelVo();
                        GA1ModelVo inVo = new GA1ModelVo();
                        inVo = new GA1ModelVo()
                        {
                            A90Model = ((ModelVo)this.cmb_model.SelectedItem).ModelCode,
                            A90Line = ((GA1ModelVo)this.cmb_line.SelectedItem).LineCode,
                            A90Barcode = txt_barcode.Text,
                            A90Shipping = false,
                            Date = DateTime.Today,
                            Time = DateTime.Parse(DateTime.Now.ToShortTimeString()),
                            FactoryCode = cmb_machine.Text,
                            A90ThurstStatus = "OK",
                            RegistrationUserCode = UserData.GetUserData().UserName,
                        };
                        outVo = (GA1ModelVo)DefaultCbmInvoker.Invoke(new AddGA1ModelThurstCbm(), inVo);
                        GridBind();

                        {
                            pb_OK.Visible = true;
                            pb_NG.Visible = false;
                            lbl_status.Text = "CHECKED";
                            timer1.Enabled = true;
                            lbl_status.ForeColor = System.Drawing.Color.Green;
                            txt_barcode.Text = "";
                        }
                    }
                }
                else
                {
                    messageData = new MessageData("Error", " Mã barcode phải đúng 8 kí tự!", lbl_barcode.Text);
                    popUpMessage.ApplicationError(messageData, Text);
                    txt_barcode.Focus();
                }
            }
        }
    }
}
