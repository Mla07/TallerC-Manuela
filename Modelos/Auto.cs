namespace TallerPOO.Modelos
{
    
    // Se usan los : para indicar herencia
    public class Auto : Vehiculo
    {
        public int Puertas { get; set; }
        // Override para sobrescribir el método virtual de la clase base
        public override string Describir() => $"Vehículo: Marca={Marca}, Puertas={Puertas}";
    }
}
