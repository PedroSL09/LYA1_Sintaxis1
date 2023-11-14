using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LYA1_Sintaxis1
{
    class Program
    {
        static void Main(string[] args) 
        {
            try
            {
                using (Lenguaje L = new Lenguaje())
                {
                    L.Programa();
                    /* 
                    while (!L.FinArchivo())
                    {
                        L.nextToken();
                    }
                    */
                }
            } 
            catch (Exception e)
            {
                Console.WriteLine("Error "+e.Message);
            }
        }
    }
}