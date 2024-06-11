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

namespace TD1_RevisionsLayout
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btOK_Click(object sender, RoutedEventArgs e)
        {

            string genre = "";
            foreach (RadioButton rb in spGenre.Children)
            {
                if (rb.IsChecked==true)
                {
                    genre = rb.Content.ToString();
                }
            }
            MessageBox.Show($"Genre : {genre}" +
                $"\nNom : {tbNom.Text}" +
                $"\nPrénom : {tbPrenom.Text}");
        }
        private void ButtonNumber_Click(object sender, RoutedEventArgs e)
        {
            tbCalc.Text += ((Button)sender).Content.ToString();
        }

        private void ellipse_MouseMove(object sender, MouseEventArgs e)
        {
            System.Windows.Point position = e.GetPosition(canvas);
            double pX = position.X;
            double pY = position.Y;

            Canvas.SetTop(ellipse, pY);
            Canvas.SetLeft(ellipse, pX);
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Image)sender).Height += 100;
            ((Image)sender).Width += 100;
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Image)sender).Height -= 100;
            ((Image)sender).Width -= 100;
        }
    }
}
