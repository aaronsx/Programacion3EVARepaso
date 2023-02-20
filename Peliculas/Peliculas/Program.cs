using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Peliculas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(".\\Datos\\Pelis.txt", UnicodeEncoding.Default);
            List<string> listapelis = new List<string>();
            string strTamanyo, pelis, tipo, formato, fichero;
            double tam;
            int num = 1;
            while (!sr.EndOfStream)
            {
                listapelis.Add(sr.ReadLine().Substring(22));
            }
            string[] nombrepelis;
            Console.WriteLine("\n  Nº\tPelícula                             Valor  Form.   Tamaño    ");
            Console.WriteLine("  ---\t------------------------------------- ----  -----   ------    ");
            foreach (string s in listapelis) 
            {
                strTamanyo = s.Substring(0,13).Trim();
                tam = Math.Round(Convert.ToDouble(strTamanyo) / 1000000000, 2);
                fichero= s.Substring(13).Trim();
                nombrepelis=fichero.Split('(', ')');
                pelis = CuadraTexto(nombrepelis[0], 37);
                tipo = nombrepelis[1];
                formato = nombrepelis[2].ToUpper().Remove(0,1);
                Console.WriteLine("  {0}\t{1}  {2}     {3}     {4}", num++, pelis, tipo, formato, tam);
            }
            Console.WriteLine("\n¿Nombre del fichero donde  guardar los datos? (Intro = salir sin guardar)");
            ConsoleKeyInfo tecla = Console.ReadKey(true);

            if (tecla.Key != ConsoleKey.Enter)
            {
                string nombreArchivo = Console.ReadLine() + ".TXT";

                
                StreamWriter sw = File.CreateText(@".\Datos\" + nombreArchivo);

                
                num = 1;

                foreach (string s in listapelis)
                {
                    
                    strTamanyo = s.Substring(0, 13).Trim(); 

                    tam = Math.Round(Convert.ToDouble(strTamanyo) / 1000000000, 2);

                    fichero = s.Substring(13).Trim();
                    nombrepelis = fichero.Split('(', ')');
                    pelis = CuadraTexto(nombrepelis[0], 37);
                    tipo = nombrepelis[1];
                    formato = nombrepelis[2].ToUpper().Remove(0, 1);


                    sw.WriteLine("{0};{1};{2};{3}", pelis, tipo, formato, tam);

                }
            }

        }
        static string CuadraTexto(string text, int num)
        {
            text += ".............................................................";
            return text.Substring(0,num);
        }
    }
}
