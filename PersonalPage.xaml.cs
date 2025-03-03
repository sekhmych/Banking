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
    /// Логика взаимодействия для PersonalPage.xaml
    /// </summary>
    public partial class PersonalPage : Page
    {

        public PersonalAccounts personalAccounts;
        public OperationsHistory operationsHistory;
        public PersonalPage()
        {
            InitializeComponent();
        }

        public PersonalPage(String FIO, string userID)
        {
            InitializeComponent();
            this.DataContext = this;
            this.FIO = FIO;
            this.UserID = userID;

            personalAccounts = new PersonalAccounts(this.UserID);
            operationsHistory = new OperationsHistory(this.UserID);

            FillPersonName();
            PersonalFrame.Navigate(personalAccounts);
        }

        private void FillPersonName()
        {
            var name = FIO.Split(' ')[0];
            var surname = FIO.Split(' ')[1].ElementAt(0) + ".";
            var patronymic = FIO.Split(' ')[2].ElementAt(0) + ".";
            
            TextFIO.Text = name + " " + surname + " " + patronymic;
        }

        public String FIO { get; set; }
        public String UserID { get; set; }

        private void BtnPersonalAccounts_Click(object sender, RoutedEventArgs e)
        {
            PersonalFrame.Navigate(personalAccounts);
        }

        private void BtnOperationHistory_Click(object sender, RoutedEventArgs e)
        {
            PersonalFrame.Navigate(operationsHistory);  
        }
    }
}
