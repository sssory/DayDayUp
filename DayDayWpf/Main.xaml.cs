using DataBase.MySql;
using DataBase;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace DayDayWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main_Vm _vm = new Main_Vm();
        public Main()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _vm;//绑定视图模型
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    public class Main_Vm :INotifyCollectionChanged,INotifyPropertyChanged
    {
        public event NotifyCollectionChangedEventHandler? CollectionChanged;
        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<MenuItem_M> MenuItems { get; set; }
        public ICommand? MenuItemCmd { get; }
        List<menus> list { get; set; }
        public Main_Vm()
        {
            MenuItems = new ObservableCollection<MenuItem_M>();
            list = DayDayDB.GetList<menus>();
            //一级菜单
            foreach (var item in list.Where(m => m.ParentId == 0).OrderBy(m => m.Sort))
            {
                MenuItem_M newItem = new MenuItem_M();
                newItem.Header = item.Name;
                newItem.Command = MenuItemCmd;
                newItem.CommadParameter = item.Code.ToString();
                newItem.Children= BindChild(item.Id);
                MenuItems.Add(newItem);
            }
        }
        public ObservableCollection<MenuItem_M> BindChild(int parentid)
        {
            var child = list.Where(c => c.ParentId == parentid).OrderBy(c => c.Sort);
            ObservableCollection<MenuItem_M> childs = new ObservableCollection<MenuItem_M>();
            foreach (var item in child)
            {
                MenuItem_M newItem = new MenuItem_M();
                newItem.Header = item.Name;
                newItem.Command = MenuItemCmd;
                newItem.CommadParameter = item.Code.ToString();
                newItem.Children = BindChild(item.Id);
                childs.Add(newItem);
            }
            return childs;
        }
    }

    public class MenuItem_M
    {
        public MenuItem_M()
        {
            Children = new ObservableCollection<MenuItem_M>();
        }
        public string? Header { get; set; }
        public ICommand? Command { get; set; }
        public string? CommadParameter { get; set; }
        public ObservableCollection<MenuItem_M> Children { get; set; }
    }
}