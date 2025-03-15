using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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


        public bool makeSummary()
        {
            if (TextBoxSum.Text != String.Empty && TextBoxPeriod.Text != String.Empty)
            {
                try
                {
                    int sum = Convert.ToInt32(TextBoxSum.Text);
                    int period = Convert.ToInt32(TextBoxPeriod.Text);
                    if (period >= 3 && period < 6)
                    {
                        DepositIncomeStable.Text = Calculations.Monthly(sum, 9.85, period).ToString("N2") + "Руб.";
                        DepositIncomeOptimal.Text = "Не рассчитывается";
                        DepositIncomeStandard.Text = Calculations.Monthly(sum, 6.55, period).ToString("N2") + " Руб.";
                        return true;
                    }
                    else if (period >= 6 && period <= 60)
                    {
                        DepositIncomeStable.Text = Calculations.Monthly(sum, 9.85, period).ToString("N2") + "Руб.";
                        DepositIncomeOptimal.Text = Calculations.Monthly(sum, 6.1, period).ToString("N2") + " Руб.";
                        DepositIncomeStandard.Text = Calculations.Monthly(sum, 6.55, period).ToString("N2") + " Руб.";
                        return true;
                    }
                    else
                    {
                        DepositIncomeStable.Text = "Не рассчитывается";
                        DepositIncomeOptimal.Text = "Не рассчитывается";
                        DepositIncomeStandard.Text = "Не рассчитывается";
                        return false;
                    }
                } catch (OverflowException)
                {
                    DepositIncomeStable.Text = "Не рассчитывается";
                    DepositIncomeOptimal.Text = "Не рассчитывается";
                    DepositIncomeStandard.Text = "Не рассчитывается";
                    return false;
                }
                
            } else
            {
                return false;
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
            if (makeSummary())
            {
                int sum = Convert.ToInt32(TextBoxSum.Text);
                int period = Convert.ToInt32(TextBoxPeriod.Text);
                Documents.DepositsInfo depositsInfo = new Documents.DepositsInfo()
                {
                    RawPeriod = period.ToString(),
                    RawSum = sum.ToString(),
                    Sum = sum + " Руб.",

                    StableMonthly = Calculations.Monthly(sum, 9.85, period).ToString("N2"),
                    StableTotal = Calculations.MonthlySum(sum, 9.85, period).ToString("N2"),
                    StablePercent = "9.85",

                    OptimalMonthly = Calculations.Monthly(sum, 6.1, period).ToString("N2"),
                    OptimalTotal = Calculations.MonthlySum(sum, 6.1, period).ToString("N2"),
                    OptimalPercent = "6.1",

                    StandardMonthly = Calculations.Monthly(sum, 6.55, period).ToString("N2"),
                    StandardTotal = Calculations.MonthlySum(sum, 6.55, period).ToString("N2"),
                    StandardPercent = "6.55",

                    Period = period.ToString() + " месяцев"

                };
                NavigationService.Navigate(new DepositComparison(depositsInfo));
            } else
            {
                MessageBox.Show("Недопустимые параметры для вклада!");
                return;
            }
            
        }
    }
}
