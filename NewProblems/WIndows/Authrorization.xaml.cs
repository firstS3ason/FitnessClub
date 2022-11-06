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
using System.Windows.Shapes;

using NewProblems.Contexts;
using NewProblems.Models;
using NewProblems.WIndows;

namespace NewProblems.WIndows
{
    /// <summary>
    /// Interaction logic for Authrorization.xaml
    /// </summary>
    public partial class Authrorization : Window
    {
        UsersContext _dbAut = MainWindow._db;
        public Authrorization()
        {

            InitializeComponent();
        }


        private void exit_btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void Entering(UsersContext _context)
        {
            try
            {

                Users _userInSession = (from i in _context.Users where i.Password == password_txt.Text select i).FirstOrDefault();

                if (_userInSession.Login != null)
                {
                    UserInSession<Users> _CurrentUserInSession = new UserInSession<Users>(_userInSession); // Передача информации об пользователе во внутрь свойств, расположенных в классе через обобщение в сторону экземпляров класса
                    switch (_CurrentUserInSession.TypeOfPerson)
                    {
                        case "Administrator":

                            break;

                        case "Coach":

                            break;

                        case "Buyer":
                            BuyerWindow _windowOfBuyer = new BuyerWindow();
                            _windowOfBuyer.Show();

                            Close();
                            break;

                    }
                    MessageBox.Show($"Greetings, {_CurrentUserInSession.TypeOfPerson} {_CurrentUserInSession.User}", "@!@");
                }
                else
                {
                    MessageBox.Show("Пользователь не обнаружен");

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       private void enter_btn_Click(object sender, RoutedEventArgs e)
            {

                Entering(_dbAut);
            }

        private void registration_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow _regWindow = new MainWindow();

           
            _regWindow.Show();
            Close();
        }
    }
}
