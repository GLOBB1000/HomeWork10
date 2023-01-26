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

            currentClient = new Client();

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
            
            var index = ((sender as ListBox).SelectedIndex);

            currentClient = ClientsList.Items[index] as Client; 
            if(currentClient != null) 
            {
                UName.Text = currentClient.Name;
                ULastName.Text = currentClient.LastName;
            }
        }

        private void AddUser()
        {
            var newCl = new Client();
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

            foreach (var client in ClientDB.Clients)
            {
                ClientsList.Items.Add(client);
            }
        }

        private void ClientsList_Selected(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
