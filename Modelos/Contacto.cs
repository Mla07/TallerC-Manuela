using System;
using System.Text.RegularExpressions;
namespace TallerPOO.Modelos
{
    public class Contacto
    {
        private string telefono = "";
        public string Nombre { get; set; } = "";
        public string Telefono
        {
            get => telefono;
            set
            {
                if (!Regex.IsMatch(value, @"^\d{7,15}$"))
                    throw new ArgumentException("Teléfono inválido (solo dígitos, 7–15 caracteres)");
                telefono = value;
            }
        }
        public Contacto(string nombre, string telefono)
        {
            Nombre = nombre;
            Telefono = telefono;
        }
    }
}
