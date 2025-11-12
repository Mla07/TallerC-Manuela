using System;
namespace TallerPOO.Modelos
{
    //Clase principal
    public class Vehiculo
    {
        public string Marca { get; set; } = "";
        public void Arrancar() => Console.WriteLine("Arrancando...");
        //Virtual para que pueda ser sobrescrito
        public virtual string Describir() => $"Vehículo: Marca={Marca}";
    }
}
