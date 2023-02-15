/*
     Construye dos tablas tApell y tNomb con los datos que tienes más abajo. A continuación
    realizamos el siguiente proceso:
    1) Construimos una tabla de byte tIds con las mismas filas que las tablas anteriores. Se
    cargará con números al azar de dos cifras sin que exista ninguno repetido. Cada número se
    considera el id del alumno de la misma fila.
    2) Construimos una tabla de float tNotas con las mismas filas que la anterior, pero de dos
    dimensiones (tres columnas), para guardar las notas de los alumnos, es decir, en la fila n
    se guardarán las tres notas del alumno de posición n. Esta tabla se cargará con notas
    obtenidas al azar, entre 0.0 y 9.9, (con un decimal).
    3) Guardamos los datos en un fichero formando registros con la siguiente estructura:
    id;Apellidos;Nombre;n0;n1;n2
    El fichero se llamará fNotasCS.TXT. Se guardará en una carpeta de nombre Datos, en el
    directorio de trabajo por defecto.
    Los campos irán separados por el carácter ‘;’ y los registros por salto de línea.


    Apellidos: "Sánchez Elegante", "Arenas Mata", "García Solís", "Rodríguez Vázquez", "Hurtado Miranda", "Pinto
    Mirinda", "Barrios Garrobo", "Márquez Salazar", "Medina Gómez", "Alonso Pérez", "López Mora", "González
    Chaparro", "Ferrer Jiménez", "Morales Moncayo", "Fernández Perea", "Blanco Roldán", "Navarro Romero",
    "Aguilar Rubio", "Baena Fernández", "Barco Ramírez", "Delegado Rodríguez", "Duque Martínez"
    Nombres: "Álvaro", "Daniel Luis", "Juan Manuel", "Agustín", "Fco. Javier", "José Manuel", "María", "Carlos",
    "Jose Carlos", "Juan Luis", "Daniel", "Carmen", "Jacobo", "Alejandro", "Francisco", "Alicia", "Francisco", "Ángela",
    "Constantino", "Mariló", "Rafaela", "Antonio"
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace P33a_Escribir_Datos_En_TxtConSeparadores
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] tApell =
            {
                "Sánchez Elegante", "Arenas Mata", "García Solís", "Rodríguez Vázquez", "Hurtado Miranda", "Pinto Mirinda", 
                "Barrios Garrobo", "Márquez Salazar", "Medina Gómez", "Alonso Pérez", "López Mora", "González Chaparro", 
                "Ferrer Jiménez", "Morales Moncayo", "Fernández Perea", "Blanco Roldán", "Navarro Romero",
                "Aguilar Rubio", "Baena Fernández", "Barco Ramírez", "Delegado Rodríguez", "Duque Martínez"
            };
            string[] tNomb =
            {
                 "Álvaro", "Daniel Luis", "Juan Manuel", "Agustín", "Fco. Javier", "José Manuel", "María", "Carlos",
                 "Jose Carlos", "Juan Luis", "Daniel", "Carmen", "Jacobo", "Alejandro", "Francisco", "Alicia", "Francisco", "Ángela",
                 "Constantino", "Mariló", "Rafaela", "Antonio"
            };
            byte [] tIds= CargaIds2Cifras(tApell.Length);
            float[,] tNotas = Carga3Notas(tApell.Length);


            
            StreamWriter ficheros = new StreamWriter("C:\\zDatosPruebas\\fNotasCS.txt");
            for (int i=0;i < tApell.Length;i++)
            {
                ficheros.WriteLine(tIds[i] +";" + tApell[i] + ";" + tNomb[i] + ";" + tNotas[i, 0] + ";" + tNotas[i,1] + ";" + tNotas[i, 2]);
            }
            ficheros.Close();
        }
        static byte[] CargaIds2Cifras(int cantidad)
        {
            byte[] tabIds2Cifras = new byte[cantidad];
            Random azar = new Random();

            List<byte> lista = new List<byte>();
            for (byte b = 10; b < 100; b++) // cargamos la lista con los valores posibles
                lista.Add(b);
            int pos;
            for (int i = 0; i < cantidad; i++)
            {
                pos = azar.Next(lista.Count); // Obtengo una posición al azar de la lista
                tabIds2Cifras[i] = lista[pos];     // Guardo el valor de esa posición en la tabla
                lista.RemoveAt(pos);          // elimino ese elemento de la lista para que no se pueda repetir
            }

            #region Otra forma: comprobando la existencia de cada número que obtengo
            //bool[] tbRepes = new bool[100];  // para marcar los números que ya hemos cogido
            //int num;
            //for (int i = 0; i < cantidad; i++)
            //{
            //	num = azar.Next(10, 100);       // elegimos un número y...
            //	while (tbRepes[num] == true)    // mientras ya se haya tomado antes...
            //		num = azar.Next(10, 100);   // seguimos eligiendo un número
            //									// si llegamos aquí es que num no se había elegido antes
            //	tabIds2Cifras[i] = (byte)num;     // lo guardamos
            //	tbRepes[num] = true;            // lo marcamos como ya elegido
            //}
            #endregion

            return tabIds2Cifras;
        }
        static float[,] Carga3Notas(int tamanyo)
        {
            float[,] tNotas = new float[tamanyo, 3];
            Random azar = new Random();

            for (int i = 0; i < tamanyo; i++)
            {
                tNotas[i, 0] = azar.Next(100) / 10F;
                tNotas[i, 1] = azar.Next(100) / 10F;
                tNotas[i, 2] = azar.Next(100) / 10F;
            }
            return tNotas;
        }
    }
}
