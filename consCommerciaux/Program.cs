using System;
using libCommerciaux;

namespace consCommerciaux
{
    class Program
    {
        static void Main(string[] args)
        {
            Commercial c;
            c = new Commercial("Jean", "Dupond", "A", 8);
            NoteFrais T0;
            T0 = new FraisTransport(1, new DateTime(2013, 11, 12), c, 250);
            Console.WriteLine(T0.ToString());
        }
    }
}
