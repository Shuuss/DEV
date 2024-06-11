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
using System.Windows.Shapes;

namespace P2_ListeClients
{
    /// <summary>
    /// Logique d'interaction pour FicheClient.xaml
    /// </summary>
    public enum Mode { Creation, Modification }

    public partial class FicheClient : Window
    {
        public FicheClient(Mode mode)
        {
            InitializeComponent();
            this.Title = mode.ToString();
            if (mode == Mode.Creation)
            {
                btValider.Content = "Créer";
            }
            else
            {
                btValider.Content = "Modifier";
            }
        }

        private void btValider_Click(object sender, RoutedEventArgs e)
        {
            bool ok = true;
            foreach (UIElement uie in sp.Children)
            {
                if (uie is TextBox)
                {
                    TextBox txt = (TextBox)uie;
                    txt.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                }
                if (Validation.GetHasError(uie))
                    ok = false;
            }
            dpDateNaissance.GetBindingExpression(DatePicker.SelectedDateProperty).UpdateSource();
            if (Validation.GetHasError(dpDateNaissance))
                ok = false;
            if (ok)
            {
                DialogResult = true;
            }
            else 
            { 
                MessageBox.Show("tous les champs ne sont pas correctement renseignés"); 
            }
        }

        private void btAnnuler_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
