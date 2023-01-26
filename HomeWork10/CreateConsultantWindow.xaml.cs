using HomeWork10.DataBases;
using HomeWork10.Users;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HomeWork10
{
    /// <summary>
    /// Interaction logic for CreateConsultantWindow.xaml
    /// </summary>
    public partial class CreateConsultantWindow : Page
    {
        private ConsultantDB consultantDB;
        private Window mainWindow;
        public CreateConsultantWindow(Window mainWindow)
        {
            InitializeComponent();
            consultantDB = new ConsultantDB();
            this.mainWindow = mainWindow;
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Login.Text) || string.IsNullOrEmpty(Pass.Password) || string.IsNullOrEmpty(PassRep.Password))
                return;

            if (ConsultantDB.Consultants == null)
                consultantDB.Load();

            if (ConsultantDB.Consultants.Exists(x => x.Login == Login.Text))
            {
                Username.Text = "User name is busy";
                Login.Background = Brushes.Red;
                return;
            }

            Username.Text = "";
            Login.Background = Brushes.White;
            var uType = (ComboBoxItem)UserType.SelectedValue;
            if(uType == null)
            {
                Username.Text = "Please select user type";
                return;
            }
                
            var newConsultant = new Consultant(Login.Text, Pass.Password, uType.Content.ToString());

            if (ConsultantDB.Consultants == null)
                ConsultantDB.Consultants = new List<Consultant>();

            ConsultantDB.Consultants.Add(newConsultant);
            consultantDB.Save();

            mainWindow.Content = new MainPage(mainWindow);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
