using DataBase;
using DataBase.MySql;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DayDayWinForm.Pages.Option
{
    public partial class option_munes : UserControl
    {
        public option_munes()
        {
            InitializeComponent();
        }
        private void option_munes_Load(object sender, EventArgs e)
        {
            list = Sugar.MySql.Queryable<menus>().ToList();
            BindList();
        }
        private int GetId(TreeNode node)
        {
            if (node == null) return 0;
            return int.Parse(node.Name.Replace("node", ""));
        }
        #region 显示列表
        List<menus> list = new List<menus>();
        private void BindList(int ParentId = 0)
        {

            TreeNode parent = tvmenus.Nodes.Find("node" + ParentId, true).FirstOrDefault();

            foreach (menus item in list.Where(m => m.ParentId == ParentId))
            {
                TreeNode node = new TreeNode();
                node.Name = "node" + item.Id;
                node.Text = item.Name;

                if (ParentId == 0)
                {
                    tvmenus.Nodes.Add(node);
                }
                else
                {
                    parent.Nodes.Add(node);
                }

                BindList(item.Id);

            }
        }
        private void BindInfo(int id = 0)
        {
            if (id == 0)
            {
                txtName.Text = string.Empty;
                txtCode.Text = string.Empty;
                cbType.SelectedItem = string.Empty;
                cbAutoStart.Checked = false;
                txtSort.Text = 0.ToString();
            }
            else
            {
                var info = list.FirstOrDefault(i => i.Id == id);
                txtName.Text = info.Name;
                txtCode.Text = info.Code;
                cbType.SelectedItem = info.ShowType;
                cbAutoStart.Checked = info.AutoStart == 1;
                txtSort.Text = info.Sort.ToString();
            }
        }
        private void tvmenus_MouseDown(object sender, MouseEventArgs e)
        {
            // 获取点击位置的节点
            TreeNode clickedNode = tvmenus.GetNodeAt(e.Location);

            // 如果点击位置没有节点（即空白区域）
            if (clickedNode == null)
            {
                BindInfo();
                tvmenus.SelectedNode = null;
            }
        }
        private void tvmenus_AfterSelect(object sender, TreeViewEventArgs e)
        {
            BindInfo(GetId(e.Node));
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tvmenus.SelectedNode == null)
            {
                MessageBox.Show("请选择项");
                return;
            }
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                MessageBox.Show("请填写菜单名称");
                return;
            }
            if (string.IsNullOrEmpty(txtCode.Text.Trim()))
            {
                MessageBox.Show("请填写开发代码");
                return;
            }
            int outid = 0;
            if (!int.TryParse(txtSort.Text.Trim(),out outid))
            {
                MessageBox.Show("请填写整数序号");
                return;
            }

            var menu=list.FirstOrDefault(m => m.Id == GetId(tvmenus.SelectedNode));

            if (list.Any(m => m.Id != menu.Id && (m.Code == txtCode.Text.Trim())))
            {
                MessageBox.Show("已存在重复的开发代码");
                return;
            }

            tvmenus.SelectedNode.Text = txtName.Text.Trim();
            menu.Name = txtName.Text.Trim();
            menu.Code = txtCode.Text.Trim();
            menu.ShowType = cbType.SelectedItem.ToString();
            menu.AutoStart = cbAutoStart.Checked ? 1 : 0;
            menu.Sort = outid;
            Sugar.MySql.Updateable(menu).ExecuteCommand();
            MessageBox.Show("操作成功");

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                MessageBox.Show("请填写菜单名称");
                return;
            }
            if (string.IsNullOrEmpty(txtCode.Text.Trim()))
            {
                MessageBox.Show("请填写开发代码");
                return;
            }
            if (list.Any(m => m.Code == txtCode.Text.Trim()))
            {
                MessageBox.Show("已存在重复的开发代码");
                return;
            }

            int parentid = GetId(tvmenus.SelectedNode);
            var border = list.Where(m => m.ParentId == parentid).ToList();

            menus newm = new menus();
            newm.Name = txtName.Text.Trim();
            newm.Code = txtCode.Text.Trim();
            newm.Sort = border.Count > 0 ? (border.Max(m => m.Sort) + 1) : 0;//计算排序号
            newm.ParentId = parentid;
            newm.ShowType = cbType.SelectedItem.ToString();
            newm.AutoStart = cbAutoStart.Checked ? 1 : 0;
            newm = Sugar.MySql.Insertable(newm).ExecuteReturnEntity();
            list.Add(newm);

            tvmenus.Nodes.Clear();
            BindList();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (tvmenus.SelectedNode == null)
            {
                MessageBox.Show("请选择删除项");
                return;
            }

            if (MessageBox.Show($"您确定要删除“{tvmenus.SelectedNode.Text}”菜单吗?","DayDayUp",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                
                int id = GetId(tvmenus.SelectedNode);
                var del = list.FirstOrDefault(d => d.Id ==id);
                Sugar.MySql.Deleteable(del).ExecuteCommand();
                list.Remove(del);
                DelChild(id);

                tvmenus.Nodes.Clear();
                BindList();
                MessageBox.Show("操作成功");
            } 
        }
        private void DelChild(int parentid)
        {
            List<menus> dels = list.Where(d => d.ParentId == parentid).ToList();
            foreach (var del in dels)
            {
                Sugar.MySql.Deleteable(del).ExecuteCommand();
                list.Remove(del);
                DelChild(del.Id);
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (tvmenus.SelectedNode == null)
            {
                MessageBox.Show("请选择移动项");
                return;
            }
         
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            MessageBox.Show(tvmenus.SelectedNode.Text);
        }

        private void btnChangeParent_Click(object sender, EventArgs e)
        {
            MessageBox.Show(tvmenus.SelectedNode.Text);
        }
    }
}
