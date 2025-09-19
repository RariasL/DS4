using System;

namespace Laboratorio33
{
    internal class lab33
    {
        public static void Main(string[] args)
        {
            double perimetro, longitud, ancho;

            Console.Write("Ingrese la longitud del rectangulo ");
            longitud = Convert.ToSingle(Console.ReadLine());

            Console.Write("Ingrese el ancho del rectangulo ");
            ancho = Convert.ToSingle(Console.ReadLine());

            perimetro = 2 * (longitud + ancho);

            Console.WriteLine("El perimetro de rectangulo es: " + perimetro);
        }
    }
}