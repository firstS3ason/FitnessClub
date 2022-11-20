using System;
using System.Linq;
using System.Windows;
using NewProblems.Contexts;
using NewProblems.Models;

namespace NewProblems.WIndows
{
    /// <summary>
    /// Interaction logic for InteractingToCoach.xaml
    /// </summary>
    public partial class InteractingToCoach : Window
    {
        UsersContext dbAddingC = new UsersContext();
        public InteractingToCoach()
        {
            InitializeComponent();
            LoadingUsers(dbAddingC);
        }
        private void LoadingUsers(UsersContext context)
        {
            UsersDataGrid.ItemsSource = dbAddingC.GetAll().ToList();

        }
        private bool IsHavingInfoTxts()
        {
            if (txtAge.Text != "" && txtName.Text != "" &&

                txtProfessionalIn.Text != "" && txtGender.Text != "" )
            
            {
                return true; 
            }
            else
            {
                MessageBox.Show("Значения отсутствует, внутри области для ввода значений.");
                return false;
            }

        }
        private void Button_Click(object sender, RoutedEventArgs e) //AddNewCoach_btn
        {
            try
            {
                if (IsHavingInfoTxts())
                {
                    Coaches NewCoach = new Coaches()
                    {
                        CoachName = txtName.Text,
                        Age = Int32.Parse(txtAge.Text),
                        InOurGymFrom = Calendar_ChooseDate.SelectedDate,
                        Gender = txtGender.Text,
                        SpecialistIn = txtProfessionalIn.Text,
                        YearsInStudyPractise = Calendar_ChooseDate.YearsInPractise
                    };

                    dbAddingC.Coaches.Add(NewCoach);
                    dbAddingC.SaveChanges();

                }
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message); 
            }
           

        }

        private void escape_btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Calendar_ChooseDate clndr_Window = new Calendar_ChooseDate();
            clndr_Window.Show();
        }
    }
}
