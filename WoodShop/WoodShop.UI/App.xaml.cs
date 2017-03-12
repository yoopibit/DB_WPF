using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WoodShop.UI.ViewModel;

namespace WoodShop.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var vm = new MainWindowViewModel();
            var window = new MainWindow(vm);
            window.Show();
        }
    }
}
