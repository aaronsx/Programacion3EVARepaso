/* Leer Datos En Fichero.Txt Con Separadores de Campos: 
Realiza un programa que lea el fichero AlumNotas.txt que tienes en la carpeta Datos. 
Se sabe que cada fila contiene los campos: id, nombre, nota1, nota2 y nota3 separados por ‘;’. 
A partir de estas filas obtenidas, rellena una tabla de byte tabIds, otra de string tabAlums 
y otra de float tabNotas de tres columnas. 
A continuación presentar los datos con su cabecera
 Importante: 
 1.	Utilizar Ruta Relativa y mantener la estructura de archivos que se te entrega. 
 2.	El archivo debe estar abierto el menor tiempo posible.
 3.	Se puede utilizar una lista auxiliar pero tienes que actuar como si no se supiera 
    el número de alumnos que guarda el fichero.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace P33b_Leer_Datos_En_TxtSeparadores_Campos
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(".\\Datos\\AlumNotas.txt");
            string alumnos=String.Empty;
            List<string> listaAlumno = new List<string>();
            while (!sr.EndOfStream)
            {
                listaAlumno.Add(sr.ReadLine());
            }
            sr.Close();
            byte[] tabIds = new byte[listaAlumno.Count()];
            string[] tabAlums = new string[listaAlumno.Count()];
            float[,] tabNotas = new float[listaAlumno.Count(),3];
            float[] tabMedias = new float[listaAlumno.Count()];
            string[] vAlumnos;
            for (int i = 0; i < listaAlumno.Count(); i++)
            {
                vAlumnos = listaAlumno[i].Split(';');
                tabIds[i] = Convert.ToByte(vAlumnos[0]);
                tabAlums[i] = vAlumnos[1];
                tabNotas[i,0] = Convert.ToSingle(vAlumnos[2]);
                tabNotas[i, 1] = Convert.ToSingle(vAlumnos[3]);
                tabNotas[i, 2] = Convert.ToSingle(vAlumnos[4]);
                tabMedias[i] = (tabNotas[i, 0]+ tabNotas[i, 1]+ tabNotas[i, 2]) / 3;
            }
           


            //-------------- Mostramos los datos  -----------------

            Console.WriteLine("     Id  Alumno\t\t\t\tProg    Ed      BD      Media");
            Console.WriteLine("     -----------------------------------------------------------------");
            for (int i = 0; i < listaAlumno.Count(); i++) 
            {
                Console.SetCursorPosition(5,i+3);
                Console.WriteLine(tabIds[i]+" " +tabAlums[i]);
                Console.SetCursorPosition(40,i+3);
                Console.WriteLine(tabNotas[i, 0]);
                Console.SetCursorPosition(48, i + 3);
                Console.WriteLine(tabNotas[i, 1]);
                Console.SetCursorPosition(56, i + 3);
                Console.WriteLine(tabNotas[i, 2]);
                Console.SetCursorPosition(64, i + 3);
                Console.WriteLine(tabMedias[i]);

            }
            Console.ReadKey();
        }
    }
}
