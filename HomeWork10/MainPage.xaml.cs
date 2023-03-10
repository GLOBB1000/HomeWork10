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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private UsersDB consultantDB;
        private Window mainWindow;

        public MainPage(Window mainWindow)
        {
            InitializeComponent();

            consultantDB = new UsersDB();
            consultantDB.Load();
            this.mainWindow = mainWindow;
        }

        private void Create_Consultant(object sender, RoutedEventArgs e)
        {
            CreateConsultantWindow createConsultantWindow = new CreateConsultantWindow(mainWindow);
            mainWindow.Content = createConsultantWindow;
        }

        private void LoginCon(object sender, RoutedEventArgs e)
        {
            if (UsersDB.Users == null)
                UsersDB.Users = new List<User>();

            if (!string.IsNullOrEmpty(Login.Text) && !UsersDB.Users.Exists(x => x.Login == Login.Text))
                ErrorText.Text = "Consultant not found. Please create it";

            else
            {
                if (!string.IsNullOrEmpty(Pass.Password) && UsersDB.Users.Exists(x => x.Login == Login.Text && x.Password == Pass.Password))
                {
                    var curCons = UsersDB.Users.Find(x => x.Login == Login.Text);

                    if(curCons != null)
                        mainWindow.Content = new ClientListWindow(mainWindow, curCons);
                }
            }
        }

        private void Init(object sender, EventArgs e)
        {

        }
    }
}
