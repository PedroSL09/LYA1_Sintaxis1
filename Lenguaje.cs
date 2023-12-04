using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LYA1_Sintaxis1
{
    public class Lenguaje : Sintaxis
    {
        public Lenguaje()
        {
        }
        public Lenguaje(string nombre) : base(nombre)
        {
        }
        //Programa  -> Librerias? Variables? Main
        public void Programa()
        {
            if (getContenido() == "#")
            {
                Librerias();
            }
            if (getClasificacion() == Tipos.tipoDatos)
            {
                Variables();
            }
            Main();
        }
        //Librerias -> #include<identificador(.h)?> Librerias?
        private void Librerias()
        {
            match("#");
            match("include");
            match("<");
            match(Tipos.Identificador);
            if (getContenido() == ".")
            {
                match(".");
                match("h");
            }
            match(">");
            if (getContenido() == "#")
            {
                Librerias();
            }
        }
        //Variables -> tipoDato listaIdentificadores; Variables?
        private void Variables()
        {
            match(Tipos.tipoDatos);
            listaIdentificadores();
            match(";");
            if (getClasificacion() == Tipos.tipoDatos)
            {
                Variables();
            }
        }
        //listaIdentificadores -> Identificador (,listaIdentificadores)?
        private void listaIdentificadores()
        {
            match(Tipos.Identificador);
            if (getContenido() == ",")
            {
                match(",");
                listaIdentificadores();
            }
        }
        //bloqueInstrucciones -> { listaIntrucciones? }
        private void bloqueInstrucciones()
        {
            match("{");
            if (getContenido() != "}")
            {
                ListaInstrucciones();
            }
            match("}");
        }
        //ListaInstrucciones -> Instruccion ListaInstrucciones?
        private void ListaInstrucciones()
        {
            Instruccion();
            if (getContenido() != "}")
            {
                ListaInstrucciones();
            }
        }
        //Instruccion -> Printf | Scanf | If | While | do while | For | Asignacion
        private void Instruccion()
        {
            if (getContenido() == "printf")
            {
                Printf();
            }
            else if (getContenido() == "scanf")
            {
                Scanf();
            }
            else if (getContenido() == "if")
            {
                If();
            }
            else if (getContenido() == "while")
            {
                While();
            }
            else if (getContenido() == "do")
            {
                Do();
            }
            else if (getContenido() == "for")
            {
                For();
            }
            else
            {
                Asignacion();
            }
        }
        //Requerimiento 1: Printf -> printf(cadena(, Identificador)?);
        private void Printf()
        {
            match("printf");
            match("(");
            match(Tipos.Cadena);
            if (getContenido() == ",")
            {
                match(",");
                match(Tipos.Identificador);
            }
            match(")");
            match(";");
        }

        //Requerimiento 2: Scanf -> scanf(cadena,&Identificador);
        private void Scanf()
        {
            match("scanf");
            match("(");
            match(Tipos.Cadena);
            if (getContenido() == ",")
            {
                match(",");
                match("&");
                match(Tipos.Identificador);
            }
            match(")");
            match(";");
        }

        //Asignacion -> Identificador = (Expresion | Numero);
        private void Asignacion()
        {
            match(Tipos.Identificador);

            if (getContenido() == "=")
            {
                match("=");
                if (getClasificacion() == Tipos.Numero)
                {
                    match(Tipos.Numero);
                }
                else
                {
                    Expresion();
                }
            }
            else if (getContenido() == "+=" || getContenido() == "-=" || getContenido() == "*=" || getContenido() == "/=" || getContenido() == "%=")
            {
                match(getContenido());
                if (getClasificacion() == Tipos.Numero)
                {
                    match(Tipos.Numero);
                }
                else
                {
                    Expresion();
                }
            }

            match(";");
        }

        //If -> if (Condicion) instruccion | bloqueInstrucciones 
        //      (else instruccion | bloqueInstrucciones)?
        private void If()
        {
            match("if");
            match("(");
            Condicion();
            match(")");
            if (getContenido() == "{")
            {
                bloqueInstrucciones();
            }
            else
            {
                Instruccion();
            }

            //Requerimiento 4: Agregar el else optativo al if

            if (getContenido() == "else")
            {
                match("else");
                if (getContenido() == "{")
                {
                    bloqueInstrucciones();
                }
                else
                {
                    Instruccion();
                }
            }

        }
        //Condicion -> Expresion operadoRelacional Expresion
        private void Condicion()
        {
            Expresion();
            match(Tipos.OperadorRelacional);
            Expresion();
        }
        //While -> while(Condicion) bloque de instrucciones | instruccion
        private void While()
        {
            match("while");
            match("(");
            Condicion();
            match(")");
            if (getContenido() == "{")
            {
                bloqueInstrucciones();
            }
            else
            {
                Instruccion();
            }

        }
        //Do -> do bloque de instrucciones | intruccion while(Condicion)
        private void Do()
        {
            match("do");
            if (getContenido() == "{")
            {
                bloqueInstrucciones();
            }
            else
            {
                Instruccion();
            }
            match("while");
            match("(");
            Condicion();
            match(")");
            match(";");

        }
        //For -> for(Asignacion;Condicion; Incremento) Bloque de instruccones | Intruccion 
        private void For()
        {
            match("for");
            match("(");
            Asignacion();
            match(";");
            Condicion();
            match(";");
            Incremento();
            if (getContenido() == "{")
            {
                bloqueInstrucciones();
            }
            else
            {
                Instruccion();
            }

        }
        // Incremento -> Identificador (++ | --);
        private void Incremento()
        {

            match(Tipos.Identificador);

            if (getContenido() == "++" || getContenido() == "--")
            {
                match(getContenido());
            }

            match(";");

        }


        //Main      -> void main() bloqueInstrucciones
        private void Main()
        {
            match("void");
            match("main");
            match("(");
            match(")");
            bloqueInstrucciones();
        }
        //Expresion -> Termino MasTermino
        private void Expresion()
        {
            Termino();
            MasTermino();
        }
        //MasTermino -> (OperadorTermino Termino)?
        private void MasTermino()
        {
            if (getClasificacion() == Tipos.OperadorTermino)
            {
                match(Tipos.OperadorTermino);
                Termino();
            }
        }
        //Termino -> Factor PorFactor
        private void Termino()
        {
            Factor();
            PorFactor();
        }
        //PorFactor -> (OperadorFactor Factor)?
        private void PorFactor()
        {
            if (getClasificacion() == Tipos.OperadorFactor)
            {
                match(Tipos.OperadorFactor);
                Factor();
            }
        }
        //Factor -> numero | identificador | (Expresion)
        private void Factor()
        {
            if (getClasificacion() == Tipos.Numero)
            {
                match(Tipos.Numero);
            }
            else if (getClasificacion() == Tipos.Identificador)
            {
                match(Tipos.Identificador);
            }
            else
            {
                match("(");
                Expresion();
                match(")");
            }
        }
    }
}