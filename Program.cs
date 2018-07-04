using MinimumEditDistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessThePattern
{
    class Program
    {
        private static string hidden = "germany lost"; //Only for lowercase chars and numbers, you can customize accordingly.

        public static int Try(string text, int found)
        {
            Random rand = new Random();
            int fix = rand.Next(-1, 0);

            switch (found)
            {
                case 1: break;
                case 2: Console.Write("Fixed: " + (fix + Levenshtein.CalculateDistance(hidden, text, 1)) + " ");
                        Console.Write("Original: " + Levenshtein.CalculateDistance(hidden, text, 1) + "\n");
                        break;
            }
            return (fix + Levenshtein.CalculateDistance(hidden, text, 1));
        }

        public static string Guess()
        {
            string temp = "";
            int temp_dif = Try(temp, 1); //1
            Console.Write("Temp dif: " + temp_dif + "\n");

            char[] alpha = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p','q', 'r', 's', 't', 'u', 'v','w', 'x', 'y', 'z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ' '};
            char[] new_array = new char[temp_dif]; //New guess / new array

            int dif = temp_dif; //First step / previous difference
            int static_dif = dif;
            int new_dif = 0; //New difference
            int k = 0; //index of the new array
            int found = 0; 

            for(int d = 0; d < static_dif; d++) //Run as difference count
            {
                for(int a = 0; a < alpha.Length && found < 1; a++)// Check one by one basd on alphabet array
                {
                    new_array[k] = alpha[a];
                    temp = new string(new_array);
                    new_dif = Try(temp, 2);//2
                    if (dif - new_dif == 1) //If the current char is found
                    {
                        found = 1;
                        k++;
                        dif = new_dif; //Then save and continue searching
                    }                 
                }
                found = 0;
            }
            return temp;
        }

        static void Main(string[] args)
        {
            string final = Guess();
            Console.Write("Guess: " + final);
            Console.Read();
        }
    }
}
