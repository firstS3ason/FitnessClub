using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
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

using NewProblems.Contexts;
using NewProblems.Models;
using NewProblems.WIndows;

namespace NewProblems
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   
    ///  _db.Database.EnsureCreated();
    ///  Users polzovatel1 = new Users { Login = "Anton", Password = "NeGena", Permissions = "Zero" }; 
    ///  _db.Users.AddRange(polzovatel1);_db.SaveChanges();
    ///  using (UsersContext _db = new UsersContext()) {Инструкции, что доступны} // создаем метку в сторону класса, на основе которого и создается экземпляр.


    public partial class MainWindow : Window
    {
       static public UsersContext _db = new UsersContext();

       public MainWindow()
       {

            InitializeComponent();
            DbLoad();
            
       }


        public void ClearingTxts()
        {
            password_txt.Clear();
            login_txt.Clear();
            id_txt.Clear();
        }
        public void DbLoad()
        {
            UsersdataGrid.ItemsSource = _db.GetAll().ToList();
        }
        public bool TxtHaveInfo()
        {
            if (combo_box.SelectedItem != null &&
                password_txt.Text != "" &&
                login_txt.Text != "")
            {
                return true;
            }

            else 
            {
                MessageBox.Show("Заполните два необходимых поля: \nЛогин, \nПароль; \nТак же - выберите собственный тип пользователя.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }
        }
        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
                if (TxtHaveInfo())
                {
                    var item = (ComboBoxItem)combo_box.SelectedValue; // Помещение выделенного значения из объекта - комбо_контейнера, что связан с классом в виде значенией, в переменную.
                    var content = (string)item.Content; // преобразорвание того, во внутренней части у переменной что в наличии, в необходимый, строковой формат.

                    Users potentialUser = new Users
                    {
                        Login = login_txt.Text,
                        Password = password_txt.Text,
                        Permissions = content
                    };

                    _db.Users.Add(potentialUser);
                    _db.SaveChanges();

                    DbLoad();
                    ClearingTxts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (HaveId())
                {
                    int elementID = (UsersdataGrid.SelectedItem as Users).ID;
                    Users user = (from r in _db.Users where r.ID == elementID select r).FirstOrDefault();
                    _db.Users.Remove(user);
                    _db.SaveChanges();

                    DbLoad();
                    ClearingTxts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool HaveId()
        {
            if (id_txt.Text != "")
            {
                return true;
            }
            else
            {
                MessageBox.Show("Уточните, поле с каким индектификатором Вы желаете изменить", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        private void update_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TxtHaveInfo())
                {

                    var item = (ComboBoxItem)combo_box.SelectedValue;
                    var content = (string)item.Content;

                    int elementID = (UsersdataGrid.SelectedItem as Users).ID;
                    Users user = (from r in _db.Users where r.ID == elementID select r).FirstOrDefault();

                    user.Login = login_txt.Text;
                    user.Password = password_txt.Text;
                    user.Permissions = content;

                    _db.Users.Update(user);
                    _db.SaveChanges();

                    DbLoad();
                    ClearingTxts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void clearing_btn_Click(object sender, RoutedEventArgs e)
        {
            ClearingTxts();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewProblems.WIndows.Authrorization _authorization = new NewProblems.WIndows.Authrorization();
            _authorization.Show();
            Close();
        }
    }
}
