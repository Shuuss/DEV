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

namespace P1_BD_Locale
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      
        public MainWindow()
        {
           
            InitializeComponent();
            dgClients.Items.Filter = ContientMotClef;
          




        }
        private bool ContientMotClef(object obj)
        {
            Client unClient = obj as Client;
            if (String.IsNullOrEmpty(textMotClef.Text))
                return true;
            else
                return (unClient.Nom.StartsWith(textMotClef.Text, StringComparison.OrdinalIgnoreCase) ||
                    unClient.Prenom.StartsWith(textMotClef.Text, StringComparison.OrdinalIgnoreCase) );
        }


            
			
        private void butModifier_Click(object sender, RoutedEventArgs e)
        {
           if (dgClients.SelectedItem != null)
            {
                Client clientSelectionne = (Client)dgClients.SelectedItem;             
                FicheClient fiche = new FicheClient(Mode.Modification);
                fiche.UCPanelClient.DataContext = (Client)dgClients.SelectedItem;
                fiche.ShowDialog();
                if (fiche.DialogResult == true)
                {
                    data.Update(clientSelectionne);
                    dgClients.SelectedItem = clientSelectionne;
                }
            }
            else
                MessageBox.Show(this, "Veuillez selectionner un client");
          
        }

        private void butSupprimer_Click(object sender, RoutedEventArgs e)
        {
			
            if (dgClients.SelectedItem != null)
            {
                Client clientSelectionne = (Client)dgClients.SelectedItem;
                MessageBoxResult res = MessageBox.Show(this, "Etes vous sur de vouloir supprimer "
                    + clientSelectionne.Prenom + " " + clientSelectionne.Nom + " ?", "Confirmation",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (res == MessageBoxResult.Yes)
                    data.LesClients.Remove(clientSelectionne);
                    data.Delete(clientSelectionne);

            }
            else
                MessageBox.Show(this, "Veuillez selectionner un client");
			
        }

            private void butAjouter_Click(object sender, RoutedEventArgs e)
        {
            Client nouveauClient = new Client();
            FicheClient fiche = new FicheClient(Mode.Creation);
            fiche.UCPanelClient.DataContext = nouveauClient;
            fiche.ShowDialog();
            if (fiche.DialogResult == true)
            {
                data.LesClients.Add(nouveauClient);
                dgClients.SelectedItem = nouveauClient;
                data.Create(nouveauClient);
            }

        }



        private void textMotClef_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgClients.ItemsSource).Refresh();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            data.DeconnexionBD();
        }
    }
}
