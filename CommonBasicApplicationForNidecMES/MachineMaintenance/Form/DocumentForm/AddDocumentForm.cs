using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using System;
using System.Windows.Forms;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using System.IO;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.DrawCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.DocumentCbm;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class AddDocumentForm : FormCommonNCVP
    {
        public AddDocumentForm()
        {
            InitializeComponent();
        }

        public DocumentVo vo = new DocumentVo();
        private static GetModelCbm getModelCbm = new GetModelCbm();
        private static GetDepartmentCbm getDeptCbm = new GetDepartmentCbm();
        public string fileName;

        private void AddDocumentForm_Load(object sender, EventArgs e)
        {
            //Load Document Type and Department
            ValueObjectList<DocumentVo> dctvolist = null;
            ValueObjectList<DocumentVo> deptvolist = null;
            try
            {
                dctvolist = (ValueObjectList<DocumentVo>)DefaultCbmInvoker.Invoke(new GetDocTypeCbm(), new DocumentVo());
            }
            catch (Framework.ApplicationException ex)
            {
                logger.Error(ex.GetMessageData());
                popUpMessage.ApplicationError(ex.GetMessageData(), Text);
                return;
            }
            cmbDocType.DisplayMember = "DocumentType";
            BindingSource b2 = new BindingSource(dctvolist.GetList(), null);
            cmbDocType.DataSource = b2;
            cmbDocType.Text = "";

            try
            {
                deptvolist = (ValueObjectList<DocumentVo>)DefaultCbmInvoker.Invoke(new GetDocDeptCbm(), new DocumentVo());
            }
            catch (Framework.ApplicationException ex)
            {
                logger.Error(ex.GetMessageData());
                popUpMessage.ApplicationError(ex.GetMessageData(), Text);
                return;
            }
            cmbDepartment.DisplayMember = "Department";
            BindingSource b3 = new BindingSource(deptvolist.GetList(), null);
            cmbDepartment.DataSource = b3;
            cmbDepartment.Text = "";

            //Form update
            if (vo.DocumentID > 0)
            {
                txtModel.Enabled = false;
                cmbDepartment.Enabled = false;
                txtModel.Text = vo.ModelCode;
                txtDocNo.Text = vo.DocumentNo;
                cmbDepartment.Text = vo.Department;
                txtDocName.Text = vo.DocumentName;
                cmbDocType.Text = vo.DocumentType;
            }
        }

        bool checkdata()
        {
            if (txtModel.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, model_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                txtModel.Focus();
                return false;
            }

            if (cmbDocType.SelectedItem == null)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, doc_type_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                cmbDocType.Focus();
                return false;
            }

            if (txtDocName.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, doc_name_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                txtDocName.Focus();
                return false;
            }

            if (cmbDepartment.SelectedItem == null)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, department_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                cmbDepartment.Focus();
                return false;
            }

            return true;
        }

        private void OK_btn_Click(object sender, EventArgs e)
        {
            string mcPath = @"Z:\(01)KK03\QA\(00)Public\DOCUMENT\";
            string parentPath = mcPath + cmbDocType.Text + @"\" + txtDocName.Text;

            if (!checkdata()) { return; }
            //Add or Update
            DocumentVo outVo = new DocumentVo();
            DocumentVo inVo = new DocumentVo
            {
                DocumentID = vo.DocumentID,
                Update_Date = DateTime.Now,
                ModelCode = txtModel.Text,
                DocumentNo = txtDocNo.Text,
                DocumentName = txtDocName.Text,
                DocumentType = cmbDocType.Text,
                Department = cmbDepartment.Text,
                Version = txtVersion.Text,
            };

            try
            {
                //Update Document
                if (inVo.DocumentID > 0)
                {
                    outVo = (DocumentVo)DefaultCbmInvoker.Invoke(new UpdateDocumentCbm(), inVo);
                    if (outVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmci00002", Properties.Resources.mmci00002);
                        popUpMessage.Information(messageData, "Infomation");
                    }
                }
                //Add Document
                else
                {
                    //Create folder and move file
                    if (!Directory.Exists(mcPath + cmbDocType.Text))
                    {
                        Directory.CreateDirectory(mcPath + cmbDocType.Text);
                        File.Move(linksave_txt.Text, parentPath);
                    }
                    else
                    {
                        File.Move(linksave_txt.Text, parentPath);
                    }
                    outVo = (DocumentVo)DefaultCbmInvoker.Invoke(new AddDocumentCbm(), inVo);

                    if (outVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001);
                        popUpMessage.Information(messageData, "Infomation");
                    }

                    //Refresh Form
                    Common.ResetControlValues.ResetControlValue(this);
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }
        }

        private void browser_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog o1 = new OpenFileDialog();
            o1.ShowDialog();
            txtDocName.Text = Path.GetFileName(o1.FileName);
            linksave_txt.Text = o1.FileName;
            fileName = Path.GetFileNameWithoutExtension(o1.FileName);

            string[] docName = fileName.Split('_');
            txtDocNo.Text = docName[2];
            txtModel.Text = docName[0];
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
