using Common;
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

namespace Common
{
    public class HistoryOperationsItem
    {
        public String HistoryDate { get; set; }
        public String HistoryNumber { get; set; }
        public String HistoryType { get; set; }
        public String HistorySum { get; set; }
    }
}

namespace Olump2018
{
    /// <summary>
    /// Логика взаимодействия для OperationsHistory.xaml
    /// </summary>
    public partial class OperationsHistory : Page
    {
        public OperationsHistory()
        {
            InitializeComponent();
            loadOperationsHistory();
        }

        public void loadOperationsHistory()
        {
            ListHistory.ItemsSource = new List<HistoryOperationsItem>();

            using (var db = new Olymp2018Entities())
            {
                List<HistoryOperationsItem> operations = new List<HistoryOperationsItem>();

                var userAccounts = db.BankAccounts
                    .AsNoTracking()
                    .Where(u => u.UserID.ToString() == Global.userId)
                    .AsEnumerable();

                foreach (var account in userAccounts)
                {
                    var operationHistory = db.Histories
                        .AsNoTracking()
                        .Where(h => h.Account == account.NumberAccount)
                        .AsEnumerable();

                    foreach (var operation in operationHistory)
                    {
                        HistoryOperationsItem item = new HistoryOperationsItem();
                        item.HistoryDate = operation.DateTime.ToString();
                        item.HistoryNumber = account.NumberAccount;
                        item.HistoryType = operation.NameOperation.ToString();
                        item.HistorySum = operation.Amount.ToString();
                        operations.Add(item);

                    }
                }
                ListHistory.ItemsSource = operations;

            }
        }

    }
}
