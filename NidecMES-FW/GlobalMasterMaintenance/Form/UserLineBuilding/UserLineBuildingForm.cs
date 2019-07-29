using System;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using System.Resources;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Drawing;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class UserLineBuildingForm
    {
        #region Variables

        /// <summary>
        /// Check for Database operation success
        /// </summary>
        public int IntSuccess = -1;
        public int IntDelSuccess = -1;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddProcessForm));

        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;

        private bool isBuildingListLoading = false;

        private ValueObjectList<UserLineBuildingVo> LineBuildingMasterVo = null;
        #endregion

        #region Constructor
        /// <summary>
        /// constructor for the form
        /// </summary>
        /// <param name="pmode"></param>
        /// <param name="dataItem"></param>
        public UserLineBuildingForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Handles Combobox loading
        /// </summary>
        /// <param name="pCombo"></param>
        /// <param name="pDatasource"></param>
        /// <param name="pDisplay"></param>
        /// <param name="pValue"></param>
        private void ComboBind<T>(ComboBox pCombo, List<T> pDatasource, string pDisplay, string pValue)
        {
            pCombo.DataSource = pDatasource;
            pCombo.DisplayMember = pDisplay;
            pCombo.ValueMember = pValue;
            pCombo.SelectedIndex = -1;
            pCombo.Text = string.Empty;
        }

        /// <summary>
        /// Load User Name
        /// </summary>
        private void LoadUserCombo()
        {
            UserVo userOutVo = null;

            try
            {
                userOutVo = (UserVo)DefaultCbmInvoker.Invoke(new GetUserMasterMntCbm(), new UserVo());
                //userOutVo.UserListVo.ForEach(p => p.UserName = p.UserCode + " " + p.UserName);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            ComboBind(User_cmb, userOutVo.UserListVo, "UserName", "UserCode");
        }

        /// <summary>
        /// Get Building data.
        /// </summary>
        private void GetBuilding()
        {
            BuildingVo outVo = new BuildingVo();

            try
            {
                outVo = (BuildingVo)base.InvokeCbm(new GetBuildingMasterMntCbm(), new BuildingVo(), false);
                outVo.BuildingListVo.ForEach(p => p.BuildingName = p.BuildingId + " " + p.BuildingName);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }

            if (outVo.BuildingListVo.Count > 0)
            {
                isBuildingListLoading = true;
                Building_lst.DataSource = outVo.BuildingListVo;
                Building_lst.DisplayMember = "BuildingName";
                Building_lst.ValueMember = "BuildingId";
                Building_lst.SelectedIndex = -1;
                isBuildingListLoading = false;
                Update_btn.Enabled = true;
            }

        }

        /// <summary>
        /// Get Line Data.
        /// </summary>
        private void LoadLineListBox()
        {
            this.Cursor = Cursors.WaitCursor;

            Line_chlst.DataSource = null;

            UserLineBuildingVo inVo = new UserLineBuildingVo();

            inVo.BuildingId = Convert.ToInt32(Building_lst.SelectedValue.ToString());
            try
            {
                LineBuildingMasterVo = (ValueObjectList<UserLineBuildingVo>)base.InvokeCbm(new GetUserLineBuildingMasterMntCbm(), inVo, false);
            }
            catch(Framework.ApplicationException ex)
            {
                logger.Info(ex.GetMessageData());
                popUpMessage.ApplicationError(ex.GetMessageData(), Text);
            }

            if (LineBuildingMasterVo == null || LineBuildingMasterVo.GetList() == null || LineBuildingMasterVo.GetList().Count == 0)
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, Line_lbl.Text);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                Update_btn.Enabled = false;
                this.Cursor = Cursors.Default;
                return;
            }
            List<UserLineBuildingVo> FilteruserlinebuildingVo = LineBuildingMasterVo.GetList().GroupBy(t => new { t.LineId })
                                                                      .Select(g => new UserLineBuildingVo
                                                                      {
                                                                          LineId = g.First().LineId,
                                                                          LineBuildingId = g.First().LineBuildingId,
                                                                          BuildingId = g.First().BuildingId,
                                                                          BuildingCode = g.First().BuildingCode,
                                                                          BuildingName = g.First().BuildingName,
                                                                          LineCode = g.First().LineCode,
                                                                          LineName = g.First().LineCode + " " + g.First().LineName,
                                                                      }).ToList();

            if (FilteruserlinebuildingVo.Count > 0)
            {
                Line_chlst.DataSource = FilteruserlinebuildingVo.OrderBy(o => o.LineCode).ToList();
                Line_chlst.DisplayMember = "LineName";
                Line_chlst.ValueMember = "LineId";
                Update_btn.Enabled = true;
            }
            else
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, Line_lbl.Text);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                Update_btn.Enabled = false;

            }

            UserLineBuildingVo chekLineIdVo;

            Line_chlst.ClearSelected();

            if (LineBuildingMasterVo != null || LineBuildingMasterVo.GetList() != null || LineBuildingMasterVo.GetList().Count > 0)
            {
                for (int i = 0; i < Line_chlst.Items.Count; i++)
                {
                    UserLineBuildingVo currline = (UserLineBuildingVo)Line_chlst.Items[i];
                    chekLineIdVo = LineBuildingMasterVo.GetList().Where(t => t.LineId == currline.LineId && t.UserCode == User_cmb.SelectedValue.ToString()).FirstOrDefault();

                    if (chekLineIdVo == null)
                    {
                        continue;
                    }

                    if (chekLineIdVo.UserLineBuildingId > 0)
                    {
                        Line_chlst.SetItemChecked(i, true);
                    }
                }
            }
            this.Cursor = Cursors.Default;

        }

        /// <summary>
        /// Checks mandatory fields
        /// </summary>
        /// <returns></returns>
        private bool CheckMandatory()
        {
            if (Building_lst.SelectedValue == null || Building_lst.SelectedValue.ToString() == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, Building_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                Building_lst.Focus();

                return false;
            }

            if (User_cmb.SelectedIndex < 0)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, User_cmb.Text);
                popUpMessage.Warning(messageData, Text);

                Building_lst.Focus();

                return false;
            }

            return true;
        }

        /// <summary>
        /// checks duplicate Line Building
        /// </summary>
        /// <param name="usrBuildingLineVo"></param>
        /// <returns></returns>
        private UserLineBuildingVo DuplicateCheck(UserLineBuildingVo usrBuildingLineVo)
        {
            UserLineBuildingVo outVo = new UserLineBuildingVo();

            try
            {
                outVo = (UserLineBuildingVo)base.InvokeCbm(new CheckUserLineBuildingMasterMntCbm(), usrBuildingLineVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            return outVo;
        }
        #endregion

        #region FormEvents
        /// <summary>
        /// load the screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserLineBuildingForm_Load(object sender, EventArgs e)
        {
            LoadUserCombo();
            GetBuilding();
            //Building_lst.ClearSelected();
        }

        /// <summary>
        /// Building List Selected Index Change.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Building_lst_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (isBuildingListLoading) return;

            if (Building_lst.SelectedIndex < 0) { return; }
            if (User_cmb.SelectedIndex < 0)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002,User_lbl.Text);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);              
                Building_lst.ClearSelected();
                return;
            }

            LoadLineListBox();
        }

        /// <summary>
        /// User Selction index change.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void User_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (User_cmb.SelectedIndex > -1 && User_cmb.DataSource != null)
            {
                Building_lst.ClearSelected();
                Line_chlst.DataSource = null;
            }
        }
        #endregion

        #region ButtonClick

        /// <summary>
        /// closes form on exit click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// inserts/updates process on ok click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_btn_Click(object sender, EventArgs e)
        {

            if (!CheckMandatory() || LineBuildingMasterVo == null || LineBuildingMasterVo.GetList() == null) return;

            UserLineBuildingVo inVo = new UserLineBuildingVo();

            inVo.UserCode = User_cmb.SelectedValue.ToString();
            inVo.LineBuildingidList = LineBuildingMasterVo.GetList().Where(t => t.BuildingId == Convert.ToInt32(Building_lst.SelectedValue)).Select(s => s.LineBuildingId).ToList();
            try
            {
                UpdateResultVo outDeleteVo = (UpdateResultVo)base.InvokeCbm(new DeleteUserLineBuildingMasterMntCbm(), inVo, false);
                IntDelSuccess = outDeleteVo.AffectedCount;
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }

            inVo.BuildingId = Convert.ToInt32(Building_lst.SelectedValue);

            UpdateResultVo outVo = new UpdateResultVo();

            foreach (UserLineBuildingVo item in Line_chlst.CheckedItems)
            {
                inVo.LineId = item.LineId;

                UserLineBuildingVo currentVo = LineBuildingMasterVo.GetList().Where(t => t.BuildingId == inVo.BuildingId && t.LineId == inVo.LineId).FirstOrDefault();

                if (currentVo == null || currentVo.LineBuildingId == 0)
                {
                    messageData = new MessageData("mmce00010", Properties.Resources.mmce00010, "LineBuildingId");
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                    return;
                }
                inVo.LineBuildingId = currentVo.LineBuildingId;              
                try
                {
                    outVo = (UpdateResultVo)base.InvokeCbm(new AddUserLineBuildingMasterMntCbm(), inVo, false);
                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                    return;
                }
            }

            IntSuccess = outVo.AffectedCount;

            if ((IntSuccess > 0) || (IntDelSuccess > 0))
            {
                messageData = new MessageData("mmci00002", Properties.Resources.mmci00002, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
            }
        }

        #endregion
    }
}
