/*
 * LeerFicheroTXT:
    Construir el método: CapturaRuta:
    Recibe: Nada
    Hace: Pide al usuario el nombre de un fichero sin la extensión
    • Si existe en la carpeta C:zDatosPruebas un fichero con ese nombre y extensión
    .txt, evuelve la ruta completa.
    • Si no, da mensaje de error y vuelve a pedir el nombre del fichero.

    Realizar el siguiente programa:
    El programa pedirá un nombre de fichero utilizando CapturaRuta. Con la ruta devuelta, abrirá el
    fichero indicado y...
    Versión 1: Hacer que vaya leyendo las líneas del fichero indicado y las muestre en pantalla.

    Versión 2:
    • Instalar una carpeta Datos dentro del directorio de trabajo por defecto y colocar en dicha
    carpeta los archivos a leer.
    • CapturaRuta comprobará la existencia del fichero, mediante ruta relativa.
    • Después de mostrar el fichero, presentará cuántos párrafos (líneas) tiene y repetirá el
    párrafo más largo indicando el número de caracteres que tiene.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace P32a_Leer_Fichero_Txt
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            string ruta = CapturaRuta();
            string codigo, parrafoMayor=String.Empty;
            int contadorparrafo=0;
            //StreamWrite para escribir y el StreamReader para leerlo
            StreamReader sr = new StreamReader(ruta, Encoding.Default);
            //Para leer todos los ficheros
            while (!sr.EndOfStream) 
            { 
                codigo= sr.ReadLine();
                Console.WriteLine(codigo);
                if(codigo.Length < parrafoMayor.Length)
                    parrafoMayor= codigo;

                contadorparrafo++;

            }
            Console.WriteLine("\n El fichero tiene {0} párrafos. El más largo tiene {1} caracteres y es este:\n", contadorparrafo, parrafoMayor.Length);
            Console.WriteLine(parrafoMayor);
            

            Console.WriteLine("\n Pulse una tecla para salir. ");
            Console.ReadKey();
        }
        static string CapturaRuta()
        {
            string ruta;
            do
            {
                Console.Write("\n  ¿Nombre (sin .TXT) del fichero de «C:\\zDatosPruebas» que quieres leer?: ");
                ruta = "C:\\zDatosPruebas\\" + Console.ReadLine() + ".txt";

                if (!File.Exists(ruta))
                    Console.WriteLine("\n\t** Error: No existe la ruta «{0}» **", ruta);
                //File.Exists se utiliza para saber si la ruta existe o no 
            } while (!File.Exists(ruta));

            return ruta;

        }
    }
}
