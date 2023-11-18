using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace libCommerciaux
{
    [System.Serializable]
    public class PersisteCommercial
    {
        public static void sauve(ServiceCommercial sc)
        {
            FileStream fichier = new FileStream("service.sr", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fichier, sc);
            fichier.Close();
        }
        public static void charge()
        {
            FileStream fichier = new FileStream("service.sr", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Deserialize(fichier);
            fichier.Close();
        }
    }
}
