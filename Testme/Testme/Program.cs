using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testme
{
    //Skapa en funktion som tar en List<T> och en Func<T, T, T> delegate som parametrar
    //och returnerar ett värde av typen T.

    //Du bestämmer själv vilken datatyp du vill använda i stället för T.

    //Funktionen ska heta Reduce och den ska reducera listan till ett värde.

    //Om listan till exempel består av strängar så är ett sätt att reducera den att konkatenera
    //alla strängar i listan och returnera resultatet.

    //Om listan består av tal så kan man reducera listan genom att räkna ut till exempel summan,
    //max- eller min-värdet. Delegaten ska alltså vara funktionen som utför själva reduceringen.

    //public delegate void Action();
    //public delegate void EvenOdd(int num);
    public delegate int Summer(List<int> list, Func<int, int, int> func);
    public delegate int Func(Func<int, int, int> func);

    public class Program
    {
        static void Main(string[] args)
        {
            Summer summer = new Summer(Reduce);
            Func<int,int,int> func = new Func<int, int, int>(SummerFunc);
            List<int> list = new List<int>();
            for (int i = 1; i < 9; i++)
            {
                list.Add(i);
            }
            list.Add(0);
            int sum = summer(list, func);
            Console.WriteLine(sum);
            Console.Read();

        }
        public static int Reduce(List<int> myList, Func<int, int, int> myFunc)
        {
            int sum=0;
            foreach (int num in myList)
            {
                sum = myFunc(sum, num);
                
            }
            
            return sum;
        }
        public static int SummerFunc (int num1, int num2)
        {
            int sum = num2 + num1;
            return sum;
        }
            
/*        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            Random rnd = new Random();
            for (int i = 0; i < 30; i++)
            {
                list.Add(rnd.Next(30));
            }
            EvenOdd evenOdd = new EvenOdd(OddEven);
            Printer(list, evenOdd, evenOdd);
            Console.Read();
        }
        public static void Printer(List<int> list, EvenOdd even, EvenOdd odd)
        {
            //Loop list
            for (int i = 0; i < list.Count; i++)
            {
                if (list.ElementAt(i)%2!=0)
                {
                    odd(list.ElementAt(i));
                }
                else if (list.ElementAt(i)%2==0)
                {
                    even(list.ElementAt(i));
                }
            }
                //print odd
                //print even
        }
        public static void OddEven(int num){
            Console.WriteLine(num);
        }
        /*
        static void Main(string[] args)
        {
            Action action = new Action(PrintMessage);
            Console.WriteLine("UGABUGA");
            UsesCallback(action);
            Console.Read();
        }
        public static void UsesCallback(Action action)
        {
            action();
        }
        public static void PrintMessage()
        {
            Console.WriteLine("This is a message");
        }
        */
    }
}
