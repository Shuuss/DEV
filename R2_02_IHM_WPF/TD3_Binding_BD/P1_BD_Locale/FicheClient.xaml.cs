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

namespace P1_BD_Locale
{

    public enum Mode { Creation, Modification};
    /// <summary>
    /// Logique d'interaction pour FicheClient.xaml
    /// </summary>
    public partial class FicheClient : Window
    {
        public FicheClient( Mode leMode)
        {
            InitializeComponent();
            if (leMode == Mode.Creation)
                this.Title = "Creation d'un client";
            else if(leMode == Mode.Modification)
                this.Title = "Modification d'un client";
        }

        private void butValider_Click(object sender, RoutedEventArgs e)
        {
            bool ok = true;
            foreach (UIElement uie in UCPanelClient.mainPanel.Children)
            {
                if (uie is TextBox)
                {
                    TextBox txt = (TextBox)uie;
                    txt.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                }
                
                if (Validation.GetHasError(uie))
                    ok = false;
            }
            foreach (UIElement uie in UCPanelClient.panelRadioBouton.Children)
            {
                RadioButton rb = (RadioButton)uie;
                rb.GetBindingExpression(RadioButton.IsCheckedProperty).UpdateSource();
                if (Validation.GetHasError(uie))
                    ok = false;
            }




            UCPanelClient.dpDate.GetBindingExpression(DatePicker.SelectedDateProperty).UpdateSource();
            if (ok)
                DialogResult = true;
            else
                MessageBox.Show(this, "Erreur", "Vérifiez vos informations.", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void butAnnuler_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
