using System;
using System.Linq;
namespace TallerPOO.Modelos
{
    public class Asignatura
    {
        public string Nombre { get; set; } = "";
        public double[] Notas { get; set; } = Array.Empty<double>();
        public double Promedio()
        {
            if (Notas.Length < 1)
                throw new InvalidOperationException("Debe tener al menos una nota");
            if (Notas.Any(n => n < 0 || n > 5))
                throw new ArgumentOutOfRangeException("Notas fuera de rango (0–5)");
            return Notas.Average();
        }
    }
}
