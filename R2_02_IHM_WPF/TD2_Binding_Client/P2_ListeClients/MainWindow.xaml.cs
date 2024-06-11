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

namespace P2_ListeClients
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public bool modification;
        public MainWindow()
        {
            InitializeComponent();
            dgClients.Items.Filter = ContientMotClef;
            modification = false;
        }
        private bool ContientMotClef(object obj)
        {
            Client unClient = obj as Client;
            if (String.IsNullOrEmpty(textMotClef.Text))
                return true;
            else
                return (unClient.Nom.StartsWith(textMotClef.Text, StringComparison.OrdinalIgnoreCase)
                || unClient.Prenom.StartsWith(textMotClef.Text, StringComparison.OrdinalIgnoreCase));
        }

        private void textMotClef_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgClients.ItemsSource).Refresh();
        }

        private void butEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            data.Sauvegarde();
            modification = false;
        }

        private void butModifier_Click(object sender, RoutedEventArgs e)
        {
            Client clientSelectionner = (Client)dgClients.SelectedItem;
            Client clientCopie = new Client(clientSelectionner.Nom, clientSelectionner.Prenom, clientSelectionner.Email, clientSelectionner.DateNaissance, clientSelectionner.Telephone);
            if (clientSelectionner is null)
            {
                MessageBox.Show("sélectionnez un client pour le modifier");
            }
            else
            {
                FicheClient fiche = new FicheClient(Mode.Modification);
                fiche.DataContext = clientCopie;
                fiche.ShowDialog();
                if (fiche.DialogResult == true)
                {
                    data.LesClients.Insert(data.LesClients.IndexOf(clientSelectionner), clientCopie);
                    data.LesClients.Remove(clientSelectionner);
                    modification = true;
                }
            }
        }

        private void butAjouter_Click(object sender, RoutedEventArgs e)
        {
            Client nouveauClient = new Client();
            FicheClient fiche = new FicheClient(Mode.Creation);
            fiche.DataContext = nouveauClient;
            fiche.ShowDialog();
            if (fiche.DialogResult == true)
            {
                data.LesClients.Add(nouveauClient);
                dgClients.SelectedItem = data.LesClients.Last();
                modification = true;
            }
        }

        private void butSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (dgClients.SelectedItem is null)
            {
                MessageBox.Show("veuillez sélectionner un client");
            }
            else
            {
                Client clientSelectionne = (Client)dgClients.SelectedItem;
                MessageBoxResult ouiNon = MessageBox.Show($"êtes vous sûr(e) de vouloir supprimer {clientSelectionne.Nom} {clientSelectionne.Prenom} ?", "suppression", MessageBoxButton.YesNo);
                if (ouiNon == MessageBoxResult.Yes)
                {
                    modification = true;
                    data.LesClients.Remove(clientSelectionne);
                }
            }

        }
        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (modification)
            {
                MessageBoxResult result = MessageBox.Show(this, "Warning", "Voulez-vous sauvegarder vos modifications ? ", MessageBoxButton.YesNoCancel, MessageBoxImage.Error);
                if (result == MessageBoxResult.Cancel)
                    e.Cancel = true;
                else if (result == MessageBoxResult.Yes)
                {
                    data.Sauvegarde();
                }
            }
            
        }
    }
}
