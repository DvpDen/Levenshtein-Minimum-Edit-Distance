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
        private static string hidden = "germany won at the 2014 world cup in brazil"; //Only for lowercase chars and numbers, you can customize accordingly.

        public static int Try(string text)
        {
            return Levenshtein.CalculateDistance(hidden, text, 1);
        }

        public static string Guess()
        {
            char[] alpha = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p','q', 'r', 's', 't', 'u', 'v','w', 'x', 'y', 'z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ' '};
            char[] new_array = new char[100]; //New guess / new array

            string text = new string(new_array);//char array to string

            string new_text = "";
            string final_text = "";

            int dif = Try(text); //First step / previous difference
            int new_dif = 0; //New difference
            int k = 0; //index of the new array

            for(int d = 0; d < dif; d++) //Run as difference count
            {
                for(int a = 0; a < alpha.Length; a++)// Check one by one basd on alphabet array
                {
                    new_array[k] = alpha[a];
                    new_text = new string(new_array);
                    new_dif = Try(new_text);
                    if(dif - new_dif == 1) //If the current char is found
                    {
                        k++;
                        dif = new_dif; //Then save and continue searching
                    }
                }
            }
            final_text = new string(new_array);//Finalizing the new array, the guess, into string form 
            return final_text;
        }

        static void Main(string[] args)
        {
            string final = Guess();
            Console.Write("Guess: " + final);
            Console.Read();
        }
    }
}
