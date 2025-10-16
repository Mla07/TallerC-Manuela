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
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida. Presione cualquier tecla para continuar...");
                Console.ReadLine();
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
        Console.ReadLine();
    }

    // ==================== EJERCICIO 1 ====================
    static void Ejercicio1()
    {
        Console.WriteLine("1) Casteo seguro a int[]");
        Console.WriteLine("Descripción: Convierte línea de texto con números en arreglo int[]\n");
        
        // Llamar subfunción que retorna el arreglo
        int[] resultado = ConvertirTextoAArregloEnteros();
        
        // Solo orquesta: muestra resultado
        Console.Write("Arreglo int[]: ");
        MostrarArreglo(resultado);
    }

    static int[] ConvertirTextoAArregloEnteros()
    {
        while (true)
        {
            try
            {
                Console.Write("Ingrese números enteros separados por espacios: ");
                string entrada = Console.ReadLine() ?? string.Empty;
                
                // Validar que no esté vacía
                if (string.IsNullOrWhiteSpace(entrada))
                {
                    throw new Exception("La línea no puede estar vacía");
                }

                // Separar por espacios
                string[] partes = entrada.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int[] arreglo = new int[partes.Length];
                
                // Convertir cada parte a entero
                for (int i = 0; i < partes.Length; i++)
                {
                    if (!int.TryParse(partes[i], out arreglo[i]))
                    {
                        throw new FormatException($"'{partes[i]}' no es un entero válido");
                    }
                }
                
                return arreglo;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}. Intente nuevamente.");
            }
        }
    }

    // ==================== EJERCICIO 2 ====================
    static void Ejercicio2()
    {
        Console.WriteLine("2) Mínimo, máximo y posiciones");
        Console.WriteLine("Descripción: Encuentra min, max y sus primeras posiciones\n");
        
        int[] arreglo = ConvertirTextoAArregloEnteros();
        
        // Llamar subfunción que calcula estadísticas
        var estadisticas = CalcularMinMaxPosiciones(arreglo);
        
        // Solo orquesta: muestra resultados
        Console.WriteLine($"Min={estadisticas.min} (pos {estadisticas.posMin}), Max={estadisticas.max} (pos {estadisticas.posMax})");
    }

    static (int min, int max, int posMin, int posMax) CalcularMinMaxPosiciones(int[] arreglo)
    {
        // Validar que no esté vacío
        if (arreglo.Length == 0)
        {
            throw new ArgumentException("El arreglo no puede estar vacío");
        }

        // Inicializar con el primer elemento
        int min = arreglo[0];
        int max = arreglo[0];
        int posMin = 0;
        int posMax = 0;

        // Buscar mínimo y máximo
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

        return (min, max, posMin, posMax);
    }

    // ==================== EJERCICIO 3 ====================
    static void Ejercicio3()
    {
        Console.WriteLine("3) Rotación de arreglo");
        Console.WriteLine("Descripción: Rota un arreglo k posiciones a la derecha\n");
        
        int[] arreglo = ConvertirTextoAArregloEnteros();
        int k = LeerEntero("Ingrese k (positivo=derecha, negativo=izquierda): ");
        
        // Llamar subfunción que rota
        int[] rotado = RotarArreglo(arreglo, k);
        
        // Solo orquesta: muestra resultado
        Console.Write("Arreglo rotado: ");
        MostrarArreglo(rotado);
    }

    static int[] RotarArreglo(int[] arreglo, int k)
    {
        if (arreglo.Length == 0) return new int[0];
        
        // Normalizar k al rango [0, Length)
        k = k % arreglo.Length;
        if (k < 0) k += arreglo.Length;

        int[] rotado = new int[arreglo.Length];
        
        // Rotar cada elemento
        for (int i = 0; i < arreglo.Length; i++)
        {
            int nuevaPosicion = (i + k) % arreglo.Length;
            rotado[nuevaPosicion] = arreglo[i];
        }

        return rotado;
    }

    // ==================== EJERCICIO 4 ====================
    static void Ejercicio4()
    {
        Console.WriteLine("4) Distinct estable (sin repetir)");
        Console.WriteLine("Descripción: Elimina duplicados preservando primer aparición\n");
        
        int[] arreglo = ConvertirTextoAArregloEnteros();
        
        // Llamar subfunción
        List<int> sinRepetidos = EliminarDuplicados(arreglo);
        
        // Solo orquesta: muestra resultado
        Console.Write("Sin repetidos: ");
        MostrarLista(sinRepetidos);
    }

    static List<int> EliminarDuplicados(int[] arreglo)
    {
        List<int> resultado = new List<int>();
        HashSet<int> vistos = new HashSet<int>();

        foreach (int numero in arreglo)
        {
            // Add retorna true si el elemento es nuevo
            if (vistos.Add(numero))
            {
                resultado.Add(numero);
            }
        }

        return resultado;
    }

    // ==================== EJERCICIO 5 ====================
    static void Ejercicio5()
    {
        Console.WriteLine("5) Búsqueda lineal vs binaria (benchmark)");
        Console.WriteLine("Descripción: Compara tiempos de búsqueda lineal y binaria\n");
        
        int[] arreglo = ConvertirTextoAArregloEnteros();
        Array.Sort(arreglo); // Necesario para búsqueda binaria
        
        Console.WriteLine("Arreglo ordenado para búsqueda binaria");
        int objetivo = LeerEntero("Valor a buscar: ");
        
        // Ejecutar benchmarks
        var resultadoLineal = BenchmarkBusquedaLineal(arreglo, objetivo);
        var resultadoBinaria = BenchmarkBusquedaBinaria(arreglo, objetivo);
        
        // Mostrar resultados
        Console.WriteLine($"Lineal: Índice={resultadoLineal.indice}, Tiempo={resultadoLineal.tiempo:F4} ms");
        Console.WriteLine($"Binaria: Índice={resultadoBinaria.indice}, Tiempo={resultadoBinaria.tiempo:F4} ms");
    }

    static (int indice, double tiempo) BenchmarkBusquedaLineal(int[] arreglo, int objetivo)
    {
        var inicio = DateTime.Now;
        int indice = BusquedaLineal(arreglo, objetivo);
        var tiempo = (DateTime.Now - inicio).TotalMilliseconds;
        return (indice, tiempo);
    }

    static (int indice, double tiempo) BenchmarkBusquedaBinaria(int[] arreglo, int objetivo)
    {
        var inicio = DateTime.Now;
        int indice = BusquedaBinaria(arreglo, objetivo);
        var tiempo = (DateTime.Now - inicio).TotalMilliseconds;
        return (indice, tiempo);
    }

    static int BusquedaLineal(int[] arreglo, int objetivo)
    {
        for (int i = 0; i < arreglo.Length; i++)
        {
            if (arreglo[i] == objetivo) return i;
        }
        return -1;
    }

    static int BusquedaBinaria(int[] arreglo, int objetivo)
    {
        int izq = 0;
        int der = arreglo.Length - 1;
        
        while (izq <= der)
        {
            int medio = izq + (der - izq) / 2;
            
            if (arreglo[medio] == objetivo)
                return medio;
            else if (arreglo[medio] < objetivo)
                izq = medio + 1;
            else
                der = medio - 1;
        }
        
        return -1;
    }

    // ==================== EJERCICIO 6 ====================
    static void Ejercicio6()
    {
        Console.WriteLine("6) ArrayList: separar int/double y promedios");
        Console.WriteLine("Descripción: Separa int y double de ArrayList y calcula promedios\n");
        
        ArrayList lista = LeerArrayList();
        var resultado = SepararYPromediar(lista);
        
        // Mostrar resultados
        Console.WriteLine($"Enteros: [{string.Join(", ", resultado.enteros)}] Prom={resultado.promEnteros:F2}");
        Console.WriteLine($"Reales: [{string.Join(", ", resultado.reales)}] Prom={resultado.promReales:F2}");
    }

    static ArrayList LeerArrayList()
    {
        ArrayList lista = new ArrayList();
        Console.WriteLine("Ingrese elementos (int o double), vacío para terminar:");
        
        while (true)
        {
            Console.Write("Elemento: ");
            string entrada = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrEmpty(entrada)) break;
            
            // Intentar parsear como int primero
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
        
        return lista;
    }

    static (List<int> enteros, List<double> reales, double promEnteros, double promReales) 
        SepararYPromediar(ArrayList lista)
    {
        List<int> enteros = new List<int>();
        List<double> reales = new List<double>();

        // Separar por tipo
        foreach (object item in lista)
        {
            if (item is int entero)
                enteros.Add(entero);
            else if (item is double real)
                reales.Add(real);
        }

        // Calcular promedios
        double promEnteros = enteros.Count > 0 ? enteros.Average() : 0;
        double promReales = reales.Count > 0 ? reales.Average() : 0;

        return (enteros, reales, promEnteros, promReales);
    }

    // ==================== EJERCICIO 7 ====================
    static void Ejercicio7()
    {
        Console.WriteLine("7) List<int>: filtros y transformaciones");
        Console.WriteLine("Descripción: Filtra pares, obtiene cuadrados y suma\n");
        
        List<int> lista = ConvertirTextoAArregloEnteros().ToList();
        
        // Sin LINQ
        var resultadoManual = ProcesarListaManual(lista);
        Console.WriteLine("--- Sin LINQ ---");
        Console.WriteLine($"Pares: [{string.Join(", ", resultadoManual.pares)}]");
        Console.WriteLine($"Cuadrados: [{string.Join(", ", resultadoManual.cuadrados)}]");
        Console.WriteLine($"Suma: {resultadoManual.suma}");
        
        // Con LINQ
        var resultadoLINQ = ProcesarListaLINQ(lista);
        Console.WriteLine("\n--- Con LINQ ---");
        Console.WriteLine($"Pares: [{string.Join(", ", resultadoLINQ.pares)}]");
        Console.WriteLine($"Cuadrados: [{string.Join(", ", resultadoLINQ.cuadrados)}]");
        Console.WriteLine($"Suma: {resultadoLINQ.suma}");
    }

    static (List<int> pares, List<int> cuadrados, int suma) ProcesarListaManual(List<int> lista)
    {
        List<int> pares = new List<int>();
        List<int> cuadrados = new List<int>();
        int suma = 0;

        foreach (int num in lista)
        {
            if (num % 2 == 0)
                pares.Add(num);
            
            cuadrados.Add(num * num);
            suma += num;
        }

        return (pares, cuadrados, suma);
    }

    static (List<int> pares, List<int> cuadrados, int suma) ProcesarListaLINQ(List<int> lista)
    {
        var pares = lista.Where(x => x % 2 == 0).ToList();
        var cuadrados = lista.Select(x => x * x).ToList();
        var suma = lista.Sum();
        
        return (pares, cuadrados, suma);
    }

    // ==================== EJERCICIO 8 ====================
    static void Ejercicio8()
    {
        Console.WriteLine("8) Subarreglo de suma máxima");
        Console.WriteLine("Descripción: Encuentra suma de subarreglo entre índices\n");
        
        int[] arreglo = ConvertirTextoAArregloEnteros();
        MostrarArreglo(arreglo);
        
        int iMin = LeerIndice("Índice menor (iMin): ", arreglo.Length);
        int iMax = LeerIndiceMax("Índice mayor (iMax): ", iMin, arreglo.Length);
        
        int suma = CalcularSumaSubarreglo(arreglo, iMin, iMax);
        
        Console.WriteLine($"SumaSubarreglo={suma}");
    }

    static int CalcularSumaSubarreglo(int[] arreglo, int iMin, int iMax)
    {
        int suma = 0;
        for (int i = iMin; i <= iMax; i++)
        {
            suma += arreglo[i];
        }
        return suma;
    }

    // ==================== EJERCICIO 9 ====================
    static void Ejercicio9()
    {
        Console.WriteLine("9) Matrices: transpuesta y sumas");
        Console.WriteLine("Descripción: Calcula transpuesta y sumas por filas/columnas\n");
        
        int filas = LeerEnteroPositivo("Filas: ");
        int columnas = LeerEnteroPositivo("Columnas: ");
        
        int[,] matriz = LeerMatriz(filas, columnas);
        
        var resultado = ProcesarMatriz(matriz);
        
        Console.WriteLine("\nMatriz original:");
        MostrarMatriz(matriz);
        
        Console.WriteLine("\nMatriz transpuesta:");
        MostrarMatriz(resultado.transpuesta);
        
        Console.WriteLine($"SumaFilas: [{string.Join(", ", resultado.sumaFilas)}]");
        Console.WriteLine($"SumaColumnas: [{string.Join(", ", resultado.sumaColumnas)}]");
    }

    static int[,] LeerMatriz(int filas, int columnas)
    {
        int[,] matriz = new int[filas, columnas];
        
        Console.WriteLine("Ingrese elementos por filas:");
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                matriz[i, j] = LeerEntero($"Matriz[{i},{j}]: ");
            }
        }
        
        return matriz;
    }

    static (int[,] transpuesta, int[] sumaFilas, int[] sumaColumnas) ProcesarMatriz(int[,] matriz)
    {
        int filas = matriz.GetLength(0);
        int columnas = matriz.GetLength(1);
        
        // Crear transpuesta
        int[,] transpuesta = new int[columnas, filas];
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                transpuesta[j, i] = matriz[i, j];
            }
        }
        
        // Calcular suma por filas
        int[] sumaFilas = new int[filas];
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                sumaFilas[i] += matriz[i, j];
            }
        }
        
        // Calcular suma por columnas
        int[] sumaColumnas = new int[columnas];
        for (int j = 0; j < columnas; j++)
        {
            for (int i = 0; i < filas; i++)
            {
                sumaColumnas[j] += matriz[i, j];
            }
        }
        
        return (transpuesta, sumaFilas, sumaColumnas);
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

    // ==================== EJERCICIO 10 ====================
    static void Ejercicio10()
    {
        Console.WriteLine("10) Stats de notas (out y tupla)");
        Console.WriteLine("Descripción: Calcula estadísticas de notas\n");
        
        double[] notas = ConvertirTextoAArregloDoubles();
        
        // Versión con out
        CalcularEstadisticasOut(notas, out double prom, out double min, out double max, out double desv);
        Console.WriteLine("--- Versión OUT ---");
        Console.WriteLine($"Prom={prom:F2} Min={min:F2} Max={max:F2} Desv={desv:F2}");
        
        // Versión con tupla
        var stats = CalcularEstadisticasTupla(notas);
        Console.WriteLine("--- Versión TUPLA ---");
        Console.WriteLine($"Prom={stats.promedio:F2} Min={stats.minimo:F2} Max={stats.maximo:F2} Desv={stats.desviacion:F2}");
    }

    static void CalcularEstadisticasOut(double[] notas, out double promedio, out double minimo, 
        out double maximo, out double desviacion)
    {
        promedio = notas.Average();
        minimo = notas.Min();
        maximo = notas.Max();
        desviacion = CalcularDesviacionEstandar(notas);
    }

    static (double promedio, double minimo, double maximo, double desviacion) 
        CalcularEstadisticasTupla(double[] notas)
    {
        double promedio = notas.Average();
        double minimo = notas.Min();
        double maximo = notas.Max();
        double desviacion = CalcularDesviacionEstandar(notas);
        
        return (promedio, minimo, maximo, desviacion);
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

    // ==================== EJERCICIO 11 ====================
    static void Ejercicio11()
    {
        Console.WriteLine("11) Control de inventario con rechazos");
        Console.WriteLine("Descripción: Gestiona stock con movimientos y rechazos\n");
        
        Console.Write("Stock inicial: ");
        int stockInicial = LeerEntero("");
        
        int[] movimientos = ConvertirTextoAArregloEnteros();
        
        var resultado = AplicarMovimientos(stockInicial, movimientos);
        
        Console.WriteLine($"Stock final: {resultado.stockFinal}");
        Console.WriteLine($"Rechazados (índices): [{string.Join(", ", resultado.rechazados)}]");
    }

    static (int stockFinal, List<int> rechazados) AplicarMovimientos(int stockInicial, int[] movimientos)
    {
        int stock = stockInicial;
        List<int> rechazados = new List<int>();
        
        for (int i = 0; i < movimientos.Length; i++)
        {
            int nuevoStock = stock + movimientos[i];
            
            if (nuevoStock >= 0)
            {
                stock = nuevoStock;
            }
            else
            {
                rechazados.Add(i);
            }
        }
        
        return (stock, rechazados);
    }

    // ==================== EJERCICIO 12 ====================
    static void Ejercicio12()
    {
        Console.WriteLine("12) Calificaciones por estudiante (jagged)");
        Console.WriteLine("Descripción: Calcula promedios y ranking de estudiantes\n");
        
        int numEstudiantes = LeerEnteroPositivo("Número de estudiantes: ");
        double[][] calificaciones = LeerCalificaciones(numEstudiantes);
        
        var resultado = ProcesarCalificaciones(calificaciones);
        
        Console.WriteLine("\n--- Resultados por Estudiante ---");
        for (int i = 0; i < resultado.promedios.Count; i++)
        {
            string estado = resultado.promedios[i] >= 3.0 ? "Aprobado" : "Reprobado";
            Console.WriteLine($"Est{i + 1}: {resultado.promedios[i]:F2} ({estado})");
        }
        
        Console.WriteLine("\n--- Top-3 ---");
        for (int i = 0; i < Math.Min(3, resultado.top3.Count); i++)
        {
            Console.WriteLine($"Est{resultado.top3[i].indice + 1}({resultado.top3[i].promedio:F2})");
        }
    }

    static double[][] LeerCalificaciones(int numEstudiantes)
    {
        double[][] calificaciones = new double[numEstudiantes][];
        
        for (int i = 0; i < numEstudiantes; i++)
        {
            Console.Write($"Notas del estudiante {i + 1} (separadas por espacios): ");
            calificaciones[i] = ConvertirTextoAArregloDoubles();
        }
        
        return calificaciones;
    }

    static (List<double> promedios, List<(int indice, double promedio)> top3) 
        ProcesarCalificaciones(double[][] calificaciones)
    {
        List<double> promedios = new List<double>();
        List<(int indice, double promedio)> ranking = new List<(int, double)>();
        
        for (int i = 0; i < calificaciones.Length; i++)
        {
            double promedio = calificaciones[i].Average();
            promedios.Add(promedio);
            ranking.Add((i, promedio));
        }
        
        // Ordenar para obtener top 3
        ranking.Sort((a, b) => b.promedio.CompareTo(a.promedio));
        
        var top3 = ranking.Take(3).ToList();
        
        return (promedios, top3);
    }

    // ==================== EJERCICIO 13 ====================
    static void Ejercicio13()
    {
        Console.WriteLine("13) Normalización min-max");
        Console.WriteLine("Descripción: Normaliza valores al rango [0,1]\n");
        
        double[] valores = ConvertirTextoAArregloDoubles();
        double[] normalizados = NormalizarMinMax(valores);
        
        Console.Write("Valores normalizados: ");
        foreach (double valor in normalizados)
        {
            Console.Write($"{valor:F2} ");
        }
        Console.WriteLine();
    }

    static double[] NormalizarMinMax(double[] valores)
    {
        if (valores.Length == 0) return new double[0];
        
        double min = valores.Min();
        double max = valores.Max();
        double[] normalizados = new double[valores.Length];
        
        if (min == max)
        {
            // Todos los valores son iguales
            Console.WriteLine("Nota: Todos los valores son iguales. Retornando 0.0 para todos.");
            // Array ya inicializado con 0.0
        }
        else
        {
            for (int i = 0; i < valores.Length; i++)
            {
                normalizados[i] = (valores[i] - min) / (max - min);
            }
        }
        
        return normalizados;
    }

    // ==================== EJERCICIO 14 ====================
    static void Ejercicio14()
    {
        Console.WriteLine("14) Consolidación de encuestas (CSV simulado)");
        Console.WriteLine("Descripción: Procesa encuestas y promedia por ciudad\n");
        
        List<string> lineas = LeerLineasCSV();
        var resultado = ProcesarEncuestas(lineas);
        
        Console.WriteLine("\n--- Promedios por Ciudad ---");
        for (int i = 0; i < resultado.ciudades.Count; i++)
        {
            Console.WriteLine($"{resultado.ciudades[i]}: {resultado.promedios[i]:F2}");
        }
        
        Console.WriteLine($"\nInválidas: [{string.Join(", ", resultado.invalidas.Select(s => $"\"{s}\""))}]");
    }

    static List<string> LeerLineasCSV()
    {
        List<string> lineas = new List<string>();
        Console.WriteLine("Ingrese líneas (formato: Edad,Ciudad,Puntaje), vacío para terminar:");
        
        while (true)
        {
            Console.Write("Línea: ");
            string linea = Console.ReadLine();
            if (string.IsNullOrEmpty(linea)) break;
            lineas.Add(linea);
        }
        
        return lineas;
    }

    static (List<string> ciudades, List<double> promedios, List<string> invalidas) 
        ProcesarEncuestas(List<string> lineas)
    {
        List<string> ciudades = new List<string>();
        List<double> sumas = new List<double>();
        List<int> conteos = new List<int>();
        List<string> invalidas = new List<string>();
        
        foreach (string linea in lineas)
        {
            string[] campos = linea.Split(',');
            
            // Validar formato
            if (campos.Length != 3 ||
                !int.TryParse(campos[0].Trim(), out int edad) ||
                !int.TryParse(campos[2].Trim(), out int puntaje) ||
                edad < 0 || puntaje < 0)
            {
                invalidas.Add(linea);
                continue;
            }
            
            string ciudad = campos[1].Trim();
            int indice = ciudades.IndexOf(ciudad);
            
            if (indice == -1)
            {
                ciudades.Add(ciudad);
                sumas.Add(puntaje);
                conteos.Add(1);
            }
            else
            {
                sumas[indice] += puntaje;
                conteos[indice]++;
            }
        }
        
        // Calcular promedios
        List<double> promedios = new List<double>();
        for (int i = 0; i < ciudades.Count; i++)
        {
            promedios.Add(sumas[i] / conteos[i]);
        }
        
        return (ciudades, promedios, invalidas);
    }

    // ==================== EJERCICIO 15 ====================
    static void Ejercicio15()
    {
        Console.WriteLine("15) Kiosko de turnos con List<int>");
        Console.WriteLine("Descripción: Simula cola de turnos\n");
        
        SimularKiosko();
    }

    static void SimularKiosko()
    {
        List<int> cola = new List<int>();
        Console.WriteLine("Comandos: E <id> (encolar), A (atender), P (próximo), S (salir)");
        
        while (true)
        {
            Console.Write("Comando: ");
            string comando = (Console.ReadLine() ?? "").ToUpper().Trim();
            
            if (comando == "S") break;
            
            string resultado = ProcesarComandoKiosko(cola, comando);
            Console.WriteLine(resultado);
        }
    }

    static string ProcesarComandoKiosko(List<int> cola, string comando)
    {
        if (comando == "P")
        {
            return cola.Count > 0 ? cola[0].ToString() : "(vacía)";
        }
        else if (comando == "A")
        {
            if (cola.Count > 0)
            {
                cola.RemoveAt(0);
                return "Atendido";
            }
            return "Cola vacía - nada que atender";
        }
        else if (comando.StartsWith("E "))
        {
            if (int.TryParse(comando.Substring(2), out int id))
            {
                cola.Add(id);
                return $"Encolado {id}";
            }
            return "ID inválido";
        }
        
        return "Comando inválido";
    }

    // ==================== EJERCICIO 16 ====================
    static void Ejercicio16()
    {
        Console.WriteLine("16) Limpieza de texto y top-k por longitud");
        Console.WriteLine("Descripción: Procesa texto y encuentra palabras más largas\n");
        
        Console.Write("Texto: ");
        string texto = Console.ReadLine() ?? "";
        int k = LeerEnteroPositivo("k: ");
        
        var resultado = ProcesarTexto(texto, k);
        
        Console.WriteLine($"Lista limpia: [{string.Join(", ", resultado.palabrasLimpias)}]");
        Console.WriteLine($"Top-{k}: [{string.Join(", ", resultado.topK)}]");
    }

    static (List<string> palabrasLimpias, List<string> topK) ProcesarTexto(string texto, int k)
    {
        // Definir delimitadores
        char[] delimitadores = { ' ', ',', ';', '.', '!', '?', ':', '\t', '\n' };
        string[] palabras = texto.Split(delimitadores, StringSplitOptions.RemoveEmptyEntries);
        
        // Limpiar y eliminar duplicados
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
        
        // Obtener top K por longitud
        var topK = palabrasLimpias
            .OrderByDescending(p => p.Length)
            .ThenBy(p => p)
            .Take(k)
            .ToList();
        
        return (palabrasLimpias, topK);
    }

    // ==================== EJERCICIO 17 ====================
    static void Ejercicio17()
    {
        Console.WriteLine("17) Agenda: huecos libres (intervalos)");
        Console.WriteLine("Descripción: Encuentra huecos libres en agenda\n");
        
        List<(int inicio, int fin)> ocupados = LeerIntervalos();
        int X = LeerEnteroPositivo("Minutos mínimos (X): ");
        
        List<(int inicio, int fin)> libres = CalcularHuecosLibres(ocupados, X);
        
        Console.WriteLine("Huecos libres:");
        foreach (var libre in libres)
        {
            Console.WriteLine($"[{libre.inicio},{libre.fin})");
        }
    }

    static List<(int inicio, int fin)> LeerIntervalos()
    {
        List<(int inicio, int fin)> intervalos = new List<(int, int)>();
        Console.WriteLine("Ingrese intervalos ocupados [inicio,fin), vacío para terminar:");
        
        while (true)
        {
            Console.Write("Inicio: ");
            string inicioStr = Console.ReadLine() ?? "";
            if (string.IsNullOrEmpty(inicioStr)) break;
            
            Console.Write("Fin: ");
            string finStr = Console.ReadLine() ?? "";
            if (string.IsNullOrEmpty(finStr)) break;
            
            if (int.TryParse(inicioStr, out int inicio) && 
                int.TryParse(finStr, out int fin) &&
                inicio >= 0 && fin <= 1440 && inicio < fin)
            {
                intervalos.Add((inicio, fin));
            }
            else
            {
                Console.WriteLine("Intervalo inválido. Debe ser 0 ≤ inicio < fin ≤ 1440");
            }
        }
        
        return intervalos;
    }

    static List<(int inicio, int fin)> CalcularHuecosLibres(List<(int inicio, int fin)> ocupados, int X)
    {
        // Unir intervalos solapados
        if (ocupados.Count > 0)
        {
            ocupados.Sort((a, b) => a.inicio.CompareTo(b.inicio));
            
            List<(int inicio, int fin)> unidos = new List<(int, int)>();
            var actual = ocupados[0];
            
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
        
        // Calcular huecos libres
        List<(int inicio, int fin)> libres = new List<(int, int)>();
        int tiempo = 0;
        
        foreach (var ocupado in ocupados)
        {
            if (ocupado.inicio - tiempo >= X)
            {
                libres.Add((tiempo, ocupado.inicio));
            }
            tiempo = Math.Max(tiempo, ocupado.fin);
        }
        
        // Verificar el último hueco
        if (1440 - tiempo >= X)
        {
            libres.Add((tiempo, 1440));
        }
        
        return libres;
    }

    // ==================== EJERCICIO 18 ====================
    static void Ejercicio18()
    {
        Console.WriteLine("18) Inventario por categorías (sin diccionario)");
        Console.WriteLine("Descripción: Agrupa cantidades por categoría\n");
        
        Console.Write("Categorías (separadas por espacios): ");
        string[] categorias = Console.ReadLine()?.Split(' ', StringSplitOptions.RemoveEmptyEntries) ?? new string[0];
        
        Console.Write("Cantidades (separadas por espacios): ");
        string[] cantidadesStr = Console.ReadLine()?.Split(' ', StringSplitOptions.RemoveEmptyEntries) ?? new string[0];
        
        if (categorias.Length != cantidadesStr.Length)
        {
            Console.WriteLine("Error: Debe haber la misma cantidad de categorías y cantidades.");
            return;
        }
        
        var resultado = AgruparPorCategoria(categorias, cantidadesStr);
        
        Console.WriteLine("\n--- Totales por Categoría ---");
        for (int i = 0; i < resultado.categoriasUnicas.Count; i++)
        {
            Console.WriteLine($"{resultado.categoriasUnicas[i]}:{resultado.totales[i]}");
        }
    }

    static (List<string> categoriasUnicas, List<int> totales) 
        AgruparPorCategoria(string[] categorias, string[] cantidadesStr)
    {
        List<string> categoriasUnicas = new List<string>();
        List<int> totales = new List<int>();
        
        for (int i = 0; i < categorias.Length; i++)
        {
            if (!int.TryParse(cantidadesStr[i], out int cantidad))
            {
                Console.WriteLine($"Error: Cantidad inválida '{cantidadesStr[i]}'");
                continue;
            }
            
            string categoria = categorias[i];
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
        
        return (categoriasUnicas, totales);
    }

    // ==================== EJERCICIO 19 ====================
    static void Ejercicio19()
    {
        Console.WriteLine("19) Top-N palabras más frecuentes");
        Console.WriteLine("Descripción: Encuentra palabras más frecuentes\n");
        
        Console.Write("Texto: ");
        string texto = Console.ReadLine() ?? "";
        int N = LeerEnteroPositivo("N: ");
        
        var topN = ObtenerTopNPalabrasFrecuentes(texto, N);
        
        Console.WriteLine($"\nTop-{N} palabras más frecuentes:");
        foreach (var item in topN)
        {
            Console.WriteLine($"{item.palabra}:{item.frecuencia}");
        }
    }

    static List<(string palabra, int frecuencia)> ObtenerTopNPalabrasFrecuentes(string texto, int N)
    {
        // Definir delimitadores
        char[] delimitadores = { ' ', ',', ';', '.', '!', '?', ':', '\t', '\n', '(', ')', '[', ']' };
        string[] palabras = texto.ToLower().Split(delimitadores, StringSplitOptions.RemoveEmptyEntries);
        
        // Contar frecuencias
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
        
        // Crear ranking
        List<(string palabra, int frecuencia)> ranking = new List<(string, int)>();
        for (int i = 0; i < palabrasUnicas.Count; i++)
        {
            ranking.Add((palabrasUnicas[i], frecuencias[i]));
        }
        
        // Ordenar por frecuencia descendente, luego alfabéticamente
        ranking.Sort((a, b) =>
        {
            int cmp = b.frecuencia.CompareTo(a.frecuencia);
            return cmp != 0 ? cmp : a.palabra.CompareTo(b.palabra);
        });
        
        // Retornar top N
        return ranking.Take(N).ToList();
    }

    // ==================== EJERCICIO 20 ====================
    static void Ejercicio20()
    {
        Console.WriteLine("20) Ventas diarias (24 horas)");
        Console.WriteLine("Descripción: Analiza ventas por horas del día\n");
        
        int[] ventas = LeerVentas24Horas();
        var analisis = AnalizarVentas(ventas);
        
        Console.WriteLine($"\n--- RESULTADOS VENTAS DIARIAS ---");
        Console.WriteLine($"Total: {analisis.total}");
        Console.WriteLine($"Hora pico: {analisis.horaPico}:00 ({ventas[analisis.horaPico]} ventas)");
        Console.WriteLine($"Promedio Mañana (6-11): {analisis.promManana:F2}");
        Console.WriteLine($"Promedio Tarde (12-17): {analisis.promTarde:F2}");
        Console.WriteLine($"Promedio Noche (18-23): {analisis.promNoche:F2}");
        Console.WriteLine($"Promedio Diario: {analisis.promedioDiario:F2}");
        Console.WriteLine($"Horas sobre promedio: [{string.Join(", ", analisis.horasSobrePromedio)}]");
    }

    static int[] LeerVentas24Horas()
    {
        int[] ventas = new int[24];
        Console.WriteLine("Ingrese ventas para cada hora (0-23):");
        
        for (int i = 0; i < 24; i++)
        {
            ventas[i] = LeerEnteroNoNegativo($"Hora {i:00}:00: ");
        }
        
        return ventas;
    }

    static (int total, int horaPico, double promManana, double promTarde, double promNoche, 
            double promedioDiario, List<int> horasSobrePromedio) AnalizarVentas(int[] ventas)
    {
        // Calcular total y hora pico
        int total = 0;
        int horaPico = 0;
        int maxVentas = ventas[0];
        
        for (int i = 0; i < 24; i++)
        {
            total += ventas[i];
            if (ventas[i] > maxVentas)
            {
                maxVentas = ventas[i];
                horaPico = i;
            }
        }
        
        // Calcular promedios por franja
        double promManana = CalcularPromedioFranja(ventas, 6, 11);
        double promTarde = CalcularPromedioFranja(ventas, 12, 17);
        double promNoche = CalcularPromedioFranja(ventas, 18, 23);
        double promedioDiario = total / 24.0;
        
        // Encontrar horas sobre promedio
        List<int> horasSobrePromedio = new List<int>();
        for (int i = 0; i < 24; i++)
        {
            if (ventas[i] > promedioDiario)
            {
                horasSobrePromedio.Add(i);
            }
        }
        
        return (total, horaPico, promManana, promTarde, promNoche, promedioDiario, horasSobrePromedio);
    }

    static double CalcularPromedioFranja(int[] ventas, int inicio, int fin)
    {
        int suma = 0;
        int contador = 0;
        
        for (int i = inicio; i <= fin; i++)
        {
            suma += ventas[i];
            contador++;
        }
        
        return contador > 0 ? (double)suma / contador : 0;
    }

    // ==================== MÉTODOS UTILITARIOS ====================
    
    static void MostrarArreglo<T>(T[] arreglo)
    {
        Console.WriteLine($"[{string.Join(", ", arreglo)}]");
    }

    static void MostrarLista<T>(List<T> lista)
    {
        Console.WriteLine($"[{string.Join(", ", lista)}]");
    }

    static double[] ConvertirTextoAArregloDoubles()
    {
        while (true)
        {
            try
            {
                Console.Write("Ingrese números separados por espacios: ");
                string entrada = Console.ReadLine() ?? "";
                
                if (string.IsNullOrWhiteSpace(entrada))
                {
                    throw new Exception("La línea no puede estar vacía");
                }

                string[] partes = entrada.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                double[] arreglo = new double[partes.Length];
                
                for (int i = 0; i < partes.Length; i++)
                {
                    if (!double.TryParse(partes[i], out arreglo[i]))
                    {
                        throw new FormatException($"'{partes[i]}' no es un número válido");
                    }
                }
                
                return arreglo;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}. Intente nuevamente.");
            }
        }
    }

    static int LeerEntero(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);
            if (int.TryParse(Console.ReadLine(), out int valor))
            {
                return valor;
            }
            Console.WriteLine("Error: Debe ingresar un número entero válido.");
        }
    }

    static int LeerEnteroPositivo(string mensaje)
    {
        while (true)
        {
            int valor = LeerEntero(mensaje);
            if (valor > 0) return valor;
            Console.WriteLine("Error: El valor debe ser positivo.");
        }
    }

    static int LeerEnteroNoNegativo(string mensaje)
    {
        while (true)
        {
            int valor = LeerEntero(mensaje);
            if (valor >= 0) return valor;
            Console.WriteLine("Error: El valor no puede ser negativo.");
        }
    }

    static int LeerIndice(string mensaje, int longitud)
    {
        while (true)
        {
            int indice = LeerEntero(mensaje);
            if (indice >= 0 && indice < longitud) return indice;
            Console.WriteLine($"Error: El índice debe estar entre 0 y {longitud - 1}.");
        }
    }

    static int LeerIndiceMax(string mensaje, int minimo, int longitud)
    {
        while (true)
        {
            int indice = LeerEntero(mensaje);
            if (indice >= minimo && indice < longitud) return indice;
            Console.WriteLine($"Error: El índice debe estar entre {minimo} y {longitud - 1}.");
        }
    }
}