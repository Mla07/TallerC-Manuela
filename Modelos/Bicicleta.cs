namespace TallerPOO.Modelos
{
    public class Bicicleta : Vehiculo
    {
        public bool TieneCanastilla { get; set; }
        public override string Describir() => $"Vehículo: Marca={Marca}, Canastilla={TieneCanastilla}";
    }
}
