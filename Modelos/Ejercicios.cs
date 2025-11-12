using System;
namespace TallerPOO.Modelos
{
    public static class Ejercicios
    {
        public static void Ejercicio1()
        {
            Persona p1 = new Persona { Nombre = "Ana", Edad = 20 };
            Persona p2 = new Persona { Nombre = "Luis", Edad = 22 };
            p1.Saludar(); p2.Saludar();
        }

        public static void Ejercicio2()
        {
            Persona p1 = new Persona("Ana", 20);
            Persona p2 = new Persona("Luis", 22);
            p1.Saludar(); p2.Saludar();
        }

        public static void Ejercicio3()
        {
            Persona p = new Persona("Carlos", 25);
            try
            {
                p.Edad = 25;
                Console.WriteLine($"Edad asignada: {p.Edad}");
                p.Edad = 150;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void Ejercicio4()
        {
            Persona a = new Persona("Ana", 20);
            Persona b = new Persona("Pablo", 16);
            Console.WriteLine($"{a.Nombre} ({a.Edad}): Mayor de edad = {a.EsMayorDeEdad}");
            Console.WriteLine($"{b.Nombre} ({b.Edad}): Mayor de edad = {b.EsMayorDeEdad}");
        }

        public static void Ejercicio5()
        {
            CalculadoraBasica calc = new CalculadoraBasica();
            Console.WriteLine($"3 + 5 = {calc.Sumar(3,5)}");
            Console.WriteLine($"10 - 4 = {calc.Restar(10,4)}");
            Console.WriteLine($"6 * 7 = {calc.Multiplicar(6,7)}");
            try { Console.WriteLine($"10 / 0 = {calc.Dividir(10,0)}"); }
            catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
            Console.WriteLine($"Operaciones realizadas: {CalculadoraBasica.ConteoOperaciones}");
        }
    

        // === 6) Estáticos vs instancia (conteo de operaciones) ===
        public static void Ejercicio6()
        {
            CalculadoraBasica c = new CalculadoraBasica();
            c.Sumar(1, 2);
            c.Multiplicar(3, 4);
            Console.WriteLine($"Operaciones realizadas: {CalculadoraBasica.ConteoOperaciones}");
        }

        // === 7) Herencia: Vehiculo, Auto, Bicicleta ===
        public static void Ejercicio7()
        {
            Auto a = new Auto { Marca = "Ford", Puertas = 4 };
            Bicicleta b = new Bicicleta { Marca = "GW", TieneCanastilla = true };
            a.Arrancar(); Console.WriteLine(a.Describir());
            b.Arrancar(); Console.WriteLine(b.Describir());
        }

        // === 8) Polimorfismo con virtual/override ===
        public static void Ejercicio8()
        {
            var lista = new System.Collections.Generic.List<Vehiculo>
            {
                new Auto{Marca="Ford", Puertas=4},
                new Bicicleta{Marca="GW", TieneCanastilla=true}
            };
            foreach (var v in lista) Console.WriteLine(v.Describir());
        }

        // === 9) Interfaz INotificable ===
        public static void Ejercicio9()
        {
            void Avisar(INotificable canal, string cliente)
                => canal.Enviar($"Pedido listo para {cliente}");
            Avisar(new NotificadorEmail(), "Ana");
            Avisar(new NotificadorSms(), "Luis");
        }

        // === 10) Clase abstracta: Figura ===
        public static void Ejercicio10()
        {
            Figura f1 = new Circulo(2);
            Figura f2 = new Rectangulo(4, 5);
            f1.MostrarArea();
            f2.MostrarArea();
        }

        // === 11) Mini-agenda de contactos ===
        public static void Ejercicio11()
        {
            Agenda ag = new Agenda();
            try
            {
                ag.Agregar(new Contacto("Ana", "6044445555"));
                ag.Agregar(new Contacto("Marta", "3215557777"));
                ag.Agregar(new Contacto("Luis", "3146668888"));
            }
            catch (Exception ex) { Console.WriteLine($"Error al agregar: {ex.Message}"); }
            var buscado = ag.BuscarPorNombre("marta");
            if (buscado != null) Console.WriteLine($"Encontrado: {buscado.Nombre} - {buscado.Telefono}");
            ag.Listar();
        }

        // === 12) Sistema de calificaciones ===
        public static void Ejercicio12()
        {
            try
            {
                Asignatura a1 = new Asignatura { Nombre = "Programación I", Notas = new double[] { 3.5, 4.0, 3.9 } };
                Asignatura a2 = new Asignatura { Nombre = "Cálculo I", Notas = new double[] { 4.5, 4.0, 4.1 } };
                Console.WriteLine($"{a1.Nombre}: {a1.Promedio():F2}");
                Console.WriteLine($"{a2.Nombre}: {a2.Promedio():F2}");
            }
            catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
        }

        // === 13) Inventario simple ===
        public static void Ejercicio13()
        {
            Producto p = new Producto { Nombre = "Cuaderno", Precio = 2500 };
            InventarioItem item = new InventarioItem(p, 10);
            item.Entrar(2);
            bool ok = item.Salir(20);
            if (!ok) Console.WriteLine("Intento de salida 20 -> rechazado (stock insuficiente)");
            Console.WriteLine($"Stock final de \"{p.Nombre}\": {item.Stock}");
        }

        // === 14) Envío de notificaciones ===
        public static void Ejercicio14()
        {
            void AvisarPedidoListo(INotificable canal, string cliente)
                => canal.Enviar($"Pedido listo para {cliente}");
            string[] clientes = { "Ana", "Luis", "Marta" };
            var email = new NotificadorEmail();
            var sms = new NotificadorSms();
            foreach (var c in clientes) AvisarPedidoListo(email, c);
            foreach (var c in clientes) AvisarPedidoListo(sms, c);
        }

        // === 15) Reporte de figuras ===
        public static void Ejercicio15()
        {
            var figuras = new System.Collections.Generic.List<Figura>
            {
                new Circulo(2),
                new Rectangulo(3,4),
                new Circulo(4),
                new Rectangulo(2,5),
                new Circulo(1.5)
            };
            double totalArea = 0;
            Figura mayor = figuras[0];
            foreach (var f in figuras)
            {
                double area = f.Area();
                totalArea += area;
                if (area > mayor.Area()) mayor = f;
            }
            Console.WriteLine($"Total de figuras: {figuras.Count}");
            Console.WriteLine($"Área total: {totalArea:F2}");
            Console.WriteLine($"Mayor área: {mayor} con {mayor.Area():F2}");
        }
    }
}