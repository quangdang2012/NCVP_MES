using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class ModelForm : FormCommonMaster
    {
        #region Variables

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(ModelForm));

        /// <summary>
        ///  get message data
        /// </summary>
        private MessageData messageData;

        #endregion

        #region Constructor
        
        /// <summary>
        /// Constructor
        /// </summary>
        public ModelForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(ModelVo conditionInVo)
        {
            Model_dgv.DataSource = null;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                ValueObjectList<ModelVo> outVo = (ValueObjectList<ModelVo>)base.InvokeCbm(new GetModelMasterMntCbm(), conditionInVo, false);

                if (outVo != null && outVo.GetList() != null && outVo.GetList().Count > 0)
                {
                    Model_dgv.AutoGenerateColumns = false;
                    BindingSource ModelSource1 = new BindingSource(outVo.GetList(), null);
                    Model_dgv.DataSource = ModelSource1;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null); //"Model"
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }
                Model_dgv.ClearSelection();

                Update_btn.Enabled = false;

                Delete_btn.Enabled = false;
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        /// <summary>
        /// Creates seacrh condition as per user inputs 
        /// </summary>
        /// <returns>search condition</returns>
        private ModelVo FormConditionVo()
        {
            ModelVo inVo = new ModelVo();

            if (ModelCode_txt.Text != string.Empty) { inVo.ModelCode = ModelCode_txt.Text; }

            if (ModelName_txt.Text != string.Empty)
            {
                inVo.ModelName = ModelName_txt.Text;
            }

            return inVo;

        }

        /// <summary>
        /// selects user record for updation and show user form
        /// </summary>
        private void BindUpdateBuildingData()
        {
            int selectedrowindex = Model_dgv.SelectedCells[0].RowIndex;

            ModelVo cavInVo = (ModelVo)Model_dgv.Rows[selectedrowindex].DataBoundItem;

            AddModelForm newAddForm = new AddModelForm(CommonConstants.MODE_UPDATE, cavInVo);

            newAddForm.ShowDialog(this);

            if (newAddForm.IntSuccess > 0)
            {
                messageData = new MessageData("mmci00002", Properties.Resources.mmci00002, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);

                GridBind(FormConditionVo());
            }
            else if (newAddForm.IntSuccess == 0)
            {
                messageData = new MessageData("mmci00007", Properties.Resources.mmci00004, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                GridBind(FormConditionVo());
            }
        }

        /// <summary>
        /// checks mold model relation to other tables in DB
        /// </summary>
        /// <param name="moVo"></param>
        /// <returns></returns>
        private ModelVo CheckRelation(ModelVo moVo)
        {
            ModelVo outVo = new ModelVo();

            try
            {
                this.Cursor = Cursors.WaitCursor;
                outVo = (ModelVo)base.InvokeCbm(new CheckModelRelationCbm(), moVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            this.Cursor = Cursors.WaitCursor;

            return outVo;
        }

        #endregion

        #region FormEvents
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModelForm_Load(object sender, EventArgs e)
        {
            ModelCode_txt.Select();

            Update_btn.Enabled = Delete_btn.Enabled = false;
        }

        #endregion

        #region ButtonEvents

        /// <summary>
        /// search data from DB and load to grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_btn_Click(object sender, EventArgs e)
        {
            GridBind(FormConditionVo());
        }

        /// <summary>
        /// add new record to DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_btn_Click(object sender, EventArgs e)
        {
            AddModelForm newAddForm = new AddModelForm(CommonConstants.MODE_ADD, null);

            newAddForm.ShowDialog();

            if (newAddForm.IntSuccess > 0)
            {
                messageData = new MessageData("mmci00001", Properties.Resources.mmci00001, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);

                GridBind(FormConditionVo());
            }
        }

        /// <summary>
        /// clear contents for input controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_btn_Click(object sender, EventArgs e)
        {
            ModelCode_txt.Text = string.Empty;

            ModelName_txt.Text = string.Empty;

            Model_dgv.DataSource = null;

            ModelCode_txt.Select();
            Update_btn.Enabled = Delete_btn.Enabled = false;
        }

        /// <summary>
        /// update record to DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_btn_Click(object sender, EventArgs e)
        {
            BindUpdateBuildingData();
        }

        /// <summary>
        /// delete record from DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_btn_Click(object sender, EventArgs e)
        {
            int selectedrowindex = Model_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = Model_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colModelCode"].Value.ToString());
            logger.Info(messageData);
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);


            if (dialogResult == DialogResult.OK)
            {
                ModelVo inVo = new ModelVo();

                inVo.ModelId = Convert.ToInt32(selectedRow.Cells["colModelId"].Value);
                inVo.ModelCode = selectedRow.Cells["colModelCode"].Value.ToString();

                try
                {
                    ModelVo checkVo = CheckRelation(inVo);
                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00007", Properties.Resources.mmce00007, "Mold");
                        popUpMessage.Information(messageData, Text);
                        return;
                    }

                    //this.StartProgress(Properties.Resources.mmci00013);

                    ModelVo outVo = (ModelVo)base.InvokeCbm(new DeleteModelMasterMntCbm(), inVo, false);

                    //this.CompleteProgress();

                    if (outVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmci00003", Properties.Resources.mmci00003, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);

                        GridBind(FormConditionVo());
                    }
                    else if (outVo.AffectedCount == 0)
                    {
                        messageData = new MessageData("mmci00007", Properties.Resources.mmci00004, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                        GridBind(FormConditionVo());
                    }
                }
                catch (Framework.ApplicationException exception)
                {
                    //this.CompleteProgress();
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                //do something else
            }
        }

        /// <summary>
        /// close form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region ControlEvents

        /// <summary>
        /// selects a row in grid view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Model_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Model_dgv.SelectedRows.Count > 0)
            {
                Update_btn.Enabled = Delete_btn.Enabled = true;
            }
            else
            {
                Update_btn.Enabled = Delete_btn.Enabled = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Model_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Model_dgv.SelectedRows.Count > 0)
            {
                BindUpdateBuildingData();
            }
        }

        #endregion
    }
}
