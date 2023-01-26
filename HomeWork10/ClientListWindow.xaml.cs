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
        private Consultant currentUser;

        private Client currentClient;

        private ClientDB clientDB = new ClientDB();

        public ClientListWindow(Window mainWindow, Consultant consultant)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
            this.currentUser = consultant;

            InitUsers();
        }

        private void InitUsers()
        {
            if(currentUser.UserType == "Consultant")
                AddButton.Visibility = Visibility.Hidden;

            else
                AddButton.Visibility= Visibility.Visible;

            clientDB.Load();
            RebuildListBox();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClientInfo.Visibility = Visibility.Visible;
            
            var index = (sender as ListBox).SelectedIndex;

            if (index <= 0)
                return;

            currentClient = ClientDB.Clients[index];

            if(currentClient != null) 
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
            bool isManager = currentUser.UserType == "Consultant" ? false : true;

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

        private void AddUser()
        {
            var newCl = new Client(currentUser);
            ClientsList.Items.Add(newCl);
            SetClientInfo(newCl);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddUser();
        }

        private void SetClientInfo(Client client)
        {
            if(ClientDB.Clients == null) 
                ClientDB.Clients = new List<Client>();

            ClientDB.Clients.Add(client);
            clientDB.Save();
            RebuildListBox();
        }

        private void RebuildListBox()
        {
            ClientsList.Items.Clear();

            if (ClientDB.Clients == null) return;

            clientDB.Save();

            foreach (var client in ClientDB.Clients)
            {
                ClientsList.Items.Add(client.Name);
            }
        }

        private void Save()
        {
            if (currentClient != null)
            {
                var client = ClientDB.Clients.Find(x => currentClient.Id == x.Id);

                if (client != null)
                {
                    client.PhoneNumber = PhoneNumber.Text;
                    client.Name = UName.Text;
                    client.LastName = ULastName.Text;
                    client.SecondName = USecondName.Text;

                    if (currentUser.UserType == "Manager")
                    {
                        client.DocDataSeries = Seria.Text;
                        client.DocDataNumber = Number.Text;
                    }

                    client.CheckData(currentUser);
                }

                clientDB.Save();
                RebuildListBox();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Save();
            mainWindow.Content = new MainPage(mainWindow);
        }
    }
}
