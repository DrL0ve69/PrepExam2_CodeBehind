using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace PrepExam2_CodeBehind
{
    public class Produit
    {
        private string _nom;
        private int _code;
        private double _prix;
        private double _prixVente;
        private int _quantite;
        public string Nom 
        {
            get => _nom;
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Le nom ne peut pas être vide");
                }
                _nom = value;
            }
        }
        public int Code 
        {
            get => _code;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Le code ne peut pas être négatif ou égal à 0");
                }
                _code = value;
            }
        }
        public double Prix
        {
            get => _prix;
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Le prix ne peut pas être négatif.");
                }
                _prix = value;
            }
        }
        public double PrixVente
        {
            get => _prixVente;
            set
            {
                if (value <= Prix)
                {
                    throw new ArgumentException("Le prix de vente ne peut pas être plus bas ou égal au prix stock.");
                }
                _prixVente = value;
            }
        }
        public int Quantite
        {
            get => _quantite;
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("La quantité ne peut pas être négative ou égale à 0");
                }
                _quantite = value;
            }
        }
        public double MargeProfit => PrixVente - Prix;
        public double MontantTotal => PrixVente * Quantite;
        public Produit()
        {
        }
        public Produit(string nom, int code, double prix, double prixVente, int quantite)
        {
            
            Nom = nom;
            Code = code;
            Prix = prix;
            PrixVente = prixVente;
            Quantite = quantite;
        }
        public override string ToString()
        {
            return 
                $"Nom: {Nom}, Code: {Code}\n" +
                $"Prix: {Prix}$, Prix de vente: {PrixVente}$\n" +
                $" Quantité: {Quantite}\n" +
                $" Marge de profit par item: {MargeProfit}$\n" +
                $" Montant total: {MontantTotal}$";
        }
        // Ajouter les fonctions Sauvegarder et Ouvrir
        public void Sauvegarder()
        {
            string path = $"produit{Code}.json";
            string json = JsonSerializer.Serialize(this);
            File.WriteAllText(path, json);
        }
        public static Produit Ouvrir(int code)
        {
            string path = $"produit{code}.json";
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<Produit>(json);
        }
    }
}
