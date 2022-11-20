using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using NewProblems.Contexts;
using NewProblems.Models;

namespace NewProblems
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    ///  _db.Database.EnsureCreated();
    ///  Users polzovatel1 = new Users { Login = "Anton", Password = "NeGena", Permissions = "Zero" }; 
    ///  _db.Users.AddRange(polzovatel1);_db.SaveChanges();
    ///   CoachInvites _becomePartners = (from i in context.CoachInvites where i.CoachName == CoachName select i).FirstOrDefault();
    ///  using (UsersContext _db = new UsersContext()) {Инструкции, что доступны} // создаем метку в сторону класса, на основе которого и создается экземпляр.


    public partial class MainWindow : Window
    {
        private readonly UsersContext _db = new UsersContext();
        public static string? AdminIn { get; set; }
        public static string? PlacingInto_AdminIn
        {
            get
            {
                return AdminIn;
            }
            set
            {
                if (value == "Administrator")
                {
                    value = "Yes";
                    AdminIn = value;
                }
                else
                {
                    value = "No";
                    AdminIn = value;
                }
            }
        }

        public MainWindow()
       {
            InitializeComponent();
            DbLoad(_db);
            
            if (AdminIn == "Yes")
            {

            }
       }

        private void ClearingTxts()
        {
            password_txt.Clear();
            login_txt.Clear();
            
        }

        private void DbLoad(UsersContext context)
        {
            UsersdataGrid.ItemsSource = context.GetAll().ToList();
        }

        private bool TxtHaveInfo()
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
                    
                    DbLoad(_db);
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
                if (UsersdataGrid.SelectedItem != null) //заменить на значение, из себя строку пустующую на территории ДатаГрид что расположена.) 
                {
                    int elementID = (UsersdataGrid.SelectedItem as Users).ID;
                    var user = _db.Users.Where(r => r.ID == elementID).FirstOrDefault();

                    _db.Users.Remove(user);
                    _db.SaveChanges();

                    DbLoad(_db);
                    ClearingTxts();
                }
                else
                {
                    MessageBox.Show("Выделите строку, содержащую информацию, избавиться от которой Вы желаете.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    var user = _db.Users.Where(r => r.ID == elementID).FirstOrDefault();

                    user.Login = login_txt.Text;
                    user.Password = password_txt.Text;
                    user.Permissions = content;

                    _db.Users.Update(user);
                    _db.SaveChanges();

                    DbLoad(_db);
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
