using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class RoleAuthorityControlForm
    {
        #region Variables


        /// <summary>
        /// initialize vo
        /// </summary>
        private readonly AuthorityControlVo authorityInVo = new AuthorityControlVo();

        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(RoleAuthorityControlForm));

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// declare admin constant 
        /// </summary>
        private const string ADMIN = "admin";

        #endregion

        #region Constructor

        /// <summary>
        /// constructor
        /// </summary>
        public RoleAuthorityControlForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods
        /// <summary>
        /// checkes child nodes
        /// </summary>
        /// <param name="treeNode"></param>
        /// <param name="nodeChecked"></param>
        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }

        /// <summary>
        /// Adds new role authority
        /// </summary>
        /// <param name="roleCode"></param>
        /// <param name="authCode"></param>
        private void AddRoleAuthority(string roleCode, string authCode)
        {
            RoleAuthorityControlVo roleAuthorityInVo = new RoleAuthorityControlVo
            {
                RoleCode = roleCode,
                AuthorityControlCode = authCode,
                //RegistrationDateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                RegistrationUserCode = UserData.GetUserData().UserCode,
                FactoryCode = UserData.GetUserData().FactoryCode
            };

            try
            {
                RoleAuthorityControlVo roleAuthorityOutVo =
                    (RoleAuthorityControlVo)base.InvokeCbm(new AddRoleAuthorityControlMasterMntCbm(), roleAuthorityInVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        /// <summary>
        /// Updates role authority
        /// </summary>
        private void UpdateRoleAuthority()
        {

            TreeNodeCollection nodes = RoleAuthorityDetails_tv.Nodes;

            try
            {
                RoleAuthorityControlVo roleAuthorityCheckVo =
                    (RoleAuthorityControlVo)base.InvokeCbm(new GetRoleAuthorityControlMasterMntCbm(), new RoleAuthorityControlVo(), false);


                foreach (TreeNode tn in nodes)
                {
                    //if (IsAdminUser())
                    //{
                    //    if (!tn.Tag.Equals(ADMIN))
                    //    {
                    //        UpdateChildNode(tn.Tag.ToString(), tn.Nodes, roleAuthorityCheckVo);
                    //    }
                    //}
                    //else
                    //{
                        UpdateChildNode(tn.Tag.ToString(), tn.Nodes, roleAuthorityCheckVo);
                    //}
                }

                messageData = new MessageData("mmci00002", Properties.Resources.mmci00002, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        /// <summary>
        /// get checked data from childnodes and update to db
        /// </summary>
        /// <param name="roleCode"></param>
        /// <param name="treeNodes"></param>
        /// <param name="roleAuthorityVo"></param>
        private void UpdateChildNode(String roleCode, TreeNodeCollection treeNodes, RoleAuthorityControlVo roleAuthorityVo)
        {

            string authorityCode;

            foreach (TreeNode child in treeNodes)
            {

                authorityCode = child.Tag.ToString();

                int roleAuthorityCount =
                    roleAuthorityVo.RoleAuthorityControlListVo.Count(
                        t => t.RoleCode == roleCode && t.AuthorityControlCode == authorityCode);

                if (child.Checked)
                {
                    if (roleAuthorityCount == 0)
                    {
                        AddRoleAuthority(roleCode, authorityCode);
                    }
                }
                else
                {
                    if (roleAuthorityCount == 1)
                    {
                        DeleteRoleAuthority(roleCode, authorityCode);
                    }
                }

                UpdateChildNode(roleCode, child.Nodes, roleAuthorityVo);
            }
        }

        /// <summary>
        /// Deletes role authority
        /// </summary>
        /// <param name="roleCode"></param>
        /// <param name="authorityCode"></param>
        private void DeleteRoleAuthority(string roleCode, string authorityCode)
        {
            RoleAuthorityControlVo roleAuthorityInVo = new RoleAuthorityControlVo
            {
                RoleCode = roleCode,
                AuthorityControlCode = authorityCode
            };

            try
            {
                RoleAuthorityControlVo roleAuthorityOutVo =
                    (RoleAuthorityControlVo)base.InvokeCbm(new DeleteRoleAuthorityControlMasterMntCbm(), roleAuthorityInVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        /// <summary>
        /// Binds tree view with user 
        /// </summary>
        private void BindTreeView()
        {
            RoleVo roleInVo = new RoleVo();

            if (RoleName_txt.Text != string.Empty)
            {
                roleInVo.RoleName = RoleName_txt.Text;
            }

            try
            {
                RoleVo roleOutVo = (RoleVo)base.InvokeCbm(new GetRoleMasterMntCbm(), roleInVo, false);

                PopulateTreeView(roleOutVo.RoleListVo);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        /// <summary>
        /// Binds tree view with role 
        /// </summary>
        /// <param name="roleList"></param>
        private void PopulateTreeView(List<RoleVo> roleList)
        {

            //get authority data
            AuthorityControlVo authorityOutVo;

            try
            {
                authorityOutVo = (AuthorityControlVo)base.InvokeCbm(new GetAuthorityControlMasterMntCbm(), authorityInVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }

            RoleAuthorityControlVo roleAuthorityOutVo;

            try
            {
                roleAuthorityOutVo =
                    (RoleAuthorityControlVo)base.InvokeCbm(new GetRoleAuthorityControlMasterMntCbm(), new RoleAuthorityControlVo(), false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }

            RoleAuthorityDetails_tv.Nodes.Clear();

            TreeNode[] headerNode = new TreeNode[roleList.Count];

            int i = 0;

            foreach (RoleVo role in roleList)
            {

                TreeNode child = new TreeNode
                {
                    Text = role.RoleCode + ": " + role.RoleName,
                    Tag = role.RoleCode
                };

                headerNode[i] = child;
                List<AuthorityControlVo> parentAuthorityVo =
                    authorityOutVo.AuthorityControlListVo.Where(
                        t => string.IsNullOrEmpty(t.ParentControlCode)).ToList();

                foreach (AuthorityControlVo parentAuthority in parentAuthorityVo)
                {
                    TreeNode childTreeNode = new TreeNode();

                    childTreeNode.Text = parentAuthority.AuthorityControlCode + ": " + parentAuthority.AuthorityControlName;
                    childTreeNode.Tag = parentAuthority.AuthorityControlCode;

                    List<RoleAuthorityControlVo> roleAuthorityList =
                        roleAuthorityOutVo.RoleAuthorityControlListVo.Where(t => t.RoleCode == role.RoleCode).ToList();

                    foreach (RoleAuthorityControlVo roleAuth in roleAuthorityList)
                    {
                        if (roleAuth.AuthorityControlCode == childTreeNode.Tag.ToString())
                        {
                            childTreeNode.Checked = true;
                        }
                    }

                    PopulateChildNode(authorityOutVo.AuthorityControlListVo, roleAuthorityOutVo,
                        parentAuthority.AuthorityControlCode, role.RoleCode, childTreeNode);
                    headerNode[i].Nodes.Add(childTreeNode);
                }
                RoleAuthorityDetails_tv.Nodes.Add(headerNode[i]);

                i += 1;
            }
        }

        /// <summary>
        /// bind child treenodes
        /// </summary>
        /// <param name="authority"></param>
        /// <param name="roleAuthority"></param>
        /// <param name="parentControlCode"></param>
        /// <param name="roleCode"></param>
        /// <param name="childNode"></param>
        private void PopulateChildNode(List<AuthorityControlVo> authority, RoleAuthorityControlVo roleAuthority,
            string parentControlCode, string roleCode, TreeNode childNode)
        {
            List<AuthorityControlVo> parentAuthorityVo = authority.Where(
                                                        t => t.ParentControlCode == parentControlCode).ToList();

            TreeNode mainChildNode = childNode;

            foreach (AuthorityControlVo auth in parentAuthorityVo)
            {
                TreeNode childTreeNode = new TreeNode();

                childTreeNode.Text = auth.AuthorityControlCode + ": " + auth.AuthorityControlName;
                childTreeNode.Tag = auth.AuthorityControlCode;

                List<RoleAuthorityControlVo> roleAuthorityList =
                    roleAuthority.RoleAuthorityControlListVo.Where(t => t.RoleCode == roleCode)
                        .ToList();

                foreach (RoleAuthorityControlVo roleAuth in roleAuthorityList)
                {
                    if (roleAuth.AuthorityControlCode == childTreeNode.Tag.ToString())
                    {
                        childTreeNode.Checked = true;
                    }
                }
                mainChildNode.Nodes.Add(childTreeNode);
                List<AuthorityControlVo> childAuthorityVo = authority.Where(
                                                       t => t.ParentControlCode == auth.AuthorityControlCode
                                                       ).ToList();

                if (childAuthorityVo.Count > 0)
                {
                    PopulateChildNode(authority, roleAuthority, auth.AuthorityControlCode, roleCode, childTreeNode);
                }
            }
        }


        /// <summary>
        /// Checks user is admin
        /// </summary>
        /// <returns></returns>
        private bool IsAdminUser()
        {
            bool isAdmin = false;

            UserRoleVo userRoleOutVo = new UserRoleVo();

            UserRoleVo userRoleInVo = new UserRoleVo
            {
                UserCode = UserData.GetUserData().UserCode
            };

            try
            {
                userRoleOutVo = (UserRoleVo)base.InvokeCbm(new GetUserRoleMasterMntCbm(), userRoleInVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            List<UserRoleVo> userRoleList = userRoleOutVo.UserRoleListVo.Where(t => t.RoleCode == ADMIN).ToList();

            if (userRoleList.Count > 0)
            {
                isAdmin = true;
            }

            return isAdmin;

        }

        #endregion

        #region FormEvents
        /// <summary>
        /// load the screen with data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoleAuthorityControlForm_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            BindTreeView();
            Cursor.Current = Cursors.Default;
            RoleName_txt.Select();

            //if (IsAdminUser())
            //{
            //foreach (TreeNode tn in RoleAuthorityDetails_tv.Nodes)
            //{
            //    if (tn.Level == 0 && tn.Tag.Equals(ADMIN))
            //    {
            //        tn.HideCheckBox();

            //        foreach (TreeNode sub1 in tn.Nodes)
            //        {
            //            sub1.HideCheckBox();

            //            foreach (TreeNode sub2 in sub1.Nodes)
            //            {
            //                sub2.HideCheckBox();

            //                foreach (TreeNode sub3 in sub2.Nodes)
            //                {
            //                    sub3.HideCheckBox();
            //                }
            //            }
            //        }
            //    }
            //}
            //}
        }

        #endregion

        #region ButtonClick
        /// <summary>
        /// clear the controlvalues
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_btn_Click(object sender, EventArgs e)
        {
            RoleName_txt.Text = string.Empty;
            RoleAuthorityDetails_tv.Nodes.Clear();
        }

        /// <summary>
        /// search the data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_btn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            BindTreeView();
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// update the data to db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_btn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UpdateRoleAuthority();
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// close the form
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
        private void RoleAuthorityDetails_tv_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                RoleAuthorityDetails_tv.SelectedNode = e.Node;
            }
        }

        /// <summary>
        /// draws treeview node checkbox to '+'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoleAuthorityDetails_tv_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                int d = (int)(0.2 * e.Bounds.Height);
                Rectangle rect = new Rectangle(d + RoleAuthorityDetails_tv.Margin.Left, d + e.Bounds.Top, e.Bounds.Height - d * 2, e.Bounds.Height - d * 2);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromKnownColor(KnownColor.Control)), rect);
                e.Graphics.DrawRectangle(Pens.Silver, rect);
                StringFormat sf = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };
                e.Graphics.DrawString(e.Node.IsExpanded ? "-" : "+", RoleAuthorityDetails_tv.Font, new SolidBrush(Color.Blue), rect, sf);
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
                    SizeF textSize = e.Graphics.MeasureString(e.Node.Text, RoleAuthorityDetails_tv.Font);
                    e.Graphics.FillRectangle(new SolidBrush(SystemColors.Highlight), new RectangleF(textRect.Left, textRect.Top, textSize.Width, textRect.Height));
                }
                e.Graphics.DrawString(e.Node.Text, RoleAuthorityDetails_tv.Font, new SolidBrush(RoleAuthorityDetails_tv.ForeColor), textRect, sf);
            }
            else e.DrawDefault = true;
        }

        /// <summary>
        /// sets selected Parent node checkbox selection event as child node on change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoleAuthorityDetails_tv_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                    if (e.Node.Parent != null)
                    {
                        this.CheckAllChildNodes(e.Node, e.Node.Checked);
                    }
                    else
                    {
                        if (!e.Node.Checked)
                        {
                            this.CheckAllChildNodes(e.Node, e.Node.Checked);
                        }
                    }
                
            }

            if (e.Node.Parent != null)
            {
               TreeNode treeNode = e.Node;

                while (treeNode.Parent != null && treeNode.Parent.Level > 0)
                {
                    int nodeCount = 0;

                    foreach (TreeNode node in treeNode.Parent.Nodes)
                    {
                        if (node.Checked == true)
                        {
                            nodeCount = nodeCount + 1;
                        }
                    }

                    if (nodeCount > 0)
                    {
                        treeNode.Parent.Checked = true;
                    }
                    else
                    {
                        treeNode.Parent.Checked = false;
                    }

                    treeNode = treeNode.Parent;
                }
            }
        }

        #endregion

    }
}
