using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WoodShop.UI.ViewModel.Base;

namespace WoodShop.UI.ViewModel
{
    public class MainWindowViewModel:ObservableObject
    {
        private string m_Title = "Wood Shop";
        public string Title
        {
            get { return m_Title; }
            set
            {
                if (m_Title == value) return;
                m_Title = value;
                OnPropetyChange("Title");
            }
        }

        public ICommand MyCommand { get; set; } = new DelegateCommand((x) =>
         {
             var vm = x as MainWindowViewModel;
             if (vm == null) return;
             vm.Title = "Title Changed";
         });
    }
}
