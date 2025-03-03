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

namespace Olump2018.DepositPages.UserControls
{
    /// <summary>
    /// Логика взаимодействия для DepositElement.xaml
    /// </summary>
    public partial class DepositElement : UserControl
    {
        public DepositElement()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public String Title { get; set; }
        public String Description { get; set; }
        public String Period { get; set; }
        public String Bet {  get; set; }
    }
}
