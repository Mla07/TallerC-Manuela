using System;
namespace TallerPOO.Modelos
{
    public abstract class Figura
    {
        public abstract double Area();
        public void MostrarArea() => Console.WriteLine($"Área = {Area():F2}");
    }
}
