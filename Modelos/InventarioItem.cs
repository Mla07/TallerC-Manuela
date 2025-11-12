using System;
namespace TallerPOO.Modelos
{
    public class InventarioItem
    {
        public Producto Producto { get; }
        public int Stock { get; private set; }
        public InventarioItem(Producto p, int stockInicial = 0)
        {
            Producto = p;
            Stock = Math.Max(0, stockInicial);
        }
        public void Entrar(int cantidad)
        {
            if (cantidad <= 0) throw new ArgumentException("Cantidad inválida");
            Stock += cantidad;
        }
        public bool Salir(int cantidad)
        {
            if (cantidad <= 0) throw new ArgumentException("Cantidad inválida");
            if (Stock < cantidad) return false;
            Stock -= cantidad;
            return true;
        }
    }
}
