using DataBase.MySql;
using DataBase;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Google.Protobuf.WellKnownTypes;

namespace DayDayWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main_ViewModel _vm = new Main_ViewModel();
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
        private void appMin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void btnDefault_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() => {
                menu_head.Dispatcher.Invoke(() => {
                    _vm.Index++;
                });
            });
        }

    }

    public class Main_ViewModel :INotifyCollectionChanged,INotifyPropertyChanged
    {
        public event NotifyCollectionChangedEventHandler? CollectionChanged;
        public event PropertyChangedEventHandler? PropertyChanged;
        private int _index = 0;
        public int Index { get { return _index; } set { _index = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Index))); } }
        public ObservableCollection<MenuItem_Model> MenuItems { get; set; }
        public ICommand? MenuItemCmd { get; }
        List<menus> list { get; set; }
        public Main_ViewModel()
        {
            MenuItems = new ObservableCollection<MenuItem_Model>();
            list = DayDayDB.GetList<menus>();
            //一级菜单
            foreach (var item in list.Where(m => m.ParentId == 0).OrderBy(m => m.Sort))
            {
                MenuItem_Model newItem = new MenuItem_Model();
                newItem.Header = item.Name;
                newItem.Command = MenuItemCmd;
                newItem.CommadParameter = item.Code.ToString();
                newItem.Children= BindChild(item.Id);
                MenuItems.Add(newItem);
            }
        }
        public ObservableCollection<MenuItem_Model> BindChild(int parentid)
        {
            var child = list.Where(c => c.ParentId == parentid).OrderBy(c => c.Sort);
            ObservableCollection<MenuItem_Model> childs = new ObservableCollection<MenuItem_Model>();
            foreach (var item in child)
            {
                MenuItem_Model newItem = new MenuItem_Model();
                newItem.Header = item.Name;
                newItem.Command = MenuItemCmd;
                newItem.CommadParameter = item.Code.ToString();
                newItem.Children = BindChild(item.Id);
                childs.Add(newItem);
            }
            return childs;
        }
    }

    public class MenuItem_Model
    {
        public MenuItem_Model()
        {
            Children = new ObservableCollection<MenuItem_Model>();
        }
        public string? Header { get; set; }
        public ICommand? Command { get; set; }
        public string? CommadParameter { get; set; }
        public ObservableCollection<MenuItem_Model> Children { get; set; }
    }
}