using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casos_Sem07
{
    internal class Program
    {
        static int max = 100;
        static string[] nombres = new string[max];
        static double[] notas = new double[max];
        static int contador = 0;

        static public void Titulo()
        {
            Console.WriteLine("************************************");
            Console.WriteLine("Sistema de notas");
            Console.WriteLine("************************************");
        }

        static public void Registrar_estudiante()
        {
            Console.WriteLine("Registro de estudiante nuevo: ");
            if (contador >= max)
            {
                Console.WriteLine("Llegamos a la capacidad máxima");
                return;
            }
            Console.Write("Ingresar nombres: ");
            string nombre = Console.ReadLine();
            double nota;
            while (true)
            {
                Console.Write("Ingresar nota: ");
                nota = double.Parse(Console.ReadLine());
                if (nota >= 0 && nota <= 20)
                {
                    break;
                }
                Console.WriteLine("ERROR: La nota debe ser [0-20]");
            }
            nombres[contador] = nombre;
            notas[contador] = nota;
            contador++;
        }

        static public void mostrar()
        {
            Console.WriteLine("*******Listado de estudiantes*******");
            if (contador == 0)
            {
                Console.WriteLine("No hay datos por mostrar");
                return;
            }
            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine((i + 1) + ".-" + nombres[i] + "-Nota:" + notas[i]);
            }
        }

        static public void buscar_estudiante()
        {
            Console.Write("***********BUSCAR ESTUDIANTE************\n");
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados");
                return;
            }

            Console.Write("Ingresar nombre a buscar: ");
            string nom_buscar = Console.ReadLine().ToLower();
            bool encontrado = false;
            for (int i = 0; i < contador; i++)
            {
                if (nombres[i].ToLower() == nom_buscar)
                {
                    Console.WriteLine(nombres[i] + " tiene " + notas[i]);
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("Estudiante no encontrado");
            }
        }

        static public void modificar_estudiante()
        {
            Console.WriteLine("****************MODIFICAR ESTUDIANTE****************");
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados");
                return;
            }
            Console.Write("Ingresar nombre de estudiante: ");
            string nombre_buscar = Console.ReadLine().ToLower();
            for (int i = 0; i < contador; i++)
            {
                if (nombres[i].ToLower() == nombre_buscar)
                {
                    Console.WriteLine(nombres[i] + " tiene " + notas[i]);
                    double nueva_nota;
                    while (true)
                    {
                        Console.Write("Ingresar la nueva nota: ");
                        nueva_nota = double.Parse(Console.ReadLine());
                        if (nueva_nota >= 0 && nueva_nota <= 20)
                        {
                            notas[i] = nueva_nota;
                            Console.WriteLine("Nota modificada...");
                            return;
                        }
                        Console.Write("Error, nota no válida [0-20]\n");
                    }
                }
            }
            Console.WriteLine("Estudiante no encontrado");
        }

        static public void burbuja()
        {
            double temp_notas;
            string temp_nombres;
            for (int i = 0; i < contador - 1; i++)
            {
                for (int j = 0; j < contador - i - 1; j++)
                {
                    if (notas[j] > notas[j + 1])
                    {
                        temp_notas = notas[j];
                        notas[j] = notas[j + 1];
                        notas[j + 1] = temp_notas;

                        temp_nombres = nombres[j];
                        nombres[j] = nombres[j + 1];
                        nombres[j + 1] = temp_nombres;
                    }
                }
            }
        }
        static public void seleccion_descendente()
        {
            double temp_notas;
            string temp_nombres;
            for (int i = 0; i < contador - 1; i++)
            {
                int max = i;
                for (int j = i + 1; j < contador; j++)
                {
                    if (notas[j] > notas[max])
                    {
                        max = j;
                    }
                }

                temp_notas = notas[i];
                notas[i] = notas[max];
                notas[max] = temp_notas;

                temp_nombres = nombres[i];
                nombres[i] = nombres[max];
                nombres[max] = temp_nombres;
            }
        }
        static public void estadisticas()
        {
            Console.WriteLine("***********ESTADÍSTICAS************");
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados");
                return;
            }

            double suma = 0;
            double maxima = notas[0];

            for (int i = 0; i < contador; i++)
            {
                suma = suma + notas[i];

                if (notas[i] > maxima)
                {
                    maxima = notas[i];
                }
            }

            double promedio = suma / contador;
            Console.WriteLine("El promedio de notas es: " + promedio);
            Console.WriteLine("La nota máxima del salón es: " + maxima);
        }

        static void Main(string[] args)
        {
            Titulo();
            int opc = 0;
            while (opc != 8)
            {
                Console.Clear();
                Console.WriteLine("*****MENÚ PRINCIPAL*****");
                Console.WriteLine("[1] Registrar estudiante");
                Console.WriteLine("[2] Buscar estudiantes");
                Console.WriteLine("[3] Modificar nota");
                Console.WriteLine("[4] Mostrar lista sin ordenar");
                Console.WriteLine("[5] Mostrar reporte ordenado por burbuja ASC");
                Console.WriteLine("[6] Mostrar por selección DESC");
                Console.WriteLine("[7] Promedio y nota máxima del salon");
                Console.WriteLine("[8] Salir");
                Console.Write("Ingresar opción: ");

                if (!int.TryParse(Console.ReadLine(), out opc))
                {
                    Console.WriteLine("ERROR: ingresar un valor númerico");
                    Console.ReadKey();
                    continue;
                }

                switch (opc)
                {
                    case 1:
                        Registrar_estudiante();
                        break;
                    case 2:
                        buscar_estudiante();
                        break;
                    case 3:
                        modificar_estudiante();
                        break;
                    case 4:
                        mostrar();
                        break;
                    case 5:
                        burbuja();
                        mostrar();
                        break;
                    case 6:
                        seleccion_descendente();
                        mostrar();
                        break;
                    case 7:
                        estadisticas();
                        break;
                    case 8:
                        Console.WriteLine("Gracias por usar el sistema");
                        break;
                    default:
                        Console.WriteLine("Opción incorrecta!!!!!...");
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}