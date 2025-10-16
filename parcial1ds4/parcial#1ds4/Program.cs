using System;

namespace parcial1ds4
{
    class Program
    // Rodolfo Arias 9-745-2122
    {
        static void Main(string[] args)
        {
            int a;
            do
            {
                Console.WriteLine("Debe ser par:");
                a = int.Parse(Console.ReadLine());
            } while (a % 2 != 0);

            int b;
            do
            {
                Console.WriteLine("Debe ser par:");
                b = int.Parse(Console.ReadLine());
            } while (b % 2 != 0);

            int[,] matriz = new int[a, b];
            Random numero = new Random();
            int sumaAleatorios = 0;

            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    
                    if (i == j && !((i == 0 && j == 0) || (i == a - 1 && j == b - 1)))
                    {
                        matriz[i, j] = numero.Next(101, 200);
                        sumaAleatorios += matriz[i, j];
                    }
                    else
                    {
                        matriz[i, j] = 0;
                    }
                }
            }

            Console.WriteLine("\nMatriz:");
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    Console.Write($"{matriz[i, j],8}");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"\nSuma de los elementos aleatorios: {sumaAleatorios}");

            Console.ReadKey(true);
        }
    }
}
