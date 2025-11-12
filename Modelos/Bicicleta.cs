namespace TallerPOO.Modelos
{
    // Se usan los : para indicar herencia
    public class Bicicleta : Vehiculo
    {
        public bool TieneCanastilla { get; set; }
     // Override para sobrescribir el método virtual de la clase base
        public override string Describir() => $"Vehículo: Marca={Marca}, Canastilla={TieneCanastilla}";
    }
}
