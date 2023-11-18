using System;
using System.Collections.Generic;
using System.Text;

namespace libCommerciaux
{
    [System.Serializable]
    public class ServiceCommercial
    {
        private List<Commercial> lstCommerciaux;

        public ServiceCommercial() {
            this.lstCommerciaux = new List<Commercial>();
        }

        public void ajouterCommercial(Commercial c)
        {
            this.lstCommerciaux.Add(c);
        }

        public void ajouterNote(Commercial c, DateTime date, int km)
        {
            NoteFrais fraistransport = new FraisTransport(date, c, km);
        }
        public void ajouterNote(Commercial c, DateTime date, double facture)
        {
            NoteFrais repasmidi = new RepasMidi(date, c, facture);
        }
        public void ajouterNote(Commercial c, DateTime date, int facture, int region)
        {
            NoteFrais nuite = new Nuite(date, c, region, facture);
        }

        public List<Commercial> getLstCommerciaux()
        {
            return this.lstCommerciaux;
        }

        public int nbFraisNonRembourses()
        {
            int nb = 0;
            foreach (Commercial c in this.lstCommerciaux)
            {
                foreach(NoteFrais n in c.getMesNotesFrais())
                {
                    if (n.getEstRembourse() == false)
                    {
                        nb += 1;
                    }
                }
            }
            return nb;
        }


    }
}
