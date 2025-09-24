internal class Program
{
    private static void Main(string[] args)
    {
        Dictionary<string, string> paisesCapitales = new Dictionary<string, string>
        {
            {"Francia","Paris" },
            { "España", "Madrid"},
            {"Italia","Roma" }
        };
        foreach (KeyValuePair<string, string> pasCap in paisesCapitales)
        {
            Console.WriteLine("La capital es " + pasCap.Value + "  " + "y el pais es: " + pasCap.Key);
        }
    }
}