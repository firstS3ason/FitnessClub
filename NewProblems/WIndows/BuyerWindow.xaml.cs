using NewProblems.Contexts;
using NewProblems.Interfaces.ToBuyer;
using NewProblems.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows;


namespace NewProblems.WIndows
{
    /// <summary>
    /// Interaction logic for BuyerWindow.xaml
    /// </summary>
    public partial class BuyerWindow : Window, IBuyerWindow
    {
        static public string? UserName { get; set; } // Заполняется, при авторизации пользователя в соответсвующем, для подобных действий, окне.
        public DateTime DateOfBeingPartners { get; set; }
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

        private readonly UsersContext _BuyerDb = new UsersContext();

        
        public BuyerWindow()
        {
            InitializeComponent();

            CloseThirdTab_btn.Visibility = Visibility.Hidden;
            admin_category.Visibility = Visibility.Hidden;

            if (AdminIn != "Yes")
            {
                redactCoachList_btn.Visibility = Visibility.Hidden;
                redactInvitesList_btn.Visibility = Visibility.Hidden;
                
            }
            else
            {
                calendar.Visibility = Visibility.Hidden;
            }

            try
            { 
                DataGrid_Invites_Load(_BuyerDb);
                DataGrid_CoachList_Load(_BuyerDb);
                DataGrid_Trainings_Load(_BuyerDb);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void DataGrid_Invites_Load(UsersContext context)
        {
            //var testing = context.CoachInvitesGetAll().ToList();

            var test = context.CoachInvitesGetAll().Where(s => s.NameOfPostMan == UserName).ToList();
            DataGrid_buyer.ItemsSource = test.ToList();
        }

       private void DataGrid_CoachList_Load(UsersContext context)
        {
            DataGrid_Coaches.ItemsSource = context.Coaches.ToList();
        }

        private void DataGrid_Trainings_Load(UsersContext context)
        {
            var ExcersisesForCurrentPerson = _BuyerDb.TrainingsList.Where(x => x.CreatedForWho == UserName).ToList();
            Trainings_dataGrid.ItemsSource = ExcersisesForCurrentPerson;
        }

        public void SendingInfo(UsersContext context)
        {
            try
            {
                int elementID = (DataGrid_Coaches.SelectedItem as Coaches).CoachId;
                var SelectedCoach = context.Coaches.Where(r => r.CoachId == elementID ).FirstOrDefault();

                CoachInvites newInvite = new CoachInvites
                {
                   
                    CoachName = SelectedCoach.CoachName,
                    RequestStatus = "Without answer",
                    NameOfPostMan = UserName
                    
                };

                context.CoachInvites.Add(newInvite);
                context.SaveChanges();

                DataGrid_Invites_Load(context);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ChoosingCoach(UsersContext context)
        {
            string CoachName = (DataGrid_buyer.SelectedItem as CoachInvites).CoachName;

            var completeDeal = context.CoachInvites.Where(r => r.CoachName == CoachName).FirstOrDefault();
            completeDeal.RequestStatus = "Let's start working";


            context.Update(completeDeal);
            context.SaveChanges(); 
        }

        private void Button_Click(object sender, RoutedEventArgs e) // SendInvite_btn
        {
            SendingInfo(_BuyerDb);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ChoosingCoach(_BuyerDb);
        }


        private void Delete_btn_Click(object sender, RoutedEventArgs e)
        {
            int SelectedID = (DataGrid_buyer.SelectedItem as CoachInvites).ID;
            var FoundPerson = _BuyerDb.CoachInvites.Where(x => x.ID == SelectedID).FirstOrDefault();

            _BuyerDb.Remove(FoundPerson);
            _BuyerDb.SaveChanges();

            DataGrid_Invites_Load(_BuyerDb);
        }

        private void redactCoachList_btn_Click(object sender, RoutedEventArgs e) 
        {
            admin_category.Visibility = Visibility.Visible;
            CloseThirdTab_btn.Visibility = Visibility.Visible;
            Admin_coaches_grid.Visibility = Visibility.Visible;

            var ToDataGrid = _BuyerDb.CoachGetAll().ToList();

            Admin_coaches_grid.Items.Clear();
            Admin_coaches_grid.ItemsSource = ToDataGrid.ToList();
        }

        private void redactInvitesList_btn_Click(object sender, RoutedEventArgs e)
        {
            Admin_coaches_grid.Visibility = Visibility.Visible;
            admin_category.Visibility = Visibility.Visible;
            CloseThirdTab_btn.Visibility = Visibility.Visible;

            var ToDataGrid = _BuyerDb.CoachInvitesGetAll().ToList();

            Admin_coaches_grid.Items.Clear();
            Admin_coaches_grid.ItemsSource = ToDataGrid.ToList();
        }
        private void CloseThirdTab_btn_Click(object sender, RoutedEventArgs e)
        {
            admin_category.Visibility = Visibility.Hidden;
            CloseThirdTab_btn.Visibility = Visibility.Hidden;
        }
    }
}
