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
    /// Логика взаимодействия для CreditCalculations.xaml
    /// </summary>
    public partial class CreditCalculations : UserControl
    {

        public enum CreditType { CashLoan, Mortage, CarLoan }

        public CreditType type { get; set; }
        public double percent { get; set; }

        public CreditCalculations(CreditType type)
        {
            InitializeComponent();
            this.type = type;

            if (type == CreditType.CashLoan)
            {
                TextBlockCreditName.Text = "Кредит наличными";
                TextBlockSum.Text = "Сумма";
                TextBlockPeriod.Text = "Срок";
                TextBlockDateFrom.Text = "Дата оформления кредита";
                TextBlockPeriodCompute.Text = "мес.";
                InitialPaymentGroup.Visibility = Visibility.Hidden;
                this.percent = 0.149;
            }
            else if (type == CreditType.Mortage)
            {
                TextBlockCreditName.Text = "Ипотека";
                TextBlockSum.Text = "Стоимость недвижимости";
                TextBlockPeriod.Text = "Срок ипотеки";
                TextBlockDateFrom.Text = "Дата оформления ипотеки";
                TextBlockPeriodCompute.Text = "лет/годов";

                this.percent = 0.100;

            }
            else if (type == CreditType.CarLoan)
            {
                TextBlockCreditName.Text = "Кредит наличными";
                TextBlockSum.Text = "Стоимость автомиля";
                TextBlockPeriod.Text = "Срок";
                TextBlockDateFrom.Text = "Дата оформления ипотеки";
                TextBlockPeriodCompute.Text = "лет/годов";


                this.percent = 0.1110;

            }


            TextBoxMonthlyPayment.Text = "";
            TextBoxOverPayment.Text = "";
            TextBlockPercent.Text = "%";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new CreditPaymentPlan());
        }

        private void TextBoxSum_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalculateMonthlyPayment();
            Console.WriteLine("wef");
        }

        private void TextBoxPeriod_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalculateMonthlyPayment();
        }

        private void CalculateMonthlyPayment()
        {
            if (TextBoxSum.Text != String.Empty && TextBoxPeriod.Text != String.Empty)
            {
                try
                {
                    long sum = Convert.ToInt64(TextBoxSum.Text);
                    int period = Convert.ToInt32(TextBoxPeriod.Text);
                    if (TextBoxInitialPayment.Text == String.Empty)
                    {
                        TextBoxInitialPayment.Text = "0";
                    }
                    int initialPayment = Convert.ToInt32(TextBoxInitialPayment.Text);

                    Console.WriteLine("BeforeIF");

                    if (this.type == CreditType.CashLoan)
                    {
                        if (!Calculations.CashLoanCheck(sum, period)) return;
                    }
                    else if (this.type == CreditType.Mortage)
                    {
                        if (!Calculations.MortageCheck(sum, period, initialPayment)) return;
                    }
                    else if (this.type == CreditType.CarLoan)
                    {
                        if (!Calculations.CarLoanCheck(sum, period, initialPayment)) return;
                    }
                    else
                    {
                        return;
                    }

                    Console.WriteLine("If check!");

                    if (type == CreditType.Mortage || type == CreditType.CarLoan)
                    {
                        period = period * 12;
                    }

                    float monthlyPayment = Calculations.MonthlyPaymentAmount(sum, this.percent, 12, period, initialPayment);
                    TextBoxMonthlyPayment.Text = monthlyPayment.ToString("N2") + " Руб.";
                    TextBoxOverPayment.Text = Calculations.CreditOverPayment(sum - initialPayment, Calculations.CreditTotal(monthlyPayment, period)).ToString("N2") + " Руб.";
                    TextBlockPercent.Text = Calculations.CreditEffectPercent(sum - initialPayment, Calculations.CreditOverPayment(sum - initialPayment, Calculations.CreditTotal(monthlyPayment, period))).ToString();
                    //TextBoxMonthlyPayment.Text = "Не рассчитывается";
                    //TextBoxOverPayment.Text = "Не рассчитывается";
                   


                    Console.WriteLine(sum);
                    Console.WriteLine(period);

                    
                }
                catch (Exception ex)
                {
                    TextBoxMonthlyPayment.Text = "Не рассчитывается";
                    TextBoxOverPayment.Text = "Не рассчитывается";
                    return;
                }
            }
        }
    }

}
