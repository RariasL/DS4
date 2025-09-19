namespace laboratorio2
{
    class Program
     {
         static void Main(string[] args)
         {
 Client client = new Client();
 client.FirstName = "Rodolfo";
 client.LastName = "Arias";
 client.Age = 30;
 client.id = 1;

 Console.WriteLine(client.GetFullName());
         }
     }
     public class Client
     {
         public int id { get; set; }
         public string FirstName { get; set; }
         public string LastName { get; set; }
         public int Age { get; set; }
        public string GetFullName()
         {
             return FirstName + " " + LastName;
         }
     }
 }