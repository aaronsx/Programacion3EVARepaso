using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace P38_Leer_Pacientes_Y_Mostrar_Ordenados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(".\\Datos\\Pacientes.txt");
            List<string> listapacientes = new List<string>();

            while (!sr.EndOfStream)
            {
                listapacientes.Add(sr.ReadLine());
            }
            sr.Close();
            //La variable registro es para guardar cada linea de fichero
            //y la variable vectorCampos es donde guardaremos todos los campos
            //de cada fila (split(';'))
            string registro;
            string[] vectorCampos;
            int opcion = Menu();

            while (opcion != 0)
            {
                List<string> listaOrdenada = new List<string>(listapacientes);
                for (int i = 0; i < listaOrdenada.Count(); i++)
                {
                    registro = listaOrdenada[i];
                    vectorCampos = registro.Split(';');

                    switch (opcion)
                    {

                        case 1:
                            registro = CuadraTexto(3, vectorCampos[0]) + ';' + registro;
                            break;
                        case 2:
                            registro = vectorCampos[1] + ';' + registro;
                            break;
                        case 3:
                            registro = vectorCampos[3] + ';' + registro;
                            break;
                        case 4:
                            registro = vectorCampos[4] + ';' + registro;
                            break;
                        case 5:
                            registro = vectorCampos[5] + ';' + registro;
                            break;
                        case 6:
                            registro = " " + ';' + registro;
                            break;

                    }
                    listaOrdenada[i] = registro;
                }
                listaOrdenada.Sort();
                if (opcion == 3)
                    listaOrdenada.Reverse();
                Console.WriteLine("\n  Id  Paciente                     Movil      Fecha Nac.  Alt.  Peso");
                Console.WriteLine("  --- ---------------------------- ---------  ----------  ---- -----");
                foreach (string reg in listaOrdenada)
                {
                    vectorCampos = reg.Split(';');
                    Console.Write(" " + CuadraTexto(3, vectorCampos[1]));
                    Console.Write(" {0} {1}", CapturaTexto(vectorCampos[2],28), CapturaTexto(vectorCampos[3], 9));
                    Console.Write("   {0}/{1}/{2}", vectorCampos[4].Substring(0, 4), vectorCampos[4].Substring(4, 2), vectorCampos[4].Substring(6));
                    Console.Write("  " + vectorCampos[5]);
                    double peso = Convert.ToDouble(vectorCampos[6]);
                    Console.Write("   " + Cuatradouble(peso,5));
                    Console.WriteLine();
                }
                Console.ReadKey();
                opcion = Menu();

            }


            Console.WriteLine("\n\n\t Pulsa una tecla para salir");
            Console.ReadKey();
        }
        static int Menu()
        {
            int opcion = 0;
            Console.Clear();
            Console.WriteLine("\n\n\t\t╔═════════════════════════╗");
            Console.WriteLine("\t\t║   Ordenar datos por...  ║");
            Console.WriteLine("\t\t╠═════════════════════════╣");
            Console.WriteLine("\t\t║   1) id                 ║");
            Console.WriteLine("\t\t║                         ║");
            Console.WriteLine("\t\t║   2) Apellidos, Nombre  ║");
            Console.WriteLine("\t\t║                         ║");
            Console.WriteLine("\t\t║   3) Edad (creciente)   ║");
            Console.WriteLine("\t\t║                         ║");
            Console.WriteLine("\t\t║   4) Altura             ║");
            Console.WriteLine("\t\t║                         ║");
            Console.WriteLine("\t\t║   5) Peso               ║");
            Console.WriteLine("\t\t║                         ║");
            Console.WriteLine("\t\t║   6) Sin ordenar        ║");
            Console.WriteLine("\t\t║_________________________║");
            Console.WriteLine("\t\t║                         ║");
            Console.WriteLine("\t\t║      0)  Salir          ║");
            Console.WriteLine("\t\t╚═════════════════════════╝");

            //Console.WriteLine("\t\t║   6) Nombre Apellidos   ║");
            //Console.WriteLine("\t\t║                         ║");
            //Console.WriteLine("\t\t║   7) Sin ordenar        ║");
            opcion = CapturaEntero("Introduce una opcion: ", 0, 6);

            return opcion;
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
        static string CapturaTexto(string txt, int num)
        {
            txt += "                ";
            return txt.Substring(0, num);
        }
        static string CuadraTexto(int numCaracteres, string texto)
        {
            texto = "                                  " + texto;
            return texto.Substring(texto.Length - numCaracteres);
        }
        static string Cuatradouble(double numero, int numero1)
        {
            string texto = "                    " + numero.ToString("0.0");
            return texto.Substring(texto.Length - numero1);
        }
    }
}
