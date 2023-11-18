using System;
using System.Collections.Generic;
using System.Text;

namespace libCommerciaux
{
    [System.Serializable]
    public class RepasMidi : NoteFrais 
    {
        private double factureRepas;
        private string categorie;

        public RepasMidi(DateTime date, Commercial commercial, double factureRepas) : base(date, commercial)
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
