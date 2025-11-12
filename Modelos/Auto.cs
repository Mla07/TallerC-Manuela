namespace TallerPOO.Modelos
{
    public class Auto : Vehiculo
    {
        public int Puertas { get; set; }
        public override string Describir() => $"Vehículo: Marca={Marca}, Puertas={Puertas}";
    }
}
