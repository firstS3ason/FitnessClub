using NewProblems.Contexts;
using NewProblems.Interfaces;
using NewProblems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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

namespace NewProblems.WIndows
{
    /// <summary>
    /// Interaction logic for BuyerWindow.xaml
    /// </summary>
    public partial class BuyerWindow : Window
    {
        public string UserName { get; set; }
        public DateTime DateOfBeingPartners { get; set; }

        UsersContext _BuyerDb = MainWindow._db;
        public BuyerWindow()
        {
            InitializeComponent();
            try
            {
                DataGridLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         

        }
     
        public void DataGridLoad()
        {
            

            DataGrid_buyer.ItemsSource = _BuyerDb.CoachInvites.ToList();
        }
      

        public void SendingInfo()
        {

        }
        public void ChoosingCoach()
        {

        }
    }
}
