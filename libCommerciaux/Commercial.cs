using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libCommerciaux
{
    public class Commercial
    {
        private string nom;
        private string prenom;
        private string categorie;
        private int puissanceVoiture;
        private List<NoteFrais> mesNotesFrais;

        public Commercial() { }
        public Commercial(string nom, string prenom, string categorie, int puissanceVoiture)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.categorie = categorie;
            this.puissanceVoiture = puissanceVoiture;
            this.mesNotesFrais = new List<NoteFrais>();
        }

        public string GetNom
        {
            get { return this.nom; }
            set { this.nom = value; }
        }
        public string GetPrenom
        {
            get { return this.prenom; }
            set { this.prenom = value; }
        }
        public string GetCategorie
        {
            get { return this.categorie; }
            set { this.categorie = value; }
        }
        public int GetPuissanceVoiture
        {
            get { return this.puissanceVoiture; }
            set { this.puissanceVoiture = value; }
        }
        public List<NoteFrais> getMesNotesFrais()
        {
            return this.mesNotesFrais;
        }

        public void ajouterNoteFrais(NoteFrais f)
        {
            this.mesNotesFrais.Add(f);
        }
        public override string ToString()
        {
            return $"Nom : {this.nom} - Prénom : {this.prenom} - Catégorie : {this.categorie} - Puissance voiture : {this.puissanceVoiture}";
        }
    }
}
