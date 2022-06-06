using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EscrituraDeBytes
{
    class Program
    {
        static void Main(string[] args)
        {
        }


            public class TextoBytes
        {
            //campos de la clase
            FileStream fs = null; //declaración flujo salida – escritura
            FileStream fe = null; //declaración flujo entrada - lectura
            byte[] bBuffer = new byte[81]; //arreglo tipo byte
            char[] cBuffer = new char[81]; //arreglo tipo char
            int nbytes = 0, car; //variables auxiliares

            //método 1
            public void CrearArchivo(string nombre)
            {
                try
                {
                    // Crea un flujo hacia el archivo texto.txt
                    fs = new FileStream((nombre), FileMode.Create, FileAccess.Write);         //FileStream uso los parametros (nombre) como nombre del archivo, FileMode.Create para crear el documento
                                                                                              //FileAccess.Write para escribir en el documento
                    Console.WriteLine("\nEscriba el texto que desea almacenar en el archivo, al finalizar presione <enter>:");
                    while ((car = Console.Read()) != '\n' && (nbytes < bBuffer.Length))       //mientras que lo que se esta leyendo en el archivo no sea un enter, y mientras nbytes sea menor a el largo del bBufer
                    {
                        bBuffer[nbytes] = (byte)car; //convierte en byte el carácter leído, creando un arreglo con los bytes de bBuffer
                        nbytes++; //incrementa contar de bytes
                    }
                    // Escribe la línea de texto en el archivo.
                    fs.Write(bBuffer, 0, nbytes);
                }
                catch (IOException es)
                {
                    Console.WriteLine("Mensaje del Error: " + es.Message);
                    Console.WriteLine("Ruta del Error: " + es.StackTrace);
                }
                finally
                {
                    if (fs != null) fs.Close(); //cierra el flujo de escritura
                    Console.WriteLine("\npresione <enter> para continuar...");
                    Console.ReadKey();                            // escribir un mensaje deseado para el finally.
                }
            }//fin método creararchivo
        }
    }
    
}
