using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {

        public static bool IsUserLogged()
        {
            using(var db = new Olymp2018Entities())
            {
                var user = db.Users
                    .AsNoTracking()
                    .FirstOrDefault(u => u.Login == Global.login && u.Password == Global.password);

                if (user != null)
                {
                    return true;
                } else
                {
                    return false;
                }
            }
        }

        public LoginPage()
        {
            InitializeComponent();
            if (IsUserLogged())
            {
                NavigationService.Navigate(new PersonalPage());
            }
        }

        public LoginPage(Page targetPage)
        {
            InitializeComponent();
            this.targetPage = targetPage;
            if (IsUserLogged())
            {
                NavigationService.Navigate(this.targetPage);
            }
        }

        Page targetPage { get; set; }
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(TextBoxLogin.Text) || String.IsNullOrEmpty(PasswordBox.Password)) {
                MessageBox.Show("Заполните логин/пароль");
                return;
            }

            using (var db = new Olymp2018Entities())
            {
                var user = db.Users
                    .AsNoTracking()
                    .FirstOrDefault(u => u.Login == TextBoxLogin.Text && u.Password == PasswordBox.Password);

                if (user == null)
                {
                    MessageBox.Show("Неверный пароль или такого пользователя не существует!");
                    return;
                } else if (user != null)
                {
                    Global.userId = user.IDUser.ToString();
                    Global.login = user.Login;
                    Global.password = user.Password;

                    if (this.targetPage != null)
                    {
                        NavigationService.Navigate(this.targetPage);
                        return;
                    }

                    NavigationService.Navigate(new PersonalPage((user.Name.Trim() + " " + user.Surname.Trim() + " " + user.Patronymic.Trim())));
                }


            }
        }
    }
}
