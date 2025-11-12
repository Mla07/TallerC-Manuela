namespace TallerPOO.Modelos
{
    public class Rectangulo : Figura
    {
        public double Ancho { get; set; }
        public double Alto { get; set; }
        public Rectangulo(double a, double h) { Ancho = a; Alto = h; }
        public override double Area() => Ancho * Alto;
        public override string ToString() => $"Rectángulo({Ancho:F2}x{Alto:F2})";
    }
}
