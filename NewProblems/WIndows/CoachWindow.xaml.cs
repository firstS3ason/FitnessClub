using NewProblems.Contexts;
using NewProblems.Models;
using System.Linq;
using System.Windows;
using System.Data;
using NewProblems.Interfaces.ToCoach;

namespace NewProblems.WIndows
{
    /// <summary>
    /// Interaction logic for CoachWindow.xaml
    /// </summary>
    public partial class CoachWindow : Window, ICoachWindow
    {
        private readonly UsersContext _CoachDb = new UsersContext();
        public static string? CurrentCoach { get; set; }
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
        public CoachWindow()
        {
            InitializeComponent();
            InvitesLoad(_CoachDb);
            CoachesListLoad(_CoachDb);

            if (AdminIn == "No")
            {

            }
        }

        public void InvitesLoad(UsersContext context)
        {
            var Invites_WithCoachName = context.CoachInvites.Where(a => a.CoachName == CurrentCoach).ToList();

            dataGrid_requests.ItemsSource = Invites_WithCoachName.ToList();
        }
        public void CoachesListLoad(UsersContext context)
        {
            var All_Coaches = context.CoachGetAll().ToList();

            Adm_add_coaches_grid.ItemsSource = All_Coaches.ToList();
        }
        
        public void CreatingProgramm() // todo
        {
            //dataGrid_requests.SelectedValue 
        }

     
        private void AcceptRqst(object sender, RoutedEventArgs e) //accept rqst Btn
        {
            int _SelectedUser = (dataGrid_requests.SelectedItem as CoachInvites).ID; 
            var FoundCoach = _CoachDb.CoachInvites.Where(r => r.ID == _SelectedUser).FirstOrDefault();
            FoundCoach.RequestStatus = "Agreed to practise";

            _CoachDb.Update(FoundCoach);
            _CoachDb.SaveChanges();

            InvitesLoad(_CoachDb);

        }

        private void DeniRqst(object sender, RoutedEventArgs e) //deni rqst Btn
        {
            int _ClientInSelection = (dataGrid_requests.SelectedItem as CoachInvites).ID; 
            var FoundCoach = _CoachDb.CoachInvites.Where(r => r.ID == _ClientInSelection).FirstOrDefault();
            FoundCoach.RequestStatus = "Request was denied";

            _CoachDb.Update(FoundCoach);
            _CoachDb.SaveChanges();

            InvitesLoad(_CoachDb);

        }

        private void adding_coach_MI_Click(object sender, RoutedEventArgs e)
        {
            InteractingToCoach SecondaryWindow = new InteractingToCoach();

            SecondaryWindow.Show();
        }

        private void Refresh_btn_Click(object sender, RoutedEventArgs e)
        {
            CoachesListLoad(_CoachDb);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ProgramCreating_Coach WindowForCreating = new ProgramCreating_Coach(CurrentCoach);
        }
    }
}
