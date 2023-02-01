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
    /// Interaction logic for ClientListWindow.xaml
    /// </summary>
    public partial class ClientListWindow : Page
    {
        private Window mainWindow;
        private User currentUser;

        private Client currentClient;

        private ClientDB clientDB = new ClientDB();

        public ClientListWindow(Window mainWindow, User user)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
            this.currentUser = user;

            InitUsers();
        }

        private void InitUsers()
        {
            if(currentUser.U_Type == "Consultant")
                AddButton.Visibility = Visibility.Hidden;

            else
                AddButton.Visibility = Visibility.Visible;

            clientDB.Load();
            RebuildListBox();
        }


        private void RebuildListBox()
        {
            ClientsList.Items.Clear();

            if (ClientsList == null)
                return;

            if (ClientDB.Clients == null)
                ClientDB.Clients = new List<Client>();

            foreach (var client in ClientDB.Clients)
            {
                ClientsList.Items.Add(client.Name);
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClientInfo.Visibility = Visibility.Visible;
            
            var index = (sender as ListBox).SelectedIndex;

            if (index < 0)
                return;

            currentClient = ClientDB.Clients[index];
            currentUser.InitClient(currentClient);

            if (currentClient != null) 
            {
                UName.Text = currentClient.Name;
                ULastName.Text = currentClient.LastName;
                USecondName.Text = currentClient.SecondName;

                Seria.Text = currentClient.DocDataSeries;
                Number.Text = currentClient.DocDataNumber;

                PhoneNumber.Text = currentClient.PhoneNumber;
            }

            SetElementsActive();
        }

        private void SetElementsActive()
        {
            bool isManager = currentUser.U_Type == "Consultant" ? false : true;

            UName.IsEnabled = isManager;
            ULastName.IsEnabled = isManager;
            USecondName.IsEnabled = isManager;
            Seria.IsEnabled = isManager;
            Number.IsEnabled = isManager;
            Seria.IsEnabled = isManager;

            if (!isManager)
            {
                var tS = Seria.Text.ToCharArray();
                var nS = Number.Text.ToCharArray();

                var sOut = "";
                var nOut = "";

                for (int i = 0; i < tS.Length; i++)
                    sOut += '*';

                for (int i = 0; i < nS.Length; i++)
                    nOut += '*';

                Seria.Text = sOut;
                Number.Text = nOut;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentUser.U_Type == "Manager")
            {
                var manager = (Manager)currentUser;
                manager.AddUser(ClientsList);

                RebuildListBox();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            currentUser.InitClient(currentClient);
            currentUser.Save(PhoneNumber.Text, UName.Text, USecondName.Text, ULastName.Text, Seria.Text, Number.Text);
            RebuildListBox();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            currentUser.InitClient(currentClient);
            currentUser.Save(PhoneNumber.Text, UName.Text, USecondName.Text, ULastName.Text, Seria.Text, Number.Text);
            mainWindow.Content = new MainPage(mainWindow);
        }
    }
}
