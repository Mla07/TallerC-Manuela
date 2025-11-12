using System;
using System.Collections.Generic;
using System.Linq;
namespace TallerPOO.Modelos
{
    public class Agenda
    {
        private readonly List<Contacto> contactos = new();
        public void Agregar(Contacto c) => contactos.Add(c);
        public Contacto? BuscarPorNombre(string nombre)
            => contactos.FirstOrDefault(c => c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        public void Listar()
        {
            Console.WriteLine("Contactos:");
            int i = 1;
            foreach (var c in contactos)
                Console.WriteLine($"• {i++}) {c.Nombre} - {c.Telefono}");
        }
    }
}
