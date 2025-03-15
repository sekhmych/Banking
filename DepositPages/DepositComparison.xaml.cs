using Microsoft.Office.Interop.Word;
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

namespace Olump2018.DepositPages
{
    /// <summary>
    /// Логика взаимодействия для DepositComparison.xaml
    /// </summary>
    public partial class DepositComparison : System.Windows.Controls.Page
    {
        public DepositComparison(Documents.DepositsInfo depositsInfo)
        {
            InitializeComponent();
            this.info = depositsInfo;
            Documents.DepositsInfo info = depositsInfo;
 
            StableMonthly.Text = info.StableMonthly + " Руб.";
            StableTotal.Text = info.StableTotal + " Руб.";
            StablePercent.Text = info.StablePercent + " %";

            OptimalMonthly.Text = info.OptimalMonthly + " Руб.";
            OptimalTotal.Text = info.OptimalTotal + " Руб.";
            OptimalPercent.Text = info.OptimalPercent + " %";

            StandardMonthly.Text = info.StandardMonthly + " Руб.";
            StandardTotal.Text = info.StandardTotal + " Руб.";
            StandardPercent.Text = info.StandardPercent + " %";

        }

        Documents.DepositsInfo info { get; set; }

        public string MakeBankAccount()
        {
            if (LoginPage.IsUserLogged())
            {
                using(var db = new Olymp2018Entities())
                {
                    var lastBankAccount = db.BankAccounts
                        .AsNoTracking()
                        .OrderByDescending(a => a.NumberAccount)
                        .FirstOrDefault();
                    if (lastBankAccount != null)
                    {
                        var bankAccount = db.BankAccounts.Add(new BankAccount
                        {
                            NumberAccount = (Convert.ToUInt64(lastBankAccount.NumberAccount) + 1).ToString(),
                            UserID = Convert.ToInt32(Global.userId),
                            DateOpen = DateTime.Now,
                            Balance = Convert.ToDouble(this.info.RawSum),
                            Type = 3
                        });
                        db.SaveChanges();
                        return bankAccount.NumberAccount;
                    } else
                    {
                        var bankAccount = db.BankAccounts.Add(new BankAccount
                        {
                            NumberAccount = 1.ToString(),
                            UserID = Convert.ToInt32(Global.userId),
                            DateOpen = DateTime.Now,
                            Balance = Convert.ToDouble(this.info.RawSum),
                            Type = 3
                        });
                        db.SaveChanges();
                        return bankAccount.NumberAccount;
                    }


                    
                }
            }

            return "";
        }


        public string MakeContract(string numberAccount, string percet)
        {
            if (LoginPage.IsUserLogged())
            {
                using (var db = new Olymp2018Entities())
                {

                    var bankAccount = db.BankAccounts
                        .AsNoTracking()
                        .FirstOrDefault(a => a.NumberAccount == numberAccount);
                    var contractData = new Contract();
                    if (bankAccount != null)
                    {
                        try
                        {
                            Console.WriteLine(this.info.RawSum);
                            Console.WriteLine(percet);
                            contractData = new Contract()
                            {
                                NumberAccount = numberAccount,
                                UserID = Convert.ToInt32(Global.userId),
                                Amount = Convert.ToDouble(this.info.RawSum),
                                Period = Convert.ToInt32(this.info.RawPeriod),
                                ExpirationDate = DateTime.Now.AddMonths(Convert.ToInt32(this.info.RawPeriod)),
                                Percet = Convert.ToDouble(percet.Replace('.', ','))
                            };

                        } catch (Exception)
                        {
                            return "";
                        }
                        var contract = db.Contracts.Add(contractData);

                        db.SaveChanges();
                        return contractData.IDContract.ToString();
                        
                    } else
                    {
                        return "";
                    }

                    
                }
            }

            return "";
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Documents.MakeDepositsExtract((Documents.DepositsInfo) this.info);
        }

        private void BtnMakeStable_Click(object sender, RoutedEventArgs e)
        {
            using(var db = new Olymp2018Entities())
            {

                if(LoginPage.IsUserLogged())
                {
                    MessageBox.Show("Пользователь авторизирован!");
                    var numberAccount = MakeBankAccount();
                    var contract = MakeContract(numberAccount, this.info.StablePercent);
                } else
                {
                    NavigationService.Navigate(new LoginPage(this));
                    return;
                }

                //Documents.Contract contract = new Documents.Contract()
                //{
                //    contract_number = "123",
                //    day = "24",
                //    month = "Февраль",
                //    year = "25",
                //    FIO = "Сергеев Владимир Дмитриевич",
                //    sum = StableTotal.Text,
                //    period = "24 Века",
                //    end_period = "01.05.3045",
                //    percent = StablePercent.Text,
                //    account_number = "1234124124",
                //    reg_adress = "г. Якутск",
                //    passport_series = "2133",
                //    passport_number = "124244",
                //    email = "qwfqw@mail.ru",
                //    issued_by = "Хроно",
                //    date_of_birth = "12.23.2001",
                //    place_of_birth = "Нарния"
                //};
            }
            
        }

        private void BtnMakeOptimal_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnMakeStandard_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
