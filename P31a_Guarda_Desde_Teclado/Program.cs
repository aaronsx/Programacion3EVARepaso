/*
 * Guardar Desde Teclado:
    Hacer un programa que vaya leyendo las frases que el usuario
    teclea y las guarde en un fichero de texto. Terminará cuando la
    frase introducida sea "fin" (esa frase no deberá guardarse en el
    fichero).
    Avanzado: Que el programa pida al usuario que escriba el nombre
    del fichero de texto.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace P31a_Guarda_Desde_Teclado
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Base solo escribir y leer texto
            //StreamWriter leerfichero = new StreamWriter("C:\\zDatosPrueba\\Leerficheros.txt");
            //string palabra;
            //do
            //{
            //    Console.WriteLine("Introduce una parabra para añadir al texto");
            //    palabra = Console.ReadLine();
            //    if(palabra != "fin")
            //    leerfichero.Write(palabra);
            //} while (palabra != "fin");
            //leerfichero.Close();
            #endregion
            #region AVANZADO Base+introduce tu el nombre del fichero
            //Console.WriteLine("Introduce el nombre del fichero a crear");
            //string fichero = Console.ReadLine();
            //StreamWriter leerfiche = new StreamWriter("C:\\zDatosPrueba\\{0}.txt",fichero);
            //string palabras;
            //do
            //{
            //    Console.WriteLine("Introduce una parabra para añadir al texto");
            //    palabras = Console.ReadLine();
            //    if (palabras != "fin")
            //        leerfiche.Write(palabras);
            //} while (palabras != "fin");
            
            //leerfiche.Close();
            #endregion
        }
    }
}
