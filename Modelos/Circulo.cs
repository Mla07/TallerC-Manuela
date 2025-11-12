using System;
namespace TallerPOO.Modelos
{
    public class Circulo : Figura
    {
        public double Radio { get; set; }
        public Circulo(double r) { Radio = r; }
        public override double Area() => Math.PI * Radio * Radio;
        public override string ToString() => $"Círculo(radio={Radio:F2})";
    }
}
