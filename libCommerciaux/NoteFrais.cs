using System;
using System.Collections.Generic;
using System.Text;

namespace libCommerciaux
{
    [System.Serializable]
    public class NoteFrais
    {
        private int numeroNote;
        private DateTime dateFrais;
        private double montantARembourser;
        private Commercial leCommercial;
        private bool EstRembourse;

        public NoteFrais() { }
        public NoteFrais(DateTime d, Commercial c)
        {
            this.dateFrais = d;
            this.montantARembourser = 0;
            this.leCommercial = c;
            this.numeroNote = c.getMesNotesFrais().Count;
            this.EstRembourse = false;
            this.leCommercial.ajouterNoteFrais(this);
        }

        public DateTime GetDateFrais
        {
            get { return this.dateFrais; }
            set { this.dateFrais = value; }
        }
        public double GetMontantARembourser
        {
            get { return this.montantARembourser; }
            set { this.montantARembourser = value; }
        }
        public Commercial GetLeCommercial
        {
            get { return this.leCommercial; }
            set { this.leCommercial = value; }
        }
        public bool GetEstRembourse
        {
            get { return this.EstRembourse; }
            set { this.EstRembourse = value; }
        }
        //public int getYear()
        //{
        //    return  this.dateFrais.Year;
        //}

        public void setRembourse()
        {
            this.EstRembourse = true;
        }

        public void setMontantARembourser()
        {
            this.montantARembourser = calculMontantARembourser();
        }
        virtual public double calculMontantARembourser()
        {
            return 0;
        }

        public override string ToString()
        {
            string texte;
            if (this.montantARembourser > 0) { texte = "Non Remboursé"; }
            else { texte = "Remboursé"; }
            return $"Numéro : {this.numeroNote} - Date : {this.dateFrais} - Montant à rembourser : {this.montantARembourser} euros - {texte}";
        }

        public string getMesNotesFrais(Commercial c)
        {
            string s = "Liste des notes de frais de " + c.GetNom + " " + c.GetPrenom+"\n";
            foreach(NoteFrais unNoteFrais in c.getMesNotesFrais())
            {
                s += unNoteFrais.ToString()+"\n";
            }
            return s;
        }

        public bool getEstRembourse()
        {
            if (this.EstRembourse == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
