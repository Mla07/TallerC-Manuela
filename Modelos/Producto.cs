using System;
namespace TallerPOO.Modelos
{
    public class Producto
    {
        private double precio;
        public string Nombre { get; set; } = "";
        public double Precio
        {
            get => precio;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Precio no puede ser negativo");
                precio = value;
            }
        }
    }
}
