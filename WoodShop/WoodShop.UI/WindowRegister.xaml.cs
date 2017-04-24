using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WoodShop.UI.ViewModel;

namespace WoodShop.UI
{
    /// <summary>
    /// Interaction logic for WindowRegister.xaml
    /// </summary>
    public partial class WindowRegister : Window
    {
        public WindowRegister()
        {
            InitializeComponent();
        }

        private void comboBoxManager_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SignUpViewModel model = new SignUpViewModel();
            this.comboBoxManager.ItemsSource = model.GetAllManagers;
        }
    }
}
