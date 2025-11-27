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
using System.Windows.Navigation;
using System.Windows.Shapes;

using TRPO_pr12.Service;

namespace TRPO_pr12.Pages
{
    /// <summary>
    /// Логика взаимодействия для StudentFormPage.xaml
    /// </summary>
    public partial class UserFormPage : Page
    {
        public User _user { get; set; } = new();
        public UsersServise _service { get; set; } = new();
        bool isEdit = false;
        public UserFormPage(User? user = null)
        {
            InitializeComponent();
            if (user != null)
            {
                isEdit = true;
                _user = user;
            }
            DataContext = _user;
        }

        private void save(object sender, RoutedEventArgs e)
        {
            if (isEdit)
                _service.Commit();
            else
                _service.Add(_user);
            NavigationService.GoBack();
        }

        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
