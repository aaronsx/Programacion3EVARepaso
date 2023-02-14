/*
    Guarda Primos
    Construye el método EsPrimo que...
    • Recibe: un entero num.
    • Hace: Averigua si num es primo o no.
    • Devuelve: true si es primo o false si no lo es.
    Construye el método ListaDePrimos que...
    • Recibe: un entero limiteSup.
    • Hace: Construye una lista con todos los números
    primos anteriores a limiteSup.
    • Devuelve: la lista construida.
    El Main:
    • Se le pregunta al usuario cuál es el límite superior
    «top» de los primos a obtener [10..10000].
    • Guardará en una lista todos los números primos
    menores de top
    • Guardará los valores de esa lista, separados por
    el carácter ‘;’ en un fichero de nombre primos.txt.

    ----------------

    Versión mejorada
    Haz otra versión en la que el archivo de primos se
    llame primos Menores de X.txt (donde X es top).
    La primera línea del archivo será una cabecera:
    “Números primos menores de ” + top
    A continuación, aparecerán los primos (sin ‘;’) pero
    en cinco columnas bien alineadas.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace P31c_Guarda_Primos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> ListaPrimos = new List<int>();
            int top;
            top = CapturaEntero("Introduce un numero maximo que este entre", 10, 10000);
            ListaPrimos = ListaDePrimos(top);
            StreamWriter primos = new StreamWriter("C:\\zDatosPrueba\\primos.txt");
            //foreach (int i in ListaPrimos)
            //    primos.WriteLine(ListaPrimos[i]+";");
            for (int i = 0; i < ListaPrimos.Count(); i++)
            {
                primos.WriteLine(ListaPrimos[i] + ";");
            }
        }
        static List<int> ListaDePrimos(int limiteSup)
        {
            List<int> primos = new List<int>();
          
            for (int i = 0;i<limiteSup; i++)
            {
                if (EsPrimo(i))
                {
                    primos.Add(i);
                    
                }    
            }
            return primos;
        }
        static bool EsPrimo(int num)
        {
            for (int i = 2; i < num; i++)
                if ((num % i) == 0)
                    return false;
            //o
            //if (num == 0 || num == 1 || num == 4)
            //    return false;

            //for (int i = 2; i < num; i++)
            //    if (num % i == 0)
            //        return false;
            //return true;

            return true;
        }
        static int CapturaEntero(string txt, int min, int max)
        {
            int valor;
            bool esCorrecto;

            Console.Write("{0} [{1}..{2}]: ", txt, min, max);
            esCorrecto = Int32.TryParse(Console.ReadLine(), out valor);
            while (!esCorrecto || valor < min || valor > max)
            {

                if (!esCorrecto)
                    Console.WriteLine("\n** Error: Valor introducido no es un número entero **");

                else
                    Console.WriteLine("\n** Error: El número no está en el rango pedido **");

                Console.Write("{0} [{1}..{2}]: ", txt, min, max);
                esCorrecto = Int32.TryParse(Console.ReadLine(), out valor);
            }
            return valor;
        }
    }
}
