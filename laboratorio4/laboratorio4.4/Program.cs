internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Ingrese la nota del estudiantes");
        float score = float.Parse(Console.ReadLine());

        if (score >= 70)
        {
            Console.WriteLine();
            Console.WriteLine($"Su nota es {score} ha aprobado");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine();

        }
    }
}