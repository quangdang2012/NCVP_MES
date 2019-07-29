using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;


namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class UserRoleForm
    {
        #region Variables

        /// <summary>
        /// initialize vo
        /// </summary>
        private readonly RoleVo roleInVo = new RoleVo();

        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger Logger = CommonLogger.GetInstance(typeof(UserRoleForm));

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        #endregion

        #region Constructor
        /// <summary>
        /// constructor
        /// </summary>
        public UserRoleForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Adds new user role
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="roleCode"></param>
        private void AddUserRole(string userCode, string roleCode)
        {
            UserRoleVo userRoleInVo = new UserRoleVo
            {
                UserCode = userCode,
                RoleCode = roleCode,
                //RegistrationDateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                RegistrationUserCode = UserData.GetUserData().UserCode,
                FactoryCode = UserData.GetUserData().FactoryCode
            };

            UserRoleVo userRoleOutVo = new UserRoleVo();

            try
            {
                userRoleOutVo = (UserRoleVo)base.InvokeCbm(new AddUserRoleMasterMntCbm(), userRoleInVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                Logger.Error(exception.GetMessageData());
                return;
            }
        }

        /// <summary>
        /// Updates user role
        /// </summary>
        private void UpdateUserRole()
        {
            string userCode;
            string roleCode;

            TreeNodeCollection nodes = UserRoleDetails_tv.Nodes;

            UserRoleVo userRoleCheckVo = new UserRoleVo();

            try
            {
                userRoleCheckVo = (UserRoleVo)base.InvokeCbm(new GetUserRoleMasterMntCbm(), new UserRoleVo(), false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                Logger.Error(exception.GetMessageData());
                return;
            }

            foreach (TreeNode tn in nodes)
            {
                foreach (TreeNode child in tn.Nodes)
                {
                    userCode = tn.Tag.ToString();
                    roleCode = child.Tag.ToString();

                    var userRoleCount = userRoleCheckVo.UserRoleListVo.Count(t => t.UserCode == userCode && t.RoleCode == roleCode);

                    if (child.Checked)
                    {
                        if (userRoleCount == 0)
                        {
                            AddUserRole(userCode, roleCode);
                        }
                    }
                    else
                    {
                        if (userRoleCount == 1)
                        {
                            DeleteUserRole(userCode, roleCode);
                        }
                    }
                }
            }

            messageData = new MessageData("mmci00002", Properties.Resources.mmci00002, null);
            Logger.Info(messageData);
            popUpMessage.Information(messageData, Text);
        }

        /// <summary>
        /// Deletes user role
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="roleCode"></param>
        private void DeleteUserRole(string userCode, string roleCode)
        {
            UserRoleVo userRoleInVo = new UserRoleVo
            {
                UserCode = userCode,
                RoleCode = roleCode
            };

            UserRoleVo userRoleOutVo = new UserRoleVo();

            try
            {
                userRoleOutVo = (UserRoleVo)base.InvokeCbm(new DeleteUserRoleMasterMntCbm(), userRoleInVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                Logger.Error(exception.GetMessageData());
                return;
            }
        }

        /// <summary>
        /// Binds tree view with user 
        /// </summary>
        private void BindTreeView()
        {
            UserVo userInVo = new UserVo();
            if (User_cmb.SelectedIndex == -1)
            {
                messageData = new MessageData("mmci00014", Properties.Resources.mmci00014, null);
                //Logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                return;
            }  
            if (User_cmb.Text != string.Empty && User_cmb.SelectedIndex > -1)
            {
                userInVo.UserName = User_cmb.SelectedValue.ToString();
                string strUserCode = User_cmb.Text.ToString();
                string[] tokens = strUserCode.Split(':');
                userInVo.UserCode = tokens[0].ToString();
            }

            UserVo userOutVo = new UserVo();

            try
            {
                userOutVo = (UserVo)base.InvokeCbm(new GetUserMasterMntCbm(), userInVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                Logger.Error(exception.GetMessageData());
                return;
            }

            PopulateTreeView(userOutVo.UserListVo);
        }

        /// <summary>
        /// Binds tree view with role 
        /// </summary>
        /// <param name="userList"></param>
        private void PopulateTreeView(List<UserVo> userList)
        {
            RoleVo roleOutVo = new RoleVo();

            AuthorityControlVo authorityOutVo = new AuthorityControlVo();

            try
            {
                roleOutVo = (RoleVo)base.InvokeCbm(new GetRoleMasterMntCbm(), roleInVo, false);

                AuthorityControlVo authorityInVo = new AuthorityControlVo();
           
                authorityOutVo = (AuthorityControlVo)base.InvokeCbm(new GetAuthorityControlMasterMntCbm(), authorityInVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                Logger.Error(exception.GetMessageData());
                return;
            }

            UserRoleDetails_tv.Nodes.Clear();

            TreeNode[] headerNode = new TreeNode[userList.Count];

            int i = 0;

            foreach (UserVo user in userList)
            {
                TreeNode child = new TreeNode
                {
                    Text = user.UserCode + ": " + user.UserName,
                    Tag = user.UserCode
                };

                headerNode[i] = child;

                int childNodes = roleOutVo.RoleListVo.Count;

                TreeNode[] rootNodes = new TreeNode[childNodes];

                int node = 0;

                //UserRoleVo userRoleInVo = new UserRoleVo();

                UserRoleVo userRoleOutVo = new UserRoleVo();

                try
                {
                    userRoleOutVo = (UserRoleVo)base.InvokeCbm(new GetUserRoleMasterMntCbm(), new UserRoleVo(), false);
                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    Logger.Error(exception.GetMessageData());
                    return;
                }

                foreach (RoleVo role in roleOutVo.RoleListVo)
                {
                    TreeNode rootChild = new TreeNode
                    {
                        Text = role.RoleCode + ": " + role.RoleName,
                        Tag = role.RoleCode
                    };

                    List<UserRoleVo> userRoleList = userRoleOutVo.UserRoleListVo.Where(t => t.UserCode == child.Tag.ToString()).ToList();

                    foreach (UserRoleVo userRole in userRoleList)
                    {
                        if (userRole.RoleCode == rootChild.Tag.ToString())
                        {
                            rootChild.Checked = true;
                        }
                    }

                    rootNodes[node] = rootChild;

                    headerNode[i].Nodes.Add(rootNodes[node]);

                    RoleAuthorityControlVo roleAuthorityOutVo = new RoleAuthorityControlVo();

                    try
                    {
                        roleAuthorityOutVo = (RoleAuthorityControlVo)base.InvokeCbm(new GetRoleAuthorityControlMasterMntCbm(), new RoleAuthorityControlVo(), false);
                    }
                    catch (Framework.ApplicationException exception)
                    {
                        popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                        Logger.Error(exception.GetMessageData());
                        return;
                    }

                    List<RoleAuthorityControlVo> roleAuthorityList = roleAuthorityOutVo.RoleAuthorityControlListVo.Where(t => t.RoleCode == rootChild.Tag.ToString()).ToList();

                    int authorityNodes = roleAuthorityList.Count;

                    TreeNode[] authorityRootNodes = new TreeNode[authorityNodes];

                    int subnode = 0;

                    foreach (RoleAuthorityControlVo roleAuth in roleAuthorityList)
                    {
                        AuthorityControlVo authVo = authorityOutVo.AuthorityControlListVo.Where(t => t.AuthorityControlCode == roleAuth.AuthorityControlCode).ToList().First();

                        TreeNode authorityChild = new TreeNode
                        {
                            Text = authVo.AuthorityControlCode + ": " + authVo.AuthorityControlName,
                            Tag = authVo.AuthorityControlCode
                        };

                        authorityRootNodes[subnode] = authorityChild;

                        rootNodes[node].Nodes.Add(authorityRootNodes[subnode]);

                        subnode += 1;
                    }

                    node += 1;
                }

                UserRoleDetails_tv.Nodes.Add(headerNode[i]);

                i += 1;
            }
        }

        /// <summary>
        /// Loads User Code and User name
        /// </summary>
        /// <summary>
        /// Loads User Detail
        /// </summary>
        private void LoadUserCode()
        {
            UserVo userInVo = new UserVo();
            try
            {
                UserVo userOutVo = (UserVo)base.InvokeCbm(new GetUserMasterMntCbm(), userInVo, false);

                ComboBind(User_cmb, userOutVo.UserListVo, "UserDetail", "UserName");
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                Logger.Error(exception.GetMessageData());
            }
        }

        /// <summary>
        /// For binding combo box
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
        #endregion

        #region FormEvents
        /// <summary>
        /// form load, binds treee view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserRoleForm_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;           
            LoadUserCode();
            Update_btn.Enabled = false;
            Cursor.Current = Cursors.Default;
            User_cmb.Select();
        }
      
        #endregion

        #region ButtonClick

        /// <summary>
        /// update user role to db and binds tree view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_btn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UpdateUserRole();
            BindTreeView();
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// search roles for user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_btn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            BindTreeView();
            Update_btn.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// cleares input controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_btn_Click(object sender, EventArgs e)
        {
            //UserName_txt.Text = string.Empty;
            //UserCode_txt.Text = string.Empty;
            User_cmb.SelectedIndex = -1;
            UserRoleDetails_tv.Nodes.Clear();
        }

        /// <summary>
        /// close form on exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region ControlEvents
        /// <summary>
        /// sets selected node as parent node on change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserRoleDetails_tv_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                UserRoleDetails_tv.SelectedNode = e.Node;
            }
        }

        /// <summary>
        /// draws node checkbox as '+'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserRoleDetails_tv_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                int d = (int)(0.2 * e.Bounds.Height);
                Rectangle rect = new Rectangle(d + UserRoleDetails_tv.Margin.Left, d + e.Bounds.Top, e.Bounds.Height - d * 2, e.Bounds.Height - d * 2);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromKnownColor(KnownColor.Control)), rect);
                e.Graphics.DrawRectangle(Pens.Silver, rect);
                StringFormat sf = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };
                e.Graphics.DrawString(e.Node.IsExpanded ? "-" : "+", UserRoleDetails_tv.Font, new SolidBrush(Color.Blue), rect, sf);
                //Draw the dotted line connecting the expanding/collapsing button and the node Text
                using (Pen dotted = new Pen(Color.Black) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dot })
                {
                    e.Graphics.DrawLine(dotted, new Point(rect.Right + 1, rect.Top + rect.Height / 2), new Point(rect.Right + 4, rect.Top + rect.Height / 2));
                }
                //Draw text
                sf.Alignment = StringAlignment.Near;
                Rectangle textRect = new Rectangle(e.Bounds.Left + rect.Right + 4, e.Bounds.Top, e.Bounds.Width - rect.Right - 4, e.Bounds.Height);
                if (e.Node.IsSelected)
                {
                    SizeF textSize = e.Graphics.MeasureString(e.Node.Text, UserRoleDetails_tv.Font);
                    e.Graphics.FillRectangle(new SolidBrush(SystemColors.Highlight), new RectangleF(textRect.Left, textRect.Top, textSize.Width, textRect.Height));
                }
                e.Graphics.DrawString(e.Node.Text, UserRoleDetails_tv.Font, new SolidBrush(UserRoleDetails_tv.ForeColor), textRect, sf);
            }
            else e.DrawDefault = true;

            if (e.Node.Level == 2)
            {
                e.Node.HideCheckBox();
            }
        }
        #endregion
    }

    /// <summary>
    /// extension class for tree view
    /// </summary>
    public static class TreeViewExtensions
    {
        private const int TVIF_STATE = 0x8;
        private const int TVIS_STATEIMAGEMASK = 0xF000;
        private const int TV_FIRST = 0x1100;
        private const int TVM_SETITEM = TV_FIRST + 63;

        [StructLayout(LayoutKind.Sequential, Pack = 8, CharSet = CharSet.Auto)]
        private struct Tvitem
        {
            public int mask;
            public IntPtr hItem;
            public int state;
            public int stateMask;
            [MarshalAs(UnmanagedType.LPTStr)] private readonly string lpszText;

            private readonly int cchTextMax;
            private readonly int iImage;
            private readonly int iSelectedImage;
            private readonly int cChildren;
            private readonly IntPtr lParam;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, ref Tvitem lParam);

        /// <summary>
        /// Hides the checkbox for the specified node on a TreeView control.
        /// </summary>
        public static void HideCheckBox(this TreeNode node)
        {
            Tvitem tvi = new Tvitem
            {
                hItem = node.Handle,
                mask = TVIF_STATE,
                stateMask = TVIS_STATEIMAGEMASK,
                state = 0
            };
            SendMessage(node.TreeView.Handle, TVM_SETITEM, IntPtr.Zero, ref tvi);
        }
    }
}
