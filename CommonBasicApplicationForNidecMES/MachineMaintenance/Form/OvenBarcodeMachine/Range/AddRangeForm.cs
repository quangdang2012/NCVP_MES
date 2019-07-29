using System;

using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.OvenBarcodeCbm.RangeCbm;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance
{
    public partial class AddRangeForm : FormCommonNCVP
    {
        public AddRangeForm()
        {
            InitializeComponent();
        }
        public RangeVo vo = null;
        public int IntSuccess = -1;
        private void Ok_btn_Click(object sender, EventArgs e)
        {
            if (checkdate())
            {
                int fail = 0;
                int a = vo.RangeId;
                RangeVo outvo = new RangeVo();
                try
                {
                    int countCheckTrue = 0;
                    foreach (TreeNode aNode in Barcode_tv.Nodes)
                    {
                        if (aNode.Checked == true)
                        {
                            countCheckTrue = countCheckTrue + 1;
                        }
                    }

                    if (vo.RangeId > 0)
                    {
                        foreach (TreeNode aNode in Barcode_tv.Nodes)
                        {
                            if (aNode.Checked == true)
                            {
                                outvo = (RangeVo)DefaultCbmInvoker.Invoke(new UpdateRangeCbm(), new RangeVo
                                {
                                    //RangeId = vo.RangeId,
                                    Model = model_cbm.Text,
                                    Barcode = aNode.Text,
                                    Line = line_cbm.Text,
                                    Lower = lower_txt.Text,
                                    Upper = upper_txt.Text,
                                    RegistrationUser = UserData.GetUserData().UserCode
                                });
                                IntSuccess = outvo.AffectedCount;
                            }
                        }
                    }
                    else
                    {
                        int countDem = 0;
                        
                        string duplicate_barcode = "";
                        foreach (TreeNode aNode in Barcode_tv.Nodes)
                        {
                            RangeVo checkBarcode = (RangeVo)DefaultCbmInvoker.Invoke(new CheckBarcodeRangeCbm(), new RangeVo()
                            {
                                Model = model_cbm.Text,
                                Barcode = aNode.Text,
                                Line = line_cbm.Text,
                            });
                            
                            if (aNode.Checked == true)
                            {
                                countDem = countDem + 1;
                                if (checkBarcode.Count == 0)//kiểm tra barcode có trùng trong database
                                {
                                    outvo = (RangeVo)DefaultCbmInvoker.Invoke(new AddRangeCbm(), new RangeVo
                                    {
                                        RangeId = vo.RangeId,
                                        Model = model_cbm.Text,
                                        Barcode = aNode.Text,
                                        Line = line_cbm.Text,
                                        Lower = lower_txt.Text,
                                        Upper = upper_txt.Text,
                                        RegistrationUser = UserData.GetUserData().UserCode
                                    });
                                    IntSuccess = outvo.AffectedCount;
                                }
                                else
                                {
                                    duplicate_barcode = duplicate_barcode + aNode.Text.Trim() + " & ";
                                    if (countDem == countCheckTrue)
                                    {
                                        messageData = new MessageData("mmcc00005", "Duplicate key Barcode: " + duplicate_barcode.Substring(0, duplicate_barcode.Length -2), barcode_lbl.Text);
                                        popUpMessage.Warning(messageData, Text);
                                        

                                        Barcode_tv.Focus();
                                        fail = fail + 1;
                                        //return;
                                    }
                                }
                            }
                        }
                        
                    }
                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                    return;
                }
                if ((IntSuccess > 0) || (IntSuccess == 0))
                {
                    if(fail > 0)
                    {

                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
        private bool checkdate()
        {
            if (model_cbm.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, model_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                lower_txt.Focus();
                return false;
            }
            if (line_cbm.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, line_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                upper_txt.Focus();
                return false;
            }
            int count = Barcode_tv.Nodes.Count;
            int check = 0;
            foreach (TreeNode aNode in Barcode_tv.Nodes)
            {
                
                if (aNode.Checked == false)
                {                    
                    check = check + 1;
                    if(check == count)
                    {
                        messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, barcode_lbl.Text);
                        popUpMessage.Warning(messageData, Text);
                        Barcode_tv.Focus();
                        return false;
                    }
                }
            }

                   
            if (lower_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, lower_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                lower_txt.Focus();
                return false;
            }
            if (upper_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, upper_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                upper_txt.Focus();
                return false;
            }
            //model_cbm.Text = model_cbm.Text.Trim();
            //line_cbm.Text = line_cbm.Text.Trim();
            lower_txt.Text = lower_txt.Text.Trim();
            upper_txt.Text = upper_txt.Text.Trim();
            //RangeVo outVo = new RangeVo(),
            //    inVo = new RangeVo { RangeId = vo.RangeId,  };
            //try
            //{
            //    outVo = (RangeVo)DefaultCbmInvoker.Invoke(new CheckRankCbm(), inVo);
            //    if (outVo.AffectedCount > 0)
            //    {
            //        messageData = new MessageData("mmcc00006", Properties.Resources.mmcc00006, lower_lbl.Text);
            //        popUpMessage.Warning(messageData, Text);
            //        lower_txt.Focus();
            //        return false;
            //    }
            //}
            //catch (Com.Nidec.Mes.Framework.ApplicationException exception)
            //{
            //    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
            //    logger.Error(exception.GetMessageData());
            //    return false;
            //}
            return true;

        }
        private void AddRankForm_Load(object sender, EventArgs e)
        {
            //lower_txt.Select();
            ValueObjectList<RangeVo> modelVo = (ValueObjectList<RangeVo>)DefaultCbmInvoker.Invoke(new GetModelRangeCbm(), new RangeVo());
            model_cbm.DisplayMember = "Model";
            model_cbm.DataSource = modelVo.GetList();
            model_cbm.Text = "";

            if (vo.RangeId > 0)
            {
                model_cbm.Text = vo.Model;
                model_cbm.Enabled = false;
                line_cbm.Text = vo.Line;
                line_cbm.Enabled = false;
                upper_txt.Text = vo.Upper;
                lower_txt.Text = vo.Lower;
                TreeView();
            }
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void model_cbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValueObjectList<RangeVo> linelVo = (ValueObjectList<RangeVo>)DefaultCbmInvoker.Invoke(new GetLineRangeCbm(), new RangeVo() { Model = model_cbm.Text, });
            line_cbm.DisplayMember = "Line";
            line_cbm.DataSource = linelVo.GetList();
            line_cbm.Text = "";
        }
        
        private void TreeView()
        {
            ValueObjectList<RangeVo> barcodeVo = (ValueObjectList<RangeVo>)DefaultCbmInvoker.Invoke(new GetBarcodeRangeCbm(), new RangeVo() { Model = model_cbm.Text, Line = line_cbm.Text });
            Barcode_tv.Nodes.Clear();
            
            foreach (var bar in barcodeVo.GetList())
            {
                TreeNode child = new TreeNode
                {
                    Text = bar.Barcode,
                   Tag = bar.Barcode
                };
                
                Barcode_tv.Nodes.Add(child);               
            }
            int l = int.Parse(barcodeVo.GetList().Count.ToString());
            for (int i = 0; i < l ; i++)
            {
                Barcode_tv.Nodes[i].Checked = true;
            }
            if(l > 8)
            {
                l = 8;
                this.Barcode_tv.Height = (l * 19);
            }
            else if(l >2 && l <=8)
            {
                this.Barcode_tv.Height = (l * 19);
            }
        }
        private void line_cbm_Click(object sender, EventArgs e)
        {
            TreeView();
        }

        private void line_cbm_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
