/*
 * GuardarNMultiplosDesde:
    Construye un método de nombre NMultiplosDesde que...
     Recibe: Tres enteros num, cantidad y numDesde.
     Hace: Construye un vector de tamaño cantidad y guarda en él los primeros
    múltiplos de num que indique cantidad a partir de numDesde sin incluir
    éste.
    Ejemplo: si num=19; cantidad=300 y numdesde=1000, guardará los 300
    primeros múltiplos de 19 a partir del 1000.
     Devuelve: la tabla construida.
    El Main
    1) En el programa se pedirá un número de dos cifras, la cantidad de sus
    múltiplos a representar y el número a partir del cual hallar los múltiplos, y
    se llamará a este método.
    2) Luego se le pedirá el nombre del fichero en el que guardar los valores de la
    tabla. El programa añadirá la extensión .TXT al nombre del fichero y lo
    construirá.
    3) Por último guardará en dicho fichero —de la carpeta de pruebas— todos los
    valores, separados entre sí por el carácter ‘;’ (punto y coma)
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P31b_Guardar_NMultiplos_Desde
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] multiplos;
            int num;
            int cantidad;
            int numDesde;
            num = CapturaEntero("Introduce un numero que quieres representar", 10, 99);
            cantidad = CapturaEntero("Introduce un numero desde donde quieres empezar", 10, 1000);
            numDesde = CapturaEntero("Introduce un numero como maximo", 100, 10000);
            multiplos = NMultiplosDesde(num, cantidad, numDesde);
            Console.WriteLine("Intruce como quieres que se llame el fichero");
            string nombredelfichero = Console.ReadLine();
            StreamWriter fichero= new StreamWriter(String.Format("C:\\zDatosPrueba\\{0}.txt", nombredelfichero));
            foreach (int i in multiplos)
            {
                fichero.WriteLine(multiplos[i]);
            }
            //Con el for seria
            //for (int i = 0; i < multiplos.Length; i++)
            //{
            //    fichero.WriteLine(multiplos[i]);
            //}
        }
        static int[] NMultiplosDesde(int num, int cantidad, int numDesde)
        {
            int[] vnumero=new int[cantidad];

            int multiplo = (numDesde / num) * num;

            if (multiplo < numDesde)
                multiplo += num;

            for (int i = 0; i < vnumero.Length; i++)
            {

                vnumero[i] = multiplo;

                multiplo += num;
            }


            return vnumero;
        }
        static int CapturaEntero(string texto, int min, int max)
        {
            int num;
            bool esCorrecto;
            do
            {
                Console.Write(" {0} [{1}..{2}]: ", texto, min, max);
                esCorrecto = Int32.TryParse(Console.ReadLine(), out num);
                if (!esCorrecto)
                    Console.WriteLine("\n\t ** ERROR de FORMATO **");
                else if (num < min || num > max)
                {
                    Console.WriteLine(" ** ERROR: VALOR FUERA DE RANGO **");
                    esCorrecto = false;
                }
            } while (!esCorrecto);

            return num;
        }


    }
}
