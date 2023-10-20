using System;
using System.Collections.Generic;
using System.Text;

namespace libCommerciaux
{
    public class Nuite : NoteFrais
    {
        private string categorieNuite;
        private int region;
        private int facture;

        public Nuite (int n, DateTime d, Commercial c, int region, int facture) : base(n, d, c)
        {
            this.categorieNuite = c.GetCategorie;
            this.region = region;
            this.facture = facture;
        }

        public override double calculMontantARembourser()
        {
            double montant;
            double coef;
            if(this.region == 1)
            {
                coef = 0.9;
            }
            else if(this.region == 2)
            {
                coef = 1;
            }
            else
            {
                coef = 1.15;
            }

            if (this.facture < 50)
            {
                montant = this.facture;
            }
            else
            {
                if (this.categorieNuite == "A")
                {
                    montant = 65*coef;
                }
                else if (this.categorieNuite == "B")
                {
                    montant = 22*coef;
                }
                else
                {
                    montant = 20*coef;
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

