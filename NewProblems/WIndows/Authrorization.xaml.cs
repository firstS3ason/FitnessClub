using System;
using System.Linq;
using System.Windows;
using NewProblems.Contexts;


namespace NewProblems.WIndows
{
    /// <summary>
    /// Interaction logic for Authrorization.xaml
    /// </summary>
    public partial class Authrorization : Window
    {
        private readonly UsersContext _dbAut = new UsersContext();
        public Authrorization()
        {

            InitializeComponent();
        }

        private void exit_btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private bool IsContainInfo()
        {
            if (login_txt.Text != "" && password_txt.Text != "")
            {
                return true;
            }
            else
            {
                MessageBox.Show
                    ("Заполните следующие пространства:\nполе для логина, пароля\n \nWrite values to the open space territory:\nlogin-line, password-line",
                    "News",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
                return false;
            }
        }
        public void Entering(UsersContext _context)
        {
            try
            {
               if (IsContainInfo())
               {
                    var userInSession = (from i in _context.Users where i.Password == password_txt.Text select i).FirstOrDefault();

                    //where 
                    //var 
                    //naming
                    //зависимости через конструктор
                    //переделать загрузочную логику
                    //private readonly DbContext
                    //regular expression


                    if (!String.IsNullOrEmpty(userInSession.Login))
                    {
                        switch (userInSession.Permissions)
                        {
                            case "Administrator":
                                /*
                                BuyerWindow.UserName = userInSession.Login;
                                BuyerWindow.PlacingInto_AdminIn = userInSession.Permissions;
                                BuyerWindow _windowOfBuyerAd = new BuyerWindow();

                                _windowOfBuyerAd.Show();
                                */
                                CoachWindow.AdminIn = userInSession.Permissions;
                                CoachWindow coachWindow = new CoachWindow();
                                coachWindow.Show();
                                Close();
                                break;

                            case "Coach":
                                CoachWindow.CurrentCoach = userInSession.Login;
                                CoachWindow.AdminIn = userInSession.Permissions;
                                CoachWindow _coachInside_Of_the_app = new CoachWindow();

                                _coachInside_Of_the_app.Show();
                                Close();
                                break;

                            case "Buyer":
                                BuyerWindow.UserName = userInSession.Login;
                                BuyerWindow.AdminIn = userInSession.Permissions;
                                BuyerWindow _windowOfBuyer = new BuyerWindow();

                                _windowOfBuyer.Show();
                                Close();
                                break;
                        }
                        MessageBox.Show($"Greetings, {userInSession.Permissions} {userInSession.Login}", "@!@", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Пользователь не обнаружен");
                    }
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
