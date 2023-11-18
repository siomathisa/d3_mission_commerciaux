using System;
using System.Collections.Generic;
using System.Text;

namespace libCommerciaux
{
    [System.Serializable]
    public class FraisTransport : NoteFrais
    {
        private int km;
        private int puissanceVoiture;

        public FraisTransport(DateTime d, Commercial c, int km) : base (d, c)
        {
            this.km = km;
            this.puissanceVoiture = c.GetPuissanceVoiture;
        }

        public override double calculMontantARembourser()
        {
            double montant;
            if (this.puissanceVoiture < 5)
            {
                montant = this.km * 0.1;
            }
            else if(this.puissanceVoiture >= 5 && this.puissanceVoiture <= 10)
            {
                montant = this.km * 0.2;
            }
            else
            {
                montant = this.km * 0.3;
            }
            return montant;
        }

        public override string ToString()
        {
            this.GetMontantARembourser = calculMontantARembourser();
            return base.ToString() + $"  - {this.km} km";
        }
    }
}
