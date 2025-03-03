using Olump2018.CreditPages;
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

namespace Olump2018
{
    /// <summary>
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Page
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void BtnCredits_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreditsPage());
        }

        private void BtnDeposits_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Olump2018.DepositPages.DepositsPage());
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }
    }
}
