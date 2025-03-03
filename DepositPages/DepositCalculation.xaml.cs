using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Olump2018.DepositPages
{
    /// <summary>
    /// Логика взаимодействия для DepositCalculation.xaml
    /// </summary>
    public partial class DepositCalculation : Page
    {
        public DepositCalculation()
        {
            InitializeComponent();
        }


        public void makeSummary()
        {
            if (TextBoxSum.Text != String.Empty && TextBoxPeriod.Text != String.Empty)
            {
                int sum = Convert.ToInt32(TextBoxSum.Text);
                int period = Convert.ToInt32(TextBoxPeriod.Text);
                if (period >= 3 && period < 6)
                {
                    DepositIncomeStable.Text = Calculations.Monthly(sum, 9.85, period).ToString("N2") + "Руб.";
                    DepositIncomeOptimal.Text = "Не рассчитывается";
                    DepositIncomeStandard.Text = Calculations.Monthly(sum, 6.55, period).ToString("N2") + " Руб.";
                }
                else if (period >= 4 || period >= 6)
                {
                    DepositIncomeStable.Text = Calculations.Monthly(sum, 9.85, period).ToString("N2") + "Руб.";
                    DepositIncomeOptimal.Text = Calculations.Monthly(sum, 6.1,period).ToString("N2") + " Руб.";
                    DepositIncomeStandard.Text = Calculations.Monthly(sum, 6.55, period).ToString("N2") + " Руб.";
                }
                else
                {
                    DepositIncomeStable.Text = "Не рассчитывается";
                    DepositIncomeOptimal.Text = "Не рассчитывается";
                    DepositIncomeStandard.Text = "Не рассчитывается";
                }
            }
           
        }

        private void TextBoxSum_TextChanged(object sender, TextChangedEventArgs e)
        {
            makeSummary();
        }

        private void TextBoxPeriod_TextChanged(object sender, TextChangedEventArgs e)
        {
            makeSummary();
        }

        private void TextBoxSum_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TextBoxPeriod_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DepositComparison());
        }
    }
}
