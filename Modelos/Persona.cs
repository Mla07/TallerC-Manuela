using System;
namespace TallerPOO.Modelos
{
    public class Persona
    {
        public string Nombre { get; set; } = "";
        private int edad;
        public int Edad
        {
            get => edad;
            set
            {
                if (value < 0 || value > 120)
                    throw new ArgumentOutOfRangeException("La edad debe estar entre 0 y 120.");
                edad = value;
            }
        }
        public bool EsMayorDeEdad => Edad >= 18;
        public Persona() { }
        public Persona(string nombre, int edad) { Nombre = nombre; Edad = edad; }
        public void Saludar() => Console.WriteLine($"Hola, soy {Nombre} y tengo {Edad} años.");
    }
}
