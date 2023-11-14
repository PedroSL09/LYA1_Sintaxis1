using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LYA1_Sintaxis1
{
    public class Sintaxis : Lexico
    {
        public Sintaxis()
        {
            nextToken();
        }
        public Sintaxis(string nombre) : base(nombre)
        {
            nextToken();
        }
        public void match(string espera)
        {
            if (getContenido() == espera)
            {
                nextToken();
            }
            else
            {
                throw new Error("Sintaxis: Se espera un "+espera,log);
            }
        }
        public void match(Tipos espera)
        {
            if (getClasificacion() == espera)
            {
                nextToken();
            }
            else
            {
                throw new Error("Sintaxis: Se espera un "+espera,log);
            }
        }
    }
}