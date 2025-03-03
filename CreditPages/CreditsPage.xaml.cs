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

namespace Olump2018.CreditPages
{
    /// <summary>
    /// Логика взаимодействия для CreditsPage.xaml
    /// </summary>
    public partial class CreditsPage : Page
    {
        public CreditsPage()
        {
            InitializeComponent();
        }

        private void CreditElement_CalculationClick(object sender, EventArgs e)
        {
            NavigationService.Navigate(new CreditCalculations(CreditCalculations.CreditType.CashLoan));
        }

        private void CreditElement_CalculationClick_1(object sender, EventArgs e)
        {
            NavigationService.Navigate(new CreditCalculations(CreditCalculations.CreditType.Mortage));
        }

        private void CreditElement_CalculationClick_2(object sender, EventArgs e)
        {
            NavigationService.Navigate(new CreditCalculations(CreditCalculations.CreditType.CarLoan));
        }
    }
}
