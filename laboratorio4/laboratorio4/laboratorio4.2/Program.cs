internal class Program
{
    private static void Main(string[] args)
    {
        int fact = 1, n;
        string linea;
        Console.WriteLine("Ingrese un numero entero: ");
        linea = Console.ReadLine();

        n = int.Parse(linea);
        for (int i = 1; i <= n; i++)
        {
            fact = fact * i;

        }

        Console.WriteLine("La factorial es: " + fact);
        Console.ReadKey();
    }
}