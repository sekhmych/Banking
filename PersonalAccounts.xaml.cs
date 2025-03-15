using Common;
using System;
using System.Collections;
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

namespace Common
{
    public class AccountItem
    {
        public String AccountType { get; set; }
        public String AccountNumber { get; set; }
        public String AccountBalance { get; set; }
    }
}

namespace Olump2018
{
    /// <summary>
    /// Логика взаимодействия для PersonalAccounts.xaml
    /// </summary>

  

    public partial class PersonalAccounts : Page
    {
        public PersonalAccounts()
        {
            InitializeComponent();
            loadUserAccounts();
        }
        

        public void loadUserAccounts()
        {
            ListAccounts.ItemsSource = new List<AccountItem>();
            using (var db = new Olymp2018Entities())
            {
                List<AccountItem> accounts = new List<AccountItem>();

                var userAccount = db.BankAccounts
                    .AsNoTracking()
                    .Where(u => u.UserID.ToString() == Global.userId)
                    .AsEnumerable();

                var accountType = db.Types
                    .AsNoTracking()
                    .AsEnumerable();



                foreach (var account in userAccount)
                {
                    AccountItem temp = new AccountItem();
                    foreach (var type in accountType)
                    {
                        if (type.IDType == account.Type)
                        {
                            temp.AccountType = type.NameType;
                            break;
                        }
                    }
                    temp.AccountNumber = account.NumberAccount.ToString();
                    temp.AccountBalance = account.Balance.ToString();
                    accounts.Add(temp);
                }
                ListAccounts.ItemsSource = accounts;
            }
        }
    }
}
