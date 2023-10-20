using System;
using System.Collections.Generic;
using System.Text;

namespace libCommerciaux
{
    public class RepasMidi : NoteFrais 
    {
        private int factureRepas;
        private string categorie;

        public RepasMidi (int numeroNote, DateTime date, Commercial commercial, int factureRepas) : base(numeroNote, date, commercial)
        {
            this.categorie = commercial.GetCategorie;
            this.factureRepas = factureRepas;
        }

        public override double calculMontantARembourser()
        {
            double montant;
            if (this.factureRepas < 20)
            {
                montant = this.factureRepas;
            }
            else
            {
                if (this.categorie == "A")
                {
                    montant = 25;
                }
                else if (this.categorie == "B")
                {
                    montant = 22;
                }
                else
                {
                    montant = 20;
                }
            }
            return montant;
        }

        public override string ToString()
        {
            this.GetMontantARembourser = calculMontantARembourser();
            return base.ToString();
        }
    }
}
