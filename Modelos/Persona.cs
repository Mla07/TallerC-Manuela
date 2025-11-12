using System;
namespace TallerPOO.Modelos
{
    public class Persona
    {
        public string Nombre { get; set; } = "";
        private int edad;
        public int Edad
        {
            // Validación ejercicio 3

            //Get trae el valor de la variable edad
            get => edad;
            
            //Set asigna el valor a la variable edad
            //Incluyendo validación
            set
            {   

                //O es menor que 0 o es mayor que 120, cualquiera de los dos lanza error
                if (value < 0 || value > 120)
                    throw new ArgumentOutOfRangeException("La edad debe estar entre 0 y 120.");
                edad = value;
            }
        }
        public bool EsMayorDeEdad => Edad >= 18;
        public Persona()
        {

        }
        
        public Persona(string nombre, int edad) { 
            Nombre = nombre; Edad = edad; 
        }
        public void Saludar() => Console.WriteLine($"Hola, soy {Nombre} y tengo {Edad} años.");
    }
}
