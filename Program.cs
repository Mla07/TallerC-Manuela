using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        MostrarMenu();
    }

    static void MostrarMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== TALLER: ARREGLOS, ARRAYLIST, LIST<T> Y FUNCIONES ===");
            Console.WriteLine("Seleccione un ejercicio (1-20) o 0 para salir:");
            
            for (int i = 1; i <= 20; i++)
            {
                Console.WriteLine($"{i}. Ejercicio {i}");
            }
            Console.WriteLine("0. Salir");
            Console.Write("\nOpción: ");

            if (int.TryParse(Console.ReadLine(), out int opcion))
            {
                if (opcion == 0) break;
                
                if (opcion >= 1 && opcion <= 20)
                {
                    EjecutarEjercicio(opcion);
                }
                else
                {
                    Console.WriteLine("Opción inválida. Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida. Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

    static void EjecutarEjercicio(int numero)
    {
        Console.Clear();
        Console.WriteLine($"=== EJERCICIO {numero} ===");
        
        switch (numero)
        {
            case 1: Ejercicio1(); break;
            case 2: Ejercicio2(); break;
            case 3: Ejercicio3(); break;
            case 4: Ejercicio4(); break;
            case 5: Ejercicio5(); break;
            case 6: Ejercicio6(); break;
            case 7: Ejercicio7(); break;
            case 8: Ejercicio8(); break;
            case 9: Ejercicio9(); break;
            case 10: Ejercicio10(); break;
            case 11: Ejercicio11(); break;
            case 12: Ejercicio12(); break;
            case 13: Ejercicio13(); break;
            case 14: Ejercicio14(); break;
            case 15: Ejercicio15(); break;
            case 16: Ejercicio16(); break;
            case 17: Ejercicio17(); break;
            case 18: Ejercicio18(); break;
            case 19: Ejercicio19(); break;
            case 20: Ejercicio20(); break;
        }
        
        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    //MÉTODOS UTILITARIOS COMPARTIDOS

    static int[] LeerArregloEnteros()
    {
        while (true)
        {
            try
            {
                Console.Write("Ingrese números enteros separados por espacios: ");
                string entrada = (Console.ReadLine() ?? string.Empty).Trim();
                
                if (string.IsNullOrEmpty(entrada))
                {
                    Console.WriteLine("Error: La línea no puede estar vacía.");
                    continue;
                }

                string[] partes = entrada.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int[] arreglo = new int[partes.Length];
                
                for (int i = 0; i < partes.Length; i++)
                {
                    if (!int.TryParse(partes[i], out arreglo[i]))
                    {
                        throw new FormatException($"Elemento '{partes[i]}' no es un entero válido");
                    }
                }
                
                return arreglo;
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: {ex.Message}. Intente nuevamente.");
            }
        }
    }

    static double[] LeerArregloDoubles()
    {
        while (true)
        {
            try
            {
                Console.Write("Ingrese números separados por espacios: ");
                string entrada = (Console.ReadLine() ?? string.Empty).Trim();
                
                if (string.IsNullOrEmpty(entrada))
                {
                    Console.WriteLine("Error: La línea no puede estar vacía.");
                    continue;
                }

                string[] partes = entrada.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                double[] arreglo = new double[partes.Length];
                
                for (int i = 0; i < partes.Length; i++)
                {
                    if (!double.TryParse(partes[i], out arreglo[i]))
                    {
                        throw new FormatException($"Elemento '{partes[i]}' no es un número válido");
                    }
                }
                
                return arreglo;
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: {ex.Message}. Intente nuevamente.");
            }
        }
    }

    static void ImprimirArreglo<T>(T[] arreglo)
    {
        Console.WriteLine($"[{string.Join(", ", arreglo)}]");
    }

    static void ImprimirLista<T>(List<T> lista)
    {
        Console.WriteLine($"[{string.Join(", ", lista)}]");
    }

    static double CalcularPromedio(double[] valores)
    {
        if (valores.Length == 0) return 0;
        return valores.Average();
    }

    static double CalcularDesviacionEstandar(double[] valores)
    {
        if (valores.Length == 0) return 0;
        double promedio = valores.Average();
        double sumaCuadrados = 0;
        foreach (double valor in valores)
        {
            sumaCuadrados += Math.Pow(valor - promedio, 2);
        }
        return Math.Sqrt(sumaCuadrados / valores.Length);
    }

    //IMPLEMENTACIÓN DE TODOS LOS EJERCICIOS 

    static void Ejercicio1()
    {
        Console.WriteLine("1) Casteo seguro a int[]");
        Console.WriteLine("Descripción: Convierte línea de texto con números en arreglo int[]\n");
        
        int[] resultado = LeerArregloEnteros();
        Console.Write("Arreglo int[]: ");
        ImprimirArreglo(resultado);
    }

    static void Ejercicio2()
    {
        Console.WriteLine("2) Mínimo, máximo y posiciones");
        Console.WriteLine("Descripción: Encuentra min, max y sus primeras posiciones\n");
        
        int[] arreglo = LeerArregloEnteros();
        
        if (arreglo.Length == 0)
        {
            Console.WriteLine("Error: El arreglo no puede estar vacío.");
            return;
        }

        int min = arreglo[0], max = arreglo[0];
        int posMin = 0, posMax = 0;

        for (int i = 1; i < arreglo.Length; i++)
        {
            if (arreglo[i] < min)
            {
                min = arreglo[i];
                posMin = i;
            }
            if (arreglo[i] > max)
            {
                max = arreglo[i];
                posMax = i;
            }
        }

        Console.WriteLine($"Min={min} (pos {posMin}), Max={max} (pos {posMax})");
    }

    static void Ejercicio3()
    {
        Console.WriteLine("3) Rotación de arreglo");
        Console.WriteLine("Descripción: Rota un arreglo k posiciones a la derecha\n");
        
        int[] arreglo = LeerArregloEnteros();
        
        Console.Write("Ingrese k (positivo=derecha, negativo=izquierda): ");
        if (!int.TryParse(Console.ReadLine(), out int k))
        {
            Console.WriteLine("Error: k debe ser un entero.");
            return;
        }

        // Normalizar k
        if (arreglo.Length == 0)
        {
            Console.WriteLine("Error: El arreglo no puede estar vacío.");
            return;
        }

        k = k % arreglo.Length;
        if (k < 0) k += arreglo.Length;

        int[] rotado = new int[arreglo.Length];
        
        for (int i = 0; i < arreglo.Length; i++)
        {
            rotado[(i + k) % arreglo.Length] = arreglo[i];
        }

        Console.Write("Arreglo rotado: ");
        ImprimirArreglo(rotado);
    }

    static void Ejercicio4()
    {
        Console.WriteLine("4) Distinct estable (sin repetir)");
        Console.WriteLine("Descripción: Elimina duplicados preservando primer aparición\n");
        
        int[] arreglo = LeerArregloEnteros();
        List<int> resultado = new List<int>();
        HashSet<int> vistos = new HashSet<int>();

        foreach (int num in arreglo)
        {
            if (vistos.Add(num))
            {
                resultado.Add(num);
            }
        }

        Console.Write("Sin repetidos: ");
        ImprimirLista(resultado);
    }

    static void Ejercicio5()
    {
        Console.WriteLine("5) Búsqueda lineal vs binaria (benchmark)");
        Console.WriteLine("Descripción: Compara tiempos de búsqueda lineal y binaria\n");
        
        int[] arreglo = LeerArregloEnteros();
        
        if (arreglo.Length == 0)
        {
            Console.WriteLine("Error: El arreglo no puede estar vacío.");
            return;
        }

        Array.Sort(arreglo); // Para la busqueda binaria
        
        Console.Write("Valor a buscar: ");
        if (!int.TryParse(Console.ReadLine(), out int objetivo))
        {
            Console.WriteLine("Error: Valor inválido.");
            return;
        }

        // Busqueda lineal
        var inicioLineal = DateTime.Now;
        int indiceLineal = BuscarLineal(arreglo, objetivo);
        var tiempoLineal = DateTime.Now - inicioLineal;

        // Busqueda binaria
        var inicioBinaria = DateTime.Now;
        int indiceBinaria = BuscarBinaria(arreglo, objetivo);
        var tiempoBinaria = DateTime.Now - inicioBinaria;

        Console.WriteLine($"Lineal: Índice={indiceLineal}, Tiempo={tiempoLineal.TotalMilliseconds:F2} ms");
        Console.WriteLine($"Binaria: Índice={indiceBinaria}, Tiempo={tiempoBinaria.TotalMilliseconds:F2} ms");
    }

    static int BuscarLineal(int[] arreglo, int objetivo)
    {
        for (int i = 0; i < arreglo.Length; i++)
        {
            if (arreglo[i] == objetivo) return i;
        }
        return -1;
    }

    static int BuscarBinaria(int[] arreglo, int objetivo)
    {
        int izquierda = 0, derecha = arreglo.Length - 1;
        
        while (izquierda <= derecha)
        {
            int medio = izquierda + (derecha - izquierda) / 2;
            
            if (arreglo[medio] == objetivo) return medio;
            else if (arreglo[medio] < objetivo) izquierda = medio + 1;
            else derecha = medio - 1;
        }
        
        return -1;
    }

    static void Ejercicio6()
    {
        Console.WriteLine("6) ArrayList: separar int/double y promedios");
        Console.WriteLine("Descripción: Separa int y double de ArrayList y calcula promedios\n");
        
        ArrayList lista = new ArrayList();
        
        Console.WriteLine("Ingrese elementos (int o double), vacío para terminar:");
        while (true)
        {
            Console.Write("Elemento: ");
            string entrada = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrEmpty(entrada)) break;
            
            if (int.TryParse(entrada, out int entero))
            {
                lista.Add(entero);
            }
            else if (double.TryParse(entrada, out double real))
            {
                lista.Add(real);
            }
            else
            {
                Console.WriteLine("Ignorado (no es int ni double)");
            }
        }

        List<int> enteros = new List<int>();
        List<double> reales = new List<double>();

        foreach (object item in lista)
        {
            if (item is int) enteros.Add((int)item);
            else if (item is double) reales.Add((double)item);
        }

        double promEnteros = enteros.Count > 0 ? enteros.Average() : 0;
        double promReales = reales.Count > 0 ? reales.Average() : 0;

        Console.WriteLine($"Enteros: {string.Join(", ", enteros)} Prom={promEnteros:F2}");
        Console.WriteLine($"Reales: {string.Join(", ", reales)} Prom={promReales:F2}");
    }

    static void Ejercicio7()
    {
        Console.WriteLine("7) List<int>: filtros y transformaciones");
        Console.WriteLine("Descripción: Filtra pares, obtiene cuadrados y suma\n");
        
        List<int> lista = LeerArregloEnteros().ToList();
         
        List<int> pares = new List<int>();
        List<int> cuadrados = new List<int>();
        int suma = 0;

        foreach (int num in lista)
        {
            if (num % 2 == 0) pares.Add(num);
            cuadrados.Add(num * num);
            suma += num;
        }

        Console.WriteLine($"Pares: {string.Join(", ", pares)}");
        Console.WriteLine($"Cuadrados: {string.Join(", ", cuadrados)}");
        Console.WriteLine($"Suma: {suma}");

    
        Console.WriteLine("\n--- Con LINQ ---");
        var paresLINQ = lista.Where(x => x % 2 == 0).ToList();
        var cuadradosLINQ = lista.Select(x => x * x).ToList();
        var sumaLINQ = lista.Sum();
        
        Console.WriteLine($"Pares: {string.Join(", ", paresLINQ)}");
        Console.WriteLine($"Cuadrados: {string.Join(", ", cuadradosLINQ)}");
        Console.WriteLine($"Suma: {sumaLINQ}");
    }

    static void Ejercicio8()
    {
        Console.WriteLine("8) Subarreglo de suma máxima");
        Console.WriteLine("Descripción: Encuentra suma de subarreglo entre índices\n");
        
        int[] arreglo = LeerArregloEnteros();
        
        if (arreglo.Length == 0)
        {
            Console.WriteLine("Error: El arreglo no puede estar vacío.");
            return;
        }

        Console.Write("Índice menor (iMin): ");
        if (!int.TryParse(Console.ReadLine(), out int iMin) || iMin < 0 || iMin >= arreglo.Length)
        {
            Console.WriteLine("Error: Índice menor inválido.");
            return;
        }

        Console.Write("Índice mayor (iMax): ");
        if (!int.TryParse(Console.ReadLine(), out int iMax) || iMax < iMin || iMax >= arreglo.Length)
        {
            Console.WriteLine("Error: Índice mayor inválido.");
            return;
        }

        int suma = 0;
        for (int i = iMin; i <= iMax; i++)
        {
            suma += arreglo[i];
        }

        Console.WriteLine($"SumaSubarreglo={suma}");
    }

    static void Ejercicio9()
    {
        Console.WriteLine("9) Matrices: transpuesta y sumas");
        Console.WriteLine("Descripción: Calcula transpuesta y sumas por filas/columnas\n");
        
        Console.Write("Filas: ");
        if (!int.TryParse(Console.ReadLine(), out int filas) || filas <= 0)
        {
            Console.WriteLine("Error: Filas inválidas.");
            return;
        }

        Console.Write("Columnas: ");
        if (!int.TryParse(Console.ReadLine(), out int columnas) || columnas <= 0)
        {
            Console.WriteLine("Error: Columnas inválidas.");
            return;
        }

        int[,] matriz = new int[filas, columnas];
        
        Console.WriteLine("Ingrese elementos por filas:");
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                Console.Write($"Matriz[{i},{j}]: ");
                if (!int.TryParse(Console.ReadLine(), out matriz[i, j]))
                {
                    Console.WriteLine("Error: Valor inválido.");
                    j--;
                }
            }
        }

        
        int[,] transpuesta = new int[columnas, filas];
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                transpuesta[j, i] = matriz[i, j];
            }
        }

        
        int[] sumaFilas = new int[filas];
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                sumaFilas[i] += matriz[i, j];
            }
        }

        
        int[] sumaColumnas = new int[columnas];
        for (int j = 0; j < columnas; j++)
        {
            for (int i = 0; i < filas; i++)
            {
                sumaColumnas[j] += matriz[i, j];
            }
        }

        
        Console.WriteLine("\nMatriz original:");
        MostrarMatriz(matriz);
        
        Console.WriteLine("\nMatriz transpuesta:");
        MostrarMatriz(transpuesta);
        
        Console.WriteLine($"SumaFilas: {string.Join(", ", sumaFilas)}");
        Console.WriteLine($"SumaColumnas: {string.Join(", ", sumaColumnas)}");
    }

    static void MostrarMatriz(int[,] matriz)
    {
        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                Console.Write($"{matriz[i, j],4}");
            }
            Console.WriteLine();
        }
    }

    static void Ejercicio10()
    {
        Console.WriteLine("10) Stats de notas (out y tupla)");
        Console.WriteLine("Descripción: Calcula estadísticas de notas\n");
        
        double[] notas = LeerArregloDoubles();
        
        if (notas.Length == 0)
        {
            Console.WriteLine("Error: El arreglo no puede estar vacío.");
            return;
        }

        
        CalcularStatsOut(notas, out double promA, out double minA, out double maxA, out double desvA);
        Console.WriteLine("--- Versión OUT ---");
        Console.WriteLine($"Prom={promA:F2} Min={minA:F2} Max={maxA:F2} Desv={desvA:F2}");

        
        var stats = CalcularStatsTupla(notas);
        Console.WriteLine("--- Versión TUPLA ---");
        Console.WriteLine($"Prom={stats.promedio:F2} Min={stats.minimo:F2} Max={stats.maximo:F2} Desv={stats.desviacion:F2}");
    }

    static void CalcularStatsOut(double[] notas, out double promedio, out double minimo, out double maximo, out double desviacion)
    {
        promedio = notas.Average();
        minimo = notas.Min();
        maximo = notas.Max();
        desviacion = CalcularDesviacionEstandar(notas);
    }

    static (double promedio, double minimo, double maximo, double desviacion) CalcularStatsTupla(double[] notas)
    {
        return (notas.Average(), notas.Min(), notas.Max(), CalcularDesviacionEstandar(notas));
    }

    static void Ejercicio11()
    {
        Console.WriteLine("11) Control de inventario con rechazos");
        Console.WriteLine("Descripción: Gestiona stock con movimientos y rechazos\n");
        
        Console.Write("Stock inicial (separado por espacios): ");
        List<int> stock = LeerArregloEnteros().ToList();
        
        Console.Write("Movimientos (separado por espacios): ");
        int[] movimientos = LeerArregloEnteros();
        
        List<int> rechazados = new List<int>();

        for (int i = 0; i < movimientos.Length; i++)
        {
            
            int nuevoStock = stock[0] + movimientos[i];
            
            if (nuevoStock >= 0)
            {
                stock[0] = nuevoStock;
            }
            else
            {
                rechazados.Add(i);
            }
        }

        Console.WriteLine($"Stock final: {string.Join(", ", stock)}");
        Console.WriteLine($"Rechazados (índices): {string.Join(", ", rechazados)}");
    }

    static void Ejercicio12()
    {
        Console.WriteLine("12) Calificaciones por estudiante (jagged)");
        Console.WriteLine("Descripción: Calcula promedios y ranking de estudiantes\n");
        
        Console.Write("Número de estudiantes: ");
        if (!int.TryParse(Console.ReadLine(), out int numEstudiantes) || numEstudiantes <= 0)
        {
            Console.WriteLine("Error: Número inválido.");
            return;
        }

        double[][] calificaciones = new double[numEstudiantes][];
        List<(int indice, double promedio)> promedios = new List<(int, double)>();

        for (int i = 0; i < numEstudiantes; i++)
        {
            Console.Write($"Notas del estudiante {i + 1} (separadas por espacios): ");
            double[] notas = LeerArregloDoubles();
            
            if (notas.Length == 0)
            {
                Console.WriteLine("Error: Cada estudiante debe tener al menos una nota.");
                i--;
                continue;
            }

            calificaciones[i] = notas;
            double promedio = notas.Average();
            promedios.Add((i, promedio));
        }

        
        promedios.Sort((a, b) => b.promedio.CompareTo(a.promedio));

        
        Console.WriteLine("\n--- Resultados por Estudiante ---");
        for (int i = 0; i < numEstudiantes; i++)
        {
            string estado = promedios[i].promedio >= 3.0 ? "Aprobado" : "Reprobado";
            Console.WriteLine($"Est{i + 1}: {promedios[i].promedio:F2} ({estado})");
        }

        Console.WriteLine("\n--- Top-3 ---");
        for (int i = 0; i < Math.Min(3, numEstudiantes); i++)
        {
            Console.WriteLine($"Est{promedios[i].indice + 1}({promedios[i].promedio:F2})");
        }
    }

    static void Ejercicio13()
    {
        Console.WriteLine("13) Normalización min-max");
        Console.WriteLine("Descripción: Normaliza valores al rango [0,1]\n");
        
        double[] valores = LeerArregloDoubles();
        
        if (valores.Length == 0)
        {
            Console.WriteLine("Error: El arreglo no puede estar vacío.");
            return;
        }

        double min = valores.Min();
        double max = valores.Max();

        double[] normalizados;
        
        if (min == max)
        {
            
            Console.WriteLine("Nota: Todos los valores son iguales. Retornando 0.0 para todos.");
            normalizados = new double[valores.Length];
            for (int i = 0; i < valores.Length; i++)
            {
                normalizados[i] = 0.0;
            }
        }
        else
        {
            normalizados = new double[valores.Length];
            for (int i = 0; i < valores.Length; i++)
            {
                normalizados[i] = (valores[i] - min) / (max - min);
            }
        }

        Console.Write("Valores normalizados: ");
        foreach (double valor in normalizados)
        {
            Console.Write($"{valor:F2} ");
        }
        Console.WriteLine();
    }

    static void Ejercicio14()
    {
        Console.WriteLine("14) Consolidación de encuestas (CSV simulado)");
        Console.WriteLine("Descripción: Procesa encuestas y promedia por ciudad\n");
        
        List<string> lineas = new List<string>();
        Console.WriteLine("Ingrese líneas (formato: Edad,Ciudad,Puntaje), vacío para terminar:");
        
        while (true)
        {
            Console.Write("Línea: ");
            string linea = Console.ReadLine();
            if (string.IsNullOrEmpty(linea)) break;
            lineas.Add(linea);
        }

        List<string> ciudades = new List<string>();
        List<double> promedios = new List<double>();
        List<int> conteos = new List<int>();
        List<string> invalidas = new List<string>();

        foreach (string linea in lineas)
        {
            string[] campos = linea.Split(',');
            if (campos.Length != 3)
            {
                invalidas.Add(linea);
                continue;
            }

            string ciudad = campos[1].Trim();
            if (!int.TryParse(campos[0].Trim(), out int edad) || 
                !int.TryParse(campos[2].Trim(), out int puntaje) ||
                edad < 0 || puntaje < 0)
            {
                invalidas.Add(linea);
                continue;
            }

            int indice = ciudades.IndexOf(ciudad);
            if (indice == -1)
            {
                ciudades.Add(ciudad);
                promedios.Add(puntaje);
                conteos.Add(1);
            }
            else
            {
                promedios[indice] += puntaje;
                conteos[indice]++;
            }
        }

        
        for (int i = 0; i < ciudades.Count; i++)
        {
            promedios[i] /= conteos[i];
        }

        Console.WriteLine("\n--- Promedios por Ciudad ---");
        for (int i = 0; i < ciudades.Count; i++)
        {
            Console.WriteLine($"{ciudades[i]}: {promedios[i]:F2}");
        }

        Console.WriteLine($"\nInválidas: [{string.Join(", ", invalidas.Select(s => $"\"{s}\""))}]");
    }

    static void Ejercicio15()
    {
        Console.WriteLine("15) Kiosko de turnos con List<int>");
        Console.WriteLine("Descripción: Simula cola de turnos\n");
        
        List<int> cola = new List<int>();
        Console.WriteLine("Comandos: E <id> (encolar), A (atender), P (próximo), S (salir)");
        
        while (true)
        {
            Console.Write("Comando: ");
            string comando = (Console.ReadLine() ?? string.Empty).ToUpper().Trim();
            
            if (comando == "S") break;
            
            if (comando == "P")
            {
                if (cola.Count > 0)
                {
                    Console.WriteLine(cola[0]);
                }
                else
                {
                    Console.WriteLine("(vacía)");
                }
            }
            else if (comando == "A")
            {
                if (cola.Count > 0)
                {
                    cola.RemoveAt(0);
                    Console.WriteLine("Atendido");
                }
                else
                {
                    Console.WriteLine("Cola vacía - nada que atender");
                }
            }
            else if (comando.StartsWith("E "))
            {
                if (int.TryParse(comando.Substring(2), out int id))
                {
                    cola.Add(id);
                    Console.WriteLine($"Encuelado {id}");
                }
                else
                {
                    Console.WriteLine("ID inválido");
                }
            }
            else
            {
                Console.WriteLine("Comando inválido");
            }
        }
    }

    static void Ejercicio16()
    {
        Console.WriteLine("16) Limpieza de texto y top-k por longitud");
        Console.WriteLine("Descripción: Procesa texto y encuentra palabras más largas\n");
        
    Console.Write("Texto: ");
    string texto = Console.ReadLine() ?? string.Empty;
        
        Console.Write("k: ");
        if (!int.TryParse(Console.ReadLine(), out int k) || k <= 0)
        {
            Console.WriteLine("Error: k inválido.");
            return;
        }

        
        char[] delimitadores = { ' ', ',', ';', '.', '!', '?', ':', '\t', '\n' };
        string[] palabras = texto.Split(delimitadores, StringSplitOptions.RemoveEmptyEntries);
        
        List<string> palabrasLimpias = new List<string>();
        HashSet<string> vistas = new HashSet<string>();

        foreach (string palabra in palabras)
        {
            string limpia = palabra.ToLower().Trim();
            if (!string.IsNullOrEmpty(limpia) && vistas.Add(limpia))
            {
                palabrasLimpias.Add(limpia);
            }
        }

        
        var topK = palabrasLimpias
            .OrderByDescending(p => p.Length)
            .ThenBy(p => p)
            .Take(k)
            .ToList();

        Console.WriteLine($"Lista limpia: {string.Join(", ", palabrasLimpias)}");
        Console.WriteLine($"Top-{k}: {string.Join(", ", topK)}");
    }

    static void Ejercicio17()
    {
        Console.WriteLine("17) Agenda: huecos libres (intervalos)");
        Console.WriteLine("Descripción: Encuentra huecos libres en agenda\n");
        
        List<(int inicio, int fin)> ocupados = new List<(int, int)>();
        Console.WriteLine("Ingrese intervalos ocupados [inicio,fin), vacío para terminar:");
        
        while (true)
        {
            Console.Write("Inicio: ");
                string inicioStr = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrEmpty(inicioStr)) break;
            
            Console.Write("Fin: ");
            string finStr = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrEmpty(finStr)) break;

            if (!int.TryParse(inicioStr, out int inicio) || !int.TryParse(finStr, out int fin) ||
                inicio < 0 || fin > 1440 || inicio >= fin)
            {
                Console.WriteLine("Intervalo inválido. Debe ser 0 ≤ inicio < fin ≤ 1440");
                continue;
            }

            ocupados.Add((inicio, fin));
        }

        Console.Write("Minutos mínimos (X): ");
        if (!int.TryParse(Console.ReadLine(), out int X) || X <= 0)
        {
            Console.WriteLine("Error: X inválido.");
            return;
        }

        
        if (ocupados.Count > 0)
        {
            ocupados.Sort((a, b) => a.inicio.CompareTo(b.inicio));
            
            List<(int inicio, int fin)> unidos = new List<(int, int)>();
            (int inicio, int fin) actual = ocupados[0];
            
            for (int i = 1; i < ocupados.Count; i++)
            {
                if (ocupados[i].inicio <= actual.fin)
                {
                    actual.fin = Math.Max(actual.fin, ocupados[i].fin);
                }
                else
                {
                    unidos.Add(actual);
                    actual = ocupados[i];
                }
            }
            unidos.Add(actual);
            ocupados = unidos;
        }

        
        List<(int inicio, int fin)> libres = new List<(int, int)>();
        int tiempoActual = 0;

        foreach (var ocupado in ocupados)
        {
            if (ocupado.inicio - tiempoActual >= X)
            {
                libres.Add((tiempoActual, ocupado.inicio));
            }
            tiempoActual = Math.Max(tiempoActual, ocupado.fin);
        }

        if (1440 - tiempoActual >= X)
        {
            libres.Add((tiempoActual, 1440));
        }

        Console.WriteLine("Huecos libres:");
        foreach (var libre in libres)
        {
            Console.WriteLine($"[{libre.inicio},{libre.fin})");
        }
    }

    static void Ejercicio18()
    {
        Console.WriteLine("18) Inventario por categorías (sin diccionario)");
        Console.WriteLine("Descripción: Agrupa cantidades por categoría\n");
        
    Console.Write("Categorías (separadas por espacios): ");
    string[] categoriasEntrada = (Console.ReadLine() ?? string.Empty).Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
    Console.Write("Cantidades (separadas por espacios): ");
    string[] cantidadesEntrada = (Console.ReadLine() ?? string.Empty).Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (categoriasEntrada.Length != cantidadesEntrada.Length)
        {
            Console.WriteLine("Error: Debe haber la misma cantidad de categorías y cantidades.");
            return;
        }

        List<string> categoriasUnicas = new List<string>();
        List<int> totales = new List<int>();

        for (int i = 0; i < categoriasEntrada.Length; i++)
        {
            string categoria = categoriasEntrada[i];
            if (!int.TryParse(cantidadesEntrada[i], out int cantidad))
            {
                Console.WriteLine($"Error: Cantidad inválida '{cantidadesEntrada[i]}'");
                continue;
            }

            int indice = categoriasUnicas.IndexOf(categoria);
            if (indice == -1)
            {
                categoriasUnicas.Add(categoria);
                totales.Add(cantidad);
            }
            else
            {
                totales[indice] += cantidad;
            }
        }

        Console.WriteLine("\n--- Totales por Categoría ---");
        for (int i = 0; i < categoriasUnicas.Count; i++)
        {
            Console.WriteLine($"{categoriasUnicas[i]}:{totales[i]}");
        }
    }

    static void Ejercicio19()
    {
        Console.WriteLine("19) Top-N palabras más frecuentes");
        Console.WriteLine("Descripción: Encuentra palabras más frecuentes\n");
        
    Console.Write("Texto: ");
    string texto = Console.ReadLine() ?? string.Empty;
        
        Console.Write("N: ");
        if (!int.TryParse(Console.ReadLine(), out int N) || N <= 0)
        {
            Console.WriteLine("Error: N inválido.");
            return;
        }

        
        char[] delimitadores = { ' ', ',', ';', '.', '!', '?', ':', '\t', '\n', '(', ')', '[', ']' };
        string[] palabras = texto.ToLower().Split(delimitadores, StringSplitOptions.RemoveEmptyEntries);
        
        List<string> palabrasUnicas = new List<string>();
        List<int> frecuencias = new List<int>();

        foreach (string palabra in palabras)
        {
            string limpia = palabra.Trim();
            if (string.IsNullOrEmpty(limpia)) continue;

            int indice = palabrasUnicas.IndexOf(limpia);
            if (indice == -1)
            {
                palabrasUnicas.Add(limpia);
                frecuencias.Add(1);
            }
            else
            {
                frecuencias[indice]++;
            }
        }

        
        List<(string palabra, int frecuencia)> ranking = new List<(string, int)>();
        for (int i = 0; i < palabrasUnicas.Count; i++)
        {
            ranking.Add((palabrasUnicas[i], frecuencias[i]));
        }

        ranking.Sort((a, b) => 
        {
            int cmp = b.frecuencia.CompareTo(a.frecuencia);
            return cmp != 0 ? cmp : a.palabra.CompareTo(b.palabra);
        });

        Console.WriteLine($"\nTop-{N} palabras más frecuentes:");
        for (int i = 0; i < Math.Min(N, ranking.Count); i++)
        {
            Console.WriteLine($"{ranking[i].palabra}:{ranking[i].frecuencia}");
        }
    }

    static void Ejercicio20()
    {
        Console.WriteLine("20) Ventas diarias (24 horas)");
        Console.WriteLine("Descripción: Analiza ventas por horas del día\n");
        
        int[] ventas = new int[24];
        Console.WriteLine("Ingrese ventas para cada hora (0-23):");
        
        for (int i = 0; i < 24; i++)
        {
            Console.Write($"Hora {i:00}:00: ");
            if (!int.TryParse(Console.ReadLine(), out ventas[i]) || ventas[i] < 0)
            {
                Console.WriteLine("Error: Valor inválido. Use 0 o positivo. Intente nuevamente.");
                i--;
            }
        }

        
        int total = ventas.Sum();
        int horaPico = 0;
        int maxVentas = ventas[0];
        
        for (int i = 1; i < 24; i++)
        {
            if (ventas[i] > maxVentas)
            {
                maxVentas = ventas[i];
                horaPico = i;
            }
        }

        
        double promManana = CalcularPromedioFranja(ventas, 6, 11);
        double promTarde = CalcularPromedioFranja(ventas, 12, 17);
        double promNoche = CalcularPromedioFranja(ventas, 18, 23);
        
        double promedioDiario = total / 24.0;
        List<int> horasSobrePromedio = new List<int>();
        
        for (int i = 0; i < 24; i++)
        {
            if (ventas[i] > promedioDiario)
            {
                horasSobrePromedio.Add(i);
            }
        }

        
        Console.WriteLine($"\n--- RESULTADOS VENTAS DIARIAS ---");
        Console.WriteLine($"Total: {total}");
        Console.WriteLine($"Hora pico: {horaPico}:00 ({ventas[horaPico]} ventas)");
        Console.WriteLine($"Promedio Mañana (6-11): {promManana:F2}");
        Console.WriteLine($"Promedio Tarde (12-17): {promTarde:F2}");
        Console.WriteLine($"Promedio Noche (18-23): {promNoche:F2}");
        Console.WriteLine($"Promedio Diario: {promedioDiario:F2}");
        Console.WriteLine($"Horas sobre promedio: [{string.Join(", ", horasSobrePromedio)}]");
    }

    static double CalcularPromedioFranja(int[] ventas, int inicio, int fin)
    {
        int suma = 0;
        int count = 0;
        
        for (int i = inicio; i <= fin; i++)
        {
            suma += ventas[i];
            count++;
        }
        
        return count > 0 ? (double)suma / count : 0;
    }
}
