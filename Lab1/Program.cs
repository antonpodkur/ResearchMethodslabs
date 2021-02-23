using static System.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleTables;

namespace Lab1
{
    class Program
    {

        // Variant 217

        public static List<int> getFactor(int length) // Function to get Factor
        {
            Random random = new Random();
            List<int> factor = new List<int>();
            for (int i = 0; i < length; i++) factor.Add(random.Next(1,21));
            return factor;
        }

        public static List<float> getX0AndDxAndXn(List<int> factor ,out int x0, out int dx){ // Function that generates x0, dx through 
            x0 = (factor.Max() + factor.Min())/2;                                            // links and returns xn as List
            dx = x0 - factor.Min();
            var xn = new List<float>();
            for (int i = 0; i<factor.Count(); i++)
            {
                xn.Add(((float) factor[i] - x0)/dx);
            }
            return xn;
        }

        public static void print(string name, IEnumerable<int> factor, int x0, int dx, IEnumerable<float> xn) // Just function that prints values
        {
            var table = new ConsoleTable("F`X"+name, "x0"+name, "dx"+name, "xn"+name);
            table.AddRow(String.Join(", ", factor),x0,dx,String.Join(", ", xn));
            table.Configure(o => o.NumberAlignment = Alignment.Right);
            table.Write(Format.Alternative);
            WriteLine();
        }   
        static void Main(string[] args)
        {
            const int LENGTH = 8; 
            var random = new Random();

            List<int> y = new List<int>();
            int y_et;
            
            // Setting all as
            int a0 = random.Next(1,21);
            int a1 = random.Next(1,21);
            int a2 = random.Next(1,21);
            int a3 = random.Next(1,21);


            // Getting factor listint answ = y.Min();s x0s, dxs and lists of xns
            var factorX1 = getFactor(LENGTH);
            int x01;
            int dx1;
            var xn1 = getX0AndDxAndXn(factorX1,out x01, out dx1);

            var factorX2 = getFactor(LENGTH);
            int x02;
            int dx2;
            var xn2 = getX0AndDxAndXn(factorX2,out x02, out dx2);

            var factorX3 = getFactor(LENGTH);
            int x03;
            int dx3;
            var xn3 = getX0AndDxAndXn(factorX3,out x03, out dx3);


            // Generating y list
            for(int i = 0; i < LENGTH; i++)
            {
                y.Add(a0 + a1 * factorX1[i] + a2 * factorX2[i] + a3 * factorX3[i]);
            }

            // Calculating y_et
            y_et = a0 + a1 * x01 + a2 * x02 + a3 * x03;

            
            // Calculating the result for my variant 217 (min(y))
            int index = y.IndexOf(y.Min());




            // Printing all the data

            WriteLine("+++++++++ Random coeficients +++++++++");
            var table = new ConsoleTable("a", "a1", "a2", "a3");
            table.AddRow(a0,a1,a2,a3).Configure(o => o.NumberAlignment = Alignment.Right).Write(Format.Alternative);

            WriteLine("+++++++++ f`Y equation +++++++++");
            WriteLine($"f`Y = {a0} + {a1}*X1 + {a2}*X2 + {a3}*X3");
            WriteLine();

            WriteLine("+++++++++ Factors, x0s, dxes, xns +++++++++");
            print("1", factorX1, x01, dx1, xn1);
            print("2", factorX2, x02, dx2, xn2);
            print("3", factorX3, x03, dx3, xn3);


            WriteLine("+++++++++ f`Y, f`Y_et +++++++++");
            table = new ConsoleTable("f`Y", "f`Y_et");
            table.AddRow(String.Join(", ", y), y_et).Configure(o => o.NumberAlignment = Alignment.Right).Write(Format.Alternative);
            WriteLine();

            WriteLine("+++++++++ Result +++++++++");
            WriteLine($"min(Y): {y.Min()}");
            WriteLine($"index: {y.IndexOf(y.Min())+1}");
            table = new ConsoleTable("x1", "x2", "x3");
            table.AddRow(factorX1[index], factorX2[index], factorX3[index])
            .Configure(o => o.NumberAlignment = Alignment.Right).Write(Format.Alternative);
            WriteLine($"f`Y = {a0} + {a1}*{factorX1[index]} + {a2}*{factorX2[index]} + {a3}*{factorX3[index]}");
            WriteLine($"Y = {a0 + a1*factorX1[index] + a2*factorX2[index] + a3*factorX3[index]}");
        }
    }
}
