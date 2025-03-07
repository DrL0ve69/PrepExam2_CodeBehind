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

namespace PrepExam2_CodeBehind
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Produit Produit { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                Produit = new Produit
                {
                    Nom = txtBoxNom.Text,
                    Code = int.Parse(txtBoxCode.Text),
                    Prix = double.Parse(txtBoxPrix.Text),
                    PrixVente = double.Parse(txtBoxPrixVente.Text),
                    Quantite = int.Parse(txtBoxQuantite.Text)
                };
                txtBlockDisplay.Text = Produit.ToString();
                Produit.Sauvegarder();
                lblErreur.Foreground = Brushes.Green;
                lblErreur.Content = "Sauvegarde réussie";
                txtBoxNom.Text = "";
                txtBoxCode.Text = "";
                txtBoxPrix.Text = "";
                txtBoxPrixVente.Text = "";
                txtBoxQuantite.Text = "";
                txtBoxRechcherCode.Text = "";
            }
            catch (Exception ex)
            {
                lblErreur.Foreground = Brushes.Red;
                lblErreur.Content = ex.Message;
            }
            
        }

        private void btnOuvrir_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                Produit = Produit.Ouvrir(int.Parse(txtBoxRechcherCode.Text));
                txtBlockDisplay.Text = Produit.ToString();
                lblErreur.Foreground = Brushes.Green;
                lblErreur.Content = "Ouverture réussie";
                txtBoxNom.Text = Produit.Nom;
                txtBoxCode.Text = Produit.Code + "";
                txtBoxPrix.Text = Produit.Prix + "";
                txtBoxPrixVente.Text = Produit.PrixVente + "";
                txtBoxQuantite.Text = Produit.Quantite + "";
            }
            catch (Exception ex)
            {
                lblErreur.Foreground = Brushes.Red;
                lblErreur.Content = ex.Message +"\nLe produit que vous recherchez n'existe pas.";
            }
        }
    }
}
