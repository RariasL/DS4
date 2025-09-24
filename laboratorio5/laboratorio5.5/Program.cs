class Estudiante
{
    public string nombre { get; set; }
    public int edad { get; set; }
}
class Program
{
    public static void Main(string[] args)
    {
        List<Estudiante> estudiantes = new List<Estudiante> {

        new Estudiante { nombre = "Ana", edad = 12 },
        new Estudiante { nombre = "juan", edad = 10 },
        new Estudiante { nombre = "sofia", edad = 11 }

    };

        foreach (Estudiante estudiante in estudiantes)
        {
            Console.WriteLine("Nombre: " + estudiante.nombre + ",Edad:" + estudiante.edad);
        }
    }
}



