using System;

namespace laboratorio21 { 


    public class Program
     {
         public static void Main(string[] args)
         {
 MyClass.Valor = 2;
 Console.WriteLine(MyClass.Valor);
         }
     }
     public class MyClass
     {
         public static int Valor;
     }
 }