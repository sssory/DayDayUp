using DataBase.MySql;
using DataBase;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DayDayWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadMenus();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #region 头部菜单
        List<menus> list = new List<menus>();
        private void LoadMenus()
        {
            menu_head.Items.Clear();

            list = SguarBll.GetList<menus>();
            foreach (var item in list.Where(m => m.ParentId == 0).OrderBy(m => m.Sort))
            {
                MenuItem newItem = new MenuItem();
                newItem.Header = item.Name;
                newItem.Name = item.Code;
                newItem.Tag = item.Id.ToString();
                newItem.Click += (send, e) => NewItem_Click(send, e, item);
                LoadMenusChild(newItem);
                menu_head.Items.Add(newItem);
            }
        }


        private void LoadMenusChild(MenuItem parent)
        {
            var child = list.Where(c => c.ParentId == int.Parse(Convert.ToString(parent.Tag))).OrderBy(c => c.Sort);
            foreach (var item in child)
            {
                MenuItem newItem = new MenuItem();
                newItem.Header = item.Name;
                newItem.Name = item.Code;
                newItem.Tag = item.Id.ToString();
                newItem.Click += (send, e) => NewItem_Click(send, e, item);
                LoadMenusChild(newItem);
                parent.Items.Add(newItem);

                if (item.AutoStart == 1)
                {
                    NewItem_Click(null, null, item);
                }
            }
        }
        public void NewItem_Click(object sender, EventArgs e, menus menu)
        {
            switch (menu.Code)
            {
                default:
                    break;
            }
        }
        #endregion
    }
}