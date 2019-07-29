using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using System;
using System.Windows.Forms;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.DrawCbm;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class AddDrawForm : FormCommonNCVP
    {
        public AddDrawForm()
        {
            InitializeComponent();
        }

        public DrawingVo vo = new DrawingVo();

        private static GetModelCbm getModelCbm = new GetModelCbm();

        private static GetDrawCbm getDrawCmb = new GetDrawCbm();

        private static GetMachineMasterMntCbm getMachineCmb = new GetMachineMasterMntCbm();

        private void AddJigDrawForm_Load(object sender, EventArgs e)
        {
            ValueObjectList<ModelVo> modelvolist = null;
            try
            {
                modelvolist = (ValueObjectList<ModelVo>)DefaultCbmInvoker.Invoke(getModelCbm, new ModelVo());
            }
            catch (Framework.ApplicationException ex)
            {
                logger.Error(ex.GetMessageData());
                popUpMessage.ApplicationError(ex.GetMessageData(), Text);
                return;
            }
            model_cmb.DisplayMember = "ModelCode";
            BindingSource b1 = new BindingSource(modelvolist.GetList(), null);
            model_cmb.DataSource = b1;
            model_cmb.Text = "";

            ValueObjectList<DrawVo> drawvolist = null;
            try
            {
                drawvolist = (ValueObjectList<DrawVo>)DefaultCbmInvoker.Invoke(getDrawCmb, new DrawVo());
            }
            catch (Framework.ApplicationException ex)
            {
                logger.Error(ex.GetMessageData());
                popUpMessage.ApplicationError(ex.GetMessageData(), Text);
                return;
            }
            drawing_cmb.DisplayMember = "DrawCode";
            BindingSource b = new BindingSource(drawvolist.GetList(), null);
            drawing_cmb.DataSource = b;
            drawing_cmb.Text = "";

            MachineVo machinelist = null;
            try
            {
                machinelist = (MachineVo)DefaultCbmInvoker.Invoke(getMachineCmb, new MachineVo());
            }
            catch (Framework.ApplicationException ex)
            {
                logger.Error(ex.GetMessageData());
                popUpMessage.ApplicationError(ex.GetMessageData(), Text);
                return;
            }
            Machine_cmb.DisplayMember = "MachineName";
            Machine_cmb.DataSource = machinelist.MachineListVo;
            Machine_cmb.Text = "";

            if (vo.DeviceID > 0)
            {
                model_cmb.Enabled = false;
                model_cmb.Text = vo.ModelCode;
                device_code_txt.Text = vo.DeviceCode;
                drawing_cmb.Text = vo.DrawCode;
                Machine_cmb.Text = vo.MachineName;
                timereceive_dtp.Value = vo.TimeFrom;
            }
        }

        private void model_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (model_cmb.SelectedItem != null)
            {
                ModelVo mvo = (ModelVo)model_cmb.SelectedItem;
                ValueObjectList<DrawVo> drawlist = null;
                try
                {
                    drawlist = (ValueObjectList<DrawVo>)DefaultCbmInvoker.Invoke(getDrawCmb, new DrawVo());
                }
                catch (Framework.ApplicationException ex)
                {
                    logger.Error(ex.GetMessageData());
                    popUpMessage.ApplicationError(ex.GetMessageData(), Text);
                    return;
                }
                drawing_cmb.DisplayMember = "DrawCode";
                BindingSource b = new BindingSource(drawlist.GetList(), null);
                drawing_cmb.DataSource = b;
                drawing_cmb.Text = "";
            }
        }

        bool checkdata()
        {
            if (model_cmb.SelectedItem == null)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, model_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                model_cmb.Focus();
                return false;
            }

            if (drawing_cmb.SelectedItem == null)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, drawing_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                drawing_cmb.Focus();
                return false;
            }

            if (device_code_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, device_code_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                device_code_txt.Focus();
                return false;
            }

            return true;
        }

        private void OK_btn_Click(object sender, EventArgs e) // ok buttion
        {
            string mcPath = @"Z:\(01)Motor\(02)Engineering\(03)FA\1. PRIVATE DOCUMENTS\1. MECHANIC\MES\" + Machine_cmb.Text + @"\";
            string parentPath = mcPath + drawing_cmb.Text + @"\";
            string folder1 = parentPath + @"1.Drawing\";
            string folder2 = parentPath + @"2.List\";
            string folder3 = parentPath + @"3.Calculation\";
            string folder4 = parentPath + @"4.Improvement failure\";
            string folder1a = folder1 + @"AutoCad\";
            string folder1b = folder1 + @"PDF\";

            if (!checkdata()) { return; }
            DrawingVo outVo = new DrawingVo();
            DrawingVo inVo = new DrawingVo
            {
                DeviceID = this.vo.DeviceID,
                TimeFrom = this.timereceive_dtp.Value,
                ModelId = ((ModelVo)this.model_cmb.SelectedItem).ModelId,
                DeviceCode = device_code_txt.Text,
                DrawId = ((DrawVo)this.drawing_cmb.SelectedItem).DrawId,
                MachineID = ((MachineVo)this.Machine_cmb.SelectedItem).MachineId,
                Department = depart_txt.Text,
                DrawType = DrawType_txt.Text,
                Revision = revision_txt.Text,
                RegistrationUserCode = UserData.GetUserData().UserCode,
                FactoryCode = UserData.GetUserData().FactoryCode
            };

            try
            {
                if (inVo.DeviceID > 0)
                {
                    outVo = (DrawingVo)DefaultCbmInvoker.Invoke(new UpdateDrawingCbm(), inVo);
                }
                else
                {
                    outVo = (DrawingVo)DefaultCbmInvoker.Invoke(new AddDrawingCbm(), inVo);
                }
            }
            catch (Com.Nidec.Mes.Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }
            if (outVo.AffectedCount > 0)
            {
                this.DialogResult = DialogResult.OK;
            }

            // Create a new target folder.
            if (!System.IO.Directory.Exists(mcPath))
            {
                System.IO.Directory.CreateDirectory(mcPath);

                if (!System.IO.Directory.Exists(parentPath))
                {
                    System.IO.Directory.CreateDirectory(parentPath);
                    System.IO.Directory.CreateDirectory(folder1);
                    System.IO.Directory.CreateDirectory(folder1a);
                    System.IO.Directory.CreateDirectory(folder1b);
                    System.IO.Directory.CreateDirectory(folder2);
                    System.IO.Directory.CreateDirectory(folder3);
                    System.IO.Directory.CreateDirectory(folder4);

                    MessageBox.Show("Drawing folder is created" + "\r\nYou can find it in " + "'" + parentPath + "'", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Drawing folder is already exists!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (!System.IO.Directory.Exists(parentPath))
                {
                    System.IO.Directory.CreateDirectory(parentPath);
                    System.IO.Directory.CreateDirectory(folder1);
                    System.IO.Directory.CreateDirectory(folder1a);
                    System.IO.Directory.CreateDirectory(folder1b);
                    System.IO.Directory.CreateDirectory(folder2);
                    System.IO.Directory.CreateDirectory(folder3);
                    System.IO.Directory.CreateDirectory(folder4);

                    MessageBox.Show("Drawing folder is created" + "\r\nYou can find it in " + "'" + parentPath + "'", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Drawing folder is already exists!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }       
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void drawing_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a = drawing_cmb.Text.Length;
            DrawType_txt.Text = drawing_cmb.Text.Substring(0, a-3);
            depart_txt.Text = drawing_cmb.Text.Substring(5, 2);
        }
    }
}
