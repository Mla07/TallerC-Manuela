using System;
namespace TallerPOO.Modelos
{
    public class Vehiculo
    {
        public string Marca { get; set; } = "";
        public void Arrancar() => Console.WriteLine("Arrancando...");
        public virtual string Describir() => $"Vehículo: Marca={Marca}";
    }
}
