using System;
using System.Data;
using System.Runtime.Remoting.Channels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Olump2018.CreditPages.UserControls
{
    /// <summary>
    /// Логика взаимодействия для CreditElement.xaml
    /// </summary>
    public partial class CreditElement : UserControl
    {
        public CreditElement()
        {
            InitializeComponent();
            this.DataContext = this;
            
        }

        public event EventHandler CalculationClick;

        public enum Type { CashLoan, Mortgage, CarLoan };

        public Type TypeOfCredit {  get; set; }

        public String Title { get; set; }
        public String Period { get; set; }
        public String Bet { get; set; }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (CalculationClick != null)
            {
                CalculationClick(this, EventArgs.Empty);
            }
        }
    }
}
