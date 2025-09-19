using System;

class CalculosMatematicas
{
    public int Calcular(int a, int b) {
        Func<int, int, int> operacion= (x, y) => (x + y)*(x - y);
        return operacion(a, b);

    }
}
class Program { 
    static void Main() {

        CalculosMatematicas calculadora = new CalculosMatematicas();


        Console.Write("Ingrese el primer número (a): ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Ingrese el segundo número (b): ");
        int b = int.Parse(Console.ReadLine());

        int resultado = calculadora.Calcular(a, b);

        Console.WriteLine($"El resultado de ({a}+{b})*({a}-{b}) es: {resultado}");
    }
}