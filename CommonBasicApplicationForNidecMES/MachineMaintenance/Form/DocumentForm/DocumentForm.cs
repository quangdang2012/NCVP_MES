using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using Com.Nidec.Mes.Framework;
using System.Diagnostics;
using System.Data;
using System.IO;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.DocumentCbm;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class DocumentForm : FormCommonNCVP
    {
        DataGridViewButtonColumn Open;
        DataTable doc_dt;

        public DocumentForm()
        {
            InitializeComponent();
            dgvDocument.AutoGenerateColumns = false;
        }

        private void DocumentForm_Load(object sender, EventArgs e)
        {
            ValueObjectList<DocumentVo> mdlvolist = null;
            ValueObjectList<DocumentVo> dctvolist = null;
            ValueObjectList<DocumentVo> deptvolist = null;
            try
            {
                mdlvolist = (ValueObjectList<DocumentVo>)DefaultCbmInvoker.Invoke(new GetDocModelCbm(), new DocumentVo());
            }
            catch (Framework.ApplicationException ex)
            {
                logger.Error(ex.GetMessageData());
                popUpMessage.ApplicationError(ex.GetMessageData(), Text);
                return;
            }
            cmbModel.DisplayMember = "ModelCode";
            BindingSource b1 = new BindingSource(mdlvolist.GetList(), null);
            cmbModel.DataSource = b1;
            cmbModel.Text = "";

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
            doc_type_cmb.DisplayMember = "DocumentType";
            BindingSource b2 = new BindingSource(dctvolist.GetList(), null);
            doc_type_cmb.DataSource = b2;
            doc_type_cmb.Text = "";

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
            cmbDept.DisplayMember = "Department";
            BindingSource b3 = new BindingSource(deptvolist.GetList(), null);
            cmbDept.DataSource = b3;
            cmbDept.Text = "";

            addButtonTodgv(dgvDocument);
        }

        private void initForm()
        {
            ValueObjectList<DocumentVo> getList = (ValueObjectList<DocumentVo>)DefaultCbmInvoker.Invoke(new GetDocumentCbm(), new DocumentVo
            {
                ModelCode = cmbModel.Text,
                DocumentName = txtDocName.Text,
                DocumentNo = txtDocNo.Text,
                DocumentType = doc_type_cmb.Text,
                Department = cmbDept.Text
            });
            dgvDocument.DataSource = getList.GetList();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void addButtonTodgv(DataGridView dgv)
        {
            Open = new DataGridViewButtonColumn();
            Open.Text = "Open";
            Open.UseColumnTextForButtonValue = true;
            Open.Width = 45;
            Open.Visible = true;
            dgv.Columns.Add(Open);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddDocumentForm frmAdd = new AddDocumentForm();
            frmAdd.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string docName = dgvDocument.CurrentRow.Cells["doc_name"].Value.ToString();
            string docType = dgvDocument.CurrentRow.Cells["doc_type"].Value.ToString();
            string parentPath = @"Z:\(01)KK03\QA\(00)Public\DOCUMENT\" + docType + @"\";
            string id = dgvDocument.CurrentRow.Cells["doc_id"].Value.ToString();

            DialogResult result = MessageBox.Show("Do you really want to delete this document ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                DialogResult result1 = MessageBox.Show("This action will delete the document file! Please click 'NO' if you don't want to delete it!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result1 == DialogResult.Yes)
                {
                    try
                    {
                        DocumentVo docvo = (DocumentVo)DefaultCbmInvoker.Invoke(new DeleteDocumentCmb(), new DocumentVo
                        {
                            DocumentID = int.Parse(id)
                        });
                        File.Delete(parentPath + docName);
                        MessageBox.Show("This document is deleted!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                        initForm();
                    }
                    catch (Framework.ApplicationException ex)
                    {
                        logger.Error(ex.GetMessageData());
                        popUpMessage.ApplicationError(ex.GetMessageData(), Text);
                        return;
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvDocument.SelectedCells.Count > 0)
            {
                DocumentVo selectedvo = (DocumentVo)dgvDocument.CurrentRow.DataBoundItem;
                if (new AddDocumentForm { vo = selectedvo }.ShowDialog() != DialogResult.OK)
                {
                    initForm();
                }
            }
        }

        private void dgvDocument_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string docName = dgvDocument.CurrentRow.Cells["doc_name"].Value.ToString();
            string docType = dgvDocument.CurrentRow.Cells["doc_type"].Value.ToString();
            string parentPath = @"Z:\(01)KK03\QA\(00)Public\DOCUMENT\" + docType + @"\";

            if (dgvDocument.Columns[e.ColumnIndex] == Open)
            {
                Process prc = new Process();
                try
                {
                    prc.StartInfo.FileName = parentPath + docName;
                    prc.Start();
                }
                catch { }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            initForm();
        }
    }
}