using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Framework_Batch.Cbm;
using Com.Nidec.Mes.Framework_Batch.Vo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Com.Nidec.Mes.Framework_Batch
{
    public partial class ChangeBatchProcessStatusForm : Com.Nidec.Mes.Framework.FormCommon
    {
        #region Variables

        #region Common Variables

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(ChangeBatchProcessStatusForm));

        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;

        #endregion

        #region Member
        List<AddBatchProcessVo> CurrentData = new List<AddBatchProcessVo>();
        List<AddBatchProcessVo> DeletedData = new List<AddBatchProcessVo>();
        #endregion

        #endregion

        #region Constructor
        public ChangeBatchProcessStatusForm()
        {
            InitializeComponent();
        }
        private void ChangeBatchProcessStatusForm_Load(object sender, EventArgs e)
        {
            //Get Data
            LoadBatchProcessData();
            DispayData(CurrentData);
        }
        private bool LoadBatchProcessData()
        {
            try
            {
                CurrentData = ((ValueObjectList<AddBatchProcessVo>)DefaultCbmInvoker.Invoke(new GetBatchProcessDataCompletelyCbm(), null)).GetList();
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return false;
            }
            return true;
        }
        #endregion

        #region User Control

        #region Button Event
        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Status_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            //"Stop"列ならば、ボタンがクリックされた
            if (dgv.Columns[e.ColumnIndex].Name == "colStop")
            {
                AddBatchProcessVo selectedVo = (AddBatchProcessVo)Status_dgv.SelectedRows[0].DataBoundItem;
                MessageData messageData = new MessageData("fbci00013", Properties.Resources.fbci00013);
                DialogResult result = popUpMessage.ConfirmationOkCancel(messageData, Text);
                if (result != DialogResult.OK) return;
                ChangeStatusProcess(selectedVo);
                LoadBatchProcessData();
                DispayData(CurrentData);
            }
        }
        private void Revert_btn_Click(object sender, EventArgs e)
        {
            if (DeletedData.Count <= 0)
            {
                MessageData messageData = new MessageData("fbci00010", Properties.Resources.fbci00010);
                popUpMessage.Information(messageData, Text);
                logger.Error(messageData);
            }
            InsertData(DeletedData[DeletedData.Count - 1]);
            DeletedData.RemoveAt(DeletedData.Count - 1);
            ReDisplayData();
        }
        private void Delete_btn_Click(object sender, EventArgs e)
        {
            if(Status_dgv.Rows.Count <= 0) return;
            AddBatchProcessVo selectedVo = (AddBatchProcessVo)Status_dgv.SelectedRows[0].DataBoundItem;
            MessageData messageData = new MessageData("fbci00011", Properties.Resources.fbci00011);
            DialogResult result = popUpMessage.ConfirmationOkCancel(messageData, Text);
            if (result != DialogResult.OK) return;
            DeleteRow(selectedVo);
        }
        private void Refresh_btn_Click(object sender, EventArgs e)
        {
            ReDisplayData();
        }
        #endregion

        #endregion

        #region Tool Method
        private void ReDisplayData()
        {
            LoadBatchProcessData();
            DispayData(CurrentData);
        }
        private void DispayData(List<AddBatchProcessVo> argVoList)
        {
            Status_dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            Status_dgv.AutoGenerateColumns = false;
            Delete_btn.Enabled = true;
            try
            {
                Status_dgv.DataSource = argVoList;
                if(argVoList.Count<=0)Delete_btn.Enabled = false;
            }
            catch
            {
                Status_dgv.DataSource = new List<AddBatchProcessVo>();
                Delete_btn.Enabled = false;
            }
        }
        #endregion

        #region Process Method
        private bool ChangeStatusProcess(AddBatchProcessVo argVo)
        {
            argVo.IsStopRequested = true;
            try
            {
                UpdateResultVo result = (UpdateResultVo)DefaultCbmInvoker.Invoke(new UpdateBatchProcessCbm(), argVo);
                if (result.AffectedCount <= 0)
                {
                    MessageData messageData = new MessageData("fbce00056", Properties.Resources.fbce00056);
                    popUpMessage.Information(messageData, Text);
                    logger.Error(messageData);
                    return false;
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return false;
            }
            return true;
        }
        private bool DeleteRow(AddBatchProcessVo argVo)
        {
            //delete data from data base
            if (DeleteDataFromDB(argVo) == false) return false;
            //insert data to 
            DeletedData.Add(argVo);
            LoadBatchProcessData();
            DispayData(CurrentData);
            return true;
        }
        private bool DeleteDataFromDB(AddBatchProcessVo argVo)
        {
            try
            {
                UpdateResultVo result = (UpdateResultVo)DefaultCbmInvoker.Invoke(new DeleteBatchProcessCbm(), argVo);
                if (result.AffectedCount <= 0)
                {
                    MessageData messageData = new MessageData("fbce00048", Properties.Resources.fbce00048);
                    popUpMessage.Information(messageData, Text);
                    logger.Error(messageData);
                    return false;
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return false;
            }
            return true;
        }
        private bool InsertData(AddBatchProcessVo argVo)
        {
            try
            {
                UpdateResultVo result = (UpdateResultVo)DefaultCbmInvoker.Invoke(new AddBatchProcessCbm(), argVo);
                if (result.AffectedCount <= 0)
                {
                    MessageData messageData = new MessageData("fbce00049", Properties.Resources.fbce00049);
                    popUpMessage.Information(messageData, Text);
                    logger.Error(messageData);
                    return false;
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return false;
            }
            return true;
        }
        #endregion
    }
}
