using System;
using System.Collections.Generic;
using System.Text;

namespace libCommerciaux
{
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
