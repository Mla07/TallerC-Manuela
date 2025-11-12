using System;
using TallerPOO.Modelos;

namespace TallerPOO
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== TALLER DE PROGRAMACIÓN ORIENTADA A OBJETOS ===");
                Console.WriteLine("Seleccione un ejercicio (1–15) o 0 para salir:");
                if (!int.TryParse(Console.ReadLine(), out int op) || op < 0 || op > 15)
                {
                    Console.WriteLine("Opción inválida"); Console.ReadKey(); continue;
                }
                if (op == 0) break;
                Console.Clear(); Console.WriteLine($"=== EJERCICIO {op} ===\n");
                try
                {
                    switch (op)
                    {
                        case 1: Ejercicios.Ejercicio1(); break;
                        case 2: Ejercicios.Ejercicio2(); break;
                        case 3: Ejercicios.Ejercicio3(); break;
                        case 4: Ejercicios.Ejercicio4(); break;
                        case 5: Ejercicios.Ejercicio5(); break;
                        case 6: Ejercicios.Ejercicio6(); break;
                        case 7: Ejercicios.Ejercicio7(); break;
                        case 8: Ejercicios.Ejercicio8(); break;
                        case 9: Ejercicios.Ejercicio9(); break;
                        case 10: Ejercicios.Ejercicio10(); break;
                        case 11: Ejercicios.Ejercicio11(); break;
                        case 12: Ejercicios.Ejercicio12(); break;
                        case 13: Ejercicios.Ejercicio13(); break;
                        case 14: Ejercicios.Ejercicio14(); break;
                        case 15: Ejercicios.Ejercicio15(); break;

                        default: Console.WriteLine("Ejercicio aún no implementado."); break;
                    }
                }
                catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
                Console.WriteLine("\nPresione una tecla para continuar..."); Console.ReadKey();
            }
        }
    }
}
