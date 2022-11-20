using NewProblems.Contexts;
using NewProblems.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace NewProblems.WIndows
{
    /// <summary>
    /// Interaction logic for ProgramCreating_Coach.xaml
    /// </summary>
    public partial class ProgramCreating_Coach : Window
    {
        UsersContext _db = new UsersContext();

        private string CoachInSession { get; set; }
        public ProgramCreating_Coach(string coach)
        {
            InitializeComponent();
            GridLoad(_db);
            CoachInSession = coach;
        }

        private void GridLoad(UsersContext context)
        {
            datagrid.ItemsSource = context.CoachInvites.Where(x => x.RequestStatus == "Agreed to practise").ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var SelectedValueExer = (ComboBoxItem)ExcersiePerCircle_cmb.SelectedValue;
                var SelectedValueRep = (ComboBoxItem)Repeats_count_cmb.SelectedValue;
                var SelectedValueType = (ComboBoxItem)TypeOfExcersice_cmb.SelectedValue;

                int exercise = (int)SelectedValueExer.Content;
                int repeats = (int)SelectedValueRep.Content;
                string type = (string)SelectedValueType.Content;

                TrainingsList NewTrainingSession = new TrainingsList()
                {
                    ActionsPerRepeat = exercise,
                    CreatedForWho = datagrid.SelectedItem.ToString(),
                    CoachName = CoachInSession,
                    Repeats = repeats,
                    TypeOfExcersice = type
                };

                _db.Add(NewTrainingSession);
                _db.SaveChanges();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // Exit button
        {
            Close();
        }
    }
}
