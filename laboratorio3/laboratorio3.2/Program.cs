using System;

namespace laboratorio32
{
    internal class laboratorio32
    {
        public static void Main(string[] args)
        {
            calculoArea();
        }

        static void calculoArea()
        {
            double radio, pi, area;
            Console.Write("Ingrese el radio del circulo ");
            radio = Convert.ToSingle(Console.ReadLine());

            pi = 3.14;

            area = pi * (Math.Pow(radio, 2));

            Console.WriteLine("El area del sirculo es: " + area);
        }
    }
}