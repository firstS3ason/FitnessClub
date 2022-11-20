using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace NewProblems.WIndows
{
    /// <summary>
    /// Interaction logic for Calendar_ChooseDate.xaml
    /// </summary>
    public partial class Calendar_ChooseDate : Window
    {
        public Calendar_ChooseDate()
        {
            InitializeComponent();
            
        }
        private bool IsEnabled;
        public static DateTime SelectedDate { get; set; }
        public static int YearsInPractise { get; set; }

        private void GettingDate()
        {
            SelectedDate = Calendar.SelectedDate.Value;
        }
        private void GettingYearsInfo()
        {
            YearsInPractise = Int32.Parse(YearsPractised_txt.Text);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            brd.Height = 0;
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            // to Inspect

            DoubleAnimation da = new DoubleAnimation();
            if (!IsEnabled)
            {
                da.To = 90;
                da.Duration = TimeSpan.FromSeconds(1);
                brd.BeginAnimation(Border.HeightProperty, da);
                IsEnabled = true;
            }
            else
            {
                da.To = 0;
                da.Duration = TimeSpan.FromSeconds(1);
                brd.BeginAnimation(Border.HeightProperty, da);
                IsEnabled = false;
            }

            // to Investigate 
        }

        private void Button_Click(object sender, RoutedEventArgs e) // DateChooseBtn
        {
            GettingDate();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // ClearTxtBtn  
        {
            YearsPractised_txt.Clear();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            GettingYearsInfo();
        }

        private void escape_btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
